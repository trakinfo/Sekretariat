Imports System.Drawing.Printing

Public Class frmLiczbaUczniowByMiejscowoscByRocznik
  Private DS As DataSet ',YearNumber As Integer, RowNumber As Integer
  Public Event NewRow()
  Private Sub frmLiczbaUczniowByMiejscowoscByRocznik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim CH As New CalcHelper
    Me.nudStartYear.Value = CH.StartDateOfSchoolYear.Year
    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(Me.cbSzkola, "Select ID,Alias FROM szkoly;")
    SH.FindComboItem(Me.cbSzkola, CInt(SH.GetDefault("Select ID From szkoly Where IsDefault='1';")))

  End Sub

  Private Sub GetData()
    Dim DBA As New DataBaseAction, SB As New StudentsByBirthYear
    DS = DBA.GetDataSet(SB.CountStudents(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString) & SB.SelectPlace(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString) & SB.SelectYear(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString) & SB.SelectPion(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString))
    'tabela 0 - liczba uczniów w szkole wg miejscowości, roczników i pionów
    'tabela 1 - lista miejscowości wg szkoły
    'tabela 2 - lista roczników w szkole w danym roku szkolnym
    'tabela 3 -  lista pionów klasowych w szkole
    DS.Tables(2).Columns.Add("Status", System.Type.GetType("System.Boolean"))
    DS.Tables(2).Columns.Add("Nazwa", System.Type.GetType("System.String"))
    Dim Row As DataRow
    Row = DS.Tables(2).NewRow()
    Row("Rocznik") = "0"
    Row("Status") = True
    Row("Nazwa") = "Razem"
    DS.Tables(2).Rows.Add(Row)
    For Each R As DataRow In DS.Tables(2).Select("Rocznik<>0")
      R.Item(1) = True
      R.Item(2) = R.Item(0)
    Next

    'YearNumber = DBA.CountRecords(SB.CountYear(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString))
    'DT = DBA.GetDataTable(SB.SelectPion(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString))
    'PionNumber = DS.Tables(3).Rows.Count 'DT.Rows.Count
    DataGridConfig()
  End Sub
  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    GetData()
    cmdPrint.Enabled = True
  End Sub
  Private Sub nudStartYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudStartYear.ValueChanged
    If Not nudStartYear.Created Then Exit Sub
    Me.nudEndYear.Value = Me.nudStartYear.Value + 1
    If Not cbSzkola.SelectedItem Is Nothing Then
      GetData()
    End If
  End Sub
  Private Sub chkVirtual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtual.CheckedChanged
    If Not cbSzkola.SelectedItem Is Nothing Then
      GetData()
    End If
  End Sub

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Dispose(True)
  End Sub


  '***************************************************************************************************************

  Private Sub DataGridConfig()
    Me.dgvStudentsByPlaceByYear.Rows.Clear()
    Me.dgvStudentsByPlaceByYear.Columns.Clear()
    SetColumns(Me.dgvStudentsByPlaceByYear)
    SetRows()
    With dgvStudentsByPlaceByYear
      .AutoGenerateColumns = False
      .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      .Columns(0).Frozen = True
      .Columns(0).ReadOnly = True
      .Columns(1).Frozen = True
      .Columns(1).ReadOnly = True
      For Each col As DataGridViewColumn In .Columns
        col.SortMode = DataGridViewColumnSortMode.NotSortable

      Next

      .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
      .ColumnHeadersHeight = 40
      .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
      .ColumnHeadersDefaultCellStyle.Font = New Font(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold)
      AddHandler .CellPainting, AddressOf dataGridView1_CellPainting
      AddHandler .Paint, AddressOf dataGridView1_Paint
      AddHandler .Scroll, AddressOf dataGridView1_Scroll
      AddHandler .ColumnWidthChanged, AddressOf dataGridView1_ColumnWidthChanged
    End With
  End Sub
  Private Sub SetColumns(ByVal dgvName As DataGridView)
    Dim NameCol, NrCol As New DataGridViewColumn
    With dgvName
      NrCol.Name = "Nr"
      NrCol.HeaderText = ""
      NrCol.Width = 40
      NrCol.CellTemplate = New DataGridViewTextBoxCell()
      NrCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      NrCol.DefaultCellStyle.BackColor = Color.Snow
      .Columns.Add(NrCol)

      NameCol.Name = "MiejsceZam"
      NameCol.HeaderText = ""
      NameCol.Width = 200
      NameCol.CellTemplate = New DataGridViewTextBoxCell()
      NameCol.DefaultCellStyle.BackColor = Color.Snow
      .Columns.Add(NameCol)

      ', DT As DataTable


      'tu było DT SelectPion
      Dim Idx As Integer = 0, ShiftColor As Boolean = False, GridColor() As Color = {Color.LightYellow, Color.MintCream}
      For j As Integer = 0 To DS.Tables(2).Select("Rocznik<>0").GetLength(0) - 1 'YearNumber - 1
        ShiftColor = Not ShiftColor
        For i As Integer = 0 To DS.Tables(3).Select().GetUpperBound(0) 'DT.Select().GetUpperBound(0)
          Dim ObjectColumn As New DataGridViewTextBoxColumn
          ObjectColumn.HeaderText = DS.Tables(3).Select()(i).Item(0).ToString
          ObjectColumn.Width = 40
          ObjectColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
          ObjectColumn.DefaultCellStyle.BackColor = GridColor(Convert.ToInt32(ShiftColor))
          ObjectColumn.CellTemplate = New DataGridViewTextBoxCell
          ObjectColumn.ReadOnly = True
          .Columns.Add(ObjectColumn)
        Next

      Next
      For i As Integer = 0 To DS.Tables(3).Select().GetUpperBound(0)
        Dim TotalColumn As New DataGridViewTextBoxColumn
        With TotalColumn
          .HeaderText = DS.Tables(3).Select()(i).Item(0).ToString
          .Width = 40
          .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
          .DefaultCellStyle.BackColor = Color.AntiqueWhite
          .DefaultCellStyle.ForeColor = Color.Red
          .HeaderCell.Style.ForeColor = Color.Red
          .DefaultCellStyle.Font = New Font(dgvStudentsByPlaceByYear.DefaultCellStyle.Font, FontStyle.Bold)
          .CellTemplate = New DataGridViewTextBoxCell
          .ReadOnly = True
        End With
        .Columns.Add(TotalColumn)
      Next
    End With
  End Sub

  Private Sub SetRows()
    Dim DBA As New DataBaseAction, SB As New StudentsByBirthYear
    If DS.Tables(1).Rows.Count > 0 Then
      'If RowNumber > 0 Then
      Dim idx As Integer = 2
      With dgvStudentsByPlaceByYear
        .Rows.Add(DS.Tables(1).Rows.Count) '.Rows.Add(RowNumber)
        For i As Integer = 0 To DS.Tables(1).Rows.Count - 1
          .Rows(i).Cells(0).Value = i + 1
          .Rows(i).Cells(1).Value = DS.Tables(1).Rows(i).Item(0).ToString
          For k As Integer = 0 To DS.Tables(2).Select("Rocznik<>0").GetLength(0) - 1 'YearNumber - 1
            For j As Integer = 0 To DS.Tables(3).Rows.Count - 1
              If DS.Tables(0).Select("Miejscowosc='" & DS.Tables(1).Rows(i).Item(0).ToString & "' AND Rocznik=" & CType(DS.Tables(2).Rows(k).Item(0), Integer) & " AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'").GetLength(0) > 0 Then
                .Rows(i).Cells(idx).Value = DS.Tables(0).Select("Miejscowosc='" & DS.Tables(1).Rows(i).Item(0).ToString & "' AND Rocznik=" & CType(DS.Tables(2).Rows(k).Item(0), Integer) & " AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'")(0).Item("Liczba").ToString()
                .Rows(i).Cells(idx).ToolTipText = "Rocznik: " & DS.Tables(2).Rows(k).Item(0).ToString & vbNewLine & "Pion: " & DS.Tables(3).Rows(j).Item(0).ToString
              Else
                .Rows(i).Cells(idx).Value = "0"
                .Rows(i).Cells(idx).ToolTipText = "Rocznik: " & DS.Tables(2).Rows(k).Item(0).ToString & vbNewLine & "Pion: " & DS.Tables(3).Rows(j).Item(0).ToString
              End If
              idx += 1
            Next
          Next
          '**********************************************
          For j As Integer = 0 To DS.Tables(3).Rows.Count - 1
            .Rows(i).Cells(idx).Value = IIf(DS.Tables(0).Select("Miejscowosc='" & DS.Tables(1).Rows(i).Item(0).ToString & "' AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'").GetLength(0) > 0, DS.Tables(0).Compute("Sum(Liczba)", "Miejscowosc='" & DS.Tables(1).Rows(i).Item(0).ToString & "'  AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'"), "0").ToString
            .Rows(i).Cells(idx).ToolTipText = "Miejscowość: " & DS.Tables(1).Rows(i).Item(0).ToString & vbNewLine & "Pion: " & DS.Tables(3).Rows(j).Item(0).ToString
            idx += 1
          Next

          idx = 2
        Next

        .Rows.Add()
        .Rows(.Rows.Count - 1).Cells(0).Value = ""
        .Rows(.Rows.Count - 1).Cells(1).Value = "Razem"
        .Rows(.Rows.Count - 1).DefaultCellStyle.ForeColor = Color.Red
        .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.AntiqueWhite
        .Rows(.Rows.Count - 1).DefaultCellStyle.Font = New Font(.DefaultCellStyle.Font, FontStyle.Bold)
        For k As Integer = 0 To DS.Tables(2).Select("Rocznik<>0").GetLength(0) - 1 'YearNumber - 1
          For j As Integer = 0 To DS.Tables(3).Rows.Count - 1
            If DS.Tables(0).Select("Rocznik=" & CType(DS.Tables(2).Rows(k).Item(0), Integer) & " AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'").GetLength(0) > 0 Then
              .Rows(.Rows.Count - 1).Cells(idx).Value = DS.Tables(0).Compute("Sum(Liczba)", "Rocznik=" & CType(DS.Tables(2).Rows(k).Item(0), Integer) & " AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'").ToString()
            Else
              .Rows(.Rows.Count - 1).Cells(idx).Value = "0"
            End If
            .Rows(.Rows.Count - 1).Cells(idx).ToolTipText = "Rocznik: " & DS.Tables(2).Rows(k).Item(0).ToString & vbNewLine & "Pion: " & DS.Tables(3).Rows(j).Item(0).ToString
            idx += 1
          Next
        Next
        
        For j As Integer = 0 To DS.Tables(3).Rows.Count - 1
          If DS.Tables(0).Select("Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'").GetLength(0) > 0 Then
            .Rows(.Rows.Count - 1).Cells(idx).Value = DS.Tables(0).Compute("Sum(Liczba)", "Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'").ToString()
          Else
            .Rows(.Rows.Count - 1).Cells(idx).Value = "0"
          End If
          .Rows(.Rows.Count - 1).Cells(idx).ToolTipText = "Pion: " & DS.Tables(3).Rows(j).Item(0).ToString
          .Rows(.Rows.Count - 1).Cells(idx).Style.BackColor = Color.Yellow
          idx += 1
        Next
      End With
    End If
  End Sub

  Private Sub dataGridView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs)
    Dim rtHeader As Rectangle = Me.dgvStudentsByPlaceByYear.DisplayRectangle
    rtHeader.Height = CType(Me.dgvStudentsByPlaceByYear.ColumnHeadersHeight / 2, Integer)
    Me.dgvStudentsByPlaceByYear.Invalidate(rtHeader)
  End Sub
  Private Sub dataGridView1_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs)
    Dim rtHeader As Rectangle = Me.dgvStudentsByPlaceByYear.DisplayRectangle
    rtHeader.Height = CType(Me.dgvStudentsByPlaceByYear.ColumnHeadersHeight / 2, Integer)
    Me.dgvStudentsByPlaceByYear.Invalidate(rtHeader)
  End Sub
  Private Sub dataGridView1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
    Dim StrFormat As New StringFormat()
    StrFormat.Alignment = StringAlignment.Center
    StrFormat.LineAlignment = StringAlignment.Center

    Dim NrCol As Rectangle = Me.dgvStudentsByPlaceByYear.GetCellDisplayRectangle(0, -1, True)

    e.Graphics.DrawString("L.p.", New Font(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold), New SolidBrush(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.ForeColor), NrCol, StrFormat)

    Dim PlaceName As Rectangle = Me.dgvStudentsByPlaceByYear.GetCellDisplayRectangle(1, -1, True)

    e.Graphics.DrawString("Miejscowość", New Font(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold), New SolidBrush(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.ForeColor), PlaceName, StrFormat)


    'Dim DBA As New DataBaseAction, SB As New StudentsByBirthYear, DT As DataTable
    'DT = DBA.GetDataTable(SB.SelectYear(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString))
    Dim j As Integer = 0
    While j < DS.Tables(2).Select("Rocznik<>0").GetLength(0) 'YearNumber
      Dim r1 As Rectangle = Me.dgvStudentsByPlaceByYear.GetCellDisplayRectangle(j * DS.Tables(3).Rows.Count + 2, -1, True)
      r1.X += 1
      r1.Y += 1
      r1.Width = r1.Width * DS.Tables(3).Rows.Count - 2
      r1.Height = CType(r1.Height / 2 - 2, Integer)
      e.Graphics.FillRectangle(New SolidBrush(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.BackColor), r1)
      e.Graphics.DrawString(DS.Tables(2).Select()(j).Item(0).ToString, New Font(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold), New SolidBrush(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.ForeColor), r1, StrFormat)
      'e.Graphics.DrawString(DT.Select()(j).Item(0).ToString, New Font(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold), New SolidBrush(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.ForeColor), r1, StrFormat)
      j += 1
    End While
    If j > 0 Then
      Dim r2 As Rectangle = Me.dgvStudentsByPlaceByYear.GetCellDisplayRectangle(j * DS.Tables(3).Rows.Count + 2, -1, True)
      r2.X += 1
      r2.Y += 1
      r2.Width = r2.Width * DS.Tables(3).Rows.Count - 2
      r2.Height = CType(r2.Height / 2 - 2, Integer)
      e.Graphics.FillRectangle(New SolidBrush(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.BackColor), r2)
      e.Graphics.DrawString("Razem", New Font(Me.dgvStudentsByPlaceByYear.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold), New SolidBrush(Color.Red), r2, StrFormat)
    End If

  End Sub



  Private Sub dataGridView1_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs)

    If e.RowIndex = -1 AndAlso e.ColumnIndex > -1 Then
      Dim r2 As Rectangle = e.CellBounds
      r2.Y += CType(e.CellBounds.Height / 2, Integer)
      r2.Height = CType(e.CellBounds.Height / 2, Integer)
      e.PaintBackground(r2, True)
      e.PaintContent(r2)
      e.Handled = True
    End If
  End Sub

  Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
    Dim PP As New dlgPrintPreview 
    PP.Doc = New PrintReport(DS)
    AddHandler PP.Doc.PrintPage, AddressOf PrnDoc_PrintPage
    AddHandler NewRow, AddressOf PP.NewRow
    AddHandler PP.YearChanged, AddressOf YearChange
    PP.Doc.DefaultPageSettings.Landscape = CBool(IIf(dgvStudentsByPlaceByYear.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) > (PP.Doc.DefaultPageSettings.PaperSize.Width - (PP.Doc.DefaultPageSettings.Margins.Left + PP.Doc.DefaultPageSettings.Margins.Right)), True, False))
    PP.Doc.DefaultPageSettings.Margins.Left = 40
    PP.Doc.DefaultPageSettings.Margins.Right = 40
    Dim GB As New GroupBox
    GB.Name = "gbRocznik"
    GB.AutoSize = True
    GB.Anchor = AnchorStyles.Top Or AnchorStyles.Right
    GB.Location = New Point(590, 120)
    GB.Text = "Rocznik"
    Dim Space As Integer = 23, YPos As Integer = 20
    GB.Width = 143

    For i As Integer = 0 To DS.Tables(2).Rows.Count - 1 'YearNumber - 1
      Dim ckbRocznik As New CheckBox
      ckbRocznik.Text = DS.Tables(2).Rows(i).Item(2).ToString
      ckbRocznik.Name = DS.Tables(2).Rows(i).Item(0).ToString
      ckbRocznik.Location = New Point(10, YPos)
      ckbRocznik.Checked = True
      AddHandler ckbRocznik.CheckedChanged, AddressOf PP.chkRocznik_checkedChanged
      GB.Controls.Add(ckbRocznik)

      YPos += Space

    Next

    PP.Controls.Add(GB)

    PP.Doc.ReportHeader = New String() {"Liczba uczniów z podziałem na roczniki wg miejscowości zamieszkania"}

    'PP.Doc.Offset(1) = 2
    If PP.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      'DS.Tables.Remove(DT)
    End If
  End Sub
  Private Sub YearChange(ByVal sender As Object)
    DS.Tables(2).Select("Rocznik=" & CType(sender, CheckBox).Name)(0).Item(1) = CType(sender, CheckBox).Checked
  End Sub
  Public Sub PrnDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) 'Handles Doc.PrintPage
    Dim Doc As PrintReport = CType(sender, PrintReport)
    Dim x As Single = Doc.DefaultPageSettings.Margins.Left + CType((e.MarginBounds.Width - (dgvStudentsByPlaceByYear.Columns(0).Width + dgvStudentsByPlaceByYear.Columns(1).Width + dgvStudentsByPlaceByYear.Columns(2).Width * DS.Tables(3).Rows.Count * DS.Tables(2).Select("Status=True").GetLength(0))) / 2, Integer)
    'Dim x As Single = Doc.DefaultPageSettings.Margins.Left - Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Left

    Dim y As Single = Doc.DefaultPageSettings.Margins.Top - Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Top
    Dim PrnVars As New PrintVariables
    Dim TextFont As Font = PrnVars.BaseFont
    Dim HeaderFont As Font = PrnVars.HeaderFont
    Dim LineHeight As Single = TextFont.GetHeight(e.Graphics)
    Dim HeaderLineHeight As Single = HeaderFont.GetHeight(e.Graphics)

    Doc.PageNumber += 1
    Doc.DrawText(e, "- " & Doc.PageNumber & " -", TextFont, e.MarginBounds.Left, Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Top + LineHeight, e.MarginBounds.Width, LineHeight, 1, Brushes.Black, False)
    If Doc.PageNumber = 1 Then
      y += LineHeight
      Doc.DrawText(e, Doc.ReportHeader(0), HeaderFont, e.MarginBounds.Left, y, e.MarginBounds.Width, HeaderLineHeight, 1, Brushes.Black, False)
      'Doc.DrawText(e, Doc.ReportHeader(0), HeaderFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 1, Brushes.Black, False)
      y += LineHeight * 2
      Doc.DrawText(e, "Szkoła: " & cbSzkola.Text, TextFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 0, Brushes.Black, False)
      y += LineHeight
      Doc.DrawText(e, "Rok szkolny: " & String.Concat(nudStartYear.Value.ToString, "/", nudEndYear.Value.ToString), TextFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 0, Brushes.Black, False)
      y += LineHeight * CSng(1.5)
      e.Graphics.DrawLine(Pens.Black, x, y, x + 300, y)
      y += LineHeight
    End If
    '------------------------------------------ Nagłówek tabeli -------------------------------------------
    Dim x1 As Single = x
    e.Graphics.DrawLine(New Pen(Color.Black, 2), x1, y, x1 + dgvStudentsByPlaceByYear.Columns(0).Width + dgvStudentsByPlaceByYear.Columns(1).Width + dgvStudentsByPlaceByYear.Columns(2).Width * DS.Tables(3).Rows.Count * DS.Tables(2).Select("Status=True").GetLength(0), y)
    e.Graphics.DrawLine(New Pen(Color.Black, 2), x1, y, x1, y + LineHeight * 3)

    Doc.DrawText(e, "L.p.", PrnVars.BoldFont, x1, y, dgvStudentsByPlaceByYear.Columns(0).Width, LineHeight * 3, 1, Brushes.Black)
    x1 += dgvStudentsByPlaceByYear.Columns(0).Width
    Doc.DrawText(e, "Miejscowość", PrnVars.BoldFont, x1, y, dgvStudentsByPlaceByYear.Columns(1).Width, LineHeight * 3, 1, Brushes.Black)
    x1 += dgvStudentsByPlaceByYear.Columns(1).Width
    For Each R As DataRow In DS.Tables(2).Select("Status=True")
      e.Graphics.DrawLine(New Pen(Color.Black, 2), x1, y, x1, y + LineHeight * 3)
      Doc.DrawText(e, R.Item(2).ToString, PrnVars.BoldFont, x1, y, dgvStudentsByPlaceByYear.Columns(2).Width * DS.Tables(3).Rows.Count, LineHeight * CSng(1.5), 1, Brushes.Black)
      x1 += dgvStudentsByPlaceByYear.Columns(2).Width * DS.Tables(3).Rows.Count
    Next

    y += LineHeight * CSng(1.5)
    x1 = x + dgvStudentsByPlaceByYear.Columns(0).Width + dgvStudentsByPlaceByYear.Columns(1).Width

    For Each Rocznik As DataRow In DS.Tables(2).Select("Status=True")
      For Each Pion As DataRow In DS.Tables(3).Rows  'DT.Select().GetUpperBound(0)
        Doc.DrawText(e, Pion.Item(0).ToString, PrnVars.BoldFont, x1, y, dgvStudentsByPlaceByYear.Columns(2).Width, LineHeight * CSng(1.5), 1, Brushes.Black)

        x1 += dgvStudentsByPlaceByYear.Columns(2).Width '* PionNumber
      Next
    Next

    y += LineHeight * CSng(1.5)

    e.Graphics.DrawLine(New Pen(Color.Black, 2), x, y, x + dgvStudentsByPlaceByYear.Columns(0).Width + dgvStudentsByPlaceByYear.Columns(1).Width + dgvStudentsByPlaceByYear.Columns(2).Width * DS.Tables(3).Rows.Count * DS.Tables(2).Select("Status=True").GetLength(0), y)

    '------------------------------------------------- Ciało tabeli -----------------------------------------
    '********************************************** Kolumny L.p. oraz Miejscowość ****************************************
    Do Until (y + LineHeight) > e.MarginBounds.Bottom Or Doc.Offset(0) > DS.Tables(1).Rows.Count - 1 'dgvStudentsByPlaceByYear.Rows.Count - 2
      x1 = x
      Doc.Lp += 1
      Doc.DrawText(e, Doc.Lp.ToString, PrnVars.BaseFont, x1, y, dgvStudentsByPlaceByYear.Columns(0).Width, LineHeight, 1, Brushes.Black)

      x1 += dgvStudentsByPlaceByYear.Columns(0).Width
      Doc.DrawText(e, DS.Tables(1).Rows(Doc.Offset(0)).Item(0).ToString, PrnVars.BaseFont, x1, y, dgvStudentsByPlaceByYear.Columns(1).Width, LineHeight, 0, Brushes.Black)
      x1 += dgvStudentsByPlaceByYear.Columns(1).Width

      '************************************* Liczba uczniów w rocznikach i w pionach ******************************************

      For k As Integer = 0 To DS.Tables(2).Select("Rocznik<>0 AND Status=True").GetLength(0) - 1
        For j As Integer = 0 To DS.Tables(3).Rows.Count - 1
          If DS.Tables(0).Select("Miejscowosc='" & DS.Tables(1).Rows(Doc.Offset(0)).Item(0).ToString & "' AND Rocznik=" & CType(DS.Tables(2).Rows(k).Item(0), Integer) & " AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'").GetLength(0) > 0 Then
            Doc.DrawText(e, DS.Tables(0).Select("Miejscowosc='" & DS.Tables(1).Rows(Doc.Offset(0)).Item(0).ToString & "' AND Rocznik=" & CType(DS.Tables(2).Rows(k).Item(0), Integer) & " AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'")(0).Item("Liczba").ToString(), PrnVars.BaseFont, x1, y, dgvStudentsByPlaceByYear.Columns(2).Width, LineHeight, 1, Brushes.Black)
          Else
            Doc.DrawText(e, "0", PrnVars.BaseFont, x1, y, dgvStudentsByPlaceByYear.Columns(2).Width, LineHeight, 1, Brushes.Black)
          End If
          x1 += dgvStudentsByPlaceByYear.Columns(2).Width
        Next
      Next
      e.Graphics.DrawLine(New Pen(Color.Black, 2), x1, y, x1, y + LineHeight)

      '*************************************** RightFooter *****************************************************

      If DS.Tables(2).Select("Rocznik=0 AND Status=True").GetLength(0) > 0 Then
        For j As Integer = 0 To DS.Tables(3).Rows.Count - 1
          Doc.DrawText(e, IIf(DS.Tables(0).Select("Miejscowosc='" & DS.Tables(1).Rows(Doc.Offset(0)).Item(0).ToString & "' AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'").GetLength(0) > 0, DS.Tables(0).Compute("Sum(Liczba)", "Miejscowosc='" & DS.Tables(1).Rows(Doc.Offset(0)).Item(0).ToString & "'  AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'"), "0").ToString, PrnVars.BaseFont, x1, y, dgvStudentsByPlaceByYear.Columns(2).Width, LineHeight, 1, Brushes.Black)
          x1 += dgvStudentsByPlaceByYear.Columns(2).Width
        Next
      End If

      Doc.Offset(0) += 1
      y += LineHeight
    Loop
    '************************************* End table body *************************************************************

    '************************************************** BottomFooter *************************************************
    If Doc.Offset(0) = dgvStudentsByPlaceByYear.Rows.Count - 1 AndAlso y + LineHeight < e.MarginBounds.Bottom Then
      e.Graphics.DrawLine(New Pen(Color.Black, 2), x, y, x + dgvStudentsByPlaceByYear.Columns(0).Width + dgvStudentsByPlaceByYear.Columns(1).Width + dgvStudentsByPlaceByYear.Columns(2).Width * DS.Tables(3).Rows.Count * DS.Tables(2).Select("Status=True").GetLength(0), y)
      x1 = x + dgvStudentsByPlaceByYear.Columns(0).Width
      e.Graphics.DrawLine(New Pen(Color.Black, 2), x, y, x, y + LineHeight * CSng(1.5))
      e.Graphics.DrawLine(New Pen(Color.Black, 2), x, y + LineHeight * CSng(1.5), x + dgvStudentsByPlaceByYear.Columns(0).Width + dgvStudentsByPlaceByYear.Columns(1).Width + dgvStudentsByPlaceByYear.Columns(2).Width * DS.Tables(3).Rows.Count * DS.Tables(2).Select("Status=True").GetLength(0), y + LineHeight * CSng(1.5))
      
      Doc.DrawText(e, "Razem", PrnVars.BoldFont, x, y, dgvStudentsByPlaceByYear.Columns(0).Width + dgvStudentsByPlaceByYear.Columns(1).Width, LineHeight * CSng(1.5), 1, Brushes.Black)
      x1 += dgvStudentsByPlaceByYear.Columns(1).Width

      For i As Integer = 0 To DS.Tables(2).Select("Rocznik<>0 AND Status=True").GetLength(0) - 1
        For j As Integer = 0 To DS.Tables(3).Rows.Count - 1
          If DS.Tables(0).Select("Rocznik=" & CType(DS.Tables(2).Rows(i).Item(0), Integer) & " AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'").GetLength(0) > 0 Then
            Doc.DrawText(e, DS.Tables(0).Compute("Sum(Liczba)", "Rocznik=" & CType(DS.Tables(2).Rows(i).Item(0), Integer) & " AND Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'").ToString(), PrnVars.BoldFont, x1, y, dgvStudentsByPlaceByYear.Columns(2).Width, LineHeight * CSng(1.5), 1, Brushes.Black)
          Else
            Doc.DrawText(e, "0", PrnVars.BoldFont, x1, y, dgvStudentsByPlaceByYear.Columns(2).Width, LineHeight * CSng(1.5), 1, Brushes.Black)
          End If

          x1 += dgvStudentsByPlaceByYear.Columns(2).Width
        Next

        e.Graphics.DrawLine(New Pen(Color.Black, 2), x1, y, x1, y + LineHeight * CSng(1.5))

      Next

      If DS.Tables(2).Select("Rocznik=0 AND Status=True").GetLength(0) > 0 Then
        For j As Integer = 0 To DS.Tables(3).Rows.Count - 1
          Doc.DrawText(e, IIf(DS.Tables(0).Select("Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'").GetLength(0) > 0, DS.Tables(0).Compute("Sum(Liczba)", "Pion='" & DS.Tables(3).Rows(j).Item(0).ToString & "'"), "0").ToString, PrnVars.BaseFont, x1, y, dgvStudentsByPlaceByYear.Columns(2).Width, LineHeight * CSng(1.5), 1, Brushes.Black)
          x1 += dgvStudentsByPlaceByYear.Columns(2).Width
        Next
      End If
      Doc.Offset(0) += 1
      'y += LineHeight
    End If
    '******************************************** End BotomFooter ****************************************************
    If Doc.Offset(0) <= dgvStudentsByPlaceByYear.Rows.Count - 1 Then
      e.HasMorePages = True
      RaiseEvent NewRow()
    End If
  End Sub
End Class

Public Class StudentsByBirthYear
  Public Function CountStudents(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT m.Nazwa AS Miejscowosc,YEAR(u.DataUr) AS Rocznik,LEFT(p.Klasa,1) AS Pion,COUNT(u.ID) AS Liczba FROM uczniowie u,miejscowosc m,przydzial p,szkola_klasa sk WHERE u.IdMiejsceZam=m.ID AND u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND p.RokSzkolny='" & RokSzkolny & "' AND sk.IdSzkola='" & IdSzkola & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1' GROUP BY m.Nazwa,YEAR(u.DataUr),LEFT(p.Klasa,1) ORDER BY m.Nazwa,YEAR(u.DataUr),LEFT(p.Klasa,1);"
  End Function
  'Public Function CountStudentsByPlace(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
  '  Return "SELECT m.Nazwa AS Miejscowosc,LEFT(p.Klasa,1) AS Pion,COUNT(u.ID) AS Liczba FROM uczniowie u,miejscowosc m,przydzial p,szkola_klasa sk WHERE u.IdMiejsceZam=m.ID AND u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & IdSzkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1' GROUP BY m.Nazwa,LEFT(p.Klasa,1) ORDER BY m.Nazwa;"
  'End Function
  'Public Function CountStudentsByYear(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
  '  Return "SELECT YEAR(u.DataUr) AS Rocznik,LEFT(p.Klasa,1) AS Pion,COUNT(u.ID) AS Liczba FROM uczniowie u,miejscowosc m,przydzial p,szkola_klasa sk WHERE u.IdMiejsceZam=m.ID AND u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & IdSzkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1' GROUP BY YEAR(u.DataUr),LEFT(p.Klasa,1) ORDER BY YEAR(u.DataUr);"
  'End Function
  'Public Function CountStudentsByPion(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
  '  Return "SELECT LEFT(p.Klasa,1) AS Pion,COUNT(u.ID) AS Liczba FROM uczniowie u,miejscowosc m,przydzial p,szkola_klasa sk WHERE u.IdMiejsceZam=m.ID AND u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & IdSzkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1' GROUP BY LEFT(p.Klasa,1) ORDER BY LEFT(p.Klasa,1);"
  'End Function
  Public Function SelectYear(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT DISTINCT YEAR(u.DataUr) AS Rocznik FROM uczniowie u,przydzial p,szkola_klasa sk WHERE u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & IdSzkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1' ORDER BY YEAR(u.DataUr);"
  End Function
  'Public Function CountYear(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
  '  Return "SELECT Count(*) FROM (SELECT DISTINCT YEAR(u.DataUr) AS Rocznik FROM uczniowie u,przydzial p,szkola_klasa sk WHERE u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & IdSzkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1') AS rocznik;"
  'End Function
  Public Function SelectPion(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT DISTINCT LEFT(p.Klasa,1) AS Pion FROM przydzial p INNER JOIN szkola_klasa sk ON p.Klasa=sk.IdKlasa WHERE p.RokSzkolny='" & RokSzkolny & "' AND sk.IdSzkola='" & IdSzkola & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1' ORDER BY Pion asc;"
  End Function
  'Public Function CountPion(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
  '  Return "SELECT Count(*) FROM (SELECT DISTINCT LEFT(p.Klasa,1) AS Pion FROM przydzial p INNER JOIN szkola_klasa sk ON p.Klasa=sk.IdKlasa WHERE p.RokSzkolny='" & RokSzkolny & "' AND sk.IdSzkola='" & IdSzkola & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1') AS Pion;"
  'End Function
  'Public Function CountPlace(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
  '  Return "SELECT Count(IdMiejsceZam) FROM (SELECT DISTINCT IdMiejsceZam FROM uczniowie u,przydzial p,szkola_klasa sk WHERE u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & IdSzkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1') as Place;"
  'End Function
  Public Function SelectPlace(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT DISTINCT m.Nazwa FROM uczniowie u,przydzial p,szkola_klasa sk,miejscowosc m WHERE u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND u.IdMiejsceZam=m.ID AND sk.IdSzkola='" & IdSzkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1' ORDER BY m.Nazwa;"
  End Function
End Class
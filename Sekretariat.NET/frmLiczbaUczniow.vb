Imports System.Drawing.Printing
Public Class frmLiczbaUczniow
  'Private DT As DataTable
  Public Event NewRow()
  Private PionPrinted, GroupPrinted As Boolean

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Dispose(True)
  End Sub

  Private Sub frmLiczbaUczniow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ListViewConfig(Me.lvZestawienie)
    ListViewConfig(Me.lvPionKlas)

    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(Me.cbSzkola, "Select ID,Alias FROM szkoly;")
    SH.FindComboItem(Me.cbSzkola, CInt(SH.GetDefault("Select ID From szkoly Where IsDefault='1';")))
    Dim CH As New CalcHelper
    Me.nudStartYear.Value = CH.StartDateOfSchoolYear.Year

  End Sub
  Private Sub ListViewConfig(ByVal lv As ListView)
    With lv
      .View = View.Details
      .Enabled = True
      .FullRowSelect = True
      .GridLines = True
      .MultiSelect = True
      .AllowColumnReorder = False
      .HideSelection = False
      If lv.Name = lvZestawienie.Name Then
        AddColumns(lv, "Klasa", "Liczba")
      Else
        AddColumns(lv, "Pion klas", "Liczba")
      End If
      .Items.Clear()
      .Enabled = False
    End With
  End Sub
  Private Sub AddColumns(ByVal lv As ListView, ByVal F1 As String, ByVal F2 As String)
    With lv
      .Columns.Clear()
      .Columns.Add(F1, 80, HorizontalAlignment.Center)
      .Columns.Add(F2, 80, HorizontalAlignment.Center)
      .Columns.Add("% w szkole", 80, HorizontalAlignment.Center)
    End With
  End Sub
  Private Function CountStudents() As String
    Dim DBA As New DataBaseAction, R As MySqlDataReader = Nothing
    Try
      R = DBA.GetReader("SELECT COUNT(u.ID) AS LiczbaUczniow FROM uczniowie u,przydzial p,szkola_klasa sk WHERE u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji='1';")
      If R.HasRows Then
        R.Read()
        Return R(0).ToString()
      End If
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      R.Close()
    End Try
    Return ""
  End Function
  Private Sub CountStudentsByClass()
    Dim DBA As New DataBaseAction, R As MySqlDataReader = Nothing
    Try
      R = DBA.GetReader("SELECT p.Klasa,COUNT(u.ID) AS LiczbaUczniow FROM uczniowie u,przydzial p,szkola_klasa sk WHERE u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji='1' GROUP BY p.Klasa;")
      lvZestawienie.Items.Clear()
      While R.Read
        lvZestawienie.Items.Add(R.Item(0).ToString)
        lvZestawienie.Items(lvZestawienie.Items.Count - 1).SubItems.Add(R.Item(1).ToString)
        lvZestawienie.Items(lvZestawienie.Items.Count - 1).SubItems.Add(Math.Round(CType(R.Item(1), Integer) / CType(Me.txtLiczbaUczniowSzkola.Text, Integer) * 100, 2).ToString)
      End While
      lvZestawienie.Columns(0).Width = CInt(IIf(lvZestawienie.Items.Count > 17, 62, 80))
      Me.lvZestawienie.Enabled = CBool(IIf(Me.lvZestawienie.Items.Count > 0, True, False))
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      R.Close()
    End Try
  End Sub
  Private Sub CountStudentsByPion()
    Dim DBA As New DataBaseAction, R As MySqlDataReader = Nothing
    Try
      R = DBA.GetReader("SELECT LEFT(p.Klasa,1),COUNT(u.ID) AS LiczbaUczniow FROM uczniowie u,przydzial p,szkola_klasa sk WHERE u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji='1' GROUP BY LEFT(p.Klasa,1) ASC;")
      lvPionKlas.Items.Clear()
      While R.Read
        If R.Item(0).ToString = "1" Then
          lvPionKlas.Items.Add("Klasy pierwsze")
        ElseIf R.Item(0).ToString = "2" Then
          lvPionKlas.Items.Add("Klasy drugie")
        Else
          lvPionKlas.Items.Add("Klasy trzecie")
        End If
        lvPionKlas.Items(lvPionKlas.Items.Count - 1).SubItems.Add(R.Item(1).ToString)
        lvPionKlas.Items(lvPionKlas.Items.Count - 1).SubItems.Add(Math.Round(CType(R.Item(1), Integer) / CType(Me.txtLiczbaUczniowSzkola.Text, Integer) * 100, 2).ToString)
      End While
      lvPionKlas.Columns(0).Width = CInt(IIf(lvZestawienie.Items.Count > 3, 62, 80))
      Me.lvPionKlas.Enabled = CBool(IIf(Me.lvPionKlas.Items.Count > 0, True, False))
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      R.Close()
    End Try
  End Sub

  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    Me.txtLiczbaUczniowSzkola.Text = Me.CountStudents()
    CountStudentsByPion()
    CountStudentsByClass()
    cmdPrint.Enabled = True
  End Sub
  Private Sub nudStartYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudStartYear.ValueChanged
    If Not nudStartYear.Created Then Exit Sub
    Me.nudEndYear.Value = Me.nudStartYear.Value + 1
    If Not cbSzkola.SelectedItem Is Nothing Then
      txtLiczbaUczniowSzkola.Text = CountStudents()
      CountStudentsByPion()
      CountStudentsByClass()
    End If
  End Sub
  Private Sub chkVirtual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtual.CheckedChanged
    If Not cbSzkola.SelectedItem Is Nothing Then
      txtLiczbaUczniowSzkola.Text = CountStudents()
      CountStudentsByPion()
      CountStudentsByClass()
    End If

  End Sub

  Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
    Dim PP As New dlgPrintPreview, DS As New DataSet
    DS.Tables.Add(New DataTable)
    PP.Doc = New PrintReport(DS)
    AddHandler PP.Doc.PrintPage, AddressOf PrnDoc_PrintPage
    AddHandler NewRow, AddressOf PP.NewRow
    PP.Doc.ReportHeader = New String() {"Liczba uczniów w szkole"}
    'PP.Doc.Offset(1) = 2
    If PP.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      'DS.Tables.Remove(DT)
    End If
  End Sub
  Public Sub PrnDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) 'Handles Doc.PrintPage
    Dim Doc As PrintReport = CType(sender, PrintReport)
    Dim x As Single = Doc.DefaultPageSettings.Margins.Left - Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Left
    Dim y As Single = Doc.DefaultPageSettings.Margins.Top - Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Top
    Dim PrnVars As New PrintVariables
    Dim TextFont As Font = PrnVars.BaseFont
    Dim HeaderFont As Font = PrnVars.HeaderFont
    Dim LineHeight As Single = TextFont.GetHeight(e.Graphics)
    Dim HeaderLineHeight As Single = HeaderFont.GetHeight(e.Graphics)

    Doc.PageNumber += 1
    Doc.DrawText(e, "- " & Doc.PageNumber & " -", TextFont, x, Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Top + LineHeight, e.MarginBounds.Width, LineHeight, 1, Brushes.Black, False)
    If Doc.PageNumber = 1 Then
      y += LineHeight
      Doc.DrawText(e, Doc.ReportHeader(0), HeaderFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 1, Brushes.Black, False)
      y += LineHeight * 2
      Doc.DrawText(e, "Szkoła: " & cbSzkola.Text, TextFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 0, Brushes.Black, False)
      y += LineHeight
      Doc.DrawText(e, "Rok szkolny: " & String.Concat(nudStartYear.Value.ToString, "/", nudEndYear.Value.ToString), TextFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 0, Brushes.Black, False)
      y += LineHeight * CSng(1.5)
      e.Graphics.DrawLine(Pens.Black, x, y, x + 300, y)
      y += LineHeight
    End If

    Dim k1, k2 As Single
    k1 = 150 : k2 = 200
    'PrintColumnsHeaders(e, x, y, TextFont, LineHeight)
    If Not PionPrinted Then
      Doc.DrawText(e, "Liczba uczniów ogółem: ", TextFont, x, y, e.MarginBounds.Width, LineHeight * 2, 0, Brushes.Black, False)
      Doc.DrawText(e, Me.txtLiczbaUczniowSzkola.Text, PrnVars.BoldFont, x + e.Graphics.MeasureString("Liczba uczniów ogółem: ", TextFont).Width, y, 100, LineHeight * 2, 0, Brushes.Black, False)
      y += LineHeight * 3
      Doc.DrawText(e, "Liczba uczniów w pionach", PrnVars.BoldFont, x, y, e.MarginBounds.Width, LineHeight * 2, 0, Brushes.Black, False)
      y += LineHeight * 2
      Doc.DrawText(e, "Pion klas", PrnVars.BoldFont, x, y, k1, LineHeight * 2, 1, Brushes.Black)
      Doc.DrawText(e, "Liczba uczniów", PrnVars.BoldFont, x + k1, y, k2, LineHeight * 2, 1, Brushes.Black)
      Doc.DrawText(e, "% w szkole", PrnVars.BoldFont, x + k1 + k2, y, k2, LineHeight * 2, 1, Brushes.Black)
      y += LineHeight * 2
      Do Until (y + LineHeight) > e.MarginBounds.Bottom Or Doc.Offset(0) > lvPionKlas.Items.Count - 1
        'For i As Integer = 0 To lvPionKlas.Items.Count - 1
        Doc.DrawText(e, lvPionKlas.Items(Doc.Offset(0)).Text, PrnVars.BoldFont, x, y, k1, LineHeight, 0, Brushes.Black)
        Doc.DrawText(e, lvPionKlas.Items(Doc.Offset(0)).SubItems(1).Text, PrnVars.BoldFont, x + k1, y, k2, LineHeight, 1, Brushes.Black)
        Doc.DrawText(e, lvPionKlas.Items(Doc.Offset(0)).SubItems(2).Text, PrnVars.BoldFont, x + k1 + k2, y, k2, LineHeight, 1, Brushes.Black)
        y += LineHeight
        'Next
        Doc.Offset(0) += 1
      Loop
      'e.HasMorePages = True
      If Doc.Offset(0) > lvPionKlas.Items.Count - 1 Then PionPrinted = True
      y += LineHeight * 2
      If Doc.Offset(0) <= lvPionKlas.Items.Count - 1 Then
        e.HasMorePages = True
        RaiseEvent NewRow()
      End If
    End If

    If PionPrinted AndAlso Not GroupPrinted Then
      Doc.DrawText(e, "Liczba uczniów w klasach", PrnVars.BoldFont, x, y, e.MarginBounds.Width, LineHeight * 2, 0, Brushes.Black, False)
      y += LineHeight * 2
      Doc.DrawText(e, "Klasa", PrnVars.BoldFont, x, y, k1, LineHeight * 2, 1, Brushes.Black)
      Doc.DrawText(e, "Liczba uczniów", PrnVars.BoldFont, x + k1, y, k2, LineHeight * 2, 1, Brushes.Black)
      Doc.DrawText(e, "% w szkole", PrnVars.BoldFont, x + k1 + k2, y, k2, LineHeight * 2, 1, Brushes.Black)
      y += LineHeight * 2

      Do Until (y + LineHeight) > e.MarginBounds.Bottom Or Doc.Offset(1) > lvZestawienie.Items.Count - 1
        'Doc.Lp += 1
        Doc.DrawText(e, lvZestawienie.Items(Doc.Offset(1)).Text, TextFont, x, y, k1, LineHeight, 1, Brushes.Black)
        Doc.DrawText(e, lvZestawienie.Items(Doc.Offset(1)).SubItems(1).Text, TextFont, x + k1, y, k2, LineHeight, 1, Brushes.Black)
        Doc.DrawText(e, lvZestawienie.Items(Doc.Offset(1)).SubItems(2).Text, TextFont, x + k1 + k2, y, k2, LineHeight, 1, Brushes.Black)
        y += LineHeight

        Doc.Offset(1) += 1
      Loop
      If Doc.Offset(1) > lvZestawienie.Items.Count - 1 Then GroupPrinted = True
      If Doc.Offset(1) <= lvZestawienie.Items.Count - 1 Then
        e.HasMorePages = True
        RaiseEvent NewRow()
      End If

    End If

  End Sub
End Class
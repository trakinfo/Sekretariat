﻿Imports System.Drawing.Printing
Public Class prnStudents
  Private Zoom As Double = 1, PrintGroupHeader As Boolean = True
  Private WithEvents Doc As New PrintReport(New DataSet)
  Private PrintContent As String = "Concat_WS(' ',u.Nazwisko,u.Imie1,u.Imie2) AS FullName,"
  'Private ColWidth, ColName As New Hashtable
  Private dtPrintOptions As New DataTable, TotalWidth As Single = 30
  Private Sub GetPrintContent()
    dtPrintOptions.Columns.Add("Name")
    dtPrintOptions.Columns("Name").DataType = System.Type.GetType("System.String")
    dtPrintOptions.Columns.Add("Alias")
    dtPrintOptions.Columns("Alias").DataType = System.Type.GetType("System.String")
    dtPrintOptions.Columns.Add("ColWidth")
    dtPrintOptions.Columns("ColWidth").DataType = System.Type.GetType("System.Single")
    dtPrintOptions.Columns.Add("Status")
    dtPrintOptions.Columns("Status").DataType = System.Type.GetType("System.Byte")
    dtPrintOptions.Columns.Add("SortOrder")
    dtPrintOptions.Columns("SortOrder").DataType = System.Type.GetType("System.Byte")

    dtPrintOptions.Rows.Add("LP", "L.p.", 30, CType("1", Byte), 0)
    dtPrintOptions.Rows.Add("NrArkusza", "Nr ewid.", 60, CType("0", Byte), 1)
    dtPrintOptions.Rows.Add("FullName", "Nazwisko i imiona", 200, CType("1", Byte), 2)
    dtPrintOptions.Rows.Add("DataUr", "Data ur.", 80, CType("0", Byte), 4)
    dtPrintOptions.Rows.Add("MiejsceUr", "Miejsce ur.", 180, CType("0", Byte), 5)
    dtPrintOptions.Rows.Add("ImionaRodzicow", "Imiona rodziców", 150, CType("0", Byte), 7)
    dtPrintOptions.Rows.Add("Pesel", "Pesel", 90, CType("0", Byte), 3)
    dtPrintOptions.Rows.Add("NrLegSzkol", "Nr leg.", 50, CType("0", Byte), 8)
    dtPrintOptions.Rows.Add("Adres", "Adres", 200, CType("0", Byte), 6)
    dtPrintOptions.Rows.Add("Tel", "Nr telefonów", 200, CType("0", Byte), 9)
    dtPrintOptions.Rows.Add("Uwagi", "Uwagi", 200, CType("0", Byte), 10)


    For Each Str As String In My.Settings.PrintContent.Split(";".ToCharArray)
      CType(gbPrintContent.Controls.Item(Str), CheckBox).Checked = True

    Next

  End Sub
  Private Sub prnListaUczniow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    GetPrintContent()

    Dim CH As New CalcHelper
    Me.nudStartYear.Value = CH.StartDateOfSchoolYear.Year
    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(Me.cbSzkola, "Select ID,Alias FROM szkoly;")
    SH.FindComboItem(Me.cbSzkola, CInt(SH.GetDefault("Select ID From szkoly Where IsDefault='1';")))

    pvListaUczniow.AutoZoom = True
    pvListaUczniow.Zoom = Zoom
  End Sub
  Private Sub rbZoom100_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbZoom100.CheckedChanged, rbZoom150.CheckedChanged, rbZoom200.CheckedChanged, rbZoom25.CheckedChanged, rbZoom50.CheckedChanged, rbZoom75.CheckedChanged
    If Not Me.Created Then Exit Sub
    If CType(sender, RadioButton).Checked Then
      Me.Zoom = CType(CType(sender, RadioButton).Tag, Double)
      Me.pvListaUczniow.Rows = 1
      Me.pvListaUczniow.Zoom = Me.Zoom
      Me.Doc.PageNumber = 0
      Me.Doc.Offset(0) = 0
      Me.Doc.Offset(1) = 0
      Me.Doc.Lp = 0
      Me.pvListaUczniow.InvalidatePreview()
    End If
  End Sub
  Private Sub rbZoomCustom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbZoomCustom.CheckedChanged
    If rbZoomCustom.Checked Then
      tbZoom.Enabled = True
      nudZoom.Enabled = True
      Me.Zoom = tbZoom.Value * 0.01
      Me.pvListaUczniow.Rows = 1
      Me.pvListaUczniow.Zoom = Me.Zoom
      Me.Doc.PageNumber = 0
      Me.Doc.Offset(0) = 0
      Me.Doc.Offset(1) = 0
      Me.Doc.Lp = 0
      Me.pvListaUczniow.InvalidatePreview()
    Else
      tbZoom.Enabled = False
      nudZoom.Enabled = False
    End If
  End Sub
  Private Sub tbZoom_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbZoom.Scroll
    Zoom = tbZoom.Value * 0.01
    nudZoom.Value = tbZoom.Value
    Me.pvListaUczniow.Rows = 1
    Me.pvListaUczniow.Zoom = Me.Zoom
    Me.Doc.PageNumber = 0
    Me.Doc.Offset(0) = 0
    Me.Doc.Offset(1) = 0
    Me.Doc.Lp = 0
    Me.pvListaUczniow.InvalidatePreview()
  End Sub
  Private Sub nudZoom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudZoom.ValueChanged
    If Not Me.Created Then Exit Sub
    Zoom = nudZoom.Value * 0.01
    tbZoom.Value = CType(nudZoom.Value, Integer)
    Me.pvListaUczniow.Rows = 1
    Me.pvListaUczniow.Zoom = Me.Zoom
    Me.Doc.PageNumber = 0
    Me.Doc.Offset(0) = 0
    Me.Doc.Offset(1) = 0
    Me.Doc.Lp = 0
    Me.pvListaUczniow.InvalidatePreview()

  End Sub
  Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
    Dim prnDlg As New PrintDialog
    prnDlg.AllowSomePages = False
    prnDlg.PrinterSettings.FromPage = 1
    prnDlg.PrinterSettings.ToPage = 1
    If prnDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
      Me.Doc.PageNumber = 0
      Me.Doc.Offset(0) = 0
      Me.Doc.Offset(1) = 0
      pvListaUczniow.Document.DefaultPageSettings.PrinterSettings.Copies = prnDlg.PrinterSettings.Copies
      Me.pvListaUczniow.Document.DefaultPageSettings.PrinterSettings.FromPage = prnDlg.PrinterSettings.FromPage
      Me.pvListaUczniow.Document.DefaultPageSettings.PrinterSettings.ToPage = prnDlg.PrinterSettings.ToPage
      Me.pvListaUczniow.Document.DefaultPageSettings.PrinterSettings.PrinterName = prnDlg.PrinterSettings.PrinterName
      Me.pvListaUczniow.Document.Print()
    End If
  End Sub
  Private Sub rbAllStudents_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAllStudents.CheckedChanged, rbSelectedClass.CheckedChanged
    If Me.Created AndAlso CType(sender, RadioButton).Checked Then
      Me.pvListaUczniow.Rows = 1
      Me.Doc.PageNumber = 0
      Me.Doc.Offset(0) = 0
      Me.Doc.Offset(1) = 0

      pvListaUczniow.Document.DefaultPageSettings.Landscape = CBool(IIf(CType(IIf(Me.chkUwagi.Checked, TotalWidth + CSng(dtPrintOptions.Select("Name='" & "Uwagi" & "'")(0).Item("ColWidth")), TotalWidth), Single) > (pvListaUczniow.Document.DefaultPageSettings.PaperSize.Width - (pvListaUczniow.Document.DefaultPageSettings.Margins.Left + pvListaUczniow.Document.DefaultPageSettings.Margins.Right)), True, False))

      If CType(sender, RadioButton).Name = "rbSelectedClass" Then
        Me.cbKlasa.Enabled = True
        chkPageBreak.Enabled = False
        Doc.ReportHeader = New String() {"Lista uczniów - klasa " + Me.cbKlasa.Text}
        If Me.cbKlasa.SelectedItem IsNot Nothing AndAlso Doc.DS.Tables(2).Select("Klasa='" & Me.cbKlasa.Text & "'").GetLength(0) > 0 Then
          Doc.GroupHeader = New String() {Doc.DS.Tables(2).Select("Klasa='" & Me.cbKlasa.Text & "'")(0).Item(0).ToString}
        Else
          'Exit Sub
        End If
      Else
        Me.cbKlasa.Enabled = False
        chkPageBreak.Enabled = True
        Doc.ReportHeader = New String() {"Lista uczniów z podziałem na klasy"}
      End If
      pvListaUczniow.InvalidatePreview()
    End If
  End Sub
  Private Sub cbKlasa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbKlasa.SelectedIndexChanged
    Me.rbAllStudents_CheckedChanged(Me.rbSelectedClass, e)
  End Sub
  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Dispose(True)
  End Sub

  Private Sub chkNazwiskoImiona_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFullName.CheckedChanged, chkDataUr.CheckedChanged, chkMiejsceUr.CheckedChanged, chkImionaRodzicow.CheckedChanged, chkNrArkusza.CheckedChanged, chkUwagi.CheckedChanged, chkAdres.CheckedChanged, chkNrLegSzkol.CheckedChanged, chkPesel.CheckedChanged, chkTel.CheckedChanged
    If Not Me.Created Then Exit Sub
    Me.pvListaUczniow.Rows = 1
    Me.Doc.PageNumber = 0
    Me.Doc.Offset(0) = 0
    Me.Doc.Offset(1) = 0
    Me.Doc.Lp = 0

    PrintContent = ""
    TotalWidth = 30

    dtPrintOptions.Select("Name='" & CType(sender, CheckBox).Name.Substring(3) & "'")(0).Item("Status") = CType(CType(sender, CheckBox).CheckState, Byte)

    For Each R As DataRow In dtPrintOptions.Select("Status=1 AND Name NOT IN ('LP','Uwagi')")
      PrintContent += CType(gbPrintContent.Controls.Item(String.Concat("chk", R.Item(0).ToString)), CheckBox).Tag.ToString & ","
      TotalWidth += CType(R.Item(2), Single)
    Next

    If Not Me.cbSzkola.SelectedItem Is Nothing Then
      Doc = New PrintReport(GetData)
      pvListaUczniow.Document = Doc
      My.Settings.PrintContent = ""
      For Each R As DataRow In dtPrintOptions.Select("Status=1 AND Name<>'LP'")
        My.Settings.PrintContent += String.Concat("chk", R.Item(0).ToString, ";")
      Next

      My.Settings.PrintContent = My.Settings.PrintContent.TrimEnd(";".ToCharArray)
      My.Settings.Save()
      rbAllStudents_CheckedChanged(IIf(rbAllStudents.Checked, rbAllStudents, rbSelectedClass), e)
    End If

  End Sub
  Private Sub FillKlasa()
    Dim FCB As New FillComboBox ', CS As New CommonStrings
    Me.cbKlasa.Items.Clear()
    FCB.AddComboBoxSimpleItems(cbKlasa, "SELECT DISTINCT p.Klasa FROM przydzial p INNER JOIN szkola_klasa sk ON p.Klasa=sk.IdKlasa WHERE p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND StatusAktywacji=1 ORDER BY p.Klasa ASC;")
  End Sub
  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    FillKlasa()
    'PrintContent=
    Me.gbPrintContent.Enabled = CBool(IIf(Me.cbSzkola.SelectedItem Is Nothing, False, True))
    Me.gbZakres.Enabled = CBool(IIf(Me.cbSzkola.SelectedItem Is Nothing, False, True))
    Me.gbZoom.Enabled = CBool(IIf(Me.cbSzkola.SelectedItem Is Nothing, False, True))
    Me.gbOpcje.Enabled = CBool(IIf(Me.cbSzkola.SelectedItem Is Nothing, False, True))
    Me.cmdPrint.Enabled = CBool(IIf(Me.cbSzkola.SelectedItem Is Nothing, False, True))

    Doc = New PrintReport(GetData)
    pvListaUczniow.Document = Doc
    rbAllStudents_CheckedChanged(IIf(rbAllStudents.Checked, rbAllStudents, rbSelectedClass), e)
  End Sub
  Private Function GetData() As DataSet
    Dim DBA As New DataBaseAction
    Dim DS As New DataSet()
    DS.Tables.Add(DBA.GetDataTable("SELECT " & PrintContent & "Klasa FROM uczniowie u Left Join przydzial p on u.ID=p.IdUczen LEFT JOIN szkola_klasa sk on p.Klasa=sk.IdKlasa LEFT JOIN miejscowosc m ON u.IdMiejsceZam=m.ID LEFT JOIN miejscowosc m1 ON u.IdMiejsceUr=m1.ID WHERE p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji=1 Order By p.NrwDzienniku,u.Nazwisko COLLATE utf8_polish_ci,u.Imie1 COLLATE utf8_polish_ci,u.Imie2 COLLATE utf8_polish_ci;"))
    DS.Tables.Add(DBA.GetDataTable("Select ID,Nazwa From miejscowosc;"))
    DS.Tables.Add(DBA.GetDataTable("SELECT Concat_WS(' ',b.Nazwisko,b.Imie),o.Klasa FROM obsada o,belfer b,przedmioty p,szkola_klasa sk WHERE o.IdBelfer=b.ID AND o.IdPrzedmiot=p.ID AND o.Klasa=sk.IdKlasa AND p.Typ='z' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND o.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "';"))
    DS.Tables.Add(DBA.GetDataTable("Select ID,Nazwa FROM szkoly WHERE ID='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "';"))
    Return DS
  End Function
  Public Sub PrnDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles Doc.PrintPage
    If Me.cbSzkola.SelectedItem Is Nothing Then Exit Sub
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
      Doc.DrawText(e, "Szkoła: " & Doc.DS.Tables(3).Select("ID='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "'")(0).Item("Nazwa").ToString, TextFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 0, Brushes.Black, False)
      'Doc.DrawText(e, "Szkoła: " & cbSzkola.Text, TextFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 0, Brushes.Black, False)
      y += LineHeight
      Doc.DrawText(e, "Rok szkolny: " & String.Concat(nudStartYear.Value.ToString, "/", nudEndYear.Value.ToString), TextFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 0, Brushes.Black, False)
      y += LineHeight * 3
    End If
    'PrintColumnsHeaders(e, x, y, TextFont, LineHeight)

    If Me.rbAllStudents.Checked Then
      PrintAllClasses(e, x, y, TextFont, LineHeight)
    Else
      If Not Me.cbKlasa.SelectedItem Is Nothing Then PrintSelectedClass(e, x, y, TextFont, LineHeight)
    End If
  End Sub
  Private Sub PrintColumnsHeaders(ByVal e As PrintPageEventArgs, ByRef x As Single, ByRef y As Single, ByVal TextFont As Font, ByVal LineHeight As Single)
    Dim x1 As Single = x

    For Each DR As DataRow In dtPrintOptions.Select("Status=1", "SortOrder ASC")
      Doc.DrawText(e, DR.Item("Alias").ToString, New Font(TextFont, FontStyle.Bold), x1, y, CType(DR.Item("ColWidth"), Single), CSng(LineHeight * 2), 1, Brushes.Black, True, False, False)
      x1 += CType(DR.Item("ColWidth"), Single)
    Next

    y += LineHeight * 2
  End Sub
  Private Sub PrintFooter(ByVal e As PrintPageEventArgs, ByRef x As Single, ByRef y As Single, ByVal TextFont As Font, ByVal LineHeight As Single, ByVal Klasa As String)
    e.Graphics.DrawLine(Pens.Black, x, y, x + 300, y)
    y += LineHeight
    'Doc.DrawText(e, "Podsumowanie:", New Font(TextFont, FontStyle.Bold), x, y, 200, CSng(LineHeight * 2), 0, Brushes.Black, False)
    Dim DBA As New DataBaseAction, R As MySqlDataReader = Nothing
    Try
      R = DBA.GetReader("SELECT Man,COUNT(u.ID) AS LiczbaUczniow FROM uczniowie u,przydzial p,szkola_klasa sk WHERE u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND p.Klasa='" & Klasa & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji='1' GROUP BY Man ASC;SELECT Miasto,COUNT(u.ID) AS LiczbaUczniow FROM uczniowie u INNER JOIN przydzial p ON u.ID=p.IdUczen INNER JOIN szkola_klasa sk ON p.Klasa=sk.IdKlasa LEFT JOIN miejscowosc m ON u.IdMiejsceZam=m.ID WHERE p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND p.Klasa='" & Klasa & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji='1' GROUP BY Miasto ASC;")
      Dim y1 As Single = y, x1 As Single = x
      While R.Read
        Doc.DrawText(e, IIf(CType(R.Item("Man"), Boolean) = False, "Liczba dziewcząt: ", "Liczba chłopców: ").ToString, TextFont, x, y1, 200, CSng(LineHeight), 0, Brushes.Black, False)
        'x1 += 
        Doc.DrawText(e, R.Item("LiczbaUczniow").ToString, New Font(TextFont, FontStyle.Bold), x1 + e.Graphics.MeasureString("Liczba dziewcząt: ", New Font(TextFont, FontStyle.Bold)).Width, y1, 200, CSng(LineHeight), 0, Brushes.Black, False)
        y1 += LineHeight
      End While
      y1 = y
      x1 += 50 + e.Graphics.MeasureString("Liczba dziewcząt: ", New Font(TextFont, FontStyle.Bold)).Width
      R.NextResult()
      While R.Read
        Doc.DrawText(e, IIf(CType(R.Item("Miasto"), Boolean) = False, "Liczba uczniów mieszkających na wsi: ", "Liczba uczniów mieszkających w mieście: ").ToString, TextFont, x1, y1, 400, CSng(LineHeight), 0, Brushes.Black, False)
        'x1 += 
        Doc.DrawText(e, R.Item("LiczbaUczniow").ToString, New Font(TextFont, FontStyle.Bold), x1 + e.Graphics.MeasureString("Liczba uczniów mieszkających w mieście: ", New Font(TextFont, FontStyle.Bold)).Width, y1, 200, CSng(LineHeight), 0, Brushes.Black, False)
        y1 += LineHeight

      End While
      y += LineHeight * 2
    Catch mex As MySqlException
    Catch ex As Exception
    Finally
      R.Close()
    End Try
    y += LineHeight * 2
  End Sub
  Private Sub PrintSelectedClass(ByVal e As PrintPageEventArgs, ByVal x As Single, ByVal y As Single, ByVal TextFont As Font, ByVal LineHeight As Single)
    Dim x1 As Single = x
    If chkWychowawca.Checked Then
      If Doc.GroupHeader IsNot Nothing AndAlso Doc.GroupHeader.GetLength(0) > 0 Then
        y += LineHeight
        Doc.DrawText(e, "Wychowawca: ", New Font("Arial", 9, FontStyle.Bold), x1, y, e.MarginBounds.Width, New Font("Arial", 9, FontStyle.Bold).GetHeight(e.Graphics), 0, Brushes.Black, False)
        Doc.DrawText(e, Doc.GroupHeader(0), New Font(TextFont, FontStyle.Bold Or FontStyle.Italic), x + e.Graphics.MeasureString("Wychowawca: ", New Font("Arial", 9, FontStyle.Bold)).Width, y, e.MarginBounds.Width, LineHeight, 0, Brushes.Black, False)

      End If
      y += LineHeight * 2
    End If
    PrintColumnsHeaders(e, x, y, TextFont, LineHeight)

    Dim Students() As DataRow
    Students = Doc.DS.Tables(0).Select("Klasa='" + Me.cbKlasa.Text + "'")
    Do Until (y + LineHeight) > e.MarginBounds.Bottom Or Doc.Offset(1) > Students.GetUpperBound(0)
      x1 = x : Doc.Lp += 1
      Doc.DrawText(e, Doc.Lp.ToString, TextFont, x1, y, CSng(dtPrintOptions.Select("Name='LP'")(0).Item(2)), LineHeight, 1, Brushes.Black, chkSiatka.Checked)
      x1 += CSng(dtPrintOptions.Select("Name='LP'")(0).Item(2))

      For Each DR As DataRow In dtPrintOptions.Select("Status=1 AND Name NOT IN ('LP','Uwagi')", "SortOrder ASC")
        If DR.Item("Name").ToString = "MiejsceUr" Then
          If IsDBNull(Students(Doc.Offset(1)).Item("IdMiejsceUr")) Then
            Doc.DrawText(e, "", TextFont, x1, y, CType(DR.Item("ColWidth"), Single), LineHeight, 0, Brushes.Black, chkSiatka.Checked)
          Else
            Doc.DrawText(e, Doc.DS.Tables(1).Select("ID=" + Students(Doc.Offset(1)).Item("IdMiejsceUr").ToString)(0).Item("Nazwa").ToString, TextFont, x1, y, CType(DR.Item("ColWidth"), Single), LineHeight, 0, Brushes.Black, chkSiatka.Checked)
          End If
        Else
          Doc.DrawText(e, Students(Doc.Offset(1)).Item(DR.Item("Name").ToString).ToString, TextFont, x1, y, CSng(DR.Item("ColWidth")), LineHeight, 0, Brushes.Black, chkSiatka.Checked)
        End If
        x1 += CType(DR.Item("ColWidth"), Single)
      Next

      If Me.chkUwagi.Checked Then Doc.DrawText(e, "", TextFont, x1, y, e.MarginBounds.Width - TotalWidth, LineHeight, 1, Brushes.Black, chkSiatka.Checked)
      y += LineHeight
      Doc.Offset(1) += 1
    Loop
    If Doc.Offset(1) <= Students.GetUpperBound(0) Then
      e.HasMorePages = True
      Me.pvListaUczniow.Rows += 1
    Else
      Doc.Offset(1) = 0
      Doc.Lp = 0
      y += LineHeight
      If chkPodsumowanie.Checked Then PrintFooter(e, x, y, TextFont, LineHeight, cbKlasa.Text)
    End If
  End Sub
  Private Sub PrintAllClasses(ByVal e As PrintPageEventArgs, ByVal x As Single, ByVal y As Single, ByVal TextFont As Font, ByVal LineHeight As Single)
    If chkPageBreak.CheckState = CheckState.Unchecked Then PrintColumnsHeaders(e, x, y, TextFont, LineHeight)
    Dim x1 As Single = x
    y += LineHeight
    Do Until (y + LineHeight * 2) > e.MarginBounds.Bottom Or Doc.Offset(0) > Me.cbKlasa.Items.Count - 1
      If Me.PrintGroupHeader AndAlso Doc.DS.Tables(0).Select("Klasa='" & Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString & "'").GetLength(0) > 0 Then
        x1 = x
        Doc.DrawText(e, "Klasa " + Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString, New Font("Arial", 11, FontStyle.Bold), x1, y, e.MarginBounds.Width, New Font("Arial", 11, FontStyle.Bold).GetHeight(e.Graphics), 0, Brushes.Black, False)
        If chkWychowawca.Checked AndAlso Doc.DS.Tables(2).Select("Klasa='" & Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString & "'").GetLength(0) > 0 Then
          x1 += e.Graphics.MeasureString("Klasa " & Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString, New Font("Arial", 10, FontStyle.Bold)).Width * 2
          Doc.DrawText(e, "Wychowawca: ", New Font("Arial", 9, FontStyle.Bold), x1, y, e.MarginBounds.Width, New Font("Arial", 9, FontStyle.Bold).GetHeight(e.Graphics), 0, Brushes.Black, False)
          Doc.DrawText(e, Doc.DS.Tables(2).Select("Klasa='" & Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString & "'")(0).Item(0).ToString, New Font(TextFont, FontStyle.Bold Or FontStyle.Italic), x1 + e.Graphics.MeasureString("Wychowawca: ", New Font("Arial", 9, FontStyle.Bold)).Width, y, e.MarginBounds.Width, New Font("Arial", 9, FontStyle.Bold).GetHeight(e.Graphics), 0, Brushes.Black, False)
        End If

        y += LineHeight * CSng(1.5)
        If chkPageBreak.CheckState = CheckState.Checked Then PrintColumnsHeaders(e, x, y, TextFont, LineHeight)
      End If

      Dim Students() As DataRow
      Students = Doc.DS.Tables(0).Select("Klasa='" & Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString & "'")
      Do Until (y + LineHeight) > e.MarginBounds.Bottom Or Doc.Offset(1) > Students.GetUpperBound(0)

        x1 = x : Doc.Lp += 1
        Doc.DrawText(e, Doc.Lp.ToString, TextFont, x1, y, CSng(dtPrintOptions.Select("Name='LP'")(0).Item(2)), LineHeight, 1, Brushes.Black, chkSiatka.Checked)
        x1 += CSng(dtPrintOptions.Select("Name='LP'")(0).Item(2))
        For Each DR As DataRow In dtPrintOptions.Select("Status=1 AND Name NOT IN ('LP','Uwagi')", "SortOrder ASC")
          If DR.Item("Name").ToString = "MiejsceUr" Then
            If IsDBNull(Students(Doc.Offset(1)).Item("IdMiejsceUr")) Then
              Doc.DrawText(e, "", TextFont, x1, y, CType(DR.Item("ColWidth"), Single), LineHeight, 0, Brushes.Black, chkSiatka.Checked)
            Else
              Doc.DrawText(e, Doc.DS.Tables(1).Select("ID=" + Students(Doc.Offset(1)).Item("IdMiejsceUr").ToString)(0).Item("Nazwa").ToString, TextFont, x1, y, CType(DR.Item("ColWidth"), Single), LineHeight, 0, Brushes.Black, chkSiatka.Checked)
            End If
          Else
            Doc.DrawText(e, Students(Doc.Offset(1)).Item(DR.Item("Name").ToString).ToString, TextFont, x1, y, CSng(DR.Item("ColWidth")), LineHeight, 0, Brushes.Black, chkSiatka.Checked)
          End If
          x1 += CType(DR.Item("ColWidth"), Single)
        Next

        If Me.chkUwagi.Checked Then Doc.DrawText(e, "", TextFont, x1, y, e.MarginBounds.Width - TotalWidth, LineHeight, 1, Brushes.Black, chkSiatka.Checked)
        y += LineHeight
        Doc.Offset(1) += 1
      Loop
      If Doc.Offset(1) <= Students.GetUpperBound(0) Then
        Me.PrintGroupHeader = False
        Exit Do
      Else
        Doc.Lp = 0
        Doc.Offset(1) = 0
        Me.PrintGroupHeader = True
      End If
      y += LineHeight
      If chkPodsumowanie.Checked Then PrintFooter(e, x, y, TextFont, LineHeight, Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString)
      Doc.Offset(0) += 1
      If Me.chkPageBreak.Checked Then Exit Do

    Loop
    If Doc.Offset(0) <= Me.cbKlasa.Items.Count - 1 Then
      e.HasMorePages = True
      Me.pvListaUczniow.Rows += 1
    End If
  End Sub

  Private Sub nudStartYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudStartYear.ValueChanged
    If Not nudStartYear.Created Then Exit Sub
    Me.nudEndYear.Value = Me.nudStartYear.Value + 1
    If Not cbSzkola.SelectedItem Is Nothing Then
      Me.pvListaUczniow.Rows = 1
      Me.Doc.PageNumber = 0
      Me.Doc.Offset(0) = 0
      Me.Doc.Offset(1) = 0
      FillKlasa()
      Doc = New PrintReport(GetData)
      pvListaUczniow.Document = Doc
      rbAllStudents_CheckedChanged(IIf(rbAllStudents.Checked, rbAllStudents, rbSelectedClass), e)

      'Dim RH(0) As String
      'RH(0) = "Lista uczniów z podziałem na klasy"
      'Doc.ReportHeader = RH
      'pvListaUczniow.InvalidatePreview()
    End If
  End Sub


  Private Sub chkVirtual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtual.CheckedChanged
    If Not cbSzkola.SelectedItem Is Nothing Then
      Me.pvListaUczniow.Rows = 1
      Me.Doc.PageNumber = 0
      Me.Doc.Offset(0) = 0
      Me.Doc.Offset(1) = 0
      FillKlasa()
      Doc = New PrintReport(GetData)
      pvListaUczniow.Document = Doc
      rbAllStudents_CheckedChanged(IIf(rbAllStudents.Checked, rbAllStudents, rbSelectedClass), e)

      'Dim RH(0) As String
      'RH(0) = "Lista uczniów z podziałem na klasy"
      'Doc.ReportHeader = RH
      'pvListaUczniow.InvalidatePreview()
    End If

  End Sub

  Private Sub chkWychowawca_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWychowawca.CheckedChanged, chkPageBreak.CheckedChanged, chkSiatka.CheckedChanged, chkPodsumowanie.CheckedChanged
    If Not cbSzkola.SelectedItem Is Nothing Then
      Me.pvListaUczniow.Rows = 1
      Me.Doc.PageNumber = 0
      Me.Doc.Offset(0) = 0
      Me.Doc.Offset(1) = 0
      pvListaUczniow.InvalidatePreview()
    End If
  End Sub


  Private Sub pvListaUczniow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pvListaUczniow.Click
    If (Control.ModifierKeys And Keys.Shift) = 0 Then
      If nudZoom.Maximum >= pvListaUczniow.Zoom * 100 * 2.0 Then
        pvListaUczniow.Zoom = pvListaUczniow.Zoom * 2.0
        nudZoom.Value = CType(pvListaUczniow.Zoom * 100, Decimal)

      End If
    Else
      If nudZoom.Minimum <= pvListaUczniow.Zoom * 100 / 2.0 Then
        pvListaUczniow.Zoom = pvListaUczniow.Zoom / 2.0
        nudZoom.Value = CType(pvListaUczniow.Zoom * 100, Decimal)

      End If
    End If
  End Sub

End Class


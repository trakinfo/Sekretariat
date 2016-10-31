Imports System.Drawing.Printing
Public Class frmDrugoroczni
  Private DT As DataTable, ListaKlas() As String, PrintGroupHeader As Boolean = True
  Public FormRole As String
  Public Event NewRow()
  Private Sub FetchData()
    Dim DBA As New DataBaseAction
    If FormRole = "Spady" Then
      Dim D As New DrugoroczniSQL
      DT = DBA.GetDataTable(D.SelectRepeaters(Me.nudStartYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString))
    ElseIf FormRole = "StrikeOut" Then
      Dim S As New StrikeOutStudentsSQL
      DT = DBA.GetDataTable(S.SelectStrikeOutStudents(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString))
    ElseIf FormRole = "OutOfDistrict" Then
      Dim O As New OutOfDistrictSQL
      DT = DBA.GetDataTable(O.SelectOutOfDistrictStudents(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString))
    Else
      Dim O As New OutOfSchoolSQL
      DT = DBA.GetDataTable(O.SelectOutOfSchoolStudents(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString))
    End If

  End Sub
  Private Sub GetKlasa()
    Dim DBA As New DataBaseAction, DT As DataTable, D As New DrugoroczniSQL
    Try
      DT = DBA.GetDataTable(D.SelectKlasa(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(chkVirtual.CheckState, Integer).ToString))
      ReDim ListaKlas(DT.Rows.Count - 1)
      For i As Integer = 0 To DT.Rows.Count - 1
        ListaKlas(i) = DT.Rows(i).Item(0).ToString
      Next
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try

  End Sub
  Private Sub FillKlasa()
    cbKlasa.Items.Clear()
    Dim FCB As New FillComboBox, D As New DrugoroczniSQL
    FCB.AddComboBoxSimpleItems(cbKlasa, D.SelectKlasa(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(chkVirtual.CheckState, Integer).ToString))
  End Sub
  Private Sub GetData()
    Try
      lvSpady.Items.Clear()
      Me.lvSpady.Groups.Clear()
      Dim Spady() As DataRow
      If rbWszystkieKlasy.Checked Then
        For i As Integer = 0 To ListaKlas.GetUpperBound(0)
          Spady = DT.Select("Klasa='" & ListaKlas(i) & "'")
          Dim NG As New ListViewGroup(ListaKlas(i))
          Me.lvSpady.Groups.Add(NG)
          For j As Integer = 0 To Spady.GetUpperBound(0)
            Dim NewItem As New ListViewItem(Spady(j).Item(0).ToString, NG)
            NewItem.SubItems.Add(Spady(j).Item(1).ToString)
            NewItem.SubItems.Add(Spady(j).Item(2).ToString)
            lvSpady.Items.Add(NewItem)
          Next
        Next
      Else
        Spady = DT.Select("Klasa='" & cbKlasa.Text & "'")
        Dim NG As New ListViewGroup(cbKlasa.Text)
        Me.lvSpady.Groups.Add(NG)
        For j As Integer = 0 To Spady.GetUpperBound(0)
          Dim NewItem As New ListViewItem(Spady(j).Item(0).ToString, NG)
          NewItem.SubItems.Add(Spady(j).Item(1).ToString)
          NewItem.SubItems.Add(Spady(j).Item(2).ToString)
          lvSpady.Items.Add(NewItem)
        Next
      End If

      lblRecord.Text = "0 z " & lvSpady.Items.Count
      lvSpady.Columns(1).Width = CInt(IIf(lvSpady.Items.Count > 20, 285, 305))
      lvSpady.Enabled = CBool(IIf(lvSpady.Items.Count > 0, True, False))
    Catch ex As MySqlException
      MessageBox.Show(ex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      'R.Close()
    End Try

  End Sub
  Private Sub frmDrugoroczni_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ListViewConfig(lvSpady)
    lblRecord.Text = ""
    Dim CH As New CalcHelper
    Me.nudStartYear.Value = CH.StartDateOfSchoolYear.Year
    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(Me.cbSzkola, "Select ID,Alias FROM szkoly;")
    SH.FindComboItem(Me.cbSzkola, CInt(SH.GetDefault("Select ID From szkoly Where IsDefault='1';")))
  End Sub
  Private Sub ListViewConfig(ByVal lv As ListView)
    With lv
      .View = View.Details
      .Enabled = True
      .FullRowSelect = True
      .GridLines = True
      .MultiSelect = True
      .AllowColumnReorder = False
      .AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
      .HideSelection = False
      .Columns.Add("ID", 0, HorizontalAlignment.Center)
      .Columns.Add("Nazwisko i imię", 357, HorizontalAlignment.Left)
      .Columns.Add("Klasa", 0, HorizontalAlignment.Center)
      .Items.Clear()
      .Enabled = False
    End With
  End Sub

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Dispose(True)
  End Sub
  Private Sub nudStartYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudStartYear.ValueChanged
    If Not nudStartYear.Created Then Exit Sub
    Me.nudEndYear.Value = Me.nudStartYear.Value + 1
    If Not cbSzkola.SelectedItem Is Nothing Then
      ClearDetails()
      FillKlasa()
      Me.FetchData()
      GetKlasa()
      GetData()
    End If
  End Sub
  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    ClearDetails()
    FillKlasa()
    Me.FetchData()
    GetKlasa()
    GetData()
    nudStartYear.Enabled = True
    chkVirtual.Enabled = True
    gpbZakres.Enabled = True
    cmdPrint.Enabled = True
  End Sub
  Private Sub chkVirtual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtual.CheckedChanged
    If Not cbSzkola.SelectedItem Is Nothing Then
      ClearDetails()
      FetchData()
      FillKlasa()
      GetKlasa()
      GetData()
    End If
  End Sub
  Private Sub rbWybranaKlasa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWybranaKlasa.CheckedChanged, rbWszystkieKlasy.CheckedChanged
    If Not Me.Created Then Exit Sub
    If CType(sender, RadioButton).Checked Then
      If CType(sender, RadioButton).Name = "rbWybranaKlasa" Then
        cbKlasa.Enabled = True
      Else
        cbKlasa.Enabled = False
      End If
      GetData()
    End If
  End Sub

  Private Sub cbKlasa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbKlasa.SelectedIndexChanged
    GetData()
  End Sub

  Private Sub lvSpady_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvSpady.ItemSelectionChanged
    If e.IsSelected Then
      ClearDetails()
      GetDetails(e.Item.Text, CType(sender, ListView))
    Else
      ClearDetails()
    End If
  End Sub
  Private Sub ClearDetails()
    lblUser.Text = ""
    lblIP.Text = ""
    lblData.Text = ""
  End Sub
  Private Sub GetDetails(ByVal ID As String, ByVal lv As ListView)
    Dim FoundRow() As DataRow
    Try
      lblRecord.Text = lv.SelectedItems(0).Index + 1 & " z " & lv.Items.Count
      FoundRow = DT.Select("IdUczen=" & ID)
      With FoundRow(0)
        lblUser.Text = .Item(3).ToString
        lblIP.Text = .Item(4).ToString
        lblData.Text = .Item(5).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub

  Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
    Dim PP As New dlgPrintPreview, DS As New DataSet
    DS.Tables.Add(DT)
    PP.Doc = New PrintReport(DS)
    AddHandler PP.Doc.PrintPage, AddressOf PrnDoc_PrintPage
    AddHandler NewRow, AddressOf PP.NewRow
    If FormRole = "Spady" Then
      PP.Doc.ReportHeader = New String() {"Wykaz uczniów drugorocznych"}
    ElseIf FormRole = "StrikeOut" Then
      PP.Doc.ReportHeader = New String() {"Wykaz uczniów skreślonych z listy"}
    ElseIf FormRole = "OutOfDistrict" Then
      PP.Doc.ReportHeader = New String() {"Wykaz uczniów należących do innych obwodów szkolnych"}
    Else
      PP.Doc.ReportHeader = New String() {"Wykaz uczniów realizujących obowiązek szkolny poza szkołą"}
    End If

    If PP.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      DS.Tables.Remove(DT)
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
      y += LineHeight * 2
    End If
    If Me.rbWszystkieKlasy.Checked Then
      PrintAllClasses(e, Doc, x, y, TextFont, LineHeight)
    Else
      If Not Me.cbKlasa.SelectedItem Is Nothing Then PrintSelectedClass(e, Doc, x, y, TextFont, LineHeight)
    End If
    'PrintColumnsHeaders(e, x, y, TextFont, LineHeight)
  End Sub
  Private Sub PrintAllClasses(ByVal e As PrintPageEventArgs, ByVal Doc As PrintReport, ByVal x As Single, ByVal y As Single, ByVal TextFont As Font, ByVal LineHeight As Single)

    Dim x1 As Single = x
    Do Until (y + LineHeight * 2) > e.MarginBounds.Bottom Or Doc.Offset(0) > Me.cbKlasa.Items.Count - 1 'Doc.DS.Tables(0).Rows.Count - 1
      If Me.PrintGroupHeader AndAlso Doc.DS.Tables(0).Select("Klasa='" & Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString & "'").GetLength(0) > 0 Then
        y += LineHeight * 2
        x1 = x
        Doc.DrawText(e, "Klasa " + Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString, New Font("Arial", 11, FontStyle.Bold), x1, y, e.MarginBounds.Width, New Font("Arial", 11, FontStyle.Bold).GetHeight(e.Graphics), 0, Brushes.Black, False)
        y += LineHeight * CSng(1.5)
      End If

      Do Until (y + LineHeight) > e.MarginBounds.Bottom Or Doc.Offset(1) > Doc.DS.Tables(0).Select("Klasa='" & Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString & "'").GetUpperBound(0)
        x1 = x : Doc.Lp += 1
        'Doc.Lp += 1
        Doc.DrawText(e, Doc.Lp.ToString, TextFont, x, y, 40, LineHeight, 1, Brushes.Black, False)
        Doc.DrawText(e, Doc.DS.Tables(0).Select("Klasa='" & Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString & "'")(Doc.Offset(1)).Item("Student").ToString, TextFont, x + 40, y, 300, LineHeight, 0, Brushes.Black, False)
        y += LineHeight
        Doc.Offset(1) += 1
      Loop
      If Doc.Offset(1) <= Doc.DS.Tables(0).Select("Klasa='" & Me.cbKlasa.Items.Item(Doc.Offset(0)).ToString & "'").GetUpperBound(0) Then
        Me.PrintGroupHeader = False
        Exit Do
      Else
        Doc.Lp = 0
        Doc.Offset(1) = 0
        Me.PrintGroupHeader = True
      End If
      'y += LineHeight
      Doc.Offset(0) += 1
    Loop
    If Doc.Offset(0) <= Me.cbKlasa.Items.Count - 1 Then
      e.HasMorePages = True
      RaiseEvent NewRow()
    End If
  End Sub
  Private Sub PrintSelectedClass(ByVal e As PrintPageEventArgs, ByVal Doc As PrintReport, ByVal x As Single, ByVal y As Single, ByVal TextFont As Font, ByVal LineHeight As Single)
    Doc.DrawText(e, "Klasa: " & cbKlasa.Text, TextFont, x, y, 300, LineHeight, 0, Brushes.Black, False)
    y += LineHeight * 2
    Doc.DrawText(e, "L.p.", New Font(TextFont, FontStyle.Bold), x, y, 40, LineHeight * 2, 1, Brushes.Black)
    Doc.DrawText(e, "Nazwisko i imię", New Font(TextFont, FontStyle.Bold), x + 40, y, 300, LineHeight * 2, 1, Brushes.Black)
    y += LineHeight * 2

    Do Until (y + LineHeight) > e.MarginBounds.Bottom Or Doc.Offset(0) > Doc.DS.Tables(0).Select("Klasa='" & cbKlasa.Text & "'").GetUpperBound(0)
      Doc.Lp += 1
      Doc.DrawText(e, Doc.Lp.ToString, TextFont, x, y, 40, LineHeight, 1, Brushes.Black)
      Doc.DrawText(e, Doc.DS.Tables(0).Select("Klasa='" & cbKlasa.Text & "'")(Doc.Offset(0)).Item("Student").ToString, TextFont, x + 40, y, 300, LineHeight, 0, Brushes.Black)
      y += LineHeight

      Doc.Offset(0) += 1
    Loop

    If Doc.Offset(0) <= Doc.DS.Tables(0).Select("Klasa='" & cbKlasa.Text & "'").GetLength(0) - 1 Then
      e.HasMorePages = True
      RaiseEvent NewRow()
    End If

  End Sub
  
End Class

Public Class DrugoroczniSQL
  Public Function SelectRepeaters(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT distinct p.IdUczen,Concat_WS(' ',u.Nazwisko,u.Imie1) as Student,p.Klasa,p.User,p.ComputerIP,p.Version FROM przydzial p,szkola_klasa sk,uczniowie u WHERE p.Klasa=sk.IdKlasa AND p.IdUczen=u.ID AND sk.IdSzkola='" & IdSzkola & "' AND LEFT(p.RokSzkolny,4)='" & RokSzkolny & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1' AND p.IdUczen IN (SELECT DISTINCT IdUczen FROM przydzial WHERE LEFT(RokSzkolny,4)='" & CType(RokSzkolny, Integer) - 1 & "' AND Promocja='0' AND StatusAktywacji='1') ORDER BY u.Nazwisko,u.Imie1,u.Imie2;"
  End Function
  Public Function SelectKlasa(ByVal IdSzkola As String, ByVal RokSzkolny As String, ByVal Virtual As String) As String
    Return "SELECT DISTINCT p.Klasa FROM przydzial p INNER JOIN szkola_klasa sk ON p.Klasa=sk.IdKlasa WHERE p.RokSzkolny='" & RokSzkolny & "' AND sk.IdSzkola='" & IdSzkola & "' AND sk.Virtual='" & Virtual & "' AND StatusAktywacji=1 ORDER BY p.Klasa ASC;"
  End Function
End Class

Public Class StrikeOutStudentsSQL
  Public Function SelectStrikeOutStudents(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT distinct p.IdUczen,Concat_WS(' ',u.Nazwisko,u.Imie1) as Student,p.Klasa,p.User,p.ComputerIP,p.Version FROM przydzial p,szkola_klasa sk,uczniowie u WHERE p.Klasa=sk.IdKlasa AND p.IdUczen=u.ID AND sk.IdSzkola='" & IdSzkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='0' AND MasterRecord='1' ORDER BY u.Nazwisko,u.Imie1,u.Imie2;"
  End Function
End Class

Public Class OutOfSchoolSQL
  Public Function SelectOutOfSchoolStudents(ByVal RokSzkolny As String, ByVal IdSzkola As String) As String
    Return "SELECT distinct p.IdUczen,Concat_WS(' ',u.Nazwisko,u.Imie1) as Student,p.Klasa,p.User,p.ComputerIP,p.Version FROM przydzial p,szkola_klasa sk,uczniowie u WHERE p.Klasa=sk.IdKlasa AND p.IdUczen=u.ID AND sk.IdSzkola='" & IdSzkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND sk.Virtual='1' AND p.StatusAktywacji='1' AND MasterRecord='1' ORDER BY u.Nazwisko,u.Imie1,u.Imie2;"
  End Function
End Class

Public Class OutOfDistrictSQL
  Public Function SelectOutOfDistrictStudents(ByVal RokSzkolny As String, ByVal IdSzkola As String) As String
    Return "SELECT distinct p.IdUczen,Concat_WS(' ',u.Nazwisko,u.Imie1) as Student,p.Klasa,p.User,p.ComputerIP,p.Version FROM przydzial p,szkola_klasa sk,uczniowie u WHERE p.Klasa=sk.IdKlasa AND p.IdUczen=u.ID AND sk.IdSzkola='" & IdSzkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND sk.Virtual='0' AND p.StatusAktywacji='1' AND MasterRecord='1' AND u.ObwodSzkolny='0' ORDER BY u.Nazwisko,u.Imie1,u.Imie2;"
  End Function
End Class
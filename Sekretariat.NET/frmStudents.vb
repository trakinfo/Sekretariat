Public Class frmStudents

  Private DS As DataSet, Filter As String = ""
  Dim sortColumn As Integer = -1
  Private Sub FetchData()
    Dim S As New StudentSQL, DBA As New DataBaseAction
    DS = DBA.GetDataSet(S.SelectStudents(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString) & S.SelectDetails(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString) & S.SelectWychowawca(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString) & S.SelectRepeaters(Me.nudStartYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString))
  End Sub
  Private Sub GetMainData()
    Try
      Dim FilteredData() As DataRow
      FilteredData = DS.Tables(0).Select(Filter)
      For i As Integer = 0 To FilteredData.GetUpperBound(0)
        If CType(FilteredData(i).Item("StatusAktywacji"), Boolean) Then
          Dim Repeater() As DataRow
          Repeater = DS.Tables(3).Select("IdUczen=" & FilteredData(i).Item(0).ToString)
          If Repeater.GetLength(0) > 0 Then
            lvUczen.Items.Add(FilteredData(i).Item(0).ToString).UseItemStyleForSubItems = False
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(1).ToString, Color.Red, lvUczen.BackColor, lvUczen.Font)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(2).ToString, Color.Red, lvUczen.BackColor, lvUczen.Font)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(3).ToString, Color.Red, lvUczen.BackColor, lvUczen.Font)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(4).ToString, Color.Red, lvUczen.BackColor, lvUczen.Font)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(5).ToString, Color.Red, lvUczen.BackColor, lvUczen.Font)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(CType(FilteredData(i).Item(6), Date).ToString("yyyy-MM-dd"), Color.Red, lvUczen.BackColor, lvUczen.Font)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(7).ToString, Color.Red, lvUczen.BackColor, lvUczen.Font)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(IIf(CType(FilteredData(i).Item(8), Boolean) = True, "w", "inny").ToString, Color.Red, lvUczen.BackColor, lvUczen.Font)
          Else
            lvUczen.Items.Add(FilteredData(i).Item(0).ToString)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(1).ToString)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(2).ToString)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(3).ToString)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(4).ToString)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(5).ToString)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(CType(FilteredData(i).Item(6), Date).ToString("yyyy-MM-dd"))
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(7).ToString)
            lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(IIf(CType(FilteredData(i).Item(8), Boolean) = True, "w", "inny").ToString)
          End If

        Else
          lvUczen.Items.Add(FilteredData(i).Item(0).ToString).UseItemStyleForSubItems = False
          lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(1).ToString, Color.Gray, lvUczen.BackColor, New Font(lvUczen.Font, FontStyle.Strikeout))
          lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(2).ToString, Color.Gray, lvUczen.BackColor, New Font(lvUczen.Font, FontStyle.Strikeout))
          lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(3).ToString, Color.Gray, lvUczen.BackColor, New Font(lvUczen.Font, FontStyle.Strikeout))
          lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(4).ToString, Color.Gray, lvUczen.BackColor, New Font(lvUczen.Font, FontStyle.Strikeout))
          lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(5).ToString, Color.Gray, lvUczen.BackColor, New Font(lvUczen.Font, FontStyle.Strikeout))
          lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(CType(FilteredData(i).Item(6), Date).ToString("yyyy-MM-dd"), Color.Gray, lvUczen.BackColor, New Font(lvUczen.Font, FontStyle.Strikeout))
          lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(FilteredData(i).Item(7).ToString, Color.Gray, lvUczen.BackColor, New Font(lvUczen.Font, FontStyle.Strikeout))
          lvUczen.Items(lvUczen.Items.Count - 1).SubItems.Add(IIf(CType(FilteredData(i).Item(8), Boolean) = True, "w", "inny").ToString, Color.Gray, lvUczen.BackColor, New Font(lvUczen.Font, FontStyle.Strikeout))
        End If
      Next
      lblRecord.Text = "0 z " & FilteredData.GetLength(0) & " (" & DS.Tables(0).Select("StatusAktywacji=1").GetLength(0) & " aktywnych)"
      lvUczen.Columns(4).Width = CInt(IIf(lvUczen.Items.Count > 16, 185, 204))
      lvUczen.Enabled = CBool(IIf(lvUczen.Items.Count > 0, True, False))
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub
  Private Sub GetDetails(ByVal ID As String)
    Dim FoundRow() As DataRow
    Try
      lblRecord.Text = lvUczen.SelectedItems(0).Index + 1 & " z " & lvUczen.Items.Count & " (" & DS.Tables(0).Select("StatusAktywacji=1").GetLength(0) & " aktywnych)"
      FoundRow = DS.Tables(1).Select("ID=" & ID)
      With FoundRow(0)
        lblMiejsceUr.Text = .Item(1).ToString
        lblWojUr.Text = .Item(2).ToString
        lblMan.Text = IIf(CType(.Item(3), Boolean) = True, "M", "K").ToString
        chkNiepelnosprawnosc.Checked = CType(IIf(CType(IsDBNull(.Item(4)), Boolean) = False, .Item(4), False), Boolean)
        lblMiejsceZam.Text = .Item(5).ToString
        lblUlica.Text = .Item(6).ToString
        lblNrDomu.Text = .Item(7).ToString
        lblNrMieszkania.Text = .Item(8).ToString
        lblPoczta.Text = .Item(9).ToString
        'If .Item(10).ToString <> "" Then lblKodPocztowy.Text = Format(CType(.Item(10), Integer), "00-000")
        lblKodPocztowy.Text = .Item(10).ToString
        lblWojZam.Text = .Item(11).ToString
        chkMiasto.Checked = CType(IIf(CType(IsDBNull(.Item(12)), Boolean) = False, .Item(12), False), Boolean)
        lblTel1.Text = .Item(13).ToString
        lblKraj.Text = .Item(14).ToString
        lblTelKom1.Text = .Item(15).ToString
        lblTelKom2.Text = .Item(16).ToString
        lblImieOjca.Text = .Item(17).ToString
        lblNazwiskoOjca.Text = .Item(18).ToString
        lblImieMatki.Text = .Item(19).ToString
        lblNazwiskoMatki.Text = .Item(20).ToString
        chkNiepelnosprawnosc.Checked = CType(IIf(CType(IsDBNull(.Item(21)), Boolean) = False, .Item(21), False), Boolean)

        lblUser.Text = .Item(22).ToString
        lblIP.Text = .Item(23).ToString
        lblData.Text = .Item(24).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub
  Private Sub ClearDetails()
    lblMiejsceUr.Text = ""
    lblWojUr.Text = ""
    lblMan.Text = ""
    chkNiepelnosprawnosc.Checked = False
    lblMiejsceZam.Text = ""
    lblUlica.Text = ""
    lblNrDomu.Text = ""
    lblNrMieszkania.Text = ""
    lblPoczta.Text = ""
    lblKodPocztowy.Text = ""
    lblWojZam.Text = ""
    chkMiasto.Checked = False
    lblTel1.Text = ""
    lblKraj.Text = ""
    lblTelKom1.Text = ""
    lblTelKom2.Text = ""
    lblImieOjca.Text = ""
    lblNazwiskoOjca.Text = ""
    lblImieMatki.Text = ""
    lblNazwiskoMatki.Text = ""
    chkNiepelnosprawnosc.Checked = False
    lblUser.Text = ""
    lblIP.Text = ""
    lblData.Text = ""
    lblWychowawca.Text = ""
    lblRecord.Text = "0 z " & lvUczen.Items.Count
  End Sub


  Private Sub frmStudents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    AddHandler SharedException.OnErrorGenerate, AddressOf EditData
    'Me.lblRecord.Text = ""
    'Me.lblWychowawca.Text = ""
    ClearDetails()
    ListViewConfig()
    Dim CH As New CalcHelper
    Me.nudStartYear.Value = CH.StartDateOfSchoolYear.Year
    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(Me.cbSzkola, "Select ID,Alias FROM szkoly;")
    SH.FindComboItem(Me.cbSzkola, CInt(SH.GetDefault("Select ID From szkoly Where IsDefault='1';")))
    Dim SeekCriteria() As String = New String() {"Klasa", "Nazwisko i imię", "Nr ewidencyjny", "Data urodzenia", "Pesel", "Miejsce urodzenia", "Kraj urodzenia", "Miejsce zamieszkania", "Obwód szkolny"}
    Me.cbSeek.Items.AddRange(SeekCriteria)
    Me.cbSeek.SelectedIndex = 0
  End Sub
  Private Sub EnableButtons(ByVal Value As Boolean)
    Me.cmdDelete.Enabled = Value
    Me.cmdEdit.Enabled = Value
    Me.cmdStrikeOut.Enabled = Value
    Me.cmdNrDz.Enabled = Value
  End Sub
  Private Sub ListViewConfig()
    With lvUczen
      .View = View.Details
      .Enabled = True
      .FullRowSelect = True
      .GridLines = True
      .MultiSelect = True
      .AllowColumnReorder = False
      .AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
      .HideSelection = False
      .Columns.Add("ID", 0, HorizontalAlignment.Center)
      .Columns.Add("Nr kol.", 50, HorizontalAlignment.Center)
      .Columns.Add("Nr ewid.", 60, HorizontalAlignment.Center)
      .Columns.Add("Nr leg. szk.", 70, HorizontalAlignment.Center)
      .Columns.Add("Nazwisko i imiona", 204, HorizontalAlignment.Left)
      .Columns.Add("Klasa", 50, HorizontalAlignment.Center)
      .Columns.Add("Data ur.", 80, HorizontalAlignment.Center)
      .Columns.Add("Pesel", 90, HorizontalAlignment.Center)
      .Columns.Add("Obwód", 50, HorizontalAlignment.Center)
      .Items.Clear()
      .Enabled = False
    End With
  End Sub

  Private Sub lvUczen_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvUczen.ItemSelectionChanged
    If e.IsSelected Then
      ClearDetails()
      GetWychowawca(e.Item.SubItems(5).Text)
      GetDetails(e.Item.Text)
      EnableButtons(True)
    Else
      ClearDetails()
      lblWychowawca.Text = ""
      EnableButtons(False)
    End If
  End Sub
  Private Sub GetWychowawca(ByVal Klasa As String)
    Try
      If DS.Tables(2).Select("Klasa='" & Klasa & "'").Length > 0 Then
        lblWychowawca.Text = DS.Tables(2).Select("Klasa='" & Klasa & "'")(0).Item(0).ToString
      Else
        lblWychowawca.Text = ""
      End If
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub
  Private Sub RefreshData()
    lvUczen.Sorting = SortOrder.None
    lvUczen.Items.Clear()
    ClearDetails()
    GetMainData()
  End Sub

  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    If MessageBox.Show("Zaznaczeni uczniowie zostaną bezpowrotnie usunięci z bazy danych." & vbNewLine & "Czy na pewno o to Ci chodzi? Jeśli tak, to naciśnij przycisk 'OK'. W przeciwnym razie wciśnij przycisk 'Anuluj'.", My.Application.Info.ProductName, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
      Dim S As New StudentSQL, DBA As New DataBaseAction, DeletedIndex As Integer
      For Each Item As ListViewItem In Me.lvUczen.SelectedItems
        DeletedIndex = Item.Index
        DBA.ApplyChanges(S.DeleteStudent(Item.Text))
      Next
      Me.FetchData()
      Me.RefreshData()
      Dim SH As New SeekHelper
      Me.EnableButtons(False)
      SH.FindRemovedListViewItemIndex(Me.lvUczen, DeletedIndex)
    End If
  End Sub
  Private Sub frmUczen_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    SharedStudent.CloseChildren(Me, e)
  End Sub

  Private Sub frmUczen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    SharedStudent.CloseChildren(Me, e)
  End Sub

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Dispose(True)
  End Sub
  Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
    Dim dlgAddNew As New dlgStudent
    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(dlgAddNew.cbMiejsceUr, "Select m.ID,concat_WS(' ',m.Nazwa,'{',w.Nazwa,'}') as Nazwa From miejscowosc m left Join wojewodztwa w on m.IdWoj=w.KodWoj Order by m.Nazwa;")
    dlgAddNew.cbMiejsceUr.AutoCompleteSource = AutoCompleteSource.ListItems
    dlgAddNew.cbMiejsceUr.AutoCompleteMode = AutoCompleteMode.Append
    SH.FindComboItem(dlgAddNew.cbMiejsceUr, My.Settings.LastMiejsceUr)
    FCB.AddComboBoxComplexItems(dlgAddNew.cbMiejsceZam, "Select m.ID,concat_WS(' ',m.Nazwa,'{',w.Nazwa,'}') as Nazwa From miejscowosc m left Join wojewodztwa w on m.IdWoj=w.KodWoj Order by m.Nazwa;")
    dlgAddNew.cbMiejsceZam.AutoCompleteSource = AutoCompleteSource.ListItems
    dlgAddNew.cbMiejsceZam.AutoCompleteMode = AutoCompleteMode.Append
    SH.FindComboItem(dlgAddNew.cbMiejsceZam, My.Settings.LastMiejsceZam)
    FCB.AddComboBoxSimpleItems(dlgAddNew.cbKlasa, "SELECT IdKlasa FROM szkola_klasa sk WHERE sk.Virtual='" & CType(Me.chkVirtual.CheckState, Integer).ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "';")
    dlgAddNew.cbKlasa.AutoCompleteSource = AutoCompleteSource.ListItems
    dlgAddNew.cbKlasa.AutoCompleteMode = AutoCompleteMode.Append
    If Me.lvUczen.SelectedItems.Count > 0 Then dlgAddNew.cbKlasa.Text = Me.lvUczen.SelectedItems(0).SubItems(5).Text
    dlgAddNew.Text = "Dodawanie nowego ucznia"
    dlgAddNew.cbPlec.Text = "M"
    dlgAddNew.chkObwod.Checked = True
    dlgAddNew.RokSzkolny = Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString
    dlgAddNew.MdiParent = Me.MdiParent
    dlgAddNew.MaximizeBox = False
    dlgAddNew.StartPosition = FormStartPosition.CenterScreen
    'dlgAddNew.Opacity = 0.7
    dlgAddNew.Show()
    AddHandler dlgAddNew.NewStudentAdded, AddressOf NewStudentAdded
    AddHandler dlgAddNew.FormClosed, AddressOf EnableCmdAddNew
    Me.cmdAddNew.Enabled = False
  End Sub
  Private Sub EnableCmdAddNew(ByVal sender As Object, ByVal e As FormClosedEventArgs)
    Me.cmdAddNew.Enabled = True
  End Sub
  Private Sub NewStudentAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedID As String)
    Me.FetchData()
    RefreshData()
    Dim SH As New SeekHelper
    SH.FindListViewItem(Me.lvUczen, InsertedID)
  End Sub
  Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
    EditData()
  End Sub
  Private Sub lvUczen_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvUczen.DoubleClick
    EditData()
  End Sub

  Private Sub EditData()
    Try
      Dim dlgEdit As New dlgStudent()
      Dim FCB As New FillComboBox
      FCB.AddComboBoxComplexItems(dlgEdit.cbMiejsceUr, "Select m.ID,concat_WS(' ',m.Nazwa,'{',w.Nazwa,'}') From miejscowosc m left Join wojewodztwa w on m.IdWoj=w.KodWoj Order by m.Nazwa;")
      dlgEdit.cbMiejsceUr.AutoCompleteSource = AutoCompleteSource.ListItems
      dlgEdit.cbMiejsceUr.AutoCompleteMode = AutoCompleteMode.Append
      FCB.AddComboBoxComplexItems(dlgEdit.cbMiejsceZam, "Select m.ID,concat_WS(' ',m.Nazwa,'{',w.Nazwa,'}') From miejscowosc m left Join wojewodztwa w on m.IdWoj=w.KodWoj Order by m.Nazwa;")
      dlgEdit.cbMiejsceZam.AutoCompleteSource = AutoCompleteSource.ListItems
      dlgEdit.cbMiejsceZam.AutoCompleteMode = AutoCompleteMode.Append
      FCB.AddComboBoxSimpleItems(dlgEdit.cbKlasa, "SELECT IdKlasa FROM szkola_klasa sk WHERE sk.Virtual='" & CType(Me.chkVirtual.CheckState, Integer).ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "';")
      dlgEdit.cbKlasa.AutoCompleteSource = AutoCompleteSource.ListItems
      dlgEdit.cbKlasa.AutoCompleteMode = AutoCompleteMode.Append

      With dlgEdit
        .Text = "Edycja danych ucznia"
        '.MdiParent = Me.MdiParent
        .txtNrArkusza.Text = Me.lvUczen.SelectedItems(0).SubItems(2).Text
        Dim SH As New SeekHelper
        .txtNrLegSzkol.Text = DS.Tables(0).Select("ID=" & lvUczen.SelectedItems(0).Text)(0).Item("NrLegSzkol").ToString
        SH.FindComboItem(.cbKlasa, Me.lvUczen.SelectedItems(0).SubItems(5).Text)
        .txtNazwisko.Text = DS.Tables(0).Select("ID=" & lvUczen.SelectedItems(0).Text)(0).Item("Nazwisko").ToString
        .txtImie.Text = DS.Tables(0).Select("ID=" & lvUczen.SelectedItems(0).Text)(0).Item("Imie1").ToString
        .txtImie2.Text = DS.Tables(0).Select("ID=" & lvUczen.SelectedItems(0).Text)(0).Item("Imie2").ToString
        .dtDataUr.Value = CType(Me.lvUczen.SelectedItems(0).SubItems(6).Text, Date)
        If Me.lblMiejsceUr.Text.Length > 0 Then SH.FindComboItem(.cbMiejsceUr, CType(DS.Tables(1).Select("ID=" & lvUczen.SelectedItems(0).Text)(0).Item("IdMiejsceUr"), Integer))
        If Me.lblMiejsceZam.Text.Length > 0 Then SH.FindComboItem(.cbMiejsceZam, CType(DS.Tables(1).Select("ID=" & lvUczen.SelectedItems(0).Text)(0).Item("IdMiejsceZam"), Integer))
        .txtUlica.Text = lblUlica.Text
        .txtNrDomu.Text = lblNrDomu.Text
        .txtNrMieszkania.Text = lblNrMieszkania.Text
        .txtTel1.Text = lblTel1.Text
        .txtTel2.Text = lblKraj.Text
        .txtTelKom1.Text = lblTelKom1.Text
        .txtTelKom2.Text = lblTelKom2.Text
        .txtImieOjca.Text = Me.lblImieOjca.Text
        .txtNazwiskoOjca.Text = lblNazwiskoOjca.Text
        .txtImieMatki.Text = Me.lblImieMatki.Text
        .txtNazwiskoMatki.Text = lblNazwiskoMatki.Text
        .cbPlec.Text = Me.lblMan.Text
        .txtPesel.Text = Me.lvUczen.SelectedItems(0).SubItems(7).Text
        .chkObwod.Checked = CType(IIf(Me.lvUczen.SelectedItems(0).SubItems(8).Text = "w", True, False), Boolean)
        .chkNiepelnosprawnosc.Checked = chkNiepelnosprawnosc.Checked
        .CancelButton = .cmdClose
        .AcceptButton = .cmdSave
        '.Icon = gblAppIcon
        .MinimizeBox = False
        .MaximizeBox = False

        If dlgEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
          Dim DBA As New DataBaseAction, S As New StudentSQL, IdUczen As String
          Dim MySQLTrans As MySqlTransaction

          IdUczen = Me.lvUczen.SelectedItems(0).Text
          Dim cmd As MySqlCommand = DBA.CreateCommand(S.UpdateStudent(IdUczen))
          MySQLTrans = GlobalValues.gblConn.BeginTransaction()
          cmd.Transaction = MySQLTrans
          Try
            cmd.Parameters.AddWithValue("?Nazwisko", .txtNazwisko.Text.Trim)
            cmd.Parameters.AddWithValue("?Imie1", .txtImie.Text.Trim)
            cmd.Parameters.AddWithValue("?Imie2", .txtImie2.Text.Trim)
            cmd.Parameters.AddWithValue("?NrArkusza", IIf(.txtNrArkusza.Text.Length > 0, .txtNrArkusza.Text.Trim, DBNull.Value))
            cmd.Parameters.AddWithValue("?NrLegSzkol", IIf(.txtNrLegSzkol.Text.Length > 0, .txtNrLegSzkol.Text.Trim, DBNull.Value))
            cmd.Parameters.AddWithValue("?DataUr", .dtDataUr.Value.ToString("yyyy-MM-dd"))
            If .cbMiejsceUr.Text = "" Then
              cmd.Parameters.AddWithValue("?IdMiejsceUr", DBNull.Value)
            Else
              cmd.Parameters.AddWithValue("?IdMiejsceUr", CType(.cbMiejsceUr.SelectedItem, CbItem).ID)
            End If
            If .cbMiejsceZam.Text = "" Then
              cmd.Parameters.AddWithValue("?IdMiejsceZam", DBNull.Value)
            Else
              cmd.Parameters.AddWithValue("?IdMiejsceZam", CType(.cbMiejsceZam.SelectedItem, CbItem).ID)
            End If

            cmd.Parameters.AddWithValue("?Ulica", .txtUlica.Text)
            cmd.Parameters.AddWithValue("?NrDomu", .txtNrDomu.Text)
            cmd.Parameters.AddWithValue("?NrMieszkania", .txtNrMieszkania.Text)
            cmd.Parameters.AddWithValue("?Tel1", .txtTel1.Text)
            cmd.Parameters.AddWithValue("?Tel2", .txtTel2.Text)
            cmd.Parameters.AddWithValue("?TelKom1", .txtTelKom1.Text)
            cmd.Parameters.AddWithValue("?TelKom2", .txtTelKom2.Text)
            cmd.Parameters.AddWithValue("?ImieOjca", .txtImieOjca.Text)
            cmd.Parameters.AddWithValue("?NazwiskoOjca", .txtNazwiskoOjca.Text)
            cmd.Parameters.AddWithValue("?ImieMatki", .txtImieMatki.Text)
            cmd.Parameters.AddWithValue("?NazwiskoMatki", .txtNazwiskoMatki.Text)
            cmd.Parameters.AddWithValue("?Man", IIf(.cbPlec.Text = "M", 1, 0))
            cmd.Parameters.AddWithValue("?Pesel", .txtPesel.Text)
            cmd.Parameters.AddWithValue("?ObwodSzkolny", .chkObwod.Checked)
            cmd.Parameters.AddWithValue("?Niepelnosprawnosc", .chkNiepelnosprawnosc.Checked)

            cmd.ExecuteNonQuery()

            cmd.CommandText = S.UpdatePrzydzial(IdUczen, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString)
            cmd.ExecuteNonQuery()

            cmd.CommandText = S.UpdatePrzydzial(IdUczen, .cbKlasa.Text, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString)
            If Not cmd.ExecuteNonQuery() > 0 Then
              cmd.CommandText = S.InsertPrzydzial()
              cmd.Parameters.AddWithValue("?IdUczen", IdUczen)
              cmd.Parameters.AddWithValue("?Klasa", .cbKlasa.Text)
              cmd.Parameters.AddWithValue("?RokSzkolny", Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString)
              cmd.ExecuteNonQuery()
            End If

            MySQLTrans.Commit()

          Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            MySQLTrans.Rollback()
          End Try
          Me.FetchData()
          RefreshData()
          Me.EnableButtons(False)
          SH.FindListViewItem(Me.lvUczen, IdUczen)
        End If
      End With
    Catch ex As Exception

      MessageBox.Show(ex.Message)
    End Try

  End Sub

  Private Sub SetNrDzByAlphabet()
    Dim DT As DataTable, S As New StudentSQL, DBA As New DataBaseAction
    Dim MySQLTrans As MySqlTransaction
    MySQLTrans = GlobalValues.gblConn.BeginTransaction()
    Try
      DT = DBA.GetDataTable(S.SelectStudentsID(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(Me.cbSzkola.SelectedItem, CbItem).ID.ToString, Me.lvUczen.SelectedItems(0).SubItems(5).Text))
      Dim i As Integer = 0
      Do Until i > DT.Rows.Count - 1
        i += 1
        DBA.ApplyChanges(S.UpdateNrDz(CStr(i), DT.Rows(i - 1).Item(0).ToString, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString), MySQLTrans)
      Loop
      MySQLTrans.Commit()
    Catch ex As Exception
      MySQLTrans.Rollback()
    End Try
  End Sub
  Private Sub AddToEndOfList()
    Dim S As New StudentSQL, DBA As New DataBaseAction
    DBA.ApplyChanges(S.UpdateNrDz((DBA.CountRecords(S.SelectMaxNrDz(CType(Me.cbSzkola.SelectedItem, CbItem).ID.ToString, Me.lvUczen.SelectedItems(0).SubItems(5).Text, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString)) + 1).ToString, Me.lvUczen.SelectedItems(0).Text, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString))
  End Sub
  Private Sub SetNrByHand(ByVal Nr As String)
    Dim S As New StudentSQL, DBA As New DataBaseAction
    DBA.ApplyChanges(S.UpdateNrDz(Nr, Me.lvUczen.SelectedItems(0).Text, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString))
  End Sub

  Private Sub cmdNrDz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNrDz.Click
    Dim dlgNrDz As New dlgNrDz, IdUczen As String = Me.lvUczen.SelectedItems(0).Text
    dlgNrDz.Text = "Numer w dzienniku"
    If dlgNrDz.ShowDialog = Windows.Forms.DialogResult.OK Then
      If dlgNrDz.rbAddToEnd.Checked Then
        AddToEndOfList()
      ElseIf dlgNrDz.rbByAlfabet.Checked Then
        SetNrDzByAlphabet()
      Else
        SetNrByHand(dlgNrDz.nudNr.Value.ToString)
      End If
      Me.FetchData()
      Me.RefreshData()
      Dim SH As New SeekHelper
      SH.FindListViewItem(Me.lvUczen, IdUczen)
    End If
  End Sub
  Private Sub txtSeek_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSeek.TextChanged
    Select Case Me.cbSeek.Text
      Case "Nazwisko i imię"
        Filter = "NazwiskoImie LIKE '" & Me.txtSeek.Text + "%'"
      Case "Klasa"
        Filter = "Klasa LIKE '" & Me.txtSeek.Text + "%'"
      Case "Nr ewidencyjny"
        If txtSeek.Text.Length > 0 Then
          Filter = "NrArkusza LIKE '" & Me.txtSeek.Text + "%'"
        Else
          Filter = "NrArkusza LIKE '" & Me.txtSeek.Text + "%' OR NrArkusza is null"
        End If
      Case "Data urodzenia"
        Filter = "DataUr LIKE '" & Me.txtSeek.Text + "%'"
      Case "Pesel"
        If txtSeek.Text = "brak" Then
          Filter = "Pesel is null or Pesel=''"
        Else
          Filter = "Pesel LIKE '" & Me.txtSeek.Text & "%'"
        End If
      Case "Obwód szkolny"
        If txtSeek.Text = "w" Then
          Filter = "ObwodSzkolny='1'"
        ElseIf txtSeek.Text = "i" Then
          Filter = "ObwodSzkolny='0'"
        Else
          Filter = "ObwodSzkolny LIKE '%'"
        End If
      Case "Miejsce urodzenia"
        Filter = "MiejsceUr LIKE '" & IIf(Me.txtSeek.Text.Trim.Length > 0, Me.txtSeek.Text & "%'", Me.txtSeek.Text & "%' OR Kraj IS NULL").ToString 'Me.txtSeek.Text & "%'"
      Case "Miejsce zamieszkania"
        Filter = "MiejsceZam LIKE '" & IIf(Me.txtSeek.Text.Trim.Length > 0, Me.txtSeek.Text & "%'", Me.txtSeek.Text & "%' OR Kraj IS NULL").ToString 'Me.txtSeek.Text & "%'"
      Case "Kraj urodzenia"
        Filter = "Kraj LIKE '" & IIf(Me.txtSeek.Text.Trim.Length > 0, Me.txtSeek.Text & "%'", Me.txtSeek.Text & "%' OR Kraj IS NULL").ToString
    End Select
    Me.EnableButtons(False)
    Me.RefreshData()
  End Sub

  Private Sub cbSeek_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSeek.SelectedIndexChanged
    Me.txtSeek.Text = ""
    Me.txtSeek.Focus()
  End Sub

  Private Sub nudStartYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudStartYear.ValueChanged
    If Not nudStartYear.Created Then Exit Sub
    Me.nudEndYear.Value = Me.nudStartYear.Value + 1
    If Not cbSzkola.SelectedItem Is Nothing Then
      Me.FetchData()
      RefreshData()
      Me.EnableButtons(False)
    End If
  End Sub

  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    Me.FetchData()
    RefreshData()
    nudStartYear.Enabled = True
    cbSeek.Enabled = True
    txtSeek.Enabled = True
    cmdAddNew.Enabled = True
    Me.EnableButtons(False)

  End Sub

  Private Sub chkVirtual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtual.CheckedChanged
    If Not cbSzkola.SelectedItem Is Nothing Then
      Me.FetchData()
      RefreshData()
      Me.EnableButtons(False)
    End If
  End Sub

  Private Sub cmdStrikeOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStrikeOut.Click
    If MessageBox.Show("Zaznaczeni uczniowie zostaną skreśleni z listy uczniów." & vbNewLine & "Czy kontynuować? Jeśli tak, to naciśnij przycisk 'OK'. W przeciwnym razie wciśnij przycisk 'Anuluj'.", My.Application.Info.ProductName, MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
      Dim S As New StudentSQL, DBA As New DataBaseAction, StrikeOutStudent As String = ""
      For Each Item As ListViewItem In Me.lvUczen.SelectedItems
        StrikeOutStudent = Item.Text
        DBA.ApplyChanges(S.StrikeoutStudent(Item.Text, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, Now.ToString()))
      Next
      Me.FetchData()
      Me.RefreshData()
      Dim SH As New SeekHelper
      Me.EnableButtons(False)
      SH.FindListViewItem(Me.lvUczen, StrikeOutStudent)
    End If
  End Sub

End Class

Public Class StudentSQL
  Public Function SelectStudents(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT u.ID,p.NrwDzienniku,u.NrArkusza,u.NrLegSzkol,Concat_WS(' ',u.Nazwisko,u.Imie1,u.Imie2) as NazwiskoImie,p.Klasa,CAST(u.DataUr AS CHAR) AS DataUr,u.Pesel,CAST(u.ObwodSzkolny AS CHAR) as ObwodSzkolny,u.Nazwisko,u.Imie1,u.Imie2,m.Nazwa as MiejsceZam,m1.Nazwa AS MiejsceUr,StatusAktywacji,k.Nazwa as Kraj FROM uczniowie u Left Join przydzial p on u.ID=p.IdUczen LEFT JOIN szkola_klasa sk on p.Klasa=sk.IdKlasa LEFT JOIN miejscowosc m ON u.IdMiejsceZam=m.ID LEFT JOIN miejscowosc m1 ON u.IdMiejsceUr=m1.ID LEFT JOIN kraj k ON m1.IdKraj=k.ID WHERE p.RokSzkolny='" & RokSzkolny & "' AND sk.IdSzkola='" & IdSzkola & "' AND sk.Virtual='" & Virtual & "' AND p.MasterRecord=1 ORDER BY p.Klasa,p.NrwDzienniku,u.Nazwisko COLLATE utf8_polish_ci,u.Imie1 COLLATE utf8_polish_ci,u.Imie2 COLLATE utf8_polish_ci;"
  End Function

  Public Function SelectDetails(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT u.ID,m.Nazwa as MiejsceUr,w.Nazwa as WojUr,Man,Niepelnosprawnosc,m1.Nazwa as MiejsceZam,u.Ulica,u.NrDomu,u.NrMieszkania,m1.Poczta,m1.KodPocztowy,w1.Nazwa as WojZam,m1.Miasto,u.Tel1,k.Nazwa as Kraj,u.TelKom1,u.TelKom2,u.ImieOjca,u.NazwiskoOjca,u.ImieMatki,u.NazwiskoMatki,u.Niepelnosprawnosc,u.User,u.ComputerIP, u.Version,m.ID as IdMiejsceUr,m1.ID as IdMiejsceZam FROM uczniowie u LEFT JOIN miejscowosc m on u.IdMiejsceUr=m.ID LEFT JOIN wojewodztwa w on m.IdWoj=w.KodWoj LEFT JOIN kraj k ON m.IdKraj=k.ID LEFT JOIN miejscowosc m1 on u.IdMiejsceZam=m1.ID LEFT JOIN wojewodztwa w1 on m1.IdWoj=w1.KodWoj Left JOIN przydzial p on u.ID=p.IdUczen LEFT JOIN szkola_klasa sk on p.Klasa=sk.IdKlasa WHERE p.RokSzkolny='" & RokSzkolny & "' AND sk.IdSzkola='" & IdSzkola & "' AND sk.Virtual='" & Virtual & "' AND p.MasterRecord=1;"
  End Function
  Public Function SelectWychowawca(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT Concat_WS(' ',b.Nazwisko,b.Imie),o.Klasa FROM obsada o,belfer b,przedmioty p,szkola_klasa sk WHERE o.IdBelfer=b.ID AND o.IdPrzedmiot=p.ID AND o.Klasa=sk.IdKlasa AND p.Typ='z' AND sk.IdSzkola='" & IdSzkola & "' AND sk.Virtual='" & Virtual & "' AND o.RokSzkolny='" & RokSzkolny & "';"
  End Function
  Public Function SelectStudentsID(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Klasa As String) As String
    Return "SELECT u.ID FROM uczniowie u, przydzial p WHERE u.ID=p.IdUczen AND p.RokSzkolny='" & RokSzkolny & "' AND p.Klasa IN (SELECT IdKlasa FROM szkola_klasa WHERE IdSzkola='" & IdSzkola & "' AND IdKlasa='" & Klasa & "') AND p.StatusAktywacji='1' ORDER BY u.Nazwisko,u.Imie1,u.Imie2;"
  End Function
  Public Function SelectRepeaters(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    'Return "SELECT distinct p.IdUczen FROM przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & IdSzkola & "' AND LEFT(p.RokSzkolny,4)<" & RokSzkolny & " AND sk.Virtual='" & Virtual & "' AND p.Promocja='0' AND p.StatusAktywacji='1';"
    Return "SELECT distinct p.IdUczen FROM przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & IdSzkola & "' AND LEFT(p.RokSzkolny,4)='" & RokSzkolny & "' AND sk.Virtual='" & Virtual & "' AND p.StatusAktywacji='1' AND p.IdUczen IN (SELECT DISTINCT IdUczen FROM przydzial WHERE LEFT(RokSzkolny,4)='" & CType(RokSzkolny, Integer) - 1 & "' AND Promocja='0' AND StatusAktywacji='1');"
  End Function
  Public Function SelectMaxNrDz(ByVal IdSchool As String, ByVal Klasa As String, ByVal RokSzkolny As String) As String
    Return "Select Max(p.NrwDzienniku) FROM przydzial p Where p.RokSzkolny='" & RokSzkolny & "' AND Klasa IN (Select IdKlasa From szkola_klasa WHERE IdSzkola='" & IdSchool & "' AND IdKlasa='" & Klasa & "');"
  End Function
  Public Function DeleteStudent(ByVal ID As String) As String
    Return "DELETE FROM uczniowie WHERE ID='" & ID & "';"
  End Function
  Public Function StrikeoutStudent(ByVal IdUczen As String, ByVal RokSzkolny As String, ByVal DataDeaktywacji As String) As String
    Return "UPDATE przydzial p SET p.StatusAktywacji=0,p.DataDeaktywacji='" & DataDeaktywacji & "',User='" + GlobalValues.gblUserName + "',ComputerIP='" + GlobalValues.gblIP + "',Version=NULL WHERE p.IdUczen=" & IdUczen & " AND p.RokSzkolny='" & RokSzkolny & "' AND p.MasterRecord=1;"
  End Function
  Public Function InsertStudent() As String
    Return "INSERT INTO uczniowie VALUES(null,?Nazwisko,?Imie1,?Imie2,?NrArkusza,?NrLegSzkol,?DataUr,?IdMiejsceUr,?IdMiejsceZam,?Ulica,?NrDomu,?NrMieszkania,?Tel1,?Tel2,?TelKom1,?TelKom2,?ImieOjca,?NazwiskoOjca,?ImieMatki,?NazwiskoMatki,?Man,?Pesel,?ObwodSzkolny,?Niepelnosprawnosc,'" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  Public Function InsertPrzydzial() As String
    Return "INSERT INTO przydzial VALUES(NULL,?IdUczen,?Klasa,?RokSzkolny,NULL,0,1,'" & Now.ToString() & "',NULL,1,'" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  Public Function UpdateStudent(ByVal IdUczen As String) As String
    Return "UPDATE uczniowie SET Nazwisko=?Nazwisko,Imie1=?Imie1,Imie2=?Imie2,NrArkusza=?NrArkusza,NrLegSzkol=?NrLegSzkol,DataUr=?DataUr,IdMIejsceUr=?IdMiejsceUr,IdMIejsceZam=?IdMiejsceZam,Ulica=?Ulica,NrDomu=?NrDomu,NrMieszkania=?NrMieszkania,Tel1=?Tel1,Tel2=?Tel2,TelKom1=?TelKom1,TelKom2=?TelKom2,ImieOjca=?ImieOjca,NazwiskoOjca=?NazwiskoOjca,ImieMatki=?ImieMatki,NazwiskoMatki=?NazwiskoMatki,Man=?Man,Pesel=?Pesel,ObwodSzkolny=?ObwodSzkolny,Niepelnosprawnosc=?Niepelnosprawnosc,User='" + GlobalValues.gblUserName + "',ComputerIP='" + GlobalValues.gblIP + "',Version=NULL WHERE ID='" & IdUczen & "';"
  End Function
  Public Overloads Function UpdatePrzydzial(ByVal IdUczen As String, ByVal RokSzkolny As String) As String
    Return "UPDATE przydzial SET StatusAktywacji='0',DataDeaktywacji='" & Now.ToString() & "',MasterRecord=0,User='" + GlobalValues.gblUserName + "',ComputerIP='" + GlobalValues.gblIP + "',Version=NULL WHERE IdUczen='" & IdUczen & "' AND RokSzkolny='" & RokSzkolny & "';"
  End Function
  Public Overloads Function UpdatePrzydzial(ByVal IdUczen As String, ByVal Klasa As String, ByVal RokSzkolny As String) As String
    Return "UPDATE przydzial p SET p.StatusAktywacji='1',MasterRecord=1,p.User='" + GlobalValues.gblUserName + "',p.ComputerIP='" + GlobalValues.gblIP + "',p.Version=NULL  WHERE p.IdUczen='" & IdUczen & "' AND p.Klasa='" & Klasa & "' AND p.RokSzkolny='" & RokSzkolny & "' AND p.StatusAktywacji=0;"
  End Function
  Public Function UpdateNrDz(ByVal Nr As String, ByVal IdUczen As String, ByVal RokSzkolny As String) As String
    Return "UPDATE przydzial SET NrwDzienniku='" & Nr & "' Where IdUczen='" & IdUczen & "' AND RokSzkolny='" & RokSzkolny & "' AND StatusAktywacji='1';"
  End Function
End Class
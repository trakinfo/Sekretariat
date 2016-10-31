Public Class frmSzkola
  Private DT As DataTable
  Private Sub ListViewConfig(ByVal lv As ListView)
    With lv
      .View = View.Details
      .FullRowSelect = True
      .GridLines = True
      .MultiSelect = True
      .AllowColumnReorder = False
      .AutoResizeColumns(0)
      .HideSelection = False
      AddColumns()
      .Items.Clear()
      .Enabled = True
    End With
  End Sub
  Private Sub AddColumns()
    With lvSzkoly
      .Columns.Add("ID", 0, HorizontalAlignment.Center)
      .Columns.Add("Nazwa", 200, HorizontalAlignment.Left)
      .Columns.Add("Adres", 200, HorizontalAlignment.Left)
      .Columns.Add("NIP", 100, HorizontalAlignment.Center)
      .Columns.Add("Domyślna", 50, HorizontalAlignment.Center)
    End With
  End Sub
  Private Sub frmKlasa_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    SharedSchool.CloseChildren(Me, e)
  End Sub
  Private Sub frmSzkola_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    SharedSchool.CloseChildren(Me, e)
  End Sub

  Private Sub frmSzkola_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ListViewConfig(lvSzkoly)
    ClearDetails()
    GetData()
  End Sub
  Private Sub GetData()
    Dim DBA As New DataBaseAction, S As New SzkolaSQL
    'Dim Dr As DataRow
    DT = DBA.GetDataTable(S.SelectSchools)
    Try
      lvSzkoly.Items.Clear()
      For Each Dr As DataRow In DT.Rows
        lvSzkoly.Items.Add(Dr.Item(0).ToString)
        For i As Byte = 1 To 4
          lvSzkoly.Items(lvSzkoly.Items.Count - 1).SubItems.Add(Dr.Item(i).ToString)
        Next
      Next
      If lvSzkoly.Items.Count > 0 Then
        lvSzkoly.Enabled = True
        'lvSzkoly.Focus()
        'lvSzkoly.Items(0).Selected = True
      Else
        lvSzkoly.Enabled = False
      End If
      lvSzkoly.Columns(1).Width = CInt(IIf(lvSzkoly.Items.Count > 12, 184, 200))
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub
  Private Sub GetDetails()
    Dim FoundRow() As DataRow
    Try
      FoundRow = DT.Select("ID=" & lvSzkoly.SelectedItems(0).Text)
      With FoundRow(0)
        Me.lblAlias.Text = .Item(5).ToString
        lblOrgan.Text = .Item(6).ToString
        lblTel.Text = .Item(7).ToString
        lblFax.Text = .Item(8).ToString
        lblEmail.Text = .Item(9).ToString
        Me.lblOkeID.Text = .Item(10).ToString
        lblUser.Text = .Item(11).ToString
        lblIP.Text = .Item(12).ToString
        lblData.Text = .Item(13).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub
  Private Sub ClearDetails()
    lblRecord.Text = "0 z " & lvSzkoly.Items.Count
    lblAlias.Text = ""
    lblOrgan.Text = ""
    lblTel.Text = ""
    lblFax.Text = ""
    lblEmail.Text = ""
    lblOkeID.Text = ""

    Me.lblUser.Text = ""
    Me.lblData.Text = ""
    Me.lblIP.Text = ""
  End Sub

  Private Sub lvSzkoly_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Me.EditData()
  End Sub
  Private Sub lvSzkoly_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvSzkoly.ItemSelectionChanged
    'If e.IsSelected Then Me.GetDetails()
    Me.ClearDetails()
    If e.IsSelected Then
      GetDetails()
      EnableButtons(True)
    Else
      EnableButtons(False)
    End If
  End Sub
  Private Sub EnableButtons(ByVal Value As Boolean)
    Me.cmdDelete.Enabled = Value
    Me.cmdEdit.Enabled = Value
  End Sub
  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Dispose(True)
  End Sub
  Private Sub EditData()
    Dim dlgEdit As New dlgSzkola, FCB As New FillComboBox
    With dlgEdit
      .InRefresh = True
      FCB.AddComboBoxComplexItems(dlgEdit.cbMiejscowosc, "Select m.ID,concat_WS(' ',m.Nazwa,'{',w.Nazwa,'}') as Nazwa From miejscowosc m left Join wojewodztwa w on m.IdWoj=w.KodWoj Order by m.Nazwa Collate UTF8_polish_ci;")
      dlgEdit.cbMiejscowosc.AutoCompleteSource = AutoCompleteSource.ListItems
      dlgEdit.cbMiejscowosc.AutoCompleteMode = AutoCompleteMode.Append

      FCB.AddComboBoxComplexItems(dlgEdit.cbOrgan, "Select ID,Nazwa From organ_prowadz Order by Nazwa Collate UTF8_polish_ci;")
      dlgEdit.cbOrgan.AutoCompleteSource = AutoCompleteSource.ListItems
      dlgEdit.cbOrgan.AutoCompleteMode = AutoCompleteMode.Append

      .Text = "Edycja danych szkoły"
      .txtNazwa.Text = Me.lvSzkoly.SelectedItems(0).SubItems(1).Text
      .chkIsDefault.Checked = CType(IIf(Me.lvSzkoly.SelectedItems(0).SubItems(4).Text = "True", True, False), Boolean)
      .txtAlias.Text = Me.lblAlias.Text
      .txtNip.Text = Me.lvSzkoly.SelectedItems(0).SubItems(3).Text
      .txtTel.Text = lblTel.Text
      .txtFax.Text = Me.lblFax.Text
      .txtEmail.Text = lblEmail.Text
      Dim SH As New SeekHelper
      If DT.Select("ID=" & Me.lvSzkoly.SelectedItems(0).Text)(0).Item(14).ToString.Length > 0 Then SH.FindComboItem(.cbMiejscowosc, CType(DT.Select("ID=" & Me.lvSzkoly.SelectedItems(0).Text)(0).Item(17), Integer))

      If lblOrgan.Text.Length > 0 Then SH.FindComboItem(.cbOrgan, CType(DT.Select("ID=" & Me.lvSzkoly.SelectedItems(0).Text)(0).Item(18), Integer))

      .txtUlica.Text = DT.Select("ID=" & Me.lvSzkoly.SelectedItems(0).Text)(0).Item(15).ToString
      .txtNr.Text = DT.Select("ID=" & Me.lvSzkoly.SelectedItems(0).Text)(0).Item(16).ToString
      .txtOKEID.Text = Me.lblOkeID.Text
      '.Icon = gblAppIcon
      .InRefresh = False
      If dlgEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim DBA As New DataBaseAction, S As New SzkolaSQL, IDSzkola As String
        Dim MySQLTrans As MySqlTransaction

        IDSzkola = Me.lvSzkoly.SelectedItems(0).Text
        Dim cmd As MySqlCommand = DBA.CreateCommand(S.UpdateSchool(IDSzkola))
        MySQLTrans = GlobalValues.gblConn.BeginTransaction()
        cmd.Transaction = MySQLTrans
        Try
          cmd.Parameters.AddWithValue("?Nazwa", .txtNazwa.Text.Trim)
          cmd.Parameters.AddWithValue("?Alias", .txtAlias.Text.Trim)
          cmd.Parameters.AddWithValue("?Nip", .txtNip.Text.Trim)
          If .txtOKEID.Text.Trim.Length > 0 Then
            cmd.Parameters.AddWithValue("?OkeID", .txtOKEID.Text.Trim)
          Else
            cmd.Parameters.AddWithValue("?OkeID", DBNull.Value)

          End If
          cmd.Parameters.AddWithValue("?Ulica", .txtUlica.Text.Trim)
          cmd.Parameters.AddWithValue("?Nr", .txtNr.Text.Trim)
          If .cbMiejscowosc.SelectedItem IsNot Nothing Then
            cmd.Parameters.AddWithValue("?IdMiejscowosc", CType(.cbMiejscowosc.SelectedItem, CbItem).ID.ToString)
          Else
            cmd.Parameters.AddWithValue("?IdMiejscowosc", DBNull.Value)
          End If
          'cmd.Parameters.AddWithValue("?IdMiejscowosc", CType(.cbMiejscowosc.SelectedItem, CbItem).ID.ToString)
          cmd.Parameters.AddWithValue("?Tel", .txtTel.Text.Trim)
          cmd.Parameters.AddWithValue("?Fax", .txtFax.Text.Trim)
          cmd.Parameters.AddWithValue("?Email", .txtEmail.Text.Trim)
          If .cbOrgan.SelectedItem IsNot Nothing Then
            cmd.Parameters.AddWithValue("?IdOrgan", CType(.cbOrgan.SelectedItem, CbItem).ID.ToString)
          Else
            cmd.Parameters.AddWithValue("?IdOrgan", DBNull.Value)

          End If

          cmd.ExecuteNonQuery()
          If CType(IIf(lvSzkoly.SelectedItems(0).SubItems(4).Text = "True", True, False), Boolean) <> .chkIsDefault.Checked Then
            cmd.CommandText = S.SetDefault
            cmd.ExecuteNonQuery()
            cmd.CommandText = S.SetDefault(CType(.chkIsDefault.CheckState, Integer), IDSzkola)
            cmd.ExecuteNonQuery()
          End If
          MySQLTrans.Commit()

        Catch ex As MySqlException
          MessageBox.Show(ex.Message)
          MySQLTrans.Rollback()
        End Try
        RefreshData()
        'lvSzkoly.Items.Clear()
        'GetData()
        Me.EnableButtons(False)
        'Dim SH As New SeekHelper
        SH.FindListViewItem(Me.lvSzkoly, IDSzkola)
      End If
    End With
  End Sub

  Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
    Dim dlgAddNew As New dlgSzkola, FCB As New FillComboBox
    FCB.AddComboBoxComplexItems(dlgAddNew.cbMiejscowosc, "Select m.ID,concat_WS(' ',m.Nazwa,'{',w.Nazwa,'}') as Nazwa From miejscowosc m left Join wojewodztwa w on m.IdWoj=w.KodWoj Order by m.Nazwa Collate UTF8_polish_ci;")
    dlgAddNew.cbMiejscowosc.AutoCompleteSource = AutoCompleteSource.ListItems
    dlgAddNew.cbMiejscowosc.AutoCompleteMode = AutoCompleteMode.Append

    FCB.AddComboBoxComplexItems(dlgAddNew.cbOrgan, "Select ID,Nazwa From organ_prowadz Order by Nazwa Collate UTF8_polish_ci;")
    dlgAddNew.cbOrgan.AutoCompleteSource = AutoCompleteSource.ListItems
    dlgAddNew.cbOrgan.AutoCompleteMode = AutoCompleteMode.Append

    dlgAddNew.Text = "Dodawanie nowej szkoły"
    AddHandler dlgAddNew.NewAdded, AddressOf NewSchoolAdded
    AddHandler dlgAddNew.FormClosed, AddressOf EnableCmdAddNew
    AddHandler SharedSchool.OnOwnerClose, AddressOf dlgAddNew.Cancel_Button_Click
    dlgAddNew.MdiParent = Me.MdiParent
    dlgAddNew.Show()
    dlgAddNew.txtNazwa.Focus()
    Me.cmdAddNew.Enabled = False
  End Sub
  Private Sub NewSchoolAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedID As String)
    Me.GetData()
    If Not lvSzkoly.FindItemWithText(InsertedID) Is Nothing Then
      lvSzkoly.Focus()
      lvSzkoly.Items(lvSzkoly.FindItemWithText(InsertedID).Index).Selected = True
    End If
  End Sub
  Private Sub EnableCmdAddNew(ByVal sender As Object, ByVal e As FormClosedEventArgs)
    Me.cmdAddNew.Enabled = True
  End Sub
  Private Sub RefreshData()
    lvSzkoly.Items.Clear()
    ClearDetails()
    GetData()
  End Sub
  Private Sub lvWoj_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSzkoly.DoubleClick
    EditData()
  End Sub
  Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
    Me.EditData()
  End Sub

  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    Dim DBA As New DataBaseAction, DeletedIndex As Integer, S As New SzkolaSQL
    Try
      For Each Item As ListViewItem In Me.lvSzkoly.SelectedItems
        DeletedIndex = Item.Index
        DBA.ApplyChanges(S.DeleteSchool(Item.Text))
      Next
      Me.EnableButtons(False)
      RefreshData()
      Dim SH As New SeekHelper
      SH.FindRemovedListViewItemIndex(Me.lvSzkoly, DeletedIndex)
    Catch mex As MySqlException
      MessageBox.Show(mex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)

    End Try
  End Sub
End Class

Public Class SzkolaSQL
  Public Function SelectSchools() As String
    Return "SELECT s.ID,s.Nazwa,TRIM(CONCAT_WS(' ',IFNULL(TRIM(TRAILING ', ' FROM Concat_WS(', ',m.Nazwa,s.Ulica)),''),s.Nr)) AS Adres,s.NIP,s.IsDefault,s.Alias,o.Nazwa,s.Tel,s.Fax,s.Email,s.OkeID,s.User,s.ComputerIP,s.Version,m.Nazwa,s.Ulica,s.Nr,m.ID,o.ID FROM szkoly s LEFT JOIN miejscowosc m ON s.IdMiejscowosc=m.ID LEFT JOIN organ_prowadz o ON s.IdOrgan=o.ID ORDER BY s.Nazwa COLLATE UTF8_polish_ci;"
  End Function
  Public Function UpdateSchool(ByVal IdSchool As String) As String
    Return "UPDATE szkoly SET Nazwa=?Nazwa,Alias=?Alias,Nip=?Nip,OkeID=?OkeID,Ulica=?Ulica,Nr=?Nr,IdMiejscowosc=?IdMiejscowosc,Tel=?Tel,Fax=?Fax,Email=?Email,IdOrgan=?IdOrgan,User='" & GlobalValues.gblUserName & "',ComputerIP='" & GlobalValues.gblIP & "',Version=NULL WHERE ID=" & IdSchool & ";"
  End Function
  Public Function InsertSchool() As String
    Return "INSERT INTO szkoly VALUES(NULL,?Nazwa,?Alias,?Nip,?OkeID,?Ulica,?Nr,?IdMiejscowosc,?Tel,?Fax,?Email,0,?IdOrgan,'" & GlobalValues.gblUserName & "','" & GlobalValues.gblIP & "',NULL);"
  End Function
  Public Function DeleteSchool(ByVal IdSchool As String) As String
    Return "Delete From szkoly Where ID=" & IdSchool & ";"
  End Function
  Public Function SetDefault() As String
    Return "UPDATE szkoly SET IsDefault=false;"
  End Function
  Public Function SetDefault(ByVal IsDefault As Integer, ByVal ID As String) As String
    Return "UPDATE szkoly SET IsDefault=" & IsDefault & " WHERE ID='" & ID & "';"
  End Function
End Class
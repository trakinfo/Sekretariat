Public Class frmUsers
  Private dtUsers As DataTable
  Public Sub AddUser()
    Dim HashHelper As New HashHelper, DBA As New DataBaseAction, U As New UsersSQL, dlgAddNew As New dlgUser
    Try
      If dlgAddNew.ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim SaltedPasswordHash As Byte()
        SaltedPasswordHash = HashHelper.CreateDBPassword(dlgAddNew.txtPassword.Text)
        Dim cmd As MySqlCommand = DBA.CreateCommand(U.InsertUser(dlgAddNew.txtNazwa.Text, CType(dlgAddNew.chkAdministrator.CheckState, Integer).ToString))
        'Dim cmd As MySqlCommand = DBA.CreateCommand(U.InsertUser(dlgAddNew.txtNazwa.Text, IIf(dlgAddNew.chkAdministrator.Checked, 1, 0).ToString))
        cmd.Parameters.AddWithValue("?Password", SaltedPasswordHash)
        cmd.ExecuteNonQuery()
        Me.lvUsers.Items.Clear()
        Me.GetData()
        Dim SH As New SeekHelper
        SH.FindListViewItem(Me.lvUsers, DBA.GetLastInsertedID)
      End If
    Catch err As MySqlException
      Select Case err.Number
        Case 1062
          MessageBox.Show("Podany użytkownik już istnieje." + vbNewLine + "Spróbuj innej nazwy.")
        Case Else
          MessageBox.Show(err.Message + vbNewLine + "Numer błędu: " + err.Number.ToString)
      End Select
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Close()
  End Sub

  Private Sub cmdAddNewUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNewUser.Click
    Me.AddUser()
  End Sub

  Private Sub frmUsers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.ListViewConfig(Me.lvUsers)
    Me.GetData()
  End Sub
  Private Sub ListViewConfig(ByVal lv As ListView)
    With lv
      .View = View.Details
      .FullRowSelect = True
      .GridLines = True
      .MultiSelect = True
      .AllowColumnReorder = False
      .AutoResizeColumns(0)
      .HideSelection = False
      '.HoverSelection = True
      .HeaderStyle = ColumnHeaderStyle.Nonclickable
      AddColumns(lv)
      .Items.Clear()
      .Enabled = False
    End With
  End Sub
  Private Sub AddColumns(ByVal lv As ListView)
    With lv
      .Columns.Add("Login", 230, HorizontalAlignment.Left)
      .Columns.Add("Admin", 120, HorizontalAlignment.Center)
    End With
  End Sub


  Private Sub GetData()
    Dim DBA As New DataBaseAction, U As New UsersSQL
    dtUsers = DBA.GetDataTable(U.SelectUsers)
    For Each row As DataRow In dtUsers.Rows
      Me.lvUsers.Items.Add(row.Item(0).ToString)
      Me.lvUsers.Items(Me.lvUsers.Items.Count - 1).SubItems.Add(row.Item(1).ToString)
      'Me.lvUsers.Items(Me.lvUsers.Items.Count - 1).SubItems.Add(row.Item(2).ToString)
    Next

    lvUsers.Columns(1).Width = CInt(IIf(lvUsers.Items.Count > 16, 101, 120))
    Me.lvUsers.Enabled = CType(IIf(Me.lvUsers.Items.Count > 0, True, False), Boolean)

  End Sub
  Private Sub GetDetails(ByVal Name As String)
    Try
      With dtUsers.Select("Login='" & Name & "'")(0)
        lblUser.Text = .Item(2).ToString
        lblIP.Text = .Item(3).ToString
        lblData.Text = .Item(4).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub

  Private Sub lvUsers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvUsers.DoubleClick
    Me.EditData()
  End Sub

  Private Sub lvUsers_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvUsers.ItemSelectionChanged
    Me.ClearDetails()
    If e.IsSelected Then
      GetDetails(e.Item.Text)
      EnableButtons(True)
    Else
      EnableButtons(False)
    End If
  End Sub
  Private Sub EnableButtons(ByVal Value As Boolean)
    Me.cmdDelete.Enabled = Value
    Me.cmdEdit.Enabled = Value
  End Sub
  Private Sub ClearDetails()
    Me.lblUser.Text = ""
    Me.lblData.Text = ""
    Me.lblIP.Text = ""
  End Sub
  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    Dim DBA As New DataBaseAction, DeletedIndex As Integer, U As New UsersSQL
    For Each Item As ListViewItem In Me.lvUsers.SelectedItems
      DeletedIndex = Item.Index
      DBA.ApplyChanges(U.DeleteUser(Item.Text))
    Next
    Me.EnableButtons(False)
    lvUsers.Items.Clear()
    Me.GetData()
    Dim SH As New SeekHelper
    SH.FindRemovedListViewItemIndex(Me.lvUsers, DeletedIndex)
  End Sub

  Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
    Me.EditData()
  End Sub
  Private Sub EditData()
    Dim dlgEdit As New dlgUser
    Try
      With dlgEdit
        .Text = "Edycja danych użytkownika"
        .txtNazwa.Text = Me.lvUsers.SelectedItems(0).Text
        .lblPassword.Enabled = False
        .lblPassword2.Enabled = False
        .txtPassword.Enabled = False
        .txtPassword1.Enabled = False
        .OK_Button.Text = "Zapisz"
        .chkAdministrator.Checked = CType(Me.lvUsers.SelectedItems(0).SubItems(1).Text, Boolean)
        '.Icon = gblAppIcon
        If dlgEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
          Dim DBA As New DataBaseAction, IdUser As String
          IdUser = Me.lvUsers.SelectedItems(0).Text
          DBA.ApplyChanges("UPDATE user SET Login='" + .txtNazwa.Text + "',Administrator='" + IIf(.chkAdministrator.Checked, 1, 0).ToString + "',User='" & GlobalValues.gblUserName & "',ComputerIP='" & GlobalValues.gblIP & "',Version=NULL Where Login='" + IdUser + "';")
          Me.lvUsers.Items.Clear()
          Me.GetData()

          Dim SH As New SeekHelper
          SH.FindListViewItem(Me.lvUsers, IdUser)
        End If
      End With
    Catch err As MySqlException
      Select Case err.Number
        Case 1062
          MessageBox.Show("Podany użytkownik już istnieje." + vbNewLine + "Spróbuj innej nazwy.")
        Case Else
          MessageBox.Show(err.Message + vbNewLine + "Numer błędu: " + err.Number.ToString)
      End Select
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

End Class


Public Class UsersSQL
  Public Function SelectUsers() As String
    Return "SELECT u.`Login`, u.`Administrator`, u.`User`, u.`ComputerIP`, u.`Version` FROM `user` u WHERE u.Login<>'admin';"
  End Function
  Public Function InsertUser(ByVal Login As String, ByVal Administrator As String) As String
    Return "INSERT INTO user (Login,UserPassword,Administrator,User,ComputerIP,Version) VALUES ('" + Login + "',?Password ,'" + Administrator + "','" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  Public Function DeleteUser(ByVal Name As String) As String
    Return "DELETE FROM user WHERE Login='" + Name + "';"
  End Function
  Public Function UpdatePassword(ByVal Name As String) As String
    Return "UPDATE user SET UserPassword=?Password WHERE Login='" & Name & "';"
  End Function
  'Public Function UpdateUser(ByVal Name As String) As String
  '  Return "UPDATE user SET Login=?Login, Administrator=?Admin WHERE Login='" + Name + "';"
  'End Function
End Class
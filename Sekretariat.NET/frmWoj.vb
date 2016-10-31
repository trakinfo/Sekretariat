Public Class frmWoj
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
      '.HoverSelection = True
      .HeaderStyle = ColumnHeaderStyle.Nonclickable
      AddColumns(lv)
      .Items.Clear()
      .Enabled = False
    End With
  End Sub
  Private Sub AddColumns(ByVal lv As ListView)
    With lv
      .Columns.Add("KodWoj", 50, HorizontalAlignment.Left)
      .Columns.Add("Nazwa", 200, HorizontalAlignment.Left)
      .Columns.Add("Domyślne", 50, HorizontalAlignment.Center)
    End With
  End Sub

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Close()
  End Sub

  Private Sub frmKlasa_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    SharedWoj.CloseChildren(Me, e)
  End Sub

  Private Sub frmKlasa_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    SharedWoj.CloseChildren(Me, e)
  End Sub
  Private Sub EnableCmdAddNew(ByVal sender As Object, ByVal e As FormClosedEventArgs)
    Me.cmdAddNew.Enabled = True
  End Sub
  Private Sub frmKlasa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.ListViewConfig(Me.lvWoj)
    Me.GetData()
    lblRecord.Text = "0 z " & lvWoj.Items.Count
  End Sub
  Private Sub GetData()
    Dim DBA As New DataBaseAction, W As New WojSQL
    DT = DBA.GetDataTable(W.SelectWoj)
    For Each row As DataRow In DT.Rows
      Me.lvWoj.Items.Add(row.Item(0).ToString)
      Me.lvWoj.Items(Me.lvWoj.Items.Count - 1).SubItems.Add(row.Item(1).ToString)
      Me.lvWoj.Items(Me.lvWoj.Items.Count - 1).SubItems.Add(row.Item(2).ToString)
    Next

    lvWoj.Columns(1).Width = CInt(IIf(lvWoj.Items.Count > 15, 179, 200))
    Me.lvWoj.Enabled = CType(IIf(Me.lvWoj.Items.Count > 0, True, False), Boolean)

  End Sub
  Private Sub GetDetails(ByVal Name As String)
    Try
      lblRecord.Text = lvWoj.SelectedItems(0).Index + 1 & " z " & lvWoj.Items.Count
      With DT.Select("KodWoj='" & Name & "'")(0)
        lblUser.Text = .Item(3).ToString
        lblIP.Text = .Item(4).ToString
        lblData.Text = .Item(5).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub

  Private Sub lvWoj_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvWoj.DoubleClick
    EditData()
  End Sub

  Private Sub lvKlasa_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvWoj.ItemSelectionChanged
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
    lblRecord.Text = "0 z " & lvWoj.Items.Count
    Me.lblUser.Text = ""
    Me.lblData.Text = ""
    Me.lblIP.Text = ""
  End Sub

  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    Dim DBA As New DataBaseAction, DeletedIndex As Integer, W As New WojSQL
    Try
      For Each Item As ListViewItem In Me.lvWoj.SelectedItems
        DeletedIndex = Item.Index
        DBA.ApplyChanges(W.DeleteWoj(Item.Text))
      Next
      Me.EnableButtons(False)
      lvWoj.Items.Clear()
      Me.GetData()
      Dim SH As New SeekHelper
      SH.FindRemovedListViewItemIndex(Me.lvWoj, DeletedIndex)
    Catch mex As MySqlException
      MessageBox.Show(mex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)

    End Try
  End Sub
  Public Sub AddKlasa()
    Dim dlgAddNew As New dlgWoj
    dlgAddNew.Text = "Dodawanie nowego województwa"

    dlgAddNew.MdiParent = Me.MdiParent
    dlgAddNew.MaximizeBox = False
    dlgAddNew.StartPosition = FormStartPosition.CenterScreen
    'dlgAddNew.Opacity = 0.7
    dlgAddNew.Show()
    dlgAddNew.txtKodWoj.Focus()
    AddHandler dlgAddNew.NewAdded, AddressOf NewAdded
    AddHandler dlgAddNew.FormClosed, AddressOf EnableCmdAddNew
    Me.cmdAddNew.Enabled = False
  End Sub
  Private Sub NewAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedID As String)
    lvWoj.Items.Clear()
    GetData()
    Dim SH As New SeekHelper
    SH.FindListViewItem(Me.lvWoj, InsertedID)
  End Sub
  Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
    AddKlasa()
  End Sub

  Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
    EditData()
  End Sub
  Private Sub EditData()
    Try
      Dim dlgEdit As New dlgWoj

      With dlgEdit
        .InRefresh = True
        .Text = "Edycja województwa"
        '.MdiParent = Me.MdiParent
        .txtKodWoj.Text = Me.lvWoj.SelectedItems(0).Text
        .txtNazwaWoj.Text = Me.lvWoj.SelectedItems(0).SubItems(1).Text
        .chkIsDefault.Checked = CType(IIf(lvWoj.SelectedItems(0).SubItems(2).Text = "True", True, False), Boolean)
        .InRefresh = False
        .Icon = GlobalValues.gblAppIcon
        .MinimizeBox = False
        .MaximizeBox = False

        If dlgEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
          Dim DBA As New DataBaseAction, W As New WojSQL, KodWoj As String
          Dim MySQLTrans As MySqlTransaction

          KodWoj = Me.lvWoj.SelectedItems(0).Text
          Dim cmd As MySqlCommand = DBA.CreateCommand(W.UpdateWoj(KodWoj))
          MySQLTrans = GlobalValues.gblConn.BeginTransaction()
          cmd.Transaction = MySQLTrans
          Try
            cmd.Parameters.AddWithValue("?KodWoj", .txtKodWoj.Text.Trim)
            cmd.Parameters.AddWithValue("?Nazwa", .txtNazwaWoj.Text.Trim)
            'cmd.Parameters.AddWithValue("?IsDefault", CType(.chkIsDefault.CheckState, Integer).ToString)

            cmd.ExecuteNonQuery()
            If CType(IIf(lvWoj.SelectedItems(0).SubItems(2).Text = "True", True, False), Boolean) <> .chkIsDefault.Checked Then
              cmd.CommandText = W.SetDefault
              cmd.ExecuteNonQuery()
              cmd.CommandText = W.SetDefault(CType(.chkIsDefault.CheckState, Integer), .txtKodWoj.Text)
              cmd.ExecuteNonQuery()
            End If
            MySQLTrans.Commit()

          Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            MySQLTrans.Rollback()
          End Try
          lvWoj.Items.Clear()
          GetData()
          Me.EnableButtons(False)
          Dim SH As New SeekHelper
          SH.FindListViewItem(Me.lvWoj, KodWoj)
        End If
      End With
    Catch ex As Exception

      MessageBox.Show(ex.Message)
    End Try

  End Sub
End Class

Public Class WojSQL
  Public Function SelectWoj() As String
    Return "SELECT KodWoj,Nazwa,IsDefault,User,ComputerIP,Version FROM wojewodztwa;"
  End Function
  Public Function DeleteWoj(ByVal KodWoj As String) As String
    Return "DELETE FROM wojewodztwa WHERE KodWoj='" & KodWoj & "';"
  End Function
  Public Function InsertWoj() As String
    Return "INSERT INTO wojewodztwa(KodWoj,Nazwa,User,ComputerIP,Version) VALUES(?KodWoj,?Nazwa,'" & GlobalValues.gblUserName & "','" & GlobalValues.gblIP & "',NULL);"
  End Function
  Public Function UpdateWoj(ByVal KodWoj As String) As String
    Return "UPDATE wojewodztwa SET KodWoj=?KodWoj,Nazwa=?Nazwa,User='" + GlobalValues.gblUserName + "',ComputerIP='" + GlobalValues.gblIP + "',Version=NULL WHERE KodWoj='" & KodWoj & "';"
  End Function
  Public Function SetDefault(ByVal IsDefault As Integer, ByVal KodWoj As String) As String
    Return "UPDATE wojewodztwa SET IsDefault=" & IsDefault & " WHERE KodWoj='" & KodWoj & "';"
  End Function
  Public Function SetDefault() As String
    Return "UPDATE wojewodztwa SET IsDefault=false;"
  End Function
End Class
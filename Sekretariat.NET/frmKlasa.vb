Public Class frmKlasa
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
      .Columns.Add("Kod", 0, HorizontalAlignment.Left)
      .Columns.Add("Nazwa", 187, HorizontalAlignment.Center)
    End With
  End Sub

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Close()
  End Sub

  Private Sub frmKlasa_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    SharedKlasa.CloseChildren(Me, e)
  End Sub

  Private Sub frmKlasa_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    SharedKlasa.CloseChildren(Me, e)
  End Sub
  Private Sub EnableCmdAddNew(ByVal sender As Object, ByVal e As FormClosedEventArgs)
    Me.cmdAddNew.Enabled = True
  End Sub
  Private Sub frmKlasa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.ListViewConfig(Me.lvKlasa)
    Me.GetData()
    lblRecord.Text = "0 z " & lvKlasa.Items.Count
  End Sub
  Private Sub GetData()
    Dim DBA As New DataBaseAction, K As New KlasaSQL
    DT = DBA.GetDataTable(K.SelectKlasa)
    For Each row As DataRow In DT.Rows
      Me.lvKlasa.Items.Add(row.Item(0).ToString)
      Me.lvKlasa.Items(Me.lvKlasa.Items.Count - 1).SubItems.Add(row.Item(0).ToString)
      'Me.lvUsers.Items(Me.lvUsers.Items.Count - 1).SubItems.Add(row.Item(2).ToString)
    Next

    lvKlasa.Columns(1).Width = CInt(IIf(lvKlasa.Items.Count > 15, 166, 187))
    Me.lvKlasa.Enabled = CType(IIf(Me.lvKlasa.Items.Count > 0, True, False), Boolean)

  End Sub
  Private Sub GetDetails(ByVal Name As String)
    Try
      lblRecord.Text = lvKlasa.SelectedItems(0).Index + 1 & " z " & lvKlasa.Items.Count
      With DT.Select("Klasa='" & Name & "'")(0)
        lblUser.Text = .Item(1).ToString
        lblIP.Text = .Item(2).ToString
        lblData.Text = .Item(3).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub

  Private Sub lvKlasa_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvKlasa.ItemSelectionChanged
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
    'Me.cmdEdit.Enabled = Value
  End Sub
  Private Sub ClearDetails()
    lblRecord.Text = "0 z " & lvKlasa.Items.Count
    Me.lblUser.Text = ""
    Me.lblData.Text = ""
    Me.lblIP.Text = ""
  End Sub

  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    Dim DBA As New DataBaseAction, DeletedIndex As Integer, K As New KlasaSQL
    Try
      For Each Item As ListViewItem In Me.lvKlasa.SelectedItems
        DeletedIndex = Item.Index
        DBA.ApplyChanges(K.DeleteKlasa(Item.Text))
      Next
      Me.EnableButtons(False)
      lvKlasa.Items.Clear()
      Me.GetData()
      Dim SH As New SeekHelper
      SH.FindRemovedListViewItemIndex(Me.lvKlasa, DeletedIndex)
    Catch mex As MySqlException
      MessageBox.Show(mex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)

    End Try
  End Sub
  Public Sub AddKlasa()
    Dim dlgAddNew As New dlgKlasa
    dlgAddNew.Text = "Dodawanie nowego oddziału"
    
    dlgAddNew.MdiParent = Me.MdiParent
    dlgAddNew.MaximizeBox = False
    dlgAddNew.StartPosition = FormStartPosition.CenterScreen
    'dlgAddNew.Opacity = 0.7
    dlgAddNew.Show()
    dlgAddNew.txtKlasa.Focus()
    AddHandler dlgAddNew.NewAdded, AddressOf NewAdded
    AddHandler dlgAddNew.FormClosed, AddressOf EnableCmdAddNew
    Me.cmdAddNew.Enabled = False
  End Sub
  Private Sub NewAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedID As String)
    lvKlasa.Items.Clear()
    GetData()
    Dim SH As New SeekHelper
    SH.FindListViewItem(Me.lvKlasa, InsertedID)
  End Sub
  Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
    AddKlasa()
  End Sub

  'Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
  '  EditData()
  'End Sub
  'Private Sub EditData()
  '  Try
  '    Dim dlgEdit As New dlgKlasa


  '    With dlgEdit
  '      .Text = "Edycja oddziału"
  '      '.MdiParent = Me.MdiParent
  '      .txtKlasa.Text = Me.lvKlasa.SelectedItems(0).Text

  '      .Icon = GlobalValues.gblAppIcon
  '      .MinimizeBox = False
  '      .MaximizeBox = False

  '      If dlgEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
  '        Dim DBA As New DataBaseAction, K As New KlasaSQL, Klasa As String
  '        Dim MySQLTrans As MySqlTransaction

  '        Klasa = Me.lvKlasa.SelectedItems(0).Text
  '        Dim cmd As MySqlCommand = DBA.CreateCommand(K.UpdateKlasa(.txtKlasa.Text.Trim, Klasa))
  '        MySQLTrans = GlobalValues.gblConn.BeginTransaction()
  '        cmd.Transaction = MySQLTrans
  '        Try

  '          cmd.ExecuteNonQuery()

  '          MySQLTrans.Commit()

  '        Catch ex As MySqlException
  '          MessageBox.Show(ex.Message)
  '          MySQLTrans.Rollback()
  '        End Try
  '        lvKlasa.Items.Clear()
  '        GetData()
  '        Me.EnableButtons(False)
  '        Dim SH As New SeekHelper
  '        SH.FindListViewItem(Me.lvKlasa, Klasa)
  '      End If
  '    End With
  '  Catch ex As Exception

  '    MessageBox.Show(ex.Message)
  '  End Try

  'End Sub
End Class

Public Class KlasaSQL
  Public Function SelectKlasa() As String
    Return "SELECT Klasa,User,ComputerIP,Version FROM klasy;"
  End Function
  Public Function DeleteKlasa(ByVal Klasa As String) As String
    Return "DELETE FROM klasy WHERE Klasa='" & Klasa & "';"
  End Function
  Public Function InsertKlasa(ByVal Nazwa As String) As String
    Return "INSERT INTO klasy VALUES('" & Nazwa & "','" & GlobalValues.gblUserName & "','" & GlobalValues.gblIP & "',NULL);"
  End Function
  'Public Function UpdateKlasa(ByVal NowaNazwa As String, ByVal Klasa As String) As String
  '  Return "UPDATE klasy SET Klasa='" & NowaNazwa & "' WHERE Klasa='" & Klasa & "';"
  'End Function
End Class
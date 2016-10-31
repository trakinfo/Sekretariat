Public Class frmOrgan
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
    With lvOrgan
      .Columns.Add("ID", 0, HorizontalAlignment.Center)
      .Columns.Add("Nazwa", 549, HorizontalAlignment.Left)
      '.Columns.Add("Adres", 200, HorizontalAlignment.Left)
      '.Columns.Add("NIP", 100, HorizontalAlignment.Center)
      '.Columns.Add("Domyślna", 50, HorizontalAlignment.Center)
    End With
  End Sub
  Private Sub frmKlasa_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    SharedOrgan.CloseChildren(Me, e)
  End Sub
  Private Sub frmSzkola_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    SharedOrgan.CloseChildren(Me, e)
  End Sub

  Private Sub frmSzkola_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ListViewConfig(lvOrgan)
    ClearDetails()
    GetData()
  End Sub
  Private Sub GetData()
    Dim DBA As New DataBaseAction, O As New OrganSQL
    'Dim Dr As DataRow
    DT = DBA.GetDataTable(O.SelectOrgan)
    Try
      lvOrgan.Items.Clear()
      For Each Dr As DataRow In DT.Rows
        lvOrgan.Items.Add(Dr.Item(0).ToString)
        'For i As Byte = 1 To 4
        lvOrgan.Items(lvOrgan.Items.Count - 1).SubItems.Add(Dr.Item(1).ToString)
        'Next
      Next
      If lvOrgan.Items.Count > 0 Then
        lvOrgan.Enabled = True
        'lvSzkoly.Focus()
        'lvSzkoly.Items(0).Selected = True
      Else
        lvOrgan.Enabled = False
      End If
      lvOrgan.Columns(1).Width = CInt(IIf(lvOrgan.Items.Count > 18, 533, 549))
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub
  Private Sub GetDetails()
    Dim FoundRow() As DataRow
    Try
      FoundRow = DT.Select("ID=" & lvOrgan.SelectedItems(0).Text)
      With FoundRow(0)
        Me.lblRodzaj.Text = .Item(2).ToString
        lblUlica.Text = .Item(3).ToString
        lblNr.Text = .Item(4).ToString
        lblMiejscowosc.Text = .Item(5).ToString
        lblKodPocztowy.Text = .Item(6).ToString
        Me.lblWoj.Text = .Item(7).ToString
        Me.lblKraj.Text = .Item(8).ToString
        lblUser.Text = .Item(9).ToString
        lblIP.Text = .Item(10).ToString
        lblData.Text = .Item(11).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub
  Private Sub ClearDetails()
    lblRecord.Text = "0 z " & lvOrgan.Items.Count
    lblRodzaj.Text = ""
    lblMiejscowosc.Text = ""
    lblUlica.Text = ""
    lblNr.Text = ""
    lblKodPocztowy.Text = ""
    lblWoj.Text = ""
    lblKraj.Text = ""

    Me.lblUser.Text = ""
    Me.lblData.Text = ""
    Me.lblIP.Text = ""
  End Sub

  Private Sub lvSzkoly_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvOrgan.DoubleClick
    Me.EditData()
  End Sub
  Private Sub lvSzkoly_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvOrgan.ItemSelectionChanged
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
    Dim dlgEdit As New dlgOrgan, FCB As New FillComboBox
    With dlgEdit
      .InRefresh = True
      FCB.AddComboBoxComplexItems(dlgEdit.cbMiejscowosc, "Select m.ID,concat_WS(' ',m.Nazwa,'{',w.Nazwa,'}') as Nazwa From miejscowosc m left Join wojewodztwa w on m.IdWoj=w.KodWoj Order by m.Nazwa Collate UTF8_polish_ci;")
      dlgEdit.cbMiejscowosc.AutoCompleteSource = AutoCompleteSource.ListItems
      dlgEdit.cbMiejscowosc.AutoCompleteMode = AutoCompleteMode.Append

      .Text = "Edycja danych organu prowadzącego"
      .txtNazwa.Text = Me.lvOrgan.SelectedItems(0).SubItems(1).Text
      .txtRodzaj.Text = Me.lblRodzaj.Text
      .txtUlica.Text = lblUlica.Text
      .txtNr.Text = Me.lblNr.Text
      Dim SH As New SeekHelper
      If lblMiejscowosc.Text.Length > 0 Then SH.FindComboItem(.cbMiejscowosc, CType(DT.Select("ID=" & Me.lvOrgan.SelectedItems(0).Text)(0).Item(12), Integer))
      .InRefresh = False
      If dlgEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim DBA As New DataBaseAction, O As New OrganSQL, IDOrgan As String
        Dim MySQLTrans As MySqlTransaction

        IDOrgan = Me.lvOrgan.SelectedItems(0).Text
        Dim cmd As MySqlCommand = DBA.CreateCommand(O.UpdateOrgan(IDOrgan))
        MySQLTrans = GlobalValues.gblConn.BeginTransaction()
        cmd.Transaction = MySQLTrans
        Try
          cmd.Parameters.AddWithValue("?Nazwa", .txtNazwa.Text.Trim)
          cmd.Parameters.AddWithValue("?Rodzaj", .txtRodzaj.Text.Trim)
          cmd.Parameters.AddWithValue("?Ulica", .txtUlica.Text.Trim)
          cmd.Parameters.AddWithValue("?Nr", .txtNr.Text.Trim)
          If .cbMiejscowosc.SelectedItem IsNot Nothing Then
            cmd.Parameters.AddWithValue("?IdMiejscowosc", CType(.cbMiejscowosc.SelectedItem, CbItem).ID.ToString)
          Else
            cmd.Parameters.AddWithValue("?IdMiejscowosc", DBNull.Value)
          End If

          cmd.ExecuteNonQuery()
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
        SH.FindListViewItem(Me.lvOrgan, IDOrgan)
      End If
    End With
  End Sub

  Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
    Dim dlgAddNew As New dlgOrgan, FCB As New FillComboBox
    FCB.AddComboBoxComplexItems(dlgAddNew.cbMiejscowosc, "Select m.ID,concat_WS(' ',m.Nazwa,'{',w.Nazwa,'}') as Nazwa From miejscowosc m left Join wojewodztwa w on m.IdWoj=w.KodWoj Order by m.Nazwa Collate UTF8_polish_ci;")
    dlgAddNew.cbMiejscowosc.AutoCompleteSource = AutoCompleteSource.ListItems
    dlgAddNew.cbMiejscowosc.AutoCompleteMode = AutoCompleteMode.Append

    dlgAddNew.Text = "Dodawanie organu prowadzącego"
    AddHandler dlgAddNew.NewAdded, AddressOf NewSchoolAdded
    AddHandler dlgAddNew.FormClosed, AddressOf EnableCmdAddNew
    AddHandler SharedOrgan.OnOwnerClose, AddressOf dlgAddNew.Cancel_Button_Click
    dlgAddNew.MdiParent = Me.MdiParent
    dlgAddNew.Show()
    dlgAddNew.txtRodzaj.Focus()
    Me.cmdAddNew.Enabled = False
  End Sub
  Private Sub NewSchoolAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedID As String)
    Me.GetData()
    If Not lvOrgan.FindItemWithText(InsertedID) Is Nothing Then
      lvOrgan.Focus()
      lvOrgan.Items(lvOrgan.FindItemWithText(InsertedID).Index).Selected = True
    End If
  End Sub
  Private Sub EnableCmdAddNew(ByVal sender As Object, ByVal e As FormClosedEventArgs)
    Me.cmdAddNew.Enabled = True
  End Sub
  Private Sub RefreshData()
    lvOrgan.Items.Clear()
    ClearDetails()
    GetData()
  End Sub
  'Private Sub lvWoj_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvOrgan.DoubleClick
  '  EditData()
  'End Sub
  Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
    Me.EditData()
  End Sub

  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    Dim DBA As New DataBaseAction, DeletedIndex As Integer, O As New OrganSQL
    Try
      For Each Item As ListViewItem In Me.lvOrgan.SelectedItems
        DeletedIndex = Item.Index
        DBA.ApplyChanges(O.DeleteOrgan(Item.Text))
      Next
      Me.EnableButtons(False)
      RefreshData()
      Dim SH As New SeekHelper
      SH.FindRemovedListViewItemIndex(Me.lvOrgan, DeletedIndex)
    Catch mex As MySqlException
      MessageBox.Show(mex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)

    End Try
  End Sub
End Class


Public Class OrganSQL
  Public Function SelectOrgan() As String
    Return "SELECT o.ID,o.Nazwa,o.Rodzaj,o.Ulica,o.Nr,m.Nazwa,m.KodPocztowy,w.Nazwa,k.Nazwa,o.User,o.ComputerIP,o.Version,m.ID FROM organ_prowadz o LEFT JOIN miejscowosc m ON o.IdMiejscowosc=m.ID LEFT JOIN wojewodztwa w ON m.IdWoj=w.KodWoj LEFT JOIN kraj k ON m.IdKraj=k.ID ORDER BY m.Nazwa COLLATE UTF8_polish_ci;"
  End Function
  Public Function UpdateOrgan(ByVal IdOrgan As String) As String
    Return "UPDATE organ_prowadz SET Nazwa=?Nazwa,Rodzaj=?Rodzaj,Ulica=?Ulica,Nr=?Nr,IdMiejscowosc=?IdMiejscowosc,User='" & GlobalValues.gblUserName & "',ComputerIP='" & GlobalValues.gblIP & "',Version=NULL WHERE ID=" & IdOrgan & ";"
  End Function
  Public Function InsertOrgan() As String
    Return "INSERT INTO organ_prowadz VALUES(NULL,?Rodzaj,?Nazwa,?Ulica,?Nr,?IdMiejscowosc,'" & GlobalValues.gblUserName & "','" & GlobalValues.gblIP & "',NULL);"
  End Function
  Public Function DeleteOrgan(ByVal IdOrgan As String) As String
    Return "Delete From organ_prowadz Where ID=" & IdOrgan & ";"
  End Function
  'Public Function SetDefault() As String
  '  Return "UPDATE szkoly SET IsDefault=false;"
  'End Function
  'Public Function SetDefault(ByVal IsDefault As Integer, ByVal ID As String) As String
  '  Return "UPDATE szkoly SET IsDefault=" & IsDefault & " WHERE ID='" & ID & "';"
  'End Function
End Class
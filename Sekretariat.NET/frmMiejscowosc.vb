Public Class frmMiejscowosc

  Private DT As DataTable, Filter As String = ""
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
      .Columns.Add("ID", 0, HorizontalAlignment.Left)
      .Columns.Add("Nazwa", 150, HorizontalAlignment.Left)
      .Columns.Add("Poczta", 150, HorizontalAlignment.Left)
      .Columns.Add("KodPocztowy", 50, HorizontalAlignment.Center)
      .Columns.Add("Województwo", 150, HorizontalAlignment.Left)
      .Columns.Add("Kraj", 150, HorizontalAlignment.Left)
      .Columns.Add("Status", 50, HorizontalAlignment.Left)
      .Columns.Add("Domyślny", 50, HorizontalAlignment.Center)
    End With
  End Sub

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Close()
  End Sub

  Private Sub frmKlasa_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    SharedMiejscowosc.CloseChildren(Me, e)
  End Sub

  Private Sub frmKlasa_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    SharedMiejscowosc.CloseChildren(Me, e)
    'SharedKlasa.CloseChildren(Me, e)
  End Sub
  Private Sub EnableCmdAddNew(ByVal sender As Object, ByVal e As FormClosedEventArgs)
    Me.cmdAddNew.Enabled = True
  End Sub
  Private Sub frmKlasa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.ListViewConfig(Me.lvMiejscowosc)
    Dim SeekCriteria() As String = New String() {"Nazwa", "Województwo", "Kraj"}
    Me.cbSeek.Items.AddRange(SeekCriteria)
    Me.cbSeek.SelectedIndex = 0
    FetchData()
    Me.GetData()
  End Sub
  Private Sub FetchData()
    Dim DBA As New DataBaseAction, M As New MiejscowoscSQL
    DT = DBA.GetDataTable(M.SelectMiejscowosc)

  End Sub

  Private Sub GetData()
    lvMiejscowosc.Items.Clear()
    Dim FilteredData() As DataRow
    FilteredData = DT.Select(Filter)

    For i As Integer = 0 To FilteredData.GetUpperBound(0) 'For Each row As DataRow In DT.Rows
      Me.lvMiejscowosc.Items.Add(FilteredData(i).Item(0).ToString)
      Me.lvMiejscowosc.Items(Me.lvMiejscowosc.Items.Count - 1).SubItems.Add(FilteredData(i).Item(1).ToString)
      Me.lvMiejscowosc.Items(Me.lvMiejscowosc.Items.Count - 1).SubItems.Add(FilteredData(i).Item(2).ToString)
      If CType(IsDBNull(FilteredData(i).Item(3)), Boolean) = True OrElse FilteredData(i).Item(3).ToString = "" Then
        Me.lvMiejscowosc.Items(Me.lvMiejscowosc.Items.Count - 1).SubItems.Add("")
      Else
        Me.lvMiejscowosc.Items(Me.lvMiejscowosc.Items.Count - 1).SubItems.Add(FilteredData(i).Item(3).ToString)
      End If
      'Me.lvMiejscowosc.Items(Me.lvMiejscowosc.Items.Count - 1).SubItems.Add(IIf(CType(IsDBNull(row.Item(3)), Boolean) = True, "", Format(CType(row.Item(3), Integer), "00-000")).ToString)
      Me.lvMiejscowosc.Items(Me.lvMiejscowosc.Items.Count - 1).SubItems.Add(FilteredData(i).Item(4).ToString)
      Me.lvMiejscowosc.Items(Me.lvMiejscowosc.Items.Count - 1).SubItems.Add(FilteredData(i).Item(5).ToString)
      Me.lvMiejscowosc.Items(Me.lvMiejscowosc.Items.Count - 1).SubItems.Add(IIf(CType(FilteredData(i).Item(6), Boolean) = True, "Miasto", "Wieś").ToString)
      Me.lvMiejscowosc.Items(Me.lvMiejscowosc.Items.Count - 1).SubItems.Add(IIf(CType(FilteredData(i).Item(7), Boolean) = True, "Tak", "Nie").ToString)

    Next

    lvMiejscowosc.Columns(1).Width = CInt(IIf(lvMiejscowosc.Items.Count > 23, 166, 187))
    Me.lvMiejscowosc.Enabled = CType(IIf(Me.lvMiejscowosc.Items.Count > 0, True, False), Boolean)
    lblRecord.Text = "0 z " & lvMiejscowosc.Items.Count

  End Sub
  Private Sub GetDetails(ByVal Name As String)
    Try
      lblRecord.Text = lvMiejscowosc.SelectedItems(0).Index + 1 & " z " & lvMiejscowosc.Items.Count
      With DT.Select("ID='" & Name & "'")(0)
        lblUser.Text = .Item(8).ToString
        lblIP.Text = .Item(9).ToString
        lblData.Text = .Item(10).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub

  Private Sub lvMiejscowosc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMiejscowosc.DoubleClick
    EditData()
  End Sub

  Private Sub lvKlasa_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvMiejscowosc.ItemSelectionChanged
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
    lblRecord.Text = "0 z " & lvMiejscowosc.Items.Count
    Me.lblUser.Text = ""
    Me.lblData.Text = ""
    Me.lblIP.Text = ""
  End Sub

  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    Dim DBA As New DataBaseAction, DeletedIndex As Integer, M As New MiejscowoscSQL
    Try
      For Each Item As ListViewItem In Me.lvMiejscowosc.SelectedItems
        DeletedIndex = Item.Index
        DBA.ApplyChanges(M.DeleteMiejscowosc(Item.Text))
      Next
      Me.EnableButtons(False)
      lvMiejscowosc.Items.Clear()
      Me.GetData()
      Dim SH As New SeekHelper
      SH.FindRemovedListViewItemIndex(Me.lvMiejscowosc, DeletedIndex)
    Catch mex As MySqlException
      MessageBox.Show(mex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)

    End Try
  End Sub
  Public Sub AddNewData()
    Dim dlgAddNew As New dlgMiejscowosc
    dlgAddNew.Text = "Dodawanie nowej miejscowości"
    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(dlgAddNew.cbWoj, "SELECT KodWoj,Nazwa FROM wojewodztwa;", True)
    dlgAddNew.cbWoj.AutoCompleteSource = AutoCompleteSource.ListItems
    dlgAddNew.cbWoj.AutoCompleteMode = AutoCompleteMode.Append
    'SH.FindComboItem(dlgAddNew.cbWoj, My.Settings.LastMiejsceUr)
    FCB.AddComboBoxComplexItems(dlgAddNew.cbKraj, "SELECT ID,Nazwa FROM kraj;")
    dlgAddNew.cbWoj.AutoCompleteSource = AutoCompleteSource.ListItems
    dlgAddNew.cbWoj.AutoCompleteMode = AutoCompleteMode.Append

    dlgAddNew.MdiParent = Me.MdiParent
    dlgAddNew.MaximizeBox = False
    dlgAddNew.StartPosition = FormStartPosition.CenterScreen
    'dlgAddNew.Opacity = 0.7
    dlgAddNew.Show()
    dlgAddNew.txtNazwa.Focus()
    AddHandler dlgAddNew.NewAdded, AddressOf NewAdded
    AddHandler dlgAddNew.FormClosed, AddressOf EnableCmdAddNew
    Me.cmdAddNew.Enabled = False
  End Sub
  Private Sub NewAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedID As String)
    lvMiejscowosc.Items.Clear()
    GetData()
    Dim SH As New SeekHelper
    SH.FindListViewItem(Me.lvMiejscowosc, InsertedID)
  End Sub
  Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
    AddNewData()
  End Sub

  Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
    EditData()
  End Sub
  Private Sub EditData()
    Try
      Dim dlgEdit As New dlgMiejscowosc


      With dlgEdit
        .Text = "Edycja danych miejscowości"
        '.MdiParent = Me.MdiParent
        '.txtKlasa.Text = Me.lvMiejscowosc.SelectedItems(0).Text
        Dim FCB As New FillComboBox, SH As New SeekHelper
        FCB.AddComboBoxComplexItems(.cbWoj, "SELECT KodWoj,Nazwa FROM wojewodztwa;", True)
        .cbWoj.AutoCompleteSource = AutoCompleteSource.ListItems
        .cbWoj.AutoCompleteMode = AutoCompleteMode.Append
        SH.FindComboItem(.cbWoj, lvMiejscowosc.SelectedItems(0).SubItems(4).Text)
        FCB.AddComboBoxComplexItems(.cbKraj, "SELECT ID,Nazwa FROM kraj;")
        .cbWoj.AutoCompleteSource = AutoCompleteSource.ListItems
        .cbWoj.AutoCompleteMode = AutoCompleteMode.Append
        SH.FindComboItem(.cbKraj, lvMiejscowosc.SelectedItems(0).SubItems(5).Text)
        .txtNazwa.Text = lvMiejscowosc.SelectedItems(0).SubItems(1).Text
        .txtPoczta.Text = lvMiejscowosc.SelectedItems(0).SubItems(2).Text
        .mskKodPocztowy.Text = lvMiejscowosc.SelectedItems(0).SubItems(3).Text
        '.txtKodPocztowy.Text = lvMiejscowosc.SelectedItems(0).SubItems(3).Text
        .chkMiasto.Checked = CType(IIf(lvMiejscowosc.SelectedItems(0).SubItems(6).Text = "Miasto", True, False), Boolean)
        .chkIsDefault.Checked = CType(IIf(lvMiejscowosc.SelectedItems(0).SubItems(7).Text = "Tak", True, False), Boolean)

        .Icon = GlobalValues.gblAppIcon
        .MinimizeBox = False
        .MaximizeBox = False

        If dlgEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
          Dim DBA As New DataBaseAction, M As New MiejscowoscSQL, Miejscowosc As String
          Dim MySQLTrans As MySqlTransaction

          Miejscowosc = Me.lvMiejscowosc.SelectedItems(0).Text
          Dim cmd As MySqlCommand = DBA.CreateCommand(M.UpdateMiejscowsc(Miejscowosc))
          MySQLTrans = GlobalValues.gblConn.BeginTransaction()
          cmd.Transaction = MySQLTrans
          Try
            cmd.Parameters.AddWithValue("?Nazwa", .txtNazwa.Text.Trim)
            cmd.Parameters.AddWithValue("?Poczta", .txtPoczta.Text.Trim)
            'cmd.Parameters.AddWithValue("?KodPocztowy", .mskKodPocztowy.Text)
            cmd.Parameters.AddWithValue("?KodPocztowy", .mskKodPocztowy.Text.Trim("-".ToCharArray))
            cmd.Parameters.AddWithValue("?IdWoj", CType(.cbWoj.SelectedItem, CbItem).Kod.ToString)
            cmd.Parameters.AddWithValue("?IdKraj", CType(.cbKraj.SelectedItem, CbItem).ID.ToString)
            cmd.Parameters.AddWithValue("?Miasto", CType(.chkMiasto.CheckState, Integer).ToString)
            'cmd.Parameters.AddWithValue("?IsDefault", CType(.chkIsDefault.CheckState, Integer).ToString)

            cmd.ExecuteNonQuery()
            If CType(IIf(lvMiejscowosc.SelectedItems(0).SubItems(7).Text = "True", True, False), Boolean) <> .chkIsDefault.Checked Then
              cmd.CommandText = M.SetDefault
              cmd.ExecuteNonQuery()
              cmd.CommandText = M.SetDefault(CType(.chkIsDefault.CheckState, Integer), Miejscowosc)
              cmd.ExecuteNonQuery()
            End If
            MySQLTrans.Commit()

          Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            MySQLTrans.Rollback()
          End Try
          lvMiejscowosc.Items.Clear()
          FetchData()
          GetData()
          Me.EnableButtons(False)
          'Dim SH As New SeekHelper
          SH.FindListViewItem(Me.lvMiejscowosc, Miejscowosc)
        End If
      End With
    Catch ex As Exception

      MessageBox.Show(ex.Message)
    End Try

  End Sub

  Private Sub txtSeek_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSeek.TextChanged
    Select Case Me.cbSeek.Text
      Case "Województwo"
        Filter = "Woj LIKE '" & IIf(Me.txtSeek.Text.Trim.Length > 0, Me.txtSeek.Text & "%'", Me.txtSeek.Text & "%' OR Woj IS NULL").ToString 'Me.txtSeek.Text & "%'"
      Case "Nazwa"
        Filter = "Nazwa LIKE '" & Me.txtSeek.Text & "%'"
      Case "Kraj"
        Filter = "Kraj LIKE '" & IIf(Me.txtSeek.Text.Trim.Length > 0, Me.txtSeek.Text & "%'", Me.txtSeek.Text & "%' OR Kraj IS NULL").ToString
    End Select
    Me.EnableButtons(False)
    GetData()
    'Me.RefreshData()
  End Sub
  Private Sub cbSeek_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSeek.SelectedIndexChanged
    Me.txtSeek.Text = ""
    Me.txtSeek.Focus()
  End Sub
End Class


Public Class MiejscowoscSQL
  Public Function SelectMiejscowosc() As String
    Return "SELECT m.ID,m.Nazwa,m.Poczta,m.KodPocztowy,w.Nazwa AS Woj,k.Nazwa AS Kraj,m.Miasto,m.IsDefault,m.User,m.ComputerIP,m.Version FROM miejscowosc m LEFT JOIN wojewodztwa w ON m.IdWoj=w.KodWoj LEFT JOIN kraj k ON m.IdKraj=k.ID ORDER BY m.Nazwa COLLATE utf8_polish_ci;"
  End Function
  Public Function DeleteMiejscowosc(ByVal ID As String) As String
    Return "DELETE FROM miejscowosc WHERE ID='" & ID & "';"
  End Function
  Public Function InsertMiejscowosc() As String
    Return "INSERT INTO miejscowosc VALUES(NULL,?Nazwa,?Poczta,?KodPocztowy,?IdWoj,?IdKraj,?Miasto,0,'" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  Public Function UpdateMiejscowsc(ByVal ID As String) As String
    Return "UPDATE miejscowosc SET Nazwa=?Nazwa,Poczta=?Poczta,KodPocztowy=?KodPocztowy,IdWoj=?IdWoj,IdKraj=?IdKraj,Miasto=?Miasto,User='" + GlobalValues.gblUserName + "',ComputerIP='" + GlobalValues.gblIP + "',Version=NULL WHERE ID='" & ID & "';"
  End Function
  Public Function SetDefault() As String
    Return "UPDATE miejscowosc SET IsDefault=false;"
  End Function
  Public Function SetDefault(ByVal IsDefault As Integer, ByVal ID As String) As String
    Return "UPDATE miejscowosc SET IsDefault=" & IsDefault & " WHERE ID='" & ID & "';"
  End Function
End Class
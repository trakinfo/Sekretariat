Public Class frmPrzydzialKlasDoSzkol
  Private DT As DataTable
  Private Sub frmPrzydzialKlasDoSzkol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ListViewConfig(lvKlasa)
    lblRecord.Text = ""
    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(Me.cbSzkola, "Select ID,Alias FROM szkoly;")
    SH.FindComboItem(Me.cbSzkola, CInt(SH.GetDefault("Select ID From szkoly Where IsDefault='1';")))

  End Sub
  Private Sub FetchData()
    Dim DBA As New DataBaseAction, PK As New PrzydzialKlasSQL
    DT = DBA.GetDataTable(PK.SelectClasses(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString))
  End Sub
  Private Sub GetData()
    lvKlasa.Items.Clear()
    For Each row As DataRow In DT.Rows
      Me.lvKlasa.Items.Add(row.Item(0).ToString)
      Me.lvKlasa.Items(Me.lvKlasa.Items.Count - 1).SubItems.Add(row.Item(0).ToString)
    Next

    lvKlasa.Columns(1).Width = CInt(IIf(lvKlasa.Items.Count > 15, 166, 187))
    Me.lvKlasa.Enabled = CType(IIf(Me.lvKlasa.Items.Count > 0, True, False), Boolean)
  End Sub
  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    lblRecord.Text = "0 z " & lvKlasa.Items.Count
    FetchData()
    Me.GetData()
    chkVirtual.Enabled = True
    cmdAddNew.Enabled = True
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
      .Columns.Add("Kod", 0, HorizontalAlignment.Left)
      .Columns.Add("Nazwa", 187, HorizontalAlignment.Center)
    End With
  End Sub

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Close()
  End Sub

  Private Sub GetDetails(ByVal Name As String)
    Try
      lblRecord.Text = lvKlasa.SelectedItems(0).Index + 1 & " z " & lvKlasa.Items.Count
      With DT.Select("IdKlasa='" & Name & "'")(0)
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
  Private Sub chkVirtual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtual.CheckedChanged
    If Not cbSzkola.SelectedItem Is Nothing Then
      Me.FetchData()
      GetData()
      ClearDetails()
      Me.EnableButtons(False)
    End If
  End Sub
  Private Sub EnableButtons(ByVal Value As Boolean)
    Me.cmdDelete.Enabled = Value
  End Sub
  Private Sub ClearDetails()
    lblRecord.Text = "0 z " & lvKlasa.Items.Count
    Me.lblUser.Text = ""
    Me.lblData.Text = ""
    Me.lblIP.Text = ""
  End Sub
  Private Sub frmKlasa_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    SharedPrzydzialKlas.CloseChildren(Me, e)
  End Sub

  Private Sub frmKlasa_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    SharedPrzydzialKlas.CloseChildren(Me, e)
  End Sub
  Private Sub EnableCmdAddNew(ByVal sender As Object, ByVal e As FormClosedEventArgs)
    Me.cmdAddNew.Enabled = True
  End Sub
  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    Dim DBA As New DataBaseAction, DeletedIndex As Integer, PK As New PrzydzialKlasSQL
    Try
      For Each Item As ListViewItem In Me.lvKlasa.SelectedItems
        DeletedIndex = Item.Index
        DBA.ApplyChanges(PK.DeleteClass(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Item.Text))
      Next
      Me.EnableButtons(False)
      FetchData()
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
    Dim dlgAddNew As New dlgPrzydzialKlas
    dlgAddNew.Text = "Przydział oddziału do szkoły"
    dlgAddNew.IdSzkola = CType(cbSzkola.SelectedItem, CbItem).ID.ToString
    dlgAddNew.Virtual = CType(chkVirtual.CheckState, Integer).ToString
    ListViewConfig(dlgAddNew.lvKlasa)
    Dim DBA As New DataBaseAction, PK As New PrzydzialKlasSQL, DT As DataTable
    DT = DBA.GetDataTable(PK.SelectClasses(CType(cbSzkola.SelectedItem, CbItem).ID.ToString))
    For Each row As DataRow In DT.Rows
      dlgAddNew.lvKlasa.Items.Add(row.Item(0).ToString)
      dlgAddNew.lvKlasa.Items(dlgAddNew.lvKlasa.Items.Count - 1).SubItems.Add(row.Item(0).ToString)
    Next
    dlgAddNew.lvKlasa.Columns(1).Width = CInt(IIf(dlgAddNew.lvKlasa.Items.Count > 23, 124, 144))
    dlgAddNew.lvKlasa.Enabled = CType(IIf(dlgAddNew.lvKlasa.Items.Count > 0, True, False), Boolean)

    dlgAddNew.MdiParent = Me.MdiParent
    dlgAddNew.MaximizeBox = False
    dlgAddNew.StartPosition = FormStartPosition.CenterScreen
    'dlgAddNew.Opacity = 0.7
    dlgAddNew.Show()

    AddHandler dlgAddNew.NewAdded, AddressOf NewAdded
    AddHandler dlgAddNew.FormClosed, AddressOf EnableCmdAddNew
    Me.cmdAddNew.Enabled = False
  End Sub
  Private Sub NewAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedID As String)
    FetchData()
    GetData()
    Dim SH As New SeekHelper
    SH.FindListViewItem(Me.lvKlasa, InsertedID)
  End Sub
  Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
    AddKlasa()
  End Sub

End Class

Public Class PrzydzialKlasSQL
  Public Overloads Function SelectClasses(ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT IdKlasa,User,ComputerIP,Version FROM szkola_klasa WHERE IdSzkola='" & IdSzkola & "' AND Virtual='" & Virtual & "';"
  End Function
  Public Overloads Function SelectClasses(ByVal IdSzkola As String) As String
    Return "SELECT Klasa FROM klasy WHERE Klasa NOT IN (SELECT IdKlasa FROM szkola_klasa WHERE IdSzkola='" & IdSzkola & "');"
  End Function
  Public Function DeleteClass(ByVal IdSzkola As String, ByVal IdKlasa As String) As String
    Return "DELETE FROM szkola_klasa WHERE IdKlasa='" & IdKlasa & "' AND IdSzkola='" & IdSzkola & "';"
  End Function
  Public Function InsertClass(ByVal IdSzkola As String, ByVal IdKlasa As String, ByVal Virtual As String) As String
    Return "INSERT INTO szkola_klasa VALUES('" & IdKlasa & "','" & IdSzkola & "','" & Virtual & "','" & GlobalValues.gblUserName & "','" & GlobalValues.gblIP & "',NULL);"
  End Function
End Class
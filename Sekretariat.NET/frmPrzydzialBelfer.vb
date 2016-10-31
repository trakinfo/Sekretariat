Public Class frmPrzydzialBelfer
  Private DT As DataTable
  Private Sub frmPrzydzialKlasDoSzkol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ListViewConfig(lvBelfer)
    lblRecord.Text = ""
    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(Me.cbSzkola, "Select ID,Alias FROM szkoly;")
    SH.FindComboItem(Me.cbSzkola, CInt(SH.GetDefault("Select ID From szkoly Where IsDefault='1';")))

  End Sub
  Private Sub FetchData()
    Dim DBA As New DataBaseAction, PB As New PrzydzialBelferSQL
    DT = DBA.GetDataTable(PB.SelectPrzydzial(CType(cbSzkola.SelectedItem, CbItem).ID.ToString))
  End Sub
  Private Sub GetData()
    lvBelfer.Items.Clear()
    For Each row As DataRow In DT.Rows
      Me.lvBelfer.Items.Add(row.Item(0).ToString)
      Me.lvBelfer.Items(Me.lvBelfer.Items.Count - 1).SubItems.Add(row.Item(1).ToString)
    Next

    lvBelfer.Columns(1).Width = CInt(IIf(lvBelfer.Items.Count > 17, 265, 284))
    Me.lvBelfer.Enabled = CType(IIf(Me.lvBelfer.Items.Count > 0, True, False), Boolean)
  End Sub
  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    lblRecord.Text = "0 z " & lvBelfer.Items.Count
    FetchData()
    Me.GetData()
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
      .Columns.Add("ID", 0, HorizontalAlignment.Left)
      .Columns.Add("Nazwisko i imię", 284, HorizontalAlignment.Left)
    End With
  End Sub

  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Close()
  End Sub

  Private Sub GetDetails(ByVal Name As String)
    Try
      lblRecord.Text = lvBelfer.SelectedItems(0).Index + 1 & " z " & lvBelfer.Items.Count
      With DT.Select("Id='" & Name & "'")(0)
        lblUser.Text = .Item(2).ToString
        lblIP.Text = .Item(3).ToString
        lblData.Text = .Item(4).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub

  Private Sub lvKlasa_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvBelfer.ItemSelectionChanged
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
  End Sub
  Private Sub ClearDetails()
    lblRecord.Text = "0 z " & lvBelfer.Items.Count
    Me.lblUser.Text = ""
    Me.lblData.Text = ""
    Me.lblIP.Text = ""
  End Sub
  Private Sub frmKlasa_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    SharedPrzydzialBelfer.CloseChildren(Me, e)
  End Sub

  Private Sub frmKlasa_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    SharedPrzydzialBelfer.CloseChildren(Me, e)
  End Sub
  Private Sub EnableCmdAddNew(ByVal sender As Object, ByVal e As FormClosedEventArgs)
    Me.cmdAddNew.Enabled = True
  End Sub
  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    Dim DBA As New DataBaseAction, DeletedIndex As Integer, PB As New PrzydzialBelferSQL
    Try
      For Each Item As ListViewItem In Me.lvBelfer.SelectedItems
        DeletedIndex = Item.Index
        DBA.ApplyChanges(PB.DeletePrzydzial(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Item.Text))
      Next
      Me.EnableButtons(False)
      FetchData()
      Me.GetData()
      Dim SH As New SeekHelper
      SH.FindRemovedListViewItemIndex(Me.lvBelfer, DeletedIndex)
    Catch mex As MySqlException
      MessageBox.Show(mex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)

    End Try
  End Sub
  Public Sub AddBelfer()
    Dim dlgAddNew As New dlgPrzydzialBelfer
    dlgAddNew.Text = "Przydział nauczyciela do szkoły"
    dlgAddNew.IdSzkola = CType(cbSzkola.SelectedItem, CbItem).ID.ToString
    ListViewConfig(dlgAddNew.lvBelfer)
    Dim DBA As New DataBaseAction, PB As New PrzydzialBelferSQL, DT As DataTable
    DT = DBA.GetDataTable(PB.SelectBelfer(CType(cbSzkola.SelectedItem, CbItem).ID.ToString))
    For Each row As DataRow In DT.Rows
      dlgAddNew.lvBelfer.Items.Add(row.Item(0).ToString)
      dlgAddNew.lvBelfer.Items(dlgAddNew.lvBelfer.Items.Count - 1).SubItems.Add(row.Item(1).ToString)
    Next
    dlgAddNew.lvBelfer.Columns(1).Width = CInt(IIf(dlgAddNew.lvBelfer.Items.Count > 23, 265, 284))
    dlgAddNew.lvBelfer.Enabled = CType(IIf(dlgAddNew.lvBelfer.Items.Count > 0, True, False), Boolean)

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
    SH.FindListViewItem(Me.lvBelfer, InsertedID)
  End Sub
  Private Sub cmdAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNew.Click
    AddBelfer()
  End Sub
End Class

Public Class PrzydzialBelferSQL
  Public Overloads Function SelectPrzydzial(ByVal IdSzkola As String) As String
    Return "SELECT b.ID,CONCAT_WS(' ',b.Nazwisko,b.Imie) as Belfer,sb.User,sb.ComputerIP,sb.Version FROM belfer b,szkola_belfer sb WHERE b.ID=sb.IdBelfer AND sb.IdSzkola='" & IdSzkola & "' ORDER BY b.Nazwisko,b.Imie;"
  End Function
  Public Overloads Function SelectBelfer(ByVal IdSzkola As String) As String
    Return "SELECT ID,CONCAT_WS(' ',Nazwisko,Imie) as Belfer FROM belfer WHERE ID NOT IN (SELECT IdBelfer FROM szkola_belfer WHERE IdSzkola='" & IdSzkola & "');"
  End Function
  Public Function DeletePrzydzial(ByVal IdSzkola As String, ByVal IdBelfer As String) As String
    Return "DELETE FROM szkola_belfer WHERE IdBelfer='" & IdBelfer & "' AND IdSzkola='" & IdSzkola & "';"
  End Function
  Public Function InsertPrzydzial(ByVal IdSzkola As String, ByVal IdBelfer As String) As String
    Return "INSERT INTO szkola_belfer VALUES('" & IdSzkola & "','" & IdBelfer & "','" & GlobalValues.gblUserName & "','" & GlobalValues.gblIP & "',NULL);"
  End Function
End Class
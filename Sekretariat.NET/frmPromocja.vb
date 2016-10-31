Public Class frmPromocja
  Private DS As DataSet, ListaKlas() As String, MaxPion As Byte  ', lvGroups() As ListViewGroup

  Private Sub FetchData()
    Dim P As New PromocjaSQL, DBA As New DataBaseAction
    DS = DBA.GetDataSet(P.SelectStudent(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString) & P.CheckAssignment((Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString))
  End Sub

  Private Sub GetKlasa()
    Dim DBA As New DataBaseAction, DT As DataTable, P As New PromocjaSQL
    Try
      DT = DBA.GetDataTable(P.SelectKlasa(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(chkVirtual.CheckState, Integer).ToString))
      ReDim ListaKlas(DT.Rows.Count - 1)
      For i As Integer = 0 To DT.Rows.Count - 1
        ListaKlas(i) = DT.Rows(i).Item(0).ToString
      Next
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try

  End Sub
  Private Sub GetMaxPion()
    Dim DBA As New DataBaseAction, P As New PromocjaSQL
    MaxPion = CType(DBA.GetMaxValue(P.SelectMaxPion(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString)), Byte)
  End Sub
  Private Sub LvNewItem(ByVal LV As ListView, ByVal Promocja As Integer, ByVal Klasa As String)
    Dim Students() As DataRow
    Students = DS.Tables(0).Select("Promocja=" & Promocja & " AND Klasa='" & Klasa & "'")
    Dim NG As New ListViewGroup(Klasa)
    LV.Groups.Add(NG)
    For j As Integer = 0 To Students.GetUpperBound(0)
      Dim NewItem As New ListViewItem(Students(j).Item(0).ToString, NG)
      NewItem.SubItems.Add(Students(j).Item(1).ToString)
      NewItem.SubItems.Add(Students(j).Item(2).ToString)
      LV.Items.Add(NewItem)
    Next
  End Sub
  Private Sub GetData()
    Try
      Me.lvNiepromowani.Groups.Clear()
      Me.lvPromowani.Groups.Clear()
      If rbWszystkieKlasy.Checked Then
        For i As Integer = 0 To ListaKlas.GetUpperBound(0)
          LvNewItem(lvNiepromowani, 0, ListaKlas(i))
          LvNewItem(lvPromowani, 1, ListaKlas(i))
        Next
      Else
        LvNewItem(lvNiepromowani, 0, cbKlasa.Text)
        LvNewItem(lvPromowani, 1, cbKlasa.Text)
      End If

      lblRecord.Text = "0 z " & lvNiepromowani.Items.Count
      lvNiepromowani.Columns(1).Width = CInt(IIf(lvNiepromowani.Items.Count > 20, 285, 305))
      lvNiepromowani.Enabled = CBool(IIf(lvNiepromowani.Items.Count > 0, True, False))

      lblRecord1.Text = "0 z " & lvPromowani.Items.Count
      lvPromowani.Columns(1).Width = CInt(IIf(lvPromowani.Items.Count > 20, 285, 305))
      lvPromowani.Enabled = CBool(IIf(lvPromowani.Items.Count > 0, True, False))

    Catch ex As MySqlException
      MessageBox.Show(ex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      'R.Close()
    End Try

  End Sub
  Private Sub frmPromocja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ListViewConfig(lvPromowani)
    ListViewConfig(lvNiepromowani)
    lblRecord.Text = ""
    lblRecord1.Text = ""
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
      .Columns.Add("Nazwisko i imię", 309, HorizontalAlignment.Left)
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
      Me.FetchData()
      RefreshData()
      'Me.cmdAdd.Enabled = False
      'Me.cmdDelete.Enabled = False
    End If
  End Sub
  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    Me.FetchData()
    FillKlasa()
    'cbKlasa.Items.Clear()
    'Dim FCB As New FillComboBox
    'FCB.AddComboBoxSimpleItems(cbKlasa, "SELECT IdKlasa FROM szkola_klasa sk WHERE sk.Virtual='" & CType(Me.chkVirtual.CheckState, Integer).ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "';")
    gpbZakres.Enabled = True
    gpbOpcje.Enabled = True
    RefreshData()
    'cmdAddNew.Enabled = True
    'Me.cmdAdd.Enabled = False
    'Me.cmdDelete.Enabled = False

  End Sub

  Private Sub chkVirtual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtual.CheckedChanged
    If Not cbSzkola.SelectedItem Is Nothing Then
      Me.FetchData()
      FillKlasa()
      'cbKlasa.Items.Clear()
      'Dim FCB As New FillComboBox
      'FCB.AddComboBoxSimpleItems(cbKlasa, "SELECT IdKlasa FROM szkola_klasa sk WHERE sk.Virtual='" & CType(Me.chkVirtual.CheckState, Integer).ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "';")
      RefreshData()
      'Me.cmdAdd.Enabled = False
      'Me.cmdDelete.Enabled = False
    End If
  End Sub
  Private Sub FillKlasa()
    cbKlasa.Items.Clear()
    Dim FCB As New FillComboBox
    FCB.AddComboBoxSimpleItems(cbKlasa, "SELECT IdKlasa FROM szkola_klasa sk WHERE sk.Virtual='" & CType(Me.chkVirtual.CheckState, Integer).ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "';")

  End Sub
  Private Sub RefreshData()
    lvNiepromowani.Items.Clear()
    lvPromowani.Items.Clear()
    cmdAdd.Enabled = False
    cmdDelete.Enabled = False
    ClearDetails()
    GetKlasa()
    GetMaxPion()
    GetData()
  End Sub

  Private Sub lvNiepromowani_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvNiepromowani.ItemSelectionChanged, lvPromowani.ItemSelectionChanged
    If e.IsSelected Then
      ClearDetails()
      GetDetails(e.Item.Text, CType(sender, ListView))
    Else
      ClearDetails()
      If CType(sender, ListView).Name = "lvNiepromowani" Then
        lblRecord.Text = "0 z " & CType(sender, ListView).Items.Count
      Else
        lblRecord1.Text = "0 z " & CType(sender, ListView).Items.Count
      End If
    End If
    If rbSelected.Checked Then
      cmdAdd.Enabled = CBool(IIf(lvNiepromowani.SelectedItems.Count > 0, True, False))
      cmdDelete.Enabled = CBool(IIf(lvPromowani.SelectedItems.Count > 0, True, False))
    Else
      cmdAdd.Enabled = CBool(IIf(lvNiepromowani.SelectedItems.Count = lvNiepromowani.Items.Count, False, True))
      cmdDelete.Enabled = CBool(IIf(lvPromowani.SelectedItems.Count = lvNiepromowani.Items.Count, False, True))
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
      If lv.Name = "lvNiepromowani" Then
        lblRecord.Text = lv.SelectedItems(0).Index + 1 & " z " & lv.Items.Count
      Else
        lblRecord1.Text = lv.SelectedItems(0).Index + 1 & " z " & lv.Items.Count
      End If
      FoundRow = DS.Tables(0).Select("ID=" & ID)
      With FoundRow(0)
        lblUser.Text = .Item(3).ToString
        lblIP.Text = .Item(4).ToString
        lblData.Text = .Item(5).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub

  Private Sub rbWybranaKlasa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWybranaKlasa.CheckedChanged, rbWszystkieKlasy.CheckedChanged
    If Not Me.Created Then Exit Sub
    If CType(sender, RadioButton).Checked Then
      If CType(sender, RadioButton).Name = "rbWybranaKlasa" Then
        cbKlasa.Enabled = True
      Else
        cbKlasa.Enabled = False
      End If
      RefreshData()

    End If
  End Sub

  Private Sub cbKlasa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbKlasa.SelectedIndexChanged
    RefreshData()
  End Sub

  Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
    Promotion(lvNiepromowani, "1")
  End Sub

  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    Promotion(lvPromowani, "0")
  End Sub
  Private Sub Promotion(ByVal lv As ListView, ByVal Promocja As String)
    Dim DBA As New DataBaseAction, P As New PromocjaSQL
    Dim MySQLTrans As MySqlTransaction = GlobalValues.gblConn.BeginTransaction()
    Try
      If rbSelected.Checked Then
        For Each item As ListViewItem In lv.SelectedItems
          If DS.Tables(1).Select("ID=" & item.Text).GetLength(0) < 1 Then
            DBA.ApplyChanges(P.UpdatePrzydzial(item.Text, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, Promocja), MySQLTrans)
          Else
            MessageBox.Show("Operacja nie może być wykonana, ponieważ uczeń " & item.SubItems(1).Text & " posiada przydział na następny rok szkolny.")
          End If
        Next
      Else
        For Each item As ListViewItem In lv.Items
          If item.Selected = False AndAlso DS.Tables(1).Select("ID=" & item.Text).GetLength(0) < 1 Then
            DBA.ApplyChanges(P.UpdatePrzydzial(item.Text, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, Promocja), MySQLTrans)
          Else
            MessageBox.Show("Operacja nie może być wykonana, ponieważ uczeń " & item.SubItems(1).Text & " posiada przydział na następny rok szkolny.")
          End If
        Next
      End If
      MySQLTrans.Commit()
      FetchData()
      RefreshData()
    Catch mex As MySqlException
      MySQLTrans.Rollback()
      MessageBox.Show(mex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  Private Sub rbPromuj_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSelected.CheckedChanged, rbUnselected.CheckedChanged
    If CType(sender, RadioButton).Name = "rbSelected" And CType(sender, RadioButton).Checked Then
      cmdAdd.Enabled = CBool(IIf(lvNiepromowani.SelectedItems.Count > 0, True, False))
      cmdDelete.Enabled = CBool(IIf(lvPromowani.SelectedItems.Count > 0, True, False))
    Else
      cmdAdd.Enabled = CBool(IIf(lvNiepromowani.SelectedItems.Count = lvNiepromowani.Items.Count, False, True))
      cmdDelete.Enabled = CBool(IIf(lvPromowani.SelectedItems.Count = lvNiepromowani.Items.Count, False, True))
    End If
  End Sub
End Class


Public Class PromocjaSQL
  Public Function CheckAssignment(ByVal RokSzkolny As String, ByVal IdSzkola As String) As String
    Return "SELECT u.ID FROM uczniowie u,przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND u.ID=p.IdUczen AND p.RokSzkolny='" & RokSzkolny & "' AND p.StatusAktywacji=1 AND sk.IdSzkola='" & IdSzkola & "';"
  End Function
  Public Function SelectStudent(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT u.ID,CONCAT_WS(' ',u.Nazwisko,u.Imie1) AS Student,p.Klasa,p.User,p.ComputerIP,p.Version,p.Promocja FROM uczniowie u,przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND u.ID=p.IdUczen AND p.RokSzkolny='" & RokSzkolny & "' AND p.StatusAktywacji=1 AND sk.IdSzkola='" & IdSzkola & "' AND sk.Virtual='" & Virtual & "' ORDER BY u.Nazwisko,u.Imie1;"
  End Function
  Public Function SelectMaxPion(ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT DISTINCT LEFT(MAX(sk.IdKlasa),1) FROM szkola_klasa sk WHERE sk.IdSzkola=" & IdSzkola & " AND sk.Virtual=" & Virtual & ";"
  End Function
  Public Function SelectKlasa(ByVal IdSzkola As String, ByVal RokSzkolny As String, ByVal Virtual As String) As String
    Return "SELECT DISTINCT p.Klasa FROM przydzial p INNER JOIN szkola_klasa sk ON p.Klasa=sk.IdKlasa WHERE p.RokSzkolny='" & RokSzkolny & "' AND sk.IdSzkola='" & IdSzkola & "' AND sk.Virtual='" & Virtual & "' ORDER BY p.Klasa ASC;"
  End Function
  Public Function UpdatePrzydzial(ByVal IdUczen As String, ByVal RokSzkolny As String, ByVal Promocja As String) As String
    Return "UPDATE przydzial p SET p.Promocja='" & Promocja & "',User='" + GlobalValues.gblUserName + "',ComputerIP='" + GlobalValues.gblIP + "',Version=NULL WHERE p.IdUczen='" & IdUczen & "' AND p.RokSzkolny='" & RokSzkolny & "' AND StatusAktywacji='1';"
  End Function
  'Public Function InsertPrzydzial(ByVal IdUczen As String, ByVal Klasa As String, ByVal RokSzkolny As String) As String
  '  Return "INSERT INTO przydzial VALUES(NULL,'" & IdUczen & "','" & Klasa & "','" & RokSzkolny & "',0,1,'" & Now.ToString() & "',NULL,1,'" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  'End Function
  'Public Function DeletePrzydzial(ByVal IdUczen As String, ByVal RokSzkolny As String) As String
  '  Return "DELETE FROM przydzial WHERE IdUczen='" & IdUczen & "' AND RokSzkolny='" & RokSzkolny & "' AND StatusAktywacji=1;"
  'End Function
End Class
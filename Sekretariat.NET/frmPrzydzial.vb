Public Class frmPrzydzial
  Private DS As DataSet ', MaxPion As Byte
  Private Sub FetchData()
    Dim P As New PrzydzialSQL, DBA As New DataBaseAction
    DS = DBA.GetDataSet(P.SelectStudent(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString) & P.SelectStudent((Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString) & P.SelectStudent((Me.nudStartYear.Value - 1).ToString & "/" & (Me.nudEndYear.Value - 1).ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString) & P.SelectStudentNoAssign)

  End Sub

  Private Sub LvNewItem(ByVal LV As ListView, ByVal Virtual As Integer, ByVal Klasa As String, ByVal Tablica As Integer)
    Dim Students() As DataRow
    Students = DS.Tables(Tablica).Select("Virtual=" & Virtual & " AND Klasa='" & Klasa & "'")
    Dim NG As New ListViewGroup(Klasa)
    LV.Groups.Add(NG)
    For j As Integer = 0 To Students.GetUpperBound(0)
      Dim NewItem As New ListViewItem(Students(j).Item(0).ToString, NG)
      NewItem.UseItemStyleForSubItems = True
      NewItem.ForeColor = CType(IIf(CType(Students(j).Item(8), Boolean), Color.Green, Color.LightCoral), Color)
      NewItem.SubItems.Add(Students(j).Item(1).ToString)
      NewItem.SubItems.Add(Students(j).Item(2).ToString)
      LV.Items.Add(NewItem)
    Next
  End Sub
  Private Overloads Sub GetData(ByVal cb As ComboBox, Optional ByVal Virtual As String = "0")
    Try
      If rbWszystkieKlasy.Checked Then
        If cb.Name = "cbKlasaNow" Then
          lvKlasaNow.Items.Clear()
          Me.lvKlasaNow.Groups.Clear()
          For i As Integer = 0 To cbKlasaNow.Items.Count - 1
            LvNewItem(lvKlasaNow, CType(Me.chkVirtualNow.CheckState, Integer), cbKlasaNow.Items(i).ToString, 0)
          Next
        Else
          lvKlasaNew.Items.Clear()
          Me.lvKlasaNew.Groups.Clear()
          If rbAssignNewYear.Checked Then
            For i As Integer = 0 To cbKlasaNew.Items.Count - 1
              LvNewItem(lvKlasaNew, CType(Me.chkVirtualNew.CheckState, Integer), cbKlasaNew.Items(i).ToString, 1)
            Next
          ElseIf rbReverseAssign.Checked Then
            For i As Integer = 0 To cbKlasaNew.Items.Count - 1
              LvNewItem(lvKlasaNew, CType(Me.chkVirtualNew.CheckState, Integer), cbKlasaNew.Items(i).ToString, 2)
            Next
          End If

        End If
      ElseIf rbWybranaKlasa.Checked Then
        If cb.Name = "cbKlasaNow" Then
          lvKlasaNow.Items.Clear()
          Me.lvKlasaNow.Groups.Clear()
          LvNewItem(lvKlasaNow, CType(Me.chkVirtualNow.CheckState, Integer), cb.Text, 0)
        Else
          lvKlasaNew.Items.Clear()
          Me.lvKlasaNew.Groups.Clear()
          If rbAssignNewYear.Checked Then
            LvNewItem(lvKlasaNew, CType(Me.chkVirtualNew.CheckState, Integer), cb.Text, 1)
          ElseIf rbReverseAssign.Checked Then
            LvNewItem(lvKlasaNew, CType(Me.chkVirtualNew.CheckState, Integer), cb.Text, 2)
          Else
            LvNewItem(lvKlasaNew, CType(Me.chkVirtualNew.CheckState, Integer), cb.Text, 0)
          End If
        End If
      Else
        lvKlasaNow.Items.Clear()
        Me.lvKlasaNow.Groups.Clear()
        For j As Integer = 0 To DS.Tables(3).Select().GetUpperBound(0)
          Dim NewItem As New ListViewItem(DS.Tables(3).Select()(j).Item(0).ToString)
          NewItem.SubItems.Add(DS.Tables(3).Select()(j).Item(1).ToString)
          NewItem.SubItems.Add(DS.Tables(3).Select()(j).Item(2).ToString)
          lvKlasaNow.Items.Add(NewItem)
        Next
      End If

      If cb.Name = "cbKlasaNow" Then
        lblRecord.Text = "0 z " & lvKlasaNow.Items.Count
        lvKlasaNow.Columns(1).Width = CInt(IIf(lvKlasaNow.Items.Count > 20, 285, 305))
        lvKlasaNow.Enabled = CBool(IIf(lvKlasaNow.Items.Count > 0, True, False))
      Else
        lblRecord1.Text = "0 z " & lvKlasaNew.Items.Count
        lvKlasaNew.Columns(1).Width = CInt(IIf(lvKlasaNew.Items.Count > 20, 285, 305))
        lvKlasaNew.Enabled = CBool(IIf(lvKlasaNew.Items.Count > 0, True, False))
      End If
    Catch ex As MySqlException
      MessageBox.Show(ex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      'R.Close()
    End Try
  End Sub
  
  Private Sub frmPrzydzial_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ListViewConfig(lvKlasaNew)
    ListViewConfig(lvKlasaNow)
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
  Sub SetYearLabel()
    lblCurrentYear.Text = String.Concat("[ ", nudStartYear.Value.ToString, "/", nudEndYear.Value.ToString, " ]")
    If rbAssignNewYear.Checked Then
      lblNewYear.Text = String.Concat("[ ", (nudStartYear.Value + 1).ToString, "/", (nudEndYear.Value + 1).ToString, " ]")
    ElseIf rbReverseAssign.Checked Then
      lblNewYear.Text = String.Concat("[ ", (nudStartYear.Value - 1).ToString, "/", (nudEndYear.Value - 1).ToString, " ]")
    Else
      lblNewYear.Text = String.Concat("[ ", nudStartYear.Value.ToString, "/", nudEndYear.Value.ToString, " ]")
    End If
  End Sub
  Private Sub nudStartYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudStartYear.ValueChanged
    If Not nudStartYear.Created Then Exit Sub
    Me.nudEndYear.Value = Me.nudStartYear.Value + 1
    SetYearLabel()
    If Not cbSzkola.SelectedItem Is Nothing Then
      Me.FetchData()
      RefreshData(cbKlasaNow, CType(Me.chkVirtualNow.CheckState, Integer).ToString)
      RefreshData(cbKlasaNew, CType(Me.chkVirtualNew.CheckState, Integer).ToString)
      Me.cmdMove.Enabled = False
      'Me.cmdMove.Enabled = False
    End If
  End Sub
  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    Me.FetchData()
    lvKlasaNew.Items.Clear()
    lvKlasaNow.Items.Clear()
    FillKlasa(cbKlasaNow, CType(Me.chkVirtualNow.CheckState, Integer).ToString)
    FillKlasa(cbKlasaNew, CType(Me.chkVirtualNew.CheckState, Integer).ToString)
    nudStartYear.Enabled = True
    chkVirtualNow.Enabled = True
    chkVirtualNew.Enabled = True
    Me.cmdMove.Enabled = False
    gpbZakres.Enabled = True
    gpbStatus.Enabled = True
    gpbOpcje.Enabled = True
    RefreshData(cbKlasaNow, CType(Me.chkVirtualNow.CheckState, Integer).ToString)
    RefreshData(cbKlasaNew, CType(Me.chkVirtualNew.CheckState, Integer).ToString)
    'rbWybranaKlasa_CheckedChanged(rbWszystkieKlasy, e)
  End Sub
  Private Overloads Sub FillKlasa(ByVal cb As ComboBox, ByVal Virtual As String)
    cb.Items.Clear()
    Dim FCB As New FillComboBox, P As New PrzydzialSQL
    FCB.AddComboBoxSimpleItems(cb, P.SelectClass(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Virtual))
  End Sub
  Private Overloads Sub FillKlasa(ByVal cb As ComboBox, ByVal Virtual As String, ByVal Pion As String)
    cb.Items.Clear()
    Dim FCB As New FillComboBox, P As New PrzydzialSQL
    FCB.AddComboBoxSimpleItems(cb, P.SelectClass(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Virtual, Pion))
  End Sub
  Private Overloads Sub FillKlasa(ByVal cb As ComboBox, ByVal Virtual As String, ByVal Pion1 As String, ByVal Pion2 As String)
    cb.Items.Clear()
    Dim FCB As New FillComboBox, P As New PrzydzialSQL
    FCB.AddComboBoxSimpleItems(cb, P.SelectClass(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Virtual, Pion1, Pion2))
  End Sub
  Private Sub chkVirtualNow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtualNow.CheckedChanged, chkVirtualNew.CheckedChanged

    If CType(sender, CheckBox).Name = "chkVirtualNow" Then
      cmdMove.Enabled = False
      FillKlasa(cbKlasaNow, CType(CType(sender, CheckBox).CheckState, Integer).ToString)
      If (cbKlasaNew.Text.Length = 0 AndAlso cbKlasaNow.Text.Length > 0) Then
        If (cbKlasaNow.Text.Substring(0, 1) <> cbKlasaNew.Text.Substring(0, 1)) Then
          FillKlasa(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString, cbKlasaNow.Text.Substring(0, 1))
          cbKlasaNew.Enabled = True
          chkVirtualNew.Enabled = True
        End If
      End If
      RefreshData(cbKlasaNow, CType(CType(sender, CheckBox).CheckState, Integer).ToString)
    Else
      cmdMove.Enabled = False
      If rbWybranaKlasa.Checked AndAlso cbKlasaNow.Text.Length > 0 Then
        If rbAssignNewYear.Checked Then
          FillKlasa(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString, cbKlasaNow.Text.Substring(0, 1))
          FillKlasa(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString, cbKlasaNow.Text.Substring(0, 1), (CType(cbKlasaNow.Text.Substring(0, 1), Integer) + 1).ToString)

        Else
          FillKlasa(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString, cbKlasaNow.Text.Substring(0, 1))

        End If
      Else
        FillKlasa(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString)

    End If
      RefreshData(cbKlasaNew, CType(CType(sender, CheckBox).CheckState, Integer).ToString)
    End If
  End Sub
  Private Sub RefreshData(ByVal cb As ComboBox, ByVal Virtual As String)
    cmdMove.Enabled = False
    cmdDelete.Enabled = False
    ClearDetails()
    GetData(cb, Virtual)
  End Sub
  Private Sub ClearDetails()
    lblUser.Text = ""
    lblIP.Text = ""
    lblData.Text = ""
  End Sub
  Private Sub GetDetails(ByVal ID As String, ByVal lv As ListView)
    Dim FoundRow() As DataRow
    Try
      If lv.Name = "lvKlasaNow" Then
        lblRecord.Text = lv.SelectedItems(0).Index + 1 & " z " & lv.Items.Count
        'If chkStudentBezKlasy.Checked Then
        '  FoundRow = DTnoAssignment.Select
        'Else
        FoundRow = DS.Tables(CType(IIf(rbNoAssign.Checked, 3, 0), Integer)).Select("IdUczen=" & ID)
        'End If
      Else
      lblRecord1.Text = lv.SelectedItems(0).Index + 1 & " z " & lv.Items.Count
      If rbAssignNewYear.Checked Then
        FoundRow = DS.Tables(1).Select("IdUczen=" & ID)
      ElseIf rbReverseAssign.Checked Then
        FoundRow = DS.Tables(2).Select("IdUczen=" & ID)
      Else
        FoundRow = DS.Tables(0).Select("IdUczen=" & ID)

      End If
      End If

      With FoundRow(0)
        lblUser.Text = .Item(3).ToString
        lblIP.Text = .Item(4).ToString
        lblData.Text = .Item(5).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub

  Private Sub cbKlasaNow_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbKlasaNow.SelectedIndexChanged, cbKlasaNew.SelectedIndexChanged
    If CType(sender, ComboBox).Name = "cbKlasaNow" Then
      If cbKlasaNew.Text.Length = 0 OrElse cbKlasaNow.Text.Substring(0, 1) <> cbKlasaNew.Text.Substring(0, 1) Then
        lvKlasaNew.Items.Clear()
        If rbChangeAssign.Checked Or rbReverseAssign.Checked Then
          FillKlasa(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString, cbKlasaNow.Text.Substring(0, 1))
        Else
          FillKlasa(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString, cbKlasaNow.Text.Substring(0, 1), (CType(cbKlasaNow.Text.Substring(0, 1), Integer) + 1).ToString)

        End If
        'Else
        'lvKlasaNew.Items.Clear()

      End If
      cbKlasaNew.Enabled = True
      chkVirtualNew.Enabled = True

    End If
    RefreshData(CType(sender, ComboBox), IIf(CType(sender, ComboBox).Name = "cbKlasaNow", CType(chkVirtualNow.CheckState, Integer), CType(chkVirtualNew.CheckState, Integer)).ToString)
  End Sub

  Private Sub lvKlasaObecna_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvKlasaNow.ItemSelectionChanged, lvKlasaNew.ItemSelectionChanged
    If e.IsSelected Then
      GetDetails(e.Item.Text, CType(sender, ListView))
      If CType(sender, ListView).Name = "lvKlasaNow" Then
        If rbWszystkieKlasy.Checked Then
          Me.cmdMove.Enabled = True
        Else
          If rbChangeAssign.Checked Then
            Me.cmdMove.Enabled = CType(IIf(cbKlasaNew.SelectedItem IsNot Nothing, IIf(cbKlasaNow.Text = cbKlasaNew.Text, False, True), False), Boolean)
          Else
            Me.cmdMove.Enabled = CType(IIf(cbKlasaNew.SelectedItem IsNot Nothing, True, False), Boolean)

          End If
        End If
        cmdDelete.Enabled = True
      Else
        Me.cmdMove.Enabled = False
        cmdDelete.Enabled = False
      End If
    Else
      ClearDetails()
      If CType(sender, ListView).Name = "lvKlasaNow" Then
        lblRecord.Text = "0 z " & CType(sender, ListView).Items.Count
      Else
        lblRecord1.Text = "0 z " & CType(sender, ListView).Items.Count
      End If
      Me.cmdMove.Enabled = False
      cmdDelete.Enabled = False
    End If
  End Sub

  Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMove.Click
    Dim MySQLTrans As MySqlTransaction
    MySQLTrans = GlobalValues.gblConn.BeginTransaction()
    Try

      If rbSelected.Checked Then
        If rbWszystkieKlasy.Checked Then
          For Each Item As ListViewItem In Me.lvKlasaNow.SelectedItems
            DoAssignment(Item, MySQLTrans)
          Next
        ElseIf rbWybranaKlasa.Checked Then
          For Each Item As ListViewItem In Me.lvKlasaNow.SelectedItems
            DoAssignmentForSelectedClass(Item, MySQLTrans)
          Next
        Else
          For Each Item As ListViewItem In Me.lvKlasaNow.SelectedItems
            DoAssignmentForNonAssign(Item, MySQLTrans)
          Next
        End If
      Else
        If rbWszystkieKlasy.Checked Then
          For Each Item As ListViewItem In Me.lvKlasaNow.Items
            If Item.Selected = False Then DoAssignment(Item, MySQLTrans)
          Next
        ElseIf rbWybranaKlasa.Checked Then
          For Each Item As ListViewItem In Me.lvKlasaNow.Items
            If Item.Selected = False Then DoAssignmentForSelectedClass(Item, MySQLTrans)
          Next
        Else
          For Each Item As ListViewItem In Me.lvKlasaNow.Items
            If Item.Selected = False Then DoAssignmentForNonAssign(Item, MySQLTrans)
          Next
        End If
      End If

      MySQLTrans.Commit()
      FetchData()

      RefreshData(cbKlasaNow, CType(chkVirtualNow.CheckState, Integer).ToString)
      RefreshData(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString)

    Catch Myex As MySqlException
      MySQLTrans.Rollback()
      MessageBox.Show("Rodzaj błędu:" & vbNewLine & Myex.Message & vbNewLine & "Wszystkie operacje na bazie danych zostały cofnięte.")
    End Try
  End Sub
  Private Sub DoAssignmentForNonAssign(ByVal Item As ListViewItem, ByVal MySQLTrans As MySqlTransaction)
    Dim DBA As New DataBaseAction, P As New PrzydzialSQL
    Dim cmd As MySqlCommand
    If rbAssignNewYear.Checked Then
      cmd = DBA.CreateCommand(P.InsertPrzydzial(Item.Text, cbKlasaNew.Text, (Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString))
      cmd.Transaction = MySQLTrans
      cmd.ExecuteNonQuery()
    ElseIf rbReverseAssign.Checked Then
      cmd = DBA.CreateCommand(P.InsertPrzydzial(Item.Text, cbKlasaNew.Text, (Me.nudStartYear.Value - 1).ToString & "/" & (Me.nudEndYear.Value - 1).ToString))
      cmd.Transaction = MySQLTrans
      cmd.ExecuteNonQuery()
    Else
      cmd = DBA.CreateCommand(P.InsertPrzydzial(Item.Text, cbKlasaNew.Text, (Me.nudStartYear.Value).ToString & "/" & (Me.nudEndYear.Value).ToString))
      cmd.Transaction = MySQLTrans
      cmd.ExecuteNonQuery()
    End If
  End Sub
  Private Sub DoAssignmentForSelectedClass(ByVal Item As ListViewItem, ByVal MySQLTrans As MySqlTransaction)
    Dim DBA As New DataBaseAction, P As New PrzydzialSQL
    Dim cmd As MySqlCommand
    If rbAssignNewYear.Checked Then
      If Not CType(DS.Tables(0).Select("IdUczen=" & Item.Text)(0).Item(8), Boolean) Then
        If cbKlasaNow.Text.Substring(0, 1) = cbKlasaNew.Text.Substring(0, 1) Then
          If Not DBA.CountRecords(P.CountAssignment(Item.Text, CType(cbKlasaNew.Text.Substring(0, 1), Integer), String.Concat((nudStartYear.Value + 1).ToString, "/", (nudEndYear.Value + 1).ToString))) > 0 Then
            cmd = DBA.CreateCommand(P.InsertPrzydzial(Item.Text, cbKlasaNew.Text, (Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString))
            cmd.Transaction = MySQLTrans
            cmd.ExecuteNonQuery()
          Else
            MessageBox.Show("Uczeń " & Item.SubItems(1).Text & " posiada już przydział na rok szkolny " & (Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString)
          End If
        Else
          MessageBox.Show("Nie można przydzielić ucznia niepromowanego do klasy programowo wyższej.")
        End If

      Else
        If cbKlasaNow.Text.Substring(0, 1) <> cbKlasaNew.Text.Substring(0, 1) Then
          If Not DBA.CountRecords(P.CountAssignment(Item.Text, CType(cbKlasaNew.Text.Substring(0, 1), Integer), String.Concat((nudStartYear.Value + 1).ToString, "/", (nudEndYear.Value + 1).ToString))) > 0 Then
            cmd = DBA.CreateCommand(P.InsertPrzydzial(Item.Text, cbKlasaNew.Text, (Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString))
            cmd.Transaction = MySQLTrans
            cmd.ExecuteNonQuery()
          Else
            MessageBox.Show("Uczeń " & Item.SubItems(1).Text & " posiada już przydział na rok szkolny " & (Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString)
          End If
        Else
          MessageBox.Show("Nie można przydzielić ucznia promowanego do klasy równoległej.")
        End If
      End If
    ElseIf rbReverseAssign.Checked Then
      If Not DBA.CountRecords(P.CountAssignment(Item.Text, String.Concat((nudStartYear.Value - 1).ToString, "/", (nudEndYear.Value - 1).ToString))) > 0 Then
        cmd = DBA.CreateCommand(P.InsertPrzydzial(Item.Text, cbKlasaNew.Text, (Me.nudStartYear.Value - 1).ToString & "/" & (Me.nudEndYear.Value - 1).ToString))
        cmd.Transaction = MySQLTrans
        cmd.ExecuteNonQuery()
      Else
        MessageBox.Show("Uczeń " & Item.SubItems(1).Text & " posiada już przydział na rok szkolny " & (Me.nudStartYear.Value - 1).ToString & "/" & (Me.nudEndYear.Value - 1).ToString)
      End If
    Else
      If Not DBA.CountRecords(P.CountAssignment(Item.Text, String.Concat((nudStartYear.Value + 1).ToString, "/", (nudEndYear.Value + 1).ToString))) > 0 Then
        cmd = DBA.CreateCommand(P.UpdatePrzydzial(Item.Text, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString))
        cmd.Transaction = MySQLTrans
        cmd.ExecuteNonQuery()
        If DBA.CountRecords(P.CountAssignment(Item.Text, cbKlasaNew.Text, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString)) > 0 Then
          cmd.CommandText = P.UpdatePrzydzial(Item.Text, cbKlasaNew.Text, (Me.nudStartYear.Value).ToString & "/" & (Me.nudEndYear.Value).ToString)
        Else
          cmd.CommandText = P.InsertPrzydzial(Item.Text, cbKlasaNew.Text, (Me.nudStartYear.Value).ToString & "/" & (Me.nudEndYear.Value).ToString)
        End If
        cmd.ExecuteNonQuery()
      Else
        MessageBox.Show("Nie można zmienić przydziału ucznia " & Item.SubItems(1).Text & ", ponieważ posiada on już przydział na rok szkolny " & (Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString)
      End If
    End If
  End Sub
  Private Sub DoAssignment(ByVal Item As ListViewItem, ByVal MySQLTrans As MySqlTransaction)
    Dim DBA As New DataBaseAction, P As New PrzydzialSQL
    Dim cmd As MySqlCommand = Nothing
    If rbAssignNewYear.Checked Then
      If Not CType(DS.Tables(0).Select("IdUczen=" & Item.Text)(0).Item(8), Boolean) Then
        If Not DBA.CountRecords(P.CountAssignment(Item.Text, CType(Item.SubItems(2).Text.Substring(0, 1), Integer), String.Concat((nudStartYear.Value + 1).ToString, "/", (nudEndYear.Value + 1).ToString))) > 0 Then
          cmd = DBA.CreateCommand(P.InsertPrzydzial(Item.Text, Item.SubItems(2).Text, (Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString).ToString)
          cmd.Transaction = MySQLTrans
          cmd.ExecuteNonQuery()
        Else
          MessageBox.Show("Uczeń " & Item.SubItems(1).Text & " posiada już przydział na rok szkolny " & (Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString)
        End If
      Else
        'If CType(Item.SubItems(2).Text.Substring(0, 1), Byte) <> MaxPion Then
        If Not DBA.CountRecords(P.CountAssignment(Item.Text, CType(Item.SubItems(2).Text.Substring(0, 1), Integer) + 1, String.Concat((nudStartYear.Value + 1).ToString, "/", (nudEndYear.Value + 1).ToString))) > 0 Then
          cmd = DBA.CreateCommand(P.InsertPrzydzial(Item.Text, String.Concat((CType(Item.SubItems(2).Text.Substring(0, 1), Integer) + 1).ToString, Item.SubItems(2).Text.Substring(1, 1)), (Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString))
          cmd.Transaction = MySQLTrans
          cmd.ExecuteNonQuery()
        Else
          MessageBox.Show("Uczeń " & Item.SubItems(1).Text & " posiada już przydział na rok szkolny " & (Me.nudStartYear.Value + 1).ToString & "/" & (Me.nudEndYear.Value + 1).ToString)
        End If
        'End If
      End If
    ElseIf rbReverseAssign.Checked Then
      If (Not DBA.CountRecords(P.CountAssignment(Item.Text, CType(Item.SubItems(2).Text.Substring(0, 1), Integer) - 1, String.Concat((nudStartYear.Value - 1).ToString, "/", (nudEndYear.Value - 1).ToString))) > 0) Or (Not DBA.CountRecords(P.CountAssignment(Item.Text, CType(Item.SubItems(2).Text.Substring(0, 1), Integer), String.Concat((nudStartYear.Value - 1).ToString, "/", (nudEndYear.Value - 1).ToString))) > 0) Then
        cmd = DBA.CreateCommand(P.InsertPrzydzial(Item.Text, Item.SubItems(2).Text, (Me.nudStartYear.Value - 1).ToString & "/" & (Me.nudEndYear.Value - 1).ToString))
        cmd.Transaction = MySQLTrans
        cmd.ExecuteNonQuery()
      Else
        MessageBox.Show("Uczeń " & Item.SubItems(1).Text & " posiada już przydział na rok szkolny " & (Me.nudStartYear.Value - 1).ToString & "/" & (Me.nudEndYear.Value - 1).ToString)
      End If
    End If
  End Sub
  'Private Sub GetMaxPion()
  '  Dim DBA As New DataBaseAction, P As New PrzydzialSQL
  '  MaxPion = CType(DBA.GetMaxValue(P.SelectMaxPion(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtualNow.CheckState, Integer).ToString)), Byte)
  'End Sub
  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    Dim DBA As New DataBaseAction, P As New PrzydzialSQL
    Try
      For Each Item As ListViewItem In lvKlasaNow.SelectedItems
        DBA.ApplyChanges(P.DeletePrzydzial(DS.Tables(0).Select("IdUczen=" & Item.Text & " AND Klasa='" & Item.SubItems(2).Text & "'")(0).Item("IdPrzydzial").ToString))
      Next
      FetchData()
      RefreshData(cbKlasaNow, CType(chkVirtualNow.CheckState, Integer).ToString)
    Catch mex As MySqlException
      MessageBox.Show(mex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub
  Private Sub rbWybranaKlasa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWybranaKlasa.CheckedChanged, rbWszystkieKlasy.CheckedChanged, rbNoAssign.CheckedChanged
    If Not Me.Created Then Exit Sub
    If CType(sender, RadioButton).Checked Then
      cbKlasaNow.Enabled = CBool(IIf(rbWybranaKlasa.Checked, True, False))
      chkVirtualNow.Enabled = CBool(IIf(rbWybranaKlasa.Checked, True, False))
      cbKlasaNew.Enabled = CBool(IIf(rbWszystkieKlasy.Checked, False, True))
      chkVirtualNew.Enabled = CBool(IIf(rbWszystkieKlasy.Checked, False, True))
      cbSzkola.Enabled = CBool(IIf(rbNoAssign.Checked, False, True))
      nudStartYear.Enabled = CBool(IIf(rbNoAssign.Checked, False, True))
      rbChangeAssign.Enabled = CBool(IIf(rbWszystkieKlasy.Checked, False, True))
      If rbNoAssign.Checked Then FillKlasa(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString)
      If rbWszystkieKlasy.Checked AndAlso rbChangeAssign.Checked Then rbAssignNewYear.Checked = True
      RefreshData(cbKlasaNow, CType(chkVirtualNow.CheckState, Integer).ToString)
      If rbNoAssign.Checked = False Then RefreshData(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString)
    End If
  End Sub

  Private Sub rbChangeAssign_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbChangeAssign.CheckedChanged, rbAssignNewYear.CheckedChanged, rbReverseAssign.CheckedChanged
    If Not Created OrElse CType(sender, RadioButton).Checked = False Then Exit Sub
    SetYearLabel()
    If CType(sender, RadioButton).Name = "rbChangeAssign" Or CType(sender, RadioButton).Name = "rbReverseAssign" Then
      If cbKlasaNow.SelectedItem IsNot Nothing Then FillKlasa(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString, cbKlasaNow.Text.Substring(0, 1))
    Else
      If cbKlasaNow.SelectedItem IsNot Nothing Then FillKlasa(cbKlasaNew, CType(chkVirtualNew.CheckState, Integer).ToString, cbKlasaNow.Text.Substring(0, 1), (CType(cbKlasaNow.Text.Substring(0, 1), Integer) + 1).ToString)
    End If
    RefreshData(cbKlasaNew, CType(chkVirtualNow.CheckState, Integer).ToString)
  End Sub

  Private Sub rbUnselected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbUnselected.CheckedChanged, rbSelected.CheckedChanged
    If Not Created OrElse CType(sender, RadioButton).Checked = False Then Exit Sub
    If CType(sender, RadioButton).Name = "rbUnselected" AndAlso lvKlasaNow.Items.Count > 0 Then
      cmdMove.Enabled = True
    Else
      If lvKlasaNow.SelectedItems.Count > 0 Then
        cmdMove.Enabled = True
      Else
        cmdMove.Enabled = False
      End If
    End If
  End Sub
End Class


Public Class PrzydzialSQL
  Public Function SelectStudent(ByVal RokSzkolny As String, ByVal IdSzkola As String) As String
    Return "SELECT u.ID AS IdUczen,CONCAT_WS(' ',u.Nazwisko,u.Imie1) AS Student,p.Klasa,p.User,p.ComputerIP,p.Version,sk.Virtual,p.ID AS IdPrzydzial,p.Promocja FROM uczniowie u,przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND u.ID=p.IdUczen AND p.RokSzkolny='" & RokSzkolny & "' AND p.StatusAktywacji=1 AND sk.IdSzkola='" & IdSzkola & "' ORDER BY u.Nazwisko,u.Imie1;"
  End Function
  Public Function SelectStudentNoAssign() As String
    Return "SELECT u.`ID` AS IdUczen,CONCAT_WS(' ',u.Nazwisko,u.Imie1) AS Student,null,u.User,u.ComputerIP,u.Version FROM uczniowie u WHERE ID NOT IN (SELECT DISTINCT IdUczen FROM przydzial p)"
  End Function
  Public Overloads Function SelectClass(ByVal School As String, ByVal Virtual As String) As String
    Return "SELECT IdKlasa FROM szkola_klasa sk WHERE sk.Virtual='" & Virtual & "' AND sk.IdSzkola='" & School & "';"
  End Function
  Public Overloads Function SelectClass(ByVal School As String, ByVal Virtual As String, ByVal Pion As String) As String
    Return "SELECT IdKlasa FROM szkola_klasa sk WHERE sk.Virtual='" & Virtual & "' AND sk.IdSzkola='" & School & "'  AND LEFT(IdKlasa,1)='" & Pion & "';"
  End Function
  Public Overloads Function SelectClass(ByVal School As String, ByVal Virtual As String, ByVal Pion1 As String, ByVal Pion2 As String) As String
    Return "SELECT IdKlasa FROM szkola_klasa sk WHERE sk.Virtual='" & Virtual & "' AND sk.IdSzkola='" & School & "'  AND LEFT(IdKlasa,1)='" & Pion1 & "' OR LEFT(IdKlasa,1)='" & Pion2 & "';"
  End Function
  'Public Function SelectMaxPion(ByVal IdSzkola As String, ByVal Virtual As String) As String
  '  Return "SELECT DISTINCT LEFT(MAX(sk.IdKlasa),1) FROM szkola_klasa sk WHERE sk.IdSzkola=" & IdSzkola & " AND sk.Virtual=" & Virtual & ";"
  'End Function
  Public Overloads Function CountAssignment(ByVal IdUczen As String, ByVal Klasa As String, ByVal RokSzkolny As String) As String
    Return "SELECT COUNT(ID) FROM przydzial p WHERE IdUczen='" & IdUczen & "' AND Klasa='" & Klasa & "' AND RokSzkolny='" & RokSzkolny & "';"
  End Function
  Public Overloads Function CountAssignment(ByVal IdUczen As String, ByVal Pion As Integer, ByVal RokSzkolny As String) As String
    Return "SELECT COUNT(ID) FROM przydzial p WHERE IdUczen='" & IdUczen & "' AND LEFT(Klasa,1)=" & Pion & " AND RokSzkolny='" & RokSzkolny & "';"
  End Function
  Public Overloads Function CountAssignment(ByVal IdUczen As String, ByVal RokSzkolny As String) As String
    Return "SELECT COUNT(ID) FROM przydzial p WHERE IdUczen='" & IdUczen & "' AND RokSzkolny='" & RokSzkolny & "';"
  End Function
  Public Overloads Function UpdatePrzydzial(ByVal IdUczen As String, ByVal RokSzkolny As String) As String
    Return "UPDATE przydzial p SET p.StatusAktywacji='0',p.MasterRecord='0',DataDeaktywacji='" & Now.ToString() & "',User='" + GlobalValues.gblUserName + "',ComputerIP='" + GlobalValues.gblIP + "',Version=NULL WHERE p.IdUczen='" & IdUczen & "' AND p.RokSzkolny='" & RokSzkolny & "' AND StatusAktywacji='1';"
  End Function
  Public Overloads Function UpdatePrzydzial(ByVal IdUczen As String, ByVal Klasa As String, ByVal RokSzkolny As String) As String
    Return "UPDATE przydzial p SET p.StatusAktywacji='1',p.MasterRecord='1',DataAktywacji='" & Now.ToString & "',User='" + GlobalValues.gblUserName + "',ComputerIP='" + GlobalValues.gblIP + "',Version=NULL WHERE p.IdUczen='" & IdUczen & "' AND p.RokSzkolny='" & RokSzkolny & "' AND p.Klasa='" & Klasa & "';"
  End Function
  Public Function InsertPrzydzial(ByVal IdUczen As String, ByVal Klasa As String, ByVal RokSzkolny As String) As String
    Return "INSERT INTO przydzial VALUES(NULL,'" & IdUczen & "','" & Klasa & "','" & RokSzkolny & "',NULL,0,1,'" & Now.ToString() & "',NULL,1,'" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  Public Function DeletePrzydzial(ByVal IdPrzydzial As String) As String
    Return "DELETE FROM przydzial WHERE ID='" & IdPrzydzial & "';"
  End Function
End Class
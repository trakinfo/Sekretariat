Imports System.Drawing.Printing
Public Class frmWychowawca
  Private DT As DataTable
  Public Event NewRow()
  Private Sub FetchData(Optional ByVal NoAssignment As Boolean = False)
    Dim P As New WychowawcaSQL, DBA As New DataBaseAction
    DT = DBA.GetDataTable(P.SelectWychowawca(Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString, CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString))

  End Sub
  Private Overloads Sub GetData()
    Try
      lvWychowawca.Items.Clear()
      For j As Integer = 0 To DT.Select().GetUpperBound(0)
        Dim NewItem As New ListViewItem(DT.Select()(j).Item(0).ToString)
        NewItem.SubItems.Add(DT.Select()(j).Item(1).ToString)
        lvWychowawca.Items.Add(NewItem)
      Next

      lblRecord.Text = "0 z " & lvWychowawca.Items.Count
      lvWychowawca.Columns(1).Width = CInt(IIf(lvWychowawca.Items.Count > 26, 285, 305))
      lvWychowawca.Enabled = CBool(IIf(lvWychowawca.Items.Count > 0, True, False))

    Catch ex As MySqlException
      MessageBox.Show(ex.Message)
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      'R.Close()
    End Try
  End Sub
  Private Sub frmWychowawca_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ListViewConfig(lvWychowawca)
    lblRecord.Text = ""
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
      '.Columns.Add("ID", 0, HorizontalAlignment.Center)
      .Columns.Add("Klasa", 50, HorizontalAlignment.Center)
      .Columns.Add("Nazwisko i imię", 309, HorizontalAlignment.Left)
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
      GetData()
      Me.cmdAdd.Enabled = True
      cmdEdit.Enabled = False
      Me.cmdDelete.Enabled = False
    End If
  End Sub
  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    Me.FetchData()
    GetData()
    nudStartYear.Enabled = True
    chkVirtual.Enabled = True
    Me.cmdAdd.Enabled = True
    cmdEdit.Enabled = False
    Me.cmdDelete.Enabled = False
    cmdPrint.Enabled = True
  End Sub
  Private Sub chkVirtual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtual.CheckedChanged
    ClearDetails()
    FetchData()
    GetData()
    cmdAdd.Enabled = True
    cmdEdit.Enabled = False
    cmdDelete.Enabled = False
  End Sub

  Private Sub ClearDetails()
    lblUser.Text = ""
    lblIP.Text = ""
    lblData.Text = ""
  End Sub
  Private Sub GetDetails(ByVal Klasa As String)
    'Dim FoundRow() As DataRow
    Try
      lblRecord.Text = lvWychowawca.SelectedItems(0).Index + 1 & " z " & lvWychowawca.Items.Count
      'FoundRow = DT.Select("ID=" & ID)

      With DT.Select("Klasa='" & Klasa & "'")(0) 'FoundRow(0)
        lblUser.Text = .Item(2).ToString
        lblIP.Text = .Item(3).ToString
        lblData.Text = .Item(4).ToString
      End With
    Catch err As Exception
      MessageBox.Show(err.Message)
    End Try
  End Sub

  Private Sub lvWychowawca_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvWychowawca.DoubleClick
    EditData()
  End Sub

  Private Sub lvWychowawca_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvWychowawca.ItemSelectionChanged
    If e.IsSelected Then
      GetDetails(e.Item.Text)
      Me.cmdAdd.Enabled = True
      cmdEdit.Enabled = True
      Me.cmdDelete.Enabled = True
    Else
      ClearDetails()
      lblRecord.Text = "0 z " & CType(sender, ListView).Items.Count
      Me.cmdAdd.Enabled = True
      cmdEdit.Enabled = False
      Me.cmdDelete.Enabled = False
    End If
  End Sub

  Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
    Try
      Dim dlgAddNew As New dlgWychowawca, W As New WychowawcaSQL
      Dim FCB As New FillComboBox ', SH As New SeekHelper
      FCB.AddComboBoxSimpleItems(dlgAddNew.cbKlasa, W.SelectClass(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString, nudStartYear.Value.ToString))
      FCB.AddComboBoxComplexItems(dlgAddNew.cbBelfer, W.SelectBelfer(CType(cbSzkola.SelectedItem, CbItem).ID.ToString))
      dlgAddNew.RokSzkolny = Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString
      dlgAddNew.Szkola = CType(cbSzkola.SelectedItem, CbItem).ID.ToString
      dlgAddNew.Virtual = CType(chkVirtual.CheckState, Integer).ToString
      If DT.Select().GetLength(0) > 0 Then
        dlgAddNew.IdPrzedmiot = DT.Select()(0).Item("IdPrzedmiot").ToString
      Else
        Dim DBA As New DataBaseAction
        Dim R As MySqlDataReader = DBA.GetReader("SELECT ID FROM przedmioty WHERE Typ='z';")
        If R.HasRows Then
          R.Read()
          dlgAddNew.IdPrzedmiot = R.Item(0).ToString
          R.Close()
        Else
          R.Close()
          Throw New System.Exception("Nie można przydzielić wychowawstwa." & vbNewLine & "Brak zdefiniowanego typu przedmiotu, oznaczającego wychowawstwo." & vbNewLine & "Oznacz jeden z przedmiotów jako typ 'z' i spróbuj ponownie.")
        End If
      End If
      dlgAddNew.Text = "Przydział wychowawstwa"
      dlgAddNew.MdiParent = Me.MdiParent
      dlgAddNew.MaximizeBox = False
      dlgAddNew.StartPosition = FormStartPosition.CenterScreen
      'dlgAddNew.Opacity = 0.7
      dlgAddNew.Show()
      AddHandler dlgAddNew.NewWychowawcaAdded, AddressOf NewWychowawcaAdded
      AddHandler dlgAddNew.FormClosed, AddressOf EnableCmdAddNew
      Me.cmdAdd.Enabled = False

    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally

    End Try
  End Sub
  Private Sub EnableCmdAddNew(ByVal sender As Object, ByVal e As FormClosedEventArgs)
    Me.cmdAdd.Enabled = True
  End Sub
  Private Sub NewWychowawcaAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedKlasa As String)
    Me.FetchData()
    GetData()
    Dim SH As New SeekHelper
    SH.FindListViewItem(Me.lvWychowawca, InsertedKlasa)
  End Sub
  Private Sub EditData()
    Try
      Dim dlgEdit As New dlgWychowawca, W As New WychowawcaSQL
      Dim FCB As New FillComboBox
      FCB.AddComboBoxSimpleItems(dlgEdit.cbKlasa, W.SelectAllClass(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, CType(chkVirtual.CheckState, Integer).ToString))
      dlgEdit.cbKlasa.Enabled = False

      FCB.AddComboBoxComplexItems(dlgEdit.cbBelfer, W.SelectBelfer(CType(cbSzkola.SelectedItem, CbItem).ID.ToString))
      dlgEdit.cbBelfer.AutoCompleteSource = AutoCompleteSource.ListItems
      dlgEdit.cbBelfer.AutoCompleteMode = AutoCompleteMode.Append

      With dlgEdit
        .Text = "Edycja przydziału wychowawstwa"
        Dim SH As New SeekHelper
        SH.FindComboItem(.cbKlasa, Me.lvWychowawca.SelectedItems(0).Text)
        SH.FindComboItem(.cbBelfer, CType(DT.Select("Klasa='" & lvWychowawca.SelectedItems(0).Text & "'")(0).Item("IdWychowawca"), Integer))
        .CancelButton = .Cancel_Button
        .AcceptButton = .OK_Button

        If dlgEdit.ShowDialog = Windows.Forms.DialogResult.OK Then
          Dim DBA As New DataBaseAction, Klasa As String
          Dim MySQLTrans As MySqlTransaction

          Klasa = Me.lvWychowawca.SelectedItems(0).Text
          Dim cmd As MySqlCommand = DBA.CreateCommand(W.UpdateWychowawca(Klasa, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString))
          MySQLTrans = GlobalValues.gblConn.BeginTransaction()
          cmd.Transaction = MySQLTrans
          Try
            cmd.Parameters.AddWithValue("?IdBelfer", CType(.cbBelfer.SelectedItem, CbItem).ID)
            cmd.ExecuteNonQuery()
            MySQLTrans.Commit()

          Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            MySQLTrans.Rollback()
          End Try
          Me.FetchData()
          GetData()
          Me.EnableButtons(False)
          SH.FindListViewItem(Me.lvWychowawca, Klasa)
        End If
      End With
    Catch ex As Exception

      MessageBox.Show(ex.Message)
    End Try

  End Sub

  Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
    EditData()
  End Sub
  Private Sub EnableButtons(ByVal Value As Boolean)
    Me.cmdDelete.Enabled = Value
    Me.cmdEdit.Enabled = Value
  End Sub

  Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    Dim DBA As New DataBaseAction, W As New WychowawcaSQL, DeletedIndex As Integer
    Dim MySQLTrans As MySqlTransaction
    MySQLTrans = GlobalValues.gblConn.BeginTransaction()
    Try
      For Each Item As ListViewItem In Me.lvWychowawca.SelectedItems
        DeletedIndex = Item.Index
        Dim cmd As MySqlCommand = DBA.CreateCommand(W.DeleteWychowawca(Item.Text, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString))
        cmd.Transaction = MySQLTrans
        cmd.ExecuteNonQuery()

        'DBA.ApplyChanges(W.DeleteWychowawca(Item.Text, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString))
      Next
      MySQLTrans.Commit()
      Me.FetchData()
      GetData()
      Dim SH As New SeekHelper
      Me.EnableButtons(False)
      SH.FindRemovedListViewItemIndex(Me.lvWychowawca, DeletedIndex)
    Catch mex As MySqlException
      MessageBox.Show(mex.Message)
      MySQLTrans.Rollback()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
    Dim PP As New dlgPrintPreview, DS As New DataSet
    DS.Tables.Add(DT)
    PP.Doc = New PrintReport(DS)
    AddHandler PP.Doc.PrintPage, AddressOf PrnDoc_PrintPage
    AddHandler NewRow, AddressOf PP.NewRow
    PP.Doc.ReportHeader = New String() {"Przydział wychowawstw"}
    'PP.Doc.Offset(1) = 2
    If PP.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      DS.Tables.Remove(DT)
    End If
  End Sub
  Public Sub PrnDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) 'Handles Doc.PrintPage
    Dim Doc As PrintReport = CType(sender, PrintReport)
    Dim x As Single = Doc.DefaultPageSettings.Margins.Left - Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Left
    Dim y As Single = Doc.DefaultPageSettings.Margins.Top - Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Top
    Dim PrnVars As New PrintVariables
    Dim TextFont As Font = PrnVars.BaseFont
    Dim HeaderFont As Font = PrnVars.HeaderFont
    Dim LineHeight As Single = TextFont.GetHeight(e.Graphics)
    Dim HeaderLineHeight As Single = HeaderFont.GetHeight(e.Graphics)

    Doc.PageNumber += 1
    Doc.DrawText(e, "- " & Doc.PageNumber & " -", TextFont, x, Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Top + LineHeight, e.MarginBounds.Width, LineHeight, 1, Brushes.Black, False)
    If Doc.PageNumber = 1 Then
      y += LineHeight
      Doc.DrawText(e, Doc.ReportHeader(0), HeaderFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 1, Brushes.Black, False)
      y += LineHeight * 2
      Doc.DrawText(e, "Szkoła: " & cbSzkola.Text, TextFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 0, Brushes.Black, False)
      y += LineHeight
      Doc.DrawText(e, "Rok szkolny: " & String.Concat(nudStartYear.Value.ToString, "/", nudEndYear.Value.ToString), TextFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 0, Brushes.Black, False)
      y += LineHeight * 3
    End If

    'PrintColumnsHeaders(e, x, y, TextFont, LineHeight)
    Doc.DrawText(e, "L.p.", PrnVars.BoldFont, x, y, 40, LineHeight * 2, 1, Brushes.Black)
    Doc.DrawText(e, "Klasa", PrnVars.BoldFont, x + 40, y, 60, LineHeight * 2, 1, Brushes.Black)
    Doc.DrawText(e, "Wychowawca", PrnVars.BoldFont, x + 100, y, 300, LineHeight * 2, 1, Brushes.Black)
    y += LineHeight * 2

    Do Until (y + LineHeight) > e.MarginBounds.Bottom Or Doc.Offset(0) > Doc.DS.Tables(0).Select().GetUpperBound(0)
      Doc.Lp += 1
      Doc.DrawText(e, Doc.Lp.ToString, TextFont, x, y, 40, LineHeight, 1, Brushes.Black)
      Doc.DrawText(e, Doc.DS.Tables(0).Select()(Doc.Offset(0)).Item(0).ToString, TextFont, x + 40, y, 60, LineHeight, 1, Brushes.Black)
      Doc.DrawText(e, Doc.DS.Tables(0).Select()(Doc.Offset(0)).Item(1).ToString, TextFont, x + 100, y, 300, LineHeight, 0, Brushes.Black)
      y += LineHeight

      Doc.Offset(0) += 1
    Loop

    If Doc.Offset(0) <= Doc.DS.Tables(0).Select().GetLength(0) - 1 Then
      e.HasMorePages = True
      RaiseEvent NewRow()
    End If

  End Sub
End Class

Public Class WychowawcaSQL
  Public Function SelectWychowawca(ByVal RokSzkolny As String, ByVal IdSzkola As String, ByVal Virtual As String) As String
    Return "SELECT o.Klasa,Concat_WS(' ',b.Nazwisko,b.Imie) AS Wychowawca,o.User,o.ComputerIP,o.Version,p.ID AS IdPrzedmiot,b.ID AS IdWychowawca FROM obsada o,belfer b,przedmioty p,szkola_klasa sk WHERE o.IdBelfer=b.ID AND o.IdPrzedmiot=p.ID AND o.Klasa=sk.IdKlasa AND p.Typ='z' AND sk.IdSzkola='" & IdSzkola & "' AND sk.Virtual='" & Virtual & "' AND o.RokSzkolny='" & RokSzkolny & "' ORDER BY o.Klasa;"
  End Function
  Public Function SelectClass(ByVal School As String, ByVal Virtual As String, ByVal RokSzkolny As String) As String
    Return "SELECT IdKlasa FROM szkola_klasa sk WHERE sk.Virtual='" & Virtual & "' AND sk.IdSzkola='" & School & "' AND sk.IdKlasa NOT IN (SELECT Klasa FROM obsada WHERE LEFT(RokSzkolny,4)='" & RokSzkolny & "' AND IdPrzedmiot IN (SELECT ID FROM przedmioty WHERE Typ='z'));"
  End Function
  Public Function SelectAllClass(ByVal School As String, ByVal Virtual As String) As String
    Return "SELECT IdKlasa FROM szkola_klasa sk WHERE sk.Virtual='" & Virtual & "' AND sk.IdSzkola='" & School & "';"
  End Function
  Public Function SelectBelfer(ByVal IdSzkola As String) As String
    Return "SELECT b.ID,CONCAT_WS(' ',b.Nazwisko,b.Imie) AS Wychowawca FROM belfer b,szkola_belfer sb WHERE b.ID=sb.IdBelfer AND sb.IdSzkola='" & IdSzkola & "' ORDER BY b.Nazwisko,b.Imie;"
  End Function
  Public Function InsertWychowawca() As String
    Return "INSERT INTO obsada VALUES(?Klasa,?IdPrzedmiot,?IdBelfer,?RokSzkolny,NULL,'" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  Public Function UpdateWychowawca(ByVal Klasa As String, ByVal RokSzkolny As String) As String
    Return "UPDATE obsada SET IdBelfer=?IdBelfer,User='" + GlobalValues.gblUserName + "',ComputerIP='" + GlobalValues.gblIP + "',Version=NULL WHERE Klasa='" & Klasa & "' AND RokSzkolny='" & RokSzkolny & "';"
  End Function
  Public Function DeleteWychowawca(ByVal Klasa As String, ByVal RokSzkolny As String) As String
    Return "DELETE FROM obsada WHERE  Klasa='" & Klasa & "' AND RokSzkolny='" & RokSzkolny & "' AND IdPrzedmiot IN (SELECT ID FROM przedmioty WHERE Typ='z');"
  End Function
End Class


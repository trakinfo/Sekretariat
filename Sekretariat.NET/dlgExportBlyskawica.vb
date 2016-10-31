Imports System.Windows.Forms

Public Class dlgExportBlyskawica
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
      '.Columns.Add("ID", 0, HorizontalAlignment.Left)
      .Columns.Add("Klasa", 117, HorizontalAlignment.Center)
      '.Columns.Add("Pełna nazwa", 200, HorizontalAlignment.Left)
    End With
  End Sub
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Me.Close()
    'Me.OK_Button.Enabled = False
    ''Me.cmdCancel.Enabled = False
    'Me.ControlBox = False
    'Me.txtDetails.Text = ""
    'Dim Ex As New ExportXML
    ''Dim Klasa As New Queue
    'ReDim Ex.Klasa(lvKlasa.SelectedItems.Count - 1)
    'For i As Integer = 0 To lvKlasa.SelectedItems.Count - 1
    '  'Klasa.Enqueue(item.Text)
    '  Ex.Klasa(i) = lvKlasa.SelectedItems(i).Text
    'Next

    'Ex.ExportBlyskawica(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString)
    'Me.OK_Button.Enabled = True
    ''Me.cmdCancel.Enabled = True
    'Me.ControlBox = True
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

  Private Sub dlgExportBlyskawica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'AddHandler SharedExport.OnRecordForward, AddressOf RefreshMe
    'AddHandler SharedExport.OnpbMaxValueChange, AddressOf pbMaxValue_Change
    'AddHandler SharedExport.OnRoutineChange, AddressOf GetInfo
    'AddHandler SharedExport.OnDetailedRoutineChange, AddressOf GetExtendedInfo
    Me.ListViewConfig(Me.lvKlasa)
    Dim CH As New CalcHelper
    Me.nudStartYear.Value = CH.StartDateOfSchoolYear.Year
    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(Me.cbSzkola, "Select ID,Alias FROM szkoly;")
    SH.FindComboItem(Me.cbSzkola, CInt(SH.GetDefault("Select ID From szkoly Where IsDefault='1';")))

    'RefreshMe()
    'pbMaxValue_Change()
  End Sub
  Private Sub GetKlasa(ByVal IdSzkola As String, ByVal RokSzkolny As String)
    Dim DBA As New DataBaseAction, R As MySqlDataReader = Nothing
    lvKlasa.Items.Clear()
    Try
      R = DBA.GetReader("SELECT DISTINCT p.Klasa FROM przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='0' AND p.StatusAktywacji='1';")

      While R.Read()
        lvKlasa.Items.Add(R(0).ToString())
      End While
      lvKlasa.Enabled = CType(IIf(lvKlasa.Items.Count > 0, True, False), Boolean)
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      R.Close()
    End Try
  End Sub
  'Private Sub RefreshMe()
  '  Me.pbExport.Value = SharedExport.pbValue
  '  Me.lblSuccess.Text = SharedExport.SuccessValue.ToString
  '  Me.lblError.Text = SharedExport.ErrorValue.ToString
  '  Me.Refresh()
  'End Sub
  'Private Sub pbMaxValue_Change()
  '  Me.pbExport.Maximum = SharedExport.pbMaxValue
  '  lblInfo.Text = SharedExport.InfoValue
  '  lblTotal.Text = SharedExport.TotalValue
  'End Sub
  'Private Sub GetInfo()
  '  lblInfo.Text = SharedExport.InfoValue
  '  'txtDetails.Text += SharedExport.InfoValue & vbNewLine
  'End Sub
  'Private Sub GetExtendedInfo()
  '  'lblInfo.Text = SharedExport.InfoValue
  '  txtDetails.Text += SharedExport.ExtendedInfoValue & vbNewLine
  'End Sub

  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    Me.GetKlasa(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString)

    OK_Button.Enabled = CType(IIf(lvKlasa.SelectedItems.Count > 0, True, False), Boolean)
  End Sub

  Private Sub nudStartYear_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudStartYear.ValueChanged
    If Not nudStartYear.Created Then Exit Sub
    Me.nudEndYear.Value = Me.nudStartYear.Value + 1
    If cbSzkola.SelectedItem IsNot Nothing Then GetKlasa(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString)
    OK_Button.Enabled = False
  End Sub

  Private Sub lvKlasa_ItemSelectionChanged(sender As Object, e As ListViewItemSelectionChangedEventArgs) Handles lvKlasa.ItemSelectionChanged
    OK_Button.Enabled = CType(IIf(lvKlasa.SelectedItems.Count > 0, True, False), Boolean)
  End Sub

End Class

Imports System.Windows.Forms

Public Class dlgExport

  'Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
  '  Me.DialogResult = System.Windows.Forms.DialogResult.OK
  '  Me.Close()
  'End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub
  Private Sub dlgExportStudents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Height = 260
    AddHandler SharedExport.OnRecordForward, AddressOf RefreshMe
    AddHandler SharedExport.OnpbMaxValueChange, AddressOf pbMaxValue_Change
    AddHandler SharedExport.OnRoutineChange, AddressOf GetInfo
    AddHandler SharedExport.OnDetailedRoutineChange, AddressOf GetExtendedInfo
    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(Me.cbSzkola, "Select ID,Alias FROM szkoly;")
    SH.FindComboItem(Me.cbSzkola, CInt(SH.GetDefault("Select ID From szkoly Where IsDefault='1';")))
    Dim CH As New CalcHelper
    Me.nudStartYear.Value = CH.StartDateOfSchoolYear.Year

    RefreshMe()
    pbMaxValue_Change()
  End Sub
  Private Sub RefreshMe()
    Me.pbExport.Value = SharedExport.pbValue
    Me.lblSuccess.Text = SharedExport.SuccessValue.ToString
    Me.lblError.Text = SharedExport.ErrorValue.ToString
    Me.Refresh()
  End Sub
  Private Sub pbMaxValue_Change()
    Me.pbExport.Maximum = SharedExport.pbMaxValue
    lblInfo.Text = SharedExport.InfoValue
    lblTotal.Text = SharedExport.TotalValue
  End Sub
  Private Sub GetInfo()
    lblInfo.Text = SharedExport.InfoValue
    'txtDetails.Text += SharedExport.InfoValue & vbNewLine
  End Sub
  Private Sub GetExtendedInfo()
    'lblInfo.Text = SharedExport.InfoValue
    txtDetails.Text += SharedExport.ExtendedInfoValue & vbNewLine
  End Sub
  Private Sub cmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExport.Click
    Me.cmdExport.Enabled = False
    'Me.cmdCancel.Enabled = False
    Me.ControlBox = False
    Me.txtDetails.Text = ""
    Dim Ex As New ExportXML
    Ex.ExportHermes(CType(cbSzkola.SelectedItem, CbItem).ID.ToString, Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString)
    Me.cmdExport.Enabled = True
    'Me.cmdCancel.Enabled = True
    Me.ControlBox = True
  End Sub

  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    cmdExport.Enabled = True
  End Sub

  Private Sub nudStartYear_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles nudStartYear.ValueChanged
    If Not nudStartYear.Created Then Exit Sub
    Me.nudEndYear.Value = Me.nudStartYear.Value + 1
  End Sub

  Private Sub cmdDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDetails.Click
    If Me.Height = 260 Then
      Me.Height = 472
    Else
      Me.Height = 260
    End If
  End Sub
End Class

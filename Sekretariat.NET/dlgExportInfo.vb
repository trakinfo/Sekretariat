Imports System.Windows.Forms

Public Class dlgExportInfo

  Private Sub dlgExportInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    AddHandler SharedExport.OnRecordForward, AddressOf RefreshMe
    AddHandler SharedExport.OnpbMaxValueChange, AddressOf pbMaxValue_Change
    AddHandler SharedExport.OnRoutineChange, AddressOf GetInfo
    AddHandler SharedExport.OnDetailedRoutineChange, AddressOf GetExtendedInfo

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
End Class

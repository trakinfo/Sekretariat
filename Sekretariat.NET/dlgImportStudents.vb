Imports System.Windows.Forms

Public Class dlgImportStudents

  'Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImport.Click
  '  Me.DialogResult = System.Windows.Forms.DialogResult.OK
  '  'Me.Close()
  'End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Dispose()
  End Sub

  Private Sub dlgImportStudents_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim CH As New CalcHelper
    Me.nudStartYear.Value = CH.StartDateOfSchoolYear.Year

    AddHandler SharedImport.OnRecordForward, AddressOf RefreshMe
    AddHandler SharedImport.OnpbMaxValueChange, AddressOf pbMaxValue_Change
    AddHandler SharedImport.OnRoutineChange, AddressOf GetInfo
    'lblInfo.Text = ""
    RefreshMe()
    pbMaxValue_Change()
  End Sub
  Private Sub RefreshMe()
    Me.pbImport.Value = SharedImport.pbValue
    Me.lblSuccess.Text = SharedImport.SuccessValue.ToString
    Me.lblError.Text = SharedImport.ErrorValue.ToString
    Me.Refresh()
  End Sub
  Private Sub pbMaxValue_Change()
    Me.pbImport.Maximum = SharedImport.pbMaxValue
    lblInfo.Text = SharedImport.InfoValue
    lblTotal.Text = SharedImport.TotalValue
  End Sub
  Private Sub GetInfo()
    lblInfo.Text = SharedImport.InfoValue
  End Sub
  Private Sub nudStartYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudStartYear.ValueChanged
    If Not nudStartYear.Created Then Exit Sub
    Me.nudEndYear.Value = Me.nudStartYear.Value + 1
  End Sub
  Private Sub cmdFileDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFileDialog.Click
    Dim dlgOpen As New OpenFileDialog
    With dlgOpen
      .InitialDirectory = Application.StartupPath
      .Multiselect = False
      .Filter = "Wszystkie pliki (*.*)|*.*|MS Access (*.mdb)|*.mdb"
      If .ShowDialog() = Windows.Forms.DialogResult.OK Then
        Me.txtFile.Text = .FileName
        Dim Oledb As New OledbAction, acsConn As OleDb.OleDbConnection ', I As New ImportStudent
        acsConn = Oledb.Connection(.FileName)
        'Me.pbImport.Maximum = Oledb.CountRecords(I.CountRecords, acsConn)
        'Me.lblTotal.Text = Me.pbImport.Maximum.ToString
        acsConn.Close()
        'SharedImport.pbValue = 0
        'SharedImport.SuccessValue = "0"
        'SharedImport.ErrorValue = "0"
      End If
    End With
  End Sub

  Private Sub txtFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFile.TextChanged
    Me.cmdImport.Enabled = CType(IIf(Me.txtFile.TextLength > 0, True, False), Boolean)
  End Sub
  Private Sub cmdImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImport.Click
    Me.cmdImport.Enabled = False
    'Me.cmdCancel.Enabled = False
    Me.ControlBox = False
    Dim I As New ImportStudent
    I.Import(Me.txtFile.Text, String.Concat(nudStartYear.Value, "/", nudEndYear.Value))
    Me.cmdImport.Enabled = True
    'Me.cmdCancel.Enabled = True
    Me.ControlBox = True
  End Sub
End Class

Imports System.Windows.Forms

Public Class dlgOrgan
  Public Event NewAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedID As String)
  Public InRefresh As Boolean = False
  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    If Me.Modal Then
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
    Else
      If Me.txtNazwa.Text.Length > 0 Then
        AddNew(Me, e)
        OK_Button.Enabled = False
      End If
    End If
  End Sub
  Private Sub AddNew(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim MySQLTrans As MySqlTransaction
    Dim DBA As New DataBaseAction, O As New OrganSQL
    Dim cmd As MySqlCommand = DBA.CreateCommand(O.InsertOrgan)
    MySQLTrans = GlobalValues.gblConn.BeginTransaction()
    cmd.Transaction = MySQLTrans
    Try
      cmd.Parameters.AddWithValue("?Nazwa", txtNazwa.Text.Trim)
      cmd.Parameters.AddWithValue("?Rodzaj", txtRodzaj.Text.Trim)
      cmd.Parameters.AddWithValue("?Ulica", txtUlica.Text.Trim)
      cmd.Parameters.AddWithValue("?Nr", txtNr.Text.Trim)
      If cbMiejscowosc.SelectedItem IsNot Nothing Then
        cmd.Parameters.AddWithValue("?IdMiejscowosc", CType(cbMiejscowosc.SelectedItem, CbItem).ID.ToString)
      Else
        cmd.Parameters.AddWithValue("?IdMiejscowosc", DBNull.Value)
      End If
      cmd.ExecuteNonQuery()
      MySQLTrans.Commit()
      RaiseEvent NewAdded(Me, e, cmd.LastInsertedId.ToString)
      ClearFields()
      txtRodzaj.Focus()

    Catch ex As MySqlException
      MySQLTrans.Rollback()
      Select Case ex.Number
        Case 1062
          MessageBox.Show("Wartość wprowadzona w polu '" & CType(sender, TextBox).Name & "' już istnieje w bazie danych.")
        Case Else
          MessageBox.Show(ex.Message & vbCr & ex.Number)
      End Select
    Catch ex As Exception
      'MySQLTrans.Rollback()
      MessageBox.Show(ex.Message)

    End Try
  End Sub
  Private Sub ClearFields()
    For Each ctrl As Control In Me.Controls
      If TypeOf ctrl Is TextBox Then ctrl.Text = ""
    Next
  End Sub
  Public Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub dlgKlasa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not Me.Modal Then AddHandler SharedOrgan.OnOwnerClose, AddressOf Cancel_Button_Click

  End Sub

  Private Sub txtKlasa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNazwa.TextChanged
    If Not InRefresh Then OK_Button.Enabled = CType(IIf(txtNazwa.Text.Trim.Length < 1, False, True), Boolean)
  End Sub

  Private Sub txtKlasa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNazwa.Validating, txtRodzaj.Validating
    If txtNazwa.Text.Trim.Length < 1 Then Exit Sub
    Dim SH As New StringHelper
    If SH.AllowedChars(txtNazwa.Text.Trim, True) AndAlso SH.AllowedChars(txtRodzaj.Text.Trim, True) Then
      OK_Button.Enabled = True
    Else
      OK_Button.Enabled = False
      MessageBox.Show("Nazwa zawiera niedozwolone znaki!")
      e.Cancel = True
    End If

  End Sub
  'Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
  '    Me.DialogResult = System.Windows.Forms.DialogResult.OK
  '    Me.Close()
  'End Sub

  'Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
  '    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
  '    Me.Close()
  'End Sub

End Class

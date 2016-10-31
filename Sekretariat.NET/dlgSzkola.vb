Imports System.Windows.Forms

Public Class dlgSzkola
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
    Dim DBA As New DataBaseAction, S As New SzkolaSQL
    Dim cmd As MySqlCommand = DBA.CreateCommand(S.InsertSchool)
    MySQLTrans = GlobalValues.gblConn.BeginTransaction()
    cmd.Transaction = MySQLTrans
    Try
      cmd.Parameters.AddWithValue("?Nazwa", txtNazwa.Text.Trim)
      cmd.Parameters.AddWithValue("?Alias", txtAlias.Text.Trim)
      cmd.Parameters.AddWithValue("?Nip", txtNip.Text.Trim)
      If txtOKEID.Text.Trim.Length > 0 Then
        cmd.Parameters.AddWithValue("?OkeID", txtOKEID.Text.Trim)
      Else
        cmd.Parameters.AddWithValue("?OkeID", DBNull.Value)
      End If
      cmd.Parameters.AddWithValue("?Ulica", txtUlica.Text.Trim)
      cmd.Parameters.AddWithValue("?Nr", txtNr.Text.Trim)
      If cbMiejscowosc.SelectedItem IsNot Nothing Then
        cmd.Parameters.AddWithValue("?IdMiejscowosc", CType(cbMiejscowosc.SelectedItem, CbItem).ID.ToString)
      Else
        cmd.Parameters.AddWithValue("?IdMiejscowosc", DBNull.Value)
      End If
      cmd.Parameters.AddWithValue("?Tel", txtTel.Text.Trim)
      cmd.Parameters.AddWithValue("?Fax", txtFax.Text.Trim)
      cmd.Parameters.AddWithValue("?Email", txtEmail.Text.Trim)
      If cbOrgan.SelectedItem IsNot Nothing Then
        cmd.Parameters.AddWithValue("?IdOrgan", CType(cbOrgan.SelectedItem, CbItem).ID.ToString)
      Else
        cmd.Parameters.AddWithValue("?IdOrgan", DBNull.Value)
      End If
      cmd.ExecuteNonQuery()
      Dim InsertedID As String = cmd.LastInsertedId.ToString
      If chkIsDefault.Checked Then
        cmd.CommandText = S.SetDefault()
        cmd.ExecuteNonQuery()
        cmd.CommandText = S.SetDefault(1, InsertedID)
        cmd.ExecuteNonQuery()
      End If
      MySQLTrans.Commit()
      RaiseEvent NewAdded(Me, e, InsertedID)
      ClearFields()
      txtNazwa.Focus()

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
    If Not Me.Modal Then AddHandler SharedSchool.OnOwnerClose, AddressOf Cancel_Button_Click

  End Sub

  Private Sub txtKlasa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNazwa.TextChanged
    If Not InRefresh Then OK_Button.Enabled = CType(IIf(txtNazwa.Text.Trim.Length < 1, False, True), Boolean)
  End Sub

  Private Sub txtKlasa_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNazwa.Validating, txtAlias.Validating
    If txtNazwa.Text.Trim.Length < 1 Then Exit Sub
    Dim SH As New StringHelper
    If SH.AllowedChars(txtNazwa.Text.Trim, True) AndAlso SH.AllowedChars(txtAlias.Text.Trim, True) Then
      OK_Button.Enabled = True
    Else
      OK_Button.Enabled = False
      MessageBox.Show("Nazwa zawiera niedozwolone znaki!")
      e.Cancel = True
    End If

  End Sub
  '  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
  '      Me.DialogResult = System.Windows.Forms.DialogResult.OK
  '      Me.Close()
  '  End Sub

  'Public Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
  '  Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
  '  Me.Close()
  'End Sub

  Private Sub txtNip_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNip.Validating
    If txtNip.Text.Trim.Length < 1 Then Exit Sub
    Dim CH As New CalcHelper
    If CH.ValidateNIP(txtNip.Text) Then
      e.Cancel = False
    Else
      MessageBox.Show("Numer NIP jest niepoprawny. Wpisz poprawny nr NIP lub pozostaw pole puste.")
      e.Cancel = True
    End If
  End Sub

  Private Sub txtTel_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTel.Validating, txtFax.Validating
    If CType(sender, TextBox).Text.Trim.Length < 1 Then Exit Sub
    Dim SH As New StringHelper
    If SH.DigitOnly(CType(sender, TextBox).Text) Then
      e.Cancel = False
    Else
      e.Cancel = True
      MessageBox.Show("Numer telefonu lub faxu jest niepoprawny. Wpisz poprawny nr lub pozostaw pole puste.")
    End If
  End Sub
End Class

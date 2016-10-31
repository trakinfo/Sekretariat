Imports System.Windows.Forms

Public Class dlgWychowawca
  Public RokSzkolny, IdPrzedmiot, Szkola, Virtual As String

  Public Event NewWychowawcaAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedKlasa As String)

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    If Me.Modal Then
      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()
    Else
      AddNewWychowawca(sender, e)
    End If
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    If Me.Modal Then Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub
  Private Sub AddNewWychowawca(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim MySQLTrans As MySqlTransaction
    Dim DBA As New DataBaseAction, W As New WychowawcaSQL
    Dim cmd As MySqlCommand = DBA.CreateCommand(W.InsertWychowawca)
    MySQLTrans = GlobalValues.gblConn.BeginTransaction()
    cmd.Transaction = MySQLTrans
    Try
      With Me
        cmd.Parameters.AddWithValue("?Klasa", .cbKlasa.Text)
        cmd.Parameters.AddWithValue("?IdPrzedmiot", IdPrzedmiot)
        cmd.Parameters.AddWithValue("?IdBelfer", CType(.cbBelfer.SelectedItem, CbItem).ID)
        cmd.Parameters.AddWithValue("?RokSzkolny", RokSzkolny)
        cmd.ExecuteNonQuery()
        MySQLTrans.Commit()
        RaiseEvent NewWychowawcaAdded(Me, e, .cbKlasa.Text)
        cbKlasa.Items.Clear()
        Dim FCB As New FillComboBox
        FCB.AddComboBoxSimpleItems(.cbKlasa, W.SelectClass(Szkola, Virtual, RokSzkolny.Substring(0, 4)))
        OK_Button.Enabled = False
      End With
    Catch ex As MySqlException
      MySQLTrans.Rollback()
      Select Case ex.Number
        Case 1062
          MessageBox.Show("Wybrana klasa ma już przydzielone wychowawstwo!")
        Case Else
          MessageBox.Show(ex.Message & vbCr & ex.Number)
      End Select
    Catch ex As Exception
      MySQLTrans.Rollback()
      MessageBox.Show(ex.Message)

    End Try
  End Sub

  Private Sub dlgWychowawca_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not Me.Modal Then AddHandler SharedWychowawca.OnOwnerClose, AddressOf Cancel_Button_Click

  End Sub

  Private Sub cbBelfer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbBelfer.SelectionChangeCommitted, cbKlasa.SelectionChangeCommitted
    If CType(sender, ComboBox).Name = "cbKlasa" Then
      If cbBelfer.Text.Length > 0 Then OK_Button.Enabled = True
    Else
      If cbKlasa.Text.Length > 0 Then OK_Button.Enabled = True
    End If
  End Sub

  'Private Sub cbBelfer_TextUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbBelfer.TextUpdate
  '  If CType(sender, ComboBox).Text.Length > 0 Then
  '    OK_Button.Enabled = True
  '  Else
  '    OK_Button.Enabled = False
  '  End If
  'End Sub
End Class

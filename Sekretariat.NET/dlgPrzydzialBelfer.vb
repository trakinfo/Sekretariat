Imports System.Windows.Forms

Public Class dlgPrzydzialBelfer
  Public Event NewAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedID As String)
  Public IdSzkola As String
  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    If Me.Modal Then
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
    Else
      If lvBelfer.SelectedItems.Count > 0 Then
        AddNew(lvBelfer, e)
        OK_Button.Enabled = False
      End If
    End If
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Close()
  End Sub

  Private Sub dlgPrzydzialKlas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not Me.Modal Then AddHandler SharedPrzydzialBelfer.OnOwnerClose, AddressOf Cancel_Button_Click

  End Sub
  Private Function AddNew(ByVal sender As Object, ByVal e As System.EventArgs) As Boolean

    Dim DBA As New DataBaseAction, PB As New PrzydzialBelferSQL
    'Dim cmd As MySqlCommand = DBA.CreateCommand(K.InsertKlasa(txtKlasa.Text.Trim))
    Dim MySQLTrans As MySqlTransaction = GlobalValues.gblConn.BeginTransaction()
    'cmd.Transaction = MySQLTrans
    Dim LastItem As String
    LastItem = lvBelfer.SelectedItems(lvBelfer.SelectedItems.Count - 1).Text
    Try
      For Each item As ListViewItem In lvBelfer.SelectedItems
        DBA.ApplyChanges(PB.InsertPrzydzial(IdSzkola, item.Text), MySQLTrans)
        item.Remove()
      Next
      MySQLTrans.Commit()
      RaiseEvent NewAdded(Me, e, LastItem)

      Return True
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
  End Function

  Private Sub lvKlasa_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lvBelfer.ItemSelectionChanged
    OK_Button.Enabled = CType(IIf(e.IsSelected, True, False), Boolean)
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

Imports System.Windows.Forms

Public Class dlgStudent
  Public RokSzkolny As String
  Public Event NewStudentAdded(ByVal sender As Object, ByVal e As EventArgs, ByVal InsertedID As String)

  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
    If Me.Modal Then
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
    Else
      If Me.txtNazwisko.Text.Length > 0 Then
        AddNewStudent(sender, e)
        ClearControls()
      End If
    End If
  End Sub
  Private Sub ClearControls()
    For Each C As Control In Me.Controls
      If TypeOf C Is TextBox Then C.Text = ""
    Next
  End Sub
  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    If Me.Modal Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    Me.Close()

    'Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    'Me.Close()
  End Sub
  Private Sub AddNewStudent(ByVal sender As Object, ByVal e As System.EventArgs)
    Dim MySQLTrans As MySqlTransaction
    Dim DBA As New DataBaseAction, S As New StudentSQL
    Dim cmd As MySqlCommand = DBA.CreateCommand(S.InsertStudent)
    MySQLTrans = GlobalValues.gblConn.BeginTransaction()
    cmd.Transaction = MySQLTrans
    Try
      With Me
        cmd.Parameters.AddWithValue("?Nazwisko", .txtNazwisko.Text.Trim)
        cmd.Parameters.AddWithValue("?Imie1", .txtImie.Text.Trim)
        cmd.Parameters.AddWithValue("?Imie2", .txtImie2.Text.Trim)
        cmd.Parameters.AddWithValue("?NrArkusza", IIf(.txtNrArkusza.Text.Trim.Length > 0, .txtNrArkusza.Text.Trim, DBNull.Value))
        cmd.Parameters.AddWithValue("?NrLegSzkol", IIf(.txtNrLegSzkol.Text.Trim.Length > 0, .txtNrLegSzkol.Text.Trim, DBNull.Value))
        cmd.Parameters.AddWithValue("?DataUr", .dtDataUr.Value.ToString("yyyy-MM-dd"))
        If .cbMiejsceUr.Text = "" Then
          cmd.Parameters.AddWithValue("?IdMiejsceUr", DBNull.Value)
        Else
          cmd.Parameters.AddWithValue("?IdMiejsceUr", CType(.cbMiejsceUr.SelectedItem, CbItem).ID)
        End If
        If .cbMiejsceZam.Text = "" Then
          cmd.Parameters.AddWithValue("?IdMiejsceZam", DBNull.Value)
        Else
          cmd.Parameters.AddWithValue("?IdMiejsceZam", CType(.cbMiejsceZam.SelectedItem, CbItem).ID)
        End If

        cmd.Parameters.AddWithValue("?Ulica", .txtUlica.Text.Trim)
        cmd.Parameters.AddWithValue("?NrDomu", .txtNrDomu.Text.Trim)
        cmd.Parameters.AddWithValue("?NrMieszkania", .txtNrMieszkania.Text.Trim)
        cmd.Parameters.AddWithValue("?Tel1", .txtTel1.Text.Trim)
        cmd.Parameters.AddWithValue("?Tel2", .txtTel2.Text.Trim)
        cmd.Parameters.AddWithValue("?TelKom1", .txtTelKom1.Text.Trim)
        cmd.Parameters.AddWithValue("?TelKom2", .txtTelKom2.Text.Trim)
        cmd.Parameters.AddWithValue("?ImieOjca", .txtImieOjca.Text.Trim)
        cmd.Parameters.AddWithValue("?NazwiskoOjca", .txtNazwiskoOjca.Text.Trim)
        cmd.Parameters.AddWithValue("?ImieMatki", .txtImieMatki.Text.Trim)
        cmd.Parameters.AddWithValue("?NazwiskoMatki", .txtNazwiskoMatki.Text.Trim)
        cmd.Parameters.AddWithValue("?Man", IIf(.cbPlec.Text = "M", 1, 0))
        cmd.Parameters.AddWithValue("?Pesel", .txtPesel.Text.Trim)
        cmd.Parameters.AddWithValue("?ObwodSzkolny", .chkObwod.Checked)
        cmd.Parameters.AddWithValue("?Niepelnosprawnosc", .chkNiepelnosprawnosc.Checked)

        cmd.ExecuteNonQuery()
        Dim IdUczen As String = cmd.LastInsertedId.ToString
        cmd.CommandText = S.InsertPrzydzial
        cmd.Parameters.AddWithValue("?IdUczen", IdUczen)
        cmd.Parameters.AddWithValue("?Klasa", .cbKlasa.Text)
        cmd.Parameters.AddWithValue("?RokSzkolny", RokSzkolny)
        cmd.ExecuteNonQuery()
        MySQLTrans.Commit()
        RaiseEvent NewStudentAdded(Me, e, IdUczen)
        .txtNrArkusza.Focus()
      End With
    Catch ex As MySqlException
      MySQLTrans.Rollback()
      Select Case ex.Number
        Case 1062
          MessageBox.Show("Wartość wprowadzona w polu '" & CType(sender, TextBox).Name & "' już istnieje w bazie danych.")
        Case Else
          MessageBox.Show(ex.Message & vbCr & ex.Number)
      End Select
    Catch ex As Exception
      MySQLTrans.Rollback()
      MessageBox.Show(ex.Message)

    End Try
  End Sub


  Private Sub txtPesel_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPesel.Validating
    If txtPesel.Text.Length > 0 Then
      Dim CH As New CalcHelper
      If Not CH.ValidatePesel(txtPesel.Text) Then
        If MessageBox.Show("Numer Pesel jest nieprawidłowy." & vbNewLine & "Czy mimo to chcesz go pozostawić?", "Sekretariat.NET", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.No Then
          e.Cancel = True
        End If
      Else
        dtDataUr.Value = CH.GetDateFromPesel(txtPesel.Text)
        cbPlec.Text = CH.GetSexFromPesel(txtPesel.Text)
      End If
    End If
  End Sub

  Private Sub cbMiejsceUr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMiejsceUr.SelectedIndexChanged, cbMiejsceZam.SelectedIndexChanged
    If CType(sender, ComboBox).Name = "cbMiejsceUr" Then
      My.Settings.LastMiejsceUr = CType(CType(sender, ComboBox).SelectedItem, CbItem).ID
    Else
      My.Settings.LastMiejsceZam = CType(CType(sender, ComboBox).SelectedItem, CbItem).ID
    End If
    My.Settings.Save()
  End Sub

  Private Sub txtNazwisko_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNazwisko.TextChanged
    If txtNazwisko.Text.Trim.Length > 0 AndAlso cbKlasa.Text.Length > 0 Then
      Dim SH As New StringHelper
      If SH.AllowedChars(txtNazwisko.Text) Then
        cmdSave.Enabled = True 'CType(IIf(txtNazwisko.Text.Trim.Length > 0, True, False), Boolean)
      Else
        cmdSave.Enabled = False
      End If
    Else
      cmdSave.Enabled = False
    End If
    'cmdSave.Enabled = CType(IIf(txtNazwisko.Text.Trim.Length > 0, True, False), Boolean)
  End Sub

  Private Sub txtNazwisko_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNazwisko.Validating, txtImie.Validating, txtImie2.Validating, txtImieMatki.Validating, txtImieOjca.Validating, txtNazwiskoMatki.Validating, txtNazwiskoOjca.Validating
    If CType(sender, TextBox).Text.Trim.Length > 0 Then
      Dim SH As New StringHelper
      If Not SH.AllowedChars(CType(sender, TextBox).Text) Then
        MessageBox.Show("Wpisany tekst zawiera niedozwolone znaki." & vbNewLine & "Popraw błąd lub pozostaw pole puste.", My.Application.Info.Title)
        e.Cancel = True
        'Else
        '  cmdSave.Enabled = CType(IIf(txtNazwisko.Text.Trim.Length > 0, True, False), Boolean)
      End If
    End If
  End Sub

  Private Sub txtImie_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImie.Validated, txtImie2.Validated, txtImieMatki.Validated, txtImieOjca.Validated, txtNazwiskoMatki.Validated, txtNazwiskoOjca.Validated, txtNazwisko.Validated, txtUlica.Validated
    Dim SH As New StringHelper
    CType(sender, TextBox).Text = SH.CapitalizeFirst(CType(sender, TextBox).Text.Trim)
  End Sub

  Private Sub txtNrArkusza_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNrArkusza.Validating, txtNrDomu.Validating, txtNrMieszkania.Validating
    If CType(sender, TextBox).Text.Length > 0 Then
      Dim SH As New StringHelper
      If Not SH.LetterOrDigit(CType(sender, TextBox).Text) Then
        MessageBox.Show("Wpisany tekst zawiera niedozwolone znaki." & vbNewLine & "Popraw błąd lub pozostaw pole puste.", My.Application.Info.Title)
        e.Cancel = True
      End If

    End If
  End Sub

  Private Sub txtTel1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtTel1.Validating, txtTel2.Validating, txtTelKom1.Validating, txtTelKom2.Validating
    If CType(sender, TextBox).Text.Length > 0 Then
      Dim SH As New StringHelper
      If Not SH.DigitOnly(CType(sender, TextBox).Text) Then
        MessageBox.Show("Wpisany tekst zawiera niedozwolone znaki." & vbNewLine & "Popraw błąd lub pozostaw pole puste.", My.Application.Info.Title)
        e.Cancel = True
      End If
    End If

  End Sub

  Private Sub cbKlasa_TextUpdate(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbKlasa.TextChanged
    Me.txtNazwisko_TextChanged(sender, e)
  End Sub

  Private Sub dlgStudent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If Not Me.Modal Then AddHandler SharedStudent.OnOwnerClose, AddressOf Cancel_Button_Click
    'Me.Opacity = 0.5
  End Sub

  Private Sub txtNrLegSzkol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNrLegSzkol.Validating
    If txtNrLegSzkol.Text.Trim.Length < 1 Then Exit Sub
    Dim SH As New StringHelper
    If txtNrLegSzkol.Text.Trim.IndexOf("/") > 0 Then
      If Not (SH.DigitOnly(txtNrLegSzkol.Text.Trim.Substring(0, txtNrLegSzkol.Text.Trim.IndexOf("/"))) AndAlso txtNrLegSzkol.Text.Trim.Substring(txtNrLegSzkol.Text.Trim.IndexOf("/") + 1, txtNrLegSzkol.Text.Trim.Substring(txtNrLegSzkol.Text.Trim.IndexOf("/") + 1).Length).Length = 4 AndAlso SH.DigitOnly(txtNrLegSzkol.Text.Trim.Substring(txtNrLegSzkol.Text.Trim.IndexOf("/") + 1, txtNrLegSzkol.Text.Trim.Substring(txtNrLegSzkol.Text.Trim.IndexOf("/") + 1).Length))) Then
        MessageBox.Show("Nieprawidłowy format nr legitymacji szkolnej." & vbNewLine & "Nr legitymacji szkolnej powinien składać się z liczby oraz roku w formacie czterocyfrowym, rozdzielonych ukośnikiem (/) lub z samej liczby." & vbNewLine & "Popraw zawartość tego pola lub pozostaw pole puste.", "Sekretariat.NET")
        e.Cancel = True
      End If
    Else
      If Not SH.DigitOnly(txtNrLegSzkol.Text) Then
        MessageBox.Show("Nieprawidłowy format nr legitymacji szkolnej." & vbNewLine & "Nr legitymacji szkolnej powinien składać się z liczby oraz roku w formacie czterocyfrowym, rozdzielonych ukośnikiem (/) lub z samej liczby." & vbNewLine & "Popraw zawartość tego pola lub pozostaw pole puste.", "Sekretariat.NET")
        e.Cancel = True
      End If
    End If
  End Sub
End Class

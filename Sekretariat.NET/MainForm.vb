Public Class MainForm

  Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    CloseConnection()
    'tmConn.Stop()
  End Sub

  Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    System.Windows.Forms.Application.EnableVisualStyles()
    'MessageBox.Show(Application.UserAppDataPath)
    Me.Text = Me.Text + " - ver. " + My.Application.Info.Version.ToString
    statConn.Text = ""
    Connect()
  End Sub
  Private Sub Connect()
    Dim DBA As New DataBaseAction, R As New Rijndael

    GlobalValues.gblConn = DBA.Connection(My.Settings.ServerIP, My.Settings.DBName, My.Settings.SysUser, R.Decrypt(My.Settings.SysPassword))

    If GlobalValues.gblConn.State = ConnectionState.Open Then
      Me.statConn.Text = "Połączony"
      'MenuUstawieniaManageUser_Click(Me, New System.EventArgs)
      Login()
    Else
      If SetConnectParams() Then
        Connect()
      Else
        Me.Close()
      End If
    End If
  End Sub
  Private Function SetConnectParams() As Boolean
    Dim dlgConnect As New dlgConnect, R As New Rijndael
    With dlgConnect
      .txtSerwerIP.Text = My.Settings.ServerIP
      .txtDBName.Text = My.Settings.DBName
      .txtUserName.Text = My.Settings.SysUser
      .txtPassword.Text = R.Decrypt(My.Settings.SysPassword)
    End With
    If dlgConnect.ShowDialog = Windows.Forms.DialogResult.OK Then
      With dlgConnect
        My.Settings.ServerIP = .txtSerwerIP.Text
        My.Settings.DBName = .txtDBName.Text
        My.Settings.SysUser = .txtUserName.Text
        My.Settings.SysPassword = R.Encrypt(.txtPassword.Text)
        My.Settings.Save()
        Return True
      End With
    End If
    Return False
  End Function
  Private Sub CloseConnection()
    If Not IsNothing(GlobalValues.gblConn) Then
      If GlobalValues.gblConn.State <> ConnectionState.Closed Then GlobalValues.gblConn.Close()
    End If
  End Sub
  Private Sub CheckUser(ByVal UserName As String, ByVal Password As String)
    Dim DBA As New DataBaseAction, R As MySqlDataReader = Nothing, HH As New HashHelper
    Try
      R = DBA.GetReader("SELECT u.`Administrator`,u.`UserPassword` FROM `user` u WHERE u.`Login`='" + UserName + "';")
      If R.HasRows Then
        R.Read()
        If HH.ComparePasswords(CType(R.Item(1), Byte()), Password) Then
          Dim N As New Net
          GlobalValues.gblIP = N.ComputerIPv4
          GlobalValues.gblUserName = UserName
          statUser.Text = UserName
          EnableMenu(True)
          If CType(R.Item("Administrator"), Boolean) = True Then GlobalValues.gblAdmin = True
          EnableAdminMenu(GlobalValues.gblAdmin)
        Else
          MessageBox.Show("Podane hasło jest nieprawidłowe lub użytkownik nie istnieje!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          R.Close()
          Login()
        End If
      Else
        R.Close()
        MessageBox.Show("Podane hasło jest nieprawidłowe lub użytkownik nie istnieje!", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Login()
      End If
    Catch ex As MySqlException
      MessageBox.Show(ex.Message)
    Finally
      R.Close()
    End Try

  End Sub
  Private Sub Login()
    Dim dlgLogin As New dlgLogin
    If dlgLogin.ShowDialog = Windows.Forms.DialogResult.OK Then
      With dlgLogin
        My.Settings.UserName = .txtUserName.Text
        My.Settings.Save()
        CheckUser(.txtUserName.Text, .txtPassword.Text)
      End With
    Else
      Application.Exit()
    End If

  End Sub
  Private Sub LogOut()
    GlobalValues.gblUserName = ""
    GlobalValues.gblAdmin = False
    Me.statUser.Text = ""
    EnableMenu(False)
    EnableAdminMenu(False)
    Login()
  End Sub
  Private Sub EnableAdminMenu(ByVal Value As Boolean)
    MenuUstawieniaConnectionParameters.Enabled = Value
    MenuUstawieniaManageUser.Enabled = Value
    MenuPlikImport.Enabled = Value
  End Sub
  Private Sub EnableMenu(ByVal value As Boolean)
    PlikToolStripMenuItem.Enabled = value
    ZapytaniaToolStripMenuItem.Enabled = value
    UczniowieToolStripMenuItem.Enabled = value
    RaportyToolStripMenuItem.Enabled = value
    UstawieniaToolStripMenuItem.Enabled = value
    AboutToolStripMenuItem.Enabled = value
  End Sub

  Private Sub MenuUstawieniaManageUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUstawieniaManageUser.Click
    Dim frmUsers As New frmUsers
    frmUsers.Icon = GlobalValues.gblAppIcon
    frmUsers.MdiParent = Me
    frmUsers.MaximizeBox = False
    frmUsers.StartPosition = FormStartPosition.CenterScreen
    frmUsers.Show()
  End Sub

  Private Sub MenuPlikWyloguj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPlikWyloguj.Click
    LogOut()
  End Sub

  Private Sub MenuPlikZamknij_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPlikZamknij.Click
    'CloseConnection()
    Application.Exit()

  End Sub

  Private Sub MenuUstawieniaChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUstawieniaChangePassword.Click
    If GlobalValues.gblAdmin Then
      Me.ChangePassword()
    Else
      Me.ChangePassword(GlobalValues.gblUserName)
    End If
  End Sub
  Private Overloads Sub ChangePassword(ByVal Name As String)
    Dim HashHelper As New HashHelper, DBA As New DataBaseAction, U As New UsersSQL, dlgChangePassword As New dlgUser
    With dlgChangePassword
      .Icon = GlobalValues.gblAppIcon
      .Text = "Zmiana hasła - tryb użytkownika"
      .txtNazwa.Text = Name
      .txtNazwa.Enabled = False
      .lblNazwa.Enabled = False
      .chkAdministrator.Enabled = False
      .chkAdministrator.Visible = False
      .OK_Button.Text = "Zmień"
    End With
    If dlgChangePassword.ShowDialog = Windows.Forms.DialogResult.OK Then
      Dim SaltedPasswordHash As Byte()
      SaltedPasswordHash = HashHelper.CreateDBPassword(dlgChangePassword.txtPassword.Text)
      Dim cmd As MySqlCommand = DBA.CreateCommand(U.UpdatePassword(Name))
      cmd.Parameters.AddWithValue("?Password", SaltedPasswordHash)
      cmd.ExecuteNonQuery()

    End If
  End Sub
  Private Overloads Sub ChangePassword()
    Dim HashHelper As New HashHelper, DBA As New DataBaseAction, U As New UsersSQL, dlgChangePassword As New dlgUser
    With dlgChangePassword
      .Text = "Zmiana hasła - tryb administratora"
      .txtNazwa.Enabled = False
      .txtNazwa.Visible = False
      .chkAdministrator.Enabled = False
      .chkAdministrator.Visible = False
      .OK_Button.Text = "Zmień"
      Dim cbNazwa As New ComboBox
      cbNazwa.Name = "cbNazwa"
      cbNazwa.Location = .txtNazwa.Location
      cbNazwa.Width = .txtNazwa.Width
      cbNazwa.DropDownStyle = ComboBoxStyle.DropDownList
      cbNazwa.Parent = dlgChangePassword
      Dim FCB As New FillComboBox
      FCB.AddComboBoxSimpleItems(cbNazwa, U.SelectUsers)
      AddHandler cbNazwa.SelectedIndexChanged, AddressOf cbNazwa_SelectedIndexChanged

      .Controls.Add(cbNazwa)

      If .ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim SaltedPasswordHash As Byte()
        SaltedPasswordHash = HashHelper.CreateDBPassword(.txtPassword.Text)
        Try
          Dim cmd As MySqlCommand = DBA.CreateCommand(U.UpdatePassword(cbNazwa.Text))
          cmd.Parameters.AddWithValue("?Password", SaltedPasswordHash)
          cmd.ExecuteNonQuery()
          MessageBox.Show("Hasło zostało zmienione")
        Catch ex As MySqlException
          MessageBox.Show("Wystąpił błąd:" + vbNewLine + ex.Message)
        End Try

      End If
    End With
  End Sub
  Private Sub cbNazwa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim cbNazwa As ComboBox = CType(sender, ComboBox)
    Dim dlgChangePassword As Form = cbNazwa.FindForm()
    dlgChangePassword.Controls("tlpButtons").Controls("Ok_button").Enabled = True
  End Sub


  Private Sub MenuPlikImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPlikImport.Click
    Dim dlgImport As New dlgImportStudents
    With dlgImport
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      .MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub MenuUczniowieDanePersonalne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUczniowieDanePersonalne.Click
    Dim frmStudents As New frmStudents
    'IsMdiContainer = True
    With frmStudents
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub MenuPlikExportHermes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuExportHermes.Click
    Dim dlgExportHermes As New dlgExport
    With dlgExportHermes
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      .MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With

  End Sub

  Private Sub MenuUstawieniaConnectionParameters_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUstawieniaConnectionParameters.Click
    SetConnectParams()
  End Sub

  Private Sub StatystykiLiczbaUczniow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatystykiLiczbaUczniow.Click
    Dim LiczbaUczniow As New frmLiczbaUczniow
    'IsMdiContainer = True
    With LiczbaUczniow
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub StatystykiLiczbaUczniowWgWyboru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatystykiLiczbaUczniowWgWyboru.Click
    Dim LiczbaUczniow As New frmLiczbaUczniowByChoice
    'IsMdiContainer = True
    With LiczbaUczniow
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub StatystykiUczniowieDrugoroczni_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StatystykiUczniowieDrugoroczni.Click
    Dim LiczbaUczniow As New frmLiczbaUczniowDrugorocznych
    'IsMdiContainer = True
    With LiczbaUczniow
      .Icon = GlobalValues.gblAppIcon
      .FormRoleSpady = True
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub StatystykiUczniowieSkresleni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatystykiUczniowieSkresleni.Click
    Dim LiczbaUczniow As New frmLiczbaUczniowDrugorocznych
    'IsMdiContainer = True
    With LiczbaUczniow
      .Icon = GlobalValues.gblAppIcon
      .FormRoleSpady = False
      .Text = "Liczba uczniów skreślonych z listy"
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub MenuUczniowiePromocja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUczniowiePromocja.Click
    Dim Promocja As New frmPromocja
    With Promocja
      '.FormRoleSpady = False
      '.Text = "Liczba uczniów skreślonych z listy"
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With

  End Sub

  Private Sub menuUczniowiePrzydzial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuUczniowiePrzydzial.Click
    Dim Przydzial As New frmPrzydzial
    With Przydzial
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub MenuUczniowieWychowawstwo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUczniowieWychowawstwo.Click
    Dim Wychowawca As New frmWychowawca
    With Wychowawca
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub menuUczniowieDrugoroczni_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuUczniowieDrugoroczni.Click
    Dim Spady As New frmDrugoroczni
    With Spady
      .Icon = GlobalValues.gblAppIcon
      .FormRole = "Spady"
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub menuUczniowieSkresleni_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuUczniowieSkresleni.Click
    Dim StrikeOutStudents As New frmDrugoroczni
    'IsMdiContainer = True
    With StrikeOutStudents
      .Icon = GlobalValues.gblAppIcon
      .FormRole = "StrikeOut"
      .Text = "Rejestr uczniów skreślonych z listy"
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub MenuUczniowieObwodPozaSzkola_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuUczniowieObwodPozaSzkola.Click
    Dim OutOfSchoolStudents As New frmDrugoroczni
    'IsMdiContainer = True
    With OutOfSchoolStudents
      .Icon = GlobalValues.gblAppIcon
      .FormRole = "OutOfSchool"
      .chkVirtual.Checked = True
      .chkVirtual.Enabled = False
      .chkVirtual.Visible = False
      .Text = "Rejestr uczniów realizujacych obowiązek poza szkołą"
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With

  End Sub

  Private Sub StatystykiUczniowieWgRocznikow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles StatystykiUczniowieWgRocznikow.Click
    Dim StudentsByBirthYear As New frmLiczbaUczniowByMiejscowoscByRocznik
    With StudentsByBirthYear
      .MdiParent = Me
      '.MaximizeBox = False
      .Icon = GlobalValues.gblAppIcon
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With

  End Sub


  Private Sub RaportyListaUczniow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RaportyListaUczniow.Click
    Dim StudentReport As New prnStudents
    With StudentReport
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With

  End Sub

  Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
    Dim About As New AboutSekretariat
    With About
      .Icon = GlobalValues.gblAppIcon
      '.MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .ShowDialog()
    End With
  End Sub

  Private Sub SlownikiKlasy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlownikiKlasy.Click
    Dim Klasa As New frmKlasa
    With Klasa
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      .MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub MenuUstawieniaKlasyWSzkole_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUstawieniaKlasyWSzkole.Click
    Dim Przydzial As New frmPrzydzialKlasDoSzkol
    With Przydzial
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      .MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub SlownikiMiejscowosci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlownikiMiejscowosci.Click
    Dim Miejscowosc As New frmMiejscowosc
    With Miejscowosc
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub SlownikiWojewodztwa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlownikiWojewodztwa.Click
    Dim Woj As New frmWoj
    With Woj
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub SlownikiKraje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlownikiKraje.Click
    Dim Kraj As New frmKraj
    With Kraj
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub MenuUstawieniaSzkoly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUstawieniaSzkoly.Click
    Dim Szkola As New frmSzkola
    With Szkola
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub MenuUstawieniaOrganProwadzacy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUstawieniaOrganProwadzacy.Click
    Dim Organ As New frmOrgan
    With Organ
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub SlownikiNauczyciele_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlownikiNauczyciele.Click
    Dim Belfer As New frmBelfer
    With Belfer
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With

  End Sub

  Private Sub MenuUstawieniaPrzydzialNauczyciel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUstawieniaPrzydzialNauczyciel.Click
    Dim Belfer As New frmPrzydzialBelfer
    With Belfer
      .Icon = GlobalValues.gblAppIcon
      .MdiParent = Me
      '.MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With

  End Sub

  Private Sub MenuPlikExportBlyskawica_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuExportBlyskawica.Click
    Dim dlgExport As New dlgExportBlyskawica
    'zrobić poprawkę na wzór exportu do Belfer
    With dlgExport
      .Icon = GlobalValues.gblAppIcon
      '.MdiParent = Me
      .MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      If .ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim Ex As New ExportXML
        ReDim Ex.Klasa(.lvKlasa.SelectedItems.Count - 1)
        For i As Integer = 0 To .lvKlasa.SelectedItems.Count - 1
          Ex.Klasa(i) = .lvKlasa.SelectedItems(i).Text
        Next

        Ex.ExportBlyskawica(CType(.cbSzkola.SelectedItem, CbItem).ID.ToString, .nudStartYear.Value.ToString & "/" & .nudEndYear.Value.ToString)

      End If
      '.Show()
    End With
  End Sub

  Private Sub MenuUczniowiePozaObwod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUczniowiePozaObwod.Click
    Dim OutOfDistrictStudents As New frmDrugoroczni
    'IsMdiContainer = True
    With OutOfDistrictStudents
      .Icon = GlobalValues.gblAppIcon
      .FormRole = "OutOfDistrict"
      .chkVirtual.Checked = False
      .chkVirtual.Enabled = False
      .chkVirtual.Visible = False
      .Text = "Rejestr uczniów należących do innnych obwodów szkolnych"
      .MdiParent = Me
      .StartPosition = FormStartPosition.CenterScreen
      .Show()
    End With
  End Sub

  Private Sub MenuExportBelfer_Click(sender As Object, e As EventArgs) Handles MenuExportBelfer.Click
    Dim dlgExport As New dlgExportBlyskawica
    With dlgExport
      .Icon = GlobalValues.gblAppIcon
      '.MdiParent = Me
      .MaximizeBox = False
      .StartPosition = FormStartPosition.CenterScreen
      .Text = "Export danych do programu Belfer.NET"
      If .ShowDialog = Windows.Forms.DialogResult.OK Then
        Dim Ex As New ExportXML
        ReDim Ex.Klasa(.lvKlasa.SelectedItems.Count - 1)
        For i As Integer = 0 To .lvKlasa.SelectedItems.Count - 1
          Ex.Klasa(i) = .lvKlasa.SelectedItems(i).Text
        Next

        Ex.ExportBelfer(CType(.cbSzkola.SelectedItem, CbItem).ID.ToString, .nudStartYear.Value.ToString & "/" & .nudEndYear.Value.ToString)

      End If
    End With
  End Sub
End Class

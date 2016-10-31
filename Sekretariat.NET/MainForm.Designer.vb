<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
    Me.MainMenuToolStrip = New System.Windows.Forms.MenuStrip()
    Me.PlikToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuPlikWyloguj = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
    Me.MenuPlikImport = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuPlikExport = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuExportHermes = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuExportBlyskawica = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
    Me.MenuPlikZamknij = New System.Windows.Forms.ToolStripMenuItem()
    Me.UczniowieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuUczniowieDanePersonalne = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
    Me.menuUczniowiePrzydzial = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuUczniowieWychowawstwo = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuUczniowiePromocja = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
    Me.menuUczniowieDrugoroczni = New System.Windows.Forms.ToolStripMenuItem()
    Me.menuUczniowieSkresleni = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
    Me.MenuUczniowieObwodPozaSzkola = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuUczniowiePozaObwod = New System.Windows.Forms.ToolStripMenuItem()
    Me.ZapytaniaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.StatystykiLiczbaUczniow = New System.Windows.Forms.ToolStripMenuItem()
    Me.StatystykiLiczbaUczniowWgWyboru = New System.Windows.Forms.ToolStripMenuItem()
    Me.StatystykiUczniowieWgRocznikow = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
    Me.StatystykiUczniowieDrugoroczni = New System.Windows.Forms.ToolStripMenuItem()
    Me.StatystykiUczniowieSkresleni = New System.Windows.Forms.ToolStripMenuItem()
    Me.RaportyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.RaportyListaUczniow = New System.Windows.Forms.ToolStripMenuItem()
    Me.UstawieniaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuUstawieniaManageUser = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuUstawieniaChangePassword = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
    Me.MenuUstawieniaConnectionParameters = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
    Me.MenuUstawieniaSzkoly = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuUstawieniaOrganProwadzacy = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
    Me.MenuUstawieniaPrzydzialNauczyciel = New System.Windows.Forms.ToolStripMenuItem()
    Me.MenuUstawieniaKlasyWSzkole = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
    Me.MenuUstawieniaSlowniki = New System.Windows.Forms.ToolStripMenuItem()
    Me.SlownikiMiejscowosci = New System.Windows.Forms.ToolStripMenuItem()
    Me.SlownikiWojewodztwa = New System.Windows.Forms.ToolStripMenuItem()
    Me.SlownikiKraje = New System.Windows.Forms.ToolStripMenuItem()
    Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
    Me.SlownikiKlasy = New System.Windows.Forms.ToolStripMenuItem()
    Me.SlownikiPrzedmioty = New System.Windows.Forms.ToolStripMenuItem()
    Me.SlownikiNauczyciele = New System.Windows.Forms.ToolStripMenuItem()
    Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.MainStatus = New System.Windows.Forms.StatusStrip()
    Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
    Me.statConn = New System.Windows.Forms.ToolStripStatusLabel()
    Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
    Me.statUser = New System.Windows.Forms.ToolStripStatusLabel()
    Me.MenuExportBelfer = New System.Windows.Forms.ToolStripMenuItem()
    Me.MainMenuToolStrip.SuspendLayout()
    Me.MainStatus.SuspendLayout()
    Me.SuspendLayout()
    '
    'MainMenuToolStrip
    '
    Me.MainMenuToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlikToolStripMenuItem, Me.UczniowieToolStripMenuItem, Me.ZapytaniaToolStripMenuItem, Me.RaportyToolStripMenuItem, Me.UstawieniaToolStripMenuItem, Me.AboutToolStripMenuItem})
    Me.MainMenuToolStrip.Location = New System.Drawing.Point(0, 0)
    Me.MainMenuToolStrip.Name = "MainMenuToolStrip"
    Me.MainMenuToolStrip.Size = New System.Drawing.Size(693, 24)
    Me.MainMenuToolStrip.TabIndex = 1
    Me.MainMenuToolStrip.Text = "MenuStrip1"
    '
    'PlikToolStripMenuItem
    '
    Me.PlikToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuPlikWyloguj, Me.ToolStripSeparator4, Me.MenuPlikImport, Me.MenuPlikExport, Me.ToolStripSeparator3, Me.MenuPlikZamknij})
    Me.PlikToolStripMenuItem.Enabled = False
    Me.PlikToolStripMenuItem.Name = "PlikToolStripMenuItem"
    Me.PlikToolStripMenuItem.Size = New System.Drawing.Size(38, 20)
    Me.PlikToolStripMenuItem.Text = "&Plik"
    Me.PlikToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
    '
    'MenuPlikWyloguj
    '
    Me.MenuPlikWyloguj.Name = "MenuPlikWyloguj"
    Me.MenuPlikWyloguj.Size = New System.Drawing.Size(303, 22)
    Me.MenuPlikWyloguj.Text = "&Wyloguj"
    '
    'ToolStripSeparator4
    '
    Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
    Me.ToolStripSeparator4.Size = New System.Drawing.Size(300, 6)
    '
    'MenuPlikImport
    '
    Me.MenuPlikImport.Enabled = False
    Me.MenuPlikImport.Name = "MenuPlikImport"
    Me.MenuPlikImport.Size = New System.Drawing.Size(303, 22)
    Me.MenuPlikImport.Text = "Import danych z Sekretariat 1.0 (MS Access)"
    '
    'MenuPlikExport
    '
    Me.MenuPlikExport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuExportHermes, Me.MenuExportBlyskawica, Me.MenuExportBelfer})
    Me.MenuPlikExport.Name = "MenuPlikExport"
    Me.MenuPlikExport.Size = New System.Drawing.Size(303, 22)
    Me.MenuPlikExport.Text = "Export danych do xml"
    '
    'MenuExportHermes
    '
    Me.MenuExportHermes.Name = "MenuExportHermes"
    Me.MenuExportHermes.Size = New System.Drawing.Size(282, 22)
    Me.MenuExportHermes.Text = "Export danych do programu Hermes"
    '
    'MenuExportBlyskawica
    '
    Me.MenuExportBlyskawica.Name = "MenuExportBlyskawica"
    Me.MenuExportBlyskawica.Size = New System.Drawing.Size(282, 22)
    Me.MenuExportBlyskawica.Text = "Export danych do programu Błyskawica"
    '
    'ToolStripSeparator3
    '
    Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
    Me.ToolStripSeparator3.Size = New System.Drawing.Size(300, 6)
    '
    'MenuPlikZamknij
    '
    Me.MenuPlikZamknij.Name = "MenuPlikZamknij"
    Me.MenuPlikZamknij.Size = New System.Drawing.Size(303, 22)
    Me.MenuPlikZamknij.Text = "&Zamknij"
    '
    'UczniowieToolStripMenuItem
    '
    Me.UczniowieToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuUczniowieDanePersonalne, Me.ToolStripSeparator2, Me.menuUczniowiePrzydzial, Me.MenuUczniowieWychowawstwo, Me.MenuUczniowiePromocja, Me.ToolStripSeparator1, Me.menuUczniowieDrugoroczni, Me.menuUczniowieSkresleni, Me.ToolStripSeparator8, Me.MenuUczniowieObwodPozaSzkola, Me.MenuUczniowiePozaObwod})
    Me.UczniowieToolStripMenuItem.Enabled = False
    Me.UczniowieToolStripMenuItem.Name = "UczniowieToolStripMenuItem"
    Me.UczniowieToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
    Me.UczniowieToolStripMenuItem.Text = "Uczniowie"
    '
    'MenuUczniowieDanePersonalne
    '
    Me.MenuUczniowieDanePersonalne.Name = "MenuUczniowieDanePersonalne"
    Me.MenuUczniowieDanePersonalne.Size = New System.Drawing.Size(553, 22)
    Me.MenuUczniowieDanePersonalne.Text = "Dane personalne uczniów"
    '
    'ToolStripSeparator2
    '
    Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
    Me.ToolStripSeparator2.Size = New System.Drawing.Size(550, 6)
    '
    'menuUczniowiePrzydzial
    '
    Me.menuUczniowiePrzydzial.Name = "menuUczniowiePrzydzial"
    Me.menuUczniowiePrzydzial.Size = New System.Drawing.Size(553, 22)
    Me.menuUczniowiePrzydzial.Text = "Przydział uczniów do oddziałów klasowych"
    '
    'MenuUczniowieWychowawstwo
    '
    Me.MenuUczniowieWychowawstwo.Name = "MenuUczniowieWychowawstwo"
    Me.MenuUczniowieWychowawstwo.Size = New System.Drawing.Size(553, 22)
    Me.MenuUczniowieWychowawstwo.Text = "Przydział wychowawstw"
    '
    'MenuUczniowiePromocja
    '
    Me.MenuUczniowiePromocja.Name = "MenuUczniowiePromocja"
    Me.MenuUczniowiePromocja.Size = New System.Drawing.Size(553, 22)
    Me.MenuUczniowiePromocja.Text = "Promocja uczniów"
    '
    'ToolStripSeparator1
    '
    Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
    Me.ToolStripSeparator1.Size = New System.Drawing.Size(550, 6)
    '
    'menuUczniowieDrugoroczni
    '
    Me.menuUczniowieDrugoroczni.Name = "menuUczniowieDrugoroczni"
    Me.menuUczniowieDrugoroczni.Size = New System.Drawing.Size(553, 22)
    Me.menuUczniowieDrugoroczni.Text = "Rejestr uczniów drugorocznych"
    '
    'menuUczniowieSkresleni
    '
    Me.menuUczniowieSkresleni.Name = "menuUczniowieSkresleni"
    Me.menuUczniowieSkresleni.Size = New System.Drawing.Size(553, 22)
    Me.menuUczniowieSkresleni.Text = "Rejestr uczniów skreślonych z listy"
    '
    'ToolStripSeparator8
    '
    Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
    Me.ToolStripSeparator8.Size = New System.Drawing.Size(550, 6)
    '
    'MenuUczniowieObwodPozaSzkola
    '
    Me.MenuUczniowieObwodPozaSzkola.Name = "MenuUczniowieObwodPozaSzkola"
    Me.MenuUczniowieObwodPozaSzkola.Size = New System.Drawing.Size(553, 22)
    Me.MenuUczniowieObwodPozaSzkola.Text = "Rejestr uczniów z obwodu własnego realizujących obowiązek szkolny w innych placów" & _
    "kach"
    '
    'MenuUczniowiePozaObwod
    '
    Me.MenuUczniowiePozaObwod.Name = "MenuUczniowiePozaObwod"
    Me.MenuUczniowiePozaObwod.Size = New System.Drawing.Size(553, 22)
    Me.MenuUczniowiePozaObwod.Text = "Rejestr uczniów należących do innych obwodów szkolnych"
    '
    'ZapytaniaToolStripMenuItem
    '
    Me.ZapytaniaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatystykiLiczbaUczniow, Me.StatystykiLiczbaUczniowWgWyboru, Me.StatystykiUczniowieWgRocznikow, Me.ToolStripSeparator9, Me.StatystykiUczniowieDrugoroczni, Me.StatystykiUczniowieSkresleni})
    Me.ZapytaniaToolStripMenuItem.Enabled = False
    Me.ZapytaniaToolStripMenuItem.Name = "ZapytaniaToolStripMenuItem"
    Me.ZapytaniaToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
    Me.ZapytaniaToolStripMenuItem.Text = "Zestawienia"
    '
    'StatystykiLiczbaUczniow
    '
    Me.StatystykiLiczbaUczniow.Name = "StatystykiLiczbaUczniow"
    Me.StatystykiLiczbaUczniow.Size = New System.Drawing.Size(373, 22)
    Me.StatystykiLiczbaUczniow.Text = "Liczba uczniów ogółem w szkole i w klasach"
    '
    'StatystykiLiczbaUczniowWgWyboru
    '
    Me.StatystykiLiczbaUczniowWgWyboru.Name = "StatystykiLiczbaUczniowWgWyboru"
    Me.StatystykiLiczbaUczniowWgWyboru.Size = New System.Drawing.Size(373, 22)
    Me.StatystykiLiczbaUczniowWgWyboru.Text = "Liczba uczniów wg wybranego kryterium"
    '
    'StatystykiUczniowieWgRocznikow
    '
    Me.StatystykiUczniowieWgRocznikow.Name = "StatystykiUczniowieWgRocznikow"
    Me.StatystykiUczniowieWgRocznikow.Size = New System.Drawing.Size(373, 22)
    Me.StatystykiUczniowieWgRocznikow.Text = "Liczba uczniów wg miejscowości z podziałem na roczniki"
    '
    'ToolStripSeparator9
    '
    Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
    Me.ToolStripSeparator9.Size = New System.Drawing.Size(370, 6)
    '
    'StatystykiUczniowieDrugoroczni
    '
    Me.StatystykiUczniowieDrugoroczni.Name = "StatystykiUczniowieDrugoroczni"
    Me.StatystykiUczniowieDrugoroczni.Size = New System.Drawing.Size(373, 22)
    Me.StatystykiUczniowieDrugoroczni.Text = "Liczba uczniów drugorocznych"
    '
    'StatystykiUczniowieSkresleni
    '
    Me.StatystykiUczniowieSkresleni.Name = "StatystykiUczniowieSkresleni"
    Me.StatystykiUczniowieSkresleni.Size = New System.Drawing.Size(373, 22)
    Me.StatystykiUczniowieSkresleni.Text = "Liczba uczniów skreślonych z listy uczniów"
    '
    'RaportyToolStripMenuItem
    '
    Me.RaportyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RaportyListaUczniow})
    Me.RaportyToolStripMenuItem.Enabled = False
    Me.RaportyToolStripMenuItem.Name = "RaportyToolStripMenuItem"
    Me.RaportyToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
    Me.RaportyToolStripMenuItem.Text = "Raporty"
    '
    'RaportyListaUczniow
    '
    Me.RaportyListaUczniow.Name = "RaportyListaUczniow"
    Me.RaportyListaUczniow.Size = New System.Drawing.Size(145, 22)
    Me.RaportyListaUczniow.Text = "Lista uczniów"
    Me.RaportyListaUczniow.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
    '
    'UstawieniaToolStripMenuItem
    '
    Me.UstawieniaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuUstawieniaManageUser, Me.MenuUstawieniaChangePassword, Me.ToolStripSeparator5, Me.MenuUstawieniaConnectionParameters, Me.ToolStripSeparator6, Me.MenuUstawieniaSzkoly, Me.MenuUstawieniaOrganProwadzacy, Me.ToolStripSeparator11, Me.MenuUstawieniaPrzydzialNauczyciel, Me.MenuUstawieniaKlasyWSzkole, Me.ToolStripSeparator7, Me.MenuUstawieniaSlowniki})
    Me.UstawieniaToolStripMenuItem.Enabled = False
    Me.UstawieniaToolStripMenuItem.Name = "UstawieniaToolStripMenuItem"
    Me.UstawieniaToolStripMenuItem.Size = New System.Drawing.Size(76, 20)
    Me.UstawieniaToolStripMenuItem.Text = "&Ustawienia"
    '
    'MenuUstawieniaManageUser
    '
    Me.MenuUstawieniaManageUser.Name = "MenuUstawieniaManageUser"
    Me.MenuUstawieniaManageUser.Size = New System.Drawing.Size(281, 22)
    Me.MenuUstawieniaManageUser.Text = "Zarządzanie &użytkownikami"
    '
    'MenuUstawieniaChangePassword
    '
    Me.MenuUstawieniaChangePassword.Name = "MenuUstawieniaChangePassword"
    Me.MenuUstawieniaChangePassword.Size = New System.Drawing.Size(281, 22)
    Me.MenuUstawieniaChangePassword.Text = "Zmiana &hasła użytkownika"
    '
    'ToolStripSeparator5
    '
    Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
    Me.ToolStripSeparator5.Size = New System.Drawing.Size(278, 6)
    '
    'MenuUstawieniaConnectionParameters
    '
    Me.MenuUstawieniaConnectionParameters.Name = "MenuUstawieniaConnectionParameters"
    Me.MenuUstawieniaConnectionParameters.Size = New System.Drawing.Size(281, 22)
    Me.MenuUstawieniaConnectionParameters.Text = "&Parametry połączenia z bazą danych"
    '
    'ToolStripSeparator6
    '
    Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
    Me.ToolStripSeparator6.Size = New System.Drawing.Size(278, 6)
    '
    'MenuUstawieniaSzkoly
    '
    Me.MenuUstawieniaSzkoly.Name = "MenuUstawieniaSzkoly"
    Me.MenuUstawieniaSzkoly.Size = New System.Drawing.Size(281, 22)
    Me.MenuUstawieniaSzkoly.Text = "Szkoły"
    '
    'MenuUstawieniaOrganProwadzacy
    '
    Me.MenuUstawieniaOrganProwadzacy.Name = "MenuUstawieniaOrganProwadzacy"
    Me.MenuUstawieniaOrganProwadzacy.Size = New System.Drawing.Size(281, 22)
    Me.MenuUstawieniaOrganProwadzacy.Text = "Organy prowadzące"
    '
    'ToolStripSeparator11
    '
    Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
    Me.ToolStripSeparator11.Size = New System.Drawing.Size(278, 6)
    '
    'MenuUstawieniaPrzydzialNauczyciel
    '
    Me.MenuUstawieniaPrzydzialNauczyciel.Name = "MenuUstawieniaPrzydzialNauczyciel"
    Me.MenuUstawieniaPrzydzialNauczyciel.Size = New System.Drawing.Size(281, 22)
    Me.MenuUstawieniaPrzydzialNauczyciel.Text = "Przydział nauczycieli do szkół"
    '
    'MenuUstawieniaKlasyWSzkole
    '
    Me.MenuUstawieniaKlasyWSzkole.Name = "MenuUstawieniaKlasyWSzkole"
    Me.MenuUstawieniaKlasyWSzkole.Size = New System.Drawing.Size(281, 22)
    Me.MenuUstawieniaKlasyWSzkole.Text = "Przydział oddziałów klasowych do szkół"
    '
    'ToolStripSeparator7
    '
    Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
    Me.ToolStripSeparator7.Size = New System.Drawing.Size(278, 6)
    '
    'MenuUstawieniaSlowniki
    '
    Me.MenuUstawieniaSlowniki.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SlownikiMiejscowosci, Me.SlownikiWojewodztwa, Me.SlownikiKraje, Me.ToolStripSeparator10, Me.SlownikiKlasy, Me.SlownikiPrzedmioty, Me.SlownikiNauczyciele})
    Me.MenuUstawieniaSlowniki.Name = "MenuUstawieniaSlowniki"
    Me.MenuUstawieniaSlowniki.RightToLeft = System.Windows.Forms.RightToLeft.No
    Me.MenuUstawieniaSlowniki.Size = New System.Drawing.Size(281, 22)
    Me.MenuUstawieniaSlowniki.Text = "Słowniki"
    Me.MenuUstawieniaSlowniki.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
    '
    'SlownikiMiejscowosci
    '
    Me.SlownikiMiejscowosci.Name = "SlownikiMiejscowosci"
    Me.SlownikiMiejscowosci.Size = New System.Drawing.Size(165, 22)
    Me.SlownikiMiejscowosci.Text = "Miejscowości"
    '
    'SlownikiWojewodztwa
    '
    Me.SlownikiWojewodztwa.Name = "SlownikiWojewodztwa"
    Me.SlownikiWojewodztwa.Size = New System.Drawing.Size(165, 22)
    Me.SlownikiWojewodztwa.Text = "Województwa"
    '
    'SlownikiKraje
    '
    Me.SlownikiKraje.Name = "SlownikiKraje"
    Me.SlownikiKraje.Size = New System.Drawing.Size(165, 22)
    Me.SlownikiKraje.Text = "Kraje"
    '
    'ToolStripSeparator10
    '
    Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
    Me.ToolStripSeparator10.Size = New System.Drawing.Size(162, 6)
    '
    'SlownikiKlasy
    '
    Me.SlownikiKlasy.Name = "SlownikiKlasy"
    Me.SlownikiKlasy.Size = New System.Drawing.Size(165, 22)
    Me.SlownikiKlasy.Text = "Oddziały klasowe"
    '
    'SlownikiPrzedmioty
    '
    Me.SlownikiPrzedmioty.Name = "SlownikiPrzedmioty"
    Me.SlownikiPrzedmioty.Size = New System.Drawing.Size(165, 22)
    Me.SlownikiPrzedmioty.Text = "Przedmioty"
    '
    'SlownikiNauczyciele
    '
    Me.SlownikiNauczyciele.Name = "SlownikiNauczyciele"
    Me.SlownikiNauczyciele.Size = New System.Drawing.Size(165, 22)
    Me.SlownikiNauczyciele.Text = "Nauczyciele"
    '
    'AboutToolStripMenuItem
    '
    Me.AboutToolStripMenuItem.Enabled = False
    Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
    Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(86, 20)
    Me.AboutToolStripMenuItem.Text = "O programie"
    '
    'MainStatus
    '
    Me.MainStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.statConn, Me.ToolStripStatusLabel2, Me.statUser})
    Me.MainStatus.Location = New System.Drawing.Point(0, 244)
    Me.MainStatus.Name = "MainStatus"
    Me.MainStatus.Size = New System.Drawing.Size(693, 22)
    Me.MainStatus.TabIndex = 3
    Me.MainStatus.Text = "StatusStrip1"
    '
    'ToolStripStatusLabel1
    '
    Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
    Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(42, 17)
    Me.ToolStripStatusLabel1.Text = "Status:"
    '
    'statConn
    '
    Me.statConn.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
    Me.statConn.ForeColor = System.Drawing.Color.SeaGreen
    Me.statConn.Margin = New System.Windows.Forms.Padding(0, 3, 10, 2)
    Me.statConn.Name = "statConn"
    Me.statConn.Padding = New System.Windows.Forms.Padding(0, 0, 100, 0)
    Me.statConn.Size = New System.Drawing.Size(158, 17)
    Me.statConn.Text = "statConn"
    Me.statConn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ToolStripStatusLabel2
    '
    Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
    Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(71, 17)
    Me.ToolStripStatusLabel2.Text = "Użytkownik:"
    '
    'statUser
    '
    Me.statUser.AutoSize = False
    Me.statUser.BackColor = System.Drawing.SystemColors.ButtonFace
    Me.statUser.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
    Me.statUser.ForeColor = System.Drawing.Color.Blue
    Me.statUser.Margin = New System.Windows.Forms.Padding(0, 3, 10, 2)
    Me.statUser.Name = "statUser"
    Me.statUser.Size = New System.Drawing.Size(48, 17)
    Me.statUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.statUser.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
    '
    'MenuExportBelfer
    '
    Me.MenuExportBelfer.Name = "MenuExportBelfer"
    Me.MenuExportBelfer.Size = New System.Drawing.Size(282, 22)
    Me.MenuExportBelfer.Text = "Export danych do programu Belfer"
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.SystemColors.ButtonFace
    Me.ClientSize = New System.Drawing.Size(693, 266)
    Me.Controls.Add(Me.MainStatus)
    Me.Controls.Add(Me.MainMenuToolStrip)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.IsMdiContainer = True
    Me.MainMenuStrip = Me.MainMenuToolStrip
    Me.Name = "MainForm"
    Me.Text = "Sekretariat.NET"
    Me.TransparencyKey = System.Drawing.Color.White
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.MainMenuToolStrip.ResumeLayout(False)
    Me.MainMenuToolStrip.PerformLayout()
    Me.MainStatus.ResumeLayout(False)
    Me.MainStatus.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents MainMenuToolStrip As System.Windows.Forms.MenuStrip
  Friend WithEvents PlikToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents UstawieniaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuUstawieniaManageUser As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuUstawieniaConnectionParameters As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuPlikWyloguj As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuPlikZamknij As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ZapytaniaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuPlikImport As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents UczniowieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuUczniowieDanePersonalne As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuUczniowiePromocja As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents RaportyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuUstawieniaChangePassword As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MainStatus As System.Windows.Forms.StatusStrip
  Friend WithEvents statConn As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents statUser As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents StatystykiLiczbaUczniow As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents StatystykiLiczbaUczniowWgWyboru As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents StatystykiUczniowieWgRocznikow As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents StatystykiUczniowieDrugoroczni As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents MenuUczniowieObwodPozaSzkola As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents MenuUstawieniaSlowniki As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SlownikiMiejscowosci As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SlownikiWojewodztwa As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SlownikiKlasy As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SlownikiPrzedmioty As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuUstawieniaSzkoly As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuUstawieniaOrganProwadzacy As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents MenuUstawieniaKlasyWSzkole As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents menuUczniowieDrugoroczni As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents menuUczniowieSkresleni As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents menuUczniowiePrzydzial As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents StatystykiUczniowieSkresleni As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents MenuUczniowieWychowawstwo As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents RaportyListaUczniow As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents SlownikiKraje As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents MenuUstawieniaPrzydzialNauczyciel As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents SlownikiNauczyciele As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuPlikExport As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuExportHermes As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuExportBlyskawica As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuUczniowiePozaObwod As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents MenuExportBelfer As System.Windows.Forms.ToolStripMenuItem

End Class

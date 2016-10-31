<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgStudent
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
    Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
    Me.cmdSave = New System.Windows.Forms.Button
    Me.cmdClose = New System.Windows.Forms.Button
    Me.txtNazwiskoOjca = New System.Windows.Forms.TextBox
    Me.Label11 = New System.Windows.Forms.Label
    Me.cbKlasa = New System.Windows.Forms.ComboBox
    Me.Label10 = New System.Windows.Forms.Label
    Me.txtImie2 = New System.Windows.Forms.TextBox
    Me.Label8 = New System.Windows.Forms.Label
    Me.dtDataUr = New System.Windows.Forms.DateTimePicker
    Me.Label9 = New System.Windows.Forms.Label
    Me.cbPlec = New System.Windows.Forms.ComboBox
    Me.txtImieMatki = New System.Windows.Forms.TextBox
    Me.txtImieOjca = New System.Windows.Forms.TextBox
    Me.txtNrArkusza = New System.Windows.Forms.TextBox
    Me.txtNazwisko = New System.Windows.Forms.TextBox
    Me.txtImie = New System.Windows.Forms.TextBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.chkObwod = New System.Windows.Forms.CheckBox
    Me.Label12 = New System.Windows.Forms.Label
    Me.txtNazwiskoMatki = New System.Windows.Forms.TextBox
    Me.txtPesel = New System.Windows.Forms.TextBox
    Me.Label13 = New System.Windows.Forms.Label
    Me.chkNiepelnosprawnosc = New System.Windows.Forms.CheckBox
    Me.cbMiejsceUr = New System.Windows.Forms.ComboBox
    Me.cbMiejsceZam = New System.Windows.Forms.ComboBox
    Me.Label14 = New System.Windows.Forms.Label
    Me.txtUlica = New System.Windows.Forms.TextBox
    Me.Label15 = New System.Windows.Forms.Label
    Me.txtNrDomu = New System.Windows.Forms.TextBox
    Me.Label16 = New System.Windows.Forms.Label
    Me.txtNrMieszkania = New System.Windows.Forms.TextBox
    Me.Label17 = New System.Windows.Forms.Label
    Me.txtTelKom1 = New System.Windows.Forms.TextBox
    Me.Label20 = New System.Windows.Forms.Label
    Me.txtTel1 = New System.Windows.Forms.TextBox
    Me.txtTel2 = New System.Windows.Forms.TextBox
    Me.Label21 = New System.Windows.Forms.Label
    Me.Label22 = New System.Windows.Forms.Label
    Me.txtTelKom2 = New System.Windows.Forms.TextBox
    Me.Label23 = New System.Windows.Forms.Label
    Me.txtNrLegSzkol = New System.Windows.Forms.TextBox
    Me.Label18 = New System.Windows.Forms.Label
    Me.TableLayoutPanel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.cmdSave, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.cmdClose, 1, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(510, 288)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
    Me.TableLayoutPanel1.TabIndex = 30
    '
    'cmdSave
    '
    Me.cmdSave.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.cmdSave.Enabled = False
    Me.cmdSave.Location = New System.Drawing.Point(3, 3)
    Me.cmdSave.Name = "cmdSave"
    Me.cmdSave.Size = New System.Drawing.Size(67, 23)
    Me.cmdSave.TabIndex = 24
    Me.cmdSave.Text = "&Zapisz"
    '
    'cmdClose
    '
    Me.cmdClose.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.cmdClose.Location = New System.Drawing.Point(76, 3)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(67, 23)
    Me.cmdClose.TabIndex = 25
    Me.cmdClose.Text = "&Anuluj"
    '
    'txtNazwiskoOjca
    '
    Me.txtNazwiskoOjca.Location = New System.Drawing.Point(322, 117)
    Me.txtNazwiskoOjca.Name = "txtNazwiskoOjca"
    Me.txtNazwiskoOjca.Size = New System.Drawing.Size(132, 20)
    Me.txtNazwiskoOjca.TabIndex = 13
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(235, 120)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(76, 13)
    Me.Label11.TabIndex = 45
    Me.Label11.Text = "Nazwisko ojca"
    '
    'cbKlasa
    '
    Me.cbKlasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbKlasa.FormattingEnabled = True
    Me.cbKlasa.Location = New System.Drawing.Point(322, 12)
    Me.cbKlasa.Name = "cbKlasa"
    Me.cbKlasa.Size = New System.Drawing.Size(132, 21)
    Me.cbKlasa.TabIndex = 1
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(235, 15)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(33, 13)
    Me.Label10.TabIndex = 44
    Me.Label10.Text = "Klasa"
    '
    'txtImie2
    '
    Me.txtImie2.Location = New System.Drawing.Point(525, 38)
    Me.txtImie2.Name = "txtImie2"
    Me.txtImie2.Size = New System.Drawing.Size(132, 20)
    Me.txtImie2.TabIndex = 5
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(460, 41)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(59, 13)
    Me.Label8.TabIndex = 43
    Me.Label8.Text = "Drugie imię"
    '
    'dtDataUr
    '
    Me.dtDataUr.Location = New System.Drawing.Point(322, 63)
    Me.dtDataUr.Name = "dtDataUr"
    Me.dtDataUr.Size = New System.Drawing.Size(132, 20)
    Me.dtDataUr.TabIndex = 7
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(12, 92)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(30, 13)
    Me.Label9.TabIndex = 42
    Me.Label9.Text = "Płeć"
    '
    'cbPlec
    '
    Me.cbPlec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbPlec.FormattingEnabled = True
    Me.cbPlec.Items.AddRange(New Object() {"M", "K"})
    Me.cbPlec.Location = New System.Drawing.Point(97, 90)
    Me.cbPlec.Name = "cbPlec"
    Me.cbPlec.Size = New System.Drawing.Size(132, 21)
    Me.cbPlec.TabIndex = 9
    '
    'txtImieMatki
    '
    Me.txtImieMatki.Location = New System.Drawing.Point(97, 143)
    Me.txtImieMatki.Name = "txtImieMatki"
    Me.txtImieMatki.Size = New System.Drawing.Size(132, 20)
    Me.txtImieMatki.TabIndex = 14
    '
    'txtImieOjca
    '
    Me.txtImieOjca.Location = New System.Drawing.Point(97, 117)
    Me.txtImieOjca.Margin = New System.Windows.Forms.Padding(3, 3, 3, 4)
    Me.txtImieOjca.Name = "txtImieOjca"
    Me.txtImieOjca.Size = New System.Drawing.Size(132, 20)
    Me.txtImieOjca.TabIndex = 12
    '
    'txtNrArkusza
    '
    Me.txtNrArkusza.Location = New System.Drawing.Point(97, 12)
    Me.txtNrArkusza.Name = "txtNrArkusza"
    Me.txtNrArkusza.Size = New System.Drawing.Size(132, 20)
    Me.txtNrArkusza.TabIndex = 0
    '
    'txtNazwisko
    '
    Me.txtNazwisko.Location = New System.Drawing.Point(97, 38)
    Me.txtNazwisko.Name = "txtNazwisko"
    Me.txtNazwisko.Size = New System.Drawing.Size(132, 20)
    Me.txtNazwisko.TabIndex = 3
    '
    'txtImie
    '
    Me.txtImie.Location = New System.Drawing.Point(322, 38)
    Me.txtImie.Name = "txtImie"
    Me.txtImie.Size = New System.Drawing.Size(132, 20)
    Me.txtImie.TabIndex = 4
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(460, 67)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(58, 13)
    Me.Label7.TabIndex = 38
    Me.Label7.Text = "Miejsce ur."
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(237, 67)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(45, 13)
    Me.Label6.TabIndex = 37
    Me.Label6.Text = "Data ur."
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(12, 146)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(54, 13)
    Me.Label5.TabIndex = 34
    Me.Label5.Text = "Imię matki"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(12, 120)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(49, 13)
    Me.Label4.TabIndex = 33
    Me.Label4.Text = "Imię ojca"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 15)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(79, 13)
    Me.Label3.TabIndex = 31
    Me.Label3.Text = "Nr ewidencyjny"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 41)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(53, 13)
    Me.Label2.TabIndex = 29
    Me.Label2.Text = "Nazwisko"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(235, 41)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(26, 13)
    Me.Label1.TabIndex = 27
    Me.Label1.Text = "Imię"
    '
    'chkObwod
    '
    Me.chkObwod.AutoSize = True
    Me.chkObwod.Location = New System.Drawing.Point(525, 14)
    Me.chkObwod.Name = "chkObwod"
    Me.chkObwod.Size = New System.Drawing.Size(97, 17)
    Me.chkObwod.TabIndex = 2
    Me.chkObwod.Text = "Obwód własny"
    Me.chkObwod.UseVisualStyleBackColor = True
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(235, 146)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(81, 13)
    Me.Label12.TabIndex = 49
    Me.Label12.Text = "Nazwisko matki"
    '
    'txtNazwiskoMatki
    '
    Me.txtNazwiskoMatki.Location = New System.Drawing.Point(322, 143)
    Me.txtNazwiskoMatki.Name = "txtNazwiskoMatki"
    Me.txtNazwiskoMatki.Size = New System.Drawing.Size(132, 20)
    Me.txtNazwiskoMatki.TabIndex = 15
    '
    'txtPesel
    '
    Me.txtPesel.Location = New System.Drawing.Point(97, 64)
    Me.txtPesel.Name = "txtPesel"
    Me.txtPesel.Size = New System.Drawing.Size(132, 20)
    Me.txtPesel.TabIndex = 6
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(12, 67)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(33, 13)
    Me.Label13.TabIndex = 51
    Me.Label13.Text = "Pesel"
    '
    'chkNiepelnosprawnosc
    '
    Me.chkNiepelnosprawnosc.AutoSize = True
    Me.chkNiepelnosprawnosc.Location = New System.Drawing.Point(525, 92)
    Me.chkNiepelnosprawnosc.Name = "chkNiepelnosprawnosc"
    Me.chkNiepelnosprawnosc.Size = New System.Drawing.Size(121, 17)
    Me.chkNiepelnosprawnosc.TabIndex = 11
    Me.chkNiepelnosprawnosc.Text = "Niepełnosprawność"
    Me.chkNiepelnosprawnosc.UseVisualStyleBackColor = True
    '
    'cbMiejsceUr
    '
    Me.cbMiejsceUr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbMiejsceUr.DropDownWidth = 300
    Me.cbMiejsceUr.FormattingEnabled = True
    Me.cbMiejsceUr.Location = New System.Drawing.Point(525, 64)
    Me.cbMiejsceUr.Name = "cbMiejsceUr"
    Me.cbMiejsceUr.Size = New System.Drawing.Size(132, 21)
    Me.cbMiejsceUr.TabIndex = 8
    '
    'cbMiejsceZam
    '
    Me.cbMiejsceZam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbMiejsceZam.DropDownWidth = 300
    Me.cbMiejsceZam.FormattingEnabled = True
    Me.cbMiejsceZam.Location = New System.Drawing.Point(97, 169)
    Me.cbMiejsceZam.Name = "cbMiejsceZam"
    Me.cbMiejsceZam.Size = New System.Drawing.Size(132, 21)
    Me.cbMiejsceZam.TabIndex = 16
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(12, 172)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(68, 13)
    Me.Label14.TabIndex = 57
    Me.Label14.Text = "Miejsce zam."
    '
    'txtUlica
    '
    Me.txtUlica.Location = New System.Drawing.Point(322, 169)
    Me.txtUlica.Name = "txtUlica"
    Me.txtUlica.Size = New System.Drawing.Size(132, 20)
    Me.txtUlica.TabIndex = 17
    '
    'Label15
    '
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(235, 172)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(31, 13)
    Me.Label15.TabIndex = 59
    Me.Label15.Text = "Ulica"
    '
    'txtNrDomu
    '
    Me.txtNrDomu.Location = New System.Drawing.Point(525, 169)
    Me.txtNrDomu.Name = "txtNrDomu"
    Me.txtNrDomu.Size = New System.Drawing.Size(35, 20)
    Me.txtNrDomu.TabIndex = 18
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(460, 172)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(47, 13)
    Me.Label16.TabIndex = 61
    Me.Label16.Text = "Nr domu"
    '
    'txtNrMieszkania
    '
    Me.txtNrMieszkania.Location = New System.Drawing.Point(622, 169)
    Me.txtNrMieszkania.Name = "txtNrMieszkania"
    Me.txtNrMieszkania.Size = New System.Drawing.Size(35, 20)
    Me.txtNrMieszkania.TabIndex = 19
    '
    'Label17
    '
    Me.Label17.AutoSize = True
    Me.Label17.Location = New System.Drawing.Point(566, 172)
    Me.Label17.Name = "Label17"
    Me.Label17.Size = New System.Drawing.Size(56, 13)
    Me.Label17.TabIndex = 63
    Me.Label17.Text = "Nr mieszk."
    '
    'txtTelKom1
    '
    Me.txtTelKom1.Location = New System.Drawing.Point(97, 221)
    Me.txtTelKom1.Name = "txtTelKom1"
    Me.txtTelKom1.Size = New System.Drawing.Size(132, 20)
    Me.txtTelKom1.TabIndex = 22
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Location = New System.Drawing.Point(12, 224)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(60, 13)
    Me.Label20.TabIndex = 75
    Me.Label20.Text = "Tel. kom. 1"
    '
    'txtTel1
    '
    Me.txtTel1.Location = New System.Drawing.Point(97, 195)
    Me.txtTel1.Name = "txtTel1"
    Me.txtTel1.Size = New System.Drawing.Size(132, 20)
    Me.txtTel1.TabIndex = 20
    '
    'txtTel2
    '
    Me.txtTel2.Location = New System.Drawing.Point(322, 195)
    Me.txtTel2.Name = "txtTel2"
    Me.txtTel2.Size = New System.Drawing.Size(132, 20)
    Me.txtTel2.TabIndex = 21
    '
    'Label21
    '
    Me.Label21.AutoSize = True
    Me.Label21.Location = New System.Drawing.Point(12, 198)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(34, 13)
    Me.Label21.TabIndex = 71
    Me.Label21.Text = "Tel. 1"
    '
    'Label22
    '
    Me.Label22.AutoSize = True
    Me.Label22.Location = New System.Drawing.Point(235, 198)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(34, 13)
    Me.Label22.TabIndex = 70
    Me.Label22.Text = "Tel. 2"
    '
    'txtTelKom2
    '
    Me.txtTelKom2.Location = New System.Drawing.Point(322, 221)
    Me.txtTelKom2.Name = "txtTelKom2"
    Me.txtTelKom2.Size = New System.Drawing.Size(132, 20)
    Me.txtTelKom2.TabIndex = 23
    '
    'Label23
    '
    Me.Label23.AutoSize = True
    Me.Label23.Location = New System.Drawing.Point(237, 224)
    Me.Label23.Name = "Label23"
    Me.Label23.Size = New System.Drawing.Size(60, 13)
    Me.Label23.TabIndex = 77
    Me.Label23.Text = "Tel. kom. 2"
    '
    'txtNrLegSzkol
    '
    Me.txtNrLegSzkol.Location = New System.Drawing.Point(322, 90)
    Me.txtNrLegSzkol.Name = "txtNrLegSzkol"
    Me.txtNrLegSzkol.Size = New System.Drawing.Size(132, 20)
    Me.txtNrLegSzkol.TabIndex = 10
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Location = New System.Drawing.Point(237, 93)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(60, 13)
    Me.Label18.TabIndex = 79
    Me.Label18.Text = "Nr leg. szk."
    '
    'dlgStudent
    '
    Me.AcceptButton = Me.cmdSave
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.cmdClose
    Me.ClientSize = New System.Drawing.Size(668, 329)
    Me.Controls.Add(Me.txtNrLegSzkol)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.txtTelKom2)
    Me.Controls.Add(Me.Label23)
    Me.Controls.Add(Me.txtTelKom1)
    Me.Controls.Add(Me.Label20)
    Me.Controls.Add(Me.txtTel1)
    Me.Controls.Add(Me.txtTel2)
    Me.Controls.Add(Me.Label21)
    Me.Controls.Add(Me.Label22)
    Me.Controls.Add(Me.txtNrMieszkania)
    Me.Controls.Add(Me.Label17)
    Me.Controls.Add(Me.txtNrDomu)
    Me.Controls.Add(Me.Label16)
    Me.Controls.Add(Me.txtUlica)
    Me.Controls.Add(Me.Label15)
    Me.Controls.Add(Me.cbMiejsceZam)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.cbMiejsceUr)
    Me.Controls.Add(Me.chkNiepelnosprawnosc)
    Me.Controls.Add(Me.txtPesel)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.txtNazwiskoMatki)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.chkObwod)
    Me.Controls.Add(Me.txtNazwiskoOjca)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.cbKlasa)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.txtImie2)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.dtDataUr)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.cbPlec)
    Me.Controls.Add(Me.txtImieMatki)
    Me.Controls.Add(Me.txtImieOjca)
    Me.Controls.Add(Me.txtNrArkusza)
    Me.Controls.Add(Me.txtNazwisko)
    Me.Controls.Add(Me.txtImie)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "dlgStudent"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "dlgStudent"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents cmdSave As System.Windows.Forms.Button
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents txtNazwiskoOjca As System.Windows.Forms.TextBox
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents cbKlasa As System.Windows.Forms.ComboBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents txtImie2 As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents dtDataUr As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents cbPlec As System.Windows.Forms.ComboBox
  Friend WithEvents txtImieMatki As System.Windows.Forms.TextBox
  Friend WithEvents txtImieOjca As System.Windows.Forms.TextBox
  Friend WithEvents txtNrArkusza As System.Windows.Forms.TextBox
  Friend WithEvents txtNazwisko As System.Windows.Forms.TextBox
  Friend WithEvents txtImie As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents chkObwod As System.Windows.Forms.CheckBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents txtNazwiskoMatki As System.Windows.Forms.TextBox
  Friend WithEvents txtPesel As System.Windows.Forms.TextBox
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents chkNiepelnosprawnosc As System.Windows.Forms.CheckBox
  Friend WithEvents cbMiejsceUr As System.Windows.Forms.ComboBox
  Friend WithEvents cbMiejsceZam As System.Windows.Forms.ComboBox
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents txtUlica As System.Windows.Forms.TextBox
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents txtNrDomu As System.Windows.Forms.TextBox
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents txtNrMieszkania As System.Windows.Forms.TextBox
  Friend WithEvents Label17 As System.Windows.Forms.Label
  Friend WithEvents txtTelKom1 As System.Windows.Forms.TextBox
  Friend WithEvents Label20 As System.Windows.Forms.Label
  Friend WithEvents txtTel1 As System.Windows.Forms.TextBox
  Friend WithEvents txtTel2 As System.Windows.Forms.TextBox
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents txtTelKom2 As System.Windows.Forms.TextBox
  Friend WithEvents Label23 As System.Windows.Forms.Label
  Friend WithEvents txtNrLegSzkol As System.Windows.Forms.TextBox
  Friend WithEvents Label18 As System.Windows.Forms.Label

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgSzkola
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
    Me.OK_Button = New System.Windows.Forms.Button
    Me.Cancel_Button = New System.Windows.Forms.Button
    Me.txtNazwa = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtAlias = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.txtNip = New System.Windows.Forms.TextBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.cbMiejscowosc = New System.Windows.Forms.ComboBox
    Me.Label5 = New System.Windows.Forms.Label
    Me.txtUlica = New System.Windows.Forms.TextBox
    Me.Label6 = New System.Windows.Forms.Label
    Me.txtNr = New System.Windows.Forms.TextBox
    Me.chkIsDefault = New System.Windows.Forms.CheckBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.Label8 = New System.Windows.Forms.Label
    Me.Label9 = New System.Windows.Forms.Label
    Me.txtTel = New System.Windows.Forms.TextBox
    Me.txtFax = New System.Windows.Forms.TextBox
    Me.txtEmail = New System.Windows.Forms.TextBox
    Me.Label10 = New System.Windows.Forms.Label
    Me.Label11 = New System.Windows.Forms.Label
    Me.txtOKEID = New System.Windows.Forms.TextBox
    Me.cbOrgan = New System.Windows.Forms.ComboBox
    Me.TableLayoutPanel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(441, 172)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
    Me.TableLayoutPanel1.TabIndex = 12
    '
    'OK_Button
    '
    Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.OK_Button.Enabled = False
    Me.OK_Button.Location = New System.Drawing.Point(3, 3)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(67, 23)
    Me.OK_Button.TabIndex = 12
    Me.OK_Button.Text = "OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
    Me.Cancel_Button.TabIndex = 13
    Me.Cancel_Button.Text = "Anuluj"
    '
    'txtNazwa
    '
    Me.txtNazwa.Location = New System.Drawing.Point(86, 12)
    Me.txtNazwa.Name = "txtNazwa"
    Me.txtNazwa.Size = New System.Drawing.Size(393, 20)
    Me.txtNazwa.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Nazwa"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(13, 41)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(29, 13)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Alias"
    '
    'txtAlias
    '
    Me.txtAlias.Location = New System.Drawing.Point(86, 38)
    Me.txtAlias.Name = "txtAlias"
    Me.txtAlias.Size = New System.Drawing.Size(181, 20)
    Me.txtAlias.TabIndex = 2
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(273, 41)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(25, 13)
    Me.Label3.TabIndex = 5
    Me.Label3.Text = "NIP"
    '
    'txtNip
    '
    Me.txtNip.Location = New System.Drawing.Point(310, 38)
    Me.txtNip.MaxLength = 10
    Me.txtNip.Name = "txtNip"
    Me.txtNip.Size = New System.Drawing.Size(169, 20)
    Me.txtNip.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(12, 67)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(68, 13)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "Miejscowość"
    '
    'cbMiejscowosc
    '
    Me.cbMiejscowosc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbMiejscowosc.FormattingEnabled = True
    Me.cbMiejscowosc.Location = New System.Drawing.Point(86, 64)
    Me.cbMiejscowosc.Name = "cbMiejscowosc"
    Me.cbMiejscowosc.Size = New System.Drawing.Size(181, 21)
    Me.cbMiejscowosc.TabIndex = 4
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(273, 67)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(31, 13)
    Me.Label5.TabIndex = 9
    Me.Label5.Text = "Ulica"
    '
    'txtUlica
    '
    Me.txtUlica.Location = New System.Drawing.Point(310, 64)
    Me.txtUlica.Name = "txtUlica"
    Me.txtUlica.Size = New System.Drawing.Size(169, 20)
    Me.txtUlica.TabIndex = 5
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(485, 67)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(18, 13)
    Me.Label6.TabIndex = 11
    Me.Label6.Text = "Nr"
    '
    'txtNr
    '
    Me.txtNr.Location = New System.Drawing.Point(509, 64)
    Me.txtNr.Name = "txtNr"
    Me.txtNr.Size = New System.Drawing.Size(75, 20)
    Me.txtNr.TabIndex = 6
    '
    'chkIsDefault
    '
    Me.chkIsDefault.AutoSize = True
    Me.chkIsDefault.Location = New System.Drawing.Point(485, 15)
    Me.chkIsDefault.Name = "chkIsDefault"
    Me.chkIsDefault.Size = New System.Drawing.Size(74, 17)
    Me.chkIsDefault.TabIndex = 1
    Me.chkIsDefault.Text = "Domyślnie"
    Me.chkIsDefault.UseVisualStyleBackColor = True
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(13, 94)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(43, 13)
    Me.Label7.TabIndex = 14
    Me.Label7.Text = "Telefon"
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(192, 94)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(24, 13)
    Me.Label8.TabIndex = 15
    Me.Label8.Text = "Fax"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(328, 94)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(35, 13)
    Me.Label9.TabIndex = 16
    Me.Label9.Text = "E-mail"
    '
    'txtTel
    '
    Me.txtTel.Location = New System.Drawing.Point(86, 91)
    Me.txtTel.Name = "txtTel"
    Me.txtTel.Size = New System.Drawing.Size(100, 20)
    Me.txtTel.TabIndex = 7
    '
    'txtFax
    '
    Me.txtFax.Location = New System.Drawing.Point(222, 91)
    Me.txtFax.Name = "txtFax"
    Me.txtFax.Size = New System.Drawing.Size(100, 20)
    Me.txtFax.TabIndex = 8
    '
    'txtEmail
    '
    Me.txtEmail.Location = New System.Drawing.Point(369, 91)
    Me.txtEmail.Name = "txtEmail"
    Me.txtEmail.Size = New System.Drawing.Size(215, 20)
    Me.txtEmail.TabIndex = 9
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(13, 120)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(43, 13)
    Me.Label10.TabIndex = 20
    Me.Label10.Text = "OKE ID"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(267, 120)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(96, 13)
    Me.Label11.TabIndex = 21
    Me.Label11.Text = "Organ prowadzący"
    '
    'txtOKEID
    '
    Me.txtOKEID.Location = New System.Drawing.Point(86, 117)
    Me.txtOKEID.Name = "txtOKEID"
    Me.txtOKEID.Size = New System.Drawing.Size(169, 20)
    Me.txtOKEID.TabIndex = 10
    '
    'cbOrgan
    '
    Me.cbOrgan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbOrgan.FormattingEnabled = True
    Me.cbOrgan.Location = New System.Drawing.Point(369, 117)
    Me.cbOrgan.Name = "cbOrgan"
    Me.cbOrgan.Size = New System.Drawing.Size(215, 21)
    Me.cbOrgan.TabIndex = 11
    '
    'dlgSzkola
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(599, 213)
    Me.Controls.Add(Me.cbOrgan)
    Me.Controls.Add(Me.txtOKEID)
    Me.Controls.Add(Me.Label11)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.txtEmail)
    Me.Controls.Add(Me.txtFax)
    Me.Controls.Add(Me.txtTel)
    Me.Controls.Add(Me.Label9)
    Me.Controls.Add(Me.Label8)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.chkIsDefault)
    Me.Controls.Add(Me.txtNr)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.txtUlica)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.cbMiejscowosc)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.txtNip)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtAlias)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtNazwa)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "dlgSzkola"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Dodawanie szkoły"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents txtNazwa As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtAlias As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtNip As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents cbMiejscowosc As System.Windows.Forms.ComboBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtUlica As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtNr As System.Windows.Forms.TextBox
  Friend WithEvents chkIsDefault As System.Windows.Forms.CheckBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents txtTel As System.Windows.Forms.TextBox
  Friend WithEvents txtFax As System.Windows.Forms.TextBox
  Friend WithEvents txtEmail As System.Windows.Forms.TextBox
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents txtOKEID As System.Windows.Forms.TextBox
  Friend WithEvents cbOrgan As System.Windows.Forms.ComboBox

End Class

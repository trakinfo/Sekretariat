<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgOrgan
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
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtNazwa = New System.Windows.Forms.TextBox
    Me.txtRodzaj = New System.Windows.Forms.TextBox
    Me.Label3 = New System.Windows.Forms.Label
    Me.cbMiejscowosc = New System.Windows.Forms.ComboBox
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label5 = New System.Windows.Forms.Label
    Me.txtUlica = New System.Windows.Forms.TextBox
    Me.txtNr = New System.Windows.Forms.TextBox
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
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(296, 137)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
    Me.TableLayoutPanel1.TabIndex = 5
    '
    'OK_Button
    '
    Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.OK_Button.Enabled = False
    Me.OK_Button.Location = New System.Drawing.Point(3, 3)
    Me.OK_Button.Name = "OK_Button"
    Me.OK_Button.Size = New System.Drawing.Size(67, 23)
    Me.OK_Button.TabIndex = 5
    Me.OK_Button.Text = "OK"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
    Me.Cancel_Button.TabIndex = 6
    Me.Cancel_Button.Text = "Anuluj"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(40, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Rodzaj"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 41)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(40, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Nazwa"
    '
    'txtNazwa
    '
    Me.txtNazwa.Location = New System.Drawing.Point(86, 38)
    Me.txtNazwa.Name = "txtNazwa"
    Me.txtNazwa.Size = New System.Drawing.Size(358, 20)
    Me.txtNazwa.TabIndex = 1
    '
    'txtRodzaj
    '
    Me.txtRodzaj.Location = New System.Drawing.Point(86, 12)
    Me.txtRodzaj.Name = "txtRodzaj"
    Me.txtRodzaj.Size = New System.Drawing.Size(267, 20)
    Me.txtRodzaj.TabIndex = 0
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 67)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(68, 13)
    Me.Label3.TabIndex = 5
    Me.Label3.Text = "Miejscowość"
    '
    'cbMiejscowosc
    '
    Me.cbMiejscowosc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbMiejscowosc.FormattingEnabled = True
    Me.cbMiejscowosc.Location = New System.Drawing.Point(86, 64)
    Me.cbMiejscowosc.Name = "cbMiejscowosc"
    Me.cbMiejscowosc.Size = New System.Drawing.Size(267, 21)
    Me.cbMiejscowosc.TabIndex = 2
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(13, 94)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(31, 13)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "Ulica"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(359, 94)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(18, 13)
    Me.Label5.TabIndex = 8
    Me.Label5.Text = "Nr"
    '
    'txtUlica
    '
    Me.txtUlica.Location = New System.Drawing.Point(86, 91)
    Me.txtUlica.Name = "txtUlica"
    Me.txtUlica.Size = New System.Drawing.Size(267, 20)
    Me.txtUlica.TabIndex = 3
    '
    'txtNr
    '
    Me.txtNr.Location = New System.Drawing.Point(383, 91)
    Me.txtNr.Name = "txtNr"
    Me.txtNr.Size = New System.Drawing.Size(61, 20)
    Me.txtNr.TabIndex = 4
    '
    'dlgOrgan
    '
    Me.AcceptButton = Me.OK_Button
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(454, 178)
    Me.Controls.Add(Me.txtNr)
    Me.Controls.Add(Me.txtUlica)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.cbMiejscowosc)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtRodzaj)
    Me.Controls.Add(Me.txtNazwa)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "dlgOrgan"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Dodawanie organu prowadzącego"
    Me.TableLayoutPanel1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents OK_Button As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtNazwa As System.Windows.Forms.TextBox
  Friend WithEvents txtRodzaj As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents cbMiejscowosc As System.Windows.Forms.ComboBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtUlica As System.Windows.Forms.TextBox
  Friend WithEvents txtNr As System.Windows.Forms.TextBox

End Class

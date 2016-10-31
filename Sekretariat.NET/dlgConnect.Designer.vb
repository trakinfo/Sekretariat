<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class dlgConnect
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
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.UsernameLabel = New System.Windows.Forms.Label
    Me.PasswordLabel = New System.Windows.Forms.Label
    Me.txtUserName = New System.Windows.Forms.TextBox
    Me.txtPassword = New System.Windows.Forms.TextBox
    Me.OK = New System.Windows.Forms.Button
    Me.Cancel = New System.Windows.Forms.Button
    Me.txtSerwerIP = New System.Windows.Forms.TextBox
    Me.Label2 = New System.Windows.Forms.Label
    Me.txtDBName = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.SuspendLayout()
    '
    'UsernameLabel
    '
    Me.UsernameLabel.Location = New System.Drawing.Point(12, 73)
    Me.UsernameLabel.Name = "UsernameLabel"
    Me.UsernameLabel.Size = New System.Drawing.Size(156, 23)
    Me.UsernameLabel.TabIndex = 0
    Me.UsernameLabel.Text = "Użytkownik systemowy"
    Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'PasswordLabel
    '
    Me.PasswordLabel.Location = New System.Drawing.Point(12, 99)
    Me.PasswordLabel.Name = "PasswordLabel"
    Me.PasswordLabel.Size = New System.Drawing.Size(220, 23)
    Me.PasswordLabel.TabIndex = 2
    Me.PasswordLabel.Text = "Hasło do bazy danych"
    Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'txtUserName
    '
    Me.txtUserName.Location = New System.Drawing.Point(174, 75)
    Me.txtUserName.Name = "txtUserName"
    Me.txtUserName.Size = New System.Drawing.Size(220, 20)
    Me.txtUserName.TabIndex = 3
    '
    'txtPassword
    '
    Me.txtPassword.Location = New System.Drawing.Point(174, 101)
    Me.txtPassword.Name = "txtPassword"
    Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txtPassword.Size = New System.Drawing.Size(220, 20)
    Me.txtPassword.TabIndex = 4
    '
    'OK
    '
    Me.OK.Location = New System.Drawing.Point(197, 161)
    Me.OK.Name = "OK"
    Me.OK.Size = New System.Drawing.Size(94, 23)
    Me.OK.TabIndex = 4
    Me.OK.Text = "&OK"
    '
    'Cancel
    '
    Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel.Location = New System.Drawing.Point(300, 161)
    Me.Cancel.Name = "Cancel"
    Me.Cancel.Size = New System.Drawing.Size(94, 23)
    Me.Cancel.TabIndex = 5
    Me.Cancel.Text = "&Anuluj"
    '
    'txtSerwerIP
    '
    Me.txtSerwerIP.Location = New System.Drawing.Point(174, 23)
    Me.txtSerwerIP.Name = "txtSerwerIP"
    Me.txtSerwerIP.Size = New System.Drawing.Size(220, 20)
    Me.txtSerwerIP.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(12, 21)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(156, 23)
    Me.Label2.TabIndex = 6
    Me.Label2.Text = "Serwer IP"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'txtDBName
    '
    Me.txtDBName.Location = New System.Drawing.Point(174, 49)
    Me.txtDBName.Name = "txtDBName"
    Me.txtDBName.Size = New System.Drawing.Size(220, 20)
    Me.txtDBName.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(12, 47)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(156, 23)
    Me.Label1.TabIndex = 8
    Me.Label1.Text = "Baza danych"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'dlgConnect
    '
    Me.AcceptButton = Me.OK
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel
    Me.ClientSize = New System.Drawing.Size(401, 192)
    Me.Controls.Add(Me.txtDBName)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtSerwerIP)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Cancel)
    Me.Controls.Add(Me.OK)
    Me.Controls.Add(Me.txtPassword)
    Me.Controls.Add(Me.txtUserName)
    Me.Controls.Add(Me.PasswordLabel)
    Me.Controls.Add(Me.UsernameLabel)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "dlgConnect"
    Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Parametry połączenia z bazą danych"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
    Friend WithEvents txtSerwerIP As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDBName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class

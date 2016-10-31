<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgExportInfo
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
    Me.lblInfo = New System.Windows.Forms.Label()
    Me.lblError = New System.Windows.Forms.Label()
    Me.lblSuccess = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.lblTotal = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.pbExport = New System.Windows.Forms.ProgressBar()
    Me.txtDetails = New System.Windows.Forms.TextBox()
    Me.SuspendLayout()
    '
    'lblInfo
    '
    Me.lblInfo.AutoSize = True
    Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblInfo.ForeColor = System.Drawing.Color.DimGray
    Me.lblInfo.Location = New System.Drawing.Point(12, 9)
    Me.lblInfo.Name = "lblInfo"
    Me.lblInfo.Size = New System.Drawing.Size(42, 13)
    Me.lblInfo.TabIndex = 74
    Me.lblInfo.Text = "lblInfo"
    '
    'lblError
    '
    Me.lblError.AutoSize = True
    Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblError.ForeColor = System.Drawing.Color.Red
    Me.lblError.Location = New System.Drawing.Point(263, 107)
    Me.lblError.Name = "lblError"
    Me.lblError.Size = New System.Drawing.Size(47, 13)
    Me.lblError.TabIndex = 73
    Me.lblError.Text = "lblError"
    '
    'lblSuccess
    '
    Me.lblSuccess.AutoSize = True
    Me.lblSuccess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblSuccess.ForeColor = System.Drawing.Color.Green
    Me.lblSuccess.Location = New System.Drawing.Point(105, 107)
    Me.lblSuccess.Name = "lblSuccess"
    Me.lblSuccess.Size = New System.Drawing.Size(68, 13)
    Me.lblSuccess.TabIndex = 72
    Me.lblSuccess.Text = "lblSuccess"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(210, 107)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(47, 13)
    Me.Label4.TabIndex = 71
    Me.Label4.Text = "Błędów:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(9, 107)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(90, 13)
    Me.Label3.TabIndex = 70
    Me.Label3.Text = "Wyeksportowano"
    '
    'lblTotal
    '
    Me.lblTotal.AutoSize = True
    Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaption
    Me.lblTotal.Location = New System.Drawing.Point(157, 42)
    Me.lblTotal.Name = "lblTotal"
    Me.lblTotal.Size = New System.Drawing.Size(49, 13)
    Me.lblTotal.TabIndex = 69
    Me.lblTotal.Text = "lblTotal"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
    Me.Label2.Location = New System.Drawing.Point(9, 42)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(142, 13)
    Me.Label2.TabIndex = 68
    Me.Label2.Text = "Rekordów do przetworzenia:"
    '
    'pbExport
    '
    Me.pbExport.Location = New System.Drawing.Point(12, 69)
    Me.pbExport.Name = "pbExport"
    Me.pbExport.Size = New System.Drawing.Size(490, 23)
    Me.pbExport.Step = 1
    Me.pbExport.Style = System.Windows.Forms.ProgressBarStyle.Continuous
    Me.pbExport.TabIndex = 67
    '
    'txtDetails
    '
    Me.txtDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtDetails.Location = New System.Drawing.Point(12, 135)
    Me.txtDetails.Multiline = True
    Me.txtDetails.Name = "txtDetails"
    Me.txtDetails.ReadOnly = True
    Me.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtDetails.Size = New System.Drawing.Size(490, 237)
    Me.txtDetails.TabIndex = 66
    '
    'dlgExportInfo
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(514, 384)
    Me.Controls.Add(Me.lblInfo)
    Me.Controls.Add(Me.lblError)
    Me.Controls.Add(Me.lblSuccess)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.lblTotal)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.pbExport)
    Me.Controls.Add(Me.txtDetails)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "dlgExportInfo"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Export danych"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lblInfo As System.Windows.Forms.Label
  Friend WithEvents lblError As System.Windows.Forms.Label
  Friend WithEvents lblSuccess As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents lblTotal As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents pbExport As System.Windows.Forms.ProgressBar
  Friend WithEvents txtDetails As System.Windows.Forms.TextBox

End Class

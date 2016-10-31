<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgExport
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
    Me.cmdExport = New System.Windows.Forms.Button
    Me.Cancel_Button = New System.Windows.Forms.Button
    Me.txtDetails = New System.Windows.Forms.TextBox
    Me.lblInfo = New System.Windows.Forms.Label
    Me.lblError = New System.Windows.Forms.Label
    Me.lblSuccess = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.lblTotal = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.pbExport = New System.Windows.Forms.ProgressBar
    Me.cmdDetails = New System.Windows.Forms.Button
    Me.cbSzkola = New System.Windows.Forms.ComboBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.nudEndYear = New System.Windows.Forms.NumericUpDown
    Me.nudStartYear = New System.Windows.Forms.NumericUpDown
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label7 = New System.Windows.Forms.Label
    Me.TableLayoutPanel1.SuspendLayout()
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TableLayoutPanel1
    '
    Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TableLayoutPanel1.ColumnCount = 2
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Controls.Add(Me.cmdExport, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(359, 385)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'cmdExport
    '
    Me.cmdExport.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.cmdExport.Enabled = False
    Me.cmdExport.Location = New System.Drawing.Point(3, 3)
    Me.cmdExport.Name = "cmdExport"
    Me.cmdExport.Size = New System.Drawing.Size(67, 23)
    Me.cmdExport.TabIndex = 0
    Me.cmdExport.Text = "&Eksportuj"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "&Zamknij"
    '
    'txtDetails
    '
    Me.txtDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.txtDetails.Location = New System.Drawing.Point(12, 183)
    Me.txtDetails.Multiline = True
    Me.txtDetails.Name = "txtDetails"
    Me.txtDetails.ReadOnly = True
    Me.txtDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtDetails.Size = New System.Drawing.Size(490, 196)
    Me.txtDetails.TabIndex = 1
    '
    'lblInfo
    '
    Me.lblInfo.AutoSize = True
    Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblInfo.ForeColor = System.Drawing.Color.DimGray
    Me.lblInfo.Location = New System.Drawing.Point(12, 59)
    Me.lblInfo.Name = "lblInfo"
    Me.lblInfo.Size = New System.Drawing.Size(42, 13)
    Me.lblInfo.TabIndex = 49
    Me.lblInfo.Text = "lblInfo"
    '
    'lblError
    '
    Me.lblError.AutoSize = True
    Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblError.ForeColor = System.Drawing.Color.Red
    Me.lblError.Location = New System.Drawing.Point(266, 154)
    Me.lblError.Name = "lblError"
    Me.lblError.Size = New System.Drawing.Size(47, 13)
    Me.lblError.TabIndex = 48
    Me.lblError.Text = "lblError"
    '
    'lblSuccess
    '
    Me.lblSuccess.AutoSize = True
    Me.lblSuccess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblSuccess.ForeColor = System.Drawing.Color.Green
    Me.lblSuccess.Location = New System.Drawing.Point(108, 154)
    Me.lblSuccess.Name = "lblSuccess"
    Me.lblSuccess.Size = New System.Drawing.Size(68, 13)
    Me.lblSuccess.TabIndex = 47
    Me.lblSuccess.Text = "lblSuccess"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(213, 154)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(47, 13)
    Me.Label4.TabIndex = 46
    Me.Label4.Text = "Błędów:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 154)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(90, 13)
    Me.Label3.TabIndex = 45
    Me.Label3.Text = "Wyeksportowano"
    '
    'lblTotal
    '
    Me.lblTotal.AutoSize = True
    Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaption
    Me.lblTotal.Location = New System.Drawing.Point(157, 92)
    Me.lblTotal.Name = "lblTotal"
    Me.lblTotal.Size = New System.Drawing.Size(49, 13)
    Me.lblTotal.TabIndex = 44
    Me.lblTotal.Text = "lblTotal"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
    Me.Label2.Location = New System.Drawing.Point(9, 92)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(142, 13)
    Me.Label2.TabIndex = 43
    Me.Label2.Text = "Rekordów do przetworzenia:"
    '
    'pbExport
    '
    Me.pbExport.Location = New System.Drawing.Point(12, 118)
    Me.pbExport.Name = "pbExport"
    Me.pbExport.Size = New System.Drawing.Size(490, 23)
    Me.pbExport.Step = 1
    Me.pbExport.Style = System.Windows.Forms.ProgressBarStyle.Continuous
    Me.pbExport.TabIndex = 42
    '
    'cmdDetails
    '
    Me.cmdDetails.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdDetails.Location = New System.Drawing.Point(12, 388)
    Me.cmdDetails.Name = "cmdDetails"
    Me.cmdDetails.Size = New System.Drawing.Size(75, 23)
    Me.cmdDetails.TabIndex = 50
    Me.cmdDetails.Text = "Szczegóły"
    Me.cmdDetails.UseVisualStyleBackColor = True
    '
    'cbSzkola
    '
    Me.cbSzkola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbSzkola.FormattingEnabled = True
    Me.cbSzkola.Location = New System.Drawing.Point(56, 11)
    Me.cbSzkola.Name = "cbSzkola"
    Me.cbSzkola.Size = New System.Drawing.Size(232, 21)
    Me.cbSzkola.TabIndex = 51
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.Label1.Location = New System.Drawing.Point(426, 9)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(15, 24)
    Me.Label1.TabIndex = 55
    Me.Label1.Text = "/"
    '
    'nudEndYear
    '
    Me.nudEndYear.Enabled = False
    Me.nudEndYear.Location = New System.Drawing.Point(447, 12)
    Me.nudEndYear.Maximum = New Decimal(New Integer() {2051, 0, 0, 0})
    Me.nudEndYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudEndYear.Name = "nudEndYear"
    Me.nudEndYear.Size = New System.Drawing.Size(55, 20)
    Me.nudEndYear.TabIndex = 54
    Me.nudEndYear.Value = New Decimal(New Integer() {2007, 0, 0, 0})
    '
    'nudStartYear
    '
    Me.nudStartYear.Location = New System.Drawing.Point(365, 12)
    Me.nudStartYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
    Me.nudStartYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudStartYear.Name = "nudStartYear"
    Me.nudStartYear.Size = New System.Drawing.Size(55, 20)
    Me.nudStartYear.TabIndex = 53
    Me.nudStartYear.Value = New Decimal(New Integer() {2006, 0, 0, 0})
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(294, 17)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(65, 13)
    Me.Label5.TabIndex = 52
    Me.Label5.Text = "Rok szkolny"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(9, 14)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(41, 13)
    Me.Label7.TabIndex = 56
    Me.Label7.Text = "Szkoła"
    '
    'dlgExport
    '
    Me.AcceptButton = Me.cmdExport
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(517, 426)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.nudEndYear)
    Me.Controls.Add(Me.nudStartYear)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.cbSzkola)
    Me.Controls.Add(Me.cmdDetails)
    Me.Controls.Add(Me.lblInfo)
    Me.Controls.Add(Me.lblError)
    Me.Controls.Add(Me.lblSuccess)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.lblTotal)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.pbExport)
    Me.Controls.Add(Me.txtDetails)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "dlgExport"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Export danych do programu Hermes"
    Me.TableLayoutPanel1.ResumeLayout(False)
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents cmdExport As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents txtDetails As System.Windows.Forms.TextBox
  Friend WithEvents lblInfo As System.Windows.Forms.Label
  Friend WithEvents lblError As System.Windows.Forms.Label
  Friend WithEvents lblSuccess As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents lblTotal As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents pbExport As System.Windows.Forms.ProgressBar
  Friend WithEvents cmdDetails As System.Windows.Forms.Button
  Friend WithEvents cbSzkola As System.Windows.Forms.ComboBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents nudEndYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents nudStartYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgImportStudents
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
    Me.cmdImport = New System.Windows.Forms.Button
    Me.Cancel_Button = New System.Windows.Forms.Button
    Me.Label6 = New System.Windows.Forms.Label
    Me.cmdFileDialog = New System.Windows.Forms.Button
    Me.txtFile = New System.Windows.Forms.TextBox
    Me.pbImport = New System.Windows.Forms.ProgressBar
    Me.lblTotal = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.lblError = New System.Windows.Forms.Label
    Me.lblSuccess = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.lblInfo = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.nudEndYear = New System.Windows.Forms.NumericUpDown
    Me.nudStartYear = New System.Windows.Forms.NumericUpDown
    Me.Label5 = New System.Windows.Forms.Label
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
    Me.TableLayoutPanel1.Controls.Add(Me.cmdImport, 0, 0)
    Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
    Me.TableLayoutPanel1.Location = New System.Drawing.Point(261, 229)
    Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
    Me.TableLayoutPanel1.RowCount = 1
    Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
    Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
    Me.TableLayoutPanel1.TabIndex = 0
    '
    'cmdImport
    '
    Me.cmdImport.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.cmdImport.Enabled = False
    Me.cmdImport.Location = New System.Drawing.Point(3, 3)
    Me.cmdImport.Name = "cmdImport"
    Me.cmdImport.Size = New System.Drawing.Size(67, 23)
    Me.cmdImport.TabIndex = 0
    Me.cmdImport.Text = "Importuj"
    '
    'Cancel_Button
    '
    Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
    Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
    Me.Cancel_Button.TabIndex = 1
    Me.Cancel_Button.Text = "Zamknij"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(12, 15)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(24, 13)
    Me.Label6.TabIndex = 30
    Me.Label6.Text = "Plik"
    '
    'cmdFileDialog
    '
    Me.cmdFileDialog.AutoSize = True
    Me.cmdFileDialog.Location = New System.Drawing.Point(343, 9)
    Me.cmdFileDialog.Name = "cmdFileDialog"
    Me.cmdFileDialog.Size = New System.Drawing.Size(67, 23)
    Me.cmdFileDialog.TabIndex = 29
    Me.cmdFileDialog.Text = "Przeglądaj"
    Me.cmdFileDialog.UseVisualStyleBackColor = True
    '
    'txtFile
    '
    Me.txtFile.Location = New System.Drawing.Point(42, 12)
    Me.txtFile.Name = "txtFile"
    Me.txtFile.Size = New System.Drawing.Size(295, 20)
    Me.txtFile.TabIndex = 28
    '
    'pbImport
    '
    Me.pbImport.Location = New System.Drawing.Point(12, 162)
    Me.pbImport.Name = "pbImport"
    Me.pbImport.Size = New System.Drawing.Size(398, 23)
    Me.pbImport.Step = 1
    Me.pbImport.Style = System.Windows.Forms.ProgressBarStyle.Continuous
    Me.pbImport.TabIndex = 31
    '
    'lblTotal
    '
    Me.lblTotal.AutoSize = True
    Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblTotal.ForeColor = System.Drawing.SystemColors.ActiveCaption
    Me.lblTotal.Location = New System.Drawing.Point(167, 136)
    Me.lblTotal.Name = "lblTotal"
    Me.lblTotal.Size = New System.Drawing.Size(49, 13)
    Me.lblTotal.TabIndex = 33
    Me.lblTotal.Text = "lblTotal"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
    Me.Label2.Location = New System.Drawing.Point(12, 136)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(142, 13)
    Me.Label2.TabIndex = 32
    Me.Label2.Text = "Rekordów do przetworzenia:"
    '
    'lblError
    '
    Me.lblError.AutoSize = True
    Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblError.ForeColor = System.Drawing.Color.Red
    Me.lblError.Location = New System.Drawing.Point(261, 198)
    Me.lblError.Name = "lblError"
    Me.lblError.Size = New System.Drawing.Size(47, 13)
    Me.lblError.TabIndex = 37
    Me.lblError.Text = "lblError"
    '
    'lblSuccess
    '
    Me.lblSuccess.AutoSize = True
    Me.lblSuccess.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblSuccess.ForeColor = System.Drawing.Color.Green
    Me.lblSuccess.Location = New System.Drawing.Point(104, 198)
    Me.lblSuccess.Name = "lblSuccess"
    Me.lblSuccess.Size = New System.Drawing.Size(68, 13)
    Me.lblSuccess.TabIndex = 36
    Me.lblSuccess.Text = "lblSuccess"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(208, 198)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(47, 13)
    Me.Label4.TabIndex = 35
    Me.Label4.Text = "Błędów:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 198)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(83, 13)
    Me.Label3.TabIndex = 34
    Me.Label3.Text = "Zaimportowano:"
    '
    'lblInfo
    '
    Me.lblInfo.AutoSize = True
    Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblInfo.ForeColor = System.Drawing.Color.DimGray
    Me.lblInfo.Location = New System.Drawing.Point(12, 107)
    Me.lblInfo.Name = "lblInfo"
    Me.lblInfo.Size = New System.Drawing.Size(42, 13)
    Me.lblInfo.TabIndex = 38
    Me.lblInfo.Text = "lblInfo"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.Label1.Location = New System.Drawing.Point(201, 40)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(15, 24)
    Me.Label1.TabIndex = 68
    Me.Label1.Text = "/"
    '
    'nudEndYear
    '
    Me.nudEndYear.Enabled = False
    Me.nudEndYear.Location = New System.Drawing.Point(217, 42)
    Me.nudEndYear.Maximum = New Decimal(New Integer() {2051, 0, 0, 0})
    Me.nudEndYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudEndYear.Name = "nudEndYear"
    Me.nudEndYear.Size = New System.Drawing.Size(55, 20)
    Me.nudEndYear.TabIndex = 67
    Me.nudEndYear.Value = New Decimal(New Integer() {2007, 0, 0, 0})
    '
    'nudStartYear
    '
    Me.nudStartYear.Location = New System.Drawing.Point(140, 42)
    Me.nudStartYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
    Me.nudStartYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudStartYear.Name = "nudStartYear"
    Me.nudStartYear.Size = New System.Drawing.Size(55, 20)
    Me.nudStartYear.TabIndex = 66
    Me.nudStartYear.Value = New Decimal(New Integer() {2006, 0, 0, 0})
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(12, 44)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(121, 13)
    Me.Label5.TabIndex = 65
    Me.Label5.Text = "Przydział na rok szkolny"
    '
    'dlgImportStudents
    '
    Me.AcceptButton = Me.cmdImport
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.CancelButton = Me.Cancel_Button
    Me.ClientSize = New System.Drawing.Size(419, 270)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.nudEndYear)
    Me.Controls.Add(Me.nudStartYear)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.lblInfo)
    Me.Controls.Add(Me.lblError)
    Me.Controls.Add(Me.lblSuccess)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.lblTotal)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.pbImport)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.cmdFileDialog)
    Me.Controls.Add(Me.txtFile)
    Me.Controls.Add(Me.TableLayoutPanel1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "dlgImportStudents"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
    Me.Text = "Import danych ucznia"
    Me.TableLayoutPanel1.ResumeLayout(False)
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents cmdImport As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents cmdFileDialog As System.Windows.Forms.Button
  Friend WithEvents txtFile As System.Windows.Forms.TextBox
  Friend WithEvents pbImport As System.Windows.Forms.ProgressBar
  Friend WithEvents lblTotal As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents lblError As System.Windows.Forms.Label
  Friend WithEvents lblSuccess As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents lblInfo As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents nudEndYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents nudStartYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label5 As System.Windows.Forms.Label

End Class

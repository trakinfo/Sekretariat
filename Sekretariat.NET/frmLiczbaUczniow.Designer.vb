<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiczbaUczniow
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
    Me.lvZestawienie = New System.Windows.Forms.ListView
    Me.txtLiczbaUczniowSzkola = New System.Windows.Forms.TextBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.cbSzkola = New System.Windows.Forms.ComboBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.nudEndYear = New System.Windows.Forms.NumericUpDown
    Me.nudStartYear = New System.Windows.Forms.NumericUpDown
    Me.Label5 = New System.Windows.Forms.Label
    Me.cmdPrint = New System.Windows.Forms.Button
    Me.cmdClose = New System.Windows.Forms.Button
    Me.chkVirtual = New System.Windows.Forms.CheckBox
    Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
    Me.lvPionKlas = New System.Windows.Forms.ListView
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'lvZestawienie
    '
    Me.lvZestawienie.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lvZestawienie.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
    Me.lvZestawienie.Location = New System.Drawing.Point(12, 195)
    Me.lvZestawienie.Name = "lvZestawienie"
    Me.lvZestawienie.Size = New System.Drawing.Size(245, 302)
    Me.lvZestawienie.TabIndex = 10
    Me.lvZestawienie.UseCompatibleStateImageBehavior = False
    '
    'txtLiczbaUczniowSzkola
    '
    Me.txtLiczbaUczniowSzkola.BackColor = System.Drawing.SystemColors.Info
    Me.txtLiczbaUczniowSzkola.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.txtLiczbaUczniowSzkola.ForeColor = System.Drawing.Color.Blue
    Me.txtLiczbaUczniowSzkola.Location = New System.Drawing.Point(145, 91)
    Me.txtLiczbaUczniowSzkola.Name = "txtLiczbaUczniowSzkola"
    Me.txtLiczbaUczniowSzkola.ReadOnly = True
    Me.txtLiczbaUczniowSzkola.Size = New System.Drawing.Size(112, 20)
    Me.txtLiczbaUczniowSzkola.TabIndex = 9
    Me.txtLiczbaUczniowSzkola.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 94)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(127, 13)
    Me.Label1.TabIndex = 8
    Me.Label1.Text = "Liczba uczniów w szkole:"
    '
    'cbSzkola
    '
    Me.cbSzkola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbSzkola.FormattingEnabled = True
    Me.cbSzkola.Location = New System.Drawing.Point(59, 12)
    Me.cbSzkola.Name = "cbSzkola"
    Me.cbSzkola.Size = New System.Drawing.Size(200, 21)
    Me.cbSzkola.TabIndex = 26
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(12, 15)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(41, 13)
    Me.Label7.TabIndex = 25
    Me.Label7.Text = "Szkoła"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.Label6.Location = New System.Drawing.Point(144, 41)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(15, 24)
    Me.Label6.TabIndex = 24
    Me.Label6.Text = "/"
    '
    'nudEndYear
    '
    Me.nudEndYear.Enabled = False
    Me.nudEndYear.Location = New System.Drawing.Point(160, 43)
    Me.nudEndYear.Maximum = New Decimal(New Integer() {2051, 0, 0, 0})
    Me.nudEndYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudEndYear.Name = "nudEndYear"
    Me.nudEndYear.Size = New System.Drawing.Size(55, 20)
    Me.nudEndYear.TabIndex = 23
    Me.nudEndYear.Value = New Decimal(New Integer() {2007, 0, 0, 0})
    '
    'nudStartYear
    '
    Me.nudStartYear.Location = New System.Drawing.Point(83, 43)
    Me.nudStartYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
    Me.nudStartYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudStartYear.Name = "nudStartYear"
    Me.nudStartYear.Size = New System.Drawing.Size(55, 20)
    Me.nudStartYear.TabIndex = 22
    Me.nudStartYear.Value = New Decimal(New Integer() {2006, 0, 0, 0})
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(12, 45)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(65, 13)
    Me.Label5.TabIndex = 21
    Me.Label5.Text = "Rok szkolny"
    '
    'cmdPrint
    '
    Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdPrint.Enabled = False
    Me.cmdPrint.Location = New System.Drawing.Point(265, 445)
    Me.cmdPrint.Name = "cmdPrint"
    Me.cmdPrint.Size = New System.Drawing.Size(95, 23)
    Me.cmdPrint.TabIndex = 27
    Me.cmdPrint.Text = "&Drukuj"
    Me.cmdPrint.UseVisualStyleBackColor = True
    '
    'cmdClose
    '
    Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdClose.Location = New System.Drawing.Point(265, 474)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(95, 23)
    Me.cmdClose.TabIndex = 28
    Me.cmdClose.Text = "&Zamknij"
    Me.cmdClose.UseVisualStyleBackColor = True
    '
    'chkVirtual
    '
    Me.chkVirtual.AutoSize = True
    Me.chkVirtual.Location = New System.Drawing.Point(265, 14)
    Me.chkVirtual.Name = "chkVirtual"
    Me.chkVirtual.Size = New System.Drawing.Size(107, 17)
    Me.chkVirtual.TabIndex = 53
    Me.chkVirtual.Text = "Oddział wirtualny"
    Me.chkVirtual.UseVisualStyleBackColor = True
    '
    'ShapeContainer1
    '
    Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
    Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
    Me.ShapeContainer1.Name = "ShapeContainer1"
    Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
    Me.ShapeContainer1.Size = New System.Drawing.Size(372, 510)
    Me.ShapeContainer1.TabIndex = 54
    Me.ShapeContainer1.TabStop = False
    '
    'LineShape1
    '
    Me.LineShape1.BorderColor = System.Drawing.Color.White
    Me.LineShape1.Name = "LineShape1"
    Me.LineShape1.X1 = 11
    Me.LineShape1.X2 = 364
    Me.LineShape1.Y1 = 76
    Me.LineShape1.Y2 = 76
    '
    'lvPionKlas
    '
    Me.lvPionKlas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
    Me.lvPionKlas.Location = New System.Drawing.Point(11, 122)
    Me.lvPionKlas.Name = "lvPionKlas"
    Me.lvPionKlas.Size = New System.Drawing.Size(245, 67)
    Me.lvPionKlas.TabIndex = 55
    Me.lvPionKlas.UseCompatibleStateImageBehavior = False
    '
    'frmLiczbaUczniow
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(372, 510)
    Me.Controls.Add(Me.lvPionKlas)
    Me.Controls.Add(Me.chkVirtual)
    Me.Controls.Add(Me.cmdClose)
    Me.Controls.Add(Me.cmdPrint)
    Me.Controls.Add(Me.cbSzkola)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.nudEndYear)
    Me.Controls.Add(Me.nudStartYear)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.lvZestawienie)
    Me.Controls.Add(Me.txtLiczbaUczniowSzkola)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.ShapeContainer1)
    Me.MaximumSize = New System.Drawing.Size(380, 700)
    Me.MinimumSize = New System.Drawing.Size(354, 500)
    Me.Name = "frmLiczbaUczniow"
    Me.Text = "Liczba uczniów ogółem w szkole i w klasach"
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lvZestawienie As System.Windows.Forms.ListView
  Friend WithEvents txtLiczbaUczniowSzkola As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cbSzkola As System.Windows.Forms.ComboBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents nudEndYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents nudStartYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents cmdPrint As System.Windows.Forms.Button
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents chkVirtual As System.Windows.Forms.CheckBox
  Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
  Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
  Friend WithEvents lvPionKlas As System.Windows.Forms.ListView
End Class

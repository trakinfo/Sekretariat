<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiczbaUczniowByMiejscowoscByRocznik
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
    Me.chkVirtual = New System.Windows.Forms.CheckBox
    Me.cbSzkola = New System.Windows.Forms.ComboBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.nudEndYear = New System.Windows.Forms.NumericUpDown
    Me.nudStartYear = New System.Windows.Forms.NumericUpDown
    Me.Label5 = New System.Windows.Forms.Label
    Me.cmdClose = New System.Windows.Forms.Button
    Me.cmdPrint = New System.Windows.Forms.Button
    Me.dgvStudentsByPlaceByYear = New System.Windows.Forms.DataGridView
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.dgvStudentsByPlaceByYear, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'chkVirtual
    '
    Me.chkVirtual.AutoSize = True
    Me.chkVirtual.Location = New System.Drawing.Point(489, 14)
    Me.chkVirtual.Name = "chkVirtual"
    Me.chkVirtual.Size = New System.Drawing.Size(107, 17)
    Me.chkVirtual.TabIndex = 74
    Me.chkVirtual.Text = "Oddział wirtualny"
    Me.chkVirtual.UseVisualStyleBackColor = True
    '
    'cbSzkola
    '
    Me.cbSzkola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbSzkola.FormattingEnabled = True
    Me.cbSzkola.Location = New System.Drawing.Point(56, 12)
    Me.cbSzkola.Name = "cbSzkola"
    Me.cbSzkola.Size = New System.Drawing.Size(200, 21)
    Me.cbSzkola.TabIndex = 73
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(9, 15)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(41, 13)
    Me.Label7.TabIndex = 72
    Me.Label7.Text = "Szkoła"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.Label6.Location = New System.Drawing.Point(399, 11)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(15, 24)
    Me.Label6.TabIndex = 71
    Me.Label6.Text = "/"
    '
    'nudEndYear
    '
    Me.nudEndYear.Enabled = False
    Me.nudEndYear.Location = New System.Drawing.Point(415, 13)
    Me.nudEndYear.Maximum = New Decimal(New Integer() {2051, 0, 0, 0})
    Me.nudEndYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudEndYear.Name = "nudEndYear"
    Me.nudEndYear.Size = New System.Drawing.Size(55, 20)
    Me.nudEndYear.TabIndex = 70
    Me.nudEndYear.Value = New Decimal(New Integer() {2007, 0, 0, 0})
    '
    'nudStartYear
    '
    Me.nudStartYear.Location = New System.Drawing.Point(338, 13)
    Me.nudStartYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
    Me.nudStartYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudStartYear.Name = "nudStartYear"
    Me.nudStartYear.Size = New System.Drawing.Size(55, 20)
    Me.nudStartYear.TabIndex = 69
    Me.nudStartYear.Value = New Decimal(New Integer() {2006, 0, 0, 0})
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(267, 15)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(65, 13)
    Me.Label5.TabIndex = 68
    Me.Label5.Text = "Rok szkolny"
    '
    'cmdClose
    '
    Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdClose.Location = New System.Drawing.Point(797, 506)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(75, 23)
    Me.cmdClose.TabIndex = 75
    Me.cmdClose.Text = "&Zamknij"
    Me.cmdClose.UseVisualStyleBackColor = True
    '
    'cmdPrint
    '
    Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdPrint.Enabled = False
    Me.cmdPrint.Location = New System.Drawing.Point(797, 477)
    Me.cmdPrint.Name = "cmdPrint"
    Me.cmdPrint.Size = New System.Drawing.Size(75, 23)
    Me.cmdPrint.TabIndex = 76
    Me.cmdPrint.Text = "&Drukuj"
    Me.cmdPrint.UseVisualStyleBackColor = True
    '
    'dgvStudentsByPlaceByYear
    '
    Me.dgvStudentsByPlaceByYear.AllowUserToAddRows = False
    Me.dgvStudentsByPlaceByYear.AllowUserToDeleteRows = False
    Me.dgvStudentsByPlaceByYear.AllowUserToResizeColumns = False
    Me.dgvStudentsByPlaceByYear.AllowUserToResizeRows = False
    Me.dgvStudentsByPlaceByYear.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.dgvStudentsByPlaceByYear.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
    Me.dgvStudentsByPlaceByYear.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    Me.dgvStudentsByPlaceByYear.EnableHeadersVisualStyles = False
    Me.dgvStudentsByPlaceByYear.Location = New System.Drawing.Point(12, 39)
    Me.dgvStudentsByPlaceByYear.Name = "dgvStudentsByPlaceByYear"
    Me.dgvStudentsByPlaceByYear.ReadOnly = True
    Me.dgvStudentsByPlaceByYear.RowHeadersVisible = False
    Me.dgvStudentsByPlaceByYear.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dgvStudentsByPlaceByYear.Size = New System.Drawing.Size(779, 490)
    Me.dgvStudentsByPlaceByYear.TabIndex = 77
    '
    'frmLiczbaUczniowByMiejscowoscByRocznik
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(884, 541)
    Me.Controls.Add(Me.dgvStudentsByPlaceByYear)
    Me.Controls.Add(Me.cmdPrint)
    Me.Controls.Add(Me.cmdClose)
    Me.Controls.Add(Me.chkVirtual)
    Me.Controls.Add(Me.cbSzkola)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.nudEndYear)
    Me.Controls.Add(Me.nudStartYear)
    Me.Controls.Add(Me.Label5)
    Me.Name = "frmLiczbaUczniowByMiejscowoscByRocznik"
    Me.Text = "Liczba uczniów z podziałem na roczniki wg miejscowości zamieszkania"
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.dgvStudentsByPlaceByYear, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents chkVirtual As System.Windows.Forms.CheckBox
  Friend WithEvents cbSzkola As System.Windows.Forms.ComboBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents nudEndYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents nudStartYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents cmdPrint As System.Windows.Forms.Button
  Friend WithEvents dgvStudentsByPlaceByYear As System.Windows.Forms.DataGridView
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiczbaUczniowByChoice
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
    Me.cmdClose = New System.Windows.Forms.Button
    Me.gpbZakres = New System.Windows.Forms.GroupBox
    Me.rbPion = New System.Windows.Forms.RadioButton
    Me.rbKlasa = New System.Windows.Forms.RadioButton
    Me.rbSzkola = New System.Windows.Forms.RadioButton
    Me.gpbRodzajZestawienia = New System.Windows.Forms.GroupBox
    Me.rbMiastoUr = New System.Windows.Forms.RadioButton
    Me.rbMiastoZam = New System.Windows.Forms.RadioButton
    Me.rbPlec = New System.Windows.Forms.RadioButton
    Me.rbMiejsceZam = New System.Windows.Forms.RadioButton
    Me.rbMiejsceUr = New System.Windows.Forms.RadioButton
    Me.rbRokUr = New System.Windows.Forms.RadioButton
    Me.lvZestawienie = New System.Windows.Forms.ListView
    Me.chkVirtual = New System.Windows.Forms.CheckBox
    Me.cbSzkola = New System.Windows.Forms.ComboBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.nudEndYear = New System.Windows.Forms.NumericUpDown
    Me.nudStartYear = New System.Windows.Forms.NumericUpDown
    Me.Label5 = New System.Windows.Forms.Label
    Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
    Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Me.cmdPrint = New System.Windows.Forms.Button
    Me.gpbZakres.SuspendLayout()
    Me.gpbRodzajZestawienia.SuspendLayout()
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cmdClose
    '
    Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdClose.Location = New System.Drawing.Point(591, 363)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(75, 23)
    Me.cmdClose.TabIndex = 13
    Me.cmdClose.Text = "&Zamknij"
    Me.cmdClose.UseVisualStyleBackColor = True
    '
    'gpbZakres
    '
    Me.gpbZakres.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gpbZakres.Controls.Add(Me.rbPion)
    Me.gpbZakres.Controls.Add(Me.rbKlasa)
    Me.gpbZakres.Controls.Add(Me.rbSzkola)
    Me.gpbZakres.Enabled = False
    Me.gpbZakres.Location = New System.Drawing.Point(523, 55)
    Me.gpbZakres.Name = "gpbZakres"
    Me.gpbZakres.Size = New System.Drawing.Size(143, 96)
    Me.gpbZakres.TabIndex = 12
    Me.gpbZakres.TabStop = False
    Me.gpbZakres.Text = "Zakres"
    '
    'rbPion
    '
    Me.rbPion.AutoSize = True
    Me.rbPion.Location = New System.Drawing.Point(6, 42)
    Me.rbPion.Name = "rbPion"
    Me.rbPion.Size = New System.Drawing.Size(96, 17)
    Me.rbPion.TabIndex = 1
    Me.rbPion.Text = "w pionach klas"
    Me.rbPion.UseVisualStyleBackColor = True
    '
    'rbKlasa
    '
    Me.rbKlasa.AutoSize = True
    Me.rbKlasa.Location = New System.Drawing.Point(6, 65)
    Me.rbKlasa.Name = "rbKlasa"
    Me.rbKlasa.Size = New System.Drawing.Size(73, 17)
    Me.rbKlasa.TabIndex = 2
    Me.rbKlasa.Text = "w klasach"
    Me.rbKlasa.UseVisualStyleBackColor = True
    '
    'rbSzkola
    '
    Me.rbSzkola.AutoSize = True
    Me.rbSzkola.Checked = True
    Me.rbSzkola.Location = New System.Drawing.Point(6, 19)
    Me.rbSzkola.Name = "rbSzkola"
    Me.rbSzkola.Size = New System.Drawing.Size(93, 17)
    Me.rbSzkola.TabIndex = 0
    Me.rbSzkola.TabStop = True
    Me.rbSzkola.Text = "w całej szkole"
    Me.rbSzkola.UseVisualStyleBackColor = True
    '
    'gpbRodzajZestawienia
    '
    Me.gpbRodzajZestawienia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gpbRodzajZestawienia.Controls.Add(Me.rbMiastoUr)
    Me.gpbRodzajZestawienia.Controls.Add(Me.rbMiastoZam)
    Me.gpbRodzajZestawienia.Controls.Add(Me.rbPlec)
    Me.gpbRodzajZestawienia.Controls.Add(Me.rbMiejsceZam)
    Me.gpbRodzajZestawienia.Controls.Add(Me.rbMiejsceUr)
    Me.gpbRodzajZestawienia.Controls.Add(Me.rbRokUr)
    Me.gpbRodzajZestawienia.Enabled = False
    Me.gpbRodzajZestawienia.Location = New System.Drawing.Point(523, 157)
    Me.gpbRodzajZestawienia.Name = "gpbRodzajZestawienia"
    Me.gpbRodzajZestawienia.Size = New System.Drawing.Size(143, 159)
    Me.gpbRodzajZestawienia.TabIndex = 11
    Me.gpbRodzajZestawienia.TabStop = False
    Me.gpbRodzajZestawienia.Text = "Rodzaj zestawienia"
    '
    'rbMiastoUr
    '
    Me.rbMiastoUr.AutoSize = True
    Me.rbMiastoUr.Location = New System.Drawing.Point(6, 134)
    Me.rbMiastoUr.Name = "rbMiastoUr"
    Me.rbMiastoUr.Size = New System.Drawing.Size(113, 17)
    Me.rbMiastoUr.TabIndex = 5
    Me.rbMiastoUr.TabStop = True
    Me.rbMiastoUr.Tag = "StatusUr"
    Me.rbMiastoUr.Text = "wg miasto/wieś ur."
    Me.rbMiastoUr.UseVisualStyleBackColor = True
    '
    'rbMiastoZam
    '
    Me.rbMiastoZam.AutoSize = True
    Me.rbMiastoZam.Location = New System.Drawing.Point(6, 111)
    Me.rbMiastoZam.Name = "rbMiastoZam"
    Me.rbMiastoZam.Size = New System.Drawing.Size(123, 17)
    Me.rbMiastoZam.TabIndex = 4
    Me.rbMiastoZam.TabStop = True
    Me.rbMiastoZam.Tag = "StatusZam"
    Me.rbMiastoZam.Text = "wg miasto/wieś zam."
    Me.rbMiastoZam.UseVisualStyleBackColor = True
    '
    'rbPlec
    '
    Me.rbPlec.AutoSize = True
    Me.rbPlec.Location = New System.Drawing.Point(6, 88)
    Me.rbPlec.Name = "rbPlec"
    Me.rbPlec.Size = New System.Drawing.Size(60, 17)
    Me.rbPlec.TabIndex = 3
    Me.rbPlec.TabStop = True
    Me.rbPlec.Tag = "Sex"
    Me.rbPlec.Text = "wg płci"
    Me.rbPlec.UseVisualStyleBackColor = True
    '
    'rbMiejsceZam
    '
    Me.rbMiejsceZam.AutoSize = True
    Me.rbMiejsceZam.Location = New System.Drawing.Point(6, 65)
    Me.rbMiejsceZam.Name = "rbMiejsceZam"
    Me.rbMiejsceZam.Size = New System.Drawing.Size(129, 17)
    Me.rbMiejsceZam.TabIndex = 2
    Me.rbMiejsceZam.Tag = "MiejsceZam"
    Me.rbMiejsceZam.Text = "wg miejscowości zam."
    Me.rbMiejsceZam.UseVisualStyleBackColor = True
    '
    'rbMiejsceUr
    '
    Me.rbMiejsceUr.AutoSize = True
    Me.rbMiejsceUr.Location = New System.Drawing.Point(6, 42)
    Me.rbMiejsceUr.Name = "rbMiejsceUr"
    Me.rbMiejsceUr.Size = New System.Drawing.Size(119, 17)
    Me.rbMiejsceUr.TabIndex = 1
    Me.rbMiejsceUr.Tag = "MiejsceUr"
    Me.rbMiejsceUr.Text = "wg miejscowości ur."
    Me.rbMiejsceUr.UseVisualStyleBackColor = True
    '
    'rbRokUr
    '
    Me.rbRokUr.AutoSize = True
    Me.rbRokUr.Checked = True
    Me.rbRokUr.Location = New System.Drawing.Point(6, 19)
    Me.rbRokUr.Name = "rbRokUr"
    Me.rbRokUr.Size = New System.Drawing.Size(78, 17)
    Me.rbRokUr.TabIndex = 0
    Me.rbRokUr.TabStop = True
    Me.rbRokUr.Tag = "RokUr"
    Me.rbRokUr.Text = "wg roku ur."
    Me.rbRokUr.UseVisualStyleBackColor = True
    '
    'lvZestawienie
    '
    Me.lvZestawienie.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lvZestawienie.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
    Me.lvZestawienie.Location = New System.Drawing.Point(7, 55)
    Me.lvZestawienie.Name = "lvZestawienie"
    Me.lvZestawienie.Size = New System.Drawing.Size(505, 331)
    Me.lvZestawienie.TabIndex = 10
    Me.lvZestawienie.UseCompatibleStateImageBehavior = False
    '
    'chkVirtual
    '
    Me.chkVirtual.AutoSize = True
    Me.chkVirtual.Location = New System.Drawing.Point(479, 14)
    Me.chkVirtual.Name = "chkVirtual"
    Me.chkVirtual.Size = New System.Drawing.Size(107, 17)
    Me.chkVirtual.TabIndex = 60
    Me.chkVirtual.Text = "Oddział wirtualny"
    Me.chkVirtual.UseVisualStyleBackColor = True
    '
    'cbSzkola
    '
    Me.cbSzkola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbSzkola.FormattingEnabled = True
    Me.cbSzkola.Location = New System.Drawing.Point(51, 12)
    Me.cbSzkola.Name = "cbSzkola"
    Me.cbSzkola.Size = New System.Drawing.Size(200, 21)
    Me.cbSzkola.TabIndex = 59
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(4, 15)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(41, 13)
    Me.Label7.TabIndex = 58
    Me.Label7.Text = "Szkoła"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.Label6.Location = New System.Drawing.Point(389, 11)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(15, 24)
    Me.Label6.TabIndex = 57
    Me.Label6.Text = "/"
    '
    'nudEndYear
    '
    Me.nudEndYear.Enabled = False
    Me.nudEndYear.Location = New System.Drawing.Point(405, 13)
    Me.nudEndYear.Maximum = New Decimal(New Integer() {2051, 0, 0, 0})
    Me.nudEndYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudEndYear.Name = "nudEndYear"
    Me.nudEndYear.Size = New System.Drawing.Size(55, 20)
    Me.nudEndYear.TabIndex = 56
    Me.nudEndYear.Value = New Decimal(New Integer() {2007, 0, 0, 0})
    '
    'nudStartYear
    '
    Me.nudStartYear.Location = New System.Drawing.Point(328, 13)
    Me.nudStartYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
    Me.nudStartYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudStartYear.Name = "nudStartYear"
    Me.nudStartYear.Size = New System.Drawing.Size(55, 20)
    Me.nudStartYear.TabIndex = 55
    Me.nudStartYear.Value = New Decimal(New Integer() {2006, 0, 0, 0})
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(257, 15)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(65, 13)
    Me.Label5.TabIndex = 54
    Me.Label5.Text = "Rok szkolny"
    '
    'LineShape1
    '
    Me.LineShape1.BorderColor = System.Drawing.Color.White
    Me.LineShape1.Name = "LineShape1"
    Me.LineShape1.X1 = 7
    Me.LineShape1.X2 = 665
    Me.LineShape1.Y1 = 43
    Me.LineShape1.Y2 = 43
    '
    'ShapeContainer1
    '
    Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
    Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
    Me.ShapeContainer1.Name = "ShapeContainer1"
    Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
    Me.ShapeContainer1.Size = New System.Drawing.Size(678, 398)
    Me.ShapeContainer1.TabIndex = 61
    Me.ShapeContainer1.TabStop = False
    '
    'cmdPrint
    '
    Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdPrint.Enabled = False
    Me.cmdPrint.Location = New System.Drawing.Point(591, 334)
    Me.cmdPrint.Name = "cmdPrint"
    Me.cmdPrint.Size = New System.Drawing.Size(75, 23)
    Me.cmdPrint.TabIndex = 62
    Me.cmdPrint.Text = "&Drukuj"
    Me.cmdPrint.UseVisualStyleBackColor = True
    '
    'frmLiczbaUczniowByChoice
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(678, 398)
    Me.Controls.Add(Me.cmdPrint)
    Me.Controls.Add(Me.chkVirtual)
    Me.Controls.Add(Me.cbSzkola)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.nudEndYear)
    Me.Controls.Add(Me.nudStartYear)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.cmdClose)
    Me.Controls.Add(Me.gpbZakres)
    Me.Controls.Add(Me.gpbRodzajZestawienia)
    Me.Controls.Add(Me.lvZestawienie)
    Me.Controls.Add(Me.ShapeContainer1)
    Me.MaximumSize = New System.Drawing.Size(686, 700)
    Me.MinimumSize = New System.Drawing.Size(686, 432)
    Me.Name = "frmLiczbaUczniowByChoice"
    Me.Text = "Liczba uczniów wg wybranego kryterium"
    Me.gpbZakres.ResumeLayout(False)
    Me.gpbZakres.PerformLayout()
    Me.gpbRodzajZestawienia.ResumeLayout(False)
    Me.gpbRodzajZestawienia.PerformLayout()
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents gpbZakres As System.Windows.Forms.GroupBox
  Friend WithEvents rbKlasa As System.Windows.Forms.RadioButton
  Friend WithEvents rbSzkola As System.Windows.Forms.RadioButton
  Friend WithEvents gpbRodzajZestawienia As System.Windows.Forms.GroupBox
  Friend WithEvents rbPlec As System.Windows.Forms.RadioButton
  Friend WithEvents rbMiejsceZam As System.Windows.Forms.RadioButton
  Friend WithEvents rbMiejsceUr As System.Windows.Forms.RadioButton
  Friend WithEvents rbRokUr As System.Windows.Forms.RadioButton
  Friend WithEvents lvZestawienie As System.Windows.Forms.ListView
  Friend WithEvents chkVirtual As System.Windows.Forms.CheckBox
  Friend WithEvents cbSzkola As System.Windows.Forms.ComboBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents nudEndYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents nudStartYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
  Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
  Friend WithEvents cmdPrint As System.Windows.Forms.Button
  Friend WithEvents rbPion As System.Windows.Forms.RadioButton
  Friend WithEvents rbMiastoZam As System.Windows.Forms.RadioButton
  Friend WithEvents rbMiastoUr As System.Windows.Forms.RadioButton
End Class

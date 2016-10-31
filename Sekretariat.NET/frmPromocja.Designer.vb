<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromocja
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
    Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
    Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape
    Me.cmdClose = New System.Windows.Forms.Button
    Me.cmdDelete = New System.Windows.Forms.Button
    Me.cmdAdd = New System.Windows.Forms.Button
    Me.lvPromowani = New System.Windows.Forms.ListView
    Me.Label14 = New System.Windows.Forms.Label
    Me.Label12 = New System.Windows.Forms.Label
    Me.lblData = New System.Windows.Forms.Label
    Me.lblIP = New System.Windows.Forms.Label
    Me.lblUser = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.cbKlasa = New System.Windows.Forms.ComboBox
    Me.lvNiepromowani = New System.Windows.Forms.ListView
    Me.lblRecord = New System.Windows.Forms.Label
    Me.Label8 = New System.Windows.Forms.Label
    Me.lblRecord1 = New System.Windows.Forms.Label
    Me.Label10 = New System.Windows.Forms.Label
    Me.gpbZakres = New System.Windows.Forms.GroupBox
    Me.rbWybranaKlasa = New System.Windows.Forms.RadioButton
    Me.rbWszystkieKlasy = New System.Windows.Forms.RadioButton
    Me.gpbOpcje = New System.Windows.Forms.GroupBox
    Me.rbUnselected = New System.Windows.Forms.RadioButton
    Me.rbSelected = New System.Windows.Forms.RadioButton
    Me.Label4 = New System.Windows.Forms.Label
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpbZakres.SuspendLayout()
    Me.gpbOpcje.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'chkVirtual
    '
    Me.chkVirtual.AutoSize = True
    Me.chkVirtual.Location = New System.Drawing.Point(590, 14)
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
    Me.cbSzkola.Location = New System.Drawing.Point(59, 12)
    Me.cbSzkola.Name = "cbSzkola"
    Me.cbSzkola.Size = New System.Drawing.Size(200, 21)
    Me.cbSzkola.TabIndex = 73
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(12, 15)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(41, 13)
    Me.Label7.TabIndex = 72
    Me.Label7.Text = "Szkoła"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.Label6.Location = New System.Drawing.Point(508, 11)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(15, 24)
    Me.Label6.TabIndex = 71
    Me.Label6.Text = "/"
    '
    'nudEndYear
    '
    Me.nudEndYear.Enabled = False
    Me.nudEndYear.Location = New System.Drawing.Point(529, 13)
    Me.nudEndYear.Maximum = New Decimal(New Integer() {2051, 0, 0, 0})
    Me.nudEndYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudEndYear.Name = "nudEndYear"
    Me.nudEndYear.Size = New System.Drawing.Size(55, 20)
    Me.nudEndYear.TabIndex = 70
    Me.nudEndYear.Value = New Decimal(New Integer() {2007, 0, 0, 0})
    '
    'nudStartYear
    '
    Me.nudStartYear.Location = New System.Drawing.Point(447, 13)
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
    Me.Label5.Location = New System.Drawing.Point(376, 15)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(65, 13)
    Me.Label5.TabIndex = 68
    Me.Label5.Text = "Rok szkolny"
    '
    'LineShape1
    '
    Me.LineShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.LineShape1.BorderColor = System.Drawing.Color.White
    Me.LineShape1.Name = "LineShape1"
    Me.LineShape1.Visible = False
    Me.LineShape1.X1 = 10
    Me.LineShape1.X2 = 840
    Me.LineShape1.Y1 = 41
    Me.LineShape1.Y2 = 41
    '
    'ShapeContainer1
    '
    Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
    Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
    Me.ShapeContainer1.Name = "ShapeContainer1"
    Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
    Me.ShapeContainer1.Size = New System.Drawing.Size(850, 512)
    Me.ShapeContainer1.TabIndex = 75
    Me.ShapeContainer1.TabStop = False
    '
    'LineShape2
    '
    Me.LineShape2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.LineShape2.BorderColor = System.Drawing.Color.White
    Me.LineShape2.Name = "LineShape2"
    Me.LineShape2.X1 = 10
    Me.LineShape2.X2 = 840
    Me.LineShape2.Y1 = 473
    Me.LineShape2.Y2 = 473
    '
    'cmdClose
    '
    Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdClose.Location = New System.Drawing.Point(744, 422)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(75, 23)
    Me.cmdClose.TabIndex = 76
    Me.cmdClose.Text = "&Zamknij"
    Me.cmdClose.UseVisualStyleBackColor = True
    '
    'cmdDelete
    '
    Me.cmdDelete.Enabled = False
    Me.cmdDelete.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.cmdDelete.Location = New System.Drawing.Point(327, 239)
    Me.cmdDelete.Name = "cmdDelete"
    Me.cmdDelete.Size = New System.Drawing.Size(66, 28)
    Me.cmdDelete.TabIndex = 123
    Me.cmdDelete.Text = "<<"
    Me.cmdDelete.UseVisualStyleBackColor = True
    '
    'cmdAdd
    '
    Me.cmdAdd.Enabled = False
    Me.cmdAdd.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.cmdAdd.Location = New System.Drawing.Point(327, 205)
    Me.cmdAdd.Name = "cmdAdd"
    Me.cmdAdd.Size = New System.Drawing.Size(66, 28)
    Me.cmdAdd.TabIndex = 122
    Me.cmdAdd.Text = ">>"
    Me.cmdAdd.UseVisualStyleBackColor = True
    '
    'lvPromowani
    '
    Me.lvPromowani.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lvPromowani.ForeColor = System.Drawing.Color.Green
    Me.lvPromowani.HideSelection = False
    Me.lvPromowani.Location = New System.Drawing.Point(399, 70)
    Me.lvPromowani.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
    Me.lvPromowani.Name = "lvPromowani"
    Me.lvPromowani.Size = New System.Drawing.Size(309, 375)
    Me.lvPromowani.TabIndex = 120
    Me.lvPromowani.UseCompatibleStateImageBehavior = False
    '
    'Label14
    '
    Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label14.AutoSize = True
    Me.Label14.Enabled = False
    Me.Label14.Location = New System.Drawing.Point(535, 485)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(85, 13)
    Me.Label14.TabIndex = 135
    Me.Label14.Text = "Data modyfikacji"
    '
    'Label12
    '
    Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label12.AutoSize = True
    Me.Label12.Enabled = False
    Me.Label12.Location = New System.Drawing.Point(372, 485)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(31, 13)
    Me.Label12.TabIndex = 134
    Me.Label12.Text = "Nr IP"
    '
    'lblData
    '
    Me.lblData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblData.Enabled = False
    Me.lblData.Location = New System.Drawing.Point(626, 480)
    Me.lblData.Name = "lblData"
    Me.lblData.Size = New System.Drawing.Size(148, 23)
    Me.lblData.TabIndex = 133
    Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblIP
    '
    Me.lblIP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblIP.Enabled = False
    Me.lblIP.Location = New System.Drawing.Point(409, 480)
    Me.lblIP.Name = "lblIP"
    Me.lblIP.Size = New System.Drawing.Size(120, 23)
    Me.lblIP.TabIndex = 131
    Me.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblUser
    '
    Me.lblUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblUser.Enabled = False
    Me.lblUser.Location = New System.Drawing.Point(90, 480)
    Me.lblUser.Name = "lblUser"
    Me.lblUser.Size = New System.Drawing.Size(273, 23)
    Me.lblUser.TabIndex = 132
    Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label3
    '
    Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label3.AutoSize = True
    Me.Label3.Enabled = False
    Me.Label3.Location = New System.Drawing.Point(10, 485)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(74, 13)
    Me.Label3.TabIndex = 130
    Me.Label3.Text = "Zmodyfikował"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.Label1.Location = New System.Drawing.Point(10, 54)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(146, 13)
    Me.Label1.TabIndex = 137
    Me.Label1.Text = "Uczniowie niepromowani"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Green
    Me.Label2.Location = New System.Drawing.Point(396, 54)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(129, 13)
    Me.Label2.TabIndex = 138
    Me.Label2.Text = "Uczniowie promowani"
    '
    'cbKlasa
    '
    Me.cbKlasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbKlasa.Enabled = False
    Me.cbKlasa.FormattingEnabled = True
    Me.cbKlasa.Location = New System.Drawing.Point(304, 12)
    Me.cbKlasa.Name = "cbKlasa"
    Me.cbKlasa.Size = New System.Drawing.Size(63, 21)
    Me.cbKlasa.TabIndex = 140
    '
    'lvNiepromowani
    '
    Me.lvNiepromowani.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lvNiepromowani.BackColor = System.Drawing.SystemColors.Window
    Me.lvNiepromowani.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
    Me.lvNiepromowani.HideSelection = False
    Me.lvNiepromowani.Location = New System.Drawing.Point(12, 70)
    Me.lvNiepromowani.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
    Me.lvNiepromowani.Name = "lvNiepromowani"
    Me.lvNiepromowani.Size = New System.Drawing.Size(309, 375)
    Me.lvNiepromowani.TabIndex = 142
    Me.lvNiepromowani.UseCompatibleStateImageBehavior = False
    '
    'lblRecord
    '
    Me.lblRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblRecord.AutoSize = True
    Me.lblRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblRecord.ForeColor = System.Drawing.Color.Red
    Me.lblRecord.Location = New System.Drawing.Point(54, 3)
    Me.lblRecord.Name = "lblRecord"
    Me.lblRecord.Size = New System.Drawing.Size(61, 13)
    Me.lblRecord.TabIndex = 144
    Me.lblRecord.Text = "lblRecord"
    '
    'Label8
    '
    Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(3, 3)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(45, 13)
    Me.Label8.TabIndex = 143
    Me.Label8.Text = "Rekord:"
    '
    'lblRecord1
    '
    Me.lblRecord1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblRecord1.AutoSize = True
    Me.lblRecord1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblRecord1.ForeColor = System.Drawing.Color.Green
    Me.lblRecord1.Location = New System.Drawing.Point(445, 3)
    Me.lblRecord1.Name = "lblRecord1"
    Me.lblRecord1.Size = New System.Drawing.Size(68, 13)
    Me.lblRecord1.TabIndex = 146
    Me.lblRecord1.Text = "lblRecord1"
    '
    'Label10
    '
    Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(394, 3)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(45, 13)
    Me.Label10.TabIndex = 145
    Me.Label10.Text = "Rekord:"
    '
    'gpbZakres
    '
    Me.gpbZakres.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gpbZakres.Controls.Add(Me.rbWybranaKlasa)
    Me.gpbZakres.Controls.Add(Me.rbWszystkieKlasy)
    Me.gpbZakres.Enabled = False
    Me.gpbZakres.Location = New System.Drawing.Point(717, 70)
    Me.gpbZakres.Name = "gpbZakres"
    Me.gpbZakres.Size = New System.Drawing.Size(121, 71)
    Me.gpbZakres.TabIndex = 147
    Me.gpbZakres.TabStop = False
    Me.gpbZakres.Text = "Zakres wyświetania"
    '
    'rbWybranaKlasa
    '
    Me.rbWybranaKlasa.AutoSize = True
    Me.rbWybranaKlasa.Location = New System.Drawing.Point(6, 42)
    Me.rbWybranaKlasa.Name = "rbWybranaKlasa"
    Me.rbWybranaKlasa.Size = New System.Drawing.Size(96, 17)
    Me.rbWybranaKlasa.TabIndex = 1
    Me.rbWybranaKlasa.Text = "Wybrana klasa"
    Me.rbWybranaKlasa.UseVisualStyleBackColor = True
    '
    'rbWszystkieKlasy
    '
    Me.rbWszystkieKlasy.AutoSize = True
    Me.rbWszystkieKlasy.Checked = True
    Me.rbWszystkieKlasy.Location = New System.Drawing.Point(6, 19)
    Me.rbWszystkieKlasy.Name = "rbWszystkieKlasy"
    Me.rbWszystkieKlasy.Size = New System.Drawing.Size(100, 17)
    Me.rbWszystkieKlasy.TabIndex = 0
    Me.rbWszystkieKlasy.TabStop = True
    Me.rbWszystkieKlasy.Text = "Wszystkie klasy"
    Me.rbWszystkieKlasy.UseVisualStyleBackColor = True
    '
    'gpbOpcje
    '
    Me.gpbOpcje.Controls.Add(Me.rbUnselected)
    Me.gpbOpcje.Controls.Add(Me.rbSelected)
    Me.gpbOpcje.Enabled = False
    Me.gpbOpcje.Location = New System.Drawing.Point(717, 176)
    Me.gpbOpcje.Name = "gpbOpcje"
    Me.gpbOpcje.Size = New System.Drawing.Size(121, 101)
    Me.gpbOpcje.TabIndex = 148
    Me.gpbOpcje.TabStop = False
    Me.gpbOpcje.Text = "Opcje"
    '
    'rbUnselected
    '
    Me.rbUnselected.Location = New System.Drawing.Point(6, 57)
    Me.rbUnselected.Name = "rbUnselected"
    Me.rbUnselected.Size = New System.Drawing.Size(109, 34)
    Me.rbUnselected.TabIndex = 1
    Me.rbUnselected.Text = "Wykonaj dla niezaznaczonych"
    Me.rbUnselected.UseVisualStyleBackColor = True
    '
    'rbSelected
    '
    Me.rbSelected.Checked = True
    Me.rbSelected.Location = New System.Drawing.Point(6, 19)
    Me.rbSelected.Name = "rbSelected"
    Me.rbSelected.Size = New System.Drawing.Size(104, 32)
    Me.rbSelected.TabIndex = 0
    Me.rbSelected.TabStop = True
    Me.rbSelected.Text = "Wykonaj dla zaznaczonych"
    Me.rbSelected.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(265, 15)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(33, 13)
    Me.Label4.TabIndex = 149
    Me.Label4.Text = "Klasa"
    '
    'Panel1
    '
    Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Panel1.Controls.Add(Me.lblRecord1)
    Me.Panel1.Controls.Add(Me.Label10)
    Me.Panel1.Controls.Add(Me.Label8)
    Me.Panel1.Controls.Add(Me.lblRecord)
    Me.Panel1.Location = New System.Drawing.Point(12, 449)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(696, 21)
    Me.Panel1.TabIndex = 150
    '
    'frmPromocja
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(850, 512)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.cbKlasa)
    Me.Controls.Add(Me.gpbOpcje)
    Me.Controls.Add(Me.gpbZakres)
    Me.Controls.Add(Me.lvNiepromowani)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.lblData)
    Me.Controls.Add(Me.lblIP)
    Me.Controls.Add(Me.lblUser)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.cmdDelete)
    Me.Controls.Add(Me.cmdAdd)
    Me.Controls.Add(Me.lvPromowani)
    Me.Controls.Add(Me.cmdClose)
    Me.Controls.Add(Me.chkVirtual)
    Me.Controls.Add(Me.cbSzkola)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.nudEndYear)
    Me.Controls.Add(Me.nudStartYear)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.ShapeContainer1)
    Me.MaximumSize = New System.Drawing.Size(858, 1000)
    Me.MinimumSize = New System.Drawing.Size(858, 546)
    Me.Name = "frmPromocja"
    Me.Text = "Rejestr uczniów promowanych/niepromowanych"
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpbZakres.ResumeLayout(False)
    Me.gpbZakres.PerformLayout()
    Me.gpbOpcje.ResumeLayout(False)
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
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
  Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
  Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents cmdDelete As System.Windows.Forms.Button
  Friend WithEvents cmdAdd As System.Windows.Forms.Button
  Friend WithEvents lvPromowani As System.Windows.Forms.ListView
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents lblData As System.Windows.Forms.Label
  Friend WithEvents lblIP As System.Windows.Forms.Label
  Friend WithEvents lblUser As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents cbKlasa As System.Windows.Forms.ComboBox
  Friend WithEvents lvNiepromowani As System.Windows.Forms.ListView
  Friend WithEvents lblRecord As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents lblRecord1 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents gpbZakres As System.Windows.Forms.GroupBox
  Friend WithEvents rbWybranaKlasa As System.Windows.Forms.RadioButton
  Friend WithEvents rbWszystkieKlasy As System.Windows.Forms.RadioButton
  Friend WithEvents gpbOpcje As System.Windows.Forms.GroupBox
  Friend WithEvents rbUnselected As System.Windows.Forms.RadioButton
  Friend WithEvents rbSelected As System.Windows.Forms.RadioButton
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class

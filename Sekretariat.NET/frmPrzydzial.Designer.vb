<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrzydzial
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
    Me.chkVirtualNow = New System.Windows.Forms.CheckBox
    Me.cbSzkola = New System.Windows.Forms.ComboBox
    Me.Label7 = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.nudEndYear = New System.Windows.Forms.NumericUpDown
    Me.nudStartYear = New System.Windows.Forms.NumericUpDown
    Me.Label5 = New System.Windows.Forms.Label
    Me.lvKlasaNow = New System.Windows.Forms.ListView
    Me.cmdMove = New System.Windows.Forms.Button
    Me.lvKlasaNew = New System.Windows.Forms.ListView
    Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
    Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape
    Me.cbKlasaNow = New System.Windows.Forms.ComboBox
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.cbKlasaNew = New System.Windows.Forms.ComboBox
    Me.chkVirtualNew = New System.Windows.Forms.CheckBox
    Me.cmdClose = New System.Windows.Forms.Button
    Me.Label14 = New System.Windows.Forms.Label
    Me.Label12 = New System.Windows.Forms.Label
    Me.lblData = New System.Windows.Forms.Label
    Me.lblIP = New System.Windows.Forms.Label
    Me.lblUser = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.gpbZakres = New System.Windows.Forms.GroupBox
    Me.rbNoAssign = New System.Windows.Forms.RadioButton
    Me.rbWybranaKlasa = New System.Windows.Forms.RadioButton
    Me.rbWszystkieKlasy = New System.Windows.Forms.RadioButton
    Me.gpbStatus = New System.Windows.Forms.GroupBox
    Me.rbReverseAssign = New System.Windows.Forms.RadioButton
    Me.rbAssignNewYear = New System.Windows.Forms.RadioButton
    Me.rbChangeAssign = New System.Windows.Forms.RadioButton
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.lblRecord1 = New System.Windows.Forms.Label
    Me.Label10 = New System.Windows.Forms.Label
    Me.Label8 = New System.Windows.Forms.Label
    Me.lblRecord = New System.Windows.Forms.Label
    Me.cmdDelete = New System.Windows.Forms.Button
    Me.gpbOpcje = New System.Windows.Forms.GroupBox
    Me.rbUnselected = New System.Windows.Forms.RadioButton
    Me.rbSelected = New System.Windows.Forms.RadioButton
    Me.lblNewYear = New System.Windows.Forms.Label
    Me.lblCurrentYear = New System.Windows.Forms.Label
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.gpbZakres.SuspendLayout()
    Me.gpbStatus.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.gpbOpcje.SuspendLayout()
    Me.SuspendLayout()
    '
    'chkVirtualNow
    '
    Me.chkVirtualNow.AutoSize = True
    Me.chkVirtualNow.Enabled = False
    Me.chkVirtualNow.Location = New System.Drawing.Point(212, 50)
    Me.chkVirtualNow.Name = "chkVirtualNow"
    Me.chkVirtualNow.Size = New System.Drawing.Size(107, 17)
    Me.chkVirtualNow.TabIndex = 81
    Me.chkVirtualNow.Text = "Oddział wirtualny"
    Me.chkVirtualNow.UseVisualStyleBackColor = True
    '
    'cbSzkola
    '
    Me.cbSzkola.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbSzkola.FormattingEnabled = True
    Me.cbSzkola.Location = New System.Drawing.Point(59, 12)
    Me.cbSzkola.Name = "cbSzkola"
    Me.cbSzkola.Size = New System.Drawing.Size(200, 21)
    Me.cbSzkola.TabIndex = 80
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(12, 15)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(41, 13)
    Me.Label7.TabIndex = 79
    Me.Label7.Text = "Szkoła"
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.Label6.Location = New System.Drawing.Point(397, 10)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(15, 24)
    Me.Label6.TabIndex = 78
    Me.Label6.Text = "/"
    '
    'nudEndYear
    '
    Me.nudEndYear.Enabled = False
    Me.nudEndYear.Location = New System.Drawing.Point(413, 12)
    Me.nudEndYear.Maximum = New Decimal(New Integer() {2051, 0, 0, 0})
    Me.nudEndYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudEndYear.Name = "nudEndYear"
    Me.nudEndYear.Size = New System.Drawing.Size(55, 20)
    Me.nudEndYear.TabIndex = 77
    Me.nudEndYear.Value = New Decimal(New Integer() {2007, 0, 0, 0})
    '
    'nudStartYear
    '
    Me.nudStartYear.Enabled = False
    Me.nudStartYear.Location = New System.Drawing.Point(336, 12)
    Me.nudStartYear.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
    Me.nudStartYear.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
    Me.nudStartYear.Name = "nudStartYear"
    Me.nudStartYear.Size = New System.Drawing.Size(55, 20)
    Me.nudStartYear.TabIndex = 76
    Me.nudStartYear.Value = New Decimal(New Integer() {2006, 0, 0, 0})
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(265, 15)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(65, 13)
    Me.Label5.TabIndex = 75
    Me.Label5.Text = "Rok szkolny"
    '
    'lvKlasaNow
    '
    Me.lvKlasaNow.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lvKlasaNow.BackColor = System.Drawing.SystemColors.Window
    Me.lvKlasaNow.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lvKlasaNow.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
    Me.lvKlasaNow.HideSelection = False
    Me.lvKlasaNow.Location = New System.Drawing.Point(10, 72)
    Me.lvKlasaNow.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
    Me.lvKlasaNow.Name = "lvKlasaNow"
    Me.lvKlasaNow.Size = New System.Drawing.Size(309, 375)
    Me.lvKlasaNow.TabIndex = 146
    Me.lvKlasaNow.UseCompatibleStateImageBehavior = False
    '
    'cmdMove
    '
    Me.cmdMove.Enabled = False
    Me.cmdMove.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.cmdMove.Location = New System.Drawing.Point(325, 223)
    Me.cmdMove.Name = "cmdMove"
    Me.cmdMove.Size = New System.Drawing.Size(66, 28)
    Me.cmdMove.TabIndex = 144
    Me.cmdMove.Text = ">>"
    Me.cmdMove.UseVisualStyleBackColor = True
    '
    'lvKlasaNew
    '
    Me.lvKlasaNew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lvKlasaNew.ForeColor = System.Drawing.SystemColors.ControlText
    Me.lvKlasaNew.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
    Me.lvKlasaNew.HideSelection = False
    Me.lvKlasaNew.Location = New System.Drawing.Point(397, 72)
    Me.lvKlasaNew.Margin = New System.Windows.Forms.Padding(3, 3, 3, 1)
    Me.lvKlasaNew.Name = "lvKlasaNew"
    Me.lvKlasaNew.Size = New System.Drawing.Size(309, 375)
    Me.lvKlasaNew.TabIndex = 143
    Me.lvKlasaNew.UseCompatibleStateImageBehavior = False
    '
    'LineShape1
    '
    Me.LineShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.LineShape1.BorderColor = System.Drawing.Color.White
    Me.LineShape1.Name = "LineShape1"
    Me.LineShape1.Visible = False
    Me.LineShape1.X1 = 10
    Me.LineShape1.X2 = 970
    Me.LineShape1.Y1 = 38
    Me.LineShape1.Y2 = 38
    '
    'ShapeContainer1
    '
    Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
    Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
    Me.ShapeContainer1.Name = "ShapeContainer1"
    Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
    Me.ShapeContainer1.Size = New System.Drawing.Size(848, 512)
    Me.ShapeContainer1.TabIndex = 147
    Me.ShapeContainer1.TabStop = False
    '
    'LineShape2
    '
    Me.LineShape2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.LineShape2.BorderColor = System.Drawing.Color.White
    Me.LineShape2.Name = "LineShape2"
    Me.LineShape2.X1 = 7
    Me.LineShape2.X2 = 982
    Me.LineShape2.Y1 = 474
    Me.LineShape2.Y2 = 474
    '
    'cbKlasaNow
    '
    Me.cbKlasaNow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbKlasaNow.Enabled = False
    Me.cbKlasaNow.FormattingEnabled = True
    Me.cbKlasaNow.Location = New System.Drawing.Point(51, 48)
    Me.cbKlasaNow.Name = "cbKlasaNow"
    Me.cbKlasaNow.Size = New System.Drawing.Size(63, 21)
    Me.cbKlasaNow.TabIndex = 148
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 51)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(33, 13)
    Me.Label1.TabIndex = 149
    Me.Label1.Text = "Klasa"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(394, 51)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(33, 13)
    Me.Label2.TabIndex = 152
    Me.Label2.Text = "Klasa"
    '
    'cbKlasaNew
    '
    Me.cbKlasaNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cbKlasaNew.Enabled = False
    Me.cbKlasaNew.FormattingEnabled = True
    Me.cbKlasaNew.Location = New System.Drawing.Point(433, 48)
    Me.cbKlasaNew.Name = "cbKlasaNew"
    Me.cbKlasaNew.Size = New System.Drawing.Size(63, 21)
    Me.cbKlasaNew.TabIndex = 151
    '
    'chkVirtualNew
    '
    Me.chkVirtualNew.AutoSize = True
    Me.chkVirtualNew.Enabled = False
    Me.chkVirtualNew.Location = New System.Drawing.Point(599, 50)
    Me.chkVirtualNew.Name = "chkVirtualNew"
    Me.chkVirtualNew.Size = New System.Drawing.Size(107, 17)
    Me.chkVirtualNew.TabIndex = 150
    Me.chkVirtualNew.Text = "Oddział wirtualny"
    Me.chkVirtualNew.UseVisualStyleBackColor = True
    '
    'cmdClose
    '
    Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdClose.Location = New System.Drawing.Point(715, 443)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(121, 23)
    Me.cmdClose.TabIndex = 157
    Me.cmdClose.Text = "&Zamknij"
    Me.cmdClose.UseVisualStyleBackColor = True
    '
    'Label14
    '
    Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label14.AutoSize = True
    Me.Label14.Enabled = False
    Me.Label14.Location = New System.Drawing.Point(532, 485)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(85, 13)
    Me.Label14.TabIndex = 163
    Me.Label14.Text = "Data modyfikacji"
    '
    'Label12
    '
    Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label12.AutoSize = True
    Me.Label12.Enabled = False
    Me.Label12.Location = New System.Drawing.Point(369, 485)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(31, 13)
    Me.Label12.TabIndex = 162
    Me.Label12.Text = "Nr IP"
    '
    'lblData
    '
    Me.lblData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblData.Enabled = False
    Me.lblData.Location = New System.Drawing.Point(623, 480)
    Me.lblData.Name = "lblData"
    Me.lblData.Size = New System.Drawing.Size(148, 23)
    Me.lblData.TabIndex = 161
    Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblIP
    '
    Me.lblIP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblIP.Enabled = False
    Me.lblIP.Location = New System.Drawing.Point(406, 480)
    Me.lblIP.Name = "lblIP"
    Me.lblIP.Size = New System.Drawing.Size(120, 23)
    Me.lblIP.TabIndex = 159
    Me.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblUser
    '
    Me.lblUser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblUser.Enabled = False
    Me.lblUser.Location = New System.Drawing.Point(87, 480)
    Me.lblUser.Name = "lblUser"
    Me.lblUser.Size = New System.Drawing.Size(273, 23)
    Me.lblUser.TabIndex = 160
    Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label3
    '
    Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label3.AutoSize = True
    Me.Label3.Enabled = False
    Me.Label3.Location = New System.Drawing.Point(7, 485)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(74, 13)
    Me.Label3.TabIndex = 158
    Me.Label3.Text = "Zmodyfikował"
    '
    'gpbZakres
    '
    Me.gpbZakres.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.gpbZakres.Controls.Add(Me.rbNoAssign)
    Me.gpbZakres.Controls.Add(Me.rbWybranaKlasa)
    Me.gpbZakres.Controls.Add(Me.rbWszystkieKlasy)
    Me.gpbZakres.Enabled = False
    Me.gpbZakres.Location = New System.Drawing.Point(715, 72)
    Me.gpbZakres.Name = "gpbZakres"
    Me.gpbZakres.Size = New System.Drawing.Size(121, 106)
    Me.gpbZakres.TabIndex = 166
    Me.gpbZakres.TabStop = False
    Me.gpbZakres.Text = "Zakres wyświetania"
    '
    'rbNoAssign
    '
    Me.rbNoAssign.Location = New System.Drawing.Point(6, 65)
    Me.rbNoAssign.Name = "rbNoAssign"
    Me.rbNoAssign.Size = New System.Drawing.Size(104, 35)
    Me.rbNoAssign.TabIndex = 2
    Me.rbNoAssign.TabStop = True
    Me.rbNoAssign.Text = "Bez przydziału klasowego"
    Me.rbNoAssign.UseVisualStyleBackColor = True
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
    'gpbStatus
    '
    Me.gpbStatus.Controls.Add(Me.rbReverseAssign)
    Me.gpbStatus.Controls.Add(Me.rbAssignNewYear)
    Me.gpbStatus.Controls.Add(Me.rbChangeAssign)
    Me.gpbStatus.Enabled = False
    Me.gpbStatus.Location = New System.Drawing.Point(715, 184)
    Me.gpbStatus.Name = "gpbStatus"
    Me.gpbStatus.Size = New System.Drawing.Size(121, 117)
    Me.gpbStatus.TabIndex = 167
    Me.gpbStatus.TabStop = False
    Me.gpbStatus.Text = "Rodzaj operacji"
    '
    'rbReverseAssign
    '
    Me.rbReverseAssign.Location = New System.Drawing.Point(9, 80)
    Me.rbReverseAssign.Name = "rbReverseAssign"
    Me.rbReverseAssign.Size = New System.Drawing.Size(104, 31)
    Me.rbReverseAssign.TabIndex = 2
    Me.rbReverseAssign.Text = "Przydział wsteczny"
    Me.rbReverseAssign.UseVisualStyleBackColor = True
    '
    'rbAssignNewYear
    '
    Me.rbAssignNewYear.Checked = True
    Me.rbAssignNewYear.Location = New System.Drawing.Point(9, 42)
    Me.rbAssignNewYear.Name = "rbAssignNewYear"
    Me.rbAssignNewYear.Size = New System.Drawing.Size(106, 32)
    Me.rbAssignNewYear.TabIndex = 1
    Me.rbAssignNewYear.TabStop = True
    Me.rbAssignNewYear.Text = "Przydział na nowy rok szkolny"
    Me.rbAssignNewYear.UseVisualStyleBackColor = True
    '
    'rbChangeAssign
    '
    Me.rbChangeAssign.AutoSize = True
    Me.rbChangeAssign.Enabled = False
    Me.rbChangeAssign.Location = New System.Drawing.Point(9, 19)
    Me.rbChangeAssign.Name = "rbChangeAssign"
    Me.rbChangeAssign.Size = New System.Drawing.Size(111, 17)
    Me.rbChangeAssign.TabIndex = 0
    Me.rbChangeAssign.Text = "Zmiana przydziału"
    Me.rbChangeAssign.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Panel1.Controls.Add(Me.lblRecord1)
    Me.Panel1.Controls.Add(Me.Label10)
    Me.Panel1.Controls.Add(Me.Label8)
    Me.Panel1.Controls.Add(Me.lblRecord)
    Me.Panel1.Location = New System.Drawing.Point(10, 450)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(696, 21)
    Me.Panel1.TabIndex = 151
    '
    'lblRecord1
    '
    Me.lblRecord1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblRecord1.AutoSize = True
    Me.lblRecord1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblRecord1.ForeColor = System.Drawing.Color.Green
    Me.lblRecord1.Location = New System.Drawing.Point(441, 3)
    Me.lblRecord1.Name = "lblRecord1"
    Me.lblRecord1.Size = New System.Drawing.Size(68, 13)
    Me.lblRecord1.TabIndex = 146
    Me.lblRecord1.Text = "lblRecord1"
    '
    'Label10
    '
    Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(390, 3)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(45, 13)
    Me.Label10.TabIndex = 145
    Me.Label10.Text = "Rekord:"
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
    'cmdDelete
    '
    Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.cmdDelete.Enabled = False
    Me.cmdDelete.Location = New System.Drawing.Point(715, 414)
    Me.cmdDelete.Name = "cmdDelete"
    Me.cmdDelete.Size = New System.Drawing.Size(121, 23)
    Me.cmdDelete.TabIndex = 168
    Me.cmdDelete.Text = "&Usuń"
    Me.cmdDelete.UseVisualStyleBackColor = True
    '
    'gpbOpcje
    '
    Me.gpbOpcje.Controls.Add(Me.rbUnselected)
    Me.gpbOpcje.Controls.Add(Me.rbSelected)
    Me.gpbOpcje.Enabled = False
    Me.gpbOpcje.Location = New System.Drawing.Point(714, 307)
    Me.gpbOpcje.Name = "gpbOpcje"
    Me.gpbOpcje.Size = New System.Drawing.Size(121, 101)
    Me.gpbOpcje.TabIndex = 169
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
    'lblNewYear
    '
    Me.lblNewYear.AutoSize = True
    Me.lblNewYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblNewYear.ForeColor = System.Drawing.Color.DimGray
    Me.lblNewYear.Location = New System.Drawing.Point(502, 51)
    Me.lblNewYear.Name = "lblNewYear"
    Me.lblNewYear.Size = New System.Drawing.Size(61, 13)
    Me.lblNewYear.TabIndex = 170
    Me.lblNewYear.Text = "lblNewYear"
    '
    'lblCurrentYear
    '
    Me.lblCurrentYear.AutoSize = True
    Me.lblCurrentYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblCurrentYear.ForeColor = System.Drawing.Color.DimGray
    Me.lblCurrentYear.Location = New System.Drawing.Point(120, 51)
    Me.lblCurrentYear.Name = "lblCurrentYear"
    Me.lblCurrentYear.Size = New System.Drawing.Size(73, 13)
    Me.lblCurrentYear.TabIndex = 171
    Me.lblCurrentYear.Text = "lblCurrentYear"
    '
    'frmPrzydzial
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(848, 512)
    Me.Controls.Add(Me.lblCurrentYear)
    Me.Controls.Add(Me.lblNewYear)
    Me.Controls.Add(Me.gpbOpcje)
    Me.Controls.Add(Me.cmdDelete)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.gpbStatus)
    Me.Controls.Add(Me.gpbZakres)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.Label12)
    Me.Controls.Add(Me.lblData)
    Me.Controls.Add(Me.lblIP)
    Me.Controls.Add(Me.lblUser)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.cmdClose)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.cbKlasaNew)
    Me.Controls.Add(Me.chkVirtualNew)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.cbKlasaNow)
    Me.Controls.Add(Me.lvKlasaNow)
    Me.Controls.Add(Me.cmdMove)
    Me.Controls.Add(Me.lvKlasaNew)
    Me.Controls.Add(Me.chkVirtualNow)
    Me.Controls.Add(Me.cbSzkola)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.nudEndYear)
    Me.Controls.Add(Me.nudStartYear)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.ShapeContainer1)
    Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.MaximumSize = New System.Drawing.Size(856, 1000)
    Me.MinimumSize = New System.Drawing.Size(856, 546)
    Me.Name = "frmPrzydzial"
    Me.Text = "Przydział uczniów do oddziałów klasowych"
    CType(Me.nudEndYear, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.nudStartYear, System.ComponentModel.ISupportInitialize).EndInit()
    Me.gpbZakres.ResumeLayout(False)
    Me.gpbZakres.PerformLayout()
    Me.gpbStatus.ResumeLayout(False)
    Me.gpbStatus.PerformLayout()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.gpbOpcje.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents chkVirtualNow As System.Windows.Forms.CheckBox
  Friend WithEvents cbSzkola As System.Windows.Forms.ComboBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents nudEndYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents nudStartYear As System.Windows.Forms.NumericUpDown
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents lvKlasaNow As System.Windows.Forms.ListView
  Friend WithEvents cmdMove As System.Windows.Forms.Button
  Friend WithEvents lvKlasaNew As System.Windows.Forms.ListView
  Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
  Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
  Friend WithEvents cbKlasaNow As System.Windows.Forms.ComboBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents cbKlasaNew As System.Windows.Forms.ComboBox
  Friend WithEvents chkVirtualNew As System.Windows.Forms.CheckBox
  Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents lblData As System.Windows.Forms.Label
  Friend WithEvents lblIP As System.Windows.Forms.Label
  Friend WithEvents lblUser As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents gpbZakres As System.Windows.Forms.GroupBox
  Friend WithEvents rbWybranaKlasa As System.Windows.Forms.RadioButton
  Friend WithEvents rbWszystkieKlasy As System.Windows.Forms.RadioButton
  Friend WithEvents gpbStatus As System.Windows.Forms.GroupBox
  Friend WithEvents rbAssignNewYear As System.Windows.Forms.RadioButton
  Friend WithEvents rbChangeAssign As System.Windows.Forms.RadioButton
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents lblRecord1 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents lblRecord As System.Windows.Forms.Label
  Friend WithEvents cmdDelete As System.Windows.Forms.Button
  Friend WithEvents gpbOpcje As System.Windows.Forms.GroupBox
  Friend WithEvents rbUnselected As System.Windows.Forms.RadioButton
  Friend WithEvents rbSelected As System.Windows.Forms.RadioButton
  Friend WithEvents rbReverseAssign As System.Windows.Forms.RadioButton
  Friend WithEvents rbNoAssign As System.Windows.Forms.RadioButton
  Friend WithEvents lblNewYear As System.Windows.Forms.Label
  Friend WithEvents lblCurrentYear As System.Windows.Forms.Label
End Class

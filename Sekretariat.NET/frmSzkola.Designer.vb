<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSzkola
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
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.Label11 = New System.Windows.Forms.Label
    Me.lblRecord = New System.Windows.Forms.Label
    Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape
    Me.lvSzkoly = New ListviewWithTooltip.ListViewWithTooltip
    Me.cmdClose = New System.Windows.Forms.Button
    Me.cmdDelete = New System.Windows.Forms.Button
    Me.cmdEdit = New System.Windows.Forms.Button
    Me.cmdAddNew = New System.Windows.Forms.Button
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.tlpDetails = New System.Windows.Forms.TableLayoutPanel
    Me.Label21 = New System.Windows.Forms.Label
    Me.Label13 = New System.Windows.Forms.Label
    Me.lblAlias = New System.Windows.Forms.Label
    Me.lblOkeID = New System.Windows.Forms.Label
    Me.Label14 = New System.Windows.Forms.Label
    Me.lblFax = New System.Windows.Forms.Label
    Me.lblEmail = New System.Windows.Forms.Label
    Me.Label15 = New System.Windows.Forms.Label
    Me.lblOrgan = New System.Windows.Forms.Label
    Me.Label16 = New System.Windows.Forms.Label
    Me.lblTel = New System.Windows.Forms.Label
    Me.Label22 = New System.Windows.Forms.Label
    Me.Label30 = New System.Windows.Forms.Label
    Me.Label31 = New System.Windows.Forms.Label
    Me.lblData = New System.Windows.Forms.Label
    Me.lblIP = New System.Windows.Forms.Label
    Me.lblUser = New System.Windows.Forms.Label
    Me.Label32 = New System.Windows.Forms.Label
    Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape
    Me.Panel1.SuspendLayout()
    Me.Panel2.SuspendLayout()
    Me.tlpDetails.SuspendLayout()
    Me.SuspendLayout()
    '
    'Panel1
    '
    Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Panel1.Controls.Add(Me.Label11)
    Me.Panel1.Controls.Add(Me.lblRecord)
    Me.Panel1.Controls.Add(Me.ShapeContainer2)
    Me.Panel1.Location = New System.Drawing.Point(12, 208)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(636, 34)
    Me.Panel1.TabIndex = 15
    '
    'Label11
    '
    Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(3, 7)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(45, 13)
    Me.Label11.TabIndex = 145
    Me.Label11.Text = "Rekord:"
    '
    'lblRecord
    '
    Me.lblRecord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.lblRecord.AutoSize = True
    Me.lblRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblRecord.ForeColor = System.Drawing.Color.Red
    Me.lblRecord.Location = New System.Drawing.Point(54, 7)
    Me.lblRecord.Name = "lblRecord"
    Me.lblRecord.Size = New System.Drawing.Size(61, 13)
    Me.lblRecord.TabIndex = 146
    Me.lblRecord.Text = "lblRecord"
    '
    'ShapeContainer2
    '
    Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
    Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
    Me.ShapeContainer2.Name = "ShapeContainer2"
    Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2})
    Me.ShapeContainer2.Size = New System.Drawing.Size(636, 34)
    Me.ShapeContainer2.TabIndex = 147
    Me.ShapeContainer2.TabStop = False
    '
    'LineShape2
    '
    Me.LineShape2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.LineShape2.BorderColor = System.Drawing.SystemColors.ControlLightLight
    Me.LineShape2.Name = "LineShape2"
    Me.LineShape2.X1 = 2
    Me.LineShape2.X2 = 631
    Me.LineShape2.Y1 = 29
    Me.LineShape2.Y2 = 29
    '
    'lvSzkoly
    '
    Me.lvSzkoly.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lvSzkoly.Location = New System.Drawing.Point(12, 12)
    Me.lvSzkoly.Name = "lvSzkoly"
    Me.lvSzkoly.Size = New System.Drawing.Size(555, 190)
    Me.lvSzkoly.TabIndex = 16
    Me.lvSzkoly.UseCompatibleStateImageBehavior = False
    Me.lvSzkoly.View = System.Windows.Forms.View.Details
    '
    'cmdClose
    '
    Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdClose.Location = New System.Drawing.Point(573, 179)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(75, 23)
    Me.cmdClose.TabIndex = 20
    Me.cmdClose.Text = "&Zamknij"
    Me.cmdClose.UseVisualStyleBackColor = True
    '
    'cmdDelete
    '
    Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdDelete.Enabled = False
    Me.cmdDelete.Location = New System.Drawing.Point(573, 70)
    Me.cmdDelete.Name = "cmdDelete"
    Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
    Me.cmdDelete.TabIndex = 19
    Me.cmdDelete.Text = "&Usuń"
    Me.cmdDelete.UseVisualStyleBackColor = True
    '
    'cmdEdit
    '
    Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdEdit.Enabled = False
    Me.cmdEdit.Location = New System.Drawing.Point(573, 41)
    Me.cmdEdit.Name = "cmdEdit"
    Me.cmdEdit.Size = New System.Drawing.Size(75, 23)
    Me.cmdEdit.TabIndex = 18
    Me.cmdEdit.Text = "&Edytuj"
    Me.cmdEdit.UseVisualStyleBackColor = True
    '
    'cmdAddNew
    '
    Me.cmdAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdAddNew.Location = New System.Drawing.Point(573, 12)
    Me.cmdAddNew.Name = "cmdAddNew"
    Me.cmdAddNew.Size = New System.Drawing.Size(75, 23)
    Me.cmdAddNew.TabIndex = 17
    Me.cmdAddNew.Text = "&Dodaj"
    Me.cmdAddNew.UseVisualStyleBackColor = True
    '
    'Panel2
    '
    Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Panel2.BackColor = System.Drawing.SystemColors.Control
    Me.Panel2.Controls.Add(Me.tlpDetails)
    Me.Panel2.Controls.Add(Me.Label30)
    Me.Panel2.Controls.Add(Me.Label31)
    Me.Panel2.Controls.Add(Me.lblData)
    Me.Panel2.Controls.Add(Me.lblIP)
    Me.Panel2.Controls.Add(Me.lblUser)
    Me.Panel2.Controls.Add(Me.Label32)
    Me.Panel2.Controls.Add(Me.ShapeContainer1)
    Me.Panel2.Location = New System.Drawing.Point(12, 245)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(636, 122)
    Me.Panel2.TabIndex = 21
    '
    'tlpDetails
    '
    Me.tlpDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.tlpDetails.ColumnCount = 6
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.585055!))
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.80127!))
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.405406!))
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.64706!))
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.631161!))
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.56598!))
    Me.tlpDetails.Controls.Add(Me.Label21, 4, 1)
    Me.tlpDetails.Controls.Add(Me.Label13, 0, 0)
    Me.tlpDetails.Controls.Add(Me.lblAlias, 1, 0)
    Me.tlpDetails.Controls.Add(Me.lblOkeID, 1, 2)
    Me.tlpDetails.Controls.Add(Me.Label14, 0, 2)
    Me.tlpDetails.Controls.Add(Me.lblFax, 3, 1)
    Me.tlpDetails.Controls.Add(Me.lblEmail, 5, 1)
    Me.tlpDetails.Controls.Add(Me.Label15, 3, 0)
    Me.tlpDetails.Controls.Add(Me.lblOrgan, 4, 0)
    Me.tlpDetails.Controls.Add(Me.Label16, 0, 1)
    Me.tlpDetails.Controls.Add(Me.lblTel, 1, 1)
    Me.tlpDetails.Controls.Add(Me.Label22, 2, 1)
    Me.tlpDetails.Location = New System.Drawing.Point(3, 0)
    Me.tlpDetails.Name = "tlpDetails"
    Me.tlpDetails.RowCount = 3
    Me.tlpDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
    Me.tlpDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
    Me.tlpDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
    Me.tlpDetails.Size = New System.Drawing.Size(629, 79)
    Me.tlpDetails.TabIndex = 56
    '
    'Label21
    '
    Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label21.AutoSize = True
    Me.Label21.Location = New System.Drawing.Point(354, 32)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(41, 13)
    Me.Label21.TabIndex = 87
    Me.Label21.Text = "E-mail"
    '
    'Label13
    '
    Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(3, 6)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(47, 13)
    Me.Label13.TabIndex = 71
    Me.Label13.Text = "Alias"
    '
    'lblAlias
    '
    Me.lblAlias.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblAlias.AutoSize = True
    Me.tlpDetails.SetColumnSpan(Me.lblAlias, 2)
    Me.lblAlias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblAlias.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblAlias.Location = New System.Drawing.Point(56, 6)
    Me.lblAlias.Name = "lblAlias"
    Me.lblAlias.Size = New System.Drawing.Size(182, 13)
    Me.lblAlias.TabIndex = 50
    Me.lblAlias.Text = "Alias"
    '
    'lblOkeID
    '
    Me.lblOkeID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblOkeID.AutoSize = True
    Me.tlpDetails.SetColumnSpan(Me.lblOkeID, 3)
    Me.lblOkeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblOkeID.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblOkeID.Location = New System.Drawing.Point(56, 59)
    Me.lblOkeID.Name = "lblOkeID"
    Me.lblOkeID.Size = New System.Drawing.Size(292, 13)
    Me.lblOkeID.TabIndex = 58
    Me.lblOkeID.Text = "OkeID"
    '
    'Label14
    '
    Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(3, 59)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(47, 13)
    Me.Label14.TabIndex = 73
    Me.Label14.Text = "OKE ID"
    '
    'lblFax
    '
    Me.lblFax.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblFax.AutoSize = True
    Me.lblFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblFax.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblFax.Location = New System.Drawing.Point(244, 32)
    Me.lblFax.Name = "lblFax"
    Me.lblFax.Size = New System.Drawing.Size(104, 13)
    Me.lblFax.TabIndex = 55
    Me.lblFax.Text = "Fax"
    '
    'lblEmail
    '
    Me.lblEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblEmail.AutoSize = True
    Me.lblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblEmail.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblEmail.Location = New System.Drawing.Point(401, 32)
    Me.lblEmail.Name = "lblEmail"
    Me.lblEmail.Size = New System.Drawing.Size(225, 13)
    Me.lblEmail.TabIndex = 56
    Me.lblEmail.Text = "email"
    '
    'Label15
    '
    Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(244, 6)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(104, 13)
    Me.Label15.TabIndex = 81
    Me.Label15.Text = "Organ prowadzący"
    '
    'lblOrgan
    '
    Me.lblOrgan.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblOrgan.AutoSize = True
    Me.tlpDetails.SetColumnSpan(Me.lblOrgan, 2)
    Me.lblOrgan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblOrgan.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblOrgan.Location = New System.Drawing.Point(354, 6)
    Me.lblOrgan.Name = "lblOrgan"
    Me.lblOrgan.Size = New System.Drawing.Size(272, 13)
    Me.lblOrgan.TabIndex = 52
    Me.lblOrgan.Text = "Organ"
    '
    'Label16
    '
    Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(3, 32)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(47, 13)
    Me.Label16.TabIndex = 74
    Me.Label16.Text = "Telefon"
    '
    'lblTel
    '
    Me.lblTel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblTel.AutoSize = True
    Me.lblTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblTel.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblTel.Location = New System.Drawing.Point(56, 32)
    Me.lblTel.Name = "lblTel"
    Me.lblTel.Size = New System.Drawing.Size(149, 13)
    Me.lblTel.TabIndex = 61
    Me.lblTel.Text = "Tel. "
    '
    'Label22
    '
    Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label22.AutoSize = True
    Me.Label22.Location = New System.Drawing.Point(211, 32)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(27, 13)
    Me.Label22.TabIndex = 84
    Me.Label22.Text = "Fax"
    '
    'Label30
    '
    Me.Label30.AutoSize = True
    Me.Label30.Enabled = False
    Me.Label30.Location = New System.Drawing.Point(419, 94)
    Me.Label30.Name = "Label30"
    Me.Label30.Size = New System.Drawing.Size(85, 13)
    Me.Label30.TabIndex = 54
    Me.Label30.Text = "Data modyfikacji"
    '
    'Label31
    '
    Me.Label31.AutoSize = True
    Me.Label31.Enabled = False
    Me.Label31.Location = New System.Drawing.Point(256, 94)
    Me.Label31.Name = "Label31"
    Me.Label31.Size = New System.Drawing.Size(31, 13)
    Me.Label31.TabIndex = 53
    Me.Label31.Text = "Nr IP"
    '
    'lblData
    '
    Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblData.Enabled = False
    Me.lblData.Location = New System.Drawing.Point(510, 89)
    Me.lblData.Name = "lblData"
    Me.lblData.Size = New System.Drawing.Size(122, 23)
    Me.lblData.TabIndex = 52
    Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblIP
    '
    Me.lblIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblIP.Enabled = False
    Me.lblIP.Location = New System.Drawing.Point(293, 89)
    Me.lblIP.Name = "lblIP"
    Me.lblIP.Size = New System.Drawing.Size(120, 23)
    Me.lblIP.TabIndex = 50
    Me.lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'lblUser
    '
    Me.lblUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblUser.Enabled = False
    Me.lblUser.Location = New System.Drawing.Point(83, 89)
    Me.lblUser.Name = "lblUser"
    Me.lblUser.Size = New System.Drawing.Size(167, 23)
    Me.lblUser.TabIndex = 51
    Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label32
    '
    Me.Label32.AutoSize = True
    Me.Label32.Enabled = False
    Me.Label32.Location = New System.Drawing.Point(3, 94)
    Me.Label32.Name = "Label32"
    Me.Label32.Size = New System.Drawing.Size(74, 13)
    Me.Label32.TabIndex = 49
    Me.Label32.Text = "Zmodyfikował"
    '
    'ShapeContainer1
    '
    Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
    Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
    Me.ShapeContainer1.Name = "ShapeContainer1"
    Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
    Me.ShapeContainer1.Size = New System.Drawing.Size(636, 122)
    Me.ShapeContainer1.TabIndex = 55
    Me.ShapeContainer1.TabStop = False
    '
    'LineShape1
    '
    Me.LineShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.LineShape1.BorderColor = System.Drawing.SystemColors.Window
    Me.LineShape1.Name = "LineShape2"
    Me.LineShape1.X1 = -1
    Me.LineShape1.X2 = 635
    Me.LineShape1.Y1 = 86
    Me.LineShape1.Y2 = 86
    '
    'frmSzkola
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(660, 372)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.cmdClose)
    Me.Controls.Add(Me.cmdDelete)
    Me.Controls.Add(Me.cmdEdit)
    Me.Controls.Add(Me.cmdAddNew)
    Me.Controls.Add(Me.lvSzkoly)
    Me.Controls.Add(Me.Panel1)
    Me.Name = "frmSzkola"
    Me.Text = "Szkoły"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.tlpDetails.ResumeLayout(False)
    Me.tlpDetails.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents lblRecord As System.Windows.Forms.Label
  Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
  Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
  Friend WithEvents lvSzkoly As ListviewWithTooltip.ListViewWithTooltip
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents cmdDelete As System.Windows.Forms.Button
  Friend WithEvents cmdEdit As System.Windows.Forms.Button
  Friend WithEvents cmdAddNew As System.Windows.Forms.Button
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents tlpDetails As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents lblAlias As System.Windows.Forms.Label
  Friend WithEvents lblOkeID As System.Windows.Forms.Label
  Friend WithEvents lblTel As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents lblFax As System.Windows.Forms.Label
  Friend WithEvents lblOrgan As System.Windows.Forms.Label
  Friend WithEvents lblEmail As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents lblData As System.Windows.Forms.Label
  Friend WithEvents lblIP As System.Windows.Forms.Label
  Friend WithEvents lblUser As System.Windows.Forms.Label
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
  Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
End Class

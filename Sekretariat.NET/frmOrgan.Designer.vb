<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrgan
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
    Me.lvOrgan = New ListviewWithTooltip.ListViewWithTooltip
    Me.cmdClose = New System.Windows.Forms.Button
    Me.cmdDelete = New System.Windows.Forms.Button
    Me.cmdEdit = New System.Windows.Forms.Button
    Me.cmdAddNew = New System.Windows.Forms.Button
    Me.Panel1 = New System.Windows.Forms.Panel
    Me.Label11 = New System.Windows.Forms.Label
    Me.lblRecord = New System.Windows.Forms.Label
    Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape
    Me.Panel2 = New System.Windows.Forms.Panel
    Me.tlpDetails = New System.Windows.Forms.TableLayoutPanel
    Me.Label21 = New System.Windows.Forms.Label
    Me.Label13 = New System.Windows.Forms.Label
    Me.lblRodzaj = New System.Windows.Forms.Label
    Me.lblWoj = New System.Windows.Forms.Label
    Me.Label14 = New System.Windows.Forms.Label
    Me.lblNr = New System.Windows.Forms.Label
    Me.lblKodPocztowy = New System.Windows.Forms.Label
    Me.Label15 = New System.Windows.Forms.Label
    Me.lblMiejscowosc = New System.Windows.Forms.Label
    Me.Label16 = New System.Windows.Forms.Label
    Me.lblUlica = New System.Windows.Forms.Label
    Me.Label22 = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.lblKraj = New System.Windows.Forms.Label
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
    'lvOrgan
    '
    Me.lvOrgan.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lvOrgan.Location = New System.Drawing.Point(12, 12)
    Me.lvOrgan.Name = "lvOrgan"
    Me.lvOrgan.Size = New System.Drawing.Size(554, 283)
    Me.lvOrgan.TabIndex = 17
    Me.lvOrgan.UseCompatibleStateImageBehavior = False
    Me.lvOrgan.View = System.Windows.Forms.View.Details
    '
    'cmdClose
    '
    Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdClose.Location = New System.Drawing.Point(572, 272)
    Me.cmdClose.Name = "cmdClose"
    Me.cmdClose.Size = New System.Drawing.Size(75, 23)
    Me.cmdClose.TabIndex = 24
    Me.cmdClose.Text = "&Zamknij"
    Me.cmdClose.UseVisualStyleBackColor = True
    '
    'cmdDelete
    '
    Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdDelete.Location = New System.Drawing.Point(572, 70)
    Me.cmdDelete.Name = "cmdDelete"
    Me.cmdDelete.Size = New System.Drawing.Size(75, 23)
    Me.cmdDelete.TabIndex = 23
    Me.cmdDelete.Text = "&Usuń"
    Me.cmdDelete.UseVisualStyleBackColor = True
    '
    'cmdEdit
    '
    Me.cmdEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdEdit.Location = New System.Drawing.Point(572, 41)
    Me.cmdEdit.Name = "cmdEdit"
    Me.cmdEdit.Size = New System.Drawing.Size(75, 23)
    Me.cmdEdit.TabIndex = 22
    Me.cmdEdit.Text = "&Edytuj"
    Me.cmdEdit.UseVisualStyleBackColor = True
    '
    'cmdAddNew
    '
    Me.cmdAddNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmdAddNew.Location = New System.Drawing.Point(572, 12)
    Me.cmdAddNew.Name = "cmdAddNew"
    Me.cmdAddNew.Size = New System.Drawing.Size(75, 23)
    Me.cmdAddNew.TabIndex = 21
    Me.cmdAddNew.Text = "&Dodaj"
    Me.cmdAddNew.UseVisualStyleBackColor = True
    '
    'Panel1
    '
    Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Panel1.Controls.Add(Me.Label11)
    Me.Panel1.Controls.Add(Me.lblRecord)
    Me.Panel1.Controls.Add(Me.ShapeContainer2)
    Me.Panel1.Location = New System.Drawing.Point(12, 301)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(635, 34)
    Me.Panel1.TabIndex = 25
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
    Me.ShapeContainer2.Size = New System.Drawing.Size(635, 34)
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
    Me.LineShape2.X2 = 630
    Me.LineShape2.Y1 = 25
    Me.LineShape2.Y2 = 25
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
    Me.Panel2.Location = New System.Drawing.Point(12, 339)
    Me.Panel2.Name = "Panel2"
    Me.Panel2.Size = New System.Drawing.Size(635, 120)
    Me.Panel2.TabIndex = 26
    '
    'tlpDetails
    '
    Me.tlpDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.tlpDetails.ColumnCount = 6
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.63415!))
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.19164!))
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.878049!))
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.41463!))
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.15679!))
    Me.tlpDetails.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.55052!))
    Me.tlpDetails.Controls.Add(Me.Label21, 4, 1)
    Me.tlpDetails.Controls.Add(Me.Label13, 0, 0)
    Me.tlpDetails.Controls.Add(Me.lblRodzaj, 1, 0)
    Me.tlpDetails.Controls.Add(Me.lblWoj, 1, 2)
    Me.tlpDetails.Controls.Add(Me.Label14, 0, 2)
    Me.tlpDetails.Controls.Add(Me.lblNr, 3, 1)
    Me.tlpDetails.Controls.Add(Me.lblKodPocztowy, 5, 1)
    Me.tlpDetails.Controls.Add(Me.Label15, 3, 0)
    Me.tlpDetails.Controls.Add(Me.lblMiejscowosc, 4, 0)
    Me.tlpDetails.Controls.Add(Me.Label16, 0, 1)
    Me.tlpDetails.Controls.Add(Me.lblUlica, 1, 1)
    Me.tlpDetails.Controls.Add(Me.Label22, 2, 1)
    Me.tlpDetails.Controls.Add(Me.Label1, 3, 2)
    Me.tlpDetails.Controls.Add(Me.lblKraj, 4, 2)
    Me.tlpDetails.Location = New System.Drawing.Point(3, 0)
    Me.tlpDetails.Name = "tlpDetails"
    Me.tlpDetails.RowCount = 3
    Me.tlpDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
    Me.tlpDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
    Me.tlpDetails.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
    Me.tlpDetails.Size = New System.Drawing.Size(628, 79)
    Me.tlpDetails.TabIndex = 56
    '
    'Label21
    '
    Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label21.AutoSize = True
    Me.Label21.Location = New System.Drawing.Point(430, 32)
    Me.Label21.Name = "Label21"
    Me.Label21.Size = New System.Drawing.Size(89, 13)
    Me.Label21.TabIndex = 87
    Me.Label21.Text = "Kod pocztowy"
    Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label13
    '
    Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(3, 6)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(86, 13)
    Me.Label13.TabIndex = 71
    Me.Label13.Text = "Rodzaj"
    '
    'lblRodzaj
    '
    Me.lblRodzaj.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblRodzaj.AutoSize = True
    Me.tlpDetails.SetColumnSpan(Me.lblRodzaj, 2)
    Me.lblRodzaj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblRodzaj.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblRodzaj.Location = New System.Drawing.Point(95, 6)
    Me.lblRodzaj.Name = "lblRodzaj"
    Me.lblRodzaj.Size = New System.Drawing.Size(245, 13)
    Me.lblRodzaj.TabIndex = 50
    Me.lblRodzaj.Text = "Rodzaj"
    '
    'lblWoj
    '
    Me.lblWoj.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblWoj.AutoSize = True
    Me.tlpDetails.SetColumnSpan(Me.lblWoj, 2)
    Me.lblWoj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblWoj.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblWoj.Location = New System.Drawing.Point(95, 59)
    Me.lblWoj.Name = "lblWoj"
    Me.lblWoj.Size = New System.Drawing.Size(245, 13)
    Me.lblWoj.TabIndex = 58
    Me.lblWoj.Text = "Woj"
    '
    'Label14
    '
    Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(3, 59)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(86, 13)
    Me.Label14.TabIndex = 73
    Me.Label14.Text = "Województwo"
    '
    'lblNr
    '
    Me.lblNr.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblNr.AutoSize = True
    Me.lblNr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblNr.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblNr.Location = New System.Drawing.Point(346, 32)
    Me.lblNr.Name = "lblNr"
    Me.lblNr.Size = New System.Drawing.Size(78, 13)
    Me.lblNr.TabIndex = 55
    Me.lblNr.Text = "Nr"
    '
    'lblKodPocztowy
    '
    Me.lblKodPocztowy.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblKodPocztowy.AutoSize = True
    Me.lblKodPocztowy.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblKodPocztowy.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblKodPocztowy.Location = New System.Drawing.Point(525, 32)
    Me.lblKodPocztowy.Name = "lblKodPocztowy"
    Me.lblKodPocztowy.Size = New System.Drawing.Size(100, 13)
    Me.lblKodPocztowy.TabIndex = 56
    Me.lblKodPocztowy.Text = "KodPocztowy"
    '
    'Label15
    '
    Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label15.AutoSize = True
    Me.Label15.Location = New System.Drawing.Point(346, 6)
    Me.Label15.Name = "Label15"
    Me.Label15.Size = New System.Drawing.Size(78, 13)
    Me.Label15.TabIndex = 81
    Me.Label15.Text = "Miejscowość"
    Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'lblMiejscowosc
    '
    Me.lblMiejscowosc.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblMiejscowosc.AutoSize = True
    Me.tlpDetails.SetColumnSpan(Me.lblMiejscowosc, 2)
    Me.lblMiejscowosc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblMiejscowosc.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblMiejscowosc.Location = New System.Drawing.Point(430, 6)
    Me.lblMiejscowosc.Name = "lblMiejscowosc"
    Me.lblMiejscowosc.Size = New System.Drawing.Size(195, 13)
    Me.lblMiejscowosc.TabIndex = 52
    Me.lblMiejscowosc.Text = "Miejscowosc"
    '
    'Label16
    '
    Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label16.AutoSize = True
    Me.Label16.Location = New System.Drawing.Point(3, 32)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(86, 13)
    Me.Label16.TabIndex = 74
    Me.Label16.Text = "Ulica"
    '
    'lblUlica
    '
    Me.lblUlica.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblUlica.AutoSize = True
    Me.lblUlica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblUlica.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblUlica.Location = New System.Drawing.Point(95, 32)
    Me.lblUlica.Name = "lblUlica"
    Me.lblUlica.Size = New System.Drawing.Size(215, 13)
    Me.lblUlica.TabIndex = 61
    Me.lblUlica.Text = "Ulica"
    '
    'Label22
    '
    Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label22.AutoSize = True
    Me.Label22.Location = New System.Drawing.Point(316, 32)
    Me.Label22.Name = "Label22"
    Me.Label22.Size = New System.Drawing.Size(24, 13)
    Me.Label22.TabIndex = 84
    Me.Label22.Text = "Nr"
    Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'Label1
    '
    Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(346, 59)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(78, 13)
    Me.Label1.TabIndex = 88
    Me.Label1.Text = "Kraj"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'lblKraj
    '
    Me.lblKraj.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblKraj.AutoSize = True
    Me.tlpDetails.SetColumnSpan(Me.lblKraj, 2)
    Me.lblKraj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
    Me.lblKraj.ForeColor = System.Drawing.SystemColors.HotTrack
    Me.lblKraj.Location = New System.Drawing.Point(430, 59)
    Me.lblKraj.Name = "lblKraj"
    Me.lblKraj.Size = New System.Drawing.Size(195, 13)
    Me.lblKraj.TabIndex = 56
    Me.lblKraj.Text = "Kraj"
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
    Me.ShapeContainer1.Size = New System.Drawing.Size(635, 120)
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
    Me.LineShape1.X2 = 630
    Me.LineShape1.Y1 = 82
    Me.LineShape1.Y2 = 82
    '
    'frmOrgan
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(654, 465)
    Me.Controls.Add(Me.Panel2)
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.cmdClose)
    Me.Controls.Add(Me.cmdDelete)
    Me.Controls.Add(Me.cmdEdit)
    Me.Controls.Add(Me.cmdAddNew)
    Me.Controls.Add(Me.lvOrgan)
    Me.Name = "frmOrgan"
    Me.Text = "Organy prowadzące"
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.Panel2.ResumeLayout(False)
    Me.Panel2.PerformLayout()
    Me.tlpDetails.ResumeLayout(False)
    Me.tlpDetails.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents lvOrgan As ListviewWithTooltip.ListViewWithTooltip
  Friend WithEvents cmdClose As System.Windows.Forms.Button
  Friend WithEvents cmdDelete As System.Windows.Forms.Button
  Friend WithEvents cmdEdit As System.Windows.Forms.Button
  Friend WithEvents cmdAddNew As System.Windows.Forms.Button
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents lblRecord As System.Windows.Forms.Label
  Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
  Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
  Friend WithEvents Panel2 As System.Windows.Forms.Panel
  Friend WithEvents tlpDetails As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents Label21 As System.Windows.Forms.Label
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents lblRodzaj As System.Windows.Forms.Label
  Friend WithEvents lblWoj As System.Windows.Forms.Label
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents lblNr As System.Windows.Forms.Label
  Friend WithEvents lblKodPocztowy As System.Windows.Forms.Label
  Friend WithEvents Label15 As System.Windows.Forms.Label
  Friend WithEvents lblMiejscowosc As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents lblUlica As System.Windows.Forms.Label
  Friend WithEvents Label22 As System.Windows.Forms.Label
  Friend WithEvents Label30 As System.Windows.Forms.Label
  Friend WithEvents Label31 As System.Windows.Forms.Label
  Friend WithEvents lblData As System.Windows.Forms.Label
  Friend WithEvents lblIP As System.Windows.Forms.Label
  Friend WithEvents lblUser As System.Windows.Forms.Label
  Friend WithEvents Label32 As System.Windows.Forms.Label
  Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
  Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents lblKraj As System.Windows.Forms.Label
End Class

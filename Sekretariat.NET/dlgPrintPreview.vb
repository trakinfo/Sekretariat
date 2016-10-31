Imports System.Windows.Forms

Public Class dlgPrintPreview
  Public WithEvents Doc As New PrintReport(New DataSet)
  'Public Sub New(ByVal Doc As PrintReport)
  '  InitializeComponent()
  '  Doc = Doc
  'End Sub
  Public Event YearChanged(ByVal sender As Object)
  Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
    'Me.DialogResult = System.Windows.Forms.DialogResult.OK
    Dim prnDlg As New PrintDialog
    'prnDlg.UseEXDialog = True
    prnDlg.AllowSomePages = False
    prnDlg.PrinterSettings.FromPage = 1
    prnDlg.PrinterSettings.ToPage = 1
    If prnDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
      Me.Doc.PageNumber = 0
      Me.Doc.Offset(0) = 0
      Me.Doc.Offset(1) = 0
      pvWydruk.Document.DefaultPageSettings.PrinterSettings.Copies = prnDlg.PrinterSettings.Copies
      Me.pvWydruk.Document.DefaultPageSettings.PrinterSettings.FromPage = prnDlg.PrinterSettings.FromPage
      Me.pvWydruk.Document.DefaultPageSettings.PrinterSettings.ToPage = prnDlg.PrinterSettings.ToPage
      Me.pvWydruk.Document.DefaultPageSettings.PrinterSettings.PrinterName = prnDlg.PrinterSettings.PrinterName
      Me.pvWydruk.Document.Print()
    End If
    'Me.Dispose(True)
  End Sub

  Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
    Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
    Me.Dispose(True)
  End Sub

  Private Sub nudZoom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudZoom.ValueChanged
    If Not Me.Created Then Exit Sub
    tbZoom.Value = CType(nudZoom.Value, Integer)
    Me.pvWydruk.Rows = pvWydruk.Rows
    Me.pvWydruk.Zoom = nudZoom.Value * 0.01
    Me.Doc.PageNumber = 0
    Me.Doc.Offset(0) = 0
    Me.Doc.Offset(1) = 0
    Me.Doc.Lp = 0
    'Me.pvWydruk.InvalidatePreview()

  End Sub
  Private Sub tbZoom_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbZoom.Scroll
    'Zoom = tbZoom.Value * 0.01
    nudZoom.Value = tbZoom.Value
    Me.pvWydruk.Rows = pvWydruk.Rows
    Me.pvWydruk.Zoom = tbZoom.Value * 0.01
    Me.Doc.PageNumber = 0
    Me.Doc.Offset(0) = 0
    Me.Doc.Offset(1) = 0
    Me.Doc.Lp = 0
    'Me.pvWydruk.InvalidatePreview()
  End Sub

  Private Sub dlgPrintPreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    pvWydruk.Document = Doc
    pvWydruk.Zoom = nudZoom.Value * 0.01
    pvWydruk.InvalidatePreview()
    Me.Doc.Offset(0) = 0
    Me.Doc.Offset(1) = 0
    Me.Doc.Lp = 0
  End Sub
  Public Sub NewRow()
    pvWydruk.Rows += 1
  End Sub
  Sub chkRocznik_checkedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Me.pvWydruk.Rows = 1
    Me.Doc.Offset(0) = 0
    Me.Doc.Offset(1) = 0
    Me.Doc.Lp = 0
    Me.Doc.PageNumber = 0
    RaiseEvent YearChanged(sender)
    Doc.DefaultPageSettings.Landscape = CBool(IIf(240 + 40 * Doc.DS.Tables(3).Rows.Count * Doc.DS.Tables(2).Select("Status=True").GetLength(0) > (Doc.DefaultPageSettings.PaperSize.Width - (Doc.DefaultPageSettings.Margins.Left + Doc.DefaultPageSettings.Margins.Right)), True, False))
    pvWydruk.InvalidatePreview()
  End Sub

  Private Sub pvWydruk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pvWydruk.Click
    If (Control.ModifierKeys And Keys.Shift) = 0 Then
      If nudZoom.Maximum >= pvWydruk.Zoom * 100 * 2.0 Then
        pvWydruk.Zoom = pvWydruk.Zoom * 2.0
        nudZoom.Value = CType(pvWydruk.Zoom * 100, Decimal)

      End If
    Else
      If nudZoom.Minimum <= pvWydruk.Zoom * 100 / 2.0 Then
        pvWydruk.Zoom = pvWydruk.Zoom / 2.0
        nudZoom.Value = CType(pvWydruk.Zoom * 100, Decimal)

      End If
    End If

  End Sub
End Class

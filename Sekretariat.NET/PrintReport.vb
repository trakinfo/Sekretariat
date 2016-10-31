Public Class PrintReport
  Inherits System.Drawing.Printing.PrintDocument

  Private FDS As DataSet
  Private FPageNumber As Integer
  Private FOffset(1) As Integer
  Private FReportHeader() As String
  Private FReportFooter() As String
  Private FPageHeader() As String
  Private FPageFooter() As String
  Private FGroupHeader() As String
  Private FGroupFooter() As String
  Private FTableHeader() As String
  Private FPodpis As Byte()
  'Private FSchoolPlace As String
  Private FLp As Integer = 0


  Public Property DS() As DataSet
    Get
      Return FDS
    End Get
    Set(ByVal value As DataSet)
      FDS = value
    End Set
  End Property
  Public Property PageNumber() As Integer
    Get
      Return FPageNumber
    End Get
    Set(ByVal value As Integer)
      FPageNumber = value
    End Set
  End Property
  Public Property Podpis() As Byte()
    Get
      Return FPodpis
    End Get
    Set(ByVal value As Byte())
      FPodpis = value
    End Set
  End Property
  Public Property Offset(ByVal index As Integer) As Integer
    Get
      Return FOffset(index)
    End Get
    Set(ByVal value As Integer)
      FOffset(index) = value
    End Set
  End Property

  Public Property ReportHeader() As String()
    Get
      Return FReportHeader
    End Get
    Set(ByVal value As String())
      FReportHeader = value
    End Set
  End Property
  Public Property ReportFooter() As String()
    Get
      Return FReportFooter
    End Get
    Set(ByVal value As String())
      FReportFooter = value
    End Set
  End Property
  Public Property PageHeader() As String()
    Get
      Return FPageHeader
    End Get
    Set(ByVal value As String())
      FPageHeader = value
    End Set
  End Property
  Public Property PageFooter() As String()
    Get
      Return FPageFooter
    End Get
    Set(ByVal value As String())
      FPageFooter = value
    End Set
  End Property
  Public Property GroupHeader() As String()
    Get
      Return FGroupHeader
    End Get
    Set(ByVal value As String())
      FGroupHeader = value
    End Set
  End Property
  Public Property GroupFooter() As String()
    Get
      Return FGroupFooter
    End Get
    Set(ByVal value As String())
      FGroupFooter = value
    End Set
  End Property
  Public Property TableHeader() As String()
    Get
      Return FTableHeader
    End Get
    Set(ByVal value As String())
      FTableHeader = value
    End Set
  End Property
  Public Property Lp() As Integer
    Get
      Return FLp
    End Get
    Set(ByVal value As Integer)
      FLp = value
    End Set
  End Property
  Public Sub New(ByVal DS As DataSet)
    Dim PrnVar As New PrintVariables
    FDS = DS
    Me.OriginAtMargins = False
    Me.DefaultPageSettings.Margins.Top = PrnVar.TopMargin
    Me.DefaultPageSettings.Margins.Left = PrnVar.LeftMargin
    Me.DefaultPageSettings.Margins.Bottom = PrnVar.BottomMargin
    Me.DefaultPageSettings.Margins.Right = PrnVar.RightMargin
    Me.DefaultPageSettings.Landscape = PrnVar.Landscape
    Me.DefaultPageSettings.Color = PrnVar.Color
  End Sub
  Public Overloads Sub DrawText(ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal Text As String, ByVal Font As Font, ByVal x As Single, ByVal y As Single, ByVal Width As Single, ByVal Height As Single, ByVal Alignment As Byte, ByVal FontColor As Brush, Optional ByVal DrawLines As Boolean = True, Optional ByVal VerticalLayout As Boolean = False, Optional ByVal FillBackground As Boolean = False)
    Dim strFormat As New StringFormat
    If Alignment = 0 Then
      strFormat.Alignment = StringAlignment.Near
    ElseIf Alignment = 1 Then
      strFormat.Alignment = StringAlignment.Center
    Else
      strFormat.Alignment = StringAlignment.Far
    End If
    strFormat.LineAlignment = StringAlignment.Center
    If VerticalLayout Then strFormat.FormatFlags = StringFormatFlags.DirectionVertical
    If DrawLines Then e.Graphics.DrawRectangle(Pens.Black, x, y, Width, Height)
    If FillBackground Then e.Graphics.FillRectangle(Brushes.LightGray, New RectangleF(x, y, Width, Height))
    e.Graphics.DrawString(Text, Font, FontColor, New RectangleF(x, y, Width, Height), strFormat)
  End Sub
  Public Overloads Sub DrawText(ByVal G As Graphics, ByVal Text As String, ByVal Font As Font, ByVal x As Single, ByVal y As Single, ByVal Width As Single, ByVal Height As Single, ByVal Alignment As Byte, ByVal FontColor As Brush, ByVal Angle As Integer, Optional ByVal DrawLines As Boolean = True)
    Dim strFormat As New StringFormat
    If Alignment = 0 Then
      strFormat.Alignment = StringAlignment.Near
    ElseIf Alignment = 1 Then
      strFormat.Alignment = StringAlignment.Center
    Else
      strFormat.Alignment = StringAlignment.Far
    End If
    strFormat.LineAlignment = StringAlignment.Center
    G.RotateTransform(Angle)
    G.TranslateTransform(x, y, Drawing2D.MatrixOrder.Append)
    If DrawLines Then G.DrawRectangle(Pens.Black, 0, 0 - Width / 2, Height, Width)
    G.DrawString(Text, Font, FontColor, 0, 0, strFormat)
    'G.DrawString(Text, Font, FontColor, New RectangleF(0, 0, Width, Height), strFormat)
    G.ResetTransform()
  End Sub


End Class

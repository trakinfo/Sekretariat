Imports System.Drawing.Printing
Public Class frmLiczbaUczniowDrugorocznych
  Private NumberOfStudents As Integer, NumberOfStudentsByClass As Hashtable, ListaKlas() As String, Pion As Hashtable
  Private NumberOfStudentsByPion As Hashtable
  Public FormRoleSpady As Boolean
  Public Event NewRow()


  Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
    Me.Dispose(True)
  End Sub
  Private Sub frmLiczbaUczniowDrugorocznych_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    ListViewConfig()
    'Me.Filter = "Szkola"
    Dim CH As New CalcHelper
    Me.nudStartYear.Value = CH.StartDateOfSchoolYear.Year
    Dim FCB As New FillComboBox, SH As New SeekHelper
    FCB.AddComboBoxComplexItems(Me.cbSzkola, "Select ID,Alias FROM szkoly;")
    SH.FindComboItem(Me.cbSzkola, CInt(SH.GetDefault("Select ID From szkoly Where IsDefault='1';")))
  End Sub
  Private Sub GetPionKlas()
    Dim DBA As New DataBaseAction, R As MySqlDataReader = Nothing ', DT As DataTable
    Try
      R = DBA.GetReader("SELECT DISTINCT LEFT(p.Klasa,1) AS Pion FROM przydzial p INNER JOIN szkola_klasa sk ON p.Klasa=sk.IdKlasa WHERE p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "';")
      Dim PionKlas() As String = New String() {"Klasy zerowe", "Klasy pierwsze", "Klasy drugie", "Klasy trzecie", "Klasy czwarte", "Klasy piąte", "Klasy szóste", "Klasy siódme", "Klasy ósme"}
      'ReDim Pion(DT.Rows.Count - 1)
      'For i As Integer = 0 To DT.Rows.Count - 1
      '  Pion(i) = PionKlas(CType(DT.Rows(i).Item(0), Byte))
      'Next
      Pion = New Hashtable
      While R.Read
        Pion(R.Item(0).ToString) = PionKlas(CType(R.Item(0), Integer))
      End While
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      R.Close()
    End Try
  End Sub
  Private Sub GetKlasa()
    Dim DBA As New DataBaseAction, DT As DataTable
    Try
      DT = DBA.GetDataTable("SELECT DISTINCT p.Klasa FROM przydzial p INNER JOIN szkola_klasa sk ON p.Klasa=sk.IdKlasa WHERE p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' ORDER BY p.Klasa ASC;")
      ReDim ListaKlas(DT.Rows.Count - 1)
      For i As Integer = 0 To DT.Rows.Count - 1
        ListaKlas(i) = DT.Rows(i).Item(0).ToString
      Next
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try

  End Sub
  Private Sub ListViewConfig()
    With lvZestawienie
      .View = View.Details
      .Enabled = True
      .FullRowSelect = True
      .GridLines = True
      .MultiSelect = True
      .AllowColumnReorder = False
      .HideSelection = False
      AddColumns("Szkoła")
      .Items.Clear()
      .Enabled = False
    End With
  End Sub
  Private Sub AddColumns(ByVal F1 As String)
    With lvZestawienie
      .Columns.Clear()
      .Columns.Add(F1, 180, HorizontalAlignment.Center)
      .Columns.Add("Liczba", 80, HorizontalAlignment.Center)
      .Columns.Add("% w szkole", 80, HorizontalAlignment.Center)
      .Columns.Add("% w pionie", 80, HorizontalAlignment.Center)
      .Columns.Add("% w klasie", 80, HorizontalAlignment.Center)
    End With
  End Sub
  Private Sub nudStartYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudStartYear.ValueChanged
    If Not nudStartYear.Created Then Exit Sub
    Me.nudEndYear.Value = Me.nudStartYear.Value + 1
    If Not cbSzkola.SelectedItem Is Nothing Then
      GetPionKlas()
      GetKlasa()
      Me.NumberOfStudents = Me.CountStudents
      CountStudentsByPion()
      CountStudentsByKlasa()
      rbSzkola_CheckedChanged(sender, e)
    End If
  End Sub
  Private Sub cbSzkola_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSzkola.SelectedIndexChanged
    GetPionKlas()
    GetKlasa()
    Me.NumberOfStudents = Me.CountStudents
    CountStudentsByPion()
    CountStudentsByKlasa()
    rbSzkola_CheckedChanged(sender, e)
    cmdPrint.Enabled = True
  End Sub
  Private Sub chkVirtual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVirtual.CheckedChanged
    If Not cbSzkola.SelectedItem Is Nothing Then
      GetPionKlas()
      GetKlasa()
      Me.NumberOfStudents = Me.CountStudents
      CountStudentsByPion()
      CountStudentsByKlasa()
      rbSzkola_CheckedChanged(sender, e)
    End If
  End Sub
  Private Overloads Function CountStudents() As Integer
    Dim DBA As New DataBaseAction, R As MySqlDataReader = Nothing
    Try
      R = DBA.GetReader("SELECT COUNT(u.ID) AS LiczbaUczniow FROM uczniowie u,przydzial p,szkola_klasa sk WHERE u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji='1';")
      If R.HasRows Then
        R.Read()
        Return R.GetInt32(0)
      End If
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      R.Close()
    End Try
    Return 0
  End Function
  Private Overloads Sub CountStudentsByKlasa()
    Dim DBA As New DataBaseAction, R As MySqlDataReader = Nothing
    Try
      R = DBA.GetReader("SELECT p.Klasa,COUNT(u.ID) AS LiczbaUczniow FROM uczniowie u,przydzial p,szkola_klasa sk WHERE u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji='1' GROUP BY p.Klasa ASC;")
      NumberOfStudentsByClass = New Hashtable
      While R.Read
        NumberOfStudentsByClass(R.Item(0).ToString) = CType(R.Item(1), Integer)
      End While
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      R.Close()
    End Try
  End Sub
  Private Overloads Sub CountStudentsByPion()
    Dim DBA As New DataBaseAction, R As MySqlDataReader = Nothing
    Try
      R = DBA.GetReader("SELECT DISTINCT LEFT(p.Klasa,1),COUNT(u.ID) AS LiczbaUczniow FROM uczniowie u,przydzial p,szkola_klasa sk WHERE u.ID=p.IdUczen AND p.Klasa=sk.IdKlasa AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji='1' GROUP BY LEFT(p.Klasa,1) ASC;")
      NumberOfStudentsByPion = New Hashtable
      While R.Read
        NumberOfStudentsByPion(R.Item(0).ToString) = CType(R.Item(1), Integer)
      End While
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      R.Close()
    End Try
  End Sub
  Private Sub FillLV(ByVal Filter As String, ByVal SQLString As String)
    Dim DBA As New DataBaseAction, R As MySqlDataReader = Nothing
    Try
      lvZestawienie.Items.Clear()
      R = DBA.GetReader(SQLString)
      While R.Read
        If rbSzkola.Checked Then
          lvZestawienie.Items.Add(cbSzkola.Text)
        ElseIf rbPion.Checked Then
          lvZestawienie.Items.Add(Pion(R.Item(1)).ToString)
        Else
          lvZestawienie.Items.Add(R.Item(1).ToString)
        End If
        lvZestawienie.Items(lvZestawienie.Items.Count - 1).SubItems.Add(R.Item(0).ToString)
        lvZestawienie.Items(lvZestawienie.Items.Count - 1).SubItems.Add(Math.Round(CType(R.Item(0), Integer) / Me.NumberOfStudents * 100, 2).ToString)

        If Me.rbSzkola.Checked Then
          lvZestawienie.Items(lvZestawienie.Items.Count - 1).SubItems.Add("n.d.")
          lvZestawienie.Items(lvZestawienie.Items.Count - 1).SubItems.Add("n.d.")
        ElseIf Me.rbKlasa.Checked Then
          lvZestawienie.Items(lvZestawienie.Items.Count - 1).SubItems.Add(Math.Round(CType(R.Item(0), Integer) / CType(NumberOfStudentsByPion(R.Item(1).ToString.Substring(0, 1).ToString), Integer) * 100, 2).ToString)
          lvZestawienie.Items(lvZestawienie.Items.Count - 1).SubItems.Add(Math.Round(CType(R.Item(0), Integer) / CType(NumberOfStudentsByClass(R.Item(1).ToString), Integer) * 100, 2).ToString)
        ElseIf rbPion.Checked Then
          lvZestawienie.Items(lvZestawienie.Items.Count - 1).SubItems.Add(Math.Round(CType(R.Item(0), Integer) / CType(NumberOfStudentsByPion(R.Item(1).ToString), Integer) * 100, 2).ToString)
          lvZestawienie.Items(lvZestawienie.Items.Count - 1).SubItems.Add("n.d.")
        End If
      End While
      lvZestawienie.Columns(0).Width = CInt(IIf(lvZestawienie.Items.Count > 15, 162, 180))
      Me.lvZestawienie.Enabled = CBool(IIf(Me.lvZestawienie.Items.Count > 0, True, False))
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      R.Close()
    End Try
  End Sub
  Private Sub CountStudentsBy(ByVal Filter As String)
    Dim SQLString As String = ""
    Select Case Filter
      Case "Szkola"
        If FormRoleSpady Then
          SQLString = "SELECT COUNT(*) AS LiczbaUczniow FROM (SELECT distinct p.IdUczen FROM przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND LEFT(p.RokSzkolny,4)=" & Me.nudStartYear.Value.ToString & " AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji='1' AND p.IdUczen IN (SELECT DISTINCT IdUczen FROM przydzial WHERE LEFT(RokSzkolny,4)=" & CType(Me.nudStartYear.Value.ToString, Integer) - 1 & " AND Promocja='0' AND StatusAktywacji='1')) AS spady;"
        Else
          SQLString = "SELECT COUNT(p.ID) FROM przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND p.StatusAktywacji=0 AND MasterRecord=1;"
        End If
      Case "Pion"
        If FormRoleSpady Then
          SQLString = "SELECT COUNT(*) AS LiczbaUczniow,Pion  FROM (SELECT distinct LEFT(p.Klasa,1) AS Pion,p.IdUczen FROM przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND LEFT(p.RokSzkolny,4)=" & Me.nudStartYear.Value.ToString & " AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji='1' AND p.IdUczen IN (SELECT DISTINCT IdUczen FROM przydzial WHERE LEFT(RokSzkolny,4)=" & CType(Me.nudStartYear.Value.ToString, Integer) - 1 & " AND Promocja='0' AND StatusAktywacji='1')) AS spady GROUP BY Pion ASC;"
        Else
          SQLString = "SELECT COUNT(*),LEFT(p.Klasa,1) AS Pion FROM przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND p.StatusAktywacji=0 AND MasterRecord=1 GROUP BY Pion ASC;"
        End If
      Case "Klasa"
        If FormRoleSpady Then
          SQLString = "SELECT COUNT(*) AS LiczbaUczniow,p.Klasa FROM przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND p.IdUczen IN (SELECT distinct p.IdUczen FROM przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND LEFT(p.RokSzkolny,4)=" & Me.nudStartYear.Value.ToString & " AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.StatusAktywacji='1' AND p.IdUczen IN (SELECT DISTINCT IdUczen FROM przydzial WHERE LEFT(RokSzkolny,4)=" & CType(Me.nudStartYear.Value.ToString, Integer) - 1 & " AND Promocja='0' AND StatusAktywacji='1')) Group by p.Klasa;"
        Else
          SQLString = "SELECT COUNT(*),p.Klasa FROM przydzial p,szkola_klasa sk WHERE p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & CType(cbSzkola.SelectedItem, CbItem).ID.ToString & "' AND sk.Virtual='" & CType(chkVirtual.CheckState, Integer).ToString & "' AND p.RokSzkolny='" & Me.nudStartYear.Value.ToString & "/" & Me.nudEndYear.Value.ToString & "' AND p.StatusAktywacji=0 AND MasterRecord=1 GROUP BY p.Klasa;"
        End If
    End Select
    Me.FillLV(Filter, SQLString)
  End Sub
  Private Sub rbSzkola_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSzkola.CheckedChanged, rbKlasa.CheckedChanged, rbPion.CheckedChanged
    If Not Me.Created Then Exit Sub
    If rbSzkola.Checked Then
      AddColumns("Szkoła")
      Me.CountStudentsBy("Szkola")
    ElseIf rbPion.Checked Then
      AddColumns("Pion")
      Me.CountStudentsBy("Pion")
    Else
      AddColumns("Klasa")
      Me.CountStudentsBy("Klasa")
    End If
  End Sub
  Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
    Dim PP As New dlgPrintPreview, DS As New DataSet
    DS.Tables.Add(New DataTable)
    PP.Doc = New PrintReport(DS)
    AddHandler PP.Doc.PrintPage, AddressOf PrnDoc_PrintPage
    AddHandler NewRow, AddressOf PP.NewRow
    Dim Header, SubTitle As String
    SubTitle = "skreślonych z listy"
    If FormRoleSpady Then SubTitle = "drugorocznych"
    If rbSzkola.Checked Then
      Header = "Liczba uczniów " & SubTitle & " w szkole"
    ElseIf rbPion.Checked Then
      Header = "Liczba uczniów " & SubTitle & " w pionach klas"
    Else
      Header = "Liczba uczniów " & SubTitle & " w klasach"
    End If
    'Header += SubTitle
    PP.Doc.ReportHeader = New String() {Header}
    'PP.Doc.Offset(1) = 2
    If PP.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
      'DS.Tables.Remove(DT)
    End If
  End Sub
  Public Sub PrnDoc_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) 'Handles Doc.PrintPage
    Dim Doc As PrintReport = CType(sender, PrintReport)
    Dim x As Single = Doc.DefaultPageSettings.Margins.Left - Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Left
    Dim y As Single = Doc.DefaultPageSettings.Margins.Top - Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Top
    Dim PrnVars As New PrintVariables
    Dim TextFont As Font = PrnVars.BaseFont
    Dim HeaderFont As Font = PrnVars.HeaderFont
    Dim LineHeight As Single = TextFont.GetHeight(e.Graphics)
    Dim HeaderLineHeight As Single = HeaderFont.GetHeight(e.Graphics)

    Doc.PageNumber += 1
    Doc.DrawText(e, "- " & Doc.PageNumber & " -", TextFont, x, Doc.DefaultPageSettings.PrinterSettings.DefaultPageSettings.PrintableArea.Top + LineHeight, e.MarginBounds.Width, LineHeight, 1, Brushes.Black, False)
    If Doc.PageNumber = 1 Then
      y += LineHeight
      Doc.DrawText(e, Doc.ReportHeader(0), HeaderFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 1, Brushes.Black, False)
      y += LineHeight * 2
      Doc.DrawText(e, "Szkoła: " & cbSzkola.Text, TextFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 0, Brushes.Black, False)
      y += LineHeight
      Doc.DrawText(e, "Rok szkolny: " & String.Concat(nudStartYear.Value.ToString, "/", nudEndYear.Value.ToString), TextFont, x, y, e.MarginBounds.Width, HeaderLineHeight, 0, Brushes.Black, False)
      y += LineHeight * CSng(1.5)
      e.Graphics.DrawLine(Pens.Black, x, y, x + 300, y)
      y += LineHeight
    End If
    '------------------------------------------ Nagłówek tabeli -------------------------------------------
    Dim x1 As Single = x
    Doc.DrawText(e, lvZestawienie.Columns(0).Text, PrnVars.BoldFont, x1, y, lvZestawienie.Columns(0).Width, LineHeight * 2, 0, Brushes.Black, False)
    x1 += lvZestawienie.Columns(0).Width
    For i As Integer = 1 To lvZestawienie.Columns.Count - 2
      Doc.DrawText(e, lvZestawienie.Columns(i).Text, PrnVars.BoldFont, x1, y, lvZestawienie.Columns(i).Width, LineHeight * 2, 1, Brushes.Black, False)
      x1 += lvZestawienie.Columns(i).Width
    Next
    y += LineHeight * 2

    '------------------------------------------------- Ciało tabeli -----------------------------------------
    Dim grp As String = ""
    Do Until (y + LineHeight) > e.MarginBounds.Bottom Or Doc.Offset(0) > lvZestawienie.Items.Count - 1
      x1 = x
      '---------------------------------------------- Grupa -------------------------------------------
      'If lvZestawienie.Groups.Count > 0 AndAlso grp <> lvZestawienie.Items(Doc.Offset(0)).Group.Header Then
      '  y += LineHeight
      '  grp = lvZestawienie.Items(Doc.Offset(0)).Group.Header
      '  Doc.DrawText(e, lvZestawienie.Items(Doc.Offset(0)).Group.Header, PrnVars.BoldFont, x1, y, e.MarginBounds.Width, LineHeight, 0, Brushes.Black, False)
      '  y += LineHeight
      '  e.Graphics.DrawLine(Pens.Black, x, y, x + 160, y)

      '  y += LineHeight * CSng(0.3)

      'End If
      '------------------------------------------------- Dane ------------------------------------
      Doc.DrawText(e, lvZestawienie.Items(Doc.Offset(0)).Text, PrnVars.BaseFont, x1, y, lvZestawienie.Columns(0).Width, LineHeight, 0, Brushes.Black, False)
      x1 += lvZestawienie.Columns(0).Width
      For i As Integer = 1 To lvZestawienie.Columns.Count - 2
        Doc.DrawText(e, lvZestawienie.Items(Doc.Offset(0)).SubItems(i).Text, PrnVars.BaseFont, x1, y, lvZestawienie.Columns(i).Width, LineHeight, 1, Brushes.Black, False)
        x1 += lvZestawienie.Columns(i).Width
      Next
      Doc.Offset(0) += 1
      y += LineHeight
    Loop
    If Doc.Offset(0) <= lvZestawienie.Items.Count - 1 Then
      e.HasMorePages = True
      RaiseEvent NewRow()
    End If
  End Sub
End Class
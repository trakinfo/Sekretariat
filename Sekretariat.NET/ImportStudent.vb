Imports System.Text
Imports System.IO

Public Class ImportStudent
  'Private Errors As Integer
  Public Sub Import(ByVal FileName As String, ByVal RokSzkolny As String)
    'Dim Errors As Integer
    AddHandler SharedException.OnErrorGenerate, AddressOf WriteError
    If MessageBox.Show("Za chwilę nastąpi import danych uczniów. Istniejące dane zostaną usunięte!" & vbNewLine & "Czy chcesz kontynuować?", "Import danych uczniów", MessageBoxButtons.YesNo) = DialogResult.Yes Then
      Dim acsConn As OleDb.OleDbConnection = Nothing, MySQLTrans As MySqlTransaction
      MySQLTrans = GlobalValues.gblConn.BeginTransaction()
      Try
        SharedImport.pbValue = 0
        SharedImport.SuccessValue = 0
        SharedImport.ErrorValue = 0
        SharedImport.pbMaxValue = 8
        SharedImport.pbMaxValueChange()
        Dim DBA As New DataBaseAction, k As Integer = 0

        SharedImport.InfoValue = "Usuwanie danych: 'podział uczniów na oddziały', 'uczniowie'"
        SharedImport.RoutineChange()
        DBA.ApplyChanges(DeleteString("przydzial"), MySQLTrans)
        DBA.ApplyChanges(DeleteString("uczniowie"), MySQLTrans)
        k += 1
        SharedImport.pbValue = k
        SharedImport.RecordForward()

        SharedImport.InfoValue = "Usuwanie danych:'oddziały w szkole', 'obsada przedmiotów'"
        SharedImport.RoutineChange()
        DBA.ApplyChanges(DeleteString("szkola_klasa"), MySQLTrans)
        k += 1
        SharedImport.pbValue = k
        SharedImport.RecordForward()

        SharedImport.InfoValue = "Usuwanie danych: 'lista klas'"
        SharedImport.RoutineChange()
        DBA.ApplyChanges(DeleteString("klasy"), MySQLTrans)
        k += 1
        SharedImport.pbValue = k
        SharedImport.RecordForward()

        'SharedImport.InfoValue = "Usuwanie danych: 'województwa'"
        'SharedImport.RoutineChange()
        'DBA.ApplyChanges(DeleteString("wojewodztwa"))
        'k += 1
        'SharedImport.pbValue = k
        'SharedImport.RecordForward()

        'SharedImport.InfoValue = "Usuwanie danych: 'słownik miejscowości'"
        'SharedImport.RoutineChange()
        'DBA.ApplyChanges(DeleteString("miejscowosc"))
        'k += 1
        'SharedImport.pbValue = k
        'SharedImport.RecordForward()

        '*************************************************************************

        SharedImport.InfoValue = "Usuwanie danych: 'przydział nauczycieli do szkół'"
        SharedImport.RoutineChange()
        DBA.ApplyChanges(DeleteString("szkola_belfer"), MySQLTrans)
        k += 1
        SharedImport.pbValue = k
        SharedImport.RecordForward()

        '***********************************************************************
        SharedImport.InfoValue = "Usuwanie danych: 'szkoły'"
        SharedImport.RoutineChange()
        DBA.ApplyChanges(DeleteString("szkoly"), MySQLTrans)
        DBA.ApplyChanges(DeleteString("organ_prowadz"), MySQLTrans)
        k += 1
        SharedImport.pbValue = k
        SharedImport.RecordForward()

        SharedImport.InfoValue = "Usuwanie danych: 'nauczyciele'"
        SharedImport.RoutineChange()
        DBA.ApplyChanges(DeleteString("belfer"), MySQLTrans)
        k += 1
        SharedImport.pbValue = k
        SharedImport.RecordForward()

        SharedImport.InfoValue = "Usuwanie danych: 'przedmioty'"
        SharedImport.RoutineChange()
        DBA.ApplyChanges(DeleteString("przedmioty"), MySQLTrans)
        k += 1
        SharedImport.pbValue = k
        SharedImport.RecordForward()

        SharedImport.InfoValue = "Usuwanie danych: 'wartości dozwolone'"
        SharedImport.RoutineChange()
        DBA.ApplyChanges(DeleteString("wartosci_dozwolone"), MySQLTrans)
        k += 1
        SharedImport.pbValue = k
        SharedImport.RecordForward()

        SharedImport.pbValue = 0

        '----------------------------------- Zapis danych ---------------------------------------------

        Dim Oledb As New OledbAction
        acsConn = Oledb.Connection(FileName)
        Dim DT As DataTable

        Dim SzkolaParameters() As String = {"@Nazwa", "@Nip", "@OkeID", "@Ulica", "@Nr", "@IdMiejscowosc", "@Tel", "@Fax", "@Email"}
        SharedImport.InfoValue = "Zapis danych: 'dane szkoły'"
        SharedImport.RoutineChange()
        DT = Oledb.GetDataTable(SelectSzkoly, acsConn)
        SharedImport.pbMaxValue = DT.Rows.Count
        SharedImport.TotalValue = DT.Rows.Count.ToString
        SharedImport.SuccessValue = 0
        SharedImport.pbMaxValueChange()
        Dim IdSzkola As Long
        Dim dtMiejscowosc As DataTable, CH As New CalcHelper
        For i As Integer = 0 To DT.Rows.Count - 1
          Dim cmd As MySqlCommand = DBA.CreateCommand(InsertSzkoly)
          cmd.Transaction = MySQLTrans

          cmd.Parameters.AddWithValue("@Alias", IIf(DT.Rows(i).Item(0).ToString.Length > 45, DT.Rows(i).Item(0).ToString.Substring(0, 44), DT.Rows(i).Item(0).ToString))
          For j As Integer = 0 To 4 'DT.Columns.Count - 1
            cmd.Parameters.AddWithValue(SzkolaParameters(j), DT.Rows(i).Item(j))
          Next

          dtMiejscowosc = DBA.GetDataTable("SELECT m.ID,m.Nazwa,m.Poczta,m.KodPocztowy,m.IdWoj FROM miejscowosc m WHERE Nazwa='" & DT.Rows(i).Item("Miejscowosc").ToString & "';")
          If dtMiejscowosc.Rows.Count > 0 Then
            cmd.Parameters.AddWithValue(SzkolaParameters(5), dtMiejscowosc.Rows(0).Item(0))
          Else
            DBA.ApplyChanges("INSERT INTO miejscowosc VALUES(NULL,'" & DT.Rows(i).Item("Miejscowosc").ToString & "','" & DT.Rows(i).Item("Poczta").ToString & "','" & DT.Rows(i).Item("KodPocztowy").ToString & "',NULL,'1','0','" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);")
            cmd.Parameters.AddWithValue(SzkolaParameters(5), DBA.GetLastInsertedID)
          End If
          For j As Integer = 6 To 8 'DT.Columns.Count - 1
            cmd.Parameters.AddWithValue(SzkolaParameters(j), DT.Rows(i).Item(j))
          Next
          DBA.ApplyChanges(cmd)
          IdSzkola = cmd.LastInsertedId
          'cmd.ExecuteNonQuery()
          SharedImport.pbValue = i + 1
          SharedImport.SuccessValue += 1
          'SharedImport.ErrorValue = Errors.ToString
          SharedImport.RecordForward()
        Next

        SharedImport.InfoValue = "Zapis danych: 'słownik oddziałów szkolnych'"
        SharedImport.RoutineChange()
        'Dim dtKlasa As DataTable
        DT = Oledb.GetDataTable(SelectKlasa, acsConn)
        SharedImport.pbMaxValue = DT.Rows.Count
        SharedImport.TotalValue = DT.Rows.Count.ToString
        SharedImport.SuccessValue = 0
        SharedImport.pbMaxValueChange()
        For i As Integer = 0 To DT.Rows.Count - 1
          DBA.ApplyChanges(InsertKlasa(DT.Rows(i).Item(0).ToString), MySQLTrans)
          'j += 1
          SharedImport.pbValue = i + 1
          SharedImport.SuccessValue += 1
          'SharedImport.ErrorValue = Errors.ToString
          SharedImport.RecordForward()
        Next

        'Dim SzkolaKlasaParameters() As String = {"", ""}
        SharedImport.InfoValue = "Aktywacja oddziałów szkolnych w szkole"
        SharedImport.RoutineChange()
        'DT = Oledb.GetDataTable(SelectSzkoly, acsConn)
        SharedImport.pbMaxValue = DT.Rows.Count
        SharedImport.TotalValue = DT.Rows.Count.ToString
        SharedImport.SuccessValue = 0
        SharedImport.pbMaxValueChange()
        For i As Integer = 0 To DT.Rows.Count - 1
          Dim cmd As MySqlCommand = DBA.CreateCommand(InsertSzkolaKlasa)
          cmd.Transaction = MySQLTrans
          cmd.Parameters.AddWithValue("@IdKlasa", DT.Rows(i).Item(0))
          cmd.Parameters.AddWithValue("@IdSzkola", IdSzkola)

          DBA.ApplyChanges(cmd)
          'cmd.ExecuteNonQuery()
          SharedImport.pbValue = i + 1
          SharedImport.SuccessValue += 1
          'SharedImport.ErrorValue = Errors.ToString
          SharedImport.RecordForward()
        Next

        Dim StudentParameters() As String = {"?Nazwisko", "?Imie1", "?Imie2", "?NrArkusza", "?NrLegSzkol", "?NrwDzienniku", "?DataUr", "?IdMiejsceUr", "?IdMiejsceZam", "?Ulica", "?NrDomu", "?NrMieszkania", "?Tel1", "?Tel2", "?TelKom1", "?TelKom2", "?ImieOjca", "?ImieMatki", "?NazwiskoMatki", "?Pesel", "?Man", "?ObwodSzkolny"}
        SharedImport.InfoValue = "Zapis danych: 'uczniowie'"
        SharedImport.RoutineChange()
        DT = Oledb.GetDataTable(SelectStudents, acsConn)
        SharedImport.pbMaxValue = DT.Rows.Count
        SharedImport.TotalValue = DT.Rows.Count.ToString
        SharedImport.pbMaxValueChange()
        SharedImport.SuccessValue = 0

        For i As Integer = 0 To DT.Rows.Count - 1
          Dim cmd As MySqlCommand = DBA.CreateCommand(InsertStudent)
          cmd.Transaction = MySQLTrans
          For j As Integer = 0 To 6
            cmd.Parameters.AddWithValue(StudentParameters(j), DT.Rows(i).Item(j))
          Next

          dtMiejscowosc = DBA.GetDataTable("SELECT m.ID,m.Nazwa,m.Poczta,m.KodPocztowy,m.IdWoj FROM miejscowosc m WHERE Nazwa='" & DT.Rows(i).Item("MiejsceUr").ToString & "' AND IdWoj='" & DT.Rows(i).Item("WojUr").ToString & "';")
          If dtMiejscowosc.Rows.Count > 0 Then
            cmd.Parameters.AddWithValue(StudentParameters(7), dtMiejscowosc.Rows(0).Item(0))
          Else
            DBA.ApplyChanges("INSERT INTO miejscowosc VALUES(NULL,'" & DT.Rows(i).Item("MiejsceUr").ToString & "',NULL,NULL,'" & DT.Rows(i).Item("WojUr").ToString & "','1','0','" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);")
            cmd.Parameters.AddWithValue(StudentParameters(7), DBA.GetLastInsertedID)
          End If

          dtMiejscowosc = DBA.GetDataTable("SELECT m.ID,m.Nazwa,m.Poczta,m.KodPocztowy,m.IdWoj FROM miejscowosc m WHERE Nazwa='" & DT.Rows(i).Item("Miejscowosc").ToString & "' AND IdWoj='" & DT.Rows(i).Item("Woj").ToString & "';")
          If dtMiejscowosc.Rows.Count > 0 Then
            cmd.Parameters.AddWithValue(StudentParameters(8), dtMiejscowosc.Rows(0).Item(0))
          Else
            DBA.ApplyChanges("INSERT INTO miejscowosc VALUES(NULL,'" & DT.Rows(i).Item("Miejscowosc").ToString & "','" & DT.Rows(i).Item("Poczta").ToString & "','" & DT.Rows(i).Item("KodPocztowy").ToString & "','" & DT.Rows(i).Item("Woj").ToString & "','" & CType(DT.Rows(i).Item("Miasto"), Integer).ToString & "','0','" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);")
            cmd.Parameters.AddWithValue(StudentParameters(8), DBA.GetLastInsertedID)
          End If
          For j As Integer = 9 To 19
            cmd.Parameters.AddWithValue(StudentParameters(j), DT.Rows(i).Item(j))
          Next
          For j As Integer = 20 To 21
            cmd.Parameters.AddWithValue(StudentParameters(j), DT.Rows(i).Item(j))
          Next

          DBA.ApplyChanges(cmd)
          cmd.CommandText = InsertPrzydzial()
          cmd.Parameters.AddWithValue("@IdUczen", cmd.LastInsertedId)
          cmd.Parameters.AddWithValue("@Klasa", DT.Rows(i).Item("Klasa"))
          cmd.Parameters.AddWithValue("@RokSzkolny", RokSzkolny) 'CH.CurrentSchoolYear)
          DBA.ApplyChanges(cmd)

          'cmd.ExecuteNonQuery()
          SharedImport.pbValue = i + 1
          SharedImport.SuccessValue += 1
          'SharedImport.ErrorValue = Errors.ToString
          SharedImport.RecordForward()
        Next

        SharedImport.InfoValue = "Zapis danych: 'dozwolone wartości'"
        SharedImport.RoutineChange()
        DT = Oledb.GetDataTable(SelectWartosciDozwolone, acsConn)
        SharedImport.pbMaxValue = DT.Rows.Count
        SharedImport.TotalValue = DT.Rows.Count.ToString
        SharedImport.SuccessValue = 0
        SharedImport.pbMaxValueChange()
        For i As Integer = 0 To DT.Rows.Count - 1
          DBA.ApplyChanges(InsertWartosciDozwolone(DT.Rows(i).Item(0).ToString, DT.Rows(i).Item(1).ToString, DT.Rows(i).Item(2).ToString, IIf(CType(DT.Rows(i).Item(3), Boolean) = True, 1, 0).ToString), MySQLTrans)
          SharedImport.pbValue = i + 1
          SharedImport.SuccessValue += 1
          'SharedImport.SuccessValue = (i + 1).ToString
          'SharedImport.ErrorValue = Errors.ToString
          SharedImport.RecordForward()
        Next

        Dim BelferParameters() As String = {"@ID", "@Nazwisko", "@Imie", "@Man"}
        Dim SzkolaBelferParameters() As String = {"@IdSzkola", "@IdBelfer"}
        SharedImport.InfoValue = "Zapis danych: 'nauczyciele'; wiązanie nauczycieli ze szkołą"
        SharedImport.RoutineChange()
        DT = Oledb.GetDataTable(SelectBelfer, acsConn)
        SharedImport.pbMaxValue = DT.Rows.Count
        SharedImport.TotalValue = DT.Rows.Count.ToString
        SharedImport.SuccessValue = 0
        SharedImport.pbMaxValueChange()
        Dim IdBelfer As Long
        For i As Integer = 0 To DT.Rows.Count - 1
          Dim cmd As MySqlCommand = DBA.CreateCommand(InsertBelfer)
          cmd.Transaction = MySQLTrans
          For j As Integer = 0 To DT.Columns.Count - 1
            cmd.Parameters.AddWithValue(BelferParameters(j), DT.Rows(i).Item(j))
          Next
          DBA.ApplyChanges(cmd)
          IdBelfer = cmd.LastInsertedId
          'cmd.ExecuteNonQuery()
          cmd.CommandText = InsertSzkolaBelfer()
          cmd.Parameters.AddWithValue("IdSzkola", IdSzkola)
          cmd.Parameters.AddWithValue("IdBelfer", IdBelfer)
          DBA.ApplyChanges(cmd)
          SharedImport.pbValue = i + 1
          SharedImport.SuccessValue += 1
          'SharedImport.SuccessValue = (i + 1).ToString
          'SharedImport.ErrorValue = Errors.ToString
          SharedImport.RecordForward()
        Next

        SharedImport.InfoValue = "Zapis danych: 'przedmioty'"
        SharedImport.RoutineChange()
        DT = Oledb.GetDataTable(SelectPrzedmiot, acsConn)
        SharedImport.pbMaxValue = DT.Rows.Count
        SharedImport.TotalValue = DT.Rows.Count.ToString
        SharedImport.SuccessValue = 0
        SharedImport.pbMaxValueChange()
        For i As Integer = 0 To DT.Rows.Count - 1
          DBA.ApplyChanges(InsertPrzedmiot(DT.Rows(i).Item(0).ToString, DT.Rows(i).Item(1).ToString, IIf(DT.Rows(i).Item(1).ToString = "godz. wychowawcza", "z", "p").ToString, IIf(CType(DT.Rows(i).Item(2), Boolean) = True, 1, 0).ToString), MySQLTrans)
          SharedImport.pbValue = i + 1
          SharedImport.SuccessValue += 1
          'SharedImport.SuccessValue = (i + 1).ToString
          'SharedImport.ErrorValue = Errors.ToString
          SharedImport.RecordForward()
        Next

        Dim ObsadaParameters() As String = {"@Klasa", "@IdPrzedmiot", "@IdBelfer", "@RokSzkolny"}
        SharedImport.InfoValue = "Zapis danych: 'obsada przedmiotów'"
        SharedImport.RoutineChange()
        DT = Oledb.GetDataTable(SelectObsada, acsConn)
        SharedImport.pbMaxValue = DT.Rows.Count
        SharedImport.TotalValue = DT.Rows.Count.ToString
        SharedImport.SuccessValue = 0
        SharedImport.pbMaxValueChange()
        For i As Integer = 0 To DT.Rows.Count - 1
          Dim cmd As MySqlCommand = DBA.CreateCommand(InsertObsada)
          cmd.Transaction = MySQLTrans
          For j As Integer = 0 To 2
            cmd.Parameters.AddWithValue(ObsadaParameters(j), DT.Rows(i).Item(j))
          Next
          cmd.Parameters.AddWithValue(ObsadaParameters(3), RokSzkolny) 'CH.CurrentSchoolYear)
          'MessageBox.Show(cmd.Parameters.Item(0).Value.ToString & vbNewLine & cmd.Parameters.Item(1).Value.ToString & vbNewLine & cmd.Parameters.Item(2).Value.ToString & vbNewLine & cmd.Parameters.Item(3).Value.ToString)
          DBA.ApplyChanges(cmd)

          'For i As Integer = 0 To DT.Rows.Count - 1
          '  DBA.ApplyChanges(InsertObsada(DT.Rows(i).Item(0).ToString, DT.Rows(i).Item(1).ToString, DT.Rows(i).Item(2).ToString), MySQLTrans)
          SharedImport.pbValue = i + 1
          SharedImport.SuccessValue += 1
          'SharedImport.SuccessValue = (i + 1).ToString
          'SharedImport.ErrorValue = Errors.ToString
          SharedImport.RecordForward()
        Next



        If SharedImport.ErrorValue > 0 Then Throw New System.Exception("Wystąpiły błędy importu." & vbNewLine & "Wszystkie operacje zostaną wycofane" & vbNewLine & "Raport o błędach znajduje się w pliku 'Errors.txt', w katalogu roboczym programu.")

        MySQLTrans.Commit()
        MessageBox.Show("Import danych zakończony powodzeniem!", "Sekretariat.NET")
      Catch oledbex As OleDb.OleDbException
        MessageBox.Show(oledbex.Message)
      Catch mysqlex As MySqlException
        MySQLTrans.Rollback()
        MessageBox.Show(mysqlex.Message)
      Catch ex As Exception
        MessageBox.Show(ex.Message)
        MySQLTrans.Rollback()
      Finally
        acsConn.Close()
        SharedImport.pbValue = 0
        SharedImport.SuccessValue = 0
        SharedImport.ErrorValue = 0
        SharedImport.pbMaxValue = 0
        SharedImport.TotalValue = "0"
        SharedImport.InfoValue = ""
      End Try
    End If
  End Sub
  Private Sub WriteError()
    Dim FileName As String = Application.StartupPath & "\errors.txt"
    Dim Win As Encoding = Encoding.GetEncoding(1250)
    Dim SW As StreamWriter = New StreamWriter(FileName, True, Win)

    Try
      'For i = 0 To Dane.GetUpperBound(0)
      '  SW.Write(Dane(i) & ",")
      'Next
      Select Case SharedException.ErrorNumber
        Case 1452

        Case Else
          SharedImport.ErrorValue += 1
          SharedImport.SuccessValue -= 1
      End Select
      SW.Write(SharedImport.ErrorValue.ToString & ") Rodzaj błędu: " & SharedException.ErrorMessage & ", Data: " & Now)
      SW.WriteLine()
      'Errors += 1
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      SW.Close()
    End Try
  End Sub

  'Private Sub CheckError()
  '  Select Case SharedException.ErrorNumber
  '    Case 1452

  '  End Select
  'End Sub

  Private Function SelectStudents() As String
    Return "SELECT `u`.`Nazwisko`, `u`.`Imie1`, `u`.`Imie2`, `u`.`NrArkusza`,`u`.`NrLegSzkol`, `u`.`NrDziennika`, `u`.`DataUr`, `u`.`MiejsceUr`, `a`.`Miejscowosc`, `a`.`Ulica`, `a`.`NrDomu`, `a`.`NrMieszkania`, `a`.`Tel1`, `a`.`Tel2`, `a`.`TelKom1`, `a`.`TelKom2`, `r`.`ImieOjca`, `r`.`ImieMatki`, `r`.`NazwiskoMatki`, `u`.`Pesel`, `u`.`Man`, `u`.`ObwodSzkolny`, `u`.`WojUr`, `a`.`Woj`, `a`.`Poczta`, `a`.`KodPocztowy`, `a`.`Miasto`, `u`.`Klasa` FROM `Rodzice` AS `r` RIGHT JOIN ( `Adresy` AS `a` RIGHT JOIN `Uczniowie` AS `u` ON `a`.`ID` = `u`.`IdAdres` ) ON `r`.`ID` = `u`.`IdRodzice`;"
  End Function
  Private Function SelectBelfer() As String
    Return "SELECT ID,Nazwisko,Imie,Man FROM belfer;"
  End Function
  Private Function SelectWartosciDozwolone() As String
    Return "SELECT Nazwa,NazwaSkrotowa,Typ,Default FROM wartoscidozwolone;"
  End Function
  Private Function SelectPrzedmiot() As String
    Return "SELECT ID,Nazwa,Default FROM przedmioty;"
  End Function
  Private Function SelectWoj() As String
    Return "SELECT KodWoj,Nazwa,Default FROM wojewodztwa;"
  End Function
  Private Function SelectKlasa() As String
    Return "SELECT Klasa FROM klasy;"
  End Function
  Private Function SelectObsada() As String
    Return "SELECT Klasa,IdPrzedmiot,IdBelfer FROM obsada;"
  End Function
  Private Function SelectSzkoly() As String
    Return "SELECT Nazwa,Nip,OkeID,Ulica,Nr,Miejscowosc,Tel,Fax,Email,KodPocztowy,Poczta FROM szkoly;"
  End Function
  Private Function SelectMiejscowosc() As String
    Return "SELECT DISTINCT `Miejscowosc`, `KodWoj`, `poczta`, `KodPocztowy`, `Miasto` FROM `Adresy`, `Wojewodztwa` WHERE `Adresy`.`Woj` = `Wojewodztwa`.`KodWoj`;"
  End Function

  Private Function InsertStudent() As String
    Return "INSERT INTO uczniowie VALUES(null,?Nazwisko,?Imie1,?Imie2,?NrArkusza,?NrLegSzkol,?DataUr,?IdMiejsceUr,?IdMiejsceZam,?Ulica,?NrDomu,?NrMieszkania,?Tel1,?Tel2,?TelKom1,?TelKom2,?ImieOjca,?Nazwisko,?ImieMatki,?NazwiskoMatki,?Man,?Pesel,?ObwodSzkolny,'0','" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  Private Function InsertPrzydzial() As String
    Return "INSERT INTO przydzial VALUES(NULL,@IdUczen,@Klasa,@RokSzkolny,'0','1','" + Today.ToString("yyyy-MM-dd") + "',NULL,1,'" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  'Private Function InsertWoj(ByVal Kod As String, ByVal Nazwa As String, ByVal IsDefault As String) As String
  '  Return "INSERT INTO wojewodztwa VALUES('" & Kod & "','" & Nazwa & "','" & IsDefault & "','" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  'End Function
  Private Function InsertKlasa(ByVal Nazwa As String) As String
    Return "INSERT INTO klasy VALUES('" & Nazwa & "','" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  Private Function InsertWartosciDozwolone(ByVal Nazwa As String, ByVal NazwaSkrot As String, ByVal Typ As String, ByVal IsDefault As String) As String
    Return "INSERT INTO wartosci_dozwolone VALUES('" & Nazwa & "','" & NazwaSkrot & "','" & Typ & "','" & IsDefault & "','" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function

  Private Function InsertBelfer() As String
    Return "INSERT INTO belfer (ID,Nazwisko,Imie,Man,User,ComputerIP,Version) VALUES(@ID,@Nazwisko,@Imie,@Man" & ",'" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  Private Function InsertObsada() As String
    Return "INSERT INTO obsada VALUES(@Klasa,@IdPrzedmiot,@IdBelfer,@RokSzkolny,NULL,'" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  Private Function InsertPrzedmiot(ByVal ID As String, ByVal Nazwa As String, ByVal Typ As String, ByVal IsDefault As String) As String
    Return "INSERT INTO przedmioty VALUES('" & ID & "','" & Nazwa & "','" & Typ & "','" & IsDefault & "','" + GlobalValues.gblUserName + "','" + GlobalValues.gblIP + "',NULL);"
  End Function
  Private Function InsertSzkoly() As String
    Return "INSERT INTO szkoly VALUES(NULL,@Nazwa,@Alias,@Nip,@OkeID,@Ulica,@Nr,@IdMiejscowosc,@Tel,@Fax,@Email,'0',NULL,'" & GlobalValues.gblUserName & "','" & GlobalValues.gblIP & "',NULL);"
  End Function
  Private Function InsertSzkolaKlasa() As String
    Return "INSERT INTO szkola_klasa VALUES(@IdKlasa,@IdSzkola,'0','" & GlobalValues.gblUserName & "','" & GlobalValues.gblIP & "',NULL);"
  End Function
  Private Function InsertSzkolaBelfer() As String
    Return "INSERT INTO szkola_belfer VALUES(@IdSzkola,@IdBelfer,'" & GlobalValues.gblUserName & "','" & GlobalValues.gblIP & "',NULL);"
  End Function
  'Private Function DeleteString(ByVal Tabela As String) As String
  '  Return "DELETE FROM " & Tabela & ";"
  'End Function
  Private Function DeleteString(ByVal Tabela As String) As String
    Return "TRUNCATE " & Tabela & ";"
  End Function
End Class

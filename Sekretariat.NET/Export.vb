Imports System.Xml

Public Class ExportXML
  Public Klasa As String()
  Private Function FetchHermesData(ByVal Szkola As String, ByVal RokSzkolny As String) As DataSet
    Dim DBA As New DataBaseAction
    Return DBA.GetDataSet("Select Distinct Klasa From przydzial p,szkola_klasa sk Where p.Klasa=sk.IdKlasa AND sk.IdSzkola='" & Szkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND sk.Virtual='0' AND left(Klasa,1)='3' ORDER BY Klasa;SELECT s.`Nazwa`, s.`Nip`, s.`OkeID`, CONCAT_WS(' ',s.`Ulica`, s.`Nr`) AS UlicaNr, m.`Nazwa` AS Miejscowosc, m.`Poczta`, m.`KodPocztowy`, s.`Tel`, s.`Fax`, s.`Email` FROM szkoly s,miejscowosc m WHERE s.IdMiejscowosc=m.ID AND s.ID='" & Szkola & "';Select p.NrwDzienniku,u.Nazwisko,u.Imie1,u.DataUr,u.Pesel,u.Man,u.Imie2,m.Nazwa as MiejsceUr,p.Klasa from uczniowie u INNER JOIN przydzial p ON u.ID=p.IdUczen INNER JOIN szkola_klasa sk ON p.Klasa=sk.IdKlasa LEFT JOIN miejscowosc m ON u.IdMiejsceUr=m.ID Where LEFT(p.Klasa,1)='3' AND sk.IdSzkola='" & Szkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND p.StatusAktywacji='1' AND sk.Virtual='0' Order by p.NrwDzienniku,u.Nazwisko,u.Imie1,u.Imie2;")
  End Function
  Private Function FetchBlyskawicaData(ByVal Szkola As String, ByVal RokSzkolny As String, ByVal Klasy As String) As DataTable
    Dim DBA As New DataBaseAction
    Return DBA.GetDataTable("Select u.Nazwisko,u.Imie1,p.Klasa from uczniowie u INNER JOIN przydzial p ON u.ID=p.IdUczen INNER JOIN szkola_klasa sk ON p.Klasa=sk.IdKlasa Where sk.IdSzkola='" & Szkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND p.StatusAktywacji='1' AND sk.Virtual='0' AND p.Klasa IN (" & Klasy & ") Order by p.NrwDzienniku,u.Nazwisko,u.Imie1,u.Imie2;")
  End Function
  Private Function FetchBelferData(ByVal Szkola As String, ByVal RokSzkolny As String, ByVal Klasy As String) As DataTable
    Dim DBA As New DataBaseAction
    Return DBA.GetDataTable("Select u.Nazwisko,u.Imie1,u.Imie2,u.NrArkusza,u.ImieOjca,u.ImieMatki,u.DataUr,u.Man,u.Pesel,p.Klasa from uczniowie u INNER JOIN przydzial p ON u.ID=p.IdUczen INNER JOIN szkola_klasa sk ON p.Klasa=sk.IdKlasa Where sk.IdSzkola='" & Szkola & "' AND p.RokSzkolny='" & RokSzkolny & "' AND p.StatusAktywacji='1' AND sk.Virtual='0' AND p.Klasa IN (" & Klasy & ") Order by p.NrwDzienniku,u.Nazwisko,u.Imie1,u.Imie2;")
  End Function
  Public Sub ExportHermes(ByVal IdSzkola As String, ByVal RokSzkolny As String)
    Dim dlgSave As New SaveFileDialog
    Try
      With dlgSave
        .InitialDirectory = Application.StartupPath
        .AddExtension = True
        .CheckFileExists = False
        .DefaultExt = "xml"
        .Filter = "Pliki xml (*.xml)|*.xml"

        If .ShowDialog() = Windows.Forms.DialogResult.OK Then
          SharedExport.InfoValue = "Pobieranie danych ..."
          SharedExport.RoutineChange()
          Dim DS As DataSet
          DS = FetchHermesData(IdSzkola, RokSzkolny)
          SharedExport.TotalValue = DS.Tables(2).Rows.Count.ToString
          SharedExport.InfoValue = "Tworzenie dokumentu xml ..."
          SharedExport.RoutineChange()
          Dim XmlDoc As New Xml.XmlDocument()
          XmlDoc.LoadXml("<szkoly></szkoly>")
          SharedExport.InfoValue = "Zapis deklaracji xml ..."
          SharedExport.RoutineChange()
          Dim xmlDecl As XmlDeclaration
          xmlDecl = XmlDoc.CreateXmlDeclaration("1.0", System.Text.Encoding.GetEncoding("Windows-1250").ToString, "yes")
          'Add the new node to the document.
          Dim Root As XmlElement = XmlDoc.DocumentElement
          XmlDoc.InsertBefore(xmlDecl, Root)
          Dim xmlComment As XmlComment
          xmlComment = XmlDoc.CreateComment("Export danych z programu Sekretariat.NET do Hermesa")
          XmlDoc.InsertAfter(xmlComment, xmlDecl)
          Dim doctype As XmlDocumentType
          'MessageBox.Show(Application.UserAppDataPath)
          doctype = XmlDoc.CreateDocumentType("szkoly", Nothing, Application.UserAppDataPath & "\doctype.xml", Nothing)
          XmlDoc.InsertBefore(doctype, Root)

          Dim S As XmlElement = XmlDoc.CreateElement("S")
          SharedExport.pbValue = 0
          SharedExport.SuccessValue = 0
          SharedExport.ErrorValue = 0
          SharedExport.pbMaxValue = 4
          SharedExport.pbMaxValueChange()
          SharedExport.InfoValue = "Export danych szkoły..."
          SharedExport.RoutineChange()
          If DS.Tables(1).Rows.Count > 0 Then
            Root.AppendChild(S)
            Dim ID, N As XmlAttribute
            ID = XmlDoc.CreateAttribute("identyfikator")
            ID.Value = DS.Tables(1).Rows(0).Item("OkeID").ToString.Insert(6, "-")
            N = XmlDoc.CreateAttribute("nazwa")
            N.Value = DS.Tables(1).Rows(0).Item("Nazwa").ToString
            S.Attributes.Append(ID)
            S.Attributes.Append(N)
            Dim Nazwa() As String = {"Dane szkoły", "Adres", "Dane podstawowe", "Organ prowadzący"}
            Dim DNazwa(3)(), DText(3)() As String ', idx As Byte() = {2, 6, 1, 5}
            'For i As Byte = 0 To 3
            '  DNazwa(i) = New String(idx(i)) {}
            'Next
            DNazwa(0) = New String(2) {"Publiczna", "Szkoła", "Rodzaj szkoły I"}
            DNazwa(1) = New String(6) {"Ulica i nr", "Miejscowość", "Kod poczt.", "Poczta", "Telefon", "Faks", "e-mail"}
            DNazwa(2) = New String(1) {"Położenie", "Dyrektor"}
            DNazwa(3) = New String(5) {"Rodzaj", "Nazwa", "Ulica i nr", "Miejscowość", "Kod poczt.", "Poczta"}

            DText(0) = New String(2) {"publiczna", "dla młodzieży", "nie dotyczy"}
            DText(1) = New String(6) {DS.Tables(1).Rows(0).Item("UlicaNr").ToString, DS.Tables(1).Rows(0).Item("Miejscowosc").ToString, Format(CType(DS.Tables(1).Rows(0).Item("KodPocztowy"), Integer), "00-000"), DS.Tables(1).Rows(0).Item("Poczta").ToString, Format(CType(DS.Tables(1).Rows(0).Item("Tel"), Integer), "(0##) ###-####"), Format(CType(DS.Tables(1).Rows(0).Item("Fax"), Integer), "(0##) ###-####"), DS.Tables(1).Rows(0).Item("Email").ToString}
            DText(2) = New String(1) {"", "Janina Kaniecka"}
            DText(3) = New String(5) {"samorząd gminny", "Urząd Gminy i Miasta w Suszu", "Wybickiego", "Susz", "14-240", "Susz"}
            SharedExport.ExtendedInfoValue = "Export danych szkoły:"
            SharedExport.DetailedRoutineChange()
            For i As Byte = 0 To 3
              SharedExport.ExtendedInfoValue = Nazwa(i)
              SharedExport.DetailedRoutineChange()
              Dim G As XmlElement = XmlDoc.CreateElement("G")
              G.Attributes.Append(AddAttrib("nazwa", Nazwa(i), XmlDoc))
              For j = 0 To DNazwa(i).GetUpperBound(0)
                Dim D As XmlElement = XmlDoc.CreateElement("D")
                D.Attributes.Append(AddAttrib("nazwa", DNazwa(i)(j), XmlDoc))
                D.InnerText = DText(i)(j)
                G.AppendChild(D)
              Next
              S.AppendChild(G)
              SharedExport.pbValue += 1
              SharedExport.SuccessValue += 1
              SharedExport.RecordForward()
            Next
            If Not DS.Tables(0).Rows.Count > 0 Then
              MessageBox.Show("Export został przerwany, ponieważ w pionie klas trzecich nie ma uczniów." & vbNewLine & "Uzupełnij dane i spróbuj jeszcze raz.")
              Exit Sub
            End If
            SharedExport.pbValue = 0
            SharedExport.SuccessValue = 0
            SharedExport.ErrorValue = 0
            SharedExport.pbMaxValue = DS.Tables(2).Rows.Count
            SharedExport.pbMaxValueChange()
            SharedExport.InfoValue = "Export danych uczniów ..."
            SharedExport.RoutineChange()
            SharedExport.ExtendedInfoValue = vbNewLine & "Export danych uczniów ..." & vbNewLine
            SharedExport.DetailedRoutineChange()
            For i As Integer = 0 To DS.Tables(0).Rows.Count - 1
              SharedExport.ExtendedInfoValue = vbNewLine & "Export danych klasy " & DS.Tables(0).Rows(i).Item(0).ToString & vbNewLine
              SharedExport.DetailedRoutineChange()

              Dim O As XmlElement = XmlDoc.CreateElement("O")
              O.Attributes.Append(AddAttrib("symbol", DS.Tables(0).Rows(i).Item(0).ToString.Substring(1, 1).ToUpper, XmlDoc))
              O.Attributes.Append(AddAttrib("nazwa", DS.Tables(0).Rows(i).Item(0).ToString.Substring(1, 1).ToUpper, XmlDoc))
              Dim Uczen() As DataRow
              Uczen = DS.Tables(2).Select("Klasa='" & DS.Tables(0).Rows(i).Item(0).ToString & "'")

              For j As Integer = 0 To Uczen.GetUpperBound(0)
                SharedExport.ExtendedInfoValue = String.Concat(Uczen(j).Item("Nazwisko").ToString, " ", Uczen(j).Item("Imie1").ToString)
                SharedExport.DetailedRoutineChange()

                Dim U As XmlElement = XmlDoc.CreateElement("U")
                U.Attributes.Append(AddAttrib("numer", Uczen(j).Item("NrwDzienniku").ToString, XmlDoc))
                U.Attributes.Append(AddAttrib("nazwisko", Uczen(j).Item("Nazwisko").ToString, XmlDoc))
                U.Attributes.Append(AddAttrib("imie", Uczen(j).Item("Imie1").ToString, XmlDoc))
                U.Attributes.Append(AddAttrib("data.ur", CType(Uczen(j).Item("DataUr"), Date).ToString("dd-MM-yyyy"), XmlDoc))
                U.Attributes.Append(AddAttrib("PESEL", Uczen(j).Item("Pesel").ToString, XmlDoc))
                O.AppendChild(U)
                Dim UGNazwa() As String = {"Dane osobowe", "Część humanistyczna", "Część matematyczno-przyrodnicza", "Część językowa"}
                Dim UGDN(3)(), UGDT(3)() As String
                UGDN(0) = New String(4) {"Płeć", "Drugie imię", "Miejsce ur.", "Dysleksja", "Arkusz"}
                UGDN(1) = New String(1) {"Numer sali", "Mniejszość nar."}
                UGDN(2) = New String(1) {"Numer sali", "Mniejszość nar."}
                UGDN(3) = New String(1) {"Język zdawany", "Numer sali"}

                UGDT(0) = New String(4) {IIf(CType(Uczen(j).Item("Man"), Boolean) = True, "mężczyzna", "kobieta").ToString, Uczen(j).Item("Imie2").ToString, Uczen(j).Item("MiejsceUr").ToString, "nie", "standardowy"}
                UGDT(1) = New String(1) {"", "nie"}
                UGDT(2) = New String(1) {"", "nie"}
                UGDT(3) = New String(1) {"", ""}
                For k As Byte = 0 To 3
                  Dim G As XmlElement = XmlDoc.CreateElement("G")
                  G.Attributes.Append(AddAttrib("nazwa", UGNazwa(k), XmlDoc))
                  For idx = 0 To UGDN(k).GetUpperBound(0)
                    Dim D As XmlElement = XmlDoc.CreateElement("D")
                    D.Attributes.Append(AddAttrib("nazwa", UGDN(k)(idx), XmlDoc))
                    D.InnerText = UGDT(k)(idx)
                    G.AppendChild(D)
                  Next
                  U.AppendChild(G)
                Next
                SharedExport.SuccessValue += 1
                SharedExport.pbValue += 1
                SharedExport.RecordForward()
              Next
              S.AppendChild(O)
            Next
          Else
            MessageBox.Show("Export zakończył sie niepowodzeniem z powodu braku podstawowych danych szkoły." & vbNewLine & "Uzupełnij dane i spróbuj jeszcze raz.")
            Exit Sub
          End If

          Dim writer As XmlTextWriter = New XmlTextWriter(.FileName, System.Text.Encoding.GetEncoding("Windows-1250"))
          writer.Formatting = Formatting.Indented
          XmlDoc.Save(writer)
        End If
      End With
      MessageBox.Show("Export danych do Hermesa zakończony powodzeniem.")
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      SharedExport.ErrorValue = 0
      SharedExport.ExtendedInfoValue = ""
      SharedExport.InfoValue = ""
      SharedExport.pbMaxValue = 0
      SharedExport.pbValue = 0
      SharedExport.SuccessValue = 0
      SharedExport.TotalValue = ""
    End Try
  End Sub
  Private Function AddAttrib(ByVal Nazwa As String, ByVal Value As String, ByVal XmlDoc As XmlDocument) As XmlAttribute
    Dim Attr As XmlAttribute
    Attr = XmlDoc.CreateAttribute(Nazwa)
    Attr.Value = Value
    Return Attr
  End Function
  Public Sub ExportBlyskawica(ByVal IdSzkola As String, ByVal RokSzkolny As String)
    Dim dlgSave As New SaveFileDialog
    Try
      With dlgSave
        .InitialDirectory = Application.StartupPath
        .AddExtension = True
        .CheckFileExists = False
        .DefaultExt = "xml"
        .Filter = "Pliki xml (*.xml)|*.xml"

        If .ShowDialog() = Windows.Forms.DialogResult.OK Then
          SharedExport.InfoValue = "Pobieranie danych ..."
          SharedExport.RoutineChange()
          Dim DT As DataTable, Klasy As String = ""
          For i As Integer = 0 To Klasa.GetUpperBound(0)
            Klasy += String.Concat("'", Klasa(i), "',")
          Next

          DT = FetchBlyskawicaData(IdSzkola, RokSzkolny, Klasy.TrimEnd(",".ToCharArray))
          Dim ExportInfo As New dlgExportInfo
          ExportInfo.Show()

          SharedExport.TotalValue = DT.Rows.Count.ToString
          SharedExport.InfoValue = "Tworzenie dokumentu xml ..."
          SharedExport.RoutineChange()
          Dim XmlDoc As New Xml.XmlDocument()
          XmlDoc.LoadXml("<student></student>")
          SharedExport.InfoValue = "Zapis deklaracji xml ..."
          SharedExport.RoutineChange()
          Dim xmlDecl As XmlDeclaration
          xmlDecl = XmlDoc.CreateXmlDeclaration("1.0", System.Text.Encoding.GetEncoding("UTF-8").ToString, "yes")
          'Add the new node to the document.
          Dim Root As XmlElement = XmlDoc.DocumentElement
          XmlDoc.InsertBefore(xmlDecl, Root)
          Dim xmlComment As XmlComment
          xmlComment = XmlDoc.CreateComment("Export danych z programu Sekretariat.NET do programu Błyskawica.NET")
          XmlDoc.InsertAfter(xmlComment, xmlDecl)
          SharedExport.pbValue = 0
          SharedExport.SuccessValue = 0
          SharedExport.ErrorValue = 0
          SharedExport.pbMaxValue = DT.Rows.Count
          SharedExport.pbMaxValueChange()
          SharedExport.InfoValue = "Export uczniów wg oddziałów ..."
          SharedExport.RoutineChange()
          For j As Integer = 0 To Klasa.GetUpperBound(0)
            SharedExport.ExtendedInfoValue = "Klasa " & Klasa(j)
            SharedExport.DetailedRoutineChange()
            Dim G As XmlElement = XmlDoc.CreateElement("G")
            Root.AppendChild(G)
            G.Attributes.Append(AddAttrib("Klasa", Klasa(j), XmlDoc))
            For i As Integer = 0 To DT.Select("Klasa='" & Klasa(j) & "'").GetUpperBound(0)
              SharedExport.ExtendedInfoValue = String.Concat(DT.Select("Klasa='" & Klasa(j) & "'")(i).Item(0).ToString, " ", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item(1).ToString)
              SharedExport.DetailedRoutineChange()

              Dim U As XmlElement = XmlDoc.CreateElement("U")
              U.Attributes.Append(AddAttrib("Nazwisko", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item(0).ToString, XmlDoc))
              U.Attributes.Append(AddAttrib("Imię", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item(1).ToString, XmlDoc))

              G.AppendChild(U)
              SharedExport.pbValue += 1
              SharedExport.SuccessValue += 1
              SharedExport.RecordForward()

            Next
            SharedExport.ExtendedInfoValue = ""
            SharedExport.DetailedRoutineChange()

          Next
          'End While

          Dim writer As XmlTextWriter = New XmlTextWriter(.FileName, System.Text.Encoding.GetEncoding("UTF-8"))
          writer.Formatting = Formatting.Indented
          XmlDoc.Save(writer)
          ExportInfo.lblInfo.Text = "Export danych do programu Błyskawica zakończony powodzeniem."

          'MessageBox.Show("Export danych do programu Błyskawica zakończony powodzeniem.")
        End If
      End With
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      SharedExport.ErrorValue = 0
      SharedExport.ExtendedInfoValue = ""
      SharedExport.InfoValue = ""
      SharedExport.pbMaxValue = 0
      SharedExport.pbValue = 0
      SharedExport.SuccessValue = 0
      SharedExport.TotalValue = ""
    End Try
  End Sub
  Public Sub ExportBelfer(ByVal IdSzkola As String, ByVal RokSzkolny As String)
    Dim dlgSave As New SaveFileDialog
    Try
      With dlgSave
        .InitialDirectory = Application.StartupPath
        .AddExtension = True
        .CheckFileExists = False
        .DefaultExt = "xml"
        .Filter = "Pliki xml (*.xml)|*.xml"

        If .ShowDialog() = Windows.Forms.DialogResult.OK Then
          SharedExport.InfoValue = "Pobieranie danych ..."
          SharedExport.RoutineChange()
          Dim DT As DataTable, Klasy As String = ""
          For i As Integer = 0 To Klasa.GetUpperBound(0)
            Klasy += String.Concat("'", Klasa(i), "',")
          Next

          DT = FetchBelferData(IdSzkola, RokSzkolny, Klasy.TrimEnd(",".ToCharArray))
          Dim ExportInfo As New dlgExportInfo
          ExportInfo.Show()
          SharedExport.TotalValue = DT.Rows.Count.ToString
          SharedExport.InfoValue = "Tworzenie dokumentu xml ..."
          SharedExport.RoutineChange()
          Dim XmlDoc As New Xml.XmlDocument()
          XmlDoc.LoadXml("<student></student>")
          SharedExport.InfoValue = "Zapis deklaracji xml ..."
          SharedExport.RoutineChange()
          Dim xmlDecl As XmlDeclaration
          xmlDecl = XmlDoc.CreateXmlDeclaration("1.0", System.Text.Encoding.GetEncoding("UTF-8").ToString, "yes")
          'Add the new node to the document.
          Dim Root As XmlElement = XmlDoc.DocumentElement
          XmlDoc.InsertBefore(xmlDecl, Root)
          Dim xmlComment As XmlComment
          xmlComment = XmlDoc.CreateComment("Export danych z programu Sekretariat.NET do programu Belfer.NET")
          XmlDoc.InsertAfter(xmlComment, xmlDecl)
          SharedExport.pbValue = 0
          SharedExport.SuccessValue = 0
          SharedExport.ErrorValue = 0
          SharedExport.pbMaxValue = DT.Rows.Count
          SharedExport.pbMaxValueChange()
          SharedExport.InfoValue = "Export uczniów wg oddziałów ..."
          SharedExport.RoutineChange()
          For j As Integer = 0 To Klasa.GetUpperBound(0)
            SharedExport.ExtendedInfoValue = "Klasa " & Klasa(j)
            SharedExport.DetailedRoutineChange()
            Dim G As XmlElement = XmlDoc.CreateElement("G")
            Root.AppendChild(G)
            G.Attributes.Append(AddAttrib("Klasa", Klasa(j), XmlDoc))
            For i As Integer = 0 To DT.Select("Klasa='" & Klasa(j) & "'").GetUpperBound(0)
              SharedExport.ExtendedInfoValue = String.Concat(DT.Select("Klasa='" & Klasa(j) & "'")(i).Item(0).ToString, " ", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item(1).ToString)
              SharedExport.DetailedRoutineChange()

              Dim U As XmlElement = XmlDoc.CreateElement("U")
              U.Attributes.Append(AddAttrib("Nazwisko", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item(0).ToString, XmlDoc))
              U.Attributes.Append(AddAttrib("Imie", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item(1).ToString, XmlDoc))
              U.Attributes.Append(AddAttrib("DrugieImie", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item("Imie2").ToString, XmlDoc))
              U.Attributes.Append(AddAttrib("NrArkuszaOcen", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item("NrArkusza").ToString, XmlDoc))
              U.Attributes.Append(AddAttrib("ImieOjca", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item("ImieOjca").ToString, XmlDoc))
              U.Attributes.Append(AddAttrib("ImieMatki", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item("ImieMatki").ToString, XmlDoc))
              U.Attributes.Append(AddAttrib("DataUrodzenia", CType(DT.Select("Klasa='" & Klasa(j) & "'")(i).Item("DataUr"), Date).ToShortDateString, XmlDoc))
              U.Attributes.Append(AddAttrib("Mężczyna", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item("Man").ToString, XmlDoc))
              U.Attributes.Append(AddAttrib("Pesel", DT.Select("Klasa='" & Klasa(j) & "'")(i).Item("Pesel").ToString, XmlDoc))

              G.AppendChild(U)
              SharedExport.pbValue += 1
              SharedExport.SuccessValue += 1
              SharedExport.RecordForward()

            Next
            SharedExport.ExtendedInfoValue = ""
            SharedExport.DetailedRoutineChange()

          Next
          'End While

          Dim writer As XmlTextWriter = New XmlTextWriter(.FileName, System.Text.Encoding.GetEncoding("UTF-8"))
          writer.Formatting = Formatting.Indented
          XmlDoc.Save(writer)
          ExportInfo.lblInfo.Text = "Export danych do programu Belfer zakończony powodzeniem."
          'MessageBox.Show("Export danych do programu Belfer zakończony powodzeniem.")
        End If
      End With

    Catch ex As Exception
      MessageBox.Show(ex.Message)
    Finally
      SharedExport.ErrorValue = 0
      SharedExport.ExtendedInfoValue = ""
      SharedExport.InfoValue = ""
      SharedExport.pbMaxValue = 0
      SharedExport.pbValue = 0
      SharedExport.SuccessValue = 0
      SharedExport.TotalValue = ""
    End Try
  End Sub
End Class

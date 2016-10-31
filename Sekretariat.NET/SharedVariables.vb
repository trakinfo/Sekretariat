Public Class GlobalValues
  Public Shared gblConn As MySqlConnection = Nothing
  Public Shared gblUserName, gblIP As String, gblAdmin As Boolean
  Public Shared gblAppIcon As New System.Drawing.Icon(Application.StartupPath & "\sekretariat.net.ico")

End Class


Public Class SharedImport
  Public Shared pbValue, pbMaxValue, SuccessValue, ErrorValue As Integer, InfoValue, TotalValue As String
  Public Shared Event OnRecordForward()
  Public Shared Event OnpbMaxValueChange()
  Public Shared Event OnRoutineChange()
  Shared Sub RoutineChange()
    RaiseEvent OnRoutineChange()
  End Sub
  Shared Sub pbMaxValueChange()
    RaiseEvent OnpbMaxValueChange()
  End Sub
  Shared Sub RecordForward()
    RaiseEvent OnRecordForward()
  End Sub
End Class


Public Class SharedException
  Public Shared ErrorMessage As String, ErrorNumber As Integer
  Public Shared Event OnErrorGenerate()

  Shared Sub GenerateError(ByVal errNumber As Integer, ByVal errMessage As String)
    ErrorMessage = errMessage
    ErrorNumber = errNumber
    RaiseEvent OnErrorGenerate()
  End Sub

End Class

Public Class SharedExport
  Public Shared pbValue, pbMaxValue, SuccessValue, ErrorValue As Integer, InfoValue, ExtendedInfoValue, TotalValue As String
  Public Shared Event OnRecordForward()
  Public Shared Event OnpbMaxValueChange()
  Public Shared Event OnRoutineChange()
  Public Shared Event OnDetailedRoutineChange()
  Shared Sub DetailedRoutineChange()
    RaiseEvent OnDetailedRoutineChange()
  End Sub
  Shared Sub RoutineChange()
    RaiseEvent OnRoutineChange()
  End Sub
  Shared Sub pbMaxValueChange()
    RaiseEvent OnpbMaxValueChange()
  End Sub
  Shared Sub RecordForward()
    RaiseEvent OnRecordForward()
  End Sub
End Class

Public Class SharedStudent
  Public Shared Event OnOwnerClose(ByVal sender As Object, ByVal e As EventArgs)
  Shared Sub CloseChildren(ByVal sender As Object, ByVal e As EventArgs)
    RaiseEvent OnOwnerClose(sender, e)
  End Sub
End Class

Public Class SharedWychowawca
  Public Shared Event OnOwnerClose(ByVal sender As Object, ByVal e As EventArgs)
  Shared Sub CloseChildren(ByVal sender As Object, ByVal e As EventArgs)
    RaiseEvent OnOwnerClose(sender, e)
  End Sub
End Class

Public Class SharedKlasa
  Public Shared Event OnOwnerClose(ByVal sender As Object, ByVal e As EventArgs)
  Shared Sub CloseChildren(ByVal sender As Object, ByVal e As EventArgs)
    RaiseEvent OnOwnerClose(sender, e)
  End Sub
End Class

Public Class SharedPrzydzialKlas
  Public Shared Event OnOwnerClose(ByVal sender As Object, ByVal e As EventArgs)
  Shared Sub CloseChildren(ByVal sender As Object, ByVal e As EventArgs)
    RaiseEvent OnOwnerClose(sender, e)
  End Sub
End Class

Public Class SharedMiejscowosc
  Public Shared Event OnOwnerClose(ByVal sender As Object, ByVal e As EventArgs)
  Shared Sub CloseChildren(ByVal sender As Object, ByVal e As EventArgs)
    RaiseEvent OnOwnerClose(sender, e)
  End Sub
End Class


Public Class SharedWoj
  Public Shared Event OnOwnerClose(ByVal sender As Object, ByVal e As EventArgs)
  Shared Sub CloseChildren(ByVal sender As Object, ByVal e As EventArgs)
    RaiseEvent OnOwnerClose(sender, e)
  End Sub
End Class


Public Class SharedKraj
  Public Shared Event OnOwnerClose(ByVal sender As Object, ByVal e As EventArgs)
  Shared Sub CloseChildren(ByVal sender As Object, ByVal e As EventArgs)
    RaiseEvent OnOwnerClose(sender, e)
  End Sub
End Class

Public Class SharedSchool
  Public Shared Event OnOwnerClose(ByVal sender As Object, ByVal e As EventArgs)
  Shared Sub CloseChildren(ByVal sender As Object, ByVal e As EventArgs)
    RaiseEvent OnOwnerClose(sender, e)
  End Sub
End Class

Public Class SharedOrgan
  Public Shared Event OnOwnerClose(ByVal sender As Object, ByVal e As EventArgs)
  Shared Sub CloseChildren(ByVal sender As Object, ByVal e As EventArgs)
    RaiseEvent OnOwnerClose(sender, e)
  End Sub
End Class


Public Class SharedBelfer
  Public Shared Event OnOwnerClose(ByVal sender As Object, ByVal e As EventArgs)
  Shared Sub CloseChildren(ByVal sender As Object, ByVal e As EventArgs)
    RaiseEvent OnOwnerClose(sender, e)
  End Sub
End Class


Public Class SharedPrzydzialBelfer

  Public Shared Event OnOwnerClose(ByVal sender As Object, ByVal e As EventArgs)
  Shared Sub CloseChildren(ByVal sender As Object, ByVal e As EventArgs)
    RaiseEvent OnOwnerClose(sender, e)
  End Sub
End Class
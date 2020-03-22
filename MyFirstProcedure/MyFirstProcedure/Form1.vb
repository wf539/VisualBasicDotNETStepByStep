Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisplayTime()
    End Sub
    Sub DisplayTime()
        MsgBox(GetTime)
    End Sub
    Function GetTime() As String
        Return CStr(Now)
    End Function
End Class

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Number As Integer = CInt(TextBox1.Text)
        Select Case Number
            Case 1
                MsgBox("Less than 2")
            Case 2 To 5
                MsgBox("Between 2 and 5")
            Case 6, 7, 8
                MsgBox("Between 6 and 8")
            Case 9 To 10
                MsgBox("Greater than 8")
            Case Else
                MsgBox("Not between 1 and 10")
        End Select
    End Sub
End Class

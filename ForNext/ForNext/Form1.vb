Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer = 0
        Dim NumberOfRepetitions As Integer = CInt(TextBox1.Text)
        For i = 1 To NumberOfRepetitions
            MsgBox("This line has been repeated " & i & " times")
        Next
    End Sub
End Class

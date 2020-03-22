Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sum As Integer = 0
        Dim counter As Integer = 0
        Do While sum < 100
            sum = sum + CInt(TextBox1.Text)
            counter = counter + 1
        Loop
        MsgBox("The loop has run " & CStr(counter) & " times!")
        Dim sum2 As Integer = 0
        Dim counter2 As Integer = 0
        Do Until sum2 >= 100
            sum2 = sum2 + CInt(TextBox1.Text)
            counter2 = counter2 + 1
        Loop
        MsgBox("The loop has run " & CStr(counter2) & " times!")
    End Sub
End Class

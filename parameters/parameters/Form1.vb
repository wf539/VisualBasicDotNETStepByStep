Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim aNumber As Integer = CInt(TextBox1.Text)
        Dim bNumber As Integer = CInt(TextBox2.Text)
        MsgBox(AddTwoNumbers(aNumber, bNumber))
    End Sub
    Function AddTwoNumbers(ByVal N1 As Integer, ByVal N2 As Integer) _
As Integer
        Return N1 + N2
    End Function
End Class

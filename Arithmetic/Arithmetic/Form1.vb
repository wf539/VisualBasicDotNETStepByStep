Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim A As Double = TextBox1.Text
        Dim B As Double = TextBox2.Text

        MsgBox(A + B)
        MsgBox(A - B)
        MsgBox(A * B)
        MsgBox(A / B)
    End Sub
End Class

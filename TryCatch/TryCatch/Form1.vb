Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim aNumber As Double = CDbl(TextBox1.Text)
            MsgBox("You entered the number " & aNumber)
        Catch
            MsgBox("Please enter a number.")
        Finally
            MsgBox("Why not try it again?")
        End Try
    End Sub
End Class

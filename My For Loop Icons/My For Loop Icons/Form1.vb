Public Class Form1
    Dim Counter As Integer = 1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Counter += 1
        PictureBox1.Image = System.Drawing.Image.FromFile _
             ("d:\documents and settings\administrator\my documents\visual studio 2008\projects\face0" & Counter & ".ico")
        If Counter = 5 Then Counter = 1
    End Sub
End Class

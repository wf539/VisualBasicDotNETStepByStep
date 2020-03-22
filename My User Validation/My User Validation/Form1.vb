Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strUserName, strPass As String
        strUserName = InputBox("Enter your first name.")
        strPass = InputBox("Enter your password.")
        If strUserName = "Henry" And strPass = "flower" Then
            MsgBox("Welcome, Henry! How are you today?")
            PictureBox1.Image = System.Drawing.Image.FromFile _
            ("D:\documents and settings\administrator\my documents\visual studio 2008\projects\henry photo.jpg")
        ElseIf strUserName = "Felix" And strPass = "sand" Then
            MsgBox("Welcome, Felix, ready to play?")
            PictureBox1.Image = System.Drawing.Image.FromFile _
            ("D:\documents and settings\administrator\my documents\visual studio 2008\projects\felix photo.jpg")
        Else
            MsgBox("Sorry, I don't recognise you.")
            End 'quit the program
        End If
    End Sub
End Class

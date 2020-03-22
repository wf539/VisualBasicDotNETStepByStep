Public Class Form1

    Private Sub Button1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseEnter, Button2.MouseEnter
        If sender.Equals(Button1) Then
            Button1.Text = "The mouse has entered Button1"
        Else
            Button2.Text = "The mouse has entered Button2"
        End If
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave, Button2.MouseLeave
        sender.Text = "The mouse has left the button"
    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter, Label2.MouseEnter
        If sender.Equals(Label1) Then
            Label1.Text = "The mouse has entered the Label1 area"
        Else
            Label2.Text = "The mouse has entered the Label2 area"
        End If
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave, Label2.MouseLeave
        sender.Text = "The mouse has left the label area"
    End Sub
End Class

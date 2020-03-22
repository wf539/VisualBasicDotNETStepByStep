Public Class Form1

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTitle.Click

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FirstCountryBox.Items.Add("England")
        FirstCountryBox.Items.Add("Germany")
        FirstCountryBox.Items.Add("Mexico")
        FirstCountryBox.Items.Add("Italy")
    End Sub

    Private Sub FirstCountryBox_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles FirstCountryBox.MouseHover
        If FirstCountryBox.SelectedIndex < 0 Or _
        FirstCountryBox.SelectedIndex > 4 Then
            lblGreeting.Text = "Please click the country name"
        End If
    End Sub

    Private Sub FirstCountryBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FirstCountryBox.SelectedIndexChanged
        lblCountry.Text = FirstCountryBox.Text
        Select Case FirstCountryBox.SelectedIndex
            Case 0
                lblGreeting.Text = "Hello, programmer!"
            Case 1
                lblGreeting.Text = "Hallo, programmierer!"
            Case 2
                lblGreeting.Text = "Hola, programador!"
            Case 3
                lblGreeting.Text = "Ciao, programmatore!"
        End Select
    End Sub

    Private Sub btnQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuit.Click
        End
    End Sub
End Class

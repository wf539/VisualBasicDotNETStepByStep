Public Class Form1
    Dim Temperatures(6) As Single

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Prompt, Title As String
        Dim i As Short
        Prompt = "Enter the day's high temperature."
        For i = 0 To UBound(Temperatures)
            Title = "Day " & (i + 1)
            Temperatures(i) = InputBox(Prompt, Title)
        Next
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Result As String
        Dim i As Short
        Dim Total As Single = 0
        Result = "High temperatures for the week:" & vbCrLf & vbCrLf
        For i = 0 To UBound(Temperatures)
            Result = Result & "Day " & (i + 1) & vbTab & _
                Temperatures(i) & vbCrLf
            Total = Total + Temperatures(i)
        Next
        Result = Result & vbCrLf & _
                "Average temperature: " & Format(Total / 7, "0.0")
        TextBox1.Text = Result
    End Sub
End Class

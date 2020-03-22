Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Computer.Clock.LocalTime.DayOfWeek = DayOfWeek.Saturday Or _
My.Computer.Clock.LocalTime.DayOfWeek = DayOfWeek.Sunday Then
            MsgBox("Happy Weekend!")
        Else
            MsgBox("Happy Weekday! Don't work too hard!")
        End If
    End Sub
End Class

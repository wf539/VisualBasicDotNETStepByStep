Public Class Form1
    Dim URLsVisited As New Collection()

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        URLsVisited.Add(TextBox1.Text)
        System.Diagnostics.Process.Start(TextBox1.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim URLName, AllURLs As String
        For Each URLName In URLsVisited
            AllURLs = AllUR                             ����<<<����                                 ������                                         
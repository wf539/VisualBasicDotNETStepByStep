Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim FTemp, Celsius As Single
        Dim strFTemp As String
        Dim strPrompt As String = "Enter a Fahrenheit temperature."
        Do
            strFTemp = InputBox(strPrompt, "Fahrenheit to Celsius")
            If strFTemp <> "" Then
                FTemp = CSng(strFTemp)
                Celsius = Int((FTemp + 40) * 5 / 9 - 40)
                MsgBox(Ce                             ����<<<����                                 ������                             
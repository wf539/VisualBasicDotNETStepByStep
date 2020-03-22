Public Class Form1

    Private Sub PersonBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.PersonBindingSource.EndEdit()
        Me.PersonTableAdapter.Update(Me.MyDBDataSet.Person)

    End Sub


    Private Sub PersonBindingNavigatorSaveItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Validate()
        Me.PersonBindingSource.EndEdit()
        Me.PersonTableAdapter.Update(Me.MyDBDataSet.Person)

    End Sub


    Private Sub PersonBindingNavigatorSaveItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.PersonBindingSource.EndEdit()
        Me.PersonTableAdapter.Update(Me.MyDBDataSet.Person)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MyDBDataSet.Person' table. You can move, or remove it, as needed.
        Me.PersonTableAdapter.Fill(Me.MyDBDataSet.Person)

    End Sub
End Class

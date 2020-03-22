Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MacronutrientDBDataSet.Nutrient_Info' table. You can move, or remove it, as needed.
        Me.Nutrient_InfoTableAdapter.Fill(Me.MacronutrientDBDataSet.Nutrient_Info)

    End Sub

    Private Sub Nutrient_InfoBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Nutrient_InfoBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Nutrient_InfoBindingSource.EndEdit()
        Me.Nutrient_InfoTableAdapter.Update(Me.MacronutrientDBDataSet.Nutrient_Info)

    End Sub
End Class

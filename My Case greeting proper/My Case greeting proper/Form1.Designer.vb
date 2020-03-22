<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblTitle = New System.Windows.Forms.Label
        Me.lblTextBoxLabel = New System.Windows.Forms.Label
        Me.FirstCountryBox = New System.Windows.Forms.ListBox
        Me.lblCountry = New System.Windows.Forms.Label
        Me.lblGreeting = New System.Windows.Forms.Label
        Me.btnQuit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(62, 21)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(222, 19)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "International Welcome Program"
        '
        'lblTextBoxLabel
        '
        Me.lblTextBoxLabel.AutoSize = True
        Me.lblTextBoxLabel.Location = New System.Drawing.Point(123, 68)
        Me.lblTextBoxLabel.Name = "lblTextBoxLabel"
        Me.lblTextBoxLabel.Size = New System.Drawing.Size(90, 13)
        Me.lblTextBoxLabel.TabIndex = 1
        Me.lblTextBoxLabel.Text = "Choose a country"
        '
        'FirstCountryBox
        '
        Me.FirstCountryBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstCountryBox.FormattingEnabled = True
        Me.FirstCountryBox.Location = New System.Drawing.Point(109, 94)
        Me.FirstCountryBox.Name = "FirstCountryBox"
        Me.FirstCountryBox.Size = New System.Drawing.Size(120, 95)
        Me.FirstCountryBox.TabIndex = 2
        '
        'lblCountry
        '
        Me.lblCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountry.Location = New System.Drawing.Point(123, 216)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(100, 23)
        Me.lblCountry.TabIndex = 3
        '
        'lblGreeting
        '
        Me.lblGreeting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblGreeting.ForeColor = System.Drawing.Color.Red
        Me.lblGreeting.Location = New System.Drawing.Point(100, 239)
        Me.lblGreeting.Name = "lblGreeting"
        Me.lblGreeting.Size = New System.Drawing.Size(138, 23)
        Me.lblGreeting.TabIndex = 4
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(138, 284)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(75, 34)
        Me.btnQuit.TabIndex = 5
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 362)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.lblGreeting)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.FirstCountryBox)
        Me.Controls.Add(Me.lblTextBoxLabel)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "Form1"
        Me.Text = "Case greeting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblTextBoxLabel As System.Windows.Forms.Label
    Friend WithEvents FirstCountryBox As System.Windows.Forms.ListBox
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents lblGreeting As System.Windows.Forms.Label
    Friend WithEvents btnQuit As System.Windows.Forms.Button

End Class

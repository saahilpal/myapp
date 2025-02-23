<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class feedbackForm
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
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        ratingStars = New Guna.UI2.WinForms.Guna2RatingStar()
        txtFeedback = New Guna.UI2.WinForms.Guna2TextBox()
        btnSubmit = New Guna.UI2.WinForms.Guna2Button()
        btnBack = New Guna.UI2.WinForms.Guna2Button()
        Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        SuspendLayout()
        ' 
        ' ratingStars
        ' 
        ratingStars.Location = New Point(312, 110)
        ratingStars.Name = "ratingStars"
        ratingStars.RatingColor = Color.Gold
        ratingStars.Size = New Size(356, 75)
        ratingStars.TabIndex = 0
        ' 
        ' txtFeedback
        ' 
        txtFeedback.BorderColor = Color.FromArgb(CByte(100), CByte(181), CByte(246))
        txtFeedback.BorderRadius = 25
        txtFeedback.BorderThickness = 2
        txtFeedback.CustomizableEdges = CustomizableEdges1
        txtFeedback.DefaultText = ""
        txtFeedback.DisabledState.BorderColor = Color.FromArgb(CByte(208), CByte(208), CByte(208))
        txtFeedback.DisabledState.FillColor = Color.FromArgb(CByte(226), CByte(226), CByte(226))
        txtFeedback.DisabledState.ForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtFeedback.DisabledState.PlaceholderForeColor = Color.FromArgb(CByte(138), CByte(138), CByte(138))
        txtFeedback.FocusedState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtFeedback.Font = New Font("Segoe UI", 9F)
        txtFeedback.HoverState.BorderColor = Color.FromArgb(CByte(94), CByte(148), CByte(255))
        txtFeedback.Location = New Point(197, 221)
        txtFeedback.Margin = New Padding(6, 6, 6, 6)
        txtFeedback.Multiline = True
        txtFeedback.Name = "txtFeedback"
        txtFeedback.PasswordChar = ChrW(0)
        txtFeedback.PlaceholderText = "Write your feedback here..."
        txtFeedback.SelectedText = ""
        txtFeedback.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        txtFeedback.Size = New Size(625, 260)
        txtFeedback.TabIndex = 1
        ' 
        ' btnSubmit
        ' 
        btnSubmit.BorderRadius = 25
        btnSubmit.CustomizableEdges = CustomizableEdges3
        btnSubmit.DisabledState.BorderColor = Color.DarkGray
        btnSubmit.DisabledState.CustomBorderColor = Color.DarkGray
        btnSubmit.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnSubmit.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnSubmit.FillColor = Color.FromArgb(CByte(100), CByte(181), CByte(246))
        btnSubmit.Font = New Font("Segoe UI", 9F)
        btnSubmit.ForeColor = Color.White
        btnSubmit.Location = New Point(100, 508)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnSubmit.Size = New Size(279, 89)
        btnSubmit.TabIndex = 2
        btnSubmit.Text = " ✅ Submit"
        ' 
        ' btnBack
        ' 
        btnBack.BorderRadius = 25
        btnBack.CustomizableEdges = CustomizableEdges5
        btnBack.DisabledState.BorderColor = Color.DarkGray
        btnBack.DisabledState.CustomBorderColor = Color.DarkGray
        btnBack.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnBack.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnBack.FillColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnBack.Font = New Font("Segoe UI", 9F)
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(656, 508)
        btnBack.Name = "btnBack"
        btnBack.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnBack.Size = New Size(279, 89)
        btnBack.TabIndex = 3
        btnBack.Text = "🔙 Back"
        ' 
        ' Guna2Separator1
        ' 
        Guna2Separator1.Location = New Point(-1, 191)
        Guna2Separator1.Name = "Guna2Separator1"
        Guna2Separator1.Size = New Size(1074, 21)
        Guna2Separator1.TabIndex = 4
        ' 
        ' feedbackForm
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1074, 639)
        Controls.Add(Guna2Separator1)
        Controls.Add(btnBack)
        Controls.Add(btnSubmit)
        Controls.Add(txtFeedback)
        Controls.Add(ratingStars)
        Name = "feedbackForm"
        Text = "feedbackForm"
        ResumeLayout(False)
    End Sub

    Friend WithEvents ratingStars As Guna.UI2.WinForms.Guna2RatingStar
    Friend WithEvents txtFeedback As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents btnSubmit As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnBack As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
End Class

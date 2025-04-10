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
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        ratingStars = New Guna.UI2.WinForms.Guna2RatingStar()
        txtFeedback = New Guna.UI2.WinForms.Guna2TextBox()
        Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        Guna2CustomGradientPanel1 = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        btnBack = New Guna.UI2.WinForms.Guna2Button()
        btnSubmit = New Guna.UI2.WinForms.Guna2Button()
        Guna2CustomGradientPanel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ratingStars
        ' 
        ratingStars.BackColor = Color.WhiteSmoke
        ratingStars.BorderThickness = 4
        ratingStars.Location = New Point(361, 160)
        ratingStars.Name = "ratingStars"
        ratingStars.RatingColor = Color.Gold
        ratingStars.Size = New Size(356, 75)
        ratingStars.TabIndex = 0
        ' 
        ' txtFeedback
        ' 
        txtFeedback.BackColor = Color.Transparent
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
        txtFeedback.Location = New Point(220, 271)
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
        ' Guna2Separator1
        ' 
        Guna2Separator1.BackColor = Color.Transparent
        Guna2Separator1.Location = New Point(16, 241)
        Guna2Separator1.Name = "Guna2Separator1"
        Guna2Separator1.Size = New Size(1074, 21)
        Guna2Separator1.TabIndex = 4
        ' 
        ' Guna2CustomGradientPanel1
        ' 
        Guna2CustomGradientPanel1.Controls.Add(ratingStars)
        Guna2CustomGradientPanel1.Controls.Add(Guna2Separator1)
        Guna2CustomGradientPanel1.Controls.Add(btnBack)
        Guna2CustomGradientPanel1.Controls.Add(txtFeedback)
        Guna2CustomGradientPanel1.Controls.Add(btnSubmit)
        Guna2CustomGradientPanel1.CustomizableEdges = CustomizableEdges7
        Guna2CustomGradientPanel1.FillColor = Color.DeepSkyBlue
        Guna2CustomGradientPanel1.FillColor2 = Color.LightSkyBlue
        Guna2CustomGradientPanel1.FillColor3 = Color.Azure
        Guna2CustomGradientPanel1.FillColor4 = Color.LightSkyBlue
        Guna2CustomGradientPanel1.Location = New Point(-18, -32)
        Guna2CustomGradientPanel1.Name = "Guna2CustomGradientPanel1"
        Guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        Guna2CustomGradientPanel1.Size = New Size(1130, 713)
        Guna2CustomGradientPanel1.TabIndex = 5
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.Transparent
        btnBack.BorderRadius = 25
        btnBack.CustomizableEdges = CustomizableEdges3
        btnBack.DisabledState.BorderColor = Color.DarkGray
        btnBack.DisabledState.CustomBorderColor = Color.DarkGray
        btnBack.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnBack.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnBack.FillColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnBack.Font = New Font("Segoe UI", 9F)
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(640, 540)
        btnBack.Name = "btnBack"
        btnBack.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnBack.Size = New Size(279, 89)
        btnBack.TabIndex = 6
        btnBack.Text = "🔙 Back"
        ' 
        ' btnSubmit
        ' 
        btnSubmit.BackColor = Color.Transparent
        btnSubmit.BorderRadius = 25
        btnSubmit.CustomizableEdges = CustomizableEdges5
        btnSubmit.DisabledState.BorderColor = Color.DarkGray
        btnSubmit.DisabledState.CustomBorderColor = Color.DarkGray
        btnSubmit.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnSubmit.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnSubmit.FillColor = Color.FromArgb(CByte(100), CByte(181), CByte(246))
        btnSubmit.Font = New Font("Segoe UI", 9F)
        btnSubmit.ForeColor = Color.White
        btnSubmit.Location = New Point(73, 540)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnSubmit.Size = New Size(279, 89)
        btnSubmit.TabIndex = 2
        btnSubmit.Text = " ✅ Submit"
        ' 
        ' feedbackForm
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1074, 639)
        Controls.Add(Guna2CustomGradientPanel1)
        Name = "feedbackForm"
        Text = "feedbackForm"
        Guna2CustomGradientPanel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents ratingStars As Guna.UI2.WinForms.Guna2RatingStar
    Friend WithEvents txtFeedback As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Guna2CustomGradientPanel1 As Guna.UI2.WinForms.Guna2CustomGradientPanel
    Friend WithEvents btnBack As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSubmit As Guna.UI2.WinForms.Guna2Button
End Class

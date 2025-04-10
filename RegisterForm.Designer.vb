<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RegisterForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges11 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges12 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges13 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        btnBack = New Guna.UI2.WinForms.Guna2Button()
        btnTogglePassword = New Guna.UI2.WinForms.Guna2CircleButton()
        txtName = New Guna.UI2.WinForms.Guna2TextBox()
        lblTitle = New Guna.UI2.WinForms.Guna2HtmlLabel()
        lblName = New Guna.UI2.WinForms.Guna2HtmlLabel()
        lblEmail = New Guna.UI2.WinForms.Guna2HtmlLabel()
        lblPassword = New Guna.UI2.WinForms.Guna2HtmlLabel()
        lblConfirmPassword = New Guna.UI2.WinForms.Guna2HtmlLabel()
        btnRegister = New Guna.UI2.WinForms.Guna2Button()
        txtConfirmPassword = New Guna.UI2.WinForms.Guna2TextBox()
        txtEmail = New Guna.UI2.WinForms.Guna2TextBox()
        txtPassword = New Guna.UI2.WinForms.Guna2TextBox()
        SuspendLayout()
        ' 
        ' btnBack
        ' 
        btnBack.BackColor = Color.Transparent
        btnBack.BorderRadius = 30
        btnBack.CustomizableEdges = CustomizableEdges1
        btnBack.FillColor = Color.Tomato
        btnBack.Font = New Font("Segoe UI", 9F)
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(535, 922)
        btnBack.Margin = New Padding(6, 7, 6, 7)
        btnBack.Name = "btnBack"
        btnBack.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnBack.Size = New Size(360, 90)
        btnBack.TabIndex = 24
        btnBack.Text = "Back"
        ' 
        ' btnTogglePassword
        ' 
        btnTogglePassword.FillColor = Color.DeepSkyBlue
        btnTogglePassword.Font = New Font("Segoe UI", 9F)
        btnTogglePassword.ForeColor = Color.White
        btnTogglePassword.Location = New Point(765, 617)
        btnTogglePassword.Margin = New Padding(6, 7, 6, 7)
        btnTogglePassword.Name = "btnTogglePassword"
        btnTogglePassword.ShadowDecoration.CustomizableEdges = CustomizableEdges3
        btnTogglePassword.Size = New Size(70, 70)
        btnTogglePassword.TabIndex = 25
        ' 
        ' txtName
        ' 
        txtName.BackColor = Color.Transparent
        txtName.BorderRadius = 25
        txtName.CustomizableEdges = CustomizableEdges4
        txtName.DefaultText = ""
        txtName.Font = New Font("Segoe UI", 9F)
        txtName.Location = New Point(166, 273)
        txtName.Margin = New Padding(13, 15, 13, 15)
        txtName.Name = "txtName"
        txtName.PasswordChar = ChrW(0)
        txtName.PlaceholderText = "Full Name"
        txtName.SelectedText = ""
        txtName.ShadowDecoration.CustomizableEdges = CustomizableEdges5
        txtName.Size = New Size(580, 79)
        txtName.TabIndex = 26
        ' 
        ' lblTitle
        ' 
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI", 20F, FontStyle.Bold)
        lblTitle.Location = New Point(341, 98)
        lblTitle.Margin = New Padding(6, 7, 6, 7)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(504, 73)
        lblTitle.TabIndex = 27
        lblTitle.Text = "<b>Register an Account</b>"
        ' 
        ' lblName
        ' 
        lblName.BackColor = Color.Transparent
        lblName.Font = New Font("Segoe UI", 12F)
        lblName.Location = New Point(166, 223)
        lblName.Margin = New Padding(6, 7, 6, 7)
        lblName.Name = "lblName"
        lblName.Size = New Size(88, 47)
        lblName.TabIndex = 28
        lblName.Text = "Name"
        ' 
        ' lblEmail
        ' 
        lblEmail.BackColor = Color.Transparent
        lblEmail.Font = New Font("Segoe UI", 12F)
        lblEmail.Location = New Point(166, 396)
        lblEmail.Margin = New Padding(6, 7, 6, 7)
        lblEmail.Name = "lblEmail"
        lblEmail.Size = New Size(79, 47)
        lblEmail.TabIndex = 29
        lblEmail.Text = "Email"
        ' 
        ' lblPassword
        ' 
        lblPassword.BackColor = Color.Transparent
        lblPassword.Font = New Font("Segoe UI", 12F)
        lblPassword.Location = New Point(166, 568)
        lblPassword.Margin = New Padding(6, 7, 6, 7)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(137, 47)
        lblPassword.TabIndex = 30
        lblPassword.Text = "Password"
        ' 
        ' lblConfirmPassword
        ' 
        lblConfirmPassword.BackColor = Color.Transparent
        lblConfirmPassword.Font = New Font("Segoe UI", 12F)
        lblConfirmPassword.Location = New Point(166, 740)
        lblConfirmPassword.Margin = New Padding(6, 7, 6, 7)
        lblConfirmPassword.Name = "lblConfirmPassword"
        lblConfirmPassword.Size = New Size(260, 47)
        lblConfirmPassword.TabIndex = 31
        lblConfirmPassword.Text = "Confirm Password"
        ' 
        ' btnRegister
        ' 
        btnRegister.BackColor = Color.Transparent
        btnRegister.BorderRadius = 30
        btnRegister.CustomizableEdges = CustomizableEdges6
        btnRegister.Font = New Font("Segoe UI", 9F)
        btnRegister.ForeColor = Color.White
        btnRegister.Location = New Point(62, 922)
        btnRegister.Margin = New Padding(6, 7, 6, 7)
        btnRegister.Name = "btnRegister"
        btnRegister.ShadowDecoration.CustomizableEdges = CustomizableEdges7
        btnRegister.Size = New Size(360, 90)
        btnRegister.TabIndex = 32
        btnRegister.Text = "Register"
        ' 
        ' txtConfirmPassword
        ' 
        txtConfirmPassword.BackColor = Color.Transparent
        txtConfirmPassword.BorderRadius = 25
        txtConfirmPassword.CustomizableEdges = CustomizableEdges8
        txtConfirmPassword.DefaultText = ""
        txtConfirmPassword.Font = New Font("Segoe UI", 9F)
        txtConfirmPassword.Location = New Point(166, 790)
        txtConfirmPassword.Margin = New Padding(13, 15, 13, 15)
        txtConfirmPassword.Name = "txtConfirmPassword"
        txtConfirmPassword.PasswordChar = ChrW(0)
        txtConfirmPassword.PlaceholderText = "Confirm Password"
        txtConfirmPassword.SelectedText = ""
        txtConfirmPassword.ShadowDecoration.CustomizableEdges = CustomizableEdges9
        txtConfirmPassword.Size = New Size(580, 79)
        txtConfirmPassword.TabIndex = 33
        ' 
        ' txtEmail
        ' 
        txtEmail.BackColor = Color.Transparent
        txtEmail.BorderRadius = 25
        txtEmail.CustomizableEdges = CustomizableEdges10
        txtEmail.DefaultText = ""
        txtEmail.Font = New Font("Segoe UI", 9F)
        txtEmail.Location = New Point(166, 445)
        txtEmail.Margin = New Padding(13, 15, 13, 15)
        txtEmail.Name = "txtEmail"
        txtEmail.PasswordChar = ChrW(0)
        txtEmail.PlaceholderText = "Email Address"
        txtEmail.SelectedText = ""
        txtEmail.ShadowDecoration.CustomizableEdges = CustomizableEdges11
        txtEmail.Size = New Size(580, 79)
        txtEmail.TabIndex = 34
        ' 
        ' txtPassword
        ' 
        txtPassword.BackColor = Color.Transparent
        txtPassword.BorderRadius = 25
        txtPassword.CustomizableEdges = CustomizableEdges12
        txtPassword.DefaultText = ""
        txtPassword.Font = New Font("Segoe UI", 9F)
        txtPassword.Location = New Point(166, 617)
        txtPassword.Margin = New Padding(13, 15, 13, 15)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = ChrW(0)
        txtPassword.PlaceholderText = "Password"
        txtPassword.SelectedText = ""
        txtPassword.ShadowDecoration.CustomizableEdges = CustomizableEdges13
        txtPassword.Size = New Size(580, 79)
        txtPassword.TabIndex = 35
        ' 
        ' RegisterForm
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1106, 1170)
        Controls.Add(btnBack)
        Controls.Add(btnTogglePassword)
        Controls.Add(txtName)
        Controls.Add(lblTitle)
        Controls.Add(lblName)
        Controls.Add(lblEmail)
        Controls.Add(lblPassword)
        Controls.Add(lblConfirmPassword)
        Controls.Add(btnRegister)
        Controls.Add(txtConfirmPassword)
        Controls.Add(txtEmail)
        Controls.Add(txtPassword)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(6, 7, 6, 7)
        Name = "RegisterForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "RegisterForm"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Private WithEvents btnBack As Guna.UI2.WinForms.Guna2Button
    Private WithEvents btnTogglePassword As Guna.UI2.WinForms.Guna2CircleButton
    Private WithEvents txtName As Guna.UI2.WinForms.Guna2TextBox
    Private WithEvents lblTitle As Guna.UI2.WinForms.Guna2HtmlLabel
    Private WithEvents lblName As Guna.UI2.WinForms.Guna2HtmlLabel
    Private WithEvents lblEmail As Guna.UI2.WinForms.Guna2HtmlLabel
    Private WithEvents lblPassword As Guna.UI2.WinForms.Guna2HtmlLabel
    Private WithEvents lblConfirmPassword As Guna.UI2.WinForms.Guna2HtmlLabel
    Private WithEvents btnRegister As Guna.UI2.WinForms.Guna2Button
    Private WithEvents txtConfirmPassword As Guna.UI2.WinForms.Guna2TextBox
    Private WithEvents txtEmail As Guna.UI2.WinForms.Guna2TextBox
    Private WithEvents txtPassword As Guna.UI2.WinForms.Guna2TextBox

End Class

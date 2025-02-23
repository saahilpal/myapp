<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class wishlistForm
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges7 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges8 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges9 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges10 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2CustomGradientPanel1 = New Guna.UI2.WinForms.Guna2CustomGradientPanel()
        dgWishlist = New Guna.UI2.WinForms.Guna2DataGridView()
        btnRefresh = New Guna.UI2.WinForms.Guna2Button()
        btnBack = New Guna.UI2.WinForms.Guna2Button()
        btnLogout = New Guna.UI2.WinForms.Guna2Button()
        btnFeedback = New Guna.UI2.WinForms.Guna2Button()
        Removebtn = New DataGridViewButtonColumn()
        CType(dgWishlist, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2CustomGradientPanel1
        ' 
        Guna2CustomGradientPanel1.BackColor = Color.Transparent
        Guna2CustomGradientPanel1.CustomizableEdges = CustomizableEdges1
        Guna2CustomGradientPanel1.Location = New Point(-22, -6)
        Guna2CustomGradientPanel1.Name = "Guna2CustomGradientPanel1"
        Guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2CustomGradientPanel1.Size = New Size(1824, 144)
        Guna2CustomGradientPanel1.TabIndex = 0
        ' 
        ' dgWishlist
        ' 
        dgWishlist.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = Color.White
        dgWishlist.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgWishlist.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgWishlist.ColumnHeadersHeight = 46
        dgWishlist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgWishlist.Columns.AddRange(New DataGridViewColumn() {Removebtn})
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgWishlist.DefaultCellStyle = DataGridViewCellStyle3
        dgWishlist.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgWishlist.Location = New Point(-3, 294)
        dgWishlist.Name = "dgWishlist"
        dgWishlist.RowHeadersVisible = False
        dgWishlist.RowHeadersWidth = 82
        dgWishlist.Size = New Size(1729, 567)
        dgWishlist.TabIndex = 1
        dgWishlist.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgWishlist.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgWishlist.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgWishlist.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgWishlist.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgWishlist.ThemeStyle.BackColor = Color.White
        dgWishlist.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgWishlist.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgWishlist.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgWishlist.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9F)
        dgWishlist.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgWishlist.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgWishlist.ThemeStyle.HeaderStyle.Height = 46
        dgWishlist.ThemeStyle.ReadOnly = False
        dgWishlist.ThemeStyle.RowsStyle.BackColor = Color.White
        dgWishlist.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgWishlist.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        dgWishlist.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgWishlist.ThemeStyle.RowsStyle.Height = 41
        dgWishlist.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgWishlist.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' btnRefresh
        ' 
        btnRefresh.BorderRadius = 25
        btnRefresh.CustomizableEdges = CustomizableEdges3
        btnRefresh.DisabledState.BorderColor = Color.DarkGray
        btnRefresh.DisabledState.CustomBorderColor = Color.DarkGray
        btnRefresh.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnRefresh.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnRefresh.FillColor = Color.FromArgb(CByte(30), CByte(136), CByte(229))
        btnRefresh.Font = New Font("Segoe UI", 9F)
        btnRefresh.ForeColor = Color.White
        btnRefresh.Location = New Point(642, 893)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        btnRefresh.Size = New Size(250, 83)
        btnRefresh.TabIndex = 2
        btnRefresh.Text = "🔄 Refresh"
        ' 
        ' btnBack
        ' 
        btnBack.BorderRadius = 25
        btnBack.CustomizableEdges = CustomizableEdges5
        btnBack.DisabledState.BorderColor = Color.DarkGray
        btnBack.DisabledState.CustomBorderColor = Color.DarkGray
        btnBack.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnBack.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnBack.FillColor = Color.FromArgb(CByte(63), CByte(81), CByte(181))
        btnBack.Font = New Font("Segoe UI", 9F)
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(174, 893)
        btnBack.Name = "btnBack"
        btnBack.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        btnBack.Size = New Size(250, 83)
        btnBack.TabIndex = 3
        btnBack.Text = "🏠 Back"
        ' 
        ' btnLogout
        ' 
        btnLogout.BorderRadius = 25
        btnLogout.CustomizableEdges = CustomizableEdges7
        btnLogout.DisabledState.BorderColor = Color.DarkGray
        btnLogout.DisabledState.CustomBorderColor = Color.DarkGray
        btnLogout.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnLogout.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnLogout.FillColor = Color.FromArgb(CByte(198), CByte(40), CByte(40))
        btnLogout.Font = New Font("Segoe UI", 9F)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(1405, 893)
        btnLogout.Name = "btnLogout"
        btnLogout.ShadowDecoration.CustomizableEdges = CustomizableEdges8
        btnLogout.Size = New Size(250, 83)
        btnLogout.TabIndex = 4
        btnLogout.Text = "🔙 Logout"
        ' 
        ' btnFeedback
        ' 
        btnFeedback.BorderRadius = 25
        btnFeedback.CustomizableEdges = CustomizableEdges9
        btnFeedback.DisabledState.BorderColor = Color.DarkGray
        btnFeedback.DisabledState.CustomBorderColor = Color.DarkGray
        btnFeedback.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnFeedback.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnFeedback.FillColor = Color.FromArgb(CByte(100), CByte(181), CByte(246))
        btnFeedback.Font = New Font("Segoe UI", 9F)
        btnFeedback.ForeColor = Color.White
        btnFeedback.Location = New Point(1028, 893)
        btnFeedback.Name = "btnFeedback"
        btnFeedback.ShadowDecoration.CustomizableEdges = CustomizableEdges10
        btnFeedback.Size = New Size(250, 83)
        btnFeedback.TabIndex = 5
        btnFeedback.Text = "💬 Feedback"
        ' 
        ' Removebtn
        ' 
        Removebtn.HeaderText = "Remove"
        Removebtn.MinimumWidth = 10
        Removebtn.Name = "Removebtn"
        Removebtn.UseColumnTextForButtonValue = True
        ' 
        ' wishlistForm
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1719, 1019)
        Controls.Add(btnFeedback)
        Controls.Add(btnLogout)
        Controls.Add(btnBack)
        Controls.Add(btnRefresh)
        Controls.Add(dgWishlist)
        Controls.Add(Guna2CustomGradientPanel1)
        Name = "wishlistForm"
        Text = "wishlistForm"
        CType(dgWishlist, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Guna2CustomGradientPanel1 As Guna.UI2.WinForms.Guna2CustomGradientPanel
    Friend WithEvents dgWishlist As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents DeviceName As DataGridViewTextBoxColumn
    Friend WithEvents Brand As DataGridViewTextBoxColumn
    Friend WithEvents Price As DataGridViewTextBoxColumn
    Friend WithEvents btnRefresh As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnBack As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnLogout As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnFeedback As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Removebtn As DataGridViewButtonColumn
End Class

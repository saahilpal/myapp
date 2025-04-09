<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class popularForm
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim CustomizableEdges1 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges2 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        dgPopularPhones = New Guna.UI2.WinForms.Guna2DataGridView()
        btnBack = New Guna.UI2.WinForms.Guna2Button()
        Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        CType(dgPopularPhones, ComponentModel.ISupportInitialize).BeginInit()
        Guna2Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Guna2HtmlLabel1
        ' 
        Guna2HtmlLabel1.BackColor = Color.Transparent
        Guna2HtmlLabel1.Font = New Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Guna2HtmlLabel1.Location = New Point(376, 41)
        Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Guna2HtmlLabel1.Size = New Size(474, 88)
        Guna2HtmlLabel1.TabIndex = 0
        Guna2HtmlLabel1.Text = "Popular Phones"
        ' 
        ' dgPopularPhones
        ' 
        DataGridViewCellStyle1.BackColor = Color.White
        dgPopularPhones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgPopularPhones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgPopularPhones.ColumnHeadersHeight = 4
        dgPopularPhones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.White
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        DataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgPopularPhones.DefaultCellStyle = DataGridViewCellStyle3
        dgPopularPhones.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgPopularPhones.Location = New Point(-8, 0)
        dgPopularPhones.Name = "dgPopularPhones"
        dgPopularPhones.RowHeadersVisible = False
        dgPopularPhones.RowHeadersWidth = 82
        dgPopularPhones.Size = New Size(1263, 363)
        dgPopularPhones.TabIndex = 1
        dgPopularPhones.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgPopularPhones.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgPopularPhones.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgPopularPhones.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgPopularPhones.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgPopularPhones.ThemeStyle.BackColor = Color.White
        dgPopularPhones.ThemeStyle.GridColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgPopularPhones.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgPopularPhones.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgPopularPhones.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9F)
        dgPopularPhones.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgPopularPhones.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgPopularPhones.ThemeStyle.HeaderStyle.Height = 4
        dgPopularPhones.ThemeStyle.ReadOnly = False
        dgPopularPhones.ThemeStyle.RowsStyle.BackColor = Color.White
        dgPopularPhones.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgPopularPhones.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        dgPopularPhones.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgPopularPhones.ThemeStyle.RowsStyle.Height = 41
        dgPopularPhones.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgPopularPhones.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' btnBack
        ' 
        btnBack.BorderRadius = 25
        btnBack.CustomizableEdges = CustomizableEdges1
        btnBack.DisabledState.BorderColor = Color.DarkGray
        btnBack.DisabledState.CustomBorderColor = Color.DarkGray
        btnBack.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        btnBack.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        btnBack.FillColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        btnBack.Font = New Font("Segoe UI", 9F)
        btnBack.ForeColor = Color.White
        btnBack.Location = New Point(468, 715)
        btnBack.Name = "btnBack"
        btnBack.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        btnBack.Size = New Size(279, 89)
        btnBack.TabIndex = 4
        btnBack.Text = "🔙 Back"
        ' 
        ' Guna2Panel1
        ' 
        Guna2Panel1.BackColor = Color.Transparent
        Guna2Panel1.BorderRadius = 25
        Guna2Panel1.Controls.Add(dgPopularPhones)
        Guna2Panel1.CustomizableEdges = CustomizableEdges3
        Guna2Panel1.Location = New Point(12, 320)
        Guna2Panel1.Name = "Guna2Panel1"
        Guna2Panel1.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Guna2Panel1.Size = New Size(1255, 369)
        Guna2Panel1.TabIndex = 5
        Guna2Panel1.UseTransparentBackground = True
        ' 
        ' popularForm
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1279, 867)
        Controls.Add(Guna2Panel1)
        Controls.Add(btnBack)
        Controls.Add(Guna2HtmlLabel1)
        Name = "popularForm"
        Text = "popularForm"
        CType(dgPopularPhones, ComponentModel.ISupportInitialize).EndInit()
        Guna2Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents dgPopularPhones As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents btnBack As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
End Class

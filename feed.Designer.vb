<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class feed
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(feed))
        Refreshbtn = New Guna.UI2.WinForms.Guna2Button()
        Backbtn = New Guna.UI2.WinForms.Guna2Button()
        dgfeed = New Guna.UI2.WinForms.Guna2DataGridView()
        CType(dgfeed, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Refreshbtn
        ' 
        Refreshbtn.BackColor = Color.Transparent
        Refreshbtn.BorderRadius = 25
        Refreshbtn.CustomizableEdges = CustomizableEdges1
        Refreshbtn.DisabledState.BorderColor = Color.DarkGray
        Refreshbtn.DisabledState.CustomBorderColor = Color.DarkGray
        Refreshbtn.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Refreshbtn.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Refreshbtn.Font = New Font("Segoe UI", 9F)
        Refreshbtn.ForeColor = Color.White
        Refreshbtn.Location = New Point(337, 862)
        Refreshbtn.Name = "Refreshbtn"
        Refreshbtn.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Refreshbtn.Size = New Size(263, 71)
        Refreshbtn.TabIndex = 2
        Refreshbtn.Text = "Refresh"
        ' 
        ' Backbtn
        ' 
        Backbtn.BackColor = Color.Transparent
        Backbtn.BorderRadius = 25
        Backbtn.CustomizableEdges = CustomizableEdges3
        Backbtn.DisabledState.BorderColor = Color.DarkGray
        Backbtn.DisabledState.CustomBorderColor = Color.DarkGray
        Backbtn.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Backbtn.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Backbtn.FillColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        Backbtn.Font = New Font("Segoe UI", 9F)
        Backbtn.ForeColor = Color.White
        Backbtn.Location = New Point(1028, 862)
        Backbtn.Name = "Backbtn"
        Backbtn.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Backbtn.Size = New Size(279, 71)
        Backbtn.TabIndex = 4
        Backbtn.Text = "🔙 Back"
        ' 
        ' dgfeed
        ' 
        DataGridViewCellStyle1.BackColor = Color.White
        dgfeed.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dgfeed.BackgroundColor = Color.MintCream
        dgfeed.BorderStyle = BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.LightSkyBlue
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = Color.DodgerBlue
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.ButtonHighlight
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgfeed.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgfeed.ColumnHeadersHeight = 4
        dgfeed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.LightSkyBlue
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = Color.White
        DataGridViewCellStyle3.SelectionBackColor = Color.DeepSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = Color.White
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgfeed.DefaultCellStyle = DataGridViewCellStyle3
        dgfeed.EnableHeadersVisualStyles = True
        dgfeed.GridColor = Color.LightSkyBlue
        dgfeed.Location = New Point(24, 375)
        dgfeed.Name = "dgfeed"
        dgfeed.ReadOnly = True
        dgfeed.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = Color.LightSkyBlue
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.ForeColor = Color.White
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        dgfeed.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        dgfeed.RowHeadersVisible = False
        dgfeed.RowHeadersWidth = 82
        DataGridViewCellStyle5.BackColor = Color.LightSkyBlue
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dgfeed.RowsDefaultCellStyle = DataGridViewCellStyle5
        dgfeed.RowTemplate.DefaultCellStyle.BackColor = Color.Azure
        dgfeed.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.DodgerBlue
        dgfeed.Size = New Size(1773, 481)
        dgfeed.TabIndex = 5
        dgfeed.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White
        dgfeed.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgfeed.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgfeed.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgfeed.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgfeed.ThemeStyle.BackColor = Color.MintCream
        dgfeed.ThemeStyle.GridColor = Color.LightSkyBlue
        dgfeed.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(100), CByte(88), CByte(255))
        dgfeed.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgfeed.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 10.125F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        dgfeed.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgfeed.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgfeed.ThemeStyle.HeaderStyle.Height = 4
        dgfeed.ThemeStyle.ReadOnly = True
        dgfeed.ThemeStyle.RowsStyle.BackColor = Color.White
        dgfeed.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgfeed.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        dgfeed.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        dgfeed.ThemeStyle.RowsStyle.Height = 41
        dgfeed.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(231), CByte(229), CByte(255))
        dgfeed.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(CByte(71), CByte(69), CByte(94))
        ' 
        ' feed
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        ClientSize = New Size(1798, 1019)
        Controls.Add(dgfeed)
        Controls.Add(Backbtn)
        Controls.Add(Refreshbtn)
        Name = "feed"
        Text = "feed"
        CType(dgfeed, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Refreshbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Backbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents dgfeed As Guna.UI2.WinForms.Guna2DataGridView
End Class

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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim CustomizableEdges3 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges4 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges5 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Dim CustomizableEdges6 As Guna.UI2.WinForms.Suite.CustomizableEdges = New Guna.UI2.WinForms.Suite.CustomizableEdges()
        Guna2GradientPanel1 = New Guna.UI2.WinForms.Guna2GradientPanel()
        dgfeed = New Guna.UI2.WinForms.Guna2DataGridView()
        Refreshbtn = New Guna.UI2.WinForms.Guna2Button()
        Backbtn = New Guna.UI2.WinForms.Guna2Button()
        CType(dgfeed, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Guna2GradientPanel1
        ' 
        Guna2GradientPanel1.CustomizableEdges = CustomizableEdges1
        Guna2GradientPanel1.Location = New Point(-4, 3)
        Guna2GradientPanel1.Name = "Guna2GradientPanel1"
        Guna2GradientPanel1.ShadowDecoration.CustomizableEdges = CustomizableEdges2
        Guna2GradientPanel1.Size = New Size(1449, 166)
        Guna2GradientPanel1.TabIndex = 0
        ' 
        ' dgfeed
        ' 
        DataGridViewCellStyle1.BackColor = Color.FromArgb(CByte(194), CByte(224), CByte(244))
        dgfeed.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dgfeed.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dgfeed.ColumnHeadersHeight = 4
        dgfeed.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.FromArgb(CByte(214), CByte(234), CByte(247))
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = Color.Black
        DataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(CByte(119), CByte(186), CByte(231))
        DataGridViewCellStyle3.SelectionForeColor = Color.Black
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dgfeed.DefaultCellStyle = DataGridViewCellStyle3
        dgfeed.GridColor = Color.FromArgb(CByte(187), CByte(220), CByte(242))
        dgfeed.Location = New Point(-4, 335)
        dgfeed.Name = "dgfeed"
        dgfeed.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dgfeed.RowHeadersVisible = False
        dgfeed.RowHeadersWidth = 82
        dgfeed.Size = New Size(1449, 405)
        dgfeed.TabIndex = 1
        dgfeed.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.FeterRiver
        dgfeed.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(CByte(194), CByte(224), CByte(244))
        dgfeed.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        dgfeed.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty
        dgfeed.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty
        dgfeed.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty
        dgfeed.ThemeStyle.BackColor = Color.White
        dgfeed.ThemeStyle.GridColor = Color.FromArgb(CByte(187), CByte(220), CByte(242))
        dgfeed.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        dgfeed.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None
        dgfeed.ThemeStyle.HeaderStyle.Font = New Font("Segoe UI", 9F)
        dgfeed.ThemeStyle.HeaderStyle.ForeColor = Color.White
        dgfeed.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgfeed.ThemeStyle.HeaderStyle.Height = 4
        dgfeed.ThemeStyle.ReadOnly = False
        dgfeed.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(CByte(214), CByte(234), CByte(247))
        dgfeed.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dgfeed.ThemeStyle.RowsStyle.Font = New Font("Segoe UI", 9F)
        dgfeed.ThemeStyle.RowsStyle.ForeColor = Color.Black
        dgfeed.ThemeStyle.RowsStyle.Height = 41
        dgfeed.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(CByte(119), CByte(186), CByte(231))
        dgfeed.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black
        ' 
        ' Refreshbtn
        ' 
        Refreshbtn.BorderRadius = 25
        Refreshbtn.CustomizableEdges = CustomizableEdges3
        Refreshbtn.DisabledState.BorderColor = Color.DarkGray
        Refreshbtn.DisabledState.CustomBorderColor = Color.DarkGray
        Refreshbtn.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Refreshbtn.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Refreshbtn.Font = New Font("Segoe UI", 9F)
        Refreshbtn.ForeColor = Color.White
        Refreshbtn.Location = New Point(272, 769)
        Refreshbtn.Name = "Refreshbtn"
        Refreshbtn.ShadowDecoration.CustomizableEdges = CustomizableEdges4
        Refreshbtn.Size = New Size(263, 71)
        Refreshbtn.TabIndex = 2
        Refreshbtn.Text = "Refresh"
        ' 
        ' Backbtn
        ' 
        Backbtn.BorderRadius = 25
        Backbtn.CustomizableEdges = CustomizableEdges5
        Backbtn.DisabledState.BorderColor = Color.DarkGray
        Backbtn.DisabledState.CustomBorderColor = Color.DarkGray
        Backbtn.DisabledState.FillColor = Color.FromArgb(CByte(169), CByte(169), CByte(169))
        Backbtn.DisabledState.ForeColor = Color.FromArgb(CByte(141), CByte(141), CByte(141))
        Backbtn.FillColor = Color.FromArgb(CByte(211), CByte(47), CByte(47))
        Backbtn.Font = New Font("Segoe UI", 9F)
        Backbtn.ForeColor = Color.White
        Backbtn.Location = New Point(850, 769)
        Backbtn.Name = "Backbtn"
        Backbtn.ShadowDecoration.CustomizableEdges = CustomizableEdges6
        Backbtn.Size = New Size(279, 71)
        Backbtn.TabIndex = 4
        Backbtn.Text = "🔙 Back"
        ' 
        ' feed
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1449, 886)
        Controls.Add(Backbtn)
        Controls.Add(Refreshbtn)
        Controls.Add(dgfeed)
        Controls.Add(Guna2GradientPanel1)
        Name = "feed"
        Text = "feed"
        CType(dgfeed, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Guna2GradientPanel1 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents dgfeed As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Refreshbtn As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Backbtn As Guna.UI2.WinForms.Guna2Button
End Class

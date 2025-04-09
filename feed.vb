Imports Microsoft.Data.SqlClient

Public Class feed
    Private ReadOnly connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"

    ' FIX: Renamed from "parentForm" to avoid base class conflict
    Private _callerForm As Form

    ' Constructor accepts the caller form (AdminDashboard)
    Public Sub New(Optional caller As Form = Nothing)
        InitializeComponent()
        _callerForm = caller
    End Sub

    Private Sub feed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFeed()
    End Sub

    Private Sub LoadFeed()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT f.FeedbackID, u.Name AS Username, f.Rating, f.Comment, f.CreatedAt " &
                                      "FROM Feedback f JOIN Users u ON f.UserID = u.ID"

                Dim dt As New DataTable()
                Dim da As New SqlDataAdapter(query, con)
                da.Fill(dt)

                dgfeed.DataSource = dt
                FormatGrid()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading feedback: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        With dgfeed
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .RowTemplate.Height = 60
            .AllowUserToAddRows = False
            .ReadOnly = True
            .ScrollBars = ScrollBars.Both

            ' Header Styling
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 149, 237)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ColumnHeadersHeight = 35

            ' Cell Styling
            .DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255)
            .DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40)
            .DefaultCellStyle.Font = New Font("Segoe UI", 9)
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(225, 240, 255)

            .RowHeadersVisible = False
            .BorderStyle = BorderStyle.None
            .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .GridColor = Color.LightGray
        End With
    End Sub

    Private Sub Refreshbtn_Click(sender As Object, e As EventArgs) Handles Refreshbtn.Click
        LoadFeed()
    End Sub

    Private Sub Backbtn_Click(sender As Object, e As EventArgs) Handles Backbtn.Click
        If _callerForm IsNot Nothing Then
            _callerForm.Show()
        End If
        Me.Close()
    End Sub
End Class

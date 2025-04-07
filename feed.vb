
Imports Microsoft.Data.SqlClient

Public Class feed

    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"
    Private Sub feed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFeed()
    End Sub
    Private Sub LoadFeed()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT f.FeedbackID, u.Name AS Username, f.Rating, f.Comment, f.CreatedAt " &
                                  "FROM Feedback f JOIN Users u ON f.UserID = u.ID"

                Dim da As New SqlDataAdapter(query, con)
                Dim dt As New DataTable()
                da.Fill(dt)

                dgfeed.AutoGenerateColumns = True
                dgfeed.DataSource = dt

                ' Modern theme styling
                With dgfeed
                    ' HEADER STYLING
                    .EnableHeadersVisualStyles = False
                    .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 149, 237) ' CornflowerBlue
                    .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                    .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    .ColumnHeadersHeight = 35

                    ' CELL STYLING
                    .DefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255) ' AliceBlue
                    .DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40)
                    .DefaultCellStyle.Font = New Font("Segoe UI", 9)
                    .DefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 216, 230) ' LightBlue
                    .DefaultCellStyle.SelectionForeColor = Color.Black

                    .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(225, 240, 255)

                    .RowHeadersVisible = False
                    .BorderStyle = BorderStyle.None
                    .CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
                    .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

                    .GridColor = Color.LightGray
                End With


            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading feedback: " & ex.Message)
        End Try
    End Sub


    Private Sub Refreshbtn_Click(sender As Object, e As EventArgs) Handles Refreshbtn.Click
        LoadFeed()
    End Sub

    Private Sub Backbtn_Click(sender As Object, e As EventArgs) Handles Backbtn.Click
        Dim adminDashboard As New AdminDashboard()
        adminDashboard.Show()
        Me.Close()
    End Sub
End Class
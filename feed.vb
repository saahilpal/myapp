
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
                With dgfeed
                    .ColumnHeadersVisible = True
                    .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
                    .ColumnHeadersHeight = 30 ' or whatever height you like
                End With

                dgfeed.AutoGenerateColumns = True
                dgfeed.DataSource = dt
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
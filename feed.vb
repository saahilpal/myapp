Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Imports Guna.UI2.WinForms
Public Class feed

    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"
    Private Sub feed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFeed()
    End Sub

    Private Sub loadFeed()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT f.FeedbackID, u.Name AS Username, f.Rating, f.Comment, f.CreatedAt " &
                          "FROM Feedback f " &
                          "JOIN Users u ON f.UserID = u.ID"
            dgfeed.Columns.Add("FeedbackID", "Feedback ID")
            dgfeed.Columns.Add("Username", "Username")
            dgfeed.Columns.Add("Rating", "Rating")
            dgfeed.Columns.Add("Comment", "Comment")
            dgfeed.Columns.Add("CreatedAt", "Submitted On")
            Dim da As New SqlDataAdapter(query, con)
                Dim dt As New DataTable()
                da.Fill(dt)
                dgfeed.DataSource = dt ' Automatically creates columns with query result names
            End Using

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
Imports Microsoft.Data.SqlClient
Imports Microsoft.Identity.Client.Internal
Public Class wishlistForm

    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"

    Private loggedInUserID As Integer

    Public Sub New(userID As Integer)
        InitializeComponent()
        loggedInUserID = userID

    End Sub



    Private Sub wishlistForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadWishlist()
    End Sub
    Private Sub LoadWishlist()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT w.WishlistID, d.DeviceID, d.Name, d.Brand, d.Price 
                                   FROM Wishlist w 
                                   INNER JOIN Devices d ON w.DeviceID = d.DeviceID 
                                   WHERE w.UserID = @UserID"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = loggedInUserID

                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)

                    ' ✅ Debugging: Show DeviceIDs in the Wishlist
                    For Each row As DataRow In table.Rows
                        Console.WriteLine("Wishlist DeviceID: " & row("DeviceID"))
                    Next

                    ' ✅ Force DataGridView to refresh properly
                    dgWishlist.DataSource = Nothing
                    dgWishlist.Rows.Clear()
                    dgWishlist.DataSource = table
                    dgWishlist.Refresh()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading wishlist: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    Private Sub dgWishlist_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgWishlist.CellContentClick
        If dgWishlist.Columns(e.ColumnIndex).Name = "Removebtn" Then
            Try
                Dim wishlistID As Integer = Convert.ToInt32(dgWishlist.Rows(e.RowIndex).Cells("WishlistID").Value)

                Using con As New SqlConnection(connectionString)
                    con.Open()

                    Dim deleteQuery As String = "DELETE FROM Wishlist WHERE WishlistID = @WishlistID"
                    Using cmd As New SqlCommand(deleteQuery, con)
                        cmd.Parameters.AddWithValue("@WishlistID", wishlistID)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MessageBox.Show("Item removed from Wishlist!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadWishlist()
            Catch ex As Exception
                MessageBox.Show("Error removing item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        Dim dashboard As New UserDashboard(loggedInUserID)
        dashboard.Show()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadWishlist()
    End Sub

    Private Sub btnFeedback_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Dim feedback As New feedbackForm()
        feedback.Show()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
        loginform.Show()
    End Sub
End Class
Imports Microsoft.Data.SqlClient

Public Class wishlistForm
    Private connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"
    Private loggedInUserID As Integer
    Private callerForm As Form

    ' Designer constructor
    Public Sub New()
        InitializeComponent()
    End Sub

    ' Custom constructor with only userID (used by UserDashboard)
    Public Sub New(userID As Integer)
        InitializeComponent()
        loggedInUserID = userID
    End Sub

    ' Custom constructor with userID and parent form (used by Feedback)
    Public Sub New(userID As Integer, parentForm As Form)
        InitializeComponent()
        loggedInUserID = userID
        callerForm = parentForm
    End Sub

    Private Sub wishlistForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGrid()
        LoadWishlist()
    End Sub

    Private Sub SetupGrid()
        With dgWishlist
            .AllowUserToAddRows = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .ScrollBars = ScrollBars.Both
            .RowHeadersVisible = False
            .Columns.Clear()
        End With
    End Sub

    Private Sub LoadWishlist()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "
                    SELECT 
                        w.WishlistID, 
                        d.DeviceID, 
                        d.Name AS [Device Name], 
                        d.Brand AS [Brand], 
                        d.Price AS [Price (INR)]
                    FROM Wishlist w
                    INNER JOIN Devices d ON w.DeviceID = d.DeviceID
                    WHERE w.UserID = @UserID"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", loggedInUserID)

                    Dim adapter As New SqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)

                    If table.Rows.Count = 0 Then
                        MessageBox.Show("No items in your wishlist.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    dgWishlist.DataSource = Nothing
                    dgWishlist.DataSource = table

                    ' Hide IDs
                    If dgWishlist.Columns.Contains("WishlistID") Then dgWishlist.Columns("WishlistID").Visible = False
                    If dgWishlist.Columns.Contains("DeviceID") Then dgWishlist.Columns("DeviceID").Visible = False

                    ' Format price
                    If dgWishlist.Columns.Contains("Price (INR)") Then
                        dgWishlist.Columns("Price (INR)").DefaultCellStyle.Format = "₹#,0"
                    End If

                    ' Add remove button if not already added
                    If Not dgWishlist.Columns.Contains("Removebtn") Then
                        Dim removeBtn As New DataGridViewButtonColumn()
                        removeBtn.Name = "Removebtn"
                        removeBtn.HeaderText = ""
                        removeBtn.Text = "Remove"
                        removeBtn.UseColumnTextForButtonValue = True
                        removeBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                        dgWishlist.Columns.Add(removeBtn)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load wishlist: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgWishlist_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgWishlist.CellContentClick
        If e.RowIndex >= 0 AndAlso dgWishlist.Columns(e.ColumnIndex).Name = "Removebtn" Then
            Dim wishlistID As Integer = Convert.ToInt32(dgWishlist.Rows(e.RowIndex).Cells("WishlistID").Value)
            Dim confirm = MessageBox.Show("Remove this item from wishlist?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If confirm = DialogResult.Yes Then
                Try
                    Using con As New SqlConnection(connectionString)
                        con.Open()
                        Dim cmd As New SqlCommand("DELETE FROM Wishlist WHERE WishlistID = @WishlistID", con)
                        cmd.Parameters.AddWithValue("@WishlistID", wishlistID)
                        cmd.ExecuteNonQuery()
                    End Using
                    MessageBox.Show("Item removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadWishlist()
                Catch ex As Exception
                    MessageBox.Show("Failed to remove item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
        If callerForm IsNot Nothing Then callerForm.Show()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadWishlist()
    End Sub

    Private Sub btnFeedback_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Dim feedback As New feedbackForm(Me, loggedInUserID)
        feedback.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
        loginform.Show()
    End Sub
End Class

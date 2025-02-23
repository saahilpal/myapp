Imports Microsoft.Data.SqlClient

Public Class UserDashboard
    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"
    Private LoggedInUserID As Integer

    ' Constructor to receive userID
    Public Sub New(userID As Integer)
        InitializeComponent()
        LoggedInUserID = userID

    End Sub

    ' Load User Dashboard Data
    Private Sub UserDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlFilters.Visible = False ' Hide filter panel initially
        dgDevices.Visible = False ' Hide DataGridView initially
        LoadFilters()

    End Sub
    ' Load Filters from Database
    Private Sub LoadFilters()
        Using con As New SqlConnection(connectionString)
            con.Open()

            ' Load Brand Filter
            Dim brandQuery As String = "SELECT DISTINCT Brand FROM Devices"
            Dim brandCmd As New SqlCommand(brandQuery, con)
            Dim brandReader As SqlDataReader = brandCmd.ExecuteReader()
            cboBrand.Items.Clear()
            cboBrand.Items.Add("All") ' Default option
            While brandReader.Read()
                cboBrand.Items.Add(brandReader("Brand").ToString().Trim()) ' Trim spaces
            End While
            brandReader.Close()

            ' Load Performance Filter
            cboPerformance.Items.Clear()
            cboPerformance.Items.Add("All")
            cboPerformance.Items.Add("Flagship") ' Rank 1-6
            cboPerformance.Items.Add("Fast") ' Rank 7-14
            cboPerformance.Items.Add("Average") ' Rank 15 and below

            ' Load Price Filter (INR)
            cboPrice.Items.Clear()
            cboPrice.Items.Add("All")
            cboPrice.Items.Add("Budget") ' (0-25000) rs
            cboPrice.Items.Add("Mid-Range") ' (25001-49999) rs
            cboPrice.Items.Add("Premium") ' (50000+) rs

            ' Load Battery Filter
            cboBattery.Items.Clear()
            cboBattery.Items.Add("All")
            cboBattery.Items.Add("Medium Capacity") ' (3000-5000 mAh)
            cboBattery.Items.Add("High Capacity") ' (>5000 mAh)
        End Using
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtSearch.Text.Trim() = "" Then
            MessageBox.Show("Enter a device name to search!", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        LoadDevices(txtSearch.Text.Trim())

        dgDevices.Visible = True ' Show device list
    End Sub

    ' Load Devices Based on Search & Filters
    Private Sub LoadDevices(searchText As String)
        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "SELECT d.DeviceID, d.Name, d.Brand, d.Battery, d.Camera, p.ProcessorName, d.RAM, d.Price 
                               FROM Devices d 
                               INNER JOIN Performance p ON d.PerformanceID = p.PerformanceID 
                               WHERE d.Name LIKE @Search OR d.Brand LIKE @Search"

            Dim adapter As New SqlDataAdapter(query, con)
            adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" & searchText & "%")

            Dim table As New DataTable()
            adapter.Fill(table)

            ' ✅ Debugging: Show DeviceID values
            If table.Rows.Count > 0 Then
                For Each row As DataRow In table.Rows
                    Console.WriteLine("Loaded DeviceID: " & row("DeviceID"))
                Next
            Else
                MessageBox.Show("No devices found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            dgDevices.DataSource = Nothing  ' Clear before binding
            dgDevices.DataSource = table
            dgDevices.Refresh()
        End Using
    End Sub


    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        pnlFilters.Visible = True ' Show filter panel after search
    End Sub

    Private Sub dgDevices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDevices.CellContentClick

        If e.ColumnIndex = dgDevices.Columns("Wishlist").Index AndAlso e.RowIndex >= 0 Then
            ' ✅ Get the correct DeviceID from the selected row
            Dim selectedDeviceID As Integer = Convert.ToInt32(dgDevices.Rows(e.RowIndex).Cells("DeviceID").Value)

            ' ✅ Debugging: Show DeviceID before inserting
            MessageBox.Show("Selected Device ID: " & selectedDeviceID)

            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "INSERT INTO Wishlist (UserID, DeviceID) VALUES (@UserID, @DeviceID)"
                Dim cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UserID", LoggedInUserID)
                cmd.Parameters.AddWithValue("@DeviceID", selectedDeviceID)


                Try
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Device added to Wishlist!", "Wishlist", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As SqlException
                    If ex.Number = 2627 Then ' Unique constraint violation
                        MessageBox.Show("This device is already in your Wishlist!", "Wishlist Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Try
            End Using
        End If
    End Sub

    Private Sub btnWishlist_Click(sender As Object, e As EventArgs) Handles btnWishlist.Click
        Dim wishlistForm As New wishlistForm(LoggedInUserID)
        wishlistForm.Show()
    End Sub

    Private Sub btnPopular_Click(sender As Object, e As EventArgs) Handles btnPopular.Click

        Dim popularForm As New popularForm()
        popularForm.Show()
    End Sub

    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click
        Dim compareForm As New compareForm()
        compareForm.Show()
    End Sub

    Private Sub btnFeedback_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Dim feedbackForm As New feedbackForm(LoggedInUserID) ' ✅ Pass the userID
        feedbackForm.Show()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
        Dim loginform As New loginform()
        loginform.Show()
    End Sub

    Private Sub btnApplyFilters_Click(sender As Object, e As EventArgs) Handles btnApplyFilters.Click
        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "SELECT d.Name, d.Brand, d.Battery, d.Camera, p.ProcessorName, d.RAM, d.Price FROM Devices d " &
                                  "INNER JOIN Performance p ON d.PerformanceID = p.PerformanceID WHERE 1=1"

            Dim parameters As New List(Of SqlParameter)

            ' ✅ Apply Brand Filter if Selected
            If cboBrand.SelectedIndex > 0 Then
                query &= " AND d.Brand = @Brand"
                parameters.Add(New SqlParameter("@Brand", cboBrand.SelectedItem.ToString()))
            End If

            ' ✅ Apply Performance Rank Filter
            If cboPerformance.SelectedIndex > 0 Then
                Select Case cboPerformance.SelectedItem.ToString()
                    Case "Flagship"
                        query &= " AND p.PerformanceRank BETWEEN 1 AND 6"
                    Case "Fast"
                        query &= " AND p.PerformanceRank BETWEEN 7 AND 14"
                    Case "Average"
                        query &= " AND p.PerformanceRank >= 15"
                End Select
            End If

            ' ✅ Apply Price Filter
            If cboPrice.SelectedIndex > 0 Then
                Select Case cboPrice.SelectedItem.ToString()
                    Case "Budget"
                        query &= " AND d.Price BETWEEN 0 AND 25000"
                    Case "Mid-Range"
                        query &= " AND d.Price BETWEEN 25000 AND 50000"
                    Case "Premium"
                        query &= " AND d.Price >= 50000"
                End Select
            End If

            ' ✅ Apply Battery Filter
            If cboBattery.SelectedIndex > 0 Then
                Select Case cboBattery.SelectedItem.ToString()
                    Case "Medium Capacity"
                        query &= " AND d.Battery BETWEEN 3000 AND 5000"
                    Case "High Capacity"
                        query &= " AND d.Battery > 5000"
                End Select
            End If

            ' Execute the query
            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddRange(parameters.ToArray())

            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgDevices.DataSource = table

            ' Show DataGridView only if results exist
            If table.Rows.Count > 0 Then
                dgDevices.Visible = True
            Else
                MessageBox.Show("No matching devices found.", "Filter Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' Clear all ComboBoxes
        cboBrand.SelectedIndex = -1
        cboPerformance.SelectedIndex = -1
        cboPrice.SelectedIndex = -1
        cboBattery.SelectedIndex = -1

        ' Clear the search box
        txtSearch.Text = ""

        ' Hide DataGridView
        dgDevices.DataSource = Nothing
        dgDevices.Visible = False
    End Sub

End Class

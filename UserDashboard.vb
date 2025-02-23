Imports Microsoft.Data.SqlClient
Imports Windows.Win32.System

Public Class UserDashboard
    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"
    Private LoggedInUserID As Integer
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
            Dim brandQuery As String = "SELECT DISTINCT Brand FROM Devices"
            Dim brandCmd As New SqlCommand(brandQuery, con)
            Dim brandReader As SqlDataReader = brandCmd.ExecuteReader()
            cboBrand.Items.Clear()
            cboBrand.Items.Add("All")
            While brandReader.Read()
                cboBrand.Items.Add(brandReader("Brand").ToString().Trim())
            End While
            brandReader.Close()

            cboPerformance.Items.Clear()
            cboPerformance.Items.Add("All")
            cboPerformance.Items.Add("Flagship")
            cboPerformance.Items.Add("Fast")
            cboPerformance.Items.Add("Average")

            cboPrice.Items.Clear()
            cboPrice.Items.Add("All")
            cboPrice.Items.Add("Budget")
            cboPrice.Items.Add("Mid-Range")
            cboPrice.Items.Add("Premium")

            cboBattery.Items.Clear()
            cboBattery.Items.Add("All")
            cboBattery.Items.Add("Medium Capacity")
            cboBattery.Items.Add("High Capacity")
        End Using
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtSearch.Text.Trim() = "" Then
            MessageBox.Show("Enter a device name to search!", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        LoadDevices(txtSearch.Text.Trim())
        dgDevices.Visible = True
    End Sub

    ' Load Devices Based on Search & Filters
    Private Sub LoadDevices(searchText As String)
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT d.DeviceID, d.Name, d.Brand, d.Battery, d.Camera, p.ProcessorName, d.RAM, d.Price FROM Devices d " &
               "INNER JOIN Performance p ON d.PerformanceID = p.PerformanceID " &
                  "WHERE d.Name LIKE @Search OR d.Brand LIKE @Search"

            Dim adapter As New SqlDataAdapter(query, con)
            adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" & searchText & "%")
            Dim table As New DataTable()
            adapter.Fill(table)

            ' Clear and rebind data to ensure fresh display
            dgDevices.DataSource = Nothing
            dgDevices.DataSource = table

            ' Explicitly set column names to match the query
            dgDevices.Columns(0).Name = "DeviceID"
            dgDevices.Columns(1).Name = "Name"
            dgDevices.Columns(2).Name = "Brand"
            dgDevices.Columns(3).Name = "Battery"
            dgDevices.Columns(4).Name = "Camera"
            dgDevices.Columns(5).Name = "ProcessorName"
            dgDevices.Columns(6).Name = "RAM"
            dgDevices.Columns(7).Name = "Price"

            ' Debug: Show the first row’s DeviceID and Name
            If table.Rows.Count = 0 Then
                MessageBox.Show("No devices found for search.")
            End If
        End Using
    End Sub


    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        pnlFilters.Visible = True ' Show filter panel after search
    End Sub

    Private Sub dgDevices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDevices.CellContentClick
        If e.ColumnIndex = dgDevices.Columns("Wishlist").Index AndAlso e.RowIndex >= 0 Then
            Dim selectedDeviceID As Integer
            Try
                selectedDeviceID = Convert.ToInt32(dgDevices.Rows(e.RowIndex).Cells("DeviceID").Value)
            Catch ex As Exception
                MessageBox.Show("Invalid DeviceID detected: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            Dim selectedDeviceName As String = dgDevices.Rows(e.RowIndex).Cells("Name").Value.ToString()
            ' Validate DeviceID exists in Devices table
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim checkQuery As String = "SELECT COUNT(*) FROM Devices WHERE DeviceID = @DeviceID"
                Using checkCmd As New SqlCommand(checkQuery, con)
                    checkCmd.Parameters.AddWithValue("@DeviceID", selectedDeviceID)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count = 0 Then
                        MessageBox.Show("DeviceID " & selectedDeviceID & " does not exist in Devices table!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                Dim query As String = "INSERT INTO Wishlist (UserID, DeviceID) VALUES (@UserID, @DeviceID)"
                Dim cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UserID", LoggedInUserID)
                cmd.Parameters.AddWithValue("@DeviceID", selectedDeviceID)

                Try
                    cmd.ExecuteNonQuery()
                    MessageBox.Show(selectedDeviceName & " added to Wishlist!", "Wishlist", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As SqlException
                    If ex.Number = 2627 Then
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
            Dim query As String = "SELECT d.DeviceID, d.Name, d.Brand, d.Battery, d.Camera, p.ProcessorName, d.RAM, d.Price FROM Devices d " &
                                  "INNER JOIN Performance p ON d.PerformanceID = p.PerformanceID WHERE 1=1"
            Dim parameters As New List(Of SqlParameter)

            If cboBrand.SelectedIndex > 0 Then
                query &= " AND d.Brand = @Brand"
                parameters.Add(New SqlParameter("@Brand", cboBrand.SelectedItem.ToString()))
            End If

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

            If cboBattery.SelectedIndex > 0 Then
                Select Case cboBattery.SelectedItem.ToString()
                    Case "Medium Capacity"
                        query &= " AND d.Battery BETWEEN 3000 AND 5000"
                    Case "High Capacity"
                        query &= " AND d.Battery > 5000"
                End Select
            End If

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddRange(parameters.ToArray())
            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgDevices.DataSource = table

            If table.Rows.Count > 0 Then
                dgDevices.Visible = True
            Else
                MessageBox.Show("No matching devices found.", "Filter Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cboBrand.SelectedIndex = -1
        cboPerformance.SelectedIndex = -1
        cboPrice.SelectedIndex = -1
        cboBattery.SelectedIndex = -1
        txtSearch.Text = ""
        dgDevices.DataSource = Nothing
        dgDevices.Visible = False
    End Sub

End Class

Imports Microsoft.Data.SqlClient

Public Class UserDashboard
    Private connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"
    Private LoggedInUserID As Integer

    Public Sub New(userID As Integer)
        InitializeComponent()
        LoggedInUserID = userID

        dgDevices.Dock = DockStyle.Fill
        dgDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgDevices.AllowUserToAddRows = False
        dgDevices.ScrollBars = ScrollBars.Both

        cboPrice.DrawMode = DrawMode.OwnerDrawVariable
        AddHandler cboPrice.MeasureItem, AddressOf cboPrice_MeasureItem
        AddHandler cboPrice.DrawItem, AddressOf cboPrice_DrawItem
    End Sub

    Private Sub UserDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pnlFilters.Visible = False
        dgDevices.Visible = False
        LoadFilters()
    End Sub

    Private Sub LoadFilters()
        Using con As New SqlConnection(connectionString)
            con.Open()

            cboBrand.Items.Clear()
            cboBrand.Items.Add("All")

            Using cmd As New SqlCommand("SELECT DISTINCT Brand FROM Devices", con)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        cboBrand.Items.Add(reader("Brand").ToString().Trim())
                    End While
                End Using
            End Using

            cboPerformance.Items.AddRange({"All", "Flagship", "Fast", "Average"})

            cboPrice.Items.Clear()
            cboPrice.Items.Add("All")
            cboPrice.Items.Add("Budget (<25K)" & Environment.NewLine & "(\u20B90 – \u20B925,000)")
            cboPrice.Items.Add("Mid-Range(20k-50k)" & Environment.NewLine & "(\u20B925,001 – \u20B950,000)")
            cboPrice.Items.Add("Premium(>50k)" & Environment.NewLine & "(\u20B950,001 and above)")

            cboBattery.Items.AddRange({"All", "Medium Capacity", "High Capacity"})
        End Using
    End Sub

    Private Sub cboPrice_DrawItem(sender As Object, e As DrawItemEventArgs)
        If e.Index < 0 Then Return

        e.DrawBackground()
        Dim text = cboPrice.Items(e.Index).ToString()
        Dim lines = text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        Dim format As New StringFormat()
        format.LineAlignment = StringAlignment.Near

        Using brush As Brush = New SolidBrush(e.ForeColor)
            Dim rect = e.Bounds
            If lines.Length > 1 Then
                e.Graphics.DrawString(lines(0), cboPrice.Font, brush, rect.X, rect.Y)
                e.Graphics.DrawString(lines(1), cboPrice.Font, brush, rect.X, rect.Y + cboPrice.Font.Height)
            Else
                e.Graphics.DrawString(text, cboPrice.Font, brush, rect)
            End If
        End Using

        e.DrawFocusRectangle()
    End Sub

    Private Sub cboPrice_MeasureItem(sender As Object, e As MeasureItemEventArgs)
        If e.Index < 0 Then Return

        Dim text = cboPrice.Items(e.Index).ToString()
        Dim lines = text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        e.ItemHeight = cboPrice.Font.Height * lines.Length
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim keyword = txtSearch.Text.Trim()
        If keyword = "" Then
            MessageBox.Show("Enter a device name to search!", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        LoadDevices(keyword)
    End Sub

    Private Sub LoadDevices(searchText As String)
        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "SELECT d.DeviceID, d.Name, d.Brand, d.Battery, d.Camera, p.ProcessorName, d.RAM, d.Price " &
                                  "FROM Devices d INNER JOIN Performance p ON d.PerformanceID = p.PerformanceID " &
                                  "WHERE d.Name LIKE @Search OR d.Brand LIKE @Search"

            Dim adapter As New SqlDataAdapter(query, con)
            adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" & searchText & "%")

            Dim table As New DataTable()
            adapter.Fill(table)

            dgDevices.Columns.Clear()
            dgDevices.DataSource = table

            HideDeviceIDColumn()
            AddWishlistButtonColumn()
            dgDevices.Visible = True

            If table.Rows.Count = 0 Then
                MessageBox.Show("No devices found for search.")
            End If
        End Using
    End Sub

    Private Sub HideDeviceIDColumn()
        If dgDevices.Columns.Contains("DeviceID") Then
            dgDevices.Columns("DeviceID").Visible = False
        End If
    End Sub

    Private Sub btnApplyFilters_Click(sender As Object, e As EventArgs) Handles btnApplyFilters.Click
        Dim priceCategory = If(cboPrice.SelectedIndex > 0, cboPrice.SelectedItem.ToString(), "")
        Dim performanceCategory = If(cboPerformance.SelectedIndex > 0, cboPerformance.SelectedItem.ToString(), "")

        If (priceCategory.Contains("Budget") AndAlso (performanceCategory = "Flagship" OrElse performanceCategory = "Fast")) OrElse
           (priceCategory.Contains("Mid-Range") AndAlso performanceCategory = "Flagship") Then
            MessageBox.Show("Selected combination is unlikely or not available (e.g., Budget + Flagship).", "Invalid Filter", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using con As New SqlConnection(connectionString)
            con.Open()

            Dim query As String = "SELECT d.DeviceID, d.Name, d.Brand, d.Battery, d.Camera, p.ProcessorName, d.RAM, d.Price FROM Devices d " &
                                  "INNER JOIN Performance p ON d.PerformanceID = p.PerformanceID WHERE 1=1"
            Dim parameters As New List(Of SqlParameter)()

            If cboBrand.SelectedIndex > 0 Then
                query &= " AND d.Brand = @Brand"
                parameters.Add(New SqlParameter("@Brand", cboBrand.SelectedItem.ToString()))
            End If

            If cboPerformance.SelectedIndex > 0 Then
                Select Case performanceCategory
                    Case "Flagship" : query &= " AND p.PerformanceRank BETWEEN 1 AND 6"
                    Case "Fast" : query &= " AND p.PerformanceRank BETWEEN 7 AND 14"
                    Case "Average" : query &= " AND p.PerformanceRank >= 15"
                End Select
            End If

            If cboPrice.SelectedIndex > 0 Then
                Select Case cboPrice.SelectedIndex
                    Case 1 : query &= " AND d.Price BETWEEN 0 AND 25000"
                    Case 2 : query &= " AND d.Price BETWEEN 25001 AND 50000"
                    Case 3 : query &= " AND d.Price > 50000"
                End Select
            End If

            If cboBattery.SelectedIndex > 0 Then
                Select Case cboBattery.SelectedItem.ToString()
                    Case "Medium Capacity"
                        query &= " AND TRY_CAST(REPLACE(d.Battery, 'mAh', '') AS INT) BETWEEN 3000 AND 5000"
                    Case "High Capacity"
                        query &= " AND TRY_CAST(REPLACE(d.Battery, 'mAh', '') AS INT) > 5000"
                End Select
            End If

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddRange(parameters.ToArray())

            Dim adapter As New SqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)

            dgDevices.Columns.Clear()
            dgDevices.DataSource = table

            HideDeviceIDColumn()
            AddWishlistButtonColumn()
            dgDevices.Visible = True

            If table.Rows.Count = 0 Then
                MessageBox.Show("No matching devices found.", "Filter Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub AddWishlistButtonColumn()
        If dgDevices.Columns.Contains("Wishlist") Then Return

        Dim btnCol As New DataGridViewButtonColumn With {
            .HeaderText = "Wishlist",
            .Text = "Add",
            .Name = "Wishlist",
            .UseColumnTextForButtonValue = True
        }
        dgDevices.Columns.Insert(0, btnCol)
    End Sub

    Private Sub dgDevices_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDevices.CellContentClick
        If e.ColumnIndex = dgDevices.Columns("Wishlist").Index AndAlso e.RowIndex >= 0 Then
            Dim deviceID As Integer = Convert.ToInt32(dgDevices.Rows(e.RowIndex).Cells("DeviceID").Value)
            Dim deviceName As String = dgDevices.Rows(e.RowIndex).Cells("Name").Value.ToString()

            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM Wishlist WHERE UserID = @UserID AND DeviceID = @DeviceID", con)
                checkCmd.Parameters.AddWithValue("@UserID", LoggedInUserID)
                checkCmd.Parameters.AddWithValue("@DeviceID", deviceID)

                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                If exists > 0 Then
                    MessageBox.Show("This device is already in your wishlist.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                Dim insertCmd As New SqlCommand("INSERT INTO Wishlist (UserID, DeviceID) VALUES (@UserID, @DeviceID)", con)
                insertCmd.Parameters.AddWithValue("@UserID", LoggedInUserID)
                insertCmd.Parameters.AddWithValue("@DeviceID", deviceID)
                insertCmd.ExecuteNonQuery()

                MessageBox.Show($"{deviceName} has been added to your wishlist!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        End If
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        pnlFilters.Visible = True
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

    Private Sub btnWishlist_Click(sender As Object, e As EventArgs) Handles btnWishlist.Click
        Dim wishForm As New wishlistForm(LoggedInUserID)
        wishForm.Show()
    End Sub

    Private Sub btnPopular_Click(sender As Object, e As EventArgs) Handles btnPopular.Click
        Dim popForm As New popularForm()
        popForm.Show()
    End Sub

    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click
        Dim compareF As New compareform(LoggedInUserID)
        Me.Hide()
        compareF.Show()
    End Sub

    Private Sub btnFeedback_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Dim fbForm As New feedbackForm(Me, LoggedInUserID)
        Me.Hide()
        fbForm.Show()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
        Dim loginForm As New loginform()
        loginForm.Show()
    End Sub
End Class

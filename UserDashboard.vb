Imports Microsoft.Data.SqlClient

Public Class UserDashboard
    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"
    Private LoggedInUserID As Integer

    Public Sub New(userID As Integer)
        InitializeComponent()
        LoggedInUserID = userID

        ' DataGridView formatting and layout
        dgDevices.Dock = DockStyle.Fill
        dgDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgDevices.AllowUserToAddRows = False
        dgDevices.ScrollBars = ScrollBars.Both
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

            Dim cmd As New SqlCommand("SELECT DISTINCT Brand FROM Devices", con)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    cboBrand.Items.Add(reader("Brand").ToString().Trim())
                End While
            End Using

            cboPerformance.Items.AddRange({"All", "Flagship", "Fast", "Average"})
            cboPrice.Items.AddRange({"All", "Budget", "Mid-Range", "Premium"})
            cboBattery.Items.AddRange({"All", "Medium Capacity", "High Capacity"})
        End Using
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtSearch.Text.Trim() = "" Then
            MessageBox.Show("Enter a device name to search!", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        LoadDevices(txtSearch.Text.Trim())
    End Sub

    Private Sub LoadDevices(searchText As String)
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT d.Name, d.Brand, d.Battery, d.Camera, p.ProcessorName, d.RAM, d.Price " &
                                  "FROM Devices d INNER JOIN Performance p ON d.PerformanceID = p.PerformanceID " &
                                  "WHERE d.Name LIKE @Search OR d.Brand LIKE @Search"

            Dim adapter As New SqlDataAdapter(query, con)
            adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" & searchText & "%")
            Dim table As New DataTable()
            adapter.Fill(table)

            dgDevices.DataSource = table
            dgDevices.Visible = True

            If table.Rows.Count = 0 Then
                MessageBox.Show("No devices found for search.")
            End If
        End Using
    End Sub

    Private Sub btnApplyFilters_Click(sender As Object, e As EventArgs) Handles btnApplyFilters.Click
        Dim priceCategory As String = If(cboPrice.SelectedIndex > 0, cboPrice.SelectedItem.ToString(), "")
        Dim performanceCategory As String = If(cboPerformance.SelectedIndex > 0, cboPerformance.SelectedItem.ToString(), "")

        ' Validation for impossible combinations
        If (priceCategory = "Budget" AndAlso (performanceCategory = "Flagship" OrElse performanceCategory = "Fast")) OrElse
           (priceCategory = "Mid-Range" AndAlso performanceCategory = "Flagship") Then
            MessageBox.Show("Selected combination is unlikely or not available (e.g., Budget + Flagship). Please adjust filters.", "Invalid Filter Combination", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT d.Name, d.Brand, d.Battery, d.Camera, p.ProcessorName, d.RAM, d.Price FROM Devices d " &
                                  "INNER JOIN Performance p ON d.PerformanceID = p.PerformanceID WHERE 1=1"
            Dim parameters As New List(Of SqlParameter)()

            If cboBrand.SelectedIndex > 0 Then
                query &= " AND d.Brand = @Brand"
                parameters.Add(New SqlParameter("@Brand", cboBrand.SelectedItem.ToString()))
            End If

            If cboPerformance.SelectedIndex > 0 Then
                Select Case performanceCategory
                    Case "Flagship"
                        query &= " AND p.PerformanceRank BETWEEN 1 AND 6"
                    Case "Fast"
                        query &= " AND p.PerformanceRank BETWEEN 7 AND 14"
                    Case "Average"
                        query &= " AND p.PerformanceRank >= 15"
                End Select
            End If

            If cboPrice.SelectedIndex > 0 Then
                Select Case priceCategory
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

            dgDevices.DataSource = table
            dgDevices.Visible = True

            If table.Rows.Count = 0 Then
                MessageBox.Show("No matching devices found.", "Filter Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
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
        Dim wishlistForm As New wishlistForm(LoggedInUserID)
        wishlistForm.Show()
    End Sub

    Private Sub btnPopular_Click(sender As Object, e As EventArgs) Handles btnPopular.Click
        Dim popularForm As New popularForm()
        popularForm.Show()
    End Sub

    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click
        Dim compareForm As New compareform(LoggedInUserID)
        Me.Hide()
        compareForm.Show()
    End Sub

    Private Sub btnFeedback_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Dim feedbackForm As New feedbackForm(LoggedInUserID)
        feedbackForm.Show()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
        Dim loginform As New loginform()
        loginform.Show()
    End Sub
End Class

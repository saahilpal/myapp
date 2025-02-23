Imports Microsoft.Data.SqlClient
Public Class AdminDashboard
    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"
    Private Sub AdminDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDevices()
        LoadPerformance()
    End Sub
    Private Sub LoadPerformance()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT PerformanceID, ProcessorName FROM Performance"
            Dim cmd As New SqlCommand(query, con)
            Dim reader As SqlDataReader = cmd.ExecuteReader()

            performancecmb.Items.Clear() ' Clear previous items
            performancecmb.MaxDropDownItems = 8 ' Change this value as needed

            Dim dt As New DataTable()
            dt.Load(reader)

            ' Bind data to combo box
            performancecmb.DataSource = dt
            performancecmb.DisplayMember = "ProcessorName"
            performancecmb.ValueMember = "PerformanceID"

            ' Set default selection
            If performancecmb.Items.Count > 0 Then
                performancecmb.SelectedIndex = 0
            End If
        End Using
    End Sub

    ' Load Devices into DataGridView
    Private Sub LoadDevices()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT * FROM Devices"
            Dim adapter As New SqlDataAdapter(query, con)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgDevices.DataSource = table
            dgDevices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgDevices.ScrollBars = ScrollBars.Both
        End Using
    End Sub
    ' Add Device
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Using con As New SqlConnection(connectionString)

            con.Open()

            ' Debug: Show selected processor
            Dim selectedProcessor As String = performancecmb.Text.Trim()

            ' Get PerformanceID based on selected processor name
            Dim performanceID As Integer = -1
            Dim getPerformanceIDQuery As String = "SELECT PerformanceID FROM Performance WHERE LTRIM(RTRIM(ProcessorName)) = @ProcessorName"
            Using cmdPerf As New SqlCommand(getPerformanceIDQuery, con)
                cmdPerf.Parameters.AddWithValue("@ProcessorName", selectedProcessor)

                Dim result As Object = cmdPerf.ExecuteScalar()
                If result IsNot Nothing Then
                    performanceID = Convert.ToInt32(result)
                Else
                    MessageBox.Show("Error: Selected Performance not found in the database!", "Insertion Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End Using

            ' Insert into Devices table
            Dim query As String = "INSERT INTO Devices (Name, Brand, PerformanceID, Battery, RAM, Display, Price, Camera) 
                                   VALUES (@Name, @Brand, @PerformanceID, @Battery, @RAM, @Display, @Price, @Camera)"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim())
                cmd.Parameters.AddWithValue("@Brand", txtBrand.Text.Trim())
                cmd.Parameters.AddWithValue("@PerformanceID", performanceID)
                cmd.Parameters.AddWithValue("@Battery", txtBattery.Text.Trim())
                cmd.Parameters.AddWithValue("@RAM", txtRAM.Text.Trim())
                cmd.Parameters.AddWithValue("@Display", txtDisplay.Text.Trim())
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(txtPrice.Text.Trim()))
                cmd.Parameters.AddWithValue("@Camera", txtCamera.Text.Trim())

                cmd.ExecuteNonQuery()
                MessageBox.Show("Device Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadDevices() ' Refresh device list
            End Using


        End Using

    End Sub
    ' Delete Selected Device
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgDevices.SelectedRows.Count > 0 Then
            Dim id As Integer = Convert.ToInt32(dgDevices.SelectedRows(0).Cells("ID").Value)
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "DELETE FROM Devices WHERE ID=@ID"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@ID", id)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Device Deleted Successfully")
                    LoadDevices()
                End Using
            End Using
        Else
            MessageBox.Show("Please select a device to delete.")
        End If
    End Sub

    ' Search Device
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT * FROM Devices WHERE Name LIKE @Search OR Brand LIKE @Search"
            Dim adapter As New SqlDataAdapter(query, con)
            adapter.SelectCommand.Parameters.AddWithValue("@Search", "%" & txtSearch.Text & "%")
            Dim table As New DataTable()
            adapter.Fill(table)
            dgDevices.DataSource = table
        End Using
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        Me.Close()
        loginform.Show()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtName.Clear()
        txtBrand.Clear()
        performancecmb.SelectedIndex = -1
        txtBattery.Clear()
        txtRAM.Clear()
        txtDisplay.Clear()
        txtPrice.Clear()
        txtCamera.Clear()
        txtSearch.Clear()
    End Sub

    Private Sub Feed_Click(sender As Object, e As EventArgs) Handles Feed.Click
        Dim feed As New feed()
        feed.Show()
        Me.Close()
    End Sub
End Class
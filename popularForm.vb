Imports Microsoft.Data.SqlClient

Public Class popularForm
    Private connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"

    Public Sub New()
        InitializeComponent()
        SetupDataGridView()
        LoadPopularPhones()
    End Sub

    ' Apply styling and layout to DataGridView
    Private Sub SetupDataGridView()
        dgPopularPhones.Dock = DockStyle.Fill
        dgPopularPhones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgPopularPhones.AllowUserToAddRows = False
        dgPopularPhones.AllowUserToDeleteRows = False
        dgPopularPhones.ReadOnly = True
        dgPopularPhones.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgPopularPhones.RowHeadersVisible = False
        dgPopularPhones.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgPopularPhones.ScrollBars = ScrollBars.Both
        dgPopularPhones.ColumnHeadersVisible = True

        ' Increase column header height
        dgPopularPhones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        dgPopularPhones.ColumnHeadersHeight = 40
        dgPopularPhones.Font = New Font("Segoe UI", 10)
        dgPopularPhones.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
    End Sub

    ' Load top popular phones based on wishlist count
    Private Sub LoadPopularPhones()
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                Dim query As String = "SELECT TOP 10 d.Name AS [Device Name], d.Brand, d.Price, COUNT(w.WishlistID) AS [Times Favorited] " &
                                      "FROM Devices d " &
                                      "INNER JOIN Wishlist w ON d.DeviceID = w.DeviceID " &
                                      "GROUP BY d.Name, d.Brand, d.Price " &
                                      "ORDER BY [Times Favorited] DESC"

                Dim adapter As New SqlDataAdapter(query, con)
                Dim table As New DataTable()
                adapter.Fill(table)

                dgPopularPhones.DataSource = table

                If table.Rows.Count = 0 Then
                    MessageBox.Show("No popular phones found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading popular phones: " & ex.Message)
        End Try
    End Sub

    ' Go back to dashboard
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub
End Class

Imports Microsoft.Data.SqlClient

Public Class CompareForm

    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"

    Private Sub CompareForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBrands(cmbBrand1)
        LoadBrands(cmbBrand2)
    End Sub

    Private Sub LoadBrands(combo As ComboBox)
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT DISTINCT Brand FROM Devices"
            Using cmd As New SqlCommand(query, con)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        combo.Items.Add(reader("Brand").ToString())
                    End While
                End Using
            End Using
        End Using
    End Sub
    Private Sub cmbBrand1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBrand1.SelectedIndexChanged
        LoadDevicesByBrand(cmbBrand1.Text, cmbDevice1)
    End Sub

    Private Sub cmbBrand2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBrand2.SelectedIndexChanged
        LoadDevicesByBrand(cmbBrand2.Text, cmbDevice2)
    End Sub

    Private Sub LoadDevicesByBrand(brand As String, combo As ComboBox)
        combo.Items.Clear()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT Name FROM Devices WHERE Brand = @Brand"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Brand", brand)
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        combo.Items.Add(reader("Name").ToString())
                    End While
                End Using
            End Using
        End Using
    End Sub

    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click
        If cmbDevice1.Text = "" Or cmbDevice2.Text = "" Then
            MessageBox.Show("Please select both devices to compare.")
            Exit Sub
        End If

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT d.Name, d.Brand, p.ProcessorName AS Processor, d.Battery, d.RAM, d.Display, d.Price, d.Camera
                               FROM Devices d
                               JOIN Performance p ON d.PerformanceID = p.PerformanceID
                               WHERE d.Name = @Device1 OR d.Name = @Device2"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Device1", cmbDevice1.Text)
                cmd.Parameters.AddWithValue("@Device2", cmbDevice2.Text)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim originalTable As New DataTable()
                adapter.Fill(originalTable)

                If originalTable.Rows.Count = 2 Then
                    Dim transposedTable As New DataTable()

                    ' Add column headers: first column is "Spec", then device names
                    transposedTable.Columns.Add("Spec")
                    transposedTable.Columns.Add(originalTable.Rows(0)("Name").ToString())
                    transposedTable.Columns.Add(originalTable.Rows(1)("Name").ToString())

                    ' Loop through columns to create "Spec" rows
                    For Each col As DataColumn In originalTable.Columns
                        If col.ColumnName <> "Name" Then
                            Dim row = transposedTable.NewRow()
                            row("Spec") = col.ColumnName
                            row(1) = originalTable.Rows(0)(col)
                            row(2) = originalTable.Rows(1)(col)
                            transposedTable.Rows.Add(row)
                        End If
                    Next

                    dgCompare.DataSource = transposedTable
                    ApplyGridTheme(dgCompare)
                    HighlightDifferencesVertical(dgCompare)
                Else
                    MessageBox.Show("Both devices must be found in the database.")
                End If
            End Using
        End Using
    End Sub

    Private Sub HighlightDifferencesVertical(grid As DataGridView)
        For Each row As DataGridViewRow In grid.Rows
            Dim val1 = row.Cells(1).Value?.ToString()
            Dim val2 = row.Cells(2).Value?.ToString()

            If val1 <> val2 Then
                row.Cells(1).Style.BackColor = Color.LightYellow
                row.Cells(2).Style.BackColor = Color.LightYellow
                row.Cells(1).Style.ForeColor = Color.Black
                row.Cells(2).Style.ForeColor = Color.Black
            End If
        Next
    End Sub

    Private Sub ApplyGridTheme(grid As DataGridView)
        With grid
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersHeight = 30
            .DefaultCellStyle.BackColor = Color.FromArgb(240, 254, 254)
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Regular)
            .RowTemplate.Height = 35
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .GridColor = Color.LightGray
        End With
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cmbBrand1.SelectedIndex = -1
        cmbBrand2.SelectedIndex = -1
        cmbDevice1.Items.Clear()
        cmbDevice2.Items.Clear()
        dgCompare.DataSource = Nothing
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        AdminDashboard.Show()
        Me.Close()
    End Sub

End Class
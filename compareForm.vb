Imports Microsoft.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class compareform

    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"

    Private Sub compareform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBrands(cbBrand1)
        LoadBrands(cbBrand2)
        SetupDeviceComboBox(cbDevice1)
        SetupDeviceComboBox(cbDevice2)
    End Sub

    Private Sub LoadBrands(combo As ComboBox)
        combo.Items.Clear()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim cmd As New SqlCommand("SELECT DISTINCT Brand FROM Devices", con)
            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                combo.Items.Add(reader("Brand").ToString())
            End While
        End Using
    End Sub

    Private Sub cbBrand1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand1.SelectedIndexChanged
        LoadDevices(cbBrand1.Text, cbDevice1)
    End Sub

    Private Sub cbBrand2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand2.SelectedIndexChanged
        LoadDevices(cbBrand2.Text, cbDevice2)
    End Sub

    Private Sub LoadDevices(brand As String, combo As ComboBox)
        combo.DataSource = Nothing
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim cmd As New SqlCommand("SELECT Name FROM Devices WHERE Brand = @Brand", con)
            cmd.Parameters.AddWithValue("@Brand", brand)
            Dim dt As New DataTable()
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)

            For Each row As DataRow In dt.Rows
                Dim name As String = row("Name").ToString()
                row("Name") = name.Replace("Samsung", "").Replace("Apple", "").Replace("Google", "").Trim()
            Next

            combo.DataSource = dt
            combo.DisplayMember = "Name"
            combo.ValueMember = "Name"
        End Using
    End Sub

    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click
        If String.IsNullOrWhiteSpace(cbDevice1.Text) OrElse String.IsNullOrWhiteSpace(cbDevice2.Text) Then
            MessageBox.Show("Please select both devices to compare.")
            Return
        End If

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String =
                "SELECT d.Name, d.Brand, p.ProcessorName, d.PerformanceID, d.Battery, d.RAM, d.Display, d.Price, d.Camera 
                 FROM Devices d 
                 JOIN Performance p ON d.PerformanceID = p.PerformanceID 
                 WHERE d.Name LIKE @Device1 OR d.Name LIKE @Device2"

            Dim cmd As New SqlCommand(query, con)
            cmd.Parameters.AddWithValue("@Device1", "%" & cbDevice1.Text & "%")
            cmd.Parameters.AddWithValue("@Device2", "%" & cbDevice2.Text & "%")

            Dim dt As New DataTable()
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)

            If dt.Rows.Count = 2 Then
                Dim result As New DataTable()
                result.Columns.Add("Specification")
                result.Columns.Add(dt.Rows(0)("Name").ToString())
                result.Columns.Add(dt.Rows(1)("Name").ToString())

                AddSpec(result, "Brand", dt.Rows(0)("Brand"), dt.Rows(1)("Brand"))
                AddSpec(result, "Processor", dt.Rows(0)("ProcessorName"), dt.Rows(1)("ProcessorName"))
                AddSpec(result, "Battery", dt.Rows(0)("Battery"), dt.Rows(1)("Battery"))
                AddSpec(result, "RAM", dt.Rows(0)("RAM"), dt.Rows(1)("RAM"))
                AddSpec(result, "Display", dt.Rows(0)("Display"), dt.Rows(1)("Display"))
                AddSpec(result, "Price", dt.Rows(0)("Price"), dt.Rows(1)("Price"))
                AddSpec(result, "Camera", dt.Rows(0)("Camera"), dt.Rows(1)("Camera"))

                dgvCompare.DataSource = result
                dgvCompare.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                HighlightDifferences(dt)
            Else
                MessageBox.Show("Devices not found.")
            End If
        End Using
    End Sub

    Private Sub AddSpec(table As DataTable, label As String, val1 As Object, val2 As Object)
        Dim row = table.NewRow()
        row(0) = label
        row(1) = val1.ToString()
        row(2) = val2.ToString()
        table.Rows.Add(row)
    End Sub

    Private Sub HighlightDifferences(original As DataTable)
        If dgvCompare.DataSource Is Nothing Then Return

        Dim col1 As Integer = 1, col2 As Integer = 2
        Dim diffColor As Color = Color.LightSkyBlue
        Dim highlightColor As Color = Color.FromArgb(200, 230, 255)
        Dim lossColor As Color = Color.Salmon

        Dim diff1 As Integer = 0, diff2 As Integer = 0
        Dim price1 As Decimal = 0, price2 As Decimal = 0
        Dim cam1 As String = "", cam2 As String = ""

        ' Pre-read price and camera values
        For Each row As DataGridViewRow In dgvCompare.Rows
            If row.IsNewRow Then Continue For
            Dim spec = row.Cells(0).Value.ToString().ToLower()

            If spec.Contains("price") Then
                Decimal.TryParse(row.Cells(col1).Value.ToString(), price1)
                Decimal.TryParse(row.Cells(col2).Value.ToString(), price2)
            ElseIf spec.Contains("camera") Then
                cam1 = row.Cells(col1).Value.ToString()
                cam2 = row.Cells(col2).Value.ToString()
            End If
        Next

        ' Highlight differences
        For Each row As DataGridViewRow In dgvCompare.Rows
            If row.IsNewRow Then Continue For
            Dim spec = row.Cells(0).Value.ToString().ToLower()
            Dim val1 = row.Cells(col1).Value.ToString()
            Dim val2 = row.Cells(col2).Value.ToString()

            If val1 <> val2 AndAlso Not spec.Contains("camera") Then
                row.Cells(col1).Style.BackColor = diffColor
                row.Cells(col2).Style.BackColor = diffColor
                diff1 += 1 : diff2 += 1
            End If
        Next

        ' Compare camera
        Dim mp1 = ExtractMegapixels(cam1)
        Dim mp2 = ExtractMegapixels(cam2)

        For Each row As DataGridViewRow In dgvCompare.Rows
            If row.IsNewRow Then Continue For
            If row.Cells(0).Value.ToString().ToLower().Contains("camera") Then
                If price1 > price2 AndAlso mp1 < mp2 Then
                    row.Cells(col1).Style.BackColor = lossColor
                    row.Cells(col1).Style.ForeColor = Color.White
                    diff1 += 1
                ElseIf price2 > price1 AndAlso mp2 < mp1 Then
                    row.Cells(col2).Style.BackColor = lossColor
                    row.Cells(col2).Style.ForeColor = Color.White
                    diff2 += 1
                End If
            End If
        Next

        ' Highlight name of the weaker device
        If diff1 > diff2 Then
            dgvCompare.Rows(0).Cells(col1).Style.BackColor = highlightColor
        ElseIf diff2 > diff1 Then
            dgvCompare.Rows(0).Cells(col2).Style.BackColor = highlightColor
        End If
    End Sub

    Private Function ExtractMegapixels(value As String) As Integer
        Dim matches = Regex.Matches(value, "\d+")
        Dim maxMP As Integer = 0
        For Each m As Match In matches
            Dim val = Integer.Parse(m.Value)
            If val > maxMP Then maxMP = val
        Next
        Return maxMP
    End Function

    Private Sub SetupDeviceComboBox(combo As ComboBox)
        combo.DropDownStyle = ComboBoxStyle.DropDownList
        combo.IntegralHeight = False
        combo.MaxDropDownItems = 10
        combo.Width = 400
        combo.Font = New Font("Segoe UI", 12, FontStyle.Regular)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cbBrand1.SelectedIndex = -1
        cbBrand2.SelectedIndex = -1
        cbDevice1.DataSource = Nothing
        cbDevice2.DataSource = Nothing
        dgvCompare.DataSource = Nothing
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        AdminDashboard.Show()
        Me.Close()
    End Sub

End Class

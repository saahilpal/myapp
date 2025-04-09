Imports Microsoft.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class compareform
    Private connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"
    Private LoggedInUserID As Integer

    Public Sub New(userID As Integer)
        InitializeComponent()
        LoggedInUserID = userID
    End Sub

    Private Sub compareform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBrands(cbBrand1)
        LoadBrands(cbBrand2)
        SetupComboBox(cbDevice1)
        SetupComboBox(cbDevice2)
    End Sub

    Private Sub LoadBrands(combo As ComboBox)
        combo.Items.Clear()
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim cmd As New SqlCommand("SELECT DISTINCT Brand FROM Devices", con)
            Using reader = cmd.ExecuteReader()
                While reader.Read()
                    combo.Items.Add(reader("Brand").ToString())
                End While
            End Using
        End Using
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
                row("Name") = Regex.Replace(row("Name").ToString(), "(?i)\b(Samsung|Apple|Google)\b", "").Trim()
            Next

            combo.DataSource = dt
            combo.DisplayMember = "Name"
        End Using
    End Sub

    Private Sub cbBrand1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand1.SelectedIndexChanged
        LoadDevices(cbBrand1.Text, cbDevice1)
    End Sub

    Private Sub cbBrand2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBrand2.SelectedIndexChanged
        LoadDevices(cbBrand2.Text, cbDevice2)
    End Sub

    Private Sub btnCompare_Click(sender As Object, e As EventArgs) Handles btnCompare.Click
        If cbDevice1.Text = "" OrElse cbDevice2.Text = "" Then
            MessageBox.Show("Please select both devices.")
            Return
        End If

        If cbDevice1.Text = cbDevice2.Text AndAlso cbBrand1.Text = cbBrand2.Text Then
            MessageBox.Show("You selected the same device for comparison. Please choose two different devices.", "Same Device", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim cmd As New SqlCommand("SELECT d.Name, d.Brand, d.Battery, d.RAM, d.Display, d.Price, d.Camera, p.ProcessorName, p.PerformanceRank 
                                   FROM Devices d JOIN Performance p ON d.PerformanceID = p.PerformanceID 
                                   WHERE d.Name LIKE @dev1 OR d.Name LIKE @dev2", con)
            cmd.Parameters.AddWithValue("@dev1", "%" & cbDevice1.Text & "%")
            cmd.Parameters.AddWithValue("@dev2", "%" & cbDevice2.Text & "%")

            Dim dt As New DataTable()
            Dim adapter As New SqlDataAdapter(cmd)
            adapter.Fill(dt)

            If dt.Rows.Count = 2 Then
                Dim result As New DataTable()
                result.Columns.Add("Specification")
                result.Columns.Add(dt.Rows(0)("Name").ToString())
                result.Columns.Add(dt.Rows(1)("Name").ToString())

                AddRow(result, "Brand", dt.Rows(0)("Brand"), dt.Rows(1)("Brand"))
                AddRow(result, "Processor", dt.Rows(0)("ProcessorName"), dt.Rows(1)("ProcessorName"))
                AddRow(result, "Battery", dt.Rows(0)("Battery"), dt.Rows(1)("Battery"))
                AddRow(result, "RAM", dt.Rows(0)("RAM"), dt.Rows(1)("RAM"))
                AddRow(result, "Display", dt.Rows(0)("Display"), dt.Rows(1)("Display"))
                AddRow(result, "Price", dt.Rows(0)("Price"), dt.Rows(1)("Price"))
                AddRow(result, "Camera", dt.Rows(0)("Camera"), dt.Rows(1)("Camera"))

                dgvCompare.DataSource = result
                dgvCompare.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                HighlightBetterDevice(dt)
            Else
                MessageBox.Show("Devices not found in database.")
            End If
        End Using
    End Sub

    Private Sub HighlightBetterDevice(dt As DataTable)
        Dim dev1 = dt.Rows(0)
        Dim dev2 = dt.Rows(1)
        Dim score1 As Integer = 0
        Dim score2 As Integer = 0
        Dim reasons1 As New List(Of String)
        Dim reasons2 As New List(Of String)

        ' Performance Rank
        Dim rank1 = Convert.ToInt32(dev1("PerformanceRank"))
        Dim rank2 = Convert.ToInt32(dev2("PerformanceRank"))
        If rank1 < rank2 Then
            score1 += 1
            reasons1.Add("better performance")
        ElseIf rank2 < rank1 Then
            score2 += 1
            reasons2.Add("better performance")
        End If

        ' Price (lower = better)
        If Convert.ToDecimal(dev1("Price")) < Convert.ToDecimal(dev2("Price")) Then
            score1 += 1
        Else
            score2 += 1
        End If

        ' Camera
        Dim cam1 = ExtractMegapixels(dev1("Camera").ToString())
        Dim cam2 = ExtractMegapixels(dev2("Camera").ToString())
        If cam1 > cam2 Then
            score1 += 1
            reasons1.Add("better camera")
        ElseIf cam2 > cam1 Then
            score2 += 1
            reasons2.Add("better camera")
        End If

        ' RAM
        Dim ram1 = ExtractNumber(dev1("RAM").ToString())
        Dim ram2 = ExtractNumber(dev2("RAM").ToString())
        If ram1 > ram2 Then
            score1 += 1
        ElseIf ram2 > ram1 Then
            score2 += 1
        End If

        ' Highlight better column
        Dim betterIndex = If(score1 > score2, 1, 2)
        dgvCompare.Columns(betterIndex).DefaultCellStyle.BackColor = Color.LightGreen
        dgvCompare.Columns(If(betterIndex = 1, 2, 1)).DefaultCellStyle.BackColor = Color.LightCoral

        ' Final message
        Dim betterDevice = dt.Rows(betterIndex - 1)("Name").ToString()
        Dim reasons = If(betterIndex = 1, reasons1, reasons2)
        Dim msg = betterDevice & " is the overall best."

        If reasons.Count > 0 Then
            msg &= vbCrLf & "It has " & String.Join(" and ", reasons) & "."
        End If

        MessageBox.Show(msg, "Comparison Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Sub AddRow(tbl As DataTable, spec As String, val1 As Object, val2 As Object)
        Dim row = tbl.NewRow()
        row("Specification") = spec
        row(1) = val1.ToString()
        row(2) = val2.ToString()
        tbl.Rows.Add(row)
    End Sub

    Private Function ExtractMegapixels(text As String) As Integer
        Dim matches = Regex.Matches(text, "\d+")
        If matches.Count > 0 Then
            Return matches.Cast(Of Match).Select(Function(m) Integer.Parse(m.Value)).Max()
        End If
        Return 0
    End Function

    Private Function ExtractNumber(text As String) As Integer
        Dim match = Regex.Match(text, "\d+")
        Return If(match.Success, Integer.Parse(match.Value), 0)
    End Function

    Private Sub SetupComboBox(combo As ComboBox)
        combo.DropDownStyle = ComboBoxStyle.DropDownList
        combo.IntegralHeight = False
        combo.MaxDropDownItems = 10
        combo.Width = 300
        combo.DropDownWidth = 600
        combo.Font = New Font("Segoe UI", 12)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cbBrand1.SelectedIndex = -1
        cbBrand2.SelectedIndex = -1
        cbDevice1.DataSource = Nothing
        cbDevice2.DataSource = Nothing
        dgvCompare.DataSource = Nothing
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim dashboard As New UserDashboard(LoggedInUserID)
        dashboard.Show()
        Me.Close()
    End Sub
End Class

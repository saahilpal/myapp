Imports Microsoft.Data.SqlClient

Public Class loginform
    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both email and password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT ID, Role FROM Users WHERE Email=@Email AND Password=@Password"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Password", password)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            LoggedInUserID = Convert.ToInt32(reader("ID"))
                            Dim role As String = reader("Role").ToString()

                            If role = "Admin" Then
                                MessageBox.Show("Welcome, Admin!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Dim adminForm As New AdminDashboard()
                                adminForm.Show()
                            Else
                                MessageBox.Show("Welcome!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Dim dashboard As New UserDashboard(LoggedInUserID)
                                dashboard.Show()
                            End If

                            Me.Hide()
                        Else
                            MessageBox.Show("Invalid email or password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred during login: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        RegisterForm.Show()
        Me.Hide()
    End Sub
End Class

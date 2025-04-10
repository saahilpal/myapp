Imports Microsoft.Data.SqlClient

Public Class loginform
    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"

    ' Form Load event to ensure the password is hidden initially
    Private Sub loginform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set password field to hidden by default
        txtPassword.UseSystemPasswordChar = True
        ' Set the button text to indicate the password is hidden
        btnTogglePassword.Text = "🙈" ' Hide the password (Hidden Emoji)
    End Sub

    ' Toggle Password visibility function
    Private Sub btnTogglePassword_Click(sender As Object, e As EventArgs) Handles btnTogglePassword.Click
        If txtPassword.UseSystemPasswordChar Then
            txtPassword.UseSystemPasswordChar = False
            btnTogglePassword.Text = "👀" ' Show the password (Visible Emoji)
        Else
            txtPassword.UseSystemPasswordChar = True
            btnTogglePassword.Text = "🙈" ' Hide the password (Hidden Emoji)
        End If
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Validation
        If String.IsNullOrWhiteSpace(email) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both email and password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using con As New SqlConnection(connectionString)
                con.Open()
                Dim query As String = "SELECT ID, Name, Role FROM Users WHERE Email=@Email AND Password=@Password"

                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Password", password)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            LoggedInUserID = Convert.ToInt32(reader("ID"))
                            Dim userName As String = reader("Name").ToString()
                            Dim role As String = reader("Role").ToString()

                            ' Welcome message with the user's name
                            If role = "Admin" Then
                                MessageBox.Show($"Welcome, {userName} (Admin)!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Dim adminForm As New AdminDashboard()
                                adminForm.Show()
                            Else
                                MessageBox.Show($"Welcome, {userName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

Imports Microsoft.Data.SqlClient

Public Class RegisterForm
    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True "
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim name = txtName.Text
        Dim email = txtEmail.Text
        Dim password = txtPassword.Text
        Dim confirmPassword = txtConfirmPassword.Text

        ' Validate input
        If String.IsNullOrWhiteSpace(name) Or String.IsNullOrWhiteSpace(email) Or String.IsNullOrWhiteSpace(password) Or String.IsNullOrWhiteSpace(confirmPassword) Then
            MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Check if passwords match
        If password <> confirmPassword Then
            MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Open connection to database
        Using con As New SqlConnection(connectionString)
            con.Open

            ' Check if the email already exists
            Dim checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email"
            Using checkEmailCmd As New SqlCommand(checkEmailQuery, con)
                checkEmailCmd.Parameters.AddWithValue("@Email", email)
                Dim emailExists = Convert.ToInt32(checkEmailCmd.ExecuteScalar)

                If emailExists > 0 Then
                    MessageBox.Show("Email already registered. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End Using

            ' Insert user data into Users table
            Dim insertQuery = "INSERT INTO Users (Name, Email, Password, Role) VALUES (@Name, @Email, @Password, @Role)"
            Using cmd As New SqlCommand(insertQuery, con)
                cmd.Parameters.AddWithValue("@Name", name)
                cmd.Parameters.AddWithValue("@Email", email)
                cmd.Parameters.AddWithValue("@Password", password) ' Directly store the password
                cmd.Parameters.AddWithValue("@Role", "User") ' Default role is 'User'

                Try
                    cmd.ExecuteNonQuery
                    MessageBox.Show("Registration Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Hide()
                    loginform.Show()

                Catch ex As Exception
                    MessageBox.Show("Error registering user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub


End Class
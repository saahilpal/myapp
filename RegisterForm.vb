Imports Microsoft.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class RegisterForm
    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"

    ' Form Load Event - Set password visibility to 'off' (hidden) by default
    Private Sub RegisterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set both password fields to hidden (invisible)
        txtPassword.UseSystemPasswordChar = True
        txtConfirmPassword.UseSystemPasswordChar = True
        ' Update the toggle button text to "🙈"
        btnTogglePassword.Text = "🙈"
    End Sub

    ' Register Button Click
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim name As String = txtName.Text.Trim()
        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text
        Dim confirmPassword As String = txtConfirmPassword.Text

        ' Input validation
        If String.IsNullOrWhiteSpace(name) OrElse
           String.IsNullOrWhiteSpace(email) OrElse
           String.IsNullOrWhiteSpace(password) OrElse
           String.IsNullOrWhiteSpace(confirmPassword) Then
            MessageBox.Show("Please fill in all the fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate name (only alphabets and spaces allowed)
        If Not Regex.IsMatch(name, "^[A-Za-z\s]+$") Then
            MessageBox.Show("Name should only contain alphabets.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate email format (must contain @ and .com)
        If Not Regex.IsMatch(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$") OrElse Not email.EndsWith(".com") Then
            MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate password strength (min 6 characters, at least one upper case, one lower case, one special char)
        If password.Length < 6 OrElse
           Not Regex.IsMatch(password, "[A-Z]") OrElse
           Not Regex.IsMatch(password, "[a-z]") OrElse
           Not Regex.IsMatch(password, "[^a-zA-Z0-9]") Then
            MessageBox.Show("Password must be at least 6 characters long, with one upper case, one lower case, and one special character.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Password match check
        If password <> confirmPassword Then
            MessageBox.Show("Passwords do not match. Please re-enter.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Database operations
        Try
            Using con As New SqlConnection(connectionString)
                con.Open()

                ' Check for existing email
                Dim emailCheckQuery As String = "SELECT COUNT(*) FROM Users WHERE Email = @Email"
                Using emailCmd As New SqlCommand(emailCheckQuery, con)
                    emailCmd.Parameters.AddWithValue("@Email", email)
                    Dim exists As Integer = Convert.ToInt32(emailCmd.ExecuteScalar())

                    If exists > 0 Then
                        MessageBox.Show("This email is already registered. Please use a different one.", "Duplicate Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' Insert new user
                Dim insertQuery As String = "INSERT INTO Users (Name, Email, Password, Role) VALUES (@Name, @Email, @Password, @Role)"
                Using cmd As New SqlCommand(insertQuery, con)
                    cmd.Parameters.AddWithValue("@Name", name)
                    cmd.Parameters.AddWithValue("@Email", email)
                    cmd.Parameters.AddWithValue("@Password", password) ' Consider hashing in future
                    cmd.Parameters.AddWithValue("@Role", "User")

                    cmd.ExecuteNonQuery()

                    ' Friendly welcome message
                    MessageBox.Show($"Welcome, {name}!" & vbCrLf & "Your account has been created successfully.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Clear the form fields
                    txtName.Clear()
                    txtEmail.Clear()
                    txtPassword.Clear()
                    txtConfirmPassword.Clear()

                    ' Redirect to login
                    Me.Hide()
                    loginform.Show()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while registering: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Back Button to go back to the login page
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        loginform.Show()
    End Sub

    ' Single Button to toggle visibility of both Password and Confirm Password
    Private Sub btnTogglePassword_Click(sender As Object, e As EventArgs) Handles btnTogglePassword.Click
        If txtPassword.UseSystemPasswordChar AndAlso txtConfirmPassword.UseSystemPasswordChar Then
            ' Show the password in both fields
            txtPassword.UseSystemPasswordChar = False
            txtConfirmPassword.UseSystemPasswordChar = False
            btnTogglePassword.Text = "👀" ' Show the password (Visible Emoji)
        Else
            ' Hide the password in both fields
            txtPassword.UseSystemPasswordChar = True
            txtConfirmPassword.UseSystemPasswordChar = True
            btnTogglePassword.Text = "🙈" ' Hide the password (Hidden Emoji)
        End If
    End Sub
End Class

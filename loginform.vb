Imports Microsoft.Data.SqlClient

Public Class loginform
    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True "
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click


        Dim email As String = txtEmail.Text
        Dim password As String = txtPassword.Text


        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT ID, Role FROM Users WHERE Email=@Email AND Password=@Password"

            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Email", email)
                cmd.Parameters.AddWithValue("@Password", password)
                Dim reader As SqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    LoggedInUserID = reader("ID") ' Store UserID globally
                    Dim role As String = reader("Role").ToString()

                    MessageBox.Show("Login Successful! Role: " & role, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    If role = "Admin" Then
                        MessageBox.Show("Opening Admin Dashboard...")
                        Dim adminForm As New AdminDashboard()
                        adminForm.Show()
                    Else
                        Dim dashboard As New UserDashboard(LoggedInUserID)
                        dashboard.Show()
                    End If

                    Me.Hide()
                Else
                    MessageBox.Show("Invalid email or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                reader.Close() ' ✅ Close the reader after use

            End Using
        End Using
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        RegisterForm.Show()
        Me.Hide()
    End Sub


End Class

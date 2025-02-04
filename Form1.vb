Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient

Public Class Form1
    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True "
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Dim txtEmail As New TextBox()
        Dim txtPassword As New TextBox()

        Dim email As String = txtEmail.Text
        Dim password As String = txtPassword.Text


        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "SELECT Role FROM Users WHERE Email=@Email AND PasswordHash=@Password"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@Email", email)
                cmd.Parameters.AddWithValue("@Password", password)
                Dim role As Object = cmd.ExecuteScalar()
                If role IsNot Nothing Then
                    MessageBox.Show("Login Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If role.ToString() = "Admin" Then
                        AdminDashboard.Show()
                    Else
                        UserDashboard.Show()
                    End If
                    Me.Hide()
                Else
                    MessageBox.Show("Invalid email or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End Using
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        RegisterForm.Show()
        Me.Hide()
    End Sub
End Class

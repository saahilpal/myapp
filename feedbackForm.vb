Imports System.Data.SqlClient
Imports Guna.UI2.WinForms
Imports Microsoft.Data.SqlClient

Public Class feedbackForm

    Dim connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"



    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        ' Validate that a rating is selected
        If ratingStars.Value = 0 Then
            MessageBox.Show("Please select a rating before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Get user input
        Dim rating As Decimal = ratingStars.Value
        Dim comment As String = txtFeedback.Text.Trim()

        ' Assuming you have a global variable for logged-in user ID
        Dim userID As Integer = LoggedInUserID

        ' Insert feedback into the database
        Using con As New SqlConnection(connectionString)
            con.Open()
            Dim query As String = "INSERT INTO Feedback (UserID, Rating, Comment, CreatedAt) VALUES (@UserID, @Rating, @Comment, GETDATE())"
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@UserID", userID)
                cmd.Parameters.AddWithValue("@Rating", rating)
                cmd.Parameters.AddWithValue("@Comment", If(comment = "", DBNull.Value, comment))

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show("Thank you for your feedback!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtFeedback.Clear()
                    ratingStars.Value = 0 ' Reset rating
                Else
                    MessageBox.Show("Failed to submit feedback. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Using
        End Using
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim dashboard As New UserDashboard(LoggedInUserID)
        dashboard.Show()

        Me.Close()
    End Sub
    Private LoggedInUserID As Integer ' ✅ Store userID

    ' ✅ Default Constructor (Needed for Designer)
    Public Sub New()
        InitializeComponent()
    End Sub

    ' ✅ Overloaded Constructor (Accepts User ID)
    Public Sub New(userID As Integer)
        InitializeComponent()
        Me.LoggedInUserID = userID
    End Sub


End Class
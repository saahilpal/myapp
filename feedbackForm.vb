Imports Microsoft.Data.SqlClient

Public Class feedbackForm
    Private connectionString As String = "Data Source=DESKTOP-J1R63G7\SQLEXPRESS;Initial Catalog=test;Integrated Security=True;Trust Server Certificate=True"
    Private callerForm As Form
    Private LoggedInUserID As Integer

    ' Constructor with caller form and user ID
    Public Sub New(caller As Form, userID As Integer)
        InitializeComponent()
        Me.callerForm = caller
        Me.LoggedInUserID = userID
    End Sub

    ' Default constructor (for designer only)
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click, btnSubmit.Click
        If ratingStars.Value = 0 Then
            MessageBox.Show("Please select a rating before submitting.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim rating As Decimal = ratingStars.Value
        Dim comment = txtFeedback.Text.Trim

        Try
            Using con As New SqlConnection(connectionString)
                con.Open
                Dim query = "INSERT INTO Feedback (UserID, Rating, Comment, CreatedAt) VALUES (@UserID, @Rating, @Comment, GETDATE())"
                Using cmd As New SqlCommand(query, con)
                    cmd.Parameters.AddWithValue("@UserID", LoggedInUserID)
                    cmd.Parameters.AddWithValue("@Rating", rating)
                    cmd.Parameters.AddWithValue("@Comment", If(comment = "", DBNull.Value, comment))

                    Dim result = cmd.ExecuteNonQuery

                    If result > 0 Then
                        MessageBox.Show(GetFeedbackResponse(rating), "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Auto-close and return to caller
                        If callerForm IsNot Nothing Then callerForm.Show
                        Close
                    Else
                        MessageBox.Show("Failed to submit feedback. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetFeedbackResponse(rating As Decimal) As String
        Select Case rating
            Case >= 4.5
                Return "Thank you for the excellent rating! We're glad you're enjoying the app."
            Case >= 3
                Return "Thanks for the feedback! We'll keep improving."
            Case Else
                Return "We're sorry to hear that. Your feedback helps us get better!"
        End Select
    End Function

    Private Sub btnBack_Click(sender As Object, e As EventArgs)
        If callerForm IsNot Nothing Then
            callerForm.Show
        End If
        Close
    End Sub
End Class

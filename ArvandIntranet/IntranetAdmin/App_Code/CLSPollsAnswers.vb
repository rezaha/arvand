Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSPollsAnswersItem
    Public Property UserId As Integer
    Public Property Questionas As New CLSPollsQuestionsItem
    Public Property AnswerInt As Integer
    Public Property AnswerDecription As String
    Public Property Remark As String
End Class

Public Class CLSPollsAnswers
    Public Function GetPolls(Optional ByVal FillerId As Integer = 0, Optional ByVal QuestionType As Integer = -1, Optional ByVal QuestionId As Integer = 0) As List(Of CLSPollsAnswersItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_POLLS_ANSWERS", cn) With {.CommandType = CommandType.StoredProcedure}
        If FillerId <> 0 Then
            cmd.Parameters.AddWithValue("@FILLER_ID", FillerId)
        End If
        If QuestionType <> -1 Then
            cmd.Parameters.AddWithValue("@QUESTION_TYPE", QuestionType)
        End If
        If QuestionId <> 0 Then
            cmd.Parameters.AddWithValue("@QUESTION_ID", QuestionId)
        End If
        Dim retlist As New List(Of CLSPollsAnswersItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSPollsAnswersItem()
                    item.AnswerDecription = reader("ANSWER_DESCRIPTION").ToString()
                    item.AnswerInt = reader("ANSWER_INT").ToString()
                    item.Questionas.QuestionId = reader("QUESTION_ID").ToString()
                    item.Questionas.QuestionNo = reader("QUESTION_NO").ToString()
                    item.Questionas.QuestionDescription = reader("QUESTION_DESCRIPTION").ToString()
                    item.Remark = reader("REMARK").ToString()
                    item.UserId = reader("FILLER_ID").ToString()
                    retlist.Add(item)
                Loop
            End If
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return retlist
    End Function

    Public Function GetPoll(ByVal UserId As Integer, ByVal QuestionId As Integer) As CLSPollsAnswersItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_POLLS_ANSWERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@FILLER_ID", UserId)
        cmd.Parameters.AddWithValue("@QUESTION_ID", QuestionId)
        Dim item As New CLSPollsAnswersItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.AnswerDecription = reader("ANSWER_DESCRIPTION").ToString()
                    item.AnswerInt = reader("ANSWER_INT").ToString()
                    item.Questionas.QuestionId = reader("QUESTION_ID").ToString()
                    item.Questionas.QuestionNo = reader("QUESTION_NO").ToString()
                    item.Questionas.QuestionDescription = reader("QUESTION_DESCRIPTION").ToString()
                    item.Remark = reader("REMARK").ToString()
                    item.UserId = reader("FILLER_ID").ToString()
                Loop
            End If
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return item
    End Function

    Public Function Insert(ByVal item As CLSPollsAnswersItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_POLLS_ANSWERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@USER_ID", item.UserId)
        cmd.Parameters.AddWithValue("@QUESTION_ID", item.Questionas.QuestionId)
        cmd.Parameters.AddWithValue("@ANSWER_INT", item.AnswerInt)
        cmd.Parameters.AddWithValue("@ANSWER_DESCRIPTION", item.AnswerDecription)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function
    Public Function DeleteCOUNTRIES(ByVal UserId As Integer, ByVal QuestionId As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_POLLS_ANSWERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@USER_ID", UserId)
        cmd.Parameters.AddWithValue("@QUESTION_ID", QuestionId)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function
    Public Function UpdateCOUNTRIES(ByVal item As CLSPollsAnswersItem, ByVal UserId As Integer, ByVal QuestionId As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_POLLS_ANSWERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@USER_ID", item.UserId)
        cmd.Parameters.AddWithValue("@QUESTION_ID", item.Questionas.QuestionId)
        cmd.Parameters.AddWithValue("@ANSWER_INT", item.AnswerInt)
        cmd.Parameters.AddWithValue("@ANSWER_DESCRIPTION", item.AnswerDecription)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)
        cmd.Parameters.AddWithValue("@OLD_USER_ID", UserId)
        cmd.Parameters.AddWithValue("@OLD_QUESTION_ID", QuestionId)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function
End Class

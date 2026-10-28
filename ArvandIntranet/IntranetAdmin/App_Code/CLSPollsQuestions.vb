Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSPollsQuestionsItem
    Public Property Poll As New CLSpollsItem
    Public Property QuestionId As Integer
    Public Property QuestionNo As Integer
    Public Property QuestionDescription As String
    Public Property AnswerType As Integer
    Public Property AnswerCount As Nullable(Of Integer)
    Public Property QuestionWeight As Integer
    Public Property Remark As String
End Class

Public Class CLSPollsQuestions
    Public Function GetPollsQuestions(Optional ByVal AnswerType As Integer = 0, Optional ByVal PolId As Integer = 0) As List(Of CLSPollsQuestionsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_POLLS_QUESTION", cn) With {.CommandType = CommandType.StoredProcedure}
        If AnswerType <> 0 Then
            cmd.Parameters.AddWithValue("@AnswerType", AnswerType)
        End If

        If PolId <> 0 Then
            cmd.Parameters.AddWithValue("@POLL_ID", PolId)
        End If
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSPollsQuestionsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSPollsQuestionsItem()
                    item.AnswerType = reader("ANSWER_TYPE").ToString()
                    item.AnswerCount = IIf(reader("ANSWER_COUNT").ToString() = "", Nothing, reader("ANSWER_COUNT"))
                    item.Poll.PollId = reader("POLL_ID").ToString()
                    item.Poll.PollName = reader("POLL_NAME").ToString()
                    item.Poll.PollNo = reader("POLL_NO").ToString()
                    item.QuestionDescription = reader("QUESTION_DESCRIPTION").ToString()
                    item.QuestionId = reader("QUESTION_ID").ToString()
                    item.QuestionNo = reader("QUESTION_NO").ToString()
                    item.QuestionWeight = reader("QUESTION_WEIGHT").ToString()
                    item.Remark = reader("REMARK").ToString()
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

    Public Function GetPollsQuestion(ByVal PollId As Integer) As CLSPollsQuestionsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_POLLS_QUESTION", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@QUESTION_ID", PollId)
        Dim item As New CLSPollsQuestionsItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.AnswerType = reader("ANSWER_TYPE").ToString()
                    item.AnswerCount = IIf(reader("ANSWER_COUNT").ToString() = "", Nothing, reader("ANSWER_COUNT"))
                    item.Poll.PollId = reader("POLL_ID").ToString()
                    item.Poll.PollName = reader("POLL_NAME").ToString()
                    item.Poll.PollNo = reader("POLL_NO").ToString()
                    item.QuestionDescription = reader("QUESTION_DESCRIPTION").ToString()
                    item.QuestionId = reader("QUESTION_ID").ToString()
                    item.QuestionNo = reader("QUESTION_NO").ToString()
                    item.QuestionWeight = reader("QUESTION_WEIGHT").ToString()
                    item.Remark = reader("REMARK").ToString()
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

    Public Function Insert(ByVal item As CLSPollsQuestionsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_POLLS_QUESTION", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@POLL_ID", item.Poll.PollId)
        cmd.Parameters.AddWithValue("@QUESTION_NO", item.QuestionNo)
        cmd.Parameters.AddWithValue("@QUESTION_DESCRIPTION", item.QuestionDescription)
        cmd.Parameters.AddWithValue("@ANSWER_TYPE", item.AnswerType)
        cmd.Parameters.AddWithValue("@ANSWER_COUNT", IIf(item.AnswerCount Is Nothing, DBNull.Value, item.AnswerCount))
        cmd.Parameters.AddWithValue("@QUESTION_WEIGHT", item.QuestionWeight)
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
    Public Function Delete(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_POLLS_QUESTION", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@QUESTION_ID", item)
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
    Public Function Update(ByVal item As CLSPollsQuestionsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_POLLS_QUESTION", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@QUESTION_ID", item.QuestionId)
        cmd.Parameters.AddWithValue("@POLL_ID", item.Poll.PollId)
        cmd.Parameters.AddWithValue("@QUESTION_NO", item.QuestionNo)
        cmd.Parameters.AddWithValue("@QUESTION_DESCRIPTION", item.QuestionDescription)
        cmd.Parameters.AddWithValue("@ANSWER_TYPE", item.AnswerType)
        cmd.Parameters.AddWithValue("@ANSWER_COUNT", IIf(item.AnswerCount Is Nothing, DBNull.Value, item.AnswerCount))
        cmd.Parameters.AddWithValue("@QUESTION_WEIGHT", item.QuestionWeight)
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
End Class

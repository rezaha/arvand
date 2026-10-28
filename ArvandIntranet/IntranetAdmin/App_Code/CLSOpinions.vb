Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSOpinionsItem
    Public Property OpinionId As Integer
    Public Property PartType As String
    Public Property PartId As Integer
    Public Property OpinionDate As String
    Public Property OpinionTime As String
    Public Property OpinionName As String
    Public Property OpinionCompany As String
    Public Property OpinionTell As String
    Public Property OpinionEmail As String
    Public Property OpinionSubject As String
    Public Property OpinionContent As String
    Public Property OpinionReviever As Nullable(Of Integer)
    Public Property OpinionSend As Boolean
    Public Property AdminRead As Boolean
    Public Property AdminApprove As Boolean
    Public Property AdminDelete As Boolean
    Public Property Remark As String
End Class

Public Class CLSOpinions

    Public Function GetOpinions(Optional ByVal PartType As String = "", Optional ByVal PartId As Integer = 0) As List(Of CLSOpinionsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_OPINIONS", cn) With {.CommandType = CommandType.StoredProcedure}
        If PartType <> "" Then
            cmd.Parameters.AddWithValue("@PART_TYPE", PartType)
        End If
        If PartId <> 0 Then
            cmd.Parameters.AddWithValue("@PART_ID", PartId)
        End If
        Dim retlist As New List(Of CLSOpinionsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSOpinionsItem()
                    item.AdminApprove = Boolean.Parse(reader("ADMIN_APPROVE").ToString())
                    item.AdminDelete = Boolean.Parse(reader("ADMIN_DELETE").ToString())
                    item.AdminRead = Boolean.Parse(reader("ADMIN_READ").ToString())
                    item.OpinionContent = reader("OPINION_CONTENT").ToString()
                    item.OpinionDate = reader("OPINION_DATE").ToString()
                    item.OpinionEmail = reader("OPINION_EMAIL").ToString()
                    item.OpinionId = Int32.Parse(reader("OPINION_ID").ToString())
                    item.OpinionName = reader("OPINION_NAME").ToString()
                    item.OpinionSend = Boolean.Parse(reader("OPINION_SEND").ToString())
                    item.OpinionSubject = reader("OPINION_SUBJECT").ToString()
                    item.OpinionTime = reader("OPINION_TIME").ToString()
                    item.PartId = Int32.Parse(reader("PART_ID").ToString())
                    item.OpinionCompany = reader("OPINION_COMPANY").ToString()
                    item.OpinionTell = reader("OPINION_TEL").ToString()
                    item.OpinionReviever = IIf(reader("OPINION_RECIEVER").ToString() <> "", reader("OPINION_RECIEVER").ToString(), Nothing)
                    item.PartType = reader("PART_TYPE").ToString()
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

    Public Function GetOpinion(ByVal OpinionId As Integer) As CLSOpinionsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_OPINIONS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@OpinionId", OpinionId)
        Dim retField As New CLSOpinionsItem
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                retField.AdminApprove = Boolean.Parse(reader("ADMIN_APPROVE").ToString())
                retField.AdminDelete = Boolean.Parse(reader("ADMIN_DELETE").ToString())
                retField.AdminRead = Boolean.Parse(reader("ADMIN_READ").ToString())
                retField.OpinionContent = reader("OPINION_CONTENT").ToString()
                retField.OpinionDate = reader("OPINION_DATE").ToString()
                retField.OpinionEmail = reader("OPINION_EMAIL").ToString()
                retField.OpinionId = Int32.Parse(reader("OPINION_ID").ToString())
                retField.OpinionName = reader("OPINION_NAME").ToString()
                retField.OpinionSend = Boolean.Parse(reader("OPINION_SEND").ToString())
                retField.OpinionSubject = reader("OPINION_SUBJECT").ToString()
                retField.OpinionTime = reader("OPINION_TIME").ToString()
                retField.OpinionCompany = reader("OPINION_COMPANY").ToString()
                retField.OpinionTell = reader("OPINION_TEL").ToString()
                retField.OpinionReviever = IIf(reader("OPINION_RECIEVER").ToString() <> "", reader("OPINION_RECIEVER").ToString(), Nothing)
                retField.PartId = Int32.Parse(reader("PART_ID").ToString())
                retField.PartType = reader("PART_TYPE").ToString()
                retField.Remark = reader("REMARK").ToString()
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
        Return retField
    End Function


    Public Function InsertOpinions(ByVal item As CLSOpinionsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_OPINIONS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@PART_TYPE", item.PartType)
        cmd.Parameters.AddWithValue("@PART_ID", item.PartId)
        cmd.Parameters.AddWithValue("@OPINION_DATE", item.OpinionDate)
        cmd.Parameters.AddWithValue("@OPINION_TIME", item.OpinionTime)
        cmd.Parameters.AddWithValue("@OPINION_NAME", item.OpinionName)
        cmd.Parameters.AddWithValue("@OPINION_COMPANY", item.OpinionCompany)
        cmd.Parameters.AddWithValue("@OPINION_TEL", item.OpinionTell)
        cmd.Parameters.AddWithValue("@OPINION_EMAIL", item.OpinionEmail)
        cmd.Parameters.AddWithValue("@OPINION_SUBJECT", item.OpinionSubject)
        cmd.Parameters.AddWithValue("@OPINION_CONTENT", item.OpinionContent)
        cmd.Parameters.AddWithValue("@OPINION_RECIEVER", IIf(item.OpinionReviever Is Nothing, DBNull.Value, item.OpinionReviever))
        cmd.Parameters.AddWithValue("@OPINION_SEND", item.OpinionSend)
        cmd.Parameters.AddWithValue("@ADMIN_READ", item.AdminRead)
        cmd.Parameters.AddWithValue("@ADMIN_APPROVE", item.AdminApprove)
        cmd.Parameters.AddWithValue("@ADMIN_DELETE", item.AdminDelete)
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
    Public Function DeleteOpinions(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_OPINIONS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@OpinionId", item)
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
    Public Function UpdateOpinions(ByVal item As CLSOpinionsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_OPINIONS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@OPINION_ID", item.OpinionId)
        cmd.Parameters.AddWithValue("@PART_TYPE", item.PartType)
        cmd.Parameters.AddWithValue("@PART_ID", item.PartId)
        cmd.Parameters.AddWithValue("@OPINION_DATE", item.OpinionDate)
        cmd.Parameters.AddWithValue("@OPINION_TIME", item.OpinionDate)
        cmd.Parameters.AddWithValue("@OPINION_NAME", item.OpinionName)
        cmd.Parameters.AddWithValue("@OPINION_COMPANY", item.OpinionCompany)
        cmd.Parameters.AddWithValue("@OPINION_TEL", item.OpinionTell)
        cmd.Parameters.AddWithValue("@OPINION_EMAIL", item.OpinionEmail)
        cmd.Parameters.AddWithValue("@OPINION_SUBJECT", item.OpinionSubject)
        cmd.Parameters.AddWithValue("@OPINION_CONTENT", item.OpinionContent)
        cmd.Parameters.AddWithValue("@OPINION_RECIEVER", IIf(item.OpinionReviever Is Nothing, DBNull.Value, item.OpinionReviever))
        cmd.Parameters.AddWithValue("@OPINION_SEND", item.OpinionSend)
        cmd.Parameters.AddWithValue("@ADMIN_READ", item.AdminRead)
        cmd.Parameters.AddWithValue("@ADMIN_APPROVE", item.AdminApprove)
        cmd.Parameters.AddWithValue("@ADMIN_DELETE", item.AdminDelete)
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

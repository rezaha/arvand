Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSPollsFillerItem
    Public Property Poll As New CLSpollsItem
    Public Property FillerId As Integer
    Public Property FillerNo As Integer
    Public Property FillerName As String
    Public Property FillerComoany As String
    Public Property FillerTell As String
    Public Property FillerEmail As String
    Public Property FillDate As String
    Public Property FillTime As String
    Public Property FillerIp As String
    Public Property Remark As String
End Class

Public Class CLSPollsFiller

    Public Function GetMaxId() As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("SELECT MAX(FILLER_ID)  FROM  POLLS_FILLER")
        cmd.Connection = con
        Dim dr As SqlDataReader = Nothing
        Dim maxValue As String = 0
        Try
            con.Open()
            maxValue = cmd.ExecuteScalar()
            If maxValue = String.Empty Then
                maxValue = 0
            End If
        Catch ex As Exception
        Finally
            If (con.State <> ConnectionState.Closed) Then
                con.Close()
            End If
        End Try
        Return maxValue
    End Function

    Public Function GetFillers() As List(Of CLSPollsFillerItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_POLLS_FILLER", cn) With {.CommandType = CommandType.StoredProcedure}

        Dim retlist As New List(Of CLSPollsFillerItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSPollsFillerItem()
                    item.FillerId = reader("FILLER_ID").ToString()
                    item.FillDate = reader("FILL_DATE").ToString()
                    item.FillerComoany = reader("FILLER_COMPANY").ToString()
                    item.FillerEmail = reader("FILLER_EMAIL").ToString()
                    item.FillerIp = reader("FILLER_IP").ToString()
                    item.FillerName = reader("FILLER_NAME").ToString()
                    item.FillerNo = reader("FILLER_NO").ToString()
                    item.FillerTell = reader("FILLER_TEL").ToString()
                    item.FillTime = reader("FILL_TIME").ToString()
                    item.Poll.PollId = reader("POLL_ID").ToString()
                    item.Poll.PollName = reader("POLL_NAME").ToString()
                    item.Poll.PollNo = reader("POLL_NO").ToString()
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

    Public Function GetFillers(ByVal FillerId As Integer) As CLSPollsFillerItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_POLLS_FILLER", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@FILLER_ID", FillerId)
        Dim retField As New CLSPollsFillerItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                retField.FillerId = reader("FILLER_ID").ToString()
                retField.FillDate = reader("FILL_DATE").ToString()
                retField.FillerComoany = reader("FILLER_COMPANY").ToString()
                retField.FillerEmail = reader("FILLER_EMAIL").ToString()
                retField.FillerIp = reader("FILLER_IP").ToString()
                retField.FillerName = reader("FILLER_NAME").ToString()
                retField.FillerNo = reader("FILLER_NO").ToString()
                retField.FillerTell = reader("FILLER_TEL").ToString()
                retField.FillTime = reader("FILL_TIME").ToString()
                retField.Poll.PollId = reader("POLL_ID").ToString()
                retField.Poll.PollName = reader("POLL_NAME").ToString()
                retField.Poll.PollNo = reader("POLL_NO").ToString()
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


    Public Function Insert(ByVal item As CLSPollsFillerItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_POLLS_FILLER", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@POLL_ID", item.Poll.PollId)
        cmd.Parameters.AddWithValue("@FILLER_NO", item.FillerNo)
        cmd.Parameters.AddWithValue("@FILLER_NAME", item.FillerName)
        cmd.Parameters.AddWithValue("@FILLER_COMPANY", item.FillerComoany)
        cmd.Parameters.AddWithValue("@FILLER_TEL", item.FillerTell)
        cmd.Parameters.AddWithValue("@FILLER_EMAIL", item.FillerEmail)
        cmd.Parameters.AddWithValue("@FILL_DATE", item.FillDate)
        cmd.Parameters.AddWithValue("@FILL_TIME", item.FillTime)
        cmd.Parameters.AddWithValue("@FILLER_IP", item.FillerIp)
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
        Dim cmd As New SqlCommand("DELETE_POLLS_FILLER", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@FILLER_ID", item)
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
    Public Function Update(ByVal item As CLSPollsFillerItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_POLLS_FILLER", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@FILLER_ID", item.FillerId)
        cmd.Parameters.AddWithValue("@POLL_ID", item.Poll.PollId)
        cmd.Parameters.AddWithValue("@FILLER_NO", item.FillerNo)
        cmd.Parameters.AddWithValue("@FILLER_NAME", item.FillerName)
        cmd.Parameters.AddWithValue("@FILLER_COMPANY", item.FillerComoany)
        cmd.Parameters.AddWithValue("@FILLER_TEL", item.FillerTell)
        cmd.Parameters.AddWithValue("@FILLER_EMAIL", item.FillerEmail)
        cmd.Parameters.AddWithValue("@FILL_DATE", item.FillDate)
        cmd.Parameters.AddWithValue("@FILL_TIME", item.FillTime)
        cmd.Parameters.AddWithValue("@FILLER_IP", item.FillerIp)
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
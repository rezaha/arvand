Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class CLSSecuritySubsystemsItem

    Public Property SubsystemId As Integer
    Public Property SubsystemName As String
    Public Property Remark As String

End Class

Public Class CLSSecuritySubsystems

    Public Function GetRecords() As List(Of CLSSecuritySubsystemsItem)
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_SECURITY_SUBSYSTEMS", con) With {.CommandType = CommandType.StoredProcedure}
        Dim retList As New List(Of CLSSecuritySubsystemsItem)
        Dim reader As SqlDataReader = Nothing
        Try
            con.Open()
            reader = cmd.ExecuteReader
            While reader.Read
                Dim feild As New CLSSecuritySubsystemsItem
                feild.SubsystemId = Convert.ToInt32(reader.Item("SUBSYSTEM_ID").ToString)
                feild.SubsystemName = reader.Item("SUBSYSTEM_NAME").ToString
                feild.Remark = reader.Item("REMARK").ToString
                retList.Add(feild)
            End While
        Catch ex As Exception
        Finally
            If (con.State <> ConnectionState.Closed) Then
                cmd.Dispose()
                con.Close()
            End If
        End Try
        Return retList
    End Function

    Public Function GetRecord(ByVal SubsystemId As Integer) As CLSSecuritySubsystemsItem
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_SECURITY_SUBSYSTEMS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@SUBSYSTEM_ID", SubsystemId)
        Dim Reader As SqlDataReader = Nothing
        Dim feild As New CLSSecuritySubsystemsItem
        Try
            con.Open()
            Reader = cmd.ExecuteReader
            If Reader.HasRows Then
                Reader.Read()
                feild.SubsystemId = Convert.ToInt32(Reader.Item("SUBSYSTEM_ID").ToString)
                feild.SubsystemName = Reader.Item("SUBSYSTEM_NAME").ToString
                feild.Remark = Reader.Item("REMARK").ToString
            End If
        Catch ex As Exception
        Finally
            If (con.State <> ConnectionState.Closed) Then
                cmd.Dispose()
                con.Close()
            End If
        End Try
        Return feild
    End Function

    Public Function Update(ByVal item As CLSSecuritySubsystemsItem) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_SECURITY_SUBSYSTEMS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@SUBSYSTEM_ID", item.SubsystemId)
        cmd.Parameters.AddWithValue("@SUBSYSTEM_NAME", item.SubsystemName)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)

        Dim rowEffect As Integer = 0

        Try
            con.Open()
            rowEffect = cmd.ExecuteNonQuery
        Catch ex As Exception
        Finally
            If (con.State <> ConnectionState.Closed) Then
                cmd.Dispose()
                con.Close()
            End If
        End Try
        Return rowEffect

    End Function

    Public Function Insert(ByVal item As CLSSecuritySubsystemsItem) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_SECURITY_SUBSYSTEMS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@SUBSYSTEM_NAME", item.SubsystemName)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)

        Dim rowEffect As Integer = 0

        Try
            con.Open()
            rowEffect = cmd.ExecuteNonQuery
        Catch ex As Exception

        Finally
            If (con.State <> ConnectionState.Closed) Then
                cmd.Dispose()
                con.Close()

            End If

        End Try
        Return rowEffect

    End Function

    Public Function Delete(ByVal id As Integer) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_SECURITY_SUBSYSTEMS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@SUBSYSTEM_ID", id)
        Dim rowEffect As Integer = 0

        Try
            con.Open()
            rowEffect = cmd.ExecuteNonQuery
        Catch ex As Exception

        Finally
            If (con.State <> ConnectionState.Closed) Then
                cmd.Dispose()
                con.Close()

            End If

        End Try

        Return rowEffect
    End Function

End Class

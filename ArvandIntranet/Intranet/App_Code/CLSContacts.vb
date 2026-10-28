Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSContectsItem
    Public Property Division As New CLSPlantDivisionsItem
    Public Property ContactId As Integer
    Public Property ContactType As Integer
    Public Property ContactName As String
    Public Property ContactEmail As String
    Public Property ContactSubject As String
    Public Property ContactText As String
    Public Property ContactDate As String
    Public Property ContactTime As String
    Public Property IsRead As Boolean
    Public Property IsDelete As Boolean
End Class

Public Class CLSContacts
    Public Function GetRecords(ByVal ContactType As Integer, ByVal StartDate As String, ByVal EndDate As String, Optional ByVal ContactId As Integer = 0) As List(Of CLSContectsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("SELECT_CONTACT_US", cn) With {.CommandType = CommandType.StoredProcedure}

        If ContactId <> 0 Then
            cmd.Parameters.AddWithValue("@CONTACT_ID", ContactId)
        End If
        cmd.Parameters.AddWithValue("@CONTACT_TYPE", ContactType)
        cmd.Parameters.AddWithValue("@SDATE", StartDate)
        cmd.Parameters.AddWithValue("@EDATE", EndDate)

        Dim retlist As New List(Of CLSContectsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSContectsItem()
                    item.ContactDate = reader("CONTACT_DATE").ToString()
                    item.ContactEmail = reader("CONTACT_EMAIL").ToString()
                    item.ContactId = reader("CONTACT_ID").ToString()
                    item.ContactName = reader("CONTACT_NAME").ToString()
                    item.ContactSubject = reader("CONTACT_SUBJECT").ToString()
                    item.ContactText = reader("CONTACT_TEXT").ToString()
                    item.ContactTime = reader("CONTACT_TIME").ToString()
                    item.ContactType = reader("CONTACT_TYPE").ToString()
                    item.Division.Division_id = reader("DIVISION_ID").ToString()
                    item.IsDelete = Convert.ToBoolean(reader("IS_DELETE").ToString())
                    item.IsRead = Convert.ToBoolean(reader("IS_READ").ToString())
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

    'Public Function GetRecord(ByVal ContactId As Integer) As CLSContectsItem
    '    Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
    '    Dim cmd As New SqlCommand("GET_CONTACTS", cn) With {.CommandType = CommandType.StoredProcedure}
    '    cmd.Parameters.AddWithValue("@CONTACT_ID", ContactId)
    '    Dim item As New CLSContectsItem
    '    Dim reader As SqlDataReader = Nothing
    '    Try
    '        cn.Open()
    '        reader = cmd.ExecuteReader()
    '        If reader.HasRows Then
    '            Dim row As Integer = 1
    '            reader.Read()
    '            item.Active = reader("ACTIVE").ToString()
    '            item.ContactAddress = reader("CONTACT_ADDRESS").ToString()
    '            item.ContactEmail = reader("CONTACT_EMAIL").ToString()
    '            item.ContactFax = reader("CONTACT_FAX").ToString()
    '            item.ContactId = reader("CONTACT_ID").ToString()
    '            item.ContactLocation = reader("CONTACT_LOCATION").ToString()
    '            item.ContactName = reader("CONTACT_NAME").ToString()
    '            item.ContactPosition = reader("CONTACT_POSITION").ToString()
    '            item.ContactWebSite = reader("CONTACT_WEBSITE").ToString()
    '            item.ContectNo = reader("CONTACT_NO").ToString()
    '            item.ContectTel1 = reader("CONTACT_TEL1").ToString()
    '            item.ContectTel2 = reader("CONTACT_TEL2").ToString()
    '            item.ContectTel3 = reader("CONTACT_TEL3").ToString()
    '            item.ContectTel4 = reader("CONTACT_TEL4").ToString()
    '            item.Division.Division_id = reader("DIVISION_ID").ToString()
    '            item.Division.Name_persian = reader("NAME_PERSIAN").ToString()
    '            item.Remark = reader("REMARK").ToString()
    '        End If
    '    Catch e1 As SqlException
    '        Throw
    '    Catch e2 As Exception
    '        Throw
    '    Finally
    '        If reader IsNot Nothing Then
    '            reader.Close()
    '        End If
    '        If cn.State <> ConnectionState.Closed Then
    '            cn.Close()
    '            cmd.Dispose()
    '        End If
    '    End Try
    '    Return item
    'End Function

    Public Function Insert(ByVal item As CLSContectsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_CONTACT_US", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@DIVISION_ID", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@CONTACT_TYPE", item.ContactType)
        cmd.Parameters.AddWithValue("@CONTACT_NAME", item.ContactName)
        cmd.Parameters.AddWithValue("@CONTACT_EMAIL", item.ContactEmail)
        cmd.Parameters.AddWithValue("@CONTACT_SUBJECT", item.ContactSubject)
        cmd.Parameters.AddWithValue("@CONTACT_TEXT", item.ContactText)
        cmd.Parameters.AddWithValue("@CONTACT_DATE", item.ContactDate)
        cmd.Parameters.AddWithValue("@CONTACT_TIME", item.ContactTime)
        cmd.Parameters.AddWithValue("@IS_READ", item.IsRead)
        cmd.Parameters.AddWithValue("@IS_DELETE", item.IsDelete)
      
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
    Public Function Delete(ByVal Id As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_CONTACT_US", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@CONTACT_ID", Id)
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

    'Public Function UpdatePROVINCES(ByVal item As CLSContectsItem) As Boolean
    '    Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
    '    Dim cmd As New SqlCommand("UPDATE_CONTACTS", cn) With {.CommandType = CommandType.StoredProcedure}
    '    cmd.Parameters.AddWithValue("@CONTACT_ID", item.ContactId)
    '    cmd.Parameters.AddWithValue("@DIVISION_ID", item.Division.Division_id)
    '    cmd.Parameters.AddWithValue("@CONTACT_NO", item.ContectNo)
    '    cmd.Parameters.AddWithValue("@CONTACT_NAME", item.ContactName)
    '    cmd.Parameters.AddWithValue("@CONTACT_POSITION", item.ContactPosition)
    '    cmd.Parameters.AddWithValue("@CONTACT_LOCATION", item.ContactLocation)
    '    cmd.Parameters.AddWithValue("@CONTACT_TEL1", item.ContectTel1)
    '    cmd.Parameters.AddWithValue("@CONTACT_TEL2", item.ContectTel2)
    '    cmd.Parameters.AddWithValue("@CONTACT_TEL3", item.ContectTel3)
    '    cmd.Parameters.AddWithValue("@CONTACT_TEL4", item.ContectTel4)
    '    cmd.Parameters.AddWithValue("@CONTACT_FAX", item.ContactFax)
    '    cmd.Parameters.AddWithValue("@CONTACT_EMAIL", item.ContactEmail)
    '    cmd.Parameters.AddWithValue("@CONTACT_WEBSITE", item.ContactWebSite)
    '    cmd.Parameters.AddWithValue("@CONTACT_ADDRESS", item.ContactAddress)
    '    cmd.Parameters.AddWithValue("@ACTIVE", item.Active)
    '    cmd.Parameters.AddWithValue("@REMARK", item.Remark)
    '    Dim rowEfect As Integer = 0
    '    Try
    '        cn.Open()
    '        rowEfect = cmd.ExecuteNonQuery()
    '    Catch e1 As SqlException
    '        Throw
    '    Catch e2 As Exception
    '        Throw
    '    Finally
    '        If cn.State <> ConnectionState.Closed Then
    '            cn.Close()
    '            cmd.Dispose()
    '        End If
    '    End Try
    '    Return rowEfect > 0
    'End Function
End Class

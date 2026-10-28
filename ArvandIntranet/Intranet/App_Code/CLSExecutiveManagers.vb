Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class CLSExecutiveManagersItem
    Public Property EX_ID As Integer
    Public Property PERSONName As String
    Public Property PersonLastName As String
    Public Property POSITION_NAME As String
    Public Property CERTIFICATE_NAME As String
    Public Property EXPRIENCE As String
    Public Property TEL_NO As String
    Public Property FAX_NO As String
    Public Property EMAIL As String
    Public Property ROW_NO As Integer
    Public Property COL_NO As Integer
    Public Property MANAGER_PICTURE As String
    Public Property ACTIVE As Boolean
    Public Property REMARK As String
End Class

Public Class CLSExecutiveManagers

    Public Function GetRecords(Optional ByVal EX_ID As Integer? = Nothing) As List(Of CLSExecutiveManagersItem)
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_EXECUTIVE_MANAGERS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@EX_ID", EX_ID)
        Dim retList As New List(Of CLSExecutiveManagersItem)
        Dim reader As SqlDataReader = Nothing
        Try
            con.Open()
            reader = cmd.ExecuteReader
            While reader.Read
                Dim feild As New CLSExecutiveManagersItem
                feild.EX_ID = reader.Item("EX_ID")
                feild.ACTIVE = reader.Item("ACTIVE").ToString
                feild.CERTIFICATE_NAME = reader.Item("CERTIFICATE_NAME").ToString
                feild.COL_NO = reader.Item("COL_NO").ToString
                feild.EMAIL = reader.Item("EMAIL").ToString
                feild.EXPRIENCE = reader.Item("EXPRIENCE").ToString
                feild.FAX_NO = reader.Item("FAX_NO").ToString
                feild.PERSONName = reader.Item("PERSON_NAME").ToString
                feild.PersonLastName = reader.Item("PERSON_LAST_NAME").ToString
                feild.POSITION_NAME = reader.Item("POSITION_NAME").ToString
                feild.REMARK = reader.Item("REMARK").ToString
                feild.ROW_NO = reader.Item("ROW_NO").ToString
                feild.TEL_NO = reader.Item("TEL_NO").ToString
                feild.MANAGER_PICTURE = reader("MANAGER_PICTURE").ToString
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

    Public Function GetRecord(Optional ByVal EX_ID As Integer? = Nothing) As CLSExecutiveManagersItem
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_EXECUTIVE_MANAGERS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@EX_ID", EX_ID)
        Dim Reader As SqlDataReader = Nothing
        Dim feild As New CLSExecutiveManagersItem
        Try
            con.Open()
            Reader = cmd.ExecuteReader
            If Reader.HasRows Then
                Reader.Read()
                feild.EX_ID = Reader.Item("EX_ID")
                feild.ACTIVE = Reader.Item("ACTIVE").ToString
                feild.CERTIFICATE_NAME = Reader.Item("CERTIFICATE_NAME").ToString
                feild.COL_NO = Reader.Item("COL_NO").ToString
                feild.EMAIL = Reader.Item("EMAIL").ToString
                feild.EXPRIENCE = Reader.Item("EXPRIENCE").ToString
                feild.FAX_NO = Reader.Item("FAX_NO").ToString
                feild.PERSONName = Reader.Item("PERSON_NAME").ToString
                feild.PersonLastName = Reader.Item("PERSON_LAST_NAME").ToString
                feild.POSITION_NAME = Reader.Item("POSITION_NAME").ToString
                feild.REMARK = Reader.Item("REMARK").ToString
                feild.ROW_NO = Reader.Item("ROW_NO").ToString
                feild.TEL_NO = Reader.Item("TEL_NO").ToString
                feild.MANAGER_PICTURE = Reader("MANAGER_PICTURE").ToString
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

    Public Function Update(ByVal item As CLSExecutiveManagersItem) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_EXECUTIVE_MANAGERS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@ACTIVE", item.ACTIVE)
        cmd.Parameters.AddWithValue("@CERTIFICATE_NAME", item.CERTIFICATE_NAME)
        cmd.Parameters.AddWithValue("@COL_NO", item.COL_NO)
        cmd.Parameters.AddWithValue("@EMAIL", item.EMAIL)
        cmd.Parameters.AddWithValue("@EXPRIENCE", item.EXPRIENCE)
        cmd.Parameters.AddWithValue("@FAX_NO", item.FAX_NO)
        cmd.Parameters.AddWithValue("@PERSON_NAME", item.PERSONName)
        cmd.Parameters.AddWithValue("@PERSON_LAST_NAME", item.PersonLastName)
        cmd.Parameters.AddWithValue("@EX_ID", item.EX_ID)
        cmd.Parameters.AddWithValue("@POSITION_NAME", item.POSITION_NAME)
        cmd.Parameters.AddWithValue("@ROW_NO", item.ROW_NO)
        cmd.Parameters.AddWithValue("@TEL_NO", item.TEL_NO)
        cmd.Parameters.AddWithValue("@REMARK", item.REMARK)
        cmd.Parameters.AddWithValue("@MANAGER_PICTURE", item.MANAGER_PICTURE)
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

    Public Function Insert(ByVal item As CLSExecutiveManagersItem) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_EXECUTIVE_MANAGERS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@ACTIVE", item.ACTIVE)
        cmd.Parameters.AddWithValue("@CERTIFICATE_NAME", item.CERTIFICATE_NAME)
        cmd.Parameters.AddWithValue("@COL_NO", item.COL_NO)
        cmd.Parameters.AddWithValue("@EMAIL", item.EMAIL)
        cmd.Parameters.AddWithValue("@EXPRIENCE", item.EXPRIENCE)
        cmd.Parameters.AddWithValue("@FAX_NO", item.FAX_NO)
        cmd.Parameters.AddWithValue("@PERSON_NAME", item.PERSONName)
        cmd.Parameters.AddWithValue("@PERSON_LAST_NAME", item.PersonLastName)
        cmd.Parameters.AddWithValue("@POSITION_NAME", item.POSITION_NAME)
        cmd.Parameters.AddWithValue("@ROW_NO", item.ROW_NO)
        cmd.Parameters.AddWithValue("@TEL_NO", item.TEL_NO)
        cmd.Parameters.AddWithValue("@REMARK", item.REMARK)
        cmd.Parameters.AddWithValue("@MANAGER_PICTURE", item.MANAGER_PICTURE)
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

    Public Function Delete(ByVal EX_ID As Integer) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_EXECUTIVE_MANAGERS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@EX_ID", EX_ID)

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

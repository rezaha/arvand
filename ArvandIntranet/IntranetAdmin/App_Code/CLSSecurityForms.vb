Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class CLSSecurityFormsItem

    Public Property FormPermission As Integer
    Public Property ListOrder As Integer
    Public Property Subsystem As CLSSecuritySubsystemsItem
    Public Property FormTag As String
    Public Property FormName As String
    Public Property FormTitle As String
    Public Property TabNo As Integer
    Public Property TabName As String
    Public Property TabTitle As String
    Public Property InsertRecord As Boolean
    Public Property DeleteRecord As Boolean
    Public Property UpdateRecord As Boolean
    Public Property SearchRecord As Boolean
    Public Property PrintRecord As Boolean
    Public Property ApproveAction As Boolean
    Public Property EtcAction As Boolean
    Public Property Etc2Action As Boolean

End Class

Public Class CLSSecurityForms

    Public Function GetRecords(Optional ByVal FormPermission As Integer? = Nothing) As List(Of CLSSecurityFormsItem)
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_SECURITY_FORMS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@FORM_PERMISSION", FormPermission)
        Dim retList As New List(Of CLSSecurityFormsItem)
        Dim reader As SqlDataReader = Nothing
        Try
            con.Open()
            reader = cmd.ExecuteReader
            While reader.Read
                Dim feild As New CLSSecurityFormsItem
                Dim Subsystem As New CLSSecuritySubsystemsItem
                feild.FormPermission = reader.Item("FORM_PERMISSION").ToString
                feild.ListOrder = reader.Item("LIST_ORDER").ToString

                Subsystem.SubsystemId = reader.Item("SUBSYSTEM_ID").ToString
                Subsystem.SubsystemName = reader.Item("SUBSYSTEM_NAME").ToString

                feild.Subsystem = Subsystem
                feild.FormTag = reader.Item("FORM_TAG").ToString
                feild.FormName = reader.Item("FORM_NAME").ToString
                feild.FormTitle = reader.Item("FORM_TITLE").ToString
                feild.TabNo = reader.Item("TAB_NO").ToString
                feild.TabName = reader.Item("TAB_NAME").ToString
                feild.TabTitle = reader.Item("TAB_TITLE").ToString
                feild.InsertRecord = reader.Item("INSERT_RECORD").ToString
                feild.DeleteRecord = reader.Item("DELETE_RECORD").ToString
                feild.UpdateRecord = reader.Item("UPDATE_RECORD").ToString
                feild.SearchRecord = reader.Item("SEARCH_RECORD").ToString
                feild.PrintRecord = reader.Item("PRINT_RECORD").ToString
                feild.ApproveAction = reader.Item("APPROVE_ACTION").ToString
                feild.EtcAction = reader.Item("ETC_ACTION").ToString
                feild.Etc2Action = reader.Item("ETC2_ACTION").ToString
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

    Public Function GetRecord(Optional ByVal FormPermission As Integer? = Nothing) As CLSSecurityFormsItem
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_SECURITY_FORMS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@FORM_PERMISSION", FormPermission)
        Dim feild As New CLSSecurityFormsItem
        Dim reader As SqlDataReader = Nothing
        Try
            con.Open()
            reader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()

                feild.FormPermission = reader.Item("FORM_PERMISSION").ToString
                feild.ListOrder = reader.Item("LIST_ORDER").ToString
                Dim Subsystem As New CLSSecuritySubsystemsItem
                Subsystem.SubsystemId = reader.Item("SUBSYSTEM_ID").ToString
                Subsystem.SubsystemName = reader.Item("SUBSYSTEM_NAME").ToString

                feild.Subsystem = Subsystem
                feild.FormTag = reader.Item("FORM_TAG").ToString
                feild.FormName = reader.Item("FORM_NAME").ToString
                feild.FormTitle = reader.Item("FORM_TITLE").ToString
                feild.TabNo = reader.Item("TAB_NO").ToString
                feild.TabName = reader.Item("TAB_NAME").ToString
                feild.TabTitle = reader.Item("TAB_TITLE").ToString
                feild.InsertRecord = reader.Item("INSERT_RECORD").ToString
                feild.DeleteRecord = reader.Item("DELETE_RECORD").ToString
                feild.UpdateRecord = reader.Item("UPDATE_RECORD").ToString
                feild.SearchRecord = reader.Item("SEARCH_RECORD").ToString
                feild.PrintRecord = reader.Item("PRINT_RECORD").ToString
                feild.ApproveAction = reader.Item("APPROVE_ACTION").ToString
                feild.EtcAction = reader.Item("ETC_ACTION").ToString
                feild.Etc2Action = reader.Item("ETC2_ACTION").ToString

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

    Public Function Insert(ByVal item As CLSSecurityFormsItem) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_SECURITY_FORMS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@LIST_ORDER", item.ListOrder)
        cmd.Parameters.AddWithValue("@SUBSYSTEM_ID", item.Subsystem.SubsystemId)
        cmd.Parameters.AddWithValue("@FORM_TAG", item.FormTag)
        cmd.Parameters.AddWithValue("@FORM_NAME", item.FormName)
        cmd.Parameters.AddWithValue("@FORM_TITLE", item.FormTitle)
        cmd.Parameters.AddWithValue("@TAB_NO", item.TabNo)
        cmd.Parameters.AddWithValue("@TAB_NAME", item.TabName)
        cmd.Parameters.AddWithValue("@TAB_TITLE", item.TabTitle)
        cmd.Parameters.AddWithValue("@INSERT_RECORD", item.InsertRecord)
        cmd.Parameters.AddWithValue("@DELETE_RECORD", item.DeleteRecord)
        cmd.Parameters.AddWithValue("@UPDATE_RECORD", item.UpdateRecord)
        cmd.Parameters.AddWithValue("@SEARCH_RECORD", item.SearchRecord)
        cmd.Parameters.AddWithValue("@PRINT_RECORD", item.PrintRecord)
        cmd.Parameters.AddWithValue("@APPROVE_ACTION", item.ApproveAction)
        cmd.Parameters.AddWithValue("@ETC_ACTION", item.EtcAction)
        cmd.Parameters.AddWithValue("@ETC2_ACTION", item.Etc2Action)


        Dim rowEffect As Integer = 0
        Dim isError As String = String.Empty

        Try
            con.Open()
            rowEffect = cmd.ExecuteNonQuery

        Catch ex As Exception
            isError = ex.Source.ToString
        Finally

            If (con.State <> ConnectionState.Closed) Then
                cmd.Dispose()
                con.Close()

            End If

        End Try

        Return rowEffect


    End Function

    Public Function Update(ByVal item As CLSSecurityFormsItem) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_SECURITY_FORMS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@FORM_PERMISSION", item.FormPermission)
        cmd.Parameters.AddWithValue("@LIST_ORDER", item.ListOrder)
        cmd.Parameters.AddWithValue("@SUBSYSTEM_ID", item.Subsystem.SubsystemId)
        cmd.Parameters.AddWithValue("@FORM_TAG", item.FormTag)
        cmd.Parameters.AddWithValue("@FORM_NAME", item.FormName)
        cmd.Parameters.AddWithValue("@FORM_TITLE", item.FormTitle)
        cmd.Parameters.AddWithValue("@TAB_NO", item.TabNo)
        cmd.Parameters.AddWithValue("@TAB_NAME", item.TabName)
        cmd.Parameters.AddWithValue("@TAB_TITLE", item.TabTitle)
        cmd.Parameters.AddWithValue("@INSERT_RECORD", item.InsertRecord)
        cmd.Parameters.AddWithValue("@DELETE_RECORD", item.DeleteRecord)
        cmd.Parameters.AddWithValue("@UPDATE_RECORD", item.UpdateRecord)
        cmd.Parameters.AddWithValue("@SEARCH_RECORD", item.SearchRecord)
        cmd.Parameters.AddWithValue("@PRINT_RECORD", item.PrintRecord)
        cmd.Parameters.AddWithValue("@APPROVE_ACTION", item.ApproveAction)
        cmd.Parameters.AddWithValue("@ETC_ACTION", item.EtcAction)
        cmd.Parameters.AddWithValue("@ETC2_ACTION", item.Etc2Action)


        Dim rowEffect As Integer = 0
        Dim isError As String = String.Empty

        Try
            con.Open()
            rowEffect = cmd.ExecuteNonQuery

        Catch ex As Exception
            isError = ex.Source.ToString
        Finally

            If (con.State <> ConnectionState.Closed) Then
                cmd.Dispose()
                con.Close()

            End If

        End Try

        Return rowEffect


    End Function

    Public Function Delete(ByVal FormPermision As Integer) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_SECURITY_FORMS", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@FORM_PERMISSION", FormPermision)

        Dim rowEffect As Integer = 0
        Dim isError As String = String.Empty

        Try
            con.Open()
            rowEffect = cmd.ExecuteNonQuery

        Catch ex As Exception
            isError = ex.Source.ToString
        Finally

            If (con.State <> ConnectionState.Closed) Then
                cmd.Dispose()
                con.Close()

            End If

        End Try

        Return rowEffect


    End Function

End Class

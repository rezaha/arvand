Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class CLSSecurityFormsGrantedItem

    Public Property SecurityUser As New CLSSecurityUsersItem
    Public Property FormPermission As New CLSSecurityFormsItem
    Public Property InsertRecord As Boolean
    Public Property DeleteRecord As Boolean
    Public Property UpdateRecord As Boolean
    Public Property SearchRecord As Boolean
    Public Property PrintRecord As Boolean
    Public Property ApproveAction As Boolean
    Public Property EtcAction As Boolean
    Public Property Etc2Action As Boolean

End Class

Public Class CLSSecurityFormsGranted

    Public Function GetRecords(Optional ByVal UserId As Integer? = Nothing, Optional ByVal FormId As Integer? = Nothing) As List(Of CLSSecurityFormsGrantedItem)
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_SECURITY_FORMS_GRANTED", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@USER_ID", UserId)
        cmd.Parameters.AddWithValue("@FORM_PERMISSION", FormId)
        Dim retList As New List(Of CLSSecurityFormsGrantedItem)
        Dim dr As SqlDataReader = Nothing
        Try
            con.Open()
            dr = cmd.ExecuteReader
            While dr.Read
                Dim feild As New CLSSecurityFormsGrantedItem

                Dim SecurityUser As New CLSSecurityUsersItem
                SecurityUser.User_id = dr.Item("USER_ID").ToString
                SecurityUser.User_name = dr.Item("USER_NAME").ToString
                feild.SecurityUser = SecurityUser

                Dim FormPermission As New CLSSecurityFormsItem
                FormPermission.FormPermission = dr.Item("FORM_PERMISSION").ToString
                FormPermission.FormTag = dr.Item("FORM_TAG").ToString
                FormPermission.FormName = dr.Item("FORM_NAME").ToString
                FormPermission.FormTitle = dr.Item("FORM_TITLE").ToString
                FormPermission.TabNo = dr.Item("TAB_NO").ToString
                FormPermission.TabName = dr.Item("TAB_NAME").ToString
                FormPermission.TabTitle = dr.Item("TAB_TITLE").ToString
                feild.FormPermission = FormPermission

                feild.InsertRecord = dr.Item("INSERT_RECORD").ToString
                feild.DeleteRecord = dr.Item("DELETE_RECORD").ToString
                feild.UpdateRecord = dr.Item("UPDATE_RECORD").ToString
                feild.SearchRecord = dr.Item("SEARCH_RECORD").ToString
                feild.PrintRecord = dr.Item("PRINT_RECORD").ToString
                feild.ApproveAction = dr.Item("APPROVE_ACTION").ToString
                feild.EtcAction = dr.Item("ETC_ACTION").ToString
                feild.Etc2Action = dr.Item("ETC2_ACTION").ToString
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

    Public Function GetRecord(Optional ByVal UserId As Integer? = Nothing, Optional ByVal FormPermission As Integer? = Nothing,
                                 Optional ByVal UserName As String = Nothing, Optional ByVal FormName As String = Nothing,
                                 Optional ByVal TabNo As String = Nothing) As CLSSecurityFormsGrantedItem
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_SECURITY_FORMS_GRANTED", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@USER_ID", UserId)
        cmd.Parameters.AddWithValue("@FORM_PERMISSION", FormPermission)
        'cmd.Parameters.AddWithValue("@USER_NAME", UserName.ToUpper)
        'cmd.Parameters.AddWithValue("@FORM_TAG", FormName.ToUpper)
        'cmd.Parameters.AddWithValue("@TAB_NO", TabNo)
        Dim feild As New CLSSecurityFormsGrantedItem
        Dim reader As SqlDataReader = Nothing
        Try
            con.Open()
            reader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                Dim SecurityUser As New CLSSecurityUsersItem
                SecurityUser.User_id = reader.Item("USER_ID").ToString
                SecurityUser.User_name = reader.Item("USER_NAME").ToString
                feild.SecurityUser = SecurityUser

                Dim FormPermissions As New CLSSecurityFormsItem
                FormPermissions.FormPermission = reader.Item("FORM_PERMISSION").ToString
                FormPermissions.FormTag = reader.Item("FORM_TAG").ToString
                FormPermissions.FormName = reader.Item("FORM_NAME").ToString
                FormPermissions.FormTitle = reader.Item("FORM_TITLE").ToString
                FormPermissions.TabNo = reader.Item("TAB_NO").ToString
                FormPermissions.TabName = reader.Item("TAB_NAME").ToString
                FormPermissions.TabTitle = reader.Item("TAB_TITLE").ToString
                feild.FormPermission = FormPermissions

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
            Dim SecurityUserObj As New CLSSecurityUsers
            Dim MyCls As CLSSecurityUsersItem = SecurityUserObj.GetRecord(UserId:=UserId)
            If MyCls.User_type Then
                feild.SecurityUser = MyCls
                feild.InsertRecord = True
                feild.DeleteRecord = True
                feild.UpdateRecord = True
                feild.SearchRecord = True
                feild.PrintRecord = True
                feild.ApproveAction = True
                feild.EtcAction = True
                feild.Etc2Action = True
            End If
        End Try


        Return feild

    End Function

    Public Function GetGrantes(Optional ByVal UserId As Integer? = Nothing, Optional ByVal FormPermission As Integer? = Nothing,
                                 Optional ByVal UserName As String = Nothing, Optional ByVal FormName As String = Nothing,
                                 Optional ByVal TabNo As String = Nothing) As CLSSecurityFormsGrantedItem
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_SECURITY_FORMS_GRANTED", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@USER_ID", UserId)
        cmd.Parameters.AddWithValue("@FORM_PERMISSION", FormPermission)
        cmd.Parameters.AddWithValue("@USER_NAME", UserName)
        cmd.Parameters.AddWithValue("@FORM_TAG", FormName)
        cmd.Parameters.AddWithValue("@TAB_NO", TabNo)
        Dim feild As New CLSSecurityFormsGrantedItem
        Dim reader As SqlDataReader = Nothing
        Try
            con.Open()
            reader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                Dim SecurityUser As New CLSSecurityUsersItem
                SecurityUser.User_id = reader.Item("USER_ID").ToString
                SecurityUser.User_name = reader.Item("USER_NAME").ToString
                feild.SecurityUser = SecurityUser

                Dim FormPermissions As New CLSSecurityFormsItem
                FormPermissions.FormPermission = reader.Item("FORM_PERMISSION").ToString
                FormPermissions.FormTag = reader.Item("FORM_TAG").ToString
                FormPermissions.FormName = reader.Item("FORM_NAME").ToString
                FormPermissions.FormTitle = reader.Item("FORM_TITLE").ToString
                FormPermissions.TabNo = reader.Item("TAB_NO").ToString
                FormPermissions.TabName = reader.Item("TAB_NAME").ToString
                FormPermissions.TabTitle = reader.Item("TAB_TITLE").ToString
                feild.FormPermission = FormPermissions

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

            Dim SecurityUserObj As New CLSSecurityUsers
            Dim MyCls As CLSSecurityUsersItem = SecurityUserObj.GetRecord(UserId:=UserId)
            If MyCls.User_type Then
                feild.SecurityUser = MyCls
                feild.InsertRecord = True
                feild.DeleteRecord = True
                feild.UpdateRecord = True
                feild.SearchRecord = True
                feild.PrintRecord = True
                feild.ApproveAction = True
                feild.EtcAction = True
                feild.Etc2Action = True
            End If
        End Try

        Return feild

    End Function

    Public Function Insert(ByVal item As CLSSecurityFormsGrantedItem) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_SECURITY_FORMS_GRANTED", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@USER_ID", item.SecurityUser.User_id)
        cmd.Parameters.AddWithValue("@FORM_PERMISSION", item.FormPermission.FormPermission)
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

    Public Function Update(ByVal item As CLSSecurityFormsGrantedItem, ByVal UserId As Integer, ByVal FormPermission As Integer) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_SECURITY_FORMS_GRANTED", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@USER_ID", item.SecurityUser.User_id)
        cmd.Parameters.AddWithValue("@FORM_PERMISSION", item.FormPermission.FormPermission)
        cmd.Parameters.AddWithValue("@INSERT_RECORD", item.InsertRecord)
        cmd.Parameters.AddWithValue("@DELETE_RECORD", item.DeleteRecord)
        cmd.Parameters.AddWithValue("@UPDATE_RECORD", item.UpdateRecord)
        cmd.Parameters.AddWithValue("@SEARCH_RECORD", item.SearchRecord)
        cmd.Parameters.AddWithValue("@PRINT_RECORD", item.PrintRecord)
        cmd.Parameters.AddWithValue("@APPROVE_ACTION", item.ApproveAction)
        cmd.Parameters.AddWithValue("@ETC_ACTION", item.EtcAction)
        cmd.Parameters.AddWithValue("@ETC2_ACTION", item.Etc2Action)
        cmd.Parameters.AddWithValue("@OldUSER_ID", UserId)
        cmd.Parameters.AddWithValue("@OldFORM_PERMISSION", FormPermission)

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

    Public Function Delete(ByVal UserId As Integer, ByVal FormPermision As Integer) As Integer
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_SECURITY_FORMS_GRANTED", con) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@USER_ID", UserId)
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

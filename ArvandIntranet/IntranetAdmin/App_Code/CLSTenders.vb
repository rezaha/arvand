Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSTendersItem
    Public Property Division() As New CLSPlantDivisionsItem
    Public Property Tender_id() As Integer
    Public Property Tender_type() As New CLSTendersTypesItem
    Public Property Tender_no() As String
    Public Property Tender_date() As String
    Public Property Tender_steps() As Integer
    Public Property Tender_title() As String
    Public Property Tender_content() As String
    Public Property Tender_group() As New CLSTendersGroupItem
    Public Property Show_date() As String
    Public Property Expire_date() As String
    Public Property Sell_from_date() As String
    Public Property Sell_to_date() As String
    Public Property Sell_price() As Integer
    Public Property Deliver_date() As String
    Public Property Pockets_opening_date() As String
    Public Property Pockets_opening_time() As String
    Public Property Pockets_opening_location() As String
    Public Property Pockets_opening_free() As Boolean
    Public Property Newspaper_print() As String
    Public Property Tender_file_link() As String
    Public Property Tender_file() As Byte()
    Public Property Insert_date() As String
    Public Property Insert_time() As String
    Public Property User_id() As Integer
    Public Property Active() As Boolean
    Public Property Remark() As String
End Class

Public Class CLSTenders
    Public Function GetTENDERS(Optional ByVal TopCount As Integer? = Nothing) As List(Of CLSTendersItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_TENDERS_TOP", cn) With {.CommandType = CommandType.StoredProcedure}
        If TopCount IsNot Nothing Then
            cmd.Parameters.AddWithValue("@TOP_COUNT", TopCount)
        End If
        Dim retlist As New List(Of CLSTendersItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSTendersItem()
                    item.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.Division.Name_persian = reader("NAME_PERSIAN").ToString()
                    item.Tender_id = Integer.Parse(reader("Tender_id").ToString())
                    item.Tender_type.TypeID = Integer.Parse(reader("TYPE_ID").ToString())
                    item.Tender_type.TypeName = reader("TYPE_NAME").ToString()
                    item.Tender_no = reader("Tender_no").ToString()
                    item.Tender_date = reader("Tender_date").ToString()
                    item.Tender_steps = Integer.Parse(reader("Tender_steps").ToString())
                    item.Tender_title = reader("Tender_title").ToString()
                    item.Tender_content = reader("Tender_content").ToString()
                    item.Tender_group.GroupID = Integer.Parse(reader("GROUP_ID").ToString())
                    item.Tender_group.GroupName = reader("GROUP_NAME").ToString()
                    item.Show_date = reader("Show_date").ToString()
                    item.Expire_date = reader("Expire_date").ToString()
                    item.Sell_from_date = reader("Sell_from_date").ToString()
                    item.Sell_to_date = reader("Sell_to_date").ToString()
                    item.Sell_price = Integer.Parse(reader("Sell_price").ToString())
                    item.Deliver_date = reader("Deliver_date").ToString()
                    item.Pockets_opening_date = reader("Pockets_opening_date").ToString()
                    item.Pockets_opening_time = reader("Pockets_opening_time").ToString()
                    item.Pockets_opening_location = reader("Pockets_opening_location").ToString()
                    item.Pockets_opening_free = Boolean.Parse(reader("Pockets_opening_free").ToString())
                    item.Newspaper_print = reader("Newspaper_print").ToString()
                    item.Tender_file_link = reader("Tender_file_link").ToString()
                    If reader("Tender_file").ToString() <> "" Then
                        item.Tender_file = reader("Tender_file")
                    Else
                        item.Tender_file = Nothing
                    End If
                    item.Insert_date = reader("Insert_date").ToString()
                    item.Insert_time = reader("Insert_time").ToString()
                    item.User_id = Integer.Parse(reader("User_id").ToString())
                    item.Active = Boolean.Parse(reader("Active").ToString())
                    item.Remark = reader("Remark").ToString()
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

    Public Function GetTENDER(ByVal id As Integer) As CLSTendersItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_TENDERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Tender_id", id)
        Dim item As New CLSTendersItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.Division.Name_persian = reader("NAME_PERSIAN").ToString()
                    item.Tender_id = Integer.Parse(reader("Tender_id").ToString())
                    item.Tender_type.TypeID = Integer.Parse(reader("TYPE_ID").ToString())
                    item.Tender_type.TypeName = reader("TYPE_NAME").ToString()
                    item.Tender_no = reader("Tender_no").ToString()
                    item.Tender_date = reader("Tender_date").ToString()
                    item.Tender_steps = Integer.Parse(reader("Tender_steps").ToString())
                    item.Tender_title = reader("Tender_title").ToString()
                    item.Tender_content = reader("Tender_content").ToString()
                    item.Tender_group.GroupID = Integer.Parse(reader("GROUP_ID").ToString())
                    item.Tender_group.GroupName = reader("GROUP_NAME").ToString()
                    item.Show_date = reader("Show_date").ToString()
                    item.Expire_date = reader("Expire_date").ToString()
                    item.Sell_from_date = reader("Sell_from_date").ToString()
                    item.Sell_to_date = reader("Sell_to_date").ToString()
                    item.Sell_price = Integer.Parse(reader("Sell_price").ToString())
                    item.Deliver_date = reader("Deliver_date").ToString()
                    item.Pockets_opening_date = reader("Pockets_opening_date").ToString()
                    item.Pockets_opening_time = reader("Pockets_opening_time").ToString()
                    item.Pockets_opening_location = reader("Pockets_opening_location").ToString()
                    item.Pockets_opening_free = Boolean.Parse(reader("Pockets_opening_free").ToString())
                    item.Newspaper_print = reader("Newspaper_print").ToString()
                    item.Tender_file_link = reader("Tender_file_link").ToString()
                    If reader("Tender_file").ToString() <> "" Then
                        item.Tender_file = reader("Tender_file")
                    Else
                        item.Tender_file = Nothing
                    End If
                    item.Insert_date = reader("Insert_date").ToString()
                    item.Insert_time = reader("Insert_time").ToString()
                    item.User_id = Integer.Parse(reader("User_id").ToString())
                    item.Active = Boolean.Parse(reader("Active").ToString())
                    item.Remark = reader("Remark").ToString()
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


    Public Function InsertTENDERS(ByVal item As CLSTendersItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_TENDERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@Tender_type", item.Tender_type.TypeID)
        cmd.Parameters.AddWithValue("@Tender_no", item.Tender_no)
        cmd.Parameters.AddWithValue("@Tender_date", item.Tender_date)
        cmd.Parameters.AddWithValue("@Tender_steps", item.Tender_steps)
        cmd.Parameters.AddWithValue("@Tender_title", item.Tender_title)
        cmd.Parameters.AddWithValue("@Tender_content", item.Tender_content)
        cmd.Parameters.AddWithValue("@Tender_group", item.Tender_group.GroupID)
        cmd.Parameters.AddWithValue("@Show_date", item.Show_date)
        cmd.Parameters.AddWithValue("@Expire_date", item.Expire_date)
        cmd.Parameters.AddWithValue("@Sell_from_date", item.Sell_from_date)
        cmd.Parameters.AddWithValue("@Sell_to_date", item.Sell_to_date)
        cmd.Parameters.AddWithValue("@Sell_price", item.Sell_price)
        cmd.Parameters.AddWithValue("@Deliver_date", item.Deliver_date)
        cmd.Parameters.AddWithValue("@Pockets_opening_date", item.Pockets_opening_date)
        cmd.Parameters.AddWithValue("@Pockets_opening_time", item.Pockets_opening_time)
        cmd.Parameters.AddWithValue("@Pockets_opening_location", item.Pockets_opening_location)
        cmd.Parameters.AddWithValue("@Pockets_opening_free", item.Pockets_opening_free)
        cmd.Parameters.AddWithValue("@Newspaper_print", item.Newspaper_print)
        cmd.Parameters.AddWithValue("@Tender_file_link", item.Tender_file_link)
        cmd.Parameters.AddWithValue("@Tender_file", item.Tender_file)
        cmd.Parameters.AddWithValue("@Insert_date", item.Insert_date)
        cmd.Parameters.AddWithValue("@Insert_time", item.Insert_time)
        cmd.Parameters.AddWithValue("@User_id", item.User_id)
        cmd.Parameters.AddWithValue("@Active", item.Active)
        cmd.Parameters.AddWithValue("@Remark", item.Remark)
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
    Public Function DeleteTENDERS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_TENDERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@TenderId", item)
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

    Public Function UpdateTENDERS(ByVal item As CLSTendersItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_TENDERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@Tender_id", item.Tender_id)
        cmd.Parameters.AddWithValue("@Tender_type", item.Tender_type.TypeID)
        cmd.Parameters.AddWithValue("@Tender_no", item.Tender_no)
        cmd.Parameters.AddWithValue("@Tender_date", item.Tender_date)
        cmd.Parameters.AddWithValue("@Tender_steps", item.Tender_steps)
        cmd.Parameters.AddWithValue("@Tender_title", item.Tender_title)
        cmd.Parameters.AddWithValue("@Tender_content", item.Tender_content)
        cmd.Parameters.AddWithValue("@Tender_group", item.Tender_group.GroupID)
        cmd.Parameters.AddWithValue("@Show_date", item.Show_date)
        cmd.Parameters.AddWithValue("@Expire_date", item.Expire_date)
        cmd.Parameters.AddWithValue("@Sell_from_date", item.Sell_from_date)
        cmd.Parameters.AddWithValue("@Sell_to_date", item.Sell_to_date)
        cmd.Parameters.AddWithValue("@Sell_price", item.Sell_price)
        cmd.Parameters.AddWithValue("@Deliver_date", item.Deliver_date)
        cmd.Parameters.AddWithValue("@Pockets_opening_date", item.Pockets_opening_date)
        cmd.Parameters.AddWithValue("@Pockets_opening_time", item.Pockets_opening_time)
        cmd.Parameters.AddWithValue("@Pockets_opening_location", item.Pockets_opening_location)
        cmd.Parameters.AddWithValue("@Pockets_opening_free", item.Pockets_opening_free)
        cmd.Parameters.AddWithValue("@Newspaper_print", item.Newspaper_print)
        cmd.Parameters.AddWithValue("@Tender_file_link", item.Tender_file_link)
        cmd.Parameters.AddWithValue("@Tender_file", item.Tender_file)
        cmd.Parameters.AddWithValue("@Insert_date", item.Insert_date)
        cmd.Parameters.AddWithValue("@Insert_time", item.Insert_time)
        cmd.Parameters.AddWithValue("@User_id", item.User_id)
        cmd.Parameters.AddWithValue("@Active", item.Active)
        cmd.Parameters.AddWithValue("@Remark", item.Remark)
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

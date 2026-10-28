Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSNewsItem
    Public Property Division As New CLSPlantDivisionsItem
    Public Property News_id As Integer
    Public Property News_no As Integer
    Public Property NewsUserFriendly As String
    Public Property News_group As New CLSNewsGroupsItem
    Public Property News_type As New CLSNewsTypesItem
    Public Property News_kind As New CLSNewsKindsItem
    Public Property Show_status As Integer
    Public Property Title_persian As String
    Public Property Title_latin As String
    Public Property Summary_persian As String
    Public Property Html_summary_persian As String
    Public Property Summary_latin As String
    Public Property Html_summary_latin As String
    Public Property Content_persian As String
    Public Property Html_content_persian As String
    Public Property Content_latin As String
    Public Property Html_content_latin As String
    Public Property News_date As String
    Public Property News_time As String
    Public Property News_order As Integer
    Public Property News_share As Boolean
    Public Property News_share_ok As Boolean
    Public Property Show_date As String
    Public Property Show_time As String
    Public Property Expire_date As String
    Public Property Expire_time As String
    Public Property Show_weekdays As String
    Public Property NewsLabels As String
    Public Property Insert_user As Integer
    Public Property Small_picture_link As String
    Public Property Large_picture_link As String
    Public Property News_delete As Boolean
    Public Property Active As Boolean
    Public Property Remark As String
End Class

Public Class CLSNews


    Public Function GetDayWord() As List(Of CLSNewsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_TOP_DAY_WORD", cn) With {.CommandType = CommandType.StoredProcedure}
       
        Dim retlist As New List(Of CLSNewsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSNewsItem()
                    item.Title_persian = reader("TITLE_PERSIAN").ToString()
                    item.Title_latin = reader("TITLE_LATIN").ToString()
                    item.Summary_persian = reader("SUMMARY_PERSIAN").ToString()
                    item.Html_summary_persian = reader("HTML_SUMMARY_PERSIAN").ToString()
                    item.Summary_latin = reader("SUMMARY_LATIN").ToString()
                    item.Html_summary_latin = reader("HTML_SUMMARY_LATIN").ToString()
                    item.Content_persian = reader("CONTENT_PERSIAN").ToString()
                    item.Html_content_persian = reader("HTML_CONTENT_PERSIAN").ToString()
                    item.Content_latin = reader("CONTENT_LATIN").ToString()
                    item.Html_content_latin = reader("HTML_CONTENT_LATIN").ToString()
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

    Public Function GetDayWord(ByVal divisionId As Integer) As List(Of CLSNewsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_TOP_DAY_WORD", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@DIVISION_ID", divisionId)
        Dim retlist As New List(Of CLSNewsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSNewsItem()
                    item.Title_persian = reader("TITLE_PERSIAN").ToString()
                    item.Title_latin = reader("TITLE_LATIN").ToString()
                    item.Summary_persian = reader("SUMMARY_PERSIAN").ToString()
                    item.Html_summary_persian = reader("HTML_SUMMARY_PERSIAN").ToString()
                    item.Summary_latin = reader("SUMMARY_LATIN").ToString()
                    item.Html_summary_latin = reader("HTML_SUMMARY_LATIN").ToString()
                    item.Content_persian = reader("CONTENT_PERSIAN").ToString()
                    item.Html_content_persian = reader("HTML_CONTENT_PERSIAN").ToString()
                    item.Content_latin = reader("CONTENT_LATIN").ToString()
                    item.Html_content_latin = reader("HTML_CONTENT_LATIN").ToString()
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


    Public Function GetNEWS(Optional ByVal NewsGroup As Integer = 0) As List(Of CLSNewsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_NEWS", cn) With {.CommandType = CommandType.StoredProcedure}
        If NewsGroup <> 0 Then
            cmd.Parameters.AddWithValue("NEWS_GROUP", NewsGroup)
        End If
        Dim retlist As New List(Of CLSNewsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSNewsItem()
                    item.Division.Company.Co_id = Integer.Parse(reader("CO_ID").ToString())
                    item.Division.Company.Name_persian = reader("NAME_PERSIAN").ToString()
                    item.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.Division.Name_persian = reader("DIVISION_NAME").ToString()
                    item.News_id = Integer.Parse(reader("News_id").ToString())
                    item.News_no = Integer.Parse(reader("News_no").ToString())
                    item.NewsUserFriendly = reader("NEWS_URLFRIENDLY")
                    item.News_group.Group_id = Integer.Parse(reader("GROUP_ID").ToString())
                    item.News_group.Name_persian = reader("GROUP_NAME").ToString()
                    item.News_type.Type_id = Integer.Parse(reader("TYPE_ID").ToString())
                    item.News_type.Name_persian = reader("TYPE_NAME").ToString()
                    item.News_kind.Kind_id = Integer.Parse(reader("KIND_ID").ToString())
                    item.News_kind.Name_persian = reader("KIND_NAME").ToString()
                    item.Show_status = Integer.Parse(reader("Show_status").ToString())
                    item.Title_persian = reader("Title_persian").ToString()
                    item.Title_latin = reader("Title_latin").ToString()
                    item.Summary_persian = reader("Summary_persian").ToString()
                    item.Html_summary_persian = reader("Html_summary_persian").ToString()
                    item.Summary_latin = reader("Summary_latin").ToString()
                    item.Html_summary_latin = reader("Html_summary_latin").ToString()
                    item.Content_persian = reader("Content_persian").ToString()
                    item.Html_content_persian = reader("Html_content_persian").ToString()
                    item.Content_latin = reader("Content_latin").ToString()
                    item.Html_content_latin = reader("Html_content_latin").ToString()
                    item.News_date = reader("News_date").ToString()
                    item.News_time = reader("News_time").ToString()
                    item.News_order = Integer.Parse(reader("News_order").ToString())
                    item.News_share = Boolean.Parse(reader("News_share").ToString())
                    item.News_share_ok = Boolean.Parse(reader("News_share_ok").ToString())
                    item.Show_date = reader("Show_date").ToString()
                    item.Show_time = reader("Show_time").ToString()
                    item.Expire_date = reader("Expire_date").ToString()
                    item.Expire_time = reader("Expire_time").ToString()
                    item.Show_weekdays = reader("Show_weekdays").ToString()
                    item.NewsLabels = reader("NEWS_LABELS").ToString()
                    item.Insert_user = Integer.Parse(reader("Insert_user").ToString())
                    item.Small_picture_link = reader("Small_picture_link").ToString()
                    item.Large_picture_link = reader("Large_picture_link").ToString()
                    item.News_delete = Boolean.Parse(reader("News_delete").ToString())
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

    Public Function GetNEWS(ByVal NewsGroup As Integer, ByVal divisionId As Integer) As List(Of CLSNewsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_NEWS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("NEWS_GROUP", NewsGroup)
        cmd.Parameters.AddWithValue("DivisionId", divisionId)
        Dim retlist As New List(Of CLSNewsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSNewsItem()
                    item.Division.Company.Co_id = Integer.Parse(reader("CO_ID").ToString())
                    item.Division.Company.Name_persian = reader("NAME_PERSIAN").ToString()
                    item.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.Division.Name_persian = reader("DIVISION_NAME").ToString()
                    item.News_id = Integer.Parse(reader("News_id").ToString())
                    item.News_no = Integer.Parse(reader("News_no").ToString())
                    item.NewsUserFriendly = reader("NEWS_URLFRIENDLY")
                    item.News_group.Group_id = Integer.Parse(reader("GROUP_ID").ToString())
                    item.News_group.Name_persian = reader("GROUP_NAME").ToString()
                    item.News_type.Type_id = Integer.Parse(reader("TYPE_ID").ToString())
                    item.News_type.Name_persian = reader("TYPE_NAME").ToString()
                    item.News_kind.Kind_id = Integer.Parse(reader("KIND_ID").ToString())
                    item.News_kind.Name_persian = reader("KIND_NAME").ToString()
                    item.Show_status = Integer.Parse(reader("Show_status").ToString())
                    item.Title_persian = reader("Title_persian").ToString()
                    item.Title_latin = reader("Title_latin").ToString()
                    item.Summary_persian = reader("Summary_persian").ToString()
                    item.Html_summary_persian = reader("Html_summary_persian").ToString()
                    item.Summary_latin = reader("Summary_latin").ToString()
                    item.Html_summary_latin = reader("Html_summary_latin").ToString()
                    item.Content_persian = reader("Content_persian").ToString()
                    item.Html_content_persian = reader("Html_content_persian").ToString()
                    item.Content_latin = reader("Content_latin").ToString()
                    item.Html_content_latin = reader("Html_content_latin").ToString()
                    item.News_date = reader("News_date").ToString()
                    item.News_time = reader("News_time").ToString()
                    item.News_order = Integer.Parse(reader("News_order").ToString())
                    item.News_share = Boolean.Parse(reader("News_share").ToString())
                    item.News_share_ok = Boolean.Parse(reader("News_share_ok").ToString())
                    item.Show_date = reader("Show_date").ToString()
                    item.Show_time = reader("Show_time").ToString()
                    item.Expire_date = reader("Expire_date").ToString()
                    item.Expire_time = reader("Expire_time").ToString()
                    item.Show_weekdays = reader("Show_weekdays").ToString()
                    item.NewsLabels = reader("NEWS_LABELS").ToString()
                    item.Insert_user = Integer.Parse(reader("Insert_user").ToString())
                    item.Small_picture_link = reader("Small_picture_link").ToString()
                    item.Large_picture_link = reader("Large_picture_link").ToString()
                    item.News_delete = Boolean.Parse(reader("News_delete").ToString())
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

    Public Function GetOneNEWS(Optional ByVal id As Integer = -1, Optional ByVal url As String = "") As CLSNewsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_NEWS", cn) With {.CommandType = CommandType.StoredProcedure}
        If id <> -1 Then
            cmd.Parameters.AddWithValue("@NewsId", id)
        End If
        If url <> "" Then
            cmd.Parameters.AddWithValue("@firndUrl", url)
        End If

        Dim item As New CLSNewsItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Division.Company.Co_id = Integer.Parse(reader("CO_ID").ToString())
                    item.Division.Company.Name_persian = reader("NAME_PERSIAN").ToString()
                    'item.Division.Plant.Plant_id = Integer.Parse(reader("PLANT_ID").ToString())
                    'item.Division.Plant.Name_persian = reader("PLANT_NAME").ToString()
                    item.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.Division.Name_persian = reader("DIVISION_NAME").ToString()
                    item.News_id = Integer.Parse(reader("News_id").ToString())
                    item.News_no = Integer.Parse(reader("News_no").ToString())
                    item.NewsUserFriendly = reader("NEWS_URLFRIENDLY")
                    item.News_group.Group_id = Integer.Parse(reader("GROUP_ID").ToString())
                    item.News_group.Name_persian = reader("GROUP_NAME").ToString()
                    item.News_type.Type_id = Integer.Parse(reader("TYPE_ID").ToString())
                    item.News_type.Name_persian = reader("TYPE_NAME").ToString()
                    item.News_kind.Kind_id = Integer.Parse(reader("KIND_ID").ToString())
                    item.News_kind.Name_persian = reader("KIND_NAME").ToString()
                    item.Show_status = Integer.Parse(reader("Show_status").ToString())
                    item.Title_persian = reader("Title_persian").ToString()
                    item.Title_latin = reader("Title_latin").ToString()
                    item.Summary_persian = reader("Summary_persian").ToString()
                    item.Html_summary_persian = reader("Html_summary_persian").ToString()
                    item.Summary_latin = reader("Summary_latin").ToString()
                    item.Html_summary_latin = reader("Html_summary_latin").ToString()
                    item.Content_persian = reader("Content_persian").ToString()
                    item.Html_content_persian = reader("Html_content_persian").ToString()
                    item.Content_latin = reader("Content_latin").ToString()
                    item.Html_content_latin = reader("Html_content_latin").ToString()
                    item.News_date = reader("News_date").ToString()
                    item.News_time = reader("News_time").ToString()
                    item.News_order = Integer.Parse(reader("News_order").ToString())
                    item.News_share = Boolean.Parse(reader("News_share").ToString())
                    item.News_share_ok = Boolean.Parse(reader("News_share_ok").ToString())
                    item.Show_date = reader("Show_date").ToString()
                    item.Show_time = reader("Show_time").ToString()
                    item.Expire_date = reader("Expire_date").ToString()
                    item.Expire_time = reader("Expire_time").ToString()
                    item.Show_weekdays = reader("Show_weekdays").ToString()
                    item.NewsLabels = reader("NEWS_LABELS").ToString()
                    item.Insert_user = Integer.Parse(reader("Insert_user").ToString())
                    item.Small_picture_link = reader("Small_picture_link").ToString()
                    item.Large_picture_link = reader("Large_picture_link").ToString()
                    item.News_delete = Boolean.Parse(reader("News_delete").ToString())
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

    Public Function GetNews(ByVal pageSize As Integer, ByVal PageNum As Integer, Optional ByVal ShowStatus As Integer? = Nothing) As List(Of CLSNewsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_NEWS_PAGING", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@pageSize", pageSize)
        cmd.Parameters.AddWithValue("@PageNum", PageNum)
        cmd.Parameters.AddWithValue("@ShowStatus", ShowStatus)

        Dim retlist As New List(Of CLSNewsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSNewsItem()
                    item.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.News_id = Integer.Parse(reader("News_id").ToString())
                    item.News_no = Integer.Parse(reader("News_no").ToString())
                    item.News_group.Group_id = Integer.Parse(reader("News_group").ToString())
                    item.News_type.Type_id = Integer.Parse(reader("News_type").ToString())
                    item.News_kind.Kind_id = Integer.Parse(reader("News_kind").ToString())
                    item.Show_status = Integer.Parse(reader("Show_status").ToString())
                    item.Title_persian = reader("Title_persian").ToString()
                    item.Title_latin = reader("Title_latin").ToString()
                    item.Summary_persian = reader("Summary_persian").ToString()
                    item.Html_summary_persian = reader("Html_summary_persian").ToString()
                    item.Summary_latin = reader("Summary_latin").ToString()
                    item.Html_summary_latin = reader("Html_summary_latin").ToString()
                    item.Content_persian = reader("Content_persian").ToString()
                    item.Html_content_persian = reader("Html_content_persian").ToString()
                    item.Content_latin = reader("Content_latin").ToString()
                    item.Html_content_latin = reader("Html_content_latin").ToString()
                    item.News_date = reader("News_date").ToString()
                    item.News_time = reader("News_time").ToString()
                    item.News_order = Integer.Parse(reader("News_order").ToString())
                    item.News_share = Boolean.Parse(reader("News_share").ToString())
                    item.News_share_ok = Boolean.Parse(reader("News_share_ok").ToString())
                    item.Show_date = reader("Show_date").ToString()
                    item.Show_time = reader("Show_time").ToString()
                    item.Expire_date = reader("Expire_date").ToString()
                    item.Expire_time = reader("Expire_time").ToString()
                    item.Show_weekdays = reader("Show_weekdays").ToString()
                    item.Insert_user = Integer.Parse(reader("Insert_user").ToString())
                    item.Small_picture_link = reader("Small_picture_link").ToString()
                    item.Large_picture_link = reader("Large_picture_link").ToString()
                    item.News_delete = Boolean.Parse(reader("News_delete").ToString())
                    item.Active = Boolean.Parse(reader("Active").ToString())
                    item.Remark = reader("Remark").ToString()
                    item.NewsUserFriendly = reader("NEWS_URLFRIENDLY").ToString()
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

    Public Function InsertNEWS(ByVal item As CLSNewsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_NEWS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@News_no", item.News_no)
        cmd.Parameters.AddWithValue("@NewsUrlFriendly", item.NewsUserFriendly)
        cmd.Parameters.AddWithValue("@News_group", item.News_group.Group_id)
        cmd.Parameters.AddWithValue("@News_type", item.News_type.Type_id)
        cmd.Parameters.AddWithValue("@News_kind", item.News_kind.Kind_id)
        cmd.Parameters.AddWithValue("@Show_status", item.Show_status)
        cmd.Parameters.AddWithValue("@Title_persian", item.Title_persian)
        cmd.Parameters.AddWithValue("@Title_latin", item.Title_latin)
        cmd.Parameters.AddWithValue("@Summary_persian", item.Summary_persian)
        cmd.Parameters.AddWithValue("@Html_summary_persian", item.Html_summary_persian)
        cmd.Parameters.AddWithValue("@Summary_latin", item.Summary_latin)
        cmd.Parameters.AddWithValue("@Html_summary_latin", item.Html_summary_latin)
        cmd.Parameters.AddWithValue("@Content_persian", item.Content_persian)
        cmd.Parameters.AddWithValue("@Html_content_persian", item.Html_content_persian)
        cmd.Parameters.AddWithValue("@Content_latin", item.Content_latin)
        cmd.Parameters.AddWithValue("@Html_content_latin", item.Html_content_latin)
        cmd.Parameters.AddWithValue("@News_date", item.News_date)
        cmd.Parameters.AddWithValue("@News_time", item.News_time)
        cmd.Parameters.AddWithValue("@News_order", item.News_order)
        cmd.Parameters.AddWithValue("@News_share", item.News_share)
        cmd.Parameters.AddWithValue("@News_share_ok", item.News_share_ok)
        cmd.Parameters.AddWithValue("@Show_date", item.Show_date)
        cmd.Parameters.AddWithValue("@Show_time", item.Show_time)
        cmd.Parameters.AddWithValue("@Expire_date", item.Expire_date)
        cmd.Parameters.AddWithValue("@Expire_time", item.Expire_time)
        cmd.Parameters.AddWithValue("@Show_weekdays", item.Show_weekdays)
        cmd.Parameters.AddWithValue("@NewsLabels", item.NewsLabels)
        cmd.Parameters.AddWithValue("@Insert_user", item.Insert_user)
        cmd.Parameters.AddWithValue("@Small_picture_link", item.Small_picture_link)
        cmd.Parameters.AddWithValue("@Large_picture_link", item.Large_picture_link)
        cmd.Parameters.AddWithValue("@News_delete", item.News_delete)
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

    Public Function DeleteNEWS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_NEWS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@NewsId", item)
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

    Public Function UpdateNEWS(ByVal item As CLSNewsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_NEWS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@News_id", item.News_id)
        cmd.Parameters.AddWithValue("@News_no", item.News_no)
        cmd.Parameters.AddWithValue("@NewsUrlFriendly", item.NewsUserFriendly)
        cmd.Parameters.AddWithValue("@News_group", item.News_group.Group_id)
        cmd.Parameters.AddWithValue("@News_type", item.News_type.Type_id)
        cmd.Parameters.AddWithValue("@News_kind", item.News_kind.Kind_id)
        cmd.Parameters.AddWithValue("@Show_status", item.Show_status)
        cmd.Parameters.AddWithValue("@Title_persian", item.Title_persian)
        cmd.Parameters.AddWithValue("@Title_latin", item.Title_latin)
        cmd.Parameters.AddWithValue("@Summary_persian", item.Summary_persian)
        cmd.Parameters.AddWithValue("@Html_summary_persian", item.Html_summary_persian)
        cmd.Parameters.AddWithValue("@Summary_latin", item.Summary_latin)
        cmd.Parameters.AddWithValue("@Html_summary_latin", item.Html_summary_latin)
        cmd.Parameters.AddWithValue("@Content_persian", item.Content_persian)
        cmd.Parameters.AddWithValue("@Html_content_persian", item.Html_content_persian)
        cmd.Parameters.AddWithValue("@Content_latin", item.Content_latin)
        cmd.Parameters.AddWithValue("@Html_content_latin", item.Html_content_latin)
        cmd.Parameters.AddWithValue("@News_order", item.News_order)
        cmd.Parameters.AddWithValue("@News_share", item.News_share)
        cmd.Parameters.AddWithValue("@News_share_ok", item.News_share_ok)
        cmd.Parameters.AddWithValue("@Show_date", item.Show_date)
        cmd.Parameters.AddWithValue("@Show_time", item.Show_time)
        cmd.Parameters.AddWithValue("@Expire_date", item.Expire_date)
        cmd.Parameters.AddWithValue("@Expire_time", item.Expire_time)
        cmd.Parameters.AddWithValue("@Show_weekdays", item.Show_weekdays)
        cmd.Parameters.AddWithValue("@NewsLabels", item.NewsLabels)
        cmd.Parameters.AddWithValue("@Insert_user", item.Insert_user)
        cmd.Parameters.AddWithValue("@Small_picture_link", item.Small_picture_link)
        cmd.Parameters.AddWithValue("@Large_picture_link", item.Large_picture_link)
        cmd.Parameters.AddWithValue("@News_delete", item.News_delete)
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
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSWebpartsItem
    Public Property Division_id As Integer
    Public Property Division As New CLSPlantDivisionsItem
    Public Property Webpart_id As Integer
    Public Property Webpart_no As Integer
    Public Property WebPartType As Integer
    Public Property Webpart_group As Integer
    Public Property Webpart_name As String
    Public Property Name_persian As String
    Public Property Name_latin As String
    Public Property Header_persian As String
    Public Property Header_latin As String
    Public Property Html_content_persian As String
    Public Property Html_content_latin As String
    Public Property WebPart_Address As String
    Public Property WebpartMethod As String
    Public Property WebPartParameters As String
    Public Property Description_persian As String
    Public Property Description_latin As String
    Public Property Active As Boolean
    Public Property Remark As String
End Class

Public Class CLSWebparts
    Public Function GetWEBPARTS(Optional ByVal WebpartType As Integer = 0) As List(Of CLSWebpartsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_WEBPARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        If WebpartType <> 0 Then
            cmd.Parameters.AddWithValue("@WEBPARTTYPE", WebpartType)
        End If
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSWebpartsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSWebpartsItem()
                    item.Webpart_id = Integer.Parse(reader("Webpart_id").ToString())
                    item.Webpart_no = Integer.Parse(reader("Webpart_no").ToString())
                    item.Webpart_group = Integer.Parse(reader("Webpart_group").ToString())
                    item.Webpart_name = reader("Webpart_name").ToString()
                    item.Name_persian = reader("Name_persian").ToString()
                    item.Name_latin = reader("Name_latin").ToString()
                    item.Header_persian = reader("Header_persian").ToString()
                    item.Header_latin = reader("Header_latin").ToString()
                    item.Html_content_persian = reader("Html_content_persian").ToString()
                    item.Html_content_latin = reader("Html_content_latin").ToString()
                    item.Description_persian = reader("Description_persian").ToString()
                    item.Description_latin = reader("Description_latin").ToString()
                    item.Active = Boolean.Parse(reader("Active").ToString())
                    item.Remark = reader("Remark").ToString()
                    item.WebPartType = reader("WEBPART_TYPE").ToString
                    item.WebPartParameters = reader("WEBPART_PARAMETERS").ToString
                    item.WebpartMethod = reader("WEBPART_METHOD").ToString
                    item.WebPart_Address = reader("WEBPART_ADDRESS").ToString
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
    Public Function GetWEBPARTS(ByVal WebpartType As Integer, ByVal divisionId As Integer) As List(Of CLSWebpartsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_WEBPARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@WEBPARTTYPE", WebpartType)
        cmd.Parameters.AddWithValue("@DivisionId", divisionId)
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSWebpartsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSWebpartsItem()
                    item.Webpart_id = Integer.Parse(reader("Webpart_id").ToString())
                    item.Webpart_no = Integer.Parse(reader("Webpart_no").ToString())
                    item.Webpart_group = Integer.Parse(reader("Webpart_group").ToString())
                    item.Webpart_name = reader("Webpart_name").ToString()
                    item.Name_persian = reader("Name_persian").ToString()
                    item.Name_latin = reader("Name_latin").ToString()
                    item.Header_persian = reader("Header_persian").ToString()
                    item.Header_latin = reader("Header_latin").ToString()
                    item.Html_content_persian = reader("Html_content_persian").ToString()
                    item.Html_content_latin = reader("Html_content_latin").ToString()
                    item.Description_persian = reader("Description_persian").ToString()
                    item.Description_latin = reader("Description_latin").ToString()
                    item.Active = Boolean.Parse(reader("Active").ToString())
                    item.Remark = reader("Remark").ToString()
                    item.WebPartType = reader("WEBPART_TYPE").ToString
                    item.WebPartParameters = reader("WEBPART_PARAMETERS").ToString
                    item.WebpartMethod = reader("WEBPART_METHOD").ToString
                    item.WebPart_Address = reader("WEBPART_ADDRESS").ToString
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
    Public Function GetWEBPART(ByVal id As Integer) As CLSWebpartsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_WEBPARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@WebPartId", id)
        Dim item As New CLSWebpartsItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Webpart_id = Integer.Parse(reader("Webpart_id").ToString())
                    item.Webpart_no = Integer.Parse(reader("Webpart_no").ToString())
                    item.Webpart_group = Integer.Parse(reader("Webpart_group").ToString())
                    item.Webpart_name = reader("Webpart_name").ToString()
                    item.Name_persian = reader("Name_persian").ToString()
                    item.Name_latin = reader("Name_latin").ToString()
                    item.Header_persian = reader("Header_persian").ToString()
                    item.Header_latin = reader("Header_latin").ToString()
                    item.Html_content_persian = reader("Html_content_persian").ToString()
                    item.Html_content_latin = reader("Html_content_latin").ToString()
                    item.Description_persian = reader("Description_persian").ToString()
                    item.Description_latin = reader("Description_latin").ToString()
                    item.Active = Boolean.Parse(reader("Active").ToString())
                    item.Remark = reader("Remark").ToString()
                    item.WebPartType = reader("WEBPART_TYPE").ToString
                    item.WebPartParameters = reader("WEBPART_PARAMETERS").ToString
                    item.WebpartMethod = reader("WEBPART_METHOD").ToString
                    item.WebPart_Address = reader("WEBPART_ADDRESS").ToString
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
    Public Function InsertWEBPARTS(ByVal item As CLSWebpartsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_WEBPARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_Id", item.Division_id)
        cmd.Parameters.AddWithValue("@Webpart_no", item.Webpart_no)
        cmd.Parameters.AddWithValue("@Webpart_group", item.Webpart_group)
        cmd.Parameters.AddWithValue("@Webpart_name", item.Webpart_name)
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
        cmd.Parameters.AddWithValue("@Header_persian", item.Header_persian)
        cmd.Parameters.AddWithValue("@Header_latin", item.Header_latin)
        cmd.Parameters.AddWithValue("@Html_content_persian", item.Html_content_persian)
        cmd.Parameters.AddWithValue("@Html_content_latin", item.Html_content_latin)
        cmd.Parameters.AddWithValue("@Description_persian", item.Description_persian)
        cmd.Parameters.AddWithValue("@Description_latin", item.Description_latin)
        cmd.Parameters.AddWithValue("@Active", item.Active)
        cmd.Parameters.AddWithValue("@Remark", item.Remark)
        cmd.Parameters.AddWithValue("@WEBPART_ADDRESS", item.WebPart_Address)
        cmd.Parameters.AddWithValue("@WEBPART_METHOD", item.WebpartMethod)
        cmd.Parameters.AddWithValue("@WEBPART_PARAMETERS", item.WebPartParameters)
        cmd.Parameters.AddWithValue("@WEBPART_TYPE", item.WebPartType)

        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
            'Throw
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
    Public Function DeleteWEBPARTS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_WEB_PARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@WebPartId", item)
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
    Public Function UpdateWEBPARTS(ByVal item As CLSWebpartsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_WEBPARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Webpart_id", item.Webpart_id)
        cmd.Parameters.AddWithValue("@Webpart_no", item.Webpart_no)
        cmd.Parameters.AddWithValue("@Webpart_group", item.Webpart_group)
        cmd.Parameters.AddWithValue("@Webpart_name", item.Webpart_name)
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
        cmd.Parameters.AddWithValue("@Header_persian", item.Header_persian)
        cmd.Parameters.AddWithValue("@Header_latin", item.Header_latin)
        cmd.Parameters.AddWithValue("@Html_content_persian", item.Html_content_persian)
        cmd.Parameters.AddWithValue("@Html_content_latin", item.Html_content_latin)
        cmd.Parameters.AddWithValue("@Description_persian", item.Description_persian)
        cmd.Parameters.AddWithValue("@Description_latin", item.Description_latin)
        cmd.Parameters.AddWithValue("@Active", item.Active)
        cmd.Parameters.AddWithValue("@Remark", item.Remark)
        cmd.Parameters.AddWithValue("@WEBPART_ADDRESS", item.WebPart_Address)
        cmd.Parameters.AddWithValue("@WEBPART_METHOD", item.WebpartMethod)
        cmd.Parameters.AddWithValue("@WEBPART_PARAMETERS", item.WebPartParameters)
        cmd.Parameters.AddWithValue("@WEBPART_TYPE", item.WebPartType)
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

    Public Function GetWebPartForPage(ByVal name As String) As List(Of CLSWebpartsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_NOT_USE_WEBPART_PAGE", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@PageName", name)
        Dim retlist As New List(Of CLSWebpartsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSWebpartsItem()
                    item.Webpart_id = Integer.Parse(reader("Webpart_id").ToString())
                    item.Webpart_no = Integer.Parse(reader("Webpart_no").ToString())
                    item.Webpart_group = Integer.Parse(reader("Webpart_group").ToString())
                    item.Webpart_name = reader("Webpart_name").ToString()
                    item.Name_persian = reader("Name_persian").ToString()
                    item.Name_latin = reader("Name_latin").ToString()
                    item.Header_persian = reader("Header_persian").ToString()
                    item.Header_latin = reader("Header_latin").ToString()
                    item.Html_content_persian = reader("Html_content_persian").ToString()
                    item.Html_content_latin = reader("Html_content_latin").ToString()
                    item.Description_persian = reader("Description_persian").ToString()
                    item.Description_latin = reader("Description_latin").ToString()
                    item.WebPart_Address = reader("WebPart_Address").ToString
                    item.WebPart_Address = reader.Item("WEBPART_ADDRESS").ToString
                    item.WebpartMethod = reader.Item("WEBPART_METHOD").ToString
                    item.WebPartParameters = reader.Item("WEBPART_PARAMETERS").ToString
                    item.WebPartType = Integer.Parse(reader.Item("WEBPART_TYPE").ToString)
                    item.Active = Boolean.Parse(reader("Active").ToString())
                    item.Remark = reader("Remark").ToString()
                    item.WebPartType = reader("WEBPART_TYPE").ToString
                    item.WebPartParameters = reader("WEBPART_PARAMETERS").ToString
                    item.WebpartMethod = reader("WEBPART_METHOD").ToString
                    item.WebPart_Address = reader("WEBPART_ADDRESS").ToString
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
End Class
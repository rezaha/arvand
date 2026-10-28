Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSMenusItem
    Public Property Division As New CLSPlantDivisionsItem
    Public Property Menu_id As Integer
    Public Property Menu_no As Integer
    Public Property Show_status As Integer
    Public Property Name_persian As String
    Public Property Name_latin As String
    Public Property Link_active As Boolean
    Public Property Menu_link_persian As String
    Public Property Menu_link_latin As String
    Public Property Menu_level As Integer
    Public Property Menu_order As Integer
    Public Property Menu_parant As Nullable(Of Integer)
    Public Property Result_status As Integer
    Public Property Icon_status As Integer
    Public Property Menu_icon_link As String
    Public Property Active As Boolean
    Public Property Remark As String
End Class
Public Class CLSMenus

    Public Function GetMENUS(Optional ByVal DivisionId As Integer = 0, Optional ByVal Level As Integer = 0, Optional ByVal ParentId As Integer = 0) As List(Of CLSMenusItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_MENUS", cn) With {.CommandType = CommandType.StoredProcedure}
        If ParentId <> 0 Then
            cmd.Parameters.AddWithValue("@ParentId", ParentId)
        End If
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSMenusItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSMenusItem()
                    item.Menu_id = Integer.Parse(reader("Menu_id").ToString())
                    item.Menu_no = Integer.Parse(reader("Menu_no").ToString())
                    item.Show_status = Integer.Parse(reader("Show_status").ToString())
                    item.Name_persian = reader("MENU_NAME").ToString()
                    item.Name_latin = reader("MENU_ENAME").ToString()
                    item.Link_active = Boolean.Parse(reader("Link_active").ToString())
                    item.Menu_link_persian = reader("Menu_link_persian").ToString()
                    item.Menu_link_latin = reader("Menu_link_latin").ToString()
                    item.Menu_level = Integer.Parse(reader("Menu_level").ToString())
                    item.Menu_order = Integer.Parse(reader("Menu_order").ToString())
                    If reader("Menu_parant") IsNot DBNull.Value Then
                        item.Menu_parant = Integer.Parse(reader("Menu_parant").ToString())
                    Else
                        item.Menu_parant = CType(Nothing, Integer?)
                    End If
                    item.Result_status = Integer.Parse(reader("Result_status").ToString())
                    item.Icon_status = Integer.Parse(reader("Icon_status").ToString())
                    item.Menu_icon_link = reader("Menu_icon_link").ToString()
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

    Public Function GetMenuByLang(ByVal SiteLang As String) As List(Of CLSMenusItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("SELECT *  FROM MENUS   WHERE  (SHOW_STATUS=@SiteLang OR SHOW_STATUS=0 ) AND  LINK_ACTIVE= 1  ORDER BY  MENU_PARANT,MENU_ORDER,MENU_LEVEL ", cn)
        cmd.Parameters.AddWithValue("@SiteLang", IIf(SiteLang = "fa", 1, 2))
        Dim retlist As New List(Of CLSMenusItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSMenusItem()
                    item.Menu_id = Integer.Parse(reader("Menu_id").ToString())
                    item.Menu_no = Integer.Parse(reader("Menu_no").ToString())
                    item.Show_status = Integer.Parse(reader("Show_status").ToString())
                    item.Name_persian = reader("NAME_PERSIAN").ToString()
                    item.Name_latin = reader("NAME_LATIN").ToString()
                    item.Link_active = Boolean.Parse(reader("Link_active").ToString())
                    item.Menu_link_persian = reader("Menu_link_persian").ToString()
                    item.Menu_link_latin = reader("Menu_link_latin").ToString()
                    item.Menu_level = Integer.Parse(reader("Menu_level").ToString())
                    item.Menu_order = Integer.Parse(reader("Menu_order").ToString())
                    item.Menu_parant = Integer.Parse(reader("Menu_parant").ToString())
                    item.Result_status = Integer.Parse(reader("Result_status").ToString())
                    item.Icon_status = Integer.Parse(reader("Icon_status").ToString())
                    item.Menu_icon_link = reader("Menu_icon_link").ToString()
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

    Public Function GetMENU(ByVal id As Integer) As CLSMenusItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_MENUS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@MenuId", id)
        Dim item As New CLSMenusItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Menu_id = Integer.Parse(reader("Menu_id").ToString())
                    item.Menu_no = Integer.Parse(reader("Menu_no").ToString())
                    item.Show_status = Integer.Parse(reader("Show_status").ToString())
                    item.Name_persian = reader("MENU_NAME").ToString()
                    item.Name_latin = reader("MENU_ENAME").ToString()
                    item.Link_active = Boolean.Parse(reader("Link_active").ToString())
                    item.Menu_link_persian = reader("Menu_link_persian").ToString()
                    item.Menu_link_latin = reader("Menu_link_latin").ToString()
                    item.Menu_level = Integer.Parse(reader("Menu_level").ToString())
                    item.Menu_order = Integer.Parse(reader("Menu_order").ToString())
                    If reader("Menu_parant") IsNot DBNull.Value Then
                        item.Menu_parant = Integer.Parse(reader("Menu_parant").ToString())
                    Else
                        item.Menu_parant = CType(Nothing, Integer?)
                    End If
                    item.Result_status = Integer.Parse(reader("Result_status").ToString())
                    item.Icon_status = Integer.Parse(reader("Icon_status").ToString())
                    item.Menu_icon_link = reader("Menu_icon_link").ToString()
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

    Public Function InsertMENUS(ByVal item As CLSMenusItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_MENUS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@Menu_no", item.Menu_no)
        cmd.Parameters.AddWithValue("@Show_status", item.Show_status)
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
        cmd.Parameters.AddWithValue("@Link_active", item.Link_active)
        cmd.Parameters.AddWithValue("@Menu_link_persian", item.Menu_link_persian)
        cmd.Parameters.AddWithValue("@Menu_link_latin", item.Menu_link_latin)
        cmd.Parameters.AddWithValue("@Menu_level", item.Menu_level)
        cmd.Parameters.AddWithValue("@Menu_order", item.Menu_order)
        cmd.Parameters.AddWithValue("@Menu_parant", item.Menu_parant)
        cmd.Parameters.AddWithValue("@Result_status", item.Result_status)
        cmd.Parameters.AddWithValue("@Icon_status", item.Icon_status)
        cmd.Parameters.AddWithValue("@Menu_icon_link", item.Menu_icon_link)
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

    Public Function DeleteMENUS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_MENUS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@MenuId", item)
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

    Public Function UpdateMENUS(ByVal item As CLSMenusItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_MENUS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@Menu_id", item.Menu_id)
        cmd.Parameters.AddWithValue("@Menu_no", item.Menu_no)
        cmd.Parameters.AddWithValue("@Show_status", item.Show_status)
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
        cmd.Parameters.AddWithValue("@Link_active", item.Link_active)
        cmd.Parameters.AddWithValue("@Menu_link_persian", item.Menu_link_persian)
        cmd.Parameters.AddWithValue("@Menu_link_latin", item.Menu_link_latin)
        cmd.Parameters.AddWithValue("@Menu_level", item.Menu_level)
        cmd.Parameters.AddWithValue("@Menu_order", item.Menu_order)
        cmd.Parameters.AddWithValue("@Menu_parant", item.Menu_parant)
        cmd.Parameters.AddWithValue("@Result_status", item.Result_status)
        cmd.Parameters.AddWithValue("@Icon_status", item.Icon_status)
        cmd.Parameters.AddWithValue("@Menu_icon_link", item.Menu_icon_link)
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

    Public Function GetMenusByDA(ByVal lang As String) As DataSet
        Dim con As New SqlConnection(SiteHelper.GetConnectionString)
        Dim CmdTxt As String
        If lang = "fa" Then
            CmdTxt = "SELECT     MENU_ID, NAME_PERSIAN, MENU_LINK_PERSIAN, MENU_PARANT,LINK_ACTIVE, ICON_STATUS,MENU_ICON_LINK    FROM         MENUS  WHERE  (SHOW_STATUS=1 OR SHOW_STATUS=0 ) AND  LINK_ACTIVE=1  ORDER BY  MENU_PARANT,MENU_ORDER,MENU_LEVEL   "
        Else
            CmdTxt = "SELECT     MENU_ID, NAME_LATIN, MENU_LINK_LATIN, MENU_PARANT, LINK_ACTIVE, ICON_STATUS, MENU_ICON_LINK    FROM         MENUS   WHERE  (SHOW_STATUS=2 OR SHOW_STATUS=0 ) AND  LINK_ACTIVE=1  ORDER BY  MENU_PARANT,MENU_ORDER,MENU_LEVEL    "
        End If
        Dim com As New SqlCommand(CmdTxt, con)
        Dim da As New SqlDataAdapter(com)
        Dim ds As New DataSet
        da.Fill(ds)
        com.Dispose()
        da.Dispose()
        Return ds
    End Function

End Class
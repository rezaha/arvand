<%@ WebHandler Language="VB" Class="AssignWebparts" %>

Imports System
Imports System.Web
Imports System.Data.SqlClient
Imports System.Data
Imports DaneshArvandSiteDomainClasses.Models
Imports StructureMap

Public Class AssignWebparts : Implements IHttpHandler
    
   
    Public ReadOnly Property IsReusable As Boolean Implements System.Web.IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property
    
    Protected _securityUser As SecurityUsers
    Public Property _securityUserService As ISecurityUserService
    
    Protected Function getUserName() As String
        Dim coo As HttpCookie = _context.Request.Cookies("LoginCook")
        If coo Is Nothing Then
            _context.Response.Redirect("~/defaul.aspx", True)
            Exit Function
        End If
        If coo.Value.Trim = "" Then
            _context.Response.Redirect("~/defaul.aspx", True)
            Exit Function
        End If
        Return FormsAuthentication.Decrypt(coo.Value).UserData
    End Function
    Dim _context As HttpContext
    Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
        If context.Request.QueryString("p") = "in" Then
            Dim pagename As String = context.Request.QueryString("page")
            _context = context
            _securityUserService = ObjectFactory.GetInstance(Of ISecurityUserService)()
            _securityUser = _securityUserService.GetOneSecurityUserByUserName(getUserName)
            
            Dim divisionId As Integer = _securityUser.DivisionId
            Dim list As New List(Of CLSPagesWebpartsItem)

            Dim i1 As Integer = 1
            Dim i2 As Integer = 1
            Dim i3 As Integer = 1
            Dim PageId As Integer = 0
            Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
            Dim cmd1 As New SqlCommand("select PAGE_ID from pages where LOWER(PAGE_FILE_NAME)=LOWER(@PAGE_NAME)  AND DIVISION_ID=@divisionId", cn)
            cmd1.Parameters.AddWithValue("@PAGE_NAME", pagename)
            cmd1.Parameters.AddWithValue("@divisionId", divisionId)
            Try
                cn.Open()
                PageId = Integer.Parse(cmd1.ExecuteScalar())
            Catch ex As Exception
                Exit Sub
            Finally
                If cn.State <> ConnectionState.Closed Then
                    cn.Close()
                    cmd1.Dispose()
                End If
            End Try


            Dim aa As String = context.Request.Form.Item(0)
            Dim Cnt = aa.Split("|")
            For i As Integer = 0 To Cnt.Length - 2

                Dim item() As String = Cnt(i).ToString.Split("@")
                Dim web() As String = item(1).ToString.Split("_")
                Select Case item(0)
                    Case "widget_place_1"
                        Dim p1 As New CLSPagesWebpartsItem
                        p1.Page.Page_id = PageId
                        p1.Webpart.Webpart_id = IIf(web(2) <> String.Empty, Integer.Parse(web(2).ToString), 0)
                        p1.Col_no = 1
                        p1.Row_no = i1
                        p1.Col_order = 1
                        'widget_child_2_1_1_0_1
                        'p1.Move_option = IIf(web(3) = 1, True, False)
                        'p1.Collapse_option = IIf(web(4) = 1, True, False)
                        'p1.Delete_option = IIf(web(5) = 1, True, False)
                        'p1.Header_Visible = IIf(web(6) = 1, True, False)
                        list.Add(p1)
                        i1 += 1

                    Case "widget_place_2"
                        Dim p1 As New CLSPagesWebpartsItem
                        p1.Page.Page_id = PageId
                        p1.Webpart.Webpart_id = IIf(web(2) <> String.Empty, Integer.Parse(web(2).ToString), 0)
                        p1.Col_no = 2
                        p1.Row_no = i2
                        p1.Col_order = 2
                        'p1.Move_option = IIf(web(3) = 1, True, False)
                        'p1.Collapse_option = IIf(web(4) = 1, True, False)
                        'p1.Delete_option = IIf(web(5) = 1, True, False)
                        'p1.Header_Visible = IIf(web(6) = 1, True, False)
                        list.Add(p1)
                        i2 += 1
                    Case "widget_place_3"
                        Dim p1 As New CLSPagesWebpartsItem
                        p1.Page.Page_id = PageId
                        p1.Webpart.Webpart_id = IIf(web(2) <> String.Empty, Integer.Parse(web(2).ToString), 0)
                        p1.Col_no = 3
                        p1.Row_no = i3
                        p1.Col_order = 3
                        'p1.Move_option = IIf(web(3) = 1, True, False)
                        'p1.Collapse_option = IIf(web(4) = 1, True, False)
                        'p1.Delete_option = IIf(web(5) = 1, True, False)
                        'p1.Header_Visible = IIf(web(6) = 1, True, False)
                        list.Add(p1)
                        i2 += 1

                End Select
            Next

            Dim Operation As Boolean = True

            Dim cmd As New SqlCommand("DELETE_PAGES_WEBPART_ID", cn) With {.CommandType = CommandType.StoredProcedure}
            cmd.Parameters.AddWithValue("@Pageid", PageId)
            Dim trans As SqlTransaction = Nothing

            Try
                cn.Open()

                trans = cn.BeginTransaction()
                cmd.Transaction = trans
                cmd.ExecuteNonQuery()
                cmd.CommandText = "INSERT_PAGES_WEBPARTS"
                For Each item In list
                    cmd.Parameters.Clear()
                    cmd.Parameters.AddWithValue("@Page_id", item.Page.Page_id)
                    cmd.Parameters.AddWithValue("@Webpart_id", item.Webpart.Webpart_id)
                    cmd.Parameters.AddWithValue("@Row_no", item.Row_no)
                    cmd.Parameters.AddWithValue("@Col_no", item.Col_no)
                    cmd.Parameters.AddWithValue("@Col_order", item.Col_order)
                    cmd.Parameters.AddWithValue("@HEADER_VISIBLE", item.Header_Visible)
                    cmd.Parameters.AddWithValue("@Collapse_option", item.Collapse_option)
                    cmd.Parameters.AddWithValue("@Move_option", item.Move_option)
                    cmd.Parameters.AddWithValue("@Delete_option", item.Delete_option)
                    cmd.Parameters.AddWithValue("@Remark", "")
                    cmd.ExecuteNonQuery()
                Next

                trans.Commit()

            Catch ex As Exception
                trans.Rollback()
                Operation = False
            Finally
                If cn.State <> ConnectionState.Closed Then
                    cn.Close()
                    cmd.Dispose()
                End If
            End Try
            If Operation Then
                context.Response.Write("عملیات با موفقیت انجام شد")
            Else
                context.Response.Write("0")
            End If

        End If
    End Sub

End Class
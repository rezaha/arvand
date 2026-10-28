<%@ WebHandler Language="VB" Class="FileList" %>

Imports System
Imports System.Web
Imports System.IO

Public Class FileList : Implements IHttpHandler
    Dim Mycontext As System.Web.HttpContext
    
    Public ReadOnly Property IsReusable As Boolean Implements System.Web.IHttpHandler.IsReusable
        Get

        End Get
    End Property

    Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
        Mycontext = context
        Dim RootDir As String = FindDirectoryRoot()
        
        If context.Request.QueryString("firsttime") = "firsttime" Then
            'If RootDir = "" Then
            context.Response.Write(RootDir)
            'Exit Sub
            'End If
        ElseIf Not context.Request.QueryString("filename") Is Nothing Then
            Dim ListReq As String = context.Request.QueryString("filename")
            ListReq = ListReq.Replace("/", "\")
            ListReq = ListReq.Replace("\\", "\")
            Dim StrAdd() As String = ListReq.Split("\")
            If StrAdd(StrAdd.Length - 1) = ".." Then
                Dim CurAddress = ""
                For i = 0 To StrAdd.Length - 3
                    CurAddress &= StrAdd(i) & "\"
                Next
                ListReq = CurAddress
            End If
            If ListReq(ListReq.Length - 1) <> "\" Then
                ListReq &= "\"
            End If
            Dim UpStr As Boolean = True
            If ListReq = RootDir Then
                UpStr = False
            End If
            Dim DirStr As String = GetDirs(context.Request, ListReq, UpStr)
            Dim FileStr As String = GetFiles(context.Request, ListReq)
            ListReq = ListReq.Replace("\", "/")
            context.Response.Write(DirStr & "@" & FileStr & "@" & ListReq)
        ElseIf Not context.Request.QueryString("initafter") Is Nothing Then
            Dim ListReq As String = context.Request.QueryString("initafter")
            If Not Directory.Exists(Mycontext.Request.PhysicalApplicationPath & ListReq) Then
                ListReq = RootDir
            End If
            ListReq = ListReq.Replace("/", "\")
            ListReq = ListReq.Replace("\\", "\")
            Dim StrAdd() As String = ListReq.Split("\")
            ListReq = ""
            For i = 0 To StrAdd.Length - 2
                ListReq &= StrAdd(i) & "\"
            Next
            Dim UpStr As Boolean = True
            If ListReq = RootDir Then
                UpStr = False
            End If
            Dim DirStr As String = GetDirs(context.Request, ListReq, UpStr)
            Dim FileStr As String = GetFiles(context.Request, ListReq)
            ListReq = ListReq.Replace("\", "/")
            context.Response.Write(DirStr & "@" & FileStr & "@" & ListReq & "@" & StrAdd(StrAdd.Length - 1))
        End If
    End Sub

    Private Function GetDirs(ByVal req As HttpRequest, ByVal CurAddress As String, ByVal UpStr As Boolean) As String
        Dim DirStr As New StringBuilder
        If UpStr Then
            DirStr.Append("..")
            DirStr.Append("/")
        End If
        Dim CurDirs() As String = Directory.GetDirectories(req.PhysicalApplicationPath & CurAddress)
        For Each item In CurDirs
            item = item.Substring(item.LastIndexOf("\") + 1)

            DirStr.Append(item)
            DirStr.Append("/")
        Next
        If DirStr.Length > 0 Then
            DirStr.Remove(DirStr.Length - 1, 1)
        End If

        Return DirStr.ToString
    End Function

    Private Function GetFiles(ByVal req As HttpRequest, ByVal CurAddress As String) As String
        Dim FilesStr As New StringBuilder
        Dim CurFiles() As String = Directory.GetFiles(req.PhysicalApplicationPath & CurAddress)
        For Each item In CurFiles
            item = item.Substring(item.LastIndexOf("\") + 1)

            FilesStr.Append(item)
            FilesStr.Append("/")
        Next
        If FilesStr.Length > 0 Then
            FilesStr.Remove(FilesStr.Length - 1, 1)
        End If

        Return FilesStr.ToString
    End Function

    Private Function FindDirectoryRoot() As String
        Dim UserDetails = GetUserDetailsFromCookie()
        'If UserDetails(0) <> 3 Then
        '    Mycontext.Response.Redirect("~/Logout.aspx")
        'End If
        Dim DivisionId As Integer = UserDetails(1)
        If DivisionId = 0 Then
            Return "UploadFiles\"
        End If
        If Directory.Exists(Mycontext.Request.PhysicalApplicationPath & "UploadFiles\Divisions\div-" & DivisionId) Then
            Return "UploadFiles\Divisions\div-" & DivisionId & "\"
        Else
            Dim DirInfo As DirectoryInfo = Directory.CreateDirectory(Mycontext.Request.PhysicalApplicationPath & "UploadFiles\Divisions\div-" & DivisionId)
            If DirInfo.Exists Then
                Return DirInfo.FullName
                Return "UploadFiles\Divisions\div-" & DivisionId & "\"
            End If
        End If
        Return "UploadFiles\"
    End Function

    Private Function GetUserDetailsFromCookie() As String()
        Dim CookieName As String = FormsAuthentication.FormsCookieName
        Dim AuthCookie As HttpCookie = Mycontext.Request.Cookies(CookieName)
        If AuthCookie Is DBNull.Value Then
            Mycontext.Response.Redirect("~/Logout.aspx")
        End If
        Dim AuthTicket As FormsAuthenticationTicket
        Try
            AuthTicket = FormsAuthentication.Decrypt(AuthCookie.Value)
            Dim nfr As String() = AuthTicket.UserData.Split("|")
            Return nfr
        Catch ex As Exception
            Mycontext.Response.Redirect("~/Logout.aspx")
        End Try
        If AuthTicket Is DBNull.Value Then
            Mycontext.Response.Redirect("~/Logout.aspx")
        End If
        Mycontext.Response.Redirect("~/Logout.aspx")
    End Function
    
End Class
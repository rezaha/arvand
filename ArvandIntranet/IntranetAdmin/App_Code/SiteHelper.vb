Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.Configuration
Imports System.Data.SqlClient
Imports System.Data

Public NotInheritable Class SiteHelper
    Private Sub New()
    End Sub
    Public Shared ReadOnly Property GetConnectionString() As String
        Get
            'Dim Config As Configuration = WebConfigurationManager.OpenWebConfiguration("~/web.config")
            Return ConfigurationManager.ConnectionStrings("ConnectionString").ToString()
        End Get
    End Property


    Public Shared Function GetUserRole() As String
        Dim userCookieName As String = FormsAuthentication.FormsCookieName
        Dim userCookie As HttpCookie = HttpContext.Current.Request.Cookies(userCookieName)
        If userCookie Is Nothing Then
            Return String.Empty
        End If

        Dim userTicket As FormsAuthenticationTicket
        Try
            userTicket = FormsAuthentication.Decrypt(userCookie.Value)
        Catch e1 As Exception

            Return String.Empty
        End Try

        If userTicket Is Nothing Then
            Return String.Empty
        End If

        Return userTicket.UserData
    End Function

    Public Shared Function GetDataBaseTableName() As ArrayList
        Dim cn As New SqlConnection(GetConnectionString())
        Dim cmd As New SqlCommand("SELECT name FROM dbo.sysobjects WHERE xtype = 'U'", cn)
        Dim retlist As New ArrayList()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Do While reader.Read()
                    retlist.Add(reader(0).ToString())
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

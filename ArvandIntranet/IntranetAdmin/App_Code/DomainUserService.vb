Imports System.DirectoryServices
Imports CacheManager.Core
Imports System.Threading

'Public Class DanCacheItem
'    Public Property Name As String
'    Public Property Value As Object
'    Public Property InsertTime As DateTime
'End Class

Public Class DomainUserService

    '' Private Shared ReadOnly _cashemanager As Lazy(Of ICacheManager(Of Object)) = New Lazy(Of ICacheManager(Of Object))(GetCashemanager, LazyThreadSafetyMode.ExecutionAndPublication)
    Shared _cashemanager As Lazy(Of ICacheManager(Of Object)) = New Lazy(Of ICacheManager(Of Object))(Function() GetCashemanager(), LazyThreadSafetyMode.ExecutionAndPublication)
    'private static readonly Lazy<Container> _containerBuilder =
    '       new Lazy<Container>(defaultContainer, LazyThreadSafetyMode.ExecutionAndPublication);

    '   public static Container Container
    '   {
    '       get { return _containerBuilder.Value; }
    '   }


    Public Shared Function GetCashemanager() As ICacheManager(Of Object)
        Return CacheFactory.Build("getDomainUsersCache", Function(settings) settings.WithSystemRuntimeCacheHandle("handle1"))
    End Function

    Public Shared Function GetFullNameAuthenticateUser() As String
        Try
            If Not HttpContext.Current.User.Identity.IsAuthenticated Then
                Return ""
            End If
            Dim name As String = HttpContext.Current.User.Identity.Name.ToString().Split("\"c)(1)
            Dim itemValue = GetFromCashe(name)
            If Not String.IsNullOrEmpty(itemValue) And Not String.IsNullOrWhiteSpace(itemValue) Then
                Return itemValue
            End If
            Dim entry = New DirectoryEntry("LDAP://DC=arvand,DC=co")
            Dim dSearch = New DirectorySearcher(entry)

            Dim fullName As String = String.Empty
            dSearch.Filter = "(&(objectClass=user)(SAMAccountName=" & name & "))"
            For Each sResultSet As SearchResult In dSearch.FindAll()
                fullName = GetProperty(sResultSet, "givenName") & " " & GetProperty(sResultSet, "sn")
                AddToCashe(name, fullName)
                Return fullName
            Next sResultSet
            Return HttpContext.Current.User.Identity.Name
        Catch ex As Exception

        End Try
        Return ""
    End Function

    Private Shared Function GetFromCashe(ByVal name As String) As String
        Dim fullName = _cashemanager.Value.Get(name)
        If fullName Is Nothing Then
            Return ""
        End If
        Return fullName.ToString()
    End Function

    Private Shared Sub AddToCashe(ByVal name As String, ByVal value As String)
        Dim item As New CacheItem(Of Object)(name, value, ExpirationMode.Absolute, TimeSpan.FromMinutes(60))
        _cashemanager.Value.Add(item)
    End Sub

    Public Shared Function GetDomainUserName(ByVal userWNameWithDomain As String) As String

        If userWNameWithDomain.Split("\"c).Length = 2 Then
            Return userWNameWithDomain.Split("\"c)(1)
        End If
        Return userWNameWithDomain
    End Function

    Public Shared Function GetAuthenticateUser() As String
        'Dim entry = New DirectoryEntry("LDAP://DC=abadan-ref,DC=ir")
        'Dim dSearch = New DirectorySearcher(entry)
        'Dim name As String = HttpContext.Current.User.Identity.Name.ToString().Split("\"c)(1)

        'Dim fullName As String = String.Empty
        'dSearch.Filter = "(&(objectClass=user)(SAMAccountName=" & name & "))"
        'For Each sResultSet As SearchResult In dSearch.FindAll()

        '    fullName = GetProperty(sResultSet, "givenName") & " " & GetProperty(sResultSet, "sn")

        '    'Response.Write(GetProperty(sResultSet, "cn"));
        '    '// First Name
        '    'Response.Write(GetProperty(sResultSet, "givenName"));
        '    '// Middle Initials

        '    '//Response.Write(GetProperty(sResultSet, "initials"));
        '    '// Last Name

        '    'Response.Write(GetProperty(sResultSet, "sn"));
        '    ' Address
        '    Return fullName
        'Next sResultSet
        Return HttpContext.Current.Request.ServerVariables("LOGON_USER")
    End Function

    Public Shared Function GetProperty(ByVal searchResult As SearchResult, ByVal propertyName As String) As String
        If searchResult.Properties.Contains(propertyName) Then
            Return searchResult.Properties(propertyName)(0).ToString()
        Else
            Return String.Empty
        End If
    End Function

    Public Shared Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is  _
        System.Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function

End Class

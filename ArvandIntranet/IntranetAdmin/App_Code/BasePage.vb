Imports Microsoft.VisualBasic
Imports StructureMap
Imports System.Threading
Imports System.Globalization

Public Class BasePage
    Inherits System.Web.UI.Page

    Public Sub New()
        ObjectFactory.BuildUp(Me)
    End Sub

    Dim PageObj As New CLSPages
    Dim pageCls As CLSPagesItem
    Private _siteLanguage As String
    Private _siteLocation As String
    Private _plantDivisions As PlantDivisions
    Public Property _plantDivisionsService As IPlantDivisionsService
    Public Property _visitorService As IVisitorService


    Public Property SiteLocation As String
        Get
            If RouteData.Values("location") IsNot Nothing Then
                _siteLocation = RouteData.Values("location").ToString.ToUpper
            Else
                _siteLocation = String.Empty
            End If
            Return _siteLocation
        End Get
        Set(value As String)
            _siteLocation = value
        End Set
    End Property

    Public Property SiteLanguage As String
        Get
            If RouteData.Values("language") IsNot Nothing Then
                _siteLanguage = RouteData.Values("language").ToString.ToLower
            Else
                _siteLanguage = String.Empty
            End If
            Return _siteLanguage
        End Get
        Set(value As String)
            _siteLanguage = value
        End Set
    End Property

    Public Property PlantDivisions As PlantDivisions
        Get
            If RouteData.Values("divisionAbbr") IsNot Nothing Then
                If _plantDivisions Is Nothing Then
                    Dim plantDivisionName = RouteData.Values("divisionAbbr").ToString.ToUpper
                    _plantDivisions = _plantDivisionsService.GetPlantDivisions(plantDivisionName)
                End If
            Else
                _siteLocation = String.Empty
            End If
            Return _plantDivisions
        End Get
        Set(value As PlantDivisions)
            _plantDivisions = value
        End Set
    End Property

    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        'Use the executing page, not the final route segment (e.g. news ID 390).
        pageCls = PageObj.GetPageDetails(IO.Path.GetFileName(AppRelativeVirtualPath))
        If Not String.IsNullOrEmpty(MasterPageFile) Then
            MasterPageFile = "~/MasterPages/Portal.master"
        End If
        Theme = String.Empty

    End Sub

    Protected Overrides Sub Render(writer As HtmlTextWriter)
        'Export handlers write their own response. Do not append a page shell.
        If Response.ContentType = "application/pdf" OrElse Response.ContentType = "application/vnd.ms-word" Then Return
        MyBase.Render(writer)
    End Sub

    Protected Overrides Sub InitializeCulture()

        If SiteLanguage <> "" And SiteLocation <> "" Then
            If (SiteLanguage.ToLower = "fa" Or SiteLanguage.ToLower = "en") And (SiteLocation.ToLower = "us" Or SiteLocation.ToLower = "ir") Then
            Else
                Response.Redirect("~/Default.aspx")
            End If

            Me.Culture = SiteLanguage & "-" & SiteLocation
            Me.UICulture = SiteLanguage & "-" & SiteLocation
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(SiteLanguage & "-" & SiteLocation)
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(SiteLanguage & "-" & SiteLocation)
        Else
            Response.Redirect("~/Default.aspx")
        End If
    End Sub

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'DomainUserService.GetAuthenticateUser()
            SetVisitors()
            SetMetaTags()
        End If
    End Sub

    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If SiteLanguage = "fa" Then
            If pageCls.Page_title <> "" Then
                Title = pageCls.Page_title
            End If
        Else
            If pageCls.Page_title <> "" Then
                Title = pageCls.Remark
            End If
        End If
    End Sub

    Private Sub SetVisitors()
        dim dt as new DateTimeHelper()
        Try
            Dim item As New Visitor
            item.PartId = 1
            item.PartType = "fa"
            item.Remark = ""
            item.UserType = False
            item.VisitBrowser = Request.Browser.Browser & " | " & Request.Browser.Version
            item.VisitComputerName = Request.UserHostAddress
            'item.Visit_computername = System.Net.Dns.GetHostEntry(Request.ServerVariables("remote_host")).HostName

            item.VisitDate = dt.ConvertToPersianDate(DateTime.Now)
            item.VisitIp = Request.UserHostAddress
            item.VisitOs = Request.UserAgent
            item.VisitTime = DateTime.Now.Hour & ":" & DateTime.Now.Minute
            item.DivisionId = PlantDivisions.DivisionId
            _visitorService.AddVisitor(item, New Dictionary(Of String, String))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SetMetaTags()
        Dim MetaObj As New CLSPagesMetatags

        Dim MetaData As List(Of CLSPagesMetatagsItem) = MetaObj.GetPAGES_METATAGS(PartType:="PAGES", PartId:=pageCls.Page_id)
        For Each metaTags In MetaData
            Dim Meta As New HtmlMeta
            Meta.Name = metaTags.Meta_name
            Meta.ID = metaTags.Meta_id
            Meta.Content = metaTags.Meta_content
            Meta.HttpEquiv = metaTags.Meta_httpequiv
            Meta.Scheme = metaTags.Meta_scheme
            If metaTags.Meta_lang <> "" Then
                Meta.Attributes.Add("lang", metaTags.Meta_lang)
            End If
            If metaTags.Meta_dir <> "" Then
                Meta.Attributes.Add("dir", metaTags.Meta_dir)
            End If
            If metaTags.Meta_xmllang <> "" Then
                Meta.Attributes.Add("xmllang", metaTags.Meta_xmllang)
            End If
            Page.Header.Controls.Add(Meta)
        Next
    End Sub

End Class

Option Infer On
Option Strict On

Imports System.Linq
Imports System.Web.Script.Serialization

Partial Class MasterPages_PortalShell
    Inherits BaseMasterPage

    Public Property SoftwareService As ISoftwareService
    Public Property MenuService As IMenuService
    Public Property NewsService As INewsService
    Public Property AnnouncementService As IAnnouncementService
    Public Property DocumentService As IDocManagementService
    Public Property DocumentGrantService As IDocGrantService

    Protected ReadOnly Property IsPortalHome As Boolean
        Get
            Return String.Equals(Page.AppRelativeVirtualPath, "~/default.aspx", StringComparison.OrdinalIgnoreCase)
        End Get
    End Property

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Response.ContentType = "application/pdf" OrElse Response.ContentType = "application/vnd.ms-word" Then Return
        Page.Header.DataBind()
        Dim division = PlantDivisions
        If division Is Nothing Then
            Dim adminPage = TryCast(Page, AdminBasePage)
            division = _plantDivisionsService.GetOnePlantDivisions(If(adminPage Is Nothing, 0, adminPage.CurrentDivisionId))
        End If
        If division Is Nothing Then Throw New InvalidOperationException("واحد اصلی سامانه تعریف نشده است.")
        PlantDivisions = division
        Dim divisionId = division.DivisionId
        Dim authenticated = Page.User.Identity.IsAuthenticated
        Dim userName = If(authenticated, DomainUserService.GetFullNameAuthenticateUser(), "کاربر مهمان")
        Dim domainName = If(authenticated, DomainUserService.GetDomainUserName(Page.User.Identity.Name), String.Empty)
        Dim softwares = SoftwareService.GetAllSoftwares(divisionId).
            Where(Function(item) item.Active).OrderBy(Function(item) item.SortOrder).
            Select(Function(item) New With {.title = item.SoftwareName, .url = PortalUrl.SafeUrl(item.SoftwareUrl)}).ToList()
        Dim menus = MenuService.SearchPersianMenus(DivisionId:=divisionId).
            Where(Function(item) item.Active).OrderBy(Function(item) item.MenuOrder).
            Select(Function(item) New With {
                .id = item.MenuId, .parent = item.MenuParent, .title = item.NamePersian,
                .url = If(item.LinkActive, MenuUrl(item.MenuLinkPersian), String.Empty)
            }).ToList()
        Dim news = NewsService.GetTopPersianNews(0, 20, "NewsDate DESC", divisionId).
            Select(Function(item) New With {
                .title = item.TitlePersian, .summary = item.SummaryPersian, .content = PlainText(item.HtmlContentPersian),
                .url = PageUrl("ShowNews", item.NewsId), .image = AssetUrl(item.SmallPictureLink)
            }).ToList()
        Dim announcements = AnnouncementService.GetTopAnnouncements(0, 20, "NewsDate DESC", divisionId).
            Select(Function(item) New With {
                .title = item.TitlePersian, .summary = item.SummaryPersian, .content = PlainText(item.HtmlContentPersian),
                .url = PageUrl("ShowAnnouncements", item.NewsId)
            }).ToList()
        'Match the existing document permissions; never send private document
        'titles or URLs to an unauthorized browser. DownloadDoc rechecks access.
        Dim documents = DocumentService.GetDocManagementsForDivision(divisionId).
            Where(Function(item) item.Active AndAlso
                (item.PublicGrant OrElse (authenticated AndAlso
                    DocumentGrantService.GetDocGrantByDocIdUserName(item.DocId, domainName).Any()))).
            Select(Function(item) New With {
                .title = item.DocTitle,
                .url = ResolveUrl("~/DownloadDoc.ashx?doc=" & item.DocId.ToString())
            }).ToList()
        Dim divisions = _plantDivisionsService.AllPlantDivision().
            Where(Function(item) item.DivisionId > 0 AndAlso
                (Not item.ParentDivisionId.HasValue OrElse item.ParentDivisionId.GetValueOrDefault() = divisionId)).
            OrderBy(Function(item) item.DivisionOrder).
            Select(Function(item) New With {
                .title = item.NamePersian,
                .url = GetRouteUrl("default-rout", New With {.pageName = "default", .divisionAbbr = item.DivisionAbbr})
            }).ToList()

        Dim payload = New With {
            .user = userName, .organization = PlantDivisions.NamePersian, .systems = softwares, .menus = menus,
            .news = news, .announcements = announcements, .files = documents, .divisions = divisions,
            .pages = New With {
                .home = PageUrl("default"), .about = PageUrl("About"),
                .contact = PageUrl("ContactUs"), .news = PageUrl("NewsArchive"),
                .search = PageUrl("Search"),
                .management = GetRouteUrl("managementlogin", New With {.pageName = "Login", .language = "fa", .location = "IR"}),
                .widgets = PageUrl("PortalWidgets"), .currency = PageUrl("Currency"),
                .rates = ResolveUrl("~/api/Service/PortalRates/fa/0"),
                .housing = PageUrl("RegisterHouseCooperative"), .managers = PageUrl("ExecutiveManagers")
            },
            .slides = New Object() {
                New With {.image = ResolveUrl("~/UploadFiles/slider/01/01.jpg"), .alt = "نمای مجتمع پتروشیمی اروند در غروب"},
                New With {.image = ResolveUrl("~/UploadFiles/slider/01/03.jpg"), .alt = "نمای شب مجتمع پتروشیمی اروند"},
                New With {.image = ResolveUrl("~/UploadFiles/slider/01/04.jpg"), .alt = "واحدهای تولید پتروشیمی اروند"}
            }
        }
        'A JSON script is still an HTML raw-text element: escape '<' to prevent
        'stored content containing </script> from terminating the element.
        PortalData.Text = New JavaScriptSerializer().Serialize(payload).
            Replace("<", "\u003c").Replace(">", "\u003e").Replace("&", "\u0026").
            Replace(Convert.ToChar(&H2028), "\u2028").Replace(Convert.ToChar(&H2029), "\u2029")
    End Sub

    Private Function PageUrl(pageName As String, Optional id As Integer? = Nothing) As String
        If Not IO.File.Exists(Server.MapPath("~/" & pageName & ".aspx")) Then Return String.Empty
        Dim language = If(String.IsNullOrEmpty(SiteLanguage), "fa", SiteLanguage)
        Return GetRouteUrl("default-rout", New With {.pageName = pageName, .id = id,
            .language = language, .location = If(language = "en", "US", "IR"), .divisionAbbr = PlantDivisions.DivisionAbbr})
    End Function

    Private Function PlainText(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then Return String.Empty
        Return HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(value, "<[^>]*>", " "))
    End Function

    Private Function MenuUrl(value As String) As String
        Return PortalMenuLinks.Resolve(Me, value)
    End Function

    Private Function AssetUrl(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then Return String.Empty
        Dim absolute As Uri = Nothing
        If Uri.TryCreate(value, UriKind.Absolute, absolute) Then Return PortalUrl.SafeUrl(value)
        Return PortalUrl.SafeUrl(ResolveUrl("~/" & value.Replace("\", "/").Replace("../", "").TrimStart("~"c, "/"c)))
    End Function

End Class

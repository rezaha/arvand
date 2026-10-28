<%@ Application Language="VB" %>
<%@ Import Namespace="Danesh.ArvandIntranet.DataLayer.Context" %>
<%@ Import Namespace="StructureMap" %>
<%@ Import Namespace="System.Data.Entity" %>
<%@ Import Namespace="System.Security.Principal" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="System.Web.Http" %>
<script RunAt="server">

    'Private Shared Sub InitStructureMap()
    '    ObjectFactory.Initialize(Sub(x)
    '                                 x.For(Of IUnitOfWork).HttpContextScoped().Use(Of InvestmentContext)()
    '                                 x.Scan(Sub(scan)
    '                                            scan.Assembly("Danesh.Investment.ServiceLayer")
    '                                            scan.Assembly("Danesh.Investment.Reports")
    '                                            scan.WithDefaultConventions()
    '                                        End Sub)
    '                                 x.SetAllProperties(Sub(y)
    '                                                        y.OfType(Of IUnitOfWork)()
    '                                                        y.WithAnyTypeFromNamespace("Danesh.Investment.ServiceLayer.Interfaces")
    '                                                        y.WithAnyTypeFromNamespace("Danesh.Investment.Reports.ReportInterfaces")
    '                                                    End Sub)
    '                             End Sub)
    'End Sub

    'Sub Application_Start()
    '    Database.SetInitializer(Of InvestmentContext)(Nothing)
    '    InitStructureMap()
    '    Using ctx As InvestmentContext = CType(ObjectFactory.GetInstance(Of IUnitOfWork)(), InvestmentContext)
    '        ctx.Database.Initialize(True)
    '    End Using
    'End Sub
    
    Private Shared Sub initStructureMap()
        ObjectFactory.Initialize(Sub(x)
                                     x.For(Of IUnitOfWork).HttpContextScoped().Use(Of ArvandIntranetContext)()
                                     x.For(Of INewsService).Use(Of NewsService)()
                                     x.For(Of IAnnouncementService).Use(Of AnnouncementService)()
                                     x.For(Of ISitesLinkService).Use(Of SitesLinkService)()
                                     x.For(Of ICompanyService).Use(Of CompanyService)()
                                     x.For(Of IAlbumService).Use(Of AlbumService)()
                                     x.For(Of IAlbumImagesService).Use(Of AlbumImagesService)()
                                     x.For(Of IPersuasiveService).Use(Of PersuasiveService)()
                                     x.For(Of IPrayerTimeService).Use(Of PrayerTimeService)()
                                     x.For(Of IProductService).Use(Of ProductService)()
                                     x.For(Of IMenuService).Use(Of MenuService)()
                                     x.For(Of IPlantDivisionsService).Use(Of PlantDivisionsService)()
                                     x.For(Of IPagesService).Use(Of PagesService)()
                                     x.For(Of IRSSService).Use(Of RSSService)()
                                     x.For(Of IPhonebookService).Use(Of PhonebookService)()
                                     x.For(Of ISecurityUserService).Use(Of SecurityUserService)()
                                     x.For(Of IPageWebPartService).Use(Of PageWebPartService)()
                                     x.For(Of IWebPartService).Use(Of WebPartService)()
                                     x.For(Of ISoftwareService).Use(Of SoftwareService)()
                                     x.For(Of IVisitorService).Use(Of VisitorService)()
                                     x.For(Of IExecutiveManagerService).Use(Of ExecutiveManagerService)()
                                     x.For(Of IThemeService).Use(Of ThemeService)()
                                     x.For(Of IDocManagementService).Use(Of DocManagementService)()
                                     x.For(Of IDocGrantService).Use(Of DocGrantService)()
                                     x.For(Of ISecurityFormsService).Use(Of SecurityFormsService)()
                                     x.For(Of ISecurityFormsGrantedService).Use(Of SecurityFormsGrantedService)()
                                     x.For(Of IMaxVolumeService).Use(Of MaxVolumeService)()
                                     x.For(Of IPollService).Use(Of PollService)()
                                     x.For(Of IPollQuestionsService).Use(Of PollQuestionsService)()
                                     x.For(Of IPollQuestionsOptionsService).Use(Of PollQuestionsOptionsService)()
                                     x.For(Of IPollsAnswersService).Use(Of PollsAnswersService)()
                                     x.For(Of IPollsFillerService).Use(Of PollsFillerService)()
                                     x.For(Of ISystemHistoryService).Use(Of SystemHistoryService)()
                                     x.For(Of IHouseCooperativeService).Use(Of HouseCooperativeService)()
                                     
                                     x.SetAllProperties(Sub(y)
                                                            y.OfType(Of IPhonebookService)()
                                                            y.OfType(Of IUnitOfWork)()
                                                            y.OfType(Of INewsService)()
                                                            y.OfType(Of IAnnouncementService)()
                                                            y.OfType(Of ISitesLinkService)()
                                                            y.OfType(Of ICompanyService)()
                                                            y.OfType(Of IAlbumService)()
                                                            y.OfType(Of IAlbumImagesService)()
                                                            y.OfType(Of IPersuasiveService)()
                                                            y.OfType(Of IPrayerTimeService)()
                                                            y.OfType(Of IProductService)()
                                                            y.OfType(Of IMenuService)()
                                                            y.OfType(Of IPlantDivisionsService)()
                                                            y.OfType(Of IPagesService)()
                                                            y.OfType(Of IRSSService)()
                                                            y.OfType(Of ISecurityUserService)()
                                                            y.OfType(Of IPageWebPartService)()
                                                            y.OfType(Of IWebPartService)()
                                                            y.OfType(Of ISoftwareService)()
                                                            y.OfType(Of IVisitorService)()
                                                            y.OfType(Of IExecutiveManagerService)()
                                                            y.OfType(Of IThemeService)()
                                                            y.OfType(Of IDocManagementService)()
                                                            y.OfType(Of IDocGrantService)()
                                                            y.OfType(Of ISecurityFormsService)()
                                                            y.OfType(Of ISecurityFormsGrantedService)()
                                                            y.OfType(Of IMaxVolumeService)()
                                                            y.OfType(Of IPollService)()
                                                            y.OfType(Of IPollQuestionsService)()
                                                            y.OfType(Of IPollQuestionsOptionsService)()
                                                            y.OfType(Of IPollsAnswersService)()
                                                            y.OfType(Of IPollsFillerService)()
                                                            y.OfType(Of ISystemHistoryService)()
                                                            y.OfType(Of IHouseCooperativeService)()
                                                        End Sub)
                                 End Sub)
    End Sub
    
    Public Shared KeyValid As Boolean = True
    
    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        'Application("OnlineUsers") = 0
        'RegisterRoutes(RouteTable.Routes)
        Database.SetInitializer(Of ArvandIntranetContext)(Nothing)
        initStructureMap()
        RegisterRoutes(RouteTable.Routes)
        Using ctx As ArvandIntranetContext = CType(ObjectFactory.GetInstance(Of IUnitOfWork)(), ArvandIntranetContext)
            ctx.Database.Initialize(True)
        End Using
    End Sub
    
    Sub Application_EndRequest()
        ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects()
    End Sub
    
    Sub RegisterRoutes(ByRef routes As RouteCollection)
        routes.Ignore("{*allaxd}", New With {.allaxd = ".*\.axd(/.*)?"})
        routes.Ignore("{resource}.axd/{*pathInfo}")
        routes.Ignore("{*allcss}", New With {.allcss = ".*\.css(/.*)?"})
        routes.Ignore("{*alljpg}", New With {.alljpg = ".*\.jpg(/.*)?"})
        routes.Ignore("{*alljs}", New With {.alljs = ".*\.js(/.*)?"})
        routes.Ignore("{*allpng}", New With {.allpng = ".*\.png(/.*)?"})
        routes.Ignore("{*allgif}", New With {.allpng = ".*\.gif(/.*)?"})
        routes.Ignore("{*allhandler}", New With {.allpng = ".*\.ashx(/.*)?"})
        routes.MapHttpRoute("ServiceApi", "api/{controller}/{action}/{lang}/{id}", defaults:=New With {.id = System.Web.Http.RouteParameter.Optional})
        'routes.Add("service", New Route("service/{servicename}/{id}", New HttpHandlerRouteHandler(Of PublicHandler)))
        routes.MapPageRoute("print-rout", "{language}-{location}/{divisionAbbr}/print/{part}/{id}/{description}", "~/Print.aspx", False,
                            New RouteValueDictionary(
                                New With {
                                    .description = System.Web.Http.RouteParameter.Optional
                                }
                            )
                        )
        
        routes.MapPageRoute("print-word-rout", "{language}-{location}/{divisionAbbr}/PrintWord/{part}/{id}/{description}", "~/PrintWord.aspx", False,
                          New RouteValueDictionary(
                              New With {
                                  .description = System.Web.Http.RouteParameter.Optional
                              }
                          )
                      )
        routes.MapPageRoute("text-rout", "{language}-{location}/{divisionAbbr}/text/{part}/{id}/{description}", "~/Text.aspx", False,
                            New RouteValueDictionary(
                                New With {
                                    .description = System.Web.Http.RouteParameter.Optional
                                }
                            )
                        )
        routes.MapPageRoute("rss-rout", "{language}-{location}/{divisionAbbr}/rss/{part}/{id}/{description}", "~/RSS.aspx", False,
                            New RouteValueDictionary(
                                New With {
                                    .description = System.Web.Http.RouteParameter.Optional
                                }
                            )
                        )
        Dim _plantDivisionsService As IPlantDivisionsService = ObjectFactory.GetInstance(Of IPlantDivisionsService)()
        Dim firstDivision As PlantDivisions = _plantDivisionsService.GetOnePlantDivisions(0)
        routes.MapPageRoute("managementlogin", "{language}-{location}/{pageName}/danesh", "~/SystemMng/Login.aspx")
        routes.MapPageRoute("managementSecuritySystem", "SystemMng/SecuritySystem/{pageName}", "~/SystemMng/SecuritySystem/{pageName}.aspx")
        routes.MapPageRoute("managementSiteDefine", "SystemMng/Define/SiteDefine/{pageName}", "~/SystemMng/Define/SiteDefine/{pageName}.aspx")
        routes.MapPageRoute("managementTenders", "SystemMng/Define/Tenders/{pageName}", "~/SystemMng/Define/Tenders/{pageName}.aspx")
        routes.MapPageRoute("managementDefine", "SystemMng/Define/{pageName}", "~/SystemMng/Define/{pageName}.aspx")
        routes.MapPageRoute("managementHome", "SystemMng/Home/{pageName}", "~/SystemMng/Home/{pageName}.aspx")
        routes.MapPageRoute("managementOther", "SystemMng/Other/{pageName}", "~/SystemMng/Other/{pageName}.aspx")
        routes.MapPageRoute("managementAlbums", "SystemMng/PageAction/Albums/{pageName}", "~/SystemMng/PageAction/Albums/{pageName}.aspx")
        routes.MapPageRoute("managementPageAction", "SystemMng/PageAction/{pageName}", "~/SystemMng/PageAction/{pageName}.aspx")
        routes.MapPageRoute("managementUserOpinions", "SystemMng/UserOpinions/{pageName}", "~/SystemMng/UserOpinions/{pageName}.aspx")
        routes.MapPageRoute("management", "SystemMng/{pageName}", "~/SystemMng/{pageName}.aspx")
        routes.MapPageRoute("Operators", "Operators/{pageName}", "~/Operators/{pageName}.aspx")
        
        routes.MapPageRoute("Docs", "SystemMng/DocWebpart/{pageName}/{id}", "~/SystemMng/DocWebpart/{pageName}.aspx", False,
                             New RouteValueDictionary(
                                New With {
                                    .id = 0
                                }
                            )
                            )
        
        'routes.MapPageRoute("home-rout", "{language}-{location}/{divisionAbbr}/default", "~/Containers/{divisionAbbr}.aspx", False,
        '                    New RouteValueDictionary(
        '                        New With {
        '                            .language = "fa",
        '                            .location = "IR",
        '                            .divisionAbbr = firstDivision.DivisionAbbr
        '                        }
        '                    )
        '                )
        
        routes.MapPageRoute("default-rout", "{language}-{location}/{divisionAbbr}/{pageName}/{id}/{description}", "~/{pageName}.aspx", False,
                            New RouteValueDictionary(
                                New With {
                                    .language = "fa",
                                    .location = "IR",
                                    .divisionAbbr = firstDivision.DivisionAbbr,
                                    .pageName = "default",
                                    .id = System.Web.Http.RouteParameter.Optional,
                                    .description = System.Web.Http.RouteParameter.Optional
                                }
                            )
                        )
        
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs on application shutdown
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code that runs when an unhandled error occurs
    End Sub
      
    Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As System.EventArgs)
        
        Dim originalPath As String = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.ToLower()
        If originalPath.Contains("~/default.aspx") Or originalPath.ToLower = "~/" Then
            Response.RedirectToRoute("default-rout")
        Else
            If originalPath.Contains(".aspx") Then
                Response.RedirectToRoute("default-rout")
            End If
        End If

        'Dim CurPage As String = HttpContext.Current.Request.RawUrl.ToString().ToLower()
        'If CurPage = "/ghadir_website/default.aspx" Then
        '    Response.RedirectPermanent("/ghadir_website/fa")

        'End If
        
       
        'If Request.AppRelativeCurrentExecutionFilePath.Contains("CError") Or Request.AppRelativeCurrentExecutionFilePath = "~/Images/error_page.png" Then
        'Else
        '    If KeyValid Then
        '    Else
        '        Response.Redirect("CError")
        '    End If
        'End If
        
        'Dim langCookie As HttpCookie = Request.Cookies("site-config")
        'If langCookie Is Nothing Then
        '    langCookie = New HttpCookie("site-config")
        '    langCookie.Item("lang") = "fa"
        '    langCookie.Item("divisionid") = 0
        '    Response.Cookies.Add(langCookie)
        'End If
   
        If Request.Url.AbsolutePath.ToLower.Contains("danesh") Then
            Response.RedirectToRoute("management", New With {.pageName = "login"})
        End If
    End Sub
    
    'Private Sub RegisterRoutes(ByVal routes As RouteCollection)
    '    routes.MapPageRoute("site-lang", "{lang}", "~/Default.aspx")
    '    routes.MapPageRoute("fa-lang", "{lang}/news/{news-name}", "~/ShowNews.aspx")
       
    '    'routes.MapPageRoute("product", "product/{product-name}", "~/ShowProduct.aspx")
    '    'routes.MapPageRoute("gallery", "gallery/{gallery-name}", "~/Gallery.aspx")
    '    'routes.MapPageRoute("rss-news", "rss/news/{news-name}", "~/RSS.aspx")
    '    'routes.MapPageRoute("rss-product", "rss/product/{product-name}", "~/RSS.aspx")
    'End Sub
    
    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        'If Not CLS_IDGenerator.GetUniqueID("2AE234D0CD519B0586B203854E5CC6A34479AABD") Then
        '    KeyValid = False
        '    Response.Redirect("CError")
        'Else
          
        'End If
        'Try
        '    Dim item As New Visitor
        '    item.PartId = 1
        '    item.PartType = "fa"
        '    item.Remark = ""
        '    item.UserType = False
        '    item.VisitBrowser = Request.Browser.Browser & " | " & Request.Browser.Version
        '    item.VisitComputerName = Request.UserHostAddress
        '    'item.Visit_computername = System.Net.Dns.GetHostEntry(Request.ServerVariables("remote_host")).HostName
        '    item.VisitDate = CLSShamsiDate.ShortDate(Now).Substring(2)
        '    item.VisitIp = Request.UserHostAddress
        '    item.VisitOs = Request.UserAgent
        '    item.VisitTime = Now.Hour & ":" & Now.Minute
        '    item.DivisionId = firstDivision.DIVISION_ID
        '    Dim _visitorService As IVisitorService = ObjectFactory.GetInstance(Of IVisitorService)()
        '    _visitorService.AddVisitor(item, New Dictionary(Of String, String))
        'Catch ex As Exception

        'End Try
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

    End Sub
    
</script>

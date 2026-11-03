
Partial Class UserControls_MenuWUC
    Inherits BaseUserControl

    Public Property menuService As IMenuService
    Dim menuList As List(Of Danesh.ArvandIntranet.DomainClasses.Models.Menu)
    Dim sb As New StringBuilder

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If SiteLanguage.ToLower = "en" Then
            menuList = menuService.SearchLatinMenus(DivisionId:=PlantDivisions.DivisionId)
            SetMenu(0)
            menuContent.InnerHtml = sb.ToString
        Else
            menuList = menuService.SearchPersianMenus(DivisionId:=PlantDivisions.DivisionId)
            SetMenu(0)
            menuContent.InnerHtml = sb.ToString
        End If

        
    End Sub

    Public Sub SetMenu(Optional ByVal ParentId As Integer? = Nothing)
        'If ParentId = 0 Then
        '    sb.Append("<ul class=""sf-menu"">")
        'Else
        sb.Append("<ul>")
        'End If
        Dim childMenu = menuList.Where(Function(a) If(ParentId.HasValue, a.MenuParent = ParentId, Not a.MenuParent.HasValue) And a.Active = True).OrderBy(Function(a) a.MenuOrder).ToList
        For Each item In childMenu
            Dim itemsCount = menuList.Where(Function(a) a.MenuParent = item.MenuId).Count
            Dim LinkText = IIf(SiteLanguage = "fa", item.MenuLinkPersian, item.MenuLinkLatin)
            Dim LinkStr As String = IIf(LinkText = "#", "#", SetPageLink(LinkText))
            Dim LinkName = IIf(SiteLanguage = "fa", item.NamePersian, item.NameLatin)
            If Not item.LinkActive Then
                LinkStr = "#"
            End If
            If itemsCount > 0 Then
                sb.Append("<li><a href=""" & LinkStr & """>" & LinkName & "</a>")
                SetMenu(item.MenuId)
                sb.Append("</li>")
            Else
                sb.Append("<li><a href=""" & LinkStr & """>" & LinkName & "</a></li>")
            End If
        Next
        sb.Append("</ul>")
    End Sub


    Public Function SetPageLink(ByVal PageLink As String) As String
        'Dim SplitsPageLink = PageLink.Split("/")
        'Dim PageName As String
        'Dim PageId As Integer? = Nothing
        'Dim PageDescription As String = ""

        'Select Case SplitsPageLink.Length
        '    Case 3
        '        PageName = SplitsPageLink(0)
        '        PageId = Int32.Parse(SplitsPageLink(1))
        '        PageDescription = SplitsPageLink(2)
        '    Case 2
        '        PageName = SplitsPageLink(0)
        '        PageId = Int32.Parse(SplitsPageLink(1))
        '        PageDescription = ""
        '    Case 1
        '        PageName = SplitsPageLink(0)
        '        PageDescription = ""
        '    Case 0
        '        PageName = "invalidpage"
        '        PageDescription = ""
        '    Case Else
        '        PageName = "invalidpage"
        '        PageDescription = ""
        'End Select
        'Dim url As String = GetRouteUrl("default-rout", New With {.pageName = PageName, .id = PageId}) & "/" & Server.HtmlDecode(PageDescription)
        Return PortalMenuLinks.Resolve(Me, PageLink)

    End Function

End Class

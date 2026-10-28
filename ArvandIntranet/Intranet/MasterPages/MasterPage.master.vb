
Partial Class MasterPage

    Inherits BaseMasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Header.DataBind()
        If HttpContext.Current.User.Identity.IsAuthenticated Then
            lblUserName.Text = DomainUserService.GetFullNameAuthenticateUser & " - " & DomainUserService.GetUserName
        Else
            lblUserName.Text = "ناشناس"
        End If

        lblPlantName.Text = PlantDivisions.NamePersian

        Dim Dt As New DateTimeHelper()
        lblDate.Text = Dt.ConvertToPersianDate(DateTime.Now)

        If Not IsPostBack Then
            'Dim url As String = String.Empty
            'homePageLink.HRef = GetRouteUrl("default-rout", New With {.pageName = "Default", .id = Nothing})
            txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + imgBtnSearch.ClientID + "')")
        End If

        '    Dim langCookie As HttpCookie = Request.Cookies("site-config")
        '    If langCookie.Values("lang").ToLower = "fa" Then

        '        lblDateTime.Text = "امروز " & CLSShamsiDate.ShortDatePersian(Now)
        '        lnkLatin.Visible = True
        '        lnkPersian.Visible = False
        '        lblFooter.Text = "تمامی حقوق این اثر متعلق به شرکت پتروشیمی غدیر می باشد."
        '        lblFooterDesigner.Text = "<a href=""http://www.kwsoft.ir"" terget=""_blank"">" & "©2011-DANESH Portal. طراحی و تولید شرکت دانش افزار ماهان" & "</a>"
        '    Else
        '        lblDateTime.Text = CLSShamsiDate.ShortDateLatin(Now)
        '        lnkLatin.Visible = False
        '        lnkPersian.Visible = True
        '        lblFooter.Text = "All rights reserved Ghadir Petrochemical Company"
        '        lblFooterDesigner.Text = "Design and Production Danseh Afzar Mahan.©2011-DANESH Portal"
        '    End If
        '    Dim masterPageObj As New CLSMasterPages
        '    Dim pageMetaTag As New CLSPagesMetatags
        '    If Not IsPostBack Then
        '        Dim Masterpage As CLSMasterPagesItem = masterPageObj.GetMASTERPAGE(MasterName:="MasterPage.master")
        '        Page.Title = Masterpage.Masterpage_title_persian
        '        Dim MetaData As List(Of CLSPagesMetatagsItem) = pageMetaTag.GetPAGES_METATAGS(PartType:="MASTERPAGES", PartId:=Masterpage.Masterpage_id)
        '        For Each metaTags In MetaData
        '            Dim Meta As New HtmlMeta
        '            Meta.Name = metaTags.Meta_name
        '            Meta.ID = metaTags.Meta_id
        '            Meta.Content = metaTags.Meta_content
        '            Meta.HttpEquiv = metaTags.Meta_httpequiv
        '            Meta.Scheme = metaTags.Meta_scheme
        '            If metaTags.Meta_lang <> "" Then
        '                Meta.Attributes.Add("lang", metaTags.Meta_lang)
        '            End If
        '            If metaTags.Meta_dir <> "" Then
        '                Meta.Attributes.Add("dir", metaTags.Meta_dir)
        '            End If
        '            If metaTags.Meta_xmllang <> "" Then
        '                Meta.Attributes.Add("xmllang", metaTags.Meta_xmllang)
        '            End If
        '            Page.Header.Controls.Add(Meta)
        '        Next
        '    End If

        'changeLang.HRef = Page.GetRouteUrl("default-rout",
        '                                   New With {
        '                                       .language = "en",
        '                                       .location = "US",
        '                                       .pageName = Page.RouteData.Values("pageName"),
        '                                       .id = Page.RouteData.Values("id"),
        '                                       .description = Page.RouteData.Values("description")
        '                                   }
        '                               )

    End Sub

    'Protected Sub linkBtnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkBtnSearch.Click
    '    Response.Redirect("~/Search.aspx?search=" & txtSearch.Text.Trim)
    'End Sub

    'Protected Sub lnkLatin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLatin.Click
    '    Dim langCookie As HttpCookie = Request.Cookies("site-config")
    '    langCookie.Item("lang") = "en"
    '    Response.Cookies.Add(langCookie)
    '    Response.Redirect(Request.RawUrl)
    'End Sub

    'Protected Sub lnkPersian_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkPersian.Click
    '    Dim langCookie As HttpCookie = Request.Cookies("site-config")
    '    langCookie.Item("lang") = "fa"
    '    Response.Cookies.Add(langCookie)
    '    Response.Redirect(Request.RawUrl)
    'End Sub

    Protected Function GetPageSize() As Integer
        If PlantDivisions.PageSize.HasValue Then
            Return PlantDivisions.PageSize.Value
        End If
        Return 960
    End Function

    Protected Sub imgBtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnSearch.Click
        Dim url As String = String.Empty
        url = GetRouteUrl("default-rout", New With {.pageName = "Search", .id = Nothing})
        Response.Redirect(url & "?q=" & Server.HtmlDecode(txtSearch.Text))
    End Sub
End Class


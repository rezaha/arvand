Imports Microsoft.VisualBasic
Imports StructureMap
Imports Newtonsoft.Json
Imports System.IO

Public Class PublicHandler : Implements IHttpHandler

    Dim Req_Context As System.Web.HttpContext

    Public ReadOnly Property IsReusable As Boolean Implements System.Web.IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property

    Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
        If Not context.Request.RequestContext.RouteData.Values("servicename") Is Nothing Then
            Req_Context = context
            If context.Request.RequestContext.RouteData.Values("servicename") = "weather" Then
                Wheather_Service()
            ElseIf context.Request.RequestContext.RouteData.Values("servicename") = "rates" Then
                Rates_Service()
            ElseIf context.Request.RequestContext.RouteData.Values("servicename") = "owghat" Then
                Owghat_Services()
            ElseIf context.Request.RequestContext.RouteData.Values("servicename") = "gallery" Then
                Gallery_Load()
            ElseIf context.Request.RequestContext.RouteData.Values("servicename") = "manager" Then
                Manager_Load()
            End If
        End If
    End Sub

    Private Sub Wheather_Service()

        Dim CityId As String = Req_Context.Request.RequestContext.RouteData.Values("id").ToString
        If (CityId <> String.Empty) Then
            Dim prayerTimeService As IPrayerTimeService = ObjectFactory.GetInstance(Of PrayerTimeService)()
            Dim prayer = prayerTimeService.GetOnePrayerTimes(CityId:=CityId, PrayerDate:=CLSShamsiDate.ShortDate(Now).Substring(2))
            Dim sb As New StringBuilder
            Dim CurTime As String = String.Format("{0:D2}", Now.Hour) & ":" & String.Format("{0:D2}", Now.Minute)
            sb.Append("<table class=""visitor_tb"">")

            'اذان صبح
            sb.Append("<tr><td>")
            sb.Append("<table class=""visitor_item"">")
            sb.Append("<tr>")
            sb.Append("<td style=""width: 10px;"">")
            sb.Append("<img src=""../Images/blue_red_bullet.jpg""/>")
            sb.Append("</td>")
            sb.Append("<td>")
            If Not (CurTime > prayer.MaghribPrayer And CurTime <= prayer.MidNight) Then
                If CurTime < prayer.MorningPrayer Then
                    sb.Append("<span class=""current_time"">")
                    sb.Append("اذان صبح")
                    sb.Append("</span>")
                Else
                    sb.Append("اذان صبح")
                End If
            Else
                sb.Append("اذان صبح")
            End If
            sb.Append("</td>")
            sb.Append("<td></td>")
            sb.Append("<td class=""visitor_number"">")
            sb.Append("<span style=""vertical-align: top"">")
            sb.Append(prayer.MorningPrayer)
            sb.Append("</span>")
            sb.Append("<img style=""vertical-align: middle"" src=""../images/prayer/prayer_time_ico.png"" />")
            sb.Append("</td>")
            If Not (CurTime > prayer.MaghribPrayer And CurTime <= prayer.MidNight) Then
                If CurTime < prayer.MorningPrayer Then
                    sb.Append("<td id=""current_time"" style=""background: url('../Images/flasher.gif')"" class=""redside""></td>")
                Else
                    sb.Append("<td class=""redside""></td>")
                End If
            Else
                sb.Append("<td class=""redside""></td>")
            End If
            sb.Append("</tr>")
            sb.Append("</table>")
            sb.Append("</td></tr>")

            'طلوع آفتاب
            sb.Append("<tr><td>")
            sb.Append("<table class=""visitor_item"">")
            sb.Append("<tr>")
            sb.Append("<td style=""width: 10px;"">")
            sb.Append("<img src=""../images/blue_red_bullet.jpg""/>")
            sb.Append("</td>")
            sb.Append("<td>")
            If CurTime > prayer.MorningPrayer And CurTime <= prayer.Sunrise Then
                sb.Append("<span class=""current_time"">")
                sb.Append("طلوع آفتاب")
                sb.Append("</span>")
            Else
                sb.Append("طلوع آفتاب")
            End If
            sb.Append("</td>")
            sb.Append("<td></td>")
            sb.Append("<td class=""visitor_number"">")
            sb.Append("<span style=""vertical-align: top"">")
            sb.Append(prayer.Sunrise)
            sb.Append("</span>")
            sb.Append("<img style=""vertical-align: middle"" src=""../images/prayer/prayer_time_ico.png"" />")
            sb.Append("</td>")
            If CurTime > prayer.MorningPrayer And CurTime <= prayer.Sunrise Then
                sb.Append("<td id=""current_time"" style=""background: url('../Images/flasher.gif')"" class=""redside""></td>")
            Else
                sb.Append("<td class=""redside""></td>")
            End If
            sb.Append("</tr>")
            sb.Append("</table>")
            sb.Append("</td></tr>")

            'اذان ظهر
            sb.Append("<tr><td>")
            sb.Append("<table class=""visitor_item"">")
            sb.Append("<tr>")
            sb.Append("<td style=""width: 10px;"">")
            sb.Append("<img src=""../images/blue_red_bullet.jpg""/>")
            sb.Append("</td>")
            sb.Append("<td>")
            If CurTime > prayer.Sunrise And CurTime <= prayer.NoonPrayer Then
                sb.Append("<span class=""current_time"">")
                sb.Append("اذان ظهر")
                sb.Append("</span>")
            Else
                sb.Append("اذان ظهر")
            End If
            sb.Append("</td>")
            sb.Append("<td></td>")
            sb.Append("<td class=""visitor_number"">")
            sb.Append("<span style=""vertical-align: top"">")
            sb.Append(prayer.NoonPrayer)
            sb.Append("</span>")
            sb.Append("<img style=""vertical-align: middle"" src=""../images/prayer/prayer_time_ico.png"" />")
            sb.Append("</td>")
            If CurTime > prayer.Sunrise And CurTime <= prayer.NoonPrayer Then
                sb.Append("<td id=""current_time"" style=""background: url('../Images/flasher.gif')"" class=""redside""></td>")
            Else
                sb.Append("<td class=""redside""></td>")
            End If
            sb.Append("</tr>")
            sb.Append("</table>")
            sb.Append("</td></tr>")


            'غروب خورشید
            sb.Append("<tr><td>")
            sb.Append("<table class=""visitor_item"">")
            sb.Append("<tr>")
            sb.Append("<td style=""width: 10px;"">")
            sb.Append("<img src=""../images/blue_red_bullet.jpg""/>")
            sb.Append("</td>")
            sb.Append("<td>")
            If CurTime > prayer.NoonPrayer And CurTime <= prayer.Sunset Then
                sb.Append("<span class=""current_time"">")
                sb.Append("غروب خورشید")
                sb.Append("</span>")
            Else
                sb.Append("غروب خورشید")
            End If
            sb.Append("</td>")
            sb.Append("<td></td>")
            sb.Append("<td class=""visitor_number"">")
            sb.Append("<span style=""vertical-align: top"">")
            sb.Append(prayer.Sunset)
            sb.Append("</span>")
            sb.Append("<img style=""vertical-align: middle"" src=""../images/prayer/prayer_time_ico.png"" />")
            sb.Append("</td>")
            If CurTime > prayer.NoonPrayer And CurTime <= prayer.Sunset Then
                sb.Append("<td id=""current_time"" style=""background: url('../Images/flasher.gif')"" class=""redside""></td>")
            Else
                sb.Append("<td class=""redside""></td>")
            End If
            sb.Append("</tr>")
            sb.Append("</table>")
            sb.Append("</td></tr>")


            'اذان مغرب
            sb.Append("<tr><td>")
            sb.Append("<table class=""visitor_item"">")
            sb.Append("<tr>")
            sb.Append("<td style=""width: 10px;"">")
            sb.Append("<img src=""../images/blue_red_bullet.jpg""/>")
            sb.Append("</td>")
            sb.Append("<td>")
            If CurTime > prayer.Sunset And CurTime <= prayer.MaghribPrayer Then
                sb.Append("<span class=""current_time"">")
                sb.Append("اذان مغرب")
                sb.Append("</span>")
            Else
                sb.Append("اذان مغرب")
            End If
            sb.Append("</td>")
            sb.Append("<td></td>")
            sb.Append("<td class=""visitor_number"">")
            sb.Append("<span style=""vertical-align: top"">")
            sb.Append(prayer.MaghribPrayer)
            sb.Append("</span>")
            sb.Append("<img style=""vertical-align: middle"" src=""../images/prayer/prayer_time_ico.png"" />")
            sb.Append("</td>")
            If CurTime > prayer.Sunset And CurTime <= prayer.MaghribPrayer Then
                sb.Append("<td id=""current_time"" style=""background: url('../Images/flasher.gif')"" class=""redside""></td>")
            Else
                sb.Append("<td class=""redside""></td>")
            End If
            sb.Append("</tr>")
            sb.Append("</table>")
            sb.Append("</td></tr>")


            'نیمه شب
            sb.Append("<tr><td>")
            sb.Append("<table class=""visitor_item"">")
            sb.Append("<tr>")
            sb.Append("<td style=""width: 10px;"">")
            sb.Append("<img src=""../images/blue_red_bullet.jpg""/>")
            sb.Append("</td>")
            sb.Append("<td>")
            If CurTime > prayer.MaghribPrayer And CurTime <= prayer.MidNight Then
                sb.Append("<span class=""current_time"">")
                sb.Append("نیمه شب")
                sb.Append("</span>")
            Else
                sb.Append("نیمه شب")
            End If
            sb.Append("</td>")
            sb.Append("<td></td>")
            sb.Append("<td class=""visitor_number"">")
            sb.Append("<span style=""vertical-align: top"">")
            sb.Append(prayer.MidNight)
            sb.Append("</span>")
            sb.Append("<img style=""vertical-align: middle"" src=""../images/prayer/prayer_time_ico.png"" />")
            sb.Append("</td>")
            If CurTime > prayer.MaghribPrayer And CurTime <= prayer.MidNight Then
                sb.Append("<td id=""current_time"" style=""background: url('../Images/flasher.gif')"" class=""redside""></td>")
            Else
                sb.Append("<td class=""redside""></td>")
            End If
            sb.Append("</tr>")
            sb.Append("</table>")
            sb.Append("</td></tr>")
            sb.Append(" </table>")
            Req_Context.Response.Write(sb.ToString)
        End If
    End Sub

    Private Sub Rates_Service()
        Try
            Dim tb As New Table
            Dim tr As New TableRow
            Dim td As New TableCell
            Dim RatesCls As New ExRates
            Dim list As List(Of ExRatesFromBMIItem) = RatesCls.GetExRatesFromBMI()
            Dim ExR_EUR As ExRatesFromBMIItem = list.Find(Function(item As ExRatesFromBMIItem) item.title.IndexOf("EUR") > 0) ''یورو
            Dim ExR_USD As ExRatesFromBMIItem = list.Find(Function(item As ExRatesFromBMIItem) item.title.IndexOf("USD") > 0) ''دلار آمریکا
            Dim ExR_GBP As ExRatesFromBMIItem = list.Find(Function(item As ExRatesFromBMIItem) item.title.IndexOf("GBP") > 0) ''پوند انگلیس
            Dim ExR_CHF As ExRatesFromBMIItem = list.Find(Function(item As ExRatesFromBMIItem) item.title.IndexOf("CHF") > 0) ''فرانک سوئیس

            Dim EXR_JPY100 As ExRatesFromBMIItem = list.Find(Function(item As ExRatesFromBMIItem) item.title.IndexOf("JPY100") > 0) ''یکصد ین ژاپن
            Dim ExR_CNY As ExRatesFromBMIItem = list.Find(Function(item As ExRatesFromBMIItem) item.title.IndexOf("CNY") > 0) ''یوان چین
            Dim ExR_AUD As ExRatesFromBMIItem = list.Find(Function(item As ExRatesFromBMIItem) item.title.IndexOf("AUD") > 0) ''دلار استرالیا
            Dim ExR_CAD As ExRatesFromBMIItem = list.Find(Function(item As ExRatesFromBMIItem) item.title.IndexOf("CAD") > 0) ''دلار کانادا
            Dim ExR_TRY As ExRatesFromBMIItem = list.Find(Function(item As ExRatesFromBMIItem) item.title.IndexOf("TRY") > 0) ''لیر ترکیه
            Dim ExR_AED As ExRatesFromBMIItem = list.Find(Function(item As ExRatesFromBMIItem) item.title.IndexOf("AED") > 0) ''درهم امارات


            Dim sb As New StringBuilder
            sb.Append("<table class=""Currency_table"" cellpadding=""0"" cellspacing=""0"">")
            sb.Append("<thead><tr><td class=""Currency_header""><div style=""direction:rtl;text-align:right;float:right;"">آخرین نرخ در تاریخ: </div><div style=""direction:ltr;text-align:left"">" & CLSShamsiDate.ShortDate(Now) & "</div></td></tr></thead>")
            sb.Append("<tbody>")
            sb.Append("<tr><td align=""center"" class=""previous_td""><img src=""Images/icon/news-arrow-previous.png"" class=""previous"" /></td></tr>")
            sb.Append("<tr><td><div id=""newsticker-demo"">")
            sb.Append("<ul>")


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim Rates() As String = ExR_EUR.description.Split(" ")
            sb.Append("<li><table width=""100%""><tr><td class=""Currency_icon""><img id=""Img1"" src=""Images/icon/Currency.png"" runat=""server"" /></td>")
            sb.Append("<td>یورو</td>")
            sb.Append("<td align=""left"">" & Rates(8) & "</td></tr></table></li>")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Rates = ExR_USD.description.Split(" ")
            sb.Append("<li class=""li_greenStyle""><table width=""100%""><tr><td class=""Currency_icon""><img id=""Img1"" src=""Images/icon/Currency.png"" runat=""server"" /></td>")
            sb.Append("<td>دلار آمریکا</td>")
            sb.Append("<td align=""left"">" & Rates(8) & "</td></tr></table></li>")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Rates = ExR_GBP.description.Split(" ")
            sb.Append("<li><table width=""100%""><tr><td class=""Currency_icon""><img id=""Img1"" src=""Images/icon/Currency.png"" runat=""server"" /></td>")
            sb.Append("<td>پوند انگلیس</td>")
            sb.Append("<td align=""left"">" & Rates(8) & "</td></tr></table></li>")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Rates = ExR_CHF.description.Split(" ")
            sb.Append("<li class=""li_greenStyle""><table width=""100%""><tr><td class=""Currency_icon""><img id=""Img1"" src=""Images/icon/Currency.png"" runat=""server"" /></td>")
            sb.Append("<td>فرانک سوئیس</td>")
            sb.Append("<td align=""left"">" & Rates(8) & "</td></tr></table></li>")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Rates = EXR_JPY100.description.Split(" ")
            sb.Append("<li><table width=""100%""><tr><td class=""Currency_icon""><img id=""Img1"" src=""Images/icon/Currency.png"" runat=""server"" /></td>")
            sb.Append("<td>یکصد ین ژاپن</td>")
            sb.Append("<td align=""left"">" & Rates(8) & "</td></tr></table></li>")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Rates = ExR_CNY.description.Split(" ")
            sb.Append("<li class=""li_greenStyle""><table width=""100%""><tr><td class=""Currency_icon""><img id=""Img1"" src=""Images/icon/Currency.png"" runat=""server"" /></td>")
            sb.Append("<td>یوان چین</td>")
            sb.Append("<td align=""left"">" & Rates(8) & "</td></tr></table></li>")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Rates = ExR_AUD.description.Split(" ")
            sb.Append("<li><table width=""100%""><tr><td class=""Currency_icon""><img id=""Img1"" src=""Images/icon/Currency.png"" runat=""server"" /></td>")
            sb.Append("<td>دلار استرالیا</td>")
            sb.Append("<td align=""left"">" & Rates(8) & "</td></tr></table></li>")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Rates = ExR_CAD.description.Split(" ")
            sb.Append("<li class=""li_greenStyle""><table width=""100%""><tr><td class=""Currency_icon""><img id=""Img1"" src=""Images/icon/Currency.png"" runat=""server"" /></td>")
            sb.Append("<td>دلار کانادا</td>")
            sb.Append("<td align=""left"">" & Rates(8) & "</td></tr></table></li>")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Rates = ExR_TRY.description.Split(" ")
            sb.Append("<li><table width=""100%""><tr><td class=""Currency_icon""><img id=""Img1"" src=""Images/icon/Currency.png"" runat=""server"" /></td>")
            sb.Append("<td>لیر ترکیه</td>")
            sb.Append("<td align=""left"">" & Rates(8) & "</td></tr></table></li>")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Rates = ExR_AED.description.Split(" ")
            sb.Append("<li class=""li_greenStyle""><table width=""100%""><tr><td class=""Currency_icon""><img id=""Img1"" src=""Images/icon/Currency.png"" runat=""server"" /></td>")
            sb.Append("<td>درهم امارات</td>")
            sb.Append("<td align=""left"">" & Rates(8) & "</td></tr></table></li>")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            sb.Append("</ul></div></td></tr><tr><td align=""center"" class=""next_td""><img src=""Images/icon/news-arrow.png"" class=""next"" /></td>")
            sb.Append("</tr></tbody></table>")
            Req_Context.Response.Write(sb.ToString)
        Catch ex As Exception
            Req_Context.Response.Write("سرویس در دسترس نمی باشد.")
        End Try
    End Sub

    Private Sub Owghat_Services()
        Dim CityId As String = Req_Context.Request.QueryString("city").ToString

        Dim sb As New StringBuilder
        sb.Append("<table class=""Currency_table"" cellpadding=""0"" cellspacing=""0"">")
        sb.Append("<thead><tr><td class=""Currency_header""><table width=""100%"" cellpadding=""0"" cellspacing=""0""><tr><td style=""width: 30px;"">")
        sb.Append("<img src=""Images/icon/prayer_title_ico.png"" /></td><td>")
        sb.Append("اوقات شرعی به افق")
        sb.Append("</td><td class=""prayer_city_td"">")
        Dim drp As New DropDownList
        drp.CssClass = "prayer_select"
        drp.ID = "DdlPrayer"
        Dim CityObj As New CLSCities
        Dim List As List(Of CLSCitiesItem) = CityObj.GetCITIES()
        For Each item In List
            Dim li As New ListItem
            li.Text = item.Name_persian
            li.Value = item.City_id
            drp.Items.Add(li)
        Next
        drp.SelectedValue = CityId
        drp.Attributes.Add("onchange", "return OnOwghatChange();")
        Dim sw As New StringWriter
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        drp.RenderControl(htw)

        sb.Append(sw.ToString)

        Dim PrayerObj As New CLSPrayerTime
        Dim Prayer As CLSPrayerTimeItem = PrayerObj.GetRecord(CityId:=CityId, PrayerDate:=CLSShamsiDate.ShortDate(Now).Substring(2))

        sb.Append("</td></tr></table></td></tr></thead>")
        sb.Append("<tbody><tr><td><ul style=""list-style: none;"">")

        Dim CurTime As String = Now.Hour & ":" & Now.Minute
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sb.Append("<li class=""li_whiteStyle""><table width=""100%""><tr><td class=""Currency_icon"">")
        If CurTime < Prayer.MorningPrayer Then
            sb.Append("<img id=""Img1"" src=""Images/icon/flasher.gif"" />")
        Else
            sb.Append("<img id=""Img1"" src=""Images/icon/Prayer_ico.png"" />")
        End If
        sb.Append("</td><td>اذان صبح</td><td align=""left"">" & Prayer.MorningPrayer & "</td></tr></table></li>")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sb.Append("<li class=""li_blueStyle""><table width=""100%""><tr><td class=""Currency_icon"">")
        If CurTime > Prayer.MorningPrayer And CurTime < Prayer.Sunrise Then
            sb.Append("<img id=""Img1"" src=""Images/icon/flasher.gif"" />")
        Else
            sb.Append("<img id=""Img1"" src=""Images/icon/Prayer_ico.png"" />")
        End If
        sb.Append("</td><td>طلوع خورشید</td><td align=""left"">" & Prayer.Sunrise & "</td></tr></table></li>")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sb.Append("<li class=""li_whiteStyle""><table width=""100%""><tr><td class=""Currency_icon"">")
        If CurTime > Prayer.Sunrise And CurTime < Prayer.NoonPrayer Then
            sb.Append("<img id=""Img1"" src=""Images/icon/flasher.gif"" />")
        Else
            sb.Append("<img id=""Img1"" src=""Images/icon/Prayer_ico.png"" />")
        End If
        sb.Append("</td><td>اذان ظهر</td><td align=""left"">" & Prayer.NoonPrayer & "</td></tr></table></li>")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sb.Append("<li class=""li_blueStyle""><table width=""100%""><tr><td class=""Currency_icon"">")
        If CurTime > Prayer.NoonPrayer And CurTime < Prayer.Sunset Then
            sb.Append("<img id=""Img1"" src=""Images/icon/flasher.gif"" />")
        Else
            sb.Append("<img id=""Img1"" src=""Images/icon/Prayer_ico.png"" />")
        End If
        sb.Append("</td><td>غروب خورشید</td><td align=""left"">" & Prayer.Sunset & "</td></tr></table></li>")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sb.Append("<li class=""li_whiteStyle""><table width=""100%""><tr><td class=""Currency_icon"">")
        If CurTime > Prayer.Sunset And CurTime < Prayer.MaghribPrayer Then
            sb.Append("<img id=""Img1"" src=""Images/icon/flasher.gif"" />")
        Else
            sb.Append("<img id=""Img1"" src=""Images/icon/Prayer_ico.png"" />")
        End If
        sb.Append("</td><td>اذان مغرب</td><td align=""left"">" & Prayer.MaghribPrayer & "</td></tr></table></li>")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sb.Append("<li class=""li_blueStyle""><table width=""100%""><tr><td class=""Currency_icon"">")
        If CurTime > Prayer.MaghribPrayer And CurTime < Prayer.Midnight Then
            sb.Append("<img id=""Img1"" src=""Images/icon/flasher.gif"" />")
        Else
            sb.Append("<img id=""Img1"" src=""Images/icon/Prayer_ico.png"" />")
        End If
        sb.Append("</td><td>نیمه شب</td><td align=""left"">" & Prayer.Midnight & "</td></tr></table></li>")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sb.Append("</ul></td></tr></tbody></table>")
        Req_Context.Response.Write(sb.ToString)

    End Sub

    Private Sub Gallery_Load()
        Dim AlbumImagesObj As New CLSAlbumsImages
        Dim list As List(Of CLSAlbumsImagesItem) = AlbumImagesObj.GetAlbumImages(AlbumType:=0)
        Dim sb As New StringBuilder
        For Each item In list
            Dim langCookie As HttpCookie = Req_Context.Request.Cookies("site-config")
            Dim SiteLang As String = langCookie.Values("lang").ToLower
            If SiteLang = "fa" Then
                sb.Append("<li><a href=""" & item.ImageAddress & """><img src=""" & item.ImageAddress & """ title=""" & item.Album.PersianName & """ width=""50"" height=""50"" alt=""" & item.PersianDes & """></a></li>")
            Else
                sb.Append("<li><a href=""" & item.ImageAddress & """><img src=""" & item.ImageAddress & """ title=""" & item.Album.LatinName & """ width=""50"" height=""50"" alt=""" & item.LatinDes & """></a></li>")
            End If
        Next
        Req_Context.Response.Write(sb.ToString)
    End Sub

    Private Sub Manager_Load()
        Dim personId As Integer = Req_Context.Request.QueryString("person")
        Dim item As CLSExecutiveManagersItem = New CLSExecutiveManagers().GetRecord(personId)
        Dim res As String = JsonConvert.SerializeObject(item)
        Req_Context.Response.Write(res)
    End Sub

End Class
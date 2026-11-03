Imports System.Net
Imports System.Web.Http
Imports StructureMap
Imports System.IO

Public Class ServiceController
    Inherits ApiController

    '' GET api/<controller>
    'Public Function GetValues() As IEnumerable(Of String)
    '    Return New String() {"value1", "value2"}
    'End Function

    '' GET api/<controller>/5
    'Public Function GetValue(ByVal id As Integer) As String
    '    Return "value"
    'End Function

    '' POST api/<controller>
    'Public Sub PostValue(<FromBody()> ByVal value As String)

    'End Sub

    '' PUT api/<controller>/5
    'Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    'End Sub

    '' DELETE api/<controller>/5
    'Public Sub DeleteValue(ByVal id As Integer)

    'End Sub

    Public Function Weather(ByVal lang As String, ByVal id As Integer) As String
        If lang.ToLower = "en" Then
            Try
               
            Catch ex As Exception
                Return "Service not available"
            End Try
        Else
            Try
                Dim properties As New List(Of KeyValuePair(Of String, Object))
                properties.Add(New KeyValuePair(Of String, Object)("_cityId", id))
                Dim str = UserControlHelper.RenderUserControl("~/UserControls/WeatherContentWUC.ascx", properties)
                Return str
            Catch ex As Exception
                Return "سرویس در دسترس نمیباشد."
            End Try
        End If
        Return ""
    End Function


    'JSON contract for the new shell; the original ExRate HTML action remains
    'available to existing web parts. Never substitute fabricated prices.
    <HttpGet>
    Public Function PortalRates(ByVal lang As String) As Object
        Dim rates As New List(Of Object)
        Try
            For Each item In New ExRates().GetExRatesFromBMI()
                'Preserve the price position used by the original ExRate feed contract.
                Dim parts = item.description.Split(" "c)
                If parts.Length <= 8 Then Continue For
                Dim price = HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(parts(8), "<[^>]*>", "")).Trim()
                If Not System.Text.RegularExpressions.Regex.IsMatch(price, "^[0-9۰-۹٠-٩,٬.٫]+$") Then Continue For
                rates.Add(New With {.title = item.title, .value = price, .date = item.pubDate})
            Next
        Catch ex As Exception
            Return New With {.available = False, .items = rates}
        End Try
        Return New With {.available = rates.Count > 0, .items = rates}
    End Function

    Public Function ExRate(ByVal lang As String) As String

        If lang = "en" Then

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

                sb.Append("<div class=""content-div""> <div class=""currency_title""> <span>Country</span><span style=""width: 35px;"">Price</div> ")
                sb.Append("<a href=""#"" class=""currency_prev"" onclick=""return false"" id=""prev""> <img src=""../../images/currency/currency_arrow_right.png"" /></a> <div id=""s7""> ")


                sb.Append("<div class=""currency_item"">")

                '''''''''''''''''''''یورو
                Dim Rates() As String = ExR_EUR.description.Split(" ")
                sb.Append("<div class=""currency_item item1""><span class=""currency_name""><img src=""../../images/currency/money_euro.png""/><span class=""currency_country""> Euro</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''دلار آمریکا
                Rates = ExR_USD.description.Split(" ")
                sb.Append("<div class=""currency_item item2""><span class=""currency_name""> <img src=""../../images/currency/United-States-Flag.png""/><span class=""currency_country""> USD</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''پوند انگلیس
                Rates = ExR_GBP.description.Split(" ")
                sb.Append("<div class=""currency_item item3""><span class=""currency_name""><img src=""../../images/currency/United Kingdom.png""/><span class=""currency_country""> GBP</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                sb.Append("</div>")

                sb.Append("<div class=""currency_item"">")

                '''''''''''''''''''''فرانک سویس
                Rates = ExR_CHF.description.Split(" ")
                sb.Append("<div class=""currency_item item1""><span class=""currency_name""><img src=""../../images/currency/Switzerland-Flag.png""/><span class=""currency_country""> Swiss Franc</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''یکصد ین ژاپن
                Rates = EXR_JPY100.description.Split(" ")
                sb.Append("<div class=""currency_item item2""><span class=""currency_name""> <img src=""../../images/currency/Japan-Flag.png""/><span class=""currency_country""> Yen</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''یوان چین
                Rates = ExR_CNY.description.Split(" ")
                sb.Append("<div class=""currency_item item3""><span class=""currency_name""><img src=""../../images/currency/China-Flag.png""/><span class=""currency_country""> Yuan</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                sb.Append("</div>")

                sb.Append("<div class=""currency_item"">")

                '''''''''''''''''''''دلار کانادا
                Rates = ExR_CAD.description.Split(" ")
                sb.Append("<div class=""currency_item item1""><span class=""currency_name""><img src=""../../images/currency/Canada-Flag.png""/><span class=""currency_country""> CAD</span></span>  ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''لیر ترکیه
                Rates = ExR_TRY.description.Split(" ")
                sb.Append("<div class=""currency_item item2""><span class=""currency_name""><img src=""../../images/currency/Turkey-Flag.png""/><span class=""currency_country""> Lear</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''درهم امارات

                Rates = ExR_AED.description.Split(" ")
                sb.Append("<div class=""currency_item item3""><span class=""currency_name""><img src=""../../images/currency/em_flag.png""/><span class=""currency_country""> AED</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")
                sb.Append("</div>")


                sb.Append("</div><a href=""#"" class=""currency_next"" onclick=""return false"" id=""next""> <img src=""../../images/currency/currency_arrow_left.png""/></a></div> ")
                sb.Append("<span class=""currency_update"">Last Update: &nbsp;&nbsp;<div class=""currency_update_date"">")
                sb.Append(DateTime.Now.ToString("MM/dd/yyyy") + ".")
                sb.Append("</div> </span>")


                Return sb.ToString
            Catch ex As Exception
                Return "Service is not available."
            End Try
        Else

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

                sb.Append("<div class=""content-div""> <div class=""currency_title""> <span>کشور </span><span style=""width: 35px;"">فروش</div> ")
                sb.Append("<a href=""#"" class=""currency_prev"" onclick=""return false"" id=""prev""> <img src=""../../images/currency/currency_arrow_right.png"" /></a> <div id=""s7""> ")


                sb.Append("<div class=""currency_item"">")

                '''''''''''''''''''''یورو
                Dim Rates() As String = ExR_EUR.description.Split(" ")
                sb.Append("<div class=""currency_item item1""><span class=""currency_name""><img src=""../../images/currency/money_euro.png""/><span class=""currency_country"">یورو</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''دلار آمریکا
                Rates = ExR_USD.description.Split(" ")
                sb.Append("<div class=""currency_item item2""><span class=""currency_name""> <img src=""../../images/currency/United-States-Flag.png""/><span class=""currency_country"">دلار آمریکا</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''پوند انگلیس
                Rates = ExR_GBP.description.Split(" ")
                sb.Append("<div class=""currency_item item3""><span class=""currency_name""><img src=""../../images/currency/United Kingdom.png""/><span class=""currency_country""> پوند انگلیس</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                sb.Append("</div>")

                sb.Append("<div class=""currency_item"">")

                '''''''''''''''''''''فرانک سویس
                Rates = ExR_CHF.description.Split(" ")
                sb.Append("<div class=""currency_item item1""><span class=""currency_name""><img src=""../../images/currency/Switzerland-Flag.png""/><span class=""currency_country""> فرانک سوئیس</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''یکصد ین ژاپن
                Rates = EXR_JPY100.description.Split(" ")
                sb.Append("<div class=""currency_item item2""><span class=""currency_name""> <img src=""../../images/currency/Japan-Flag.png""/><span class=""currency_country""> یکصد ین ژاپن</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''یوان چین
                Rates = ExR_CNY.description.Split(" ")
                sb.Append("<div class=""currency_item item3""><span class=""currency_name""><img src=""../../images/currency/China-Flag.png""/><span class=""currency_country""> یوان چین</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                sb.Append("</div>")

                sb.Append("<div class=""currency_item"">")

                '''''''''''''''''''''دلار کانادا
                Rates = ExR_CAD.description.Split(" ")
                sb.Append("<div class=""currency_item item1""><span class=""currency_name""><img src=""../../images/currency/Canada-Flag.png""/><span class=""currency_country""> دلار کانادا</span></span>  ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''لیر ترکیه
                Rates = ExR_TRY.description.Split(" ")
                sb.Append("<div class=""currency_item item2""><span class=""currency_name""><img src=""../../images/currency/Turkey-Flag.png""/><span class=""currency_country""> لیر ترکیه</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")

                '''''''''''''''''''''درهم امارات

                Rates = ExR_AED.description.Split(" ")
                sb.Append("<div class=""currency_item item3""><span class=""currency_name""><img src=""../../images/currency/em_flag.png""/><span class=""currency_country""> درهم امارات</span></span> ")
                sb.Append("<span class=""currency_buy"">" & Rates(8) & "</span></div>")
                sb.Append("</div>")


                sb.Append("</div><a href=""#"" class=""currency_next"" onclick=""return false"" id=""next""> <img src=""../../images/currency/currency_arrow_left.png""/></a></div> ")
                sb.Append("<span class=""currency_update"">بروز رسانی: &nbsp;&nbsp;<div class=""currency_update_date"">")
                sb.Append(CLSShamsiDate.ShortDate(Now))
                sb.Append("</div> </span>")


                Return sb.ToString
            Catch ex As Exception
                Dim sb As New StringBuilder
                sb.Append("<div style=""font-family:tahoma; font-size:11px;"">")
                sb.Append("سرویس در دسترس نمیباشد")
                sb.Append("</div>")
                Return sb.ToString()
            End Try
        End If

    End Function

    Public Function Prayer(ByVal lang As String, ByVal id As Integer) As String
        If lang.ToLower = "en" Then
            Try

            Catch ex As Exception
                Return "Service not available"
            End Try
        Else
            Try
                Dim properties As New List(Of KeyValuePair(Of String, Object))
                properties.Add(New KeyValuePair(Of String, Object)("_cityId", id))
                Dim str = UserControlHelper.RenderUserControl("~/UserControls/PrayerTimesContentWUC.ascx", properties)
                Return str
            Catch ex As Exception
                Return "سرویس در دسترس نمیباشد."
            End Try
        End If
        Return ""

    End Function

    Public Function GetManagerDetails(ByVal lang As String, ByVal id As Integer) As CLSExecutiveManagersItem
        Dim item As CLSExecutiveManagersItem = New CLSExecutiveManagers().GetRecord(id)
        Return item
    End Function
End Class
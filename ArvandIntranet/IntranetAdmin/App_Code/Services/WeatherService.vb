Imports Microsoft.VisualBasic
Imports System.Xml
Imports System.ComponentModel

Public Enum WindDirectionEnum
    <Description("عادی")>
    None = 0
    <Description("شرق")>
    East
    '<Description("بین شرق و شمال شرقی")>
    <Description("شرق و شمال شرقی")>
    ENE
    '<Description("بین شرق و جنوب شرقی")>
    <Description("شرق و جنوب شرقی")>
    ESE
    <Description("شمال شرق")>
    NE
    '<Description("بین شمال و شمال شرق")>
    <Description("شمال و شمال شرق")>
    NNE
    '<Description("بین شمال و شمال غربی")>
    <Description("شمال و شمال غربی")>
    NNW
    <Description("شمال")>
    North
    <Description("شمال غربی")>
    NW
    <Description("جنوب شرقی")>
    SE
    <Description("جنوب")>
    South
    '<Description("بین جنوب و جنوب شرقی")>
    <Description("جنوب و جنوب شرقی")>
    SSE
    '<Description("بین جنوب و جنوب غربی")>
    <Description("جنوب و جنوب غربی")>
    SSW
    <Description("جنوب غربی")>
    SW
    <Description("متغییر")>
    Variable
    <Description("غرب")>
    West
    <Description("غرب و شمال غرب")>
    WNW
    '<Description("بین غرب و جنوب غربی")>
    <Description("غرب و جنوب غربی")>
    WSW
End Enum


Public Class WeatherStation
    Public Property Id As Integer
    Public Property City As WeatherCity
    Public Property D As Date
    Public Property Temperature As Integer
    Public Property WindSpeed As Integer
    Public Property WindDirection As WindDirectionEnum
    Public Property StrWindDirection As String
    Public Property StrWeatherStatus As String
    Public Property InsertDate As DateTime
    Public Property LastUpdateDate As String
    Public Property LastUpdateDateEn As DateTime
    Public Property LastUpdateTime As String
    Public Property WeatherIcon As String
    Public Property WindDegrees As String
    Public Property RelativeHumidity As String
    Public Property VisibilityKM As String
    Public Property forecast_1 As WeatherStationForecast
    Public Property forecast_2 As WeatherStationForecast
    Public Property forecast_3 As WeatherStationForecast
    Public Property forecast_4 As WeatherStationForecast
    Public Property forecast_5 As WeatherStationForecast
End Class

Public Class WeatherStationForecast
    Public Property Id As Integer
    Public Property City As WeatherCity
    Public Property D As Date
    Public Property HighTemperature As Integer
    Public Property LowTemperature As Integer
    Public Property Conditions As String
    Public Property WeatherIcon As String
    Public Property AveWindSpeed As Integer
    Public Property AveWindDirection As WindDirectionEnum
    Public Property MaxVisibilityKM As String
    Public Property MinVisibilityKM As String
    Public Property AveVisibilityKM As String
End Class

Public Class WeatherCity
    Public Property cityId As Integer
    Public Property country As String
    Public Property city As String
    Public Property persianCity As String
    Public Property latitude As String
    Public Property longitude As String
    Public Property LoadStatus As Boolean
End Class

Public Class WeatherService
    Private Const WeatherStationCache As String = "WeatherStationCache"
    Private Shared syncRoot As New Object()
    Private Shared instance As WeatherService = Nothing
    Private _cities As List(Of WeatherCity)

    Public Sub New()
        _cities = New List(Of WeatherCity)
        _cities.Add(New WeatherCity With {.cityId = 10, .city = "Ramhormoz", .country = "iran", .latitude = "31.3", .longitude = "49.6", .persianCity = "رامهرمز"})
        _cities.Add(New WeatherCity With {.cityId = 20, .city = "Ahwaz", .country = "iran", .latitude = "31.3", .longitude = "48.7", .persianCity = "اهواز"})
        _cities.Add(New WeatherCity With {.cityId = 30, .city = "Mahshahr", .country = "iran", .latitude = "30.6", .longitude = "49.2", .persianCity = "بندر ماهشهر"})
        _cities.Add(New WeatherCity With {.cityId = 40, .city = "Behbahan", .country = "iran", .latitude = "30.6", .longitude = "50.2", .persianCity = "بهبهان"})
        _cities.Add(New WeatherCity With {.cityId = 50, .city = "Abadan", .country = "iran", .latitude = "30.4", .longitude = "48.2", .persianCity = "آبادان"})
        _cities.Add(New WeatherCity With {.cityId = 60, .city = "Tehran", .country = "iran", .latitude = "35.7", .longitude = "51.3", .persianCity = "تهران"})
        _cities.Add(New WeatherCity With {.cityId = 70, .city = "Shiraz", .country = "iran", .latitude = "29.5", .longitude = "52.6", .persianCity = "شیراز"})
        _cities.Add(New WeatherCity With {.cityId = 80, .city = "Esfahan", .country = "iran", .latitude = "32.8", .longitude = "51.9", .persianCity = "اصفهان"})
        _cities.Add(New WeatherCity With {.cityId = 90, .city = "Mashhad", .country = "iran", .latitude = "36.3", .longitude = "59.6", .persianCity = "مشهد"})
    End Sub

    Public Shared ReadOnly Property Ins() As WeatherService
        Get
            If instance Is Nothing Then
                SyncLock syncRoot
                    If instance Is Nothing Then
                        instance = New WeatherService()
                    End If
                End SyncLock
            End If

            Return instance
        End Get
    End Property

    Public ReadOnly Property Cities As List(Of WeatherCity)
        Get
            Return _cities
        End Get
    End Property

    Public Function GetWeatherStationsInfo(ByVal Lang As String, ByVal CityId As Integer) As WeatherStation
        Dim list As List(Of WeatherStation) = TryCast(HttpContext.Current.Cache(WeatherStationCache), List(Of WeatherStation))
        If list Is Nothing Then

            list = New List(Of WeatherStation)()
            HttpContext.Current.Cache.Insert(WeatherStationCache, list, Nothing, Date.Now.AddHours(3), TimeSpan.Zero)
        End If
        Dim weatherStation As WeatherStation = list.FirstOrDefault(Function(a) a.City.cityId = CityId)
        If weatherStation Is Nothing Then
            weatherStation = LoadOneCity(Lang, CityId)
            list.Add(weatherStation)
        Else
            Dim dtHelper As New DateTimeHelper
            Dim getTime As String = dtHelper.GetTime(Now)
            If weatherStation.LastUpdateTime.Split(":")(0) > getTime.Split(":")(0) Then
                weatherStation = LoadOneCity(Lang, CityId)
            End If
        End If

        HttpContext.Current.Cache.Item(WeatherStationCache) = list
        Return weatherStation
    End Function

    Private Function FindIndex(ByVal array() As String, ByVal searchString As String) As Integer
        Dim result As Integer = 0
        For i As Integer = 0 To array.Length - 1
            If array(i) = searchString Then
                result = i
            End If
        Next i
        Return result
    End Function

    Private Function LoadOneCity(ByVal Language As String, ByVal cityId As Integer) As WeatherStation
        Dim weatherStation As New WeatherStation
        Dim dtHelper As New DateTimeHelper
        Dim doc As New XmlDocument()
        Dim city = _cities.FirstOrDefault(Function(a) a.cityId = cityId)
        If city Is Nothing Then
            weatherStation = Nothing
            Return weatherStation
        End If

        If Language.ToLower = "en" Then
            doc.Load("http://api.wunderground.com/api/c1420d54f076585c/geolookup/conditions/forecast/lang:EN/q/" & city.country & "/" & city.city & ".xml")
        Else
            doc.Load("http://api.wunderground.com/api/c1420d54f076585c/geolookup/conditions/forecast/lang:FA/q/" & city.country & "/" & city.city & ".xml")
        End If

        Dim node As XmlNode = doc.SelectSingleNode("/response/current_observation")
        weatherStation.City = city
        'weatherStation.D = ""
        'weatherStation.Id = ""
        Dim LastUpdate As DateTime = Convert.ToDateTime(node("observation_time_rfc822").InnerText)
        weatherStation.LastUpdateDateEn = LastUpdate
        weatherStation.LastUpdateDate = dtHelper.ConvertToPersianDate(LastUpdate)
        weatherStation.LastUpdateTime = dtHelper.GetTime(LastUpdate)
        weatherStation.StrWindDirection = node("wind_dir").InnerText
        weatherStation.StrWeatherStatus = node("weather").InnerText
        weatherStation.Temperature = node("temp_c").InnerText
        If Language.ToLower = "en" Then
        Else
            weatherStation.WindDirection = If(node("wind_dir").InnerText = String.Empty, WindDirectionEnum.None, CType([Enum].Parse(GetType(WindDirectionEnum), node("wind_dir").InnerText), WindDirectionEnum))
        End If
        weatherStation.WindSpeed = node("wind_kph").InnerText
        weatherStation.WeatherIcon = node("icon_url").InnerText
        weatherStation.WindDegrees = node("wind_degrees").InnerText
        weatherStation.RelativeHumidity = node("relative_humidity").InnerText
        weatherStation.VisibilityKM = node("visibility_km").InnerText
        weatherStation.InsertDate = Now

        'forecast
        Dim forecast As XmlNodeList = doc.SelectNodes("/response/forecast/simpleforecast/forecastdays/forecastday")
        'forecast day 1
        Dim weatherStation1 As New WeatherStationForecast
        node = forecast(0)
        Dim d As New DateTime(node("date").SelectSingleNode("year").InnerText, node("date").SelectSingleNode("month").InnerText, node("date").SelectSingleNode("day").InnerText,
                               node("date").SelectSingleNode("hour").InnerText, node("date").SelectSingleNode("min").InnerText, node("date").SelectSingleNode("sec").InnerText)
        weatherStation1.D = d
        weatherStation1.HighTemperature = node("high").SelectSingleNode("fahrenheit").InnerText
        weatherStation1.LowTemperature = node("low").SelectSingleNode("fahrenheit").InnerText
        weatherStation1.Conditions = node("conditions").InnerText
        weatherStation1.WeatherIcon = node("icon").InnerText
        weatherStation1.AveWindSpeed = node("avewind").SelectSingleNode("kph").InnerText
        'weatherStation1.AveWindDirection = If(node("avewind").SelectSingleNode("dir").InnerText = String.Empty, WindDirectionEnum.None, CType([Enum].Parse(GetType(WindDirectionEnum), node("avewind").SelectSingleNode("dir").InnerText), WindDirectionEnum))
        weatherStation1.MaxVisibilityKM = node("maxhumidity").InnerText
        weatherStation1.MinVisibilityKM = node("minhumidity").InnerText
        weatherStation1.AveVisibilityKM = node("avehumidity").InnerText
        weatherStation.forecast_1 = weatherStation1
        'forecast day 2
        weatherStation1 = New WeatherStationForecast
        node = forecast(1)
        d = New DateTime(node("date").SelectSingleNode("year").InnerText, node("date").SelectSingleNode("month").InnerText, node("date").SelectSingleNode("day").InnerText,
                               node("date").SelectSingleNode("hour").InnerText, node("date").SelectSingleNode("min").InnerText, node("date").SelectSingleNode("sec").InnerText)
        weatherStation1.D = d
        weatherStation1.HighTemperature = node("high").SelectSingleNode("fahrenheit").InnerText
        weatherStation1.LowTemperature = node("low").SelectSingleNode("fahrenheit").InnerText
        weatherStation1.Conditions = node("conditions").InnerText
        weatherStation1.WeatherIcon = node("icon").InnerText
        weatherStation1.AveWindSpeed = node("avewind").SelectSingleNode("kph").InnerText
        'weatherStation1.AveWindDirection = If(node("avewind").SelectSingleNode("dir").InnerText = String.Empty, WindDirectionEnum.None, CType([Enum].Parse(GetType(WindDirectionEnum), node("avewind").SelectSingleNode("dir").InnerText), WindDirectionEnum))
        weatherStation1.MaxVisibilityKM = node("maxhumidity").InnerText
        weatherStation1.MinVisibilityKM = node("minhumidity").InnerText
        weatherStation1.AveVisibilityKM = node("avehumidity").InnerText
        weatherStation.forecast_2 = weatherStation1
        'forecast day 2
        weatherStation1 = New WeatherStationForecast
        node = forecast(2)
        d = New DateTime(node("date").SelectSingleNode("year").InnerText, node("date").SelectSingleNode("month").InnerText, node("date").SelectSingleNode("day").InnerText,
                               node("date").SelectSingleNode("hour").InnerText, node("date").SelectSingleNode("min").InnerText, node("date").SelectSingleNode("sec").InnerText)
        weatherStation1.D = d
        weatherStation1.HighTemperature = node("high").SelectSingleNode("fahrenheit").InnerText
        weatherStation1.LowTemperature = node("low").SelectSingleNode("fahrenheit").InnerText
        weatherStation1.Conditions = node("conditions").InnerText
        weatherStation1.WeatherIcon = node("icon").InnerText
        weatherStation1.AveWindSpeed = node("avewind").SelectSingleNode("kph").InnerText
        'weatherStation1.AveWindDirection = If(node("avewind").SelectSingleNode("dir").InnerText = String.Empty, WindDirectionEnum.None, CType([Enum].Parse(GetType(WindDirectionEnum), node("avewind").SelectSingleNode("dir").InnerText), WindDirectionEnum))
        weatherStation1.MaxVisibilityKM = node("maxhumidity").InnerText
        weatherStation1.MinVisibilityKM = node("minhumidity").InnerText
        weatherStation1.AveVisibilityKM = node("avehumidity").InnerText
        weatherStation.forecast_3 = weatherStation1
        Return weatherStation
    End Function


End Class

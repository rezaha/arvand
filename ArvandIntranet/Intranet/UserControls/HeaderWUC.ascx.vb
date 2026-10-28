Imports System.IO
Imports Danesh.ArvandIntranet.CommonLibrary

Partial Class UserControls_HeaderWUC
    Inherits BaseUserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If SiteLanguage = "fa" Then

            Dim PlantDivisionItem = _plantDivisionsService.GetOnePlantDivisions(0)

            If File.Exists(Server.MapPath("~/" + PlantDivisionItem.HeaderImagePersianLink)) Then
                companyLogoImg.Src = "~/" + PlantDivisionItem.HeaderImagePersianLink
            Else
                companyLogoImg.Src = "~/Images/header.png"
            End If
            Dim dtHelper As New DateTimeHelper

            '    CurrentDate.InnerHtml = "امروز " & dtHelper.LongPersianDate(dtHelper.ConvertToPersianDate(Now), PersianDateTimeFormat.DayOfWeekName_Day_MonthName_Year).GetPersianNumbers()

        End If
    End Sub
End Class

Imports System.IO
Partial Class Explorer
    Inherits AdminBasePage

    Public Property _plantDivisionsService As IPlantDivisionsService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If RouteData.Values("id").ToString <> "" Then
                If Int32.Parse(RouteData.Values("id")) And RouteData.Values("id").ToString() = "1" Then
                    Dim explorerPath = "~/UploadFiles/Division/" & _securityUser.PlantDivision.DivisionAbbr
                    Dim paths(0) As String
                    paths(0) = explorerPath
                    If Not Directory.Exists(Server.MapPath(explorerPath)) Then
                        Directory.CreateDirectory(Server.MapPath(explorerPath))
                    End If
                    FileExplorer1.Configuration.ViewPaths = paths
                    FileExplorer1.Configuration.UploadPaths = paths
                    FileExplorer1.Configuration.DeletePaths = paths
                    FileExplorer1.Configuration.MaxUploadFileSize = (_maxVolume.MaxFileVolume * 1024)
                    ''Dim Patern(14) As String
                    ''Patern(0) = "*.doc"
                    ''Patern(1) = "*.docx"
                    ''Patern(2) = "*.xls"
                    ''Patern(3) = "*.xlsx"
                    ''Patern(4) = "*.pdf"
                    ''Patern(5) = "*.txt"
                    ''Patern(6) = "*.jpg"
                    ''Patern(7) = "*.jpeg"
                    ''Patern(8) = "*.bmp"
                    ''Patern(9) = "*.png"
                    ''Patern(10) = "*.gif"
                    ''Patern(11) = "*.ppt"
                    ''Patern(12) = "*.pptx"
                    ''Patern(13) = "*.pps"
                    ''Patern(14) = "*.ppsx"
                    ''FileExplorer1.Configuration.SearchPatterns  = Patern
                    FileExplorer1.VisibleControls = GetVisibleControls()
                Else
                    Dim explorerPath = "~/App_Data/ProtectDocs/" & _securityUser.PlantDivision.DivisionAbbr
                    Dim paths(0) As String
                    paths(0) = explorerPath
                    If Not Directory.Exists(Server.MapPath(explorerPath)) Then
                        Directory.CreateDirectory(Server.MapPath(explorerPath))
                    End If
                    FileExplorer1.Configuration.ViewPaths = paths
                    FileExplorer1.Configuration.UploadPaths = paths
                    FileExplorer1.Configuration.DeletePaths = paths
                    FileExplorer1.Configuration.MaxUploadFileSize = (_maxVolume.MaxFileVolume * 1024)
                    FileExplorer1.VisibleControls = GetVisibleControls()
                    'Dim Patern(14) As String
                    'Patern(0) = "*.doc"
                    'Patern(1) = "*.docx"
                    'Patern(2) = "*.xls"
                    'Patern(3) = "*.xlsx"
                    'Patern(4) = "*.pdf"
                    'Patern(5) = "*.txt"
                    'Patern(6) = "*.jpg"
                    'Patern(7) = "*.jpeg"
                    'Patern(8) = "*.bmp"
                    'Patern(9) = "*.png"
                    'Patern(10) = "*.gif"
                    'Patern(11) = "*.ppt"
                    'Patern(12) = "*.pptx"
                    'Patern(13) = "*.pps"
                    'Patern(14) = "*.ppsx"
                    'FileExplorer1.Configuration.SearchPatterns = Patern
                End If
            End If
        End If
    End Sub

    Protected Function GetVisibleControls() As FileExplorer.FileExplorerControls
        Dim explorerControls As FileExplorer.FileExplorerControls = 0
        'explorerControls = explorerControls Or Telerik.Web.UI.FileExplorer.FileExplorerControls.AddressBox
        explorerControls = explorerControls Or FileExplorer.FileExplorerControls.Grid
        explorerControls = explorerControls Or FileExplorer.FileExplorerControls.Toolbar
        explorerControls = explorerControls Or FileExplorer.FileExplorerControls.TreeView
        explorerControls = explorerControls Or FileExplorer.FileExplorerControls.ContextMenus
        ' explorerControls = explorerControls Or FileExplorer.FileExplorerControls.FileList
        'explorerControls = explorerControls Or FileExplorer.FileExplorerControls.ListView
        Return explorerControls

    End Function
End Class

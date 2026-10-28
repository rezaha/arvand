
Partial Class SystemMng_Other_MainGallery
    Inherits AdminBasePage

    Public Property _albumService As IAlbumService
    Public Property _albumImagesService As IAlbumImagesService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'If FormUserGrant.InsertRecord Then
            '    btnAdd.Enabled = True
            'Else
            '    btnAdd.Enabled = False
            'End If

            'If FormUserGrant.UpdateRecord Then
            '    btnSave.Enabled = True
            'Else
            '    btnSave.Enabled = False
            'End If
            AddSystemHistory("نمایش گالری تصاویر", 0)
            Dim Album = _albumService.SearchAlbumImagesByType(0, _securityUser.DivisionId)
            lblAlbumName.Text = Album.PersianName
            hfldAlbumId.Value = Album.AlbumId
            DesignGrid()
        End If
    End Sub

    Protected Sub DesignGrid()
        gridview1.DataSource = _albumImagesService.SearchAlbumImages(hfldAlbumId.Value)
        gridview1.DataBind()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If IsValid Then

            Dim item As New AlbumsImages
            item.AlbumId = hfldAlbumId.Value
            item.ImageAddress = txtImageAddress.Text
            item.LatinDescription = ""
            item.PersianDescription = txtPerDes.Text
            item.Remark = ""
            Dim rowEffect As Boolean = _albumImagesService.AddAlbumImage(item, New Dictionary(Of String, String))
            If (rowEffect) Then
                AddSystemHistory("اضافه کردن تصویر به گالری تصاویر", 1)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                DesignGrid()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
            End If

        End If
    End Sub

    Private Sub clear()
        ImageId.Value = ""
        txtImageAddress.Text = ""
        txtPerDes.Text = ""
        gridview1.SelectedIndex = -1
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsValid And ImageId.Value <> "" Then
            Dim feild = _albumImagesService.GetOneAlbumImages(CLSHash.Decode(ImageId.Value))
            feild.ImageAddress = txtImageAddress.Text
            feild.PersianDescription = txtPerDes.Text
            Dim rowEffect As Integer = _albumImagesService.EditAlbumImage(feild, New Dictionary(Of String, String))
            If (rowEffect) Then
                AddSystemHistory("ویرایش تصویر در گالری تصاویر", 2)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                DesignGrid()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If

        Else
        ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('لطفا یک آیتم را انتخاب کنید');", True)
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
        clear()
        If (e.CommandName = "del") Then

            Dim ImageId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
            Dim feild As AlbumsImages = _albumImagesService.GetOneAlbumImages(ImageId)
            Dim rowEffect As Integer = _albumImagesService.RemoveAlbumImage(feild, New Dictionary(Of String, String))
            If (rowEffect) Then
                AddSystemHistory("حذف تصویر از گالری تصاویر", 3)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                DesignGrid()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If

        ElseIf e.CommandName = "up" Then
        Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
        gridview1.SelectedIndex = SelectRowIndx
        Dim albumImageId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
        Dim MyCls As AlbumsImages = _albumImagesService.GetOneAlbumImages(albumImageId)
        txtImageAddress.Text = MyCls.ImageAddress
        txtPerDes.Text = MyCls.PersianDescription
        ImageId.Value = CLSHash.Encode(MyCls.ImageId.ToString())
        End If
    End Sub


End Class

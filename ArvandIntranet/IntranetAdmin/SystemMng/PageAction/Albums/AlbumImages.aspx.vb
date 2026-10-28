
Partial Class SystemMng_AlbumImages
    Inherits CLS_BASE_MANAGERS

    Dim AlbumObj As New CLSAlbums
    Dim AlbumImagesObj As New CLSAlbumsImages

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If FormUserGrant.InsertRecord Then
                btnAdd.Enabled = True
            Else
                btnAdd.Enabled = False
            End If

            If FormUserGrant.UpdateRecord Then
                btnSave.Enabled = True
            Else
                btnSave.Enabled = False
            End If

            Dim AlbumId As String = Request.QueryString("album")
            If AlbumId <> "" Then
                Dim Album = AlbumObj.GetALBUM(AlbumId)
                lblAlbumName.Text = Album.PersianName
                hfldAlbumId.Value = Album.AlbumId
            End If
            DesignGrid()
        End If
    End Sub

    Protected Sub DesignGrid()
        gridview1.DataSource = AlbumImagesObj.GetAlbumImages(AlbumId:=hfldAlbumId.Value)
        gridview1.DataBind()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If IsValid Then
            If ActionGrant("Insert", "1") Then
                Dim item As New CLSAlbumsImagesItem
                item.Album.AlbumId = hfldAlbumId.Value
                item.ImageAddress = txtImageAddress.Text
                item.LatinDes = ""
                item.PersianDes = txtPerDes.Text
                item.Remark = ""
                Dim rowEffect As Boolean = AlbumImagesObj.InsertAlbumImage(item)
                If (rowEffect) Then
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                    DesignGrid()
                    clear()
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
                End If
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
            If ActionGrant("Update", "1") Then
                Dim feild As New CLSAlbumsImagesItem
                feild.ImageId = CLSHash.Decode(ImageId.Value.ToString())
                feild.Album.AlbumId = hfldAlbumId.Value
                feild.ImageAddress = txtImageAddress.Text
                feild.LatinDes = ""
                feild.PersianDes = txtPerDes.Text
                feild.Remark = ""
                Dim rowEffect As Integer = AlbumImagesObj.UpdateAlbumImages(feild)
                If (rowEffect) Then
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                    DesignGrid()
                    clear()
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
                End If
            End If
        Else
            ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('لطفا یک آیتم را انتخاب کنید');", True)
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
        clear()
        If (e.CommandName = "del") Then
            If ActionGrant("Delete", "1") Then
                Dim ImageId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
                Dim rowEffect As Integer = AlbumImagesObj.DeleteAlbumImages(ImageId)
                If (rowEffect) Then
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                    DesignGrid()
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
                End If
            End If
        ElseIf e.CommandName = "up" Then
            Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
            gridview1.SelectedIndex = SelectRowIndx
            Dim MyCls As CLSAlbumsImagesItem = AlbumImagesObj.GetAlbumImage(CLSHash.Decode(e.CommandArgument.ToString))
            txtImageAddress.Text = MyCls.ImageAddress
            txtPerDes.Text = MyCls.PersianDes
            ImageId.Value = CLSHash.Encode(MyCls.ImageId.ToString())
        End If
    End Sub

End Class

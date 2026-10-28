
Partial Class SystemMng_Albums
    Inherits CLS_BASE_MANAGERS

    Dim AlbumObj As New CLSAlbums

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

            BindGridView()
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If IsValid Then
            If ActionGrant("Insert", "1") Then
                Dim item As New CLSAlbumsItem
                item.AlbumNo = txtAlbumNo.Text
                item.LatinName = txtName_latin.Text
                item.PersianName = txtName_persian.Text
                item.Remark = txtRemark.Text
                item.AlbumImage = txtAlbumImage.Text

                Dim rowEffect As Boolean = AlbumObj.InsertALBUMS(item)

                If (rowEffect) Then
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                    BindGridView()
                    clear()
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
                End If
            End If
        End If
    End Sub

    Protected Sub BindGridView()
        gridview1.DataSource = AlbumObj.GetAlbums(AlbumType:=1)
        gridview1.DataBind()
    End Sub

    Sub clear()
        AlbumId.Value = ""
        txtName_latin.Text = ""
        txtName_persian.Text = ""
        txtRemark.Text = ""
        txtAlbumNo.Text = ""
        txtAlbumImage.Text = ""
        gridview1.SelectedIndex = -1
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
        clear()
        If (e.CommandName = "del") Then
            If ActionGrant("Delete", "1") Then
                Dim AlbumId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
                Dim rowEffect As Integer = AlbumObj.DeleteALBUMS(AlbumId)
                If (rowEffect) Then
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                    BindGridView()
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
                End If
            End If
        ElseIf e.CommandName = "up" Then
            Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
            gridview1.SelectedIndex = SelectRowIndx
            Dim MyCls As CLSAlbumsItem = AlbumObj.GetALBUM(CLSHash.Decode(e.CommandArgument.ToString))
            txtRemark.Text = MyCls.Remark
            txtName_latin.Text = MyCls.LatinName
            txtName_persian.Text = MyCls.PersianName
            txtAlbumNo.Text = MyCls.AlbumNo
            txtAlbumImage.Text = MyCls.AlbumImage
            AlbumId.Value = CLSHash.Encode(MyCls.AlbumId.ToString())
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsValid And AlbumId.Value <> "" Then
            If ActionGrant("Update", "1") Then
                Dim feild As New CLSAlbumsItem
                feild.AlbumId = CLSHash.Decode(AlbumId.Value.ToString())
                feild.LatinName = txtName_latin.Text
                feild.PersianName = txtName_persian.Text
                feild.Remark = txtRemark.Text
                feild.AlbumNo = txtAlbumNo.Text
                feild.AlbumImage = txtAlbumImage.Text
                Dim rowEffect As Integer = AlbumObj.UpdateALBUMS(feild)
                If (rowEffect) Then
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                    BindGridView()
                    clear()
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
                End If
            End If
        Else
            ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('لطفا یک آیتم را انتخاب کنید');", True)
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

End Class

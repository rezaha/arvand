
Partial Class UserControls_WriteCommentWUC
    Inherits BaseUserControl

    Dim OpinionObj As New CLSOpinions

    Protected Sub lbtnInsertComment_Click(sender As Object, e As EventArgs) Handles lbtnInsertComment.Click
        Page.Validate()
        If Page.IsValid Then
            Dim newsId As Integer = Page.RouteData.Values("id").ToString
            Dim item As New CLSOpinionsItem
            item.AdminApprove = False
            item.OpinionContent = txtCommentContent.Text.Trim
            item.OpinionName = txtCommentName.Text.Trim
            item.OpinionEmail = txtEmail.Text.Trim
            item.OpinionSubject = ""
            item.OpinionTime = Date.Now.TimeOfDay.ToString.Substring(0, 5)
            item.OpinionDate = CLSShamsiDate.ShortDate(Now).Substring(2)
            item.Remark = ""
            item.OpinionCompany = ""
            item.OpinionTell = ""
            item.PartId = Integer.Parse(newsId)
            item.AdminRead = False
            item.AdminDelete = False
            item.PartType = "NEWS"
            Dim isEffect As Boolean = OpinionObj.InsertOpinions(item)
            If isEffect Then
                If SiteLanguage = "en" Then
                    lblMsg.Text = "Comment Is Register"
                Else
                    lblMsg.Text = "نظر شما ثبت گردید."
                End If
            Else
                If SiteLanguage = "en" Then
                    lblMsg.Text = "Error. Please Try Again Later"
                Else
                    lblMsg.Text = "خطا در عملیات،لطفا مجددا تلاش کنید."
                End If
            End If
        End If
    End Sub

    Protected Sub lblRewriteComment_Click(sender As Object, e As EventArgs) Handles lblRewriteComment.Click
        txtCommentContent.Text = ""
        txtCommentName.Text = ""
        txtEmail.Text = ""
    End Sub

    'Public ReadOnly Property IsValid As String
    '    Get
    '        RequiredFieldValidator1.Validate()
    '        RegularExpressionValidator1.Validate()
    '        RequiredFieldValidator3.Validate()
    '        Return RequiredFieldValidator1.IsValid And RegularExpressionValidator1.IsValid And RequiredFieldValidator3.IsValid
    '    End Get
    'End Property

End Class

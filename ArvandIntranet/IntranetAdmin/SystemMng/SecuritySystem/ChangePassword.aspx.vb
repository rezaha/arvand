
Partial Class SystemMng_SecuritySystem_ChangePassword
    Inherits AdminBasePage

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If _securityUser.UserPassword.Trim() = txtOldPassword.Text.Trim() Then
            If txtNewPassword.Text.Trim = txtReNewPassword.Text.Trim() Then
                _securityUser.UserPassword = txtNewPassword.Text.Trim()
                _securityUserService.EditSecurityUser(_securityUser)
                AddSystemHistory("ویرایش رمز عبور", 2)
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "alert('کلمه عبور شما با موفقیت تغییر کرد.')", True)
            Else
                ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "alert('کلمه عبور جدید با تکرار آن یکسان نیست.')", True)
            End If
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "1", "alert('کلمه عبور قبلی اشتباه است.')", True)
        End If
    End Sub
End Class

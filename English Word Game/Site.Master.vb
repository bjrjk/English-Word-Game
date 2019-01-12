Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Request.Cookies("game") Is Nothing) Then
            If Request.Cookies("game").Expires < Date.Now Then
                Dim Username As String = DeCryptBase64((Request.Cookies("game").Values("username")))
                LoginStatus.Text = "欢迎" & Username & "登录！"
                LoginStatus.NavigateUrl = "~/Account/ChangePassword.aspx"
                Logout.Visible = True
            End If
        End If
    End Sub

End Class
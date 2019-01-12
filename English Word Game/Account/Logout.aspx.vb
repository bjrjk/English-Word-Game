Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Request.Cookies("game") Is Nothing Then
            Dim RemovedCookie As HttpCookie = Request.Cookies("game")
            RemovedCookie.Values.Remove("username")
            RemovedCookie.Values.Remove("password")
            Dim TS As New TimeSpan(-1, 0, 0, 0, 0)
            RemovedCookie.Expires = Date.Now.Add(TS)
            Response.AppendCookie(RemovedCookie)
        End If
        FormsAuthentication.SignOut()
    End Sub

End Class
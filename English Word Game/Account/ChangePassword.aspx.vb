Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class ChangePassword
    Inherits System.Web.UI.Page

    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSubmit.Click
        If (Not Request.Cookies("game") Is Nothing) OrElse (Not Request.Cookies("game").Values.Count = 0) Then
            If Request.Cookies("game").Expires < Date.Now Then
                If TxtPass.Text <> TxtSure.Text Then
                    LblError.Text = "两次密码不一致，请重新输入！"
                    Exit Sub
                End If
                Dim Username As String = CheckMySQLSyntax(DeCryptBase64((Request.Cookies("game").Values("username"))))
                Dim ConnectionW As New MySqlConnection(MySQLConnectString)
                ConnectionW.Open()
                Dim SQLCommandW As New MySqlCommand("update `users` set `password` = """ & MD5(TxtPass.Text, 32) & """ where `username` = """ & Username & """", ConnectionW)
                SQLCommandW.ExecuteNonQuery()
                ConnectionW.Close()
                Response.Redirect("~/Account/ChangePasswordSuccess.aspx")
            Else
                Response.Redirect("~/Default.aspx")
            End If
        Else
            Response.Redirect("~/Default.aspx")
        End If
    End Sub
End Class
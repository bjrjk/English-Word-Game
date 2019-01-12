Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSubmit.Click
        If TxtUser.Text = "" OrElse TxtPass.Text = "" Then
            LblError.Text = "您的登录信息未填全，请重新填写！"
            Exit Sub
        End If
        Dim Connection As New MySqlConnection(MySQLConnectString)
        Connection.Open()
        Dim SQLCommand As New MySqlCommand("select * from `users` WHERE `username` = """ & CheckMySQLSyntax(TxtUser.Text) & """", Connection)
        Dim MySQLReader As MySqlDataReader = SQLCommand.ExecuteReader()
        If MySQLReader.Read() Then
            If MD5(TxtPass.Text, 32) = MySQLReader("password").ToString Then
                Dim SucceedCookie As New HttpCookie("game")
                Dim ExpireTime As Date = Date.Now
                Dim ExpireTimeSpan As New TimeSpan(0, 2, 0, 0, 0)
                SucceedCookie.Expires = ExpireTime.Add(ExpireTimeSpan)
                SucceedCookie.Values.Add("username", CryptBase64(TxtUser.Text))
                SucceedCookie.Values.Add("password", CryptBase64(MD5(TxtPass.Text, 32)))
                Response.AppendCookie(SucceedCookie)
                FormsAuthentication.SetAuthCookie(CheckMySQLSyntax(TxtUser.Text), False)
                Response.Redirect("~/Default.aspx")
            Else
                LblError.Text = "密码错误，请重新输入！"
                TxtPass.Text = ""
            End If
        Else
            LblError.Text = "无此用户名，请重新输入！"
            TxtUser.Text = ""
            TxtPass.Text = ""
        End If
        MySQLReader.Close()
        Connection.Close()
    End Sub
End Class
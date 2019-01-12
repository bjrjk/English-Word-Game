Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Register
    Inherits System.Web.UI.Page
    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSubmit.Click
        If TxtEmail.Text = "" Or TxtPass.Text = "" Or TxtSure.Text = "" Or TxtUser.Text = "" Then
            LblError.Text = "您的注册信息未填全，请重新填写！"
            Exit Sub
        End If
        If (Not TxtEmail.Text.Contains("@")) Or (Not TxtEmail.Text.Contains(".")) Then
            LblError.Text = "您的Email地址填写不正确，请重新填写！"
            Exit Sub
        End If
        If TxtPass.Text <> TxtSure.Text Then
            LblError.Text = "两次密码不一致，请重新输入！"
            TxtPass.Text = ""
            TxtSure.Text = ""
            Exit Sub
        End If
        Dim ConnectionR As New MySqlConnection(MySQLConnectString)
        ConnectionR.Open()
        Dim SQLCommandR As New MySqlCommand("select * from `users` WHERE `username` = """ & CheckMySQLSyntax(TxtUser.Text) & """", ConnectionR)
        Dim MySQLReader As MySqlDataReader = SQLCommandR.ExecuteReader()
        If MySQLReader.Read() Then
            LblError.Text = "您输入的用户名已经有人注册，请重新输入！"
            TxtUser.Text = ""
            Exit Sub
        End If
        MySQLReader.Close()
        ConnectionR.Close()
        Dim ConnectionW As New MySqlConnection(MySQLConnectString)
        ConnectionW.Open()
        Dim SQLCommandW As New MySqlCommand("INSERT INTO `users` (`username`,`password`,`score`,`email`) VALUES (""" & CheckMySQLSyntax(TxtUser.Text) & """,""" & MD5(TxtPass.Text, 32) & """,0,""" & CheckMySQLSyntax(TxtEmail.Text) & """)", ConnectionW)
        SQLCommandW.ExecuteNonQuery()
        LblError.Text = "您已经成功注册，请登录！页面正在跳转，请稍候……"
        Response.Write("<script type=""text/javascript"">window.setTimeout(""window.location='/Account/Login.aspx'"", 1000);</script>")
        ConnectionW.Close()
    End Sub
End Class
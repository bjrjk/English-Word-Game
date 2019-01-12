Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Score As Long = 0
        If (Not Request.Cookies("game") Is Nothing) Then
            Dim Username As String = CheckMySQLSyntax(DeCryptBase64((Request.Cookies("game").Values("username"))))
            Dim Connection As New MySqlConnection(MySQLConnectString)
            Connection.Open()
            Dim SQLCommand As New MySqlCommand("select * from `users` WHERE `username` = """ & Username & """", Connection)
            Dim MySQLReader As MySqlDataReader = SQLCommand.ExecuteReader()
            If MySQLReader.Read() Then
                Score = Val(MySQLReader("score").ToString)
            End If
            MySQLReader.Close()
            LblUser.Text = "欢迎" & Username & "玩游戏！" & "您的分数为：" & Str(Score) & vbCrLf & "请点击上方导航栏'游戏'玩游戏。"
            LblUser.Visible = True
            TblRank.Visible = True
            Dim SQLCommand2 As New MySqlCommand("select username,score from users order by score desc limit 10", Connection)
            Dim MySQLReader2 As MySqlDataReader = SQLCommand2.ExecuteReader()
            Dim i As Integer = 1
            While MySQLReader2.Read()
                Dim TempRow As New TableRow
                Dim TempUserName As New TableCell
                Dim TempScore As New TableCell
                Dim TempRank As New TableCell
                TempRank.Text = Str(i)
                TempUserName.Text = MySQLReader2("username")
                TempScore.Text = MySQLReader2("score")
                TempRow.Cells.Add(TempRank)
                TempRow.Cells.Add(TempUserName)
                TempRow.Cells.Add(TempScore)
                TblRank.Rows.Add(TempRow)
                i += 1
            End While
            MySQLReader2.Close()
            Connection.Close()
        End If

    End Sub

End Class
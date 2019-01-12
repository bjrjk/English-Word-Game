Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class SWord
    Inherits System.Web.UI.Page
    Dim Username As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Request.Cookies("game") Is Nothing) Then
            FrameMain.SetActiveView(FrameLoggedin)
            Username = CheckMySQLSyntax(DeCryptBase64((Request.Cookies("game").Values("username"))))
            Dim Connection As New MySqlConnection(MySQLConnectString)
            Connection.Open()
            Dim SQLCommand2 As New MySqlCommand("select word,time from sword where username='" & Username & "' order by time desc", Connection)
            Dim MySQLReader2 As MySqlDataReader = SQLCommand2.ExecuteReader()
            Dim i As Integer = 1
            While MySQLReader2.Read()
                Dim TempRow As New TableRow
                Dim TempNo As New TableCell
                Dim TempWord As New TableCell
                Dim TempTime As New TableCell
                TempNo.Text = Str(i)
                TempWord.Text = MySQLReader2("word")
                TempTime.Text = MySQLReader2("time")
                TempRow.Cells.Add(TempNo)
                TempRow.Cells.Add(TempWord)
                TempRow.Cells.Add(TempTime)
                TblRank.Rows.Add(TempRow)
                i += 1
            End While
            MySQLReader2.Close()
            Connection.Close()
        Else
            FrameMain.SetActiveView(FrameAnonymous)
        End If
    End Sub


    Protected Sub BtnGoTraining_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGoTraining.Click
        Dim Str As String = "<form id=""form1"" action=""/Game.aspx"" method=""post""><input type=""hidden"" name=""SWord_UN"" value=""{0}""/></form><script language=""javascript"">document.getElementById('form1').submit();</script>"
        Response.Write(String.Format(Str, Username))
    End Sub

    Protected Sub BtnClearSW_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnClearSW.Click
        Dim ConnectionW As New MySqlConnection(MySQLConnectString)
        ConnectionW.Open()
        Dim SQLCommandW As New MySqlCommand("delete from sword where username='" & Username & "'", ConnectionW)
        SQLCommandW.ExecuteNonQuery()
        ConnectionW.Close()
    End Sub
End Class
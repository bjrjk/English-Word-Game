Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Net

Public Class Game
    Inherits System.Web.UI.Page
    Dim Username As String = ""
    Dim SWord_UN As String = ""
    Dim ListText As String = "{0}拼出了{1}单词，得{2}分。"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Form.DefaultButton = BtnSubmit.ClientID.Replace("_", "$")
        If Not Request.Form("SWord_UN") Is Nothing Or Not LblSword_U.Text = "" Then
            If Not Request.Form("SWord_UN") Is Nothing Then
                SWord_UN = CheckMySQLSyntax(Request.Form("SWord_UN"))
                LblSword_U.Text = SWord_UN
            ElseIf Not LblSword_U.Text = "" Then
                SWord_UN = LblSword_U.Text
            End If
            LblMessage.Text = "错题本模式已开启！"
        End If
        If Not IsPostBack Then
            If (Not Request.Cookies("game") Is Nothing) Then
                Randomize(DateTime.Now.ToOADate())
                FrameMain.SetActiveView(FrameLoggedin)
            Else
                FrameMain.SetActiveView(FrameAnonymous)
            End If
        End If
        If (Not Request.Cookies("game") Is Nothing) Then
            Username = CheckMySQLSyntax(DeCryptBase64((Request.Cookies("game").Values("username"))))
        End If
    End Sub

    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSubmit.Click
        LblTimes.Text = Int(LblTimes.Text) + 1
        If Val(LblTimes.Text) >= 4 Then
            Dim ConnectionW As New MySqlConnection(MySQLConnectString)
            ConnectionW.Open()
            Dim sql As String = "CALL `Update_Sword`('" & Username & "', '" & LblWord.Text & "');"
            Dim SQLCommandW As New MySqlCommand(sql, ConnectionW)
            SQLCommandW.ExecuteNonQuery()
            ConnectionW.Close()
            LblMessage.Text = "您已经三次连续回答错误！该单词为" & LblWord.Text & "。请点击提示按钮查看释义或点击换一组进行下一轮游戏。"
            BtnSubmit.Enabled = False
        ElseIf TxtWord.Text = LblWord.Text Then
            LblMessage.Text = "回答正确！该单词为" & LblWord.Text & "。请继续玩下一小题。"
            PushMessage(String.Format(ListText, Username, LblWord.Text, 1))
            AddScore()
            LblWord.Text = GetWord()
            LblRagPieces.Text = ShapingWord(LblWord.Text)
            TxtWord.Text = ""
            LblTimes.Text = "0"
        Else
            If Trim(TxtWord.Text) = "" Then
                LblMessage.Text = "对不起，单词错误，请重试！"
                Return
            End If
            If Not CompareWords(TxtWord.Text, LblWord.Text) Then
                LblMessage.Text = "对不起，单词错误，请重试！"
                Return
            End If
            Dim ConnectionR As New MySqlConnection(MySQLConnectString)
            ConnectionR.Open()
            Dim SQLCommandR As New MySqlCommand("select * from words where word='" & CheckMySQLSyntax(TxtWord.Text) & "';", ConnectionR)
            Dim MySQLReader As MySqlDataReader = SQLCommandR.ExecuteReader()
            If MySQLReader.Read() Then
                LblMessage.Text = "回答正确！该单词的另一种形式为" & LblWord.Text & "。请继续玩下一小题。"
                PushMessage(String.Format(ListText, Username, LblWord.Text, 1))
                AddScore()
                LblWord.Text = GetWord()
                LblRagPieces.Text = ShapingWord(LblWord.Text)
                TxtWord.Text = ""
                LblTimes.Text = "0"
            Else
                LblMessage.Text = "对不起，单词错误，请重试！"
            End If
            MySQLReader.Close()
            ConnectionR.Close()
        End If
    End Sub

    Private Function GetWord() As String
        Dim ConnectionR As New MySqlConnection(MySQLConnectString)
        ConnectionR.Open()
        Dim SQLCommandR As MySqlCommand
        If SWord_UN = "" Then
            SQLCommandR = New MySqlCommand("select * from words order by rand() limit 1;", ConnectionR)
        Else
            Dim tempSQL As String = String.Format("select word from sword where username='{0}' order by rand() limit 1;", SWord_UN)
            SQLCommandR = New MySqlCommand(tempSQL, ConnectionR)
        End If
        Dim MySQLReader As MySqlDataReader = SQLCommandR.ExecuteReader()
        If MySQLReader.Read() Then
            Return MySQLReader("word").ToString
        End If
        MySQLReader.Close()
        ConnectionR.Close()
        Return "NON_WORD"
    End Function

    Private Function ShapingWord(ByVal Word As String) As String
        Dim CArray() As Char = Word.ToCharArray
        Dim CNArray As New Collection
        CNArray.Clear()
        Dim i As Integer = 0
        While i <= UBound(CArray)
            Dim TempRandom As Integer = RandomInt(0, UBound(CArray) + 1)
            If Not CNArray.Contains(TempRandom) Then
                CNArray.Add(TempRandom, TempRandom)
                i += 1
            End If
        End While
        Dim result As String = ""
        For Each item In CNArray
            result &= CArray(item) & " "
        Next
        Return result
    End Function

    Private Function GetWordMean(ByVal Word As String) As String
        Dim request As WebRequest = WebRequest.Create("http://fanyi.youdao.com/openapi.do?keyfrom=English-Game&key=160587409&type=data&doctype=json&version=1.1&q=" & Word)
        Dim response As WebResponse = request.GetResponse()
        Dim datastream As Stream = response.GetResponseStream
        Dim reader As New StreamReader(datastream)
        Dim responseFromServer As String = reader.ReadToEnd()
        Dim jo As JObject = JsonConvert.DeserializeObject(responseFromServer)
        Dim result As String = jo("translation")(0).ToString & vbCrLf
        For Each item In jo("basic")("explains")
            result &= item.ToString & vbCrLf
        Next
        WithoutWordE(result)
        WithoutWordC(result)
        Return result
    End Function

    Private Function WithoutWordE(ByRef X As String) As Boolean
        Dim a As Integer, b As Integer
        a = InStr(X, "(")
        b = InStr(X, ")")
        If a = 0 Or b = 0 Then
            Return False
        End If
        X = Left(X, a - 1) & Right(X, Len(X) - b)
        If WithoutWordE(X) = False Then Exit Function
    End Function

    Private Function WithoutWordC(ByRef X As String) As Boolean
        Dim a As Integer, b As Integer
        a = InStr(X, "（")
        b = InStr(X, "）")
        If a = 0 Or b = 0 Then
            Return False
        End If
        X = Left(X, a - 1) & Right(X, Len(X) - b)
        If WithoutWordC(X) = False Then Exit Function
    End Function

    Protected Sub BtnChange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnChange.Click
        BtnSubmit.Enabled = True
        LblWord.Text = GetWord()
        LblRagPieces.Text = ShapingWord(LblWord.Text)
        LblTimes.Text = "0"
        TxtWord.Text = ""
    End Sub

    Protected Sub Timer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer.Tick
        Dim ConnectionR As New MySqlConnection(MySQLConnectString)
        ConnectionR.Open()
        Dim SQLCommandR As New MySqlCommand("select messages from messages where time>" & Str(Val(GetCurrentUnixTime()) - Timer.Interval / 1000), ConnectionR)
        Dim MySQLReader As MySqlDataReader = SQLCommandR.ExecuteReader()
        While MySQLReader.Read()
            ListMessage.Items.Add(MySQLReader("messages").ToString())
        End While
        MySQLReader.Close()
        ConnectionR.Close()
        If Not ListMessage.SelectedIndex = ListMessage.Items.Count - 1 Then
            ListMessage.SelectedIndex = ListMessage.Items.Count - 1
        End If

    End Sub

    Private Sub PushMessage(ByVal Message As String)
        Dim ConnectionW As New MySqlConnection(MySQLConnectString)
        ConnectionW.Open()
        Dim sql As String = "INSERT INTO `messages` (`messages`,`time`) VALUES ('" & Message & "',unix_timestamp(now()))"
        Dim SQLCommandW As New MySqlCommand(sql, ConnectionW)
        SQLCommandW.ExecuteNonQuery()
        ConnectionW.Close()
        ListMessage.Items.Add(Message)
    End Sub

    Private Sub FrameMain_ActiveViewChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FrameMain.ActiveViewChanged
        If FrameMain.ActiveViewIndex = 1 Then
            Timer.Enabled = True
            LblWord.Text = GetWord()
            LblRagPieces.Text = ShapingWord(LblWord.Text)
        Else
            Timer.Enabled = False
        End If
    End Sub

    Protected Sub BtnMind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnMind.Click
        LblMessage.Text = GetWordMean(LblWord.Text)
    End Sub

    Private Sub AddScore()
        Dim ConnectionW As New MySqlConnection(MySQLConnectString)
        ConnectionW.Open()
        Dim SQLCommandW As New MySqlCommand("UPDATE users SET score = score + 1 WHERE username = '" & Username & "'", ConnectionW)
        SQLCommandW.ExecuteNonQuery()
        ConnectionW.Close()
    End Sub

    Private Function CompareWords(ByVal Word1 As String, ByVal Word2 As String) As Boolean
        Dim Arr1 = Word1.ToCharArray
        Dim Arr2 = Word2.ToCharArray
        Dim Count1 As Integer = 0
        Dim Count2 As Integer = 0
        For Each item1 In Arr1
            Count1 += Asc(item1)
        Next
        For Each item2 In Arr2
            Count2 += Asc(item2)
        Next
        If Count1 = Count2 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
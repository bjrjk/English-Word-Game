Module MySQLPretendReject
    Public Function CheckMySQLSyntax(ByVal Str As String) As String
        Str = Str.Replace("'", "")
        Str = Str.Replace("""", "")
        Str = Str.Replace("&", "&amp")
        Str = Str.Replace("<", "&lt")
        Str = Str.Replace(">", "&gt")
        Str = Str.Replace("delete", "")
        Str = Str.Replace("update", "")
        Str = Str.Replace("insert", "")
        Str = Str.Replace("select", "")
        Return Str
    End Function
End Module

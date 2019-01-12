Module General
    Public ProjectPath As String = HttpRuntime.AppDomainAppPath
    Public Function MD5(ByVal strSource As String, ByVal Code As Int16) As String
        Dim dataToHash As Byte() = (New System.Text.ASCIIEncoding).GetBytes(strSource)
        Dim hashvalue As Byte() = CType(System.Security.Cryptography.CryptoConfig.CreateFromName("MD5"), System.Security.Cryptography.HashAlgorithm).ComputeHash(dataToHash)
        Dim ATR As String = ""
        Dim i As Integer
        Select Case Code
            Case 16      '选择16位字符的加密结果     
                For i = 4 To 11
                    ATR &= Hex(hashvalue(i)).PadLeft(2, "0").ToLower

                Next
            Case 32      '选择32位字符的加密结果     
                For i = 0 To 15
                    ATR &= Hex(hashvalue(i)).PadLeft(2, "0").ToLower
                Next
            Case Else       'Code错误时，返回全部字符串，即32位字符     
                For i = 0 To 15
                    ATR &= Hex(hashvalue(i)).PadLeft(2, "0").ToLower
                Next
        End Select
        Return ATR
    End Function

    Public Function CryptBase64(ByVal Str As String) As String
        If Str Is Nothing Then
            Return Str
        End If
        Dim ByteArray As Byte()
        ByteArray = System.Text.Encoding.Default.GetBytes(Str)
        Return Convert.ToBase64String(ByteArray)
    End Function

    Public Function DeCryptBase64(ByVal Str As String) As String
        If Str Is Nothing Then
            Return Str
        End If
        Dim ByteArray As Byte()
        ByteArray = Convert.FromBase64String(Str)
        Return System.Text.Encoding.Default.GetString(ByteArray)
    End Function

    Public Function RandomInt(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim rd As New Random
        Return rd.Next(Min, Max)
    End Function

    Public Function GetCurrentUnixTime() As String
        Return Str((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000)
    End Function
End Module

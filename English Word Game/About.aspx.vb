Public Class About
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Request.Cookies("game") Is Nothing) Then
            Dim Username As String = CheckMySQLSyntax(DeCryptBase64((Request.Cookies("game").Values("username"))))
            If Username = "bjrjk" Then
                LblDebug.Text = "DebugInfo:" & vbCrLf & "ProjectPath:" & ProjectPath & vbCrLf
                LblDebug.Visible = True
            End If
        End If
    End Sub

End Class
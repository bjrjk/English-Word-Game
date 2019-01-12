<%@ Page Title="更改密码" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="ChangePasswordSuccess.aspx.vb" Inherits="English_Word_Game.ChangePasswordSuccess" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 align="center">
        更改密码
    </h2>
    <p align="center">
        您的密码已成功更改，请您重新登录。页面将自动跳转，请稍候……</p>
        <script type="text/javascript">
            window.setTimeout("window.location='/Account/Logout.aspx'", 500);
        </script>
</asp:Content>

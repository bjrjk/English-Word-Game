<%@ Page Title="登出" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Logout.aspx.vb" Inherits="English_Word_Game.Logout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2 align="center">您已登出！</h2>
<p align="center">即将跳转回首页！</p>
<script type="text/javascript">
    window.setTimeout("window.location='/Default.aspx'", 500);
        </script>
</asp:Content>

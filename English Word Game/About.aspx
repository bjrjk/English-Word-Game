<%@ Page Title="关于我们" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="About.aspx.vb" Inherits="English_Word_Game.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 align="center">
        关于
    </h2>
    <p align="center">
        英语单词小游戏，由任骥恺制作。</p>
    <p align="center">
        <asp:Label ID="LblDebug" runat="server" Visible="False"></asp:Label>
    </p>
</asp:Content>

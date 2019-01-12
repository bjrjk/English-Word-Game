<%@ Page Title="主页" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.vb" Inherits="English_Word_Game._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 align="center">
        欢迎来到英语单词小游戏！</h2>
        <div align="center">
            <asp:Label ID="LblUser" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <asp:Table ID="TblRank" runat="server" BorderStyle="Solid" CaptionAlign="Top" 
                Visible="False" GridLines="Both">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server" HorizontalAlign="Center">排行榜</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">排名</asp:TableCell>
                    <asp:TableCell runat="server">用户名</asp:TableCell>
                    <asp:TableCell runat="server">分数</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
    </div>

    </asp:Content>

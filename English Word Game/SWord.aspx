<%@ Page Title="错题本" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="SWord.aspx.vb" Inherits="English_Word_Game.SWord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">

    <asp:MultiView ID="FrameMain" runat="server" ActiveViewIndex="0">
    <asp:View ID="FrameAnonymous" runat="server">
    <h2 align="center">请先点击右上角注册或登录！</h2>
    </asp:View>
        <asp:View ID="FrameLoggedin" runat="server">
        <p>您的错题本：</p>

            <div align="center">
                <asp:Table ID="TblRank" runat="server" BorderStyle="Solid" CaptionAlign="Top" 
                    GridLines="Both">
                    <asp:TableRow runat="server">
                        <asp:TableCell runat="server">序号</asp:TableCell>
                        <asp:TableCell runat="server">单词</asp:TableCell>
                        <asp:TableCell runat="server">错误次数</asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Button ID="BtnGoTraining" runat="server" Text="去训练" />
                <asp:Button ID="BtnClearSW" runat="server" Text="清除错题本" />
            </div>

        </asp:View>
    </asp:MultiView>

</div>
</asp:Content>

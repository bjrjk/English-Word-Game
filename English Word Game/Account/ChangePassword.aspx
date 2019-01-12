<%@ Page Title="更改密码" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="ChangePassword.aspx.vb" Inherits="English_Word_Game.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 align="center">
        更改密码
    </h2>
    <p align="center">
        请使用以下表单更改密码。
    </p>
    <p align="center">
         <asp:Label ID="LblError" runat="server" Font-Bold="True" Font-Italic="True" 
             Font-Size="Medium" ForeColor="Blue"></asp:Label>
     </p>
    <p align="center">
        <asp:Label ID="LblPass" runat="server" Text="密码："></asp:Label>
        <asp:TextBox ID="TxtPass" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
    </p>
    <p align="center">
        <asp:Label ID="LblSure" runat="server" Text="确认密码："></asp:Label>
        <asp:TextBox ID="TxtSure" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
    </p>
    <p align="center">
        <asp:Button ID="BtnSubmit" runat="server" Text="提交" />
    </p>
    </asp:Content>
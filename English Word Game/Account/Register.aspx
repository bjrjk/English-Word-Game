<%@ Page Title="注册" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Register.aspx.vb" Inherits="English_Word_Game.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 align="center">注册账户</h2>
     <p align="center">

         <asp:Label ID="LblError" runat="server" Font-Bold="True" Font-Italic="True" 
             Font-Size="Medium" ForeColor="Blue"></asp:Label>

     </p>
    <p align="center">
        <asp:Label ID="LblUser" runat="server" Text="用户名："></asp:Label>
        <asp:TextBox ID="TxtUser" runat="server" MaxLength="20"></asp:TextBox>
    </p>
    <p align="center">
        <asp:Label ID="LblEmail" runat="server" Text="电子邮箱："></asp:Label>
        <asp:TextBox ID="TxtEmail" runat="server" MaxLength="50" TextMode="Email"></asp:TextBox>
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
        
        <asp:Button ID="BtnSubmit" runat="server" Text="注册" />
        
    </p>
    </asp:Content>
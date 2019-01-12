<%@ Page Title="登录" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeBehind="Login.aspx.vb" Inherits="English_Word_Game.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 align="center">
        登录
    </h2>
    <p align="center">
        请输入用户名和密码。如果您没有帐户请<asp:HyperLink ID="RegisterHyperLink" runat="server" 
            Font-Bold="True" ForeColor="Red" 
            NavigateUrl="~/Account/Register.aspx">注册</asp:HyperLink> 。
     </p>
     <p align="center">
         <asp:Label ID="LblError" runat="server" Font-Bold="True" Font-Italic="True" 
             Font-Size="Medium" ForeColor="Blue"></asp:Label>
     </p>
    <p align="center">
        <asp:Label ID="LblUser" runat="server" Text="用户名："></asp:Label>
        <asp:TextBox ID="TxtUser" runat="server"></asp:TextBox>
        </p>
    <p align="center">
        <asp:Label ID="LblPass" runat="server" Text="密码："></asp:Label>
        <asp:TextBox ID="TxtPass" runat="server" TextMode="Password"></asp:TextBox>
        </p>
    <p align="center">
        <asp:Button ID="BtnSubmit" runat="server" style="width: 40px" Text="登录" />
        </p>
</asp:Content>
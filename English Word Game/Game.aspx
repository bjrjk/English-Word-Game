<%@ Page Title="游戏界面" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Game.aspx.vb" Inherits="English_Word_Game.Game" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<script type="text/javascript">
setTimeout( function(){
  try{
    document.getElementById('MainContent_TxtWord').focus();
  } catch(e){}
}, 500);</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server">
                        </asp:ScriptManager>
    <asp:MultiView ID="FrameMain" runat="server" ActiveViewIndex="0">
    <asp:View ID="FrameAnonymous" runat="server">
    <h2 align="center">请先点击右上角注册或登录！<asp:Label ID="LblWord" runat="server" 
            Visible="False"></asp:Label>
        <asp:Label ID="LblTimes" runat="server" Text="0" Visible="False"></asp:Label>
        <asp:Label ID="LblSword_U" runat="server"></asp:Label>
        </h2>
    </asp:View>
        <asp:View ID="FrameLoggedin" runat="server">
        <div style="float:inherit;margin:0 auto;width:auto;height:100%">
            <div style="float:left; width:65%; height:100%" align="center">
                
                <asp:Label ID="LblRemind3" runat="server" Font-Bold="True" Font-Size="Medium" 
                    Height="40px" Text="提示信息：" Width="15%"></asp:Label>
                <asp:Label ID="LblMessage" runat="server" BorderColor="#0066FF" 
                    BorderStyle="Dotted" Height="40px" Width="75%" BackColor="Yellow" 
                    EnableViewState="False"></asp:Label>
                
                <br />
                <br />
                <asp:Label ID="LblRemind1" runat="server" Font-Size="Medium" Height="25px" 
                    Text="单词：" Width="10%"></asp:Label>
                <asp:TextBox ID="TxtWord" runat="server" Font-Size="Medium" Height="25px" 
                    Width="25%"></asp:TextBox>
                <asp:Button ID="BtnSubmit" runat="server" Height="25px" Text="提交" Width="10%" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnChange" runat="server" Height="25px" Text="换一组" 
                    Width="10%" />
&nbsp;
                <asp:Button ID="BtnMind" runat="server" Height="25px" Text="提示" Width="10%" />
                <br />
                <br /><br />
                <asp:Label ID="LblRemind2" runat="server" Font-Size="Large" Height="30px" 
                    Text="字母:" Width="15%"></asp:Label>
                <asp:Label ID="LblRagPieces" runat="server" BorderStyle="Double" 
                    Font-Bold="True" Font-Overline="False" Font-Size="Large" Font-Underline="True" 
                    Height="30px" Width="80%"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <br />
                
            </div>
            <div style="float:left; width:35%;height:100%;" align="center">
                
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                    <ContentTemplate>
                        
                        <asp:Timer ID="Timer" runat="server" Interval="1000" Enabled="False">
                        </asp:Timer>
                        <asp:ListBox ID="ListMessage" runat="server" Height="200px" Width="100%">
                            <asp:ListItem>单词记录：</asp:ListItem>
                        </asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
            </div>
            </div>

        </asp:View>
    </asp:MultiView>
</asp:Content>

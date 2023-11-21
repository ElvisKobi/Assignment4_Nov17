<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="Assignment4_Nov17.Logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
&nbsp; <span class="auto-style1">&nbsp;Login</span></p>
&nbsp;&nbsp; Username:&nbsp;&nbsp;
<asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
&nbsp;<p>
</p>
<p>
&nbsp;&nbsp; Password:&nbsp;&nbsp; &nbsp;<asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
</p>
<p>
    &nbsp;</p>
<asp:Label ID="errorlbl" runat="server" ForeColor="Red"></asp:Label>
<p>
    &nbsp;<asp:Button ID="loginbtn" runat="server" OnClick="loginbtn_Click" Text="Login" />
</p>
<p>
    <br />
</p>
<p>
</p>
<p>
</p>
<p>
</p>
</asp:Content>

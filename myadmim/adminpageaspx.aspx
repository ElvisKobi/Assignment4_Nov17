<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adminpageaspx.aspx.cs" Inherits="Assignment4_Nov17.myadmim.adminpageaspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <span style="font-size: x-large">Administrator</span></p>
<p>
        <span style="font-size: large"><strong>Member Table</strong></span><br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
    <p style="font-size: large">
        <strong>Instructor Table</strong></p>
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    <p style="font-size: large">
        &nbsp;</p>
    <p>
        <strong>Add User</strong></p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="usernameTextBox" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="User Type"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="usertypeDropDown" runat="server">
            <asp:ListItem>Member</asp:ListItem>
            <asp:ListItem>Instructor</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT * FROM [NetUser]"></asp:SqlDataSource>
    </p>
<p>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT * FROM [Section]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:Label ID="Label8" runat="server" Text="First Name"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="MemberFirstNameTxt" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label6" runat="server" Text="Last Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="MemberLastNameTxt" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label4" runat="server" Text="Phone"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="MemberPhoneTxt" runat="server" TextMode="Phone"></asp:TextBox>
</p>
<p>
    <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="MemberEmailTxt" runat="server" TextMode="Email"></asp:TextBox>
</p>
<p>
    <asp:Button ID="MemberCreateBtn" runat="server" Height="43px" OnClick="MemberCreateBtn_Click" Text="Add" Width="152px" />
</p>
    <p>
        <asp:Label ID="errorlbl" runat="server"></asp:Label>
    </p>
   <br />
<span class="auto-style2"><strong>Add Member to Section</strong><br />
</span>
    <br />
<p>
    Member ID:&nbsp;&nbsp;<asp:TextBox ID="MemberIdTextBox" runat="server"></asp:TextBox>
&nbsp;<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT * FROM [Member]"></asp:SqlDataSource>
</p>
<p>
    Instructor ID:&nbsp;
    <asp:TextBox ID="InstructorIdTextBox" runat="server"></asp:TextBox>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:KarateSchoolConnectionString %>" SelectCommand="SELECT * FROM [Instructor]"></asp:SqlDataSource>
</p>
<p>
    Section Name:&nbsp;
    <asp:DropDownList ID="sectionNameDrpDwn" runat="server">
        <asp:ListItem>Karate Age-Uke</asp:ListItem>
        <asp:ListItem>Karate Chudan-Uke</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    Section Fee:&nbsp;
    <asp:TextBox ID="sectionFeeTxt" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Button ID="sectionBtn" runat="server" Height="40px" OnClick="sectionBtn_Click" Text="Create Section" Width="155px" />
</p>
<asp:Label ID="SectionError" runat="server"></asp:Label>
<p style="font-size: medium">
    &nbsp;</p>
<p>
    <asp:Label ID="Label12" runat="server" Text="User Name"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="DeleteTextBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="DeleteBtn" runat="server" OnClick="DeleteBtn_Click" Text="Delete" />
    </p>
    <p>
        <asp:Label ID="deleteError" runat="server"></asp:Label>
    </p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
</asp:Content>

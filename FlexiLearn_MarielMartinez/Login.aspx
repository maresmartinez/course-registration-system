<%@ Page Title="" Language="C#" MasterPageFile="~/FlexiLearn.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FlexiLearn_MarielMartinez.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="LoginForm" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Login</h1>
    <p>Don't have an account? <asp:HyperLink ID="HLRegister" runat="server" href="./GetMembership.aspx">Create an account here.</asp:HyperLink></p>
    <form id="loginForm" runat="server">
        <div>
            <asp:Label ID="LblUsername" runat="server" Text="Username"></asp:Label>
            <asp:RequiredFieldValidator ID="ReqUsername" runat="server" ControlToValidate="TxtUsername" Display="Dynamic" ErrorMessage="(Username is required)" ForeColor="#983625"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
            <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
            <asp:RequiredFieldValidator ID="ReqPassword" runat="server" ControlToValidate="TxtPassword" Display="Dynamic" ErrorMessage="(Password is required)" ForeColor="#983625"></asp:RequiredFieldValidator>
            <asp:TextBox ID="TxtPassword" runat="server"></asp:TextBox>
            <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
        </div>
    </form>
</asp:Content>

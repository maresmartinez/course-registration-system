<%@ Page Title="" Language="C#" MasterPageFile="~/FlexiLearn.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FlexiLearn_MarielMartinez.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="LoginForm" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Login</h1>
    <p>Don't have an account? <asp:HyperLink ID="HLRegister" runat="server" href="./GetMembership.aspx">Create an account here.</asp:HyperLink></p>
    <div>
        <asp:Label ID="LblFail" runat="server" ForeColor="#983625"></asp:Label>
        <br />
        <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqEmail" runat="server" ControlToValidate="TxtEmail" Display="Dynamic" ErrorMessage="(Email is required)" ForeColor="#983625" ValidationGroup="Login"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
        <asp:Label ID="LblPassword" runat="server" Text="Password"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqPassword" runat="server" ControlToValidate="TxtPassword" Display="Dynamic" ErrorMessage="(Password is required)" ForeColor="#983625" ValidationGroup="Login"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" ValidationGroup="Login" />
    </div>
</asp:Content>

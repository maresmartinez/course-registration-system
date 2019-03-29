<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/FlexiLearnAdmin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="FlexiLearn_MarielMartinez.Admins.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Admin Dashboard</h1>
    <p>This page displays all user requests.</p>
    <asp:GridView ID="GVRegistrationRequests" runat="server"></asp:GridView>
</asp:Content>

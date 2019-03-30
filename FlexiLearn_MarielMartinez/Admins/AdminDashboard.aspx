<%@ Page Title="" Language="C#" MasterPageFile="~/Admins/FlexiLearnAdmin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="FlexiLearn_MarielMartinez.Admins.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Admin Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Admin Dashboard</h1>
    <p>This page displays all user requests.</p>
    <asp:GridView ID="GVRegistrationRequests" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="ChkSelected" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HiddenField ID="HFID" runat="server" Value='<%#Eval("ID") %>'/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="RegistrationUser.Name" HeaderText ="Register Name" />
            <asp:BoundField DataField="RegistrationCourse.Title" HeaderText ="Course Title" />
            <asp:BoundField DataField="RegistrationStatus" HeaderText ="Status" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnAccept" runat="server" Text="Accept Selected Requests" OnClick="BtnAccept_Click" />
    <asp:Button ID="BtnReject" runat="server" Text="Reject Selected Requests" OnClick="BtnReject_Click" />
</asp:Content>

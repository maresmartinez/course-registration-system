<%@ Page Title="" Language="C#" MasterPageFile="~/Members/FlexiLearnMember.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="FlexiLearn_MarielMartinez.Members.UserDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>User Dashboard</h1>
    <p>This page will show the details of any registration requests you have submitted.</p>
    <asp:GridView ID="GVRegistrationRequests" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="ChkDeleteRequest" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField Visible="false">
                <ItemTemplate>
                    <asp:HiddenField ID="HFID" runat="server" Value='<%#Eval("ID") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="RegistrationCourse.CourseCode" HeaderText ="Course Code" />
            <asp:BoundField DataField="RegistrationCourse.Title" HeaderText ="Course Title" />
            <asp:BoundField DataField="RegistrationStatus" HeaderText ="Status" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnRemove" runat="server" Text="Remove Request"  OnClick="BtnRemove_Click"/>
</asp:Content>

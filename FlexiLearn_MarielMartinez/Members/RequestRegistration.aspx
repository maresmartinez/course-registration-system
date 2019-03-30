<%@ Page Title="" Language="C#" MasterPageFile="~/Members/FlexiLearnMember.Master" AutoEventWireup="true" CodeBehind="RequestRegistration.aspx.cs" Inherits="FlexiLearn_MarielMartinez.Members.RequestRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Request Registration</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Request Registration</h1>
    <h3 style="margin-left: 5px;">Filter By</h3>
    <div>
        <asp:Label ID="LblTitle" runat="server" Text="Title"></asp:Label>
        <asp:TextBox ID="TxtTitle" runat="server"></asp:TextBox>

        <asp:Label ID="LblSubject" runat="server" Text="Subject"></asp:Label>
        <asp:TextBox ID="TxtSubject" runat="server"></asp:TextBox>

        <asp:Label ID="LblMaxDuration" runat="server" Text="MaxDuration"></asp:Label>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="TxtMaxDuration" Display="Dynamic" ErrorMessage="(Max Duration must be greater than 0)" ForeColor="#983625" MaximumValue="999999999" MinimumValue="1" ValidationGroup="Filter"></asp:RangeValidator>
        <asp:TextBox ID="TxtMaxDuration" runat="server" TextMode="Number"></asp:TextBox>

        <asp:Label ID="LblMaxFee" runat="server" Text="Max Fee"></asp:Label>
        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TxtMaxFee" Display="Dynamic" ErrorMessage="(Max fee must be greater than 0)" ForeColor="#983625" MaximumValue="999999999" MinimumValue="1" ValidationGroup="Filter"></asp:RangeValidator>
        <asp:TextBox ID="TxtMaxFee" runat="server" TextMode="Number"></asp:TextBox>

        <asp:Button ID="BtnFilter" runat="server" Text="Filter" ValidationGroup="Filter" OnClick="BtnFilter_Click" />
        <asp:Button ID="BtnShowAll" runat="server" Text="Show All" OnClick="BtnShowAll_Click" />
    </div>
    <asp:Label ID="LblInstructions" runat="server" Text="Select Course to Register for:"></asp:Label>
    <asp:GridView ID="GVCourses" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="ChkSelectCourse" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="CourseCode" HeaderText ="Course Code" />
            <asp:BoundField DataField="Title" HeaderText ="Course Title" />
            <asp:BoundField DataField="Subject" HeaderText ="Subject" />
            <asp:BoundField DataField="Duration" HeaderText ="Duration (Hours)" />
            <asp:BoundField DataField="Fee" HeaderText ="Fee ($)" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="BtnAdd" runat="server" Text="Register for Selected Classes" OnClick="BtnAdd_Click" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/FlexiLearn.Master" AutoEventWireup="true" CodeBehind="GetMembership.aspx.cs" Inherits="FlexiLearn_MarielMartinez.GetMembership" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Get Membership</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Create an Account</h1>
    <div>
        <asp:Label ID="LblName" runat="server" Text=" * Name"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqName" runat="server" ControlToValidate="TxtName" Display="Dynamic" ErrorMessage="(Username is required)" ForeColor="#983625" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>

        <asp:Label ID="LblEmail" runat="server" Text=" * Email"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqEmail" runat="server" ControlToValidate="TxtEmail" Display="Dynamic" ErrorMessage="(Email is required)" ForeColor="#983625" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegexEmail" runat="server" ControlToValidate="TxtEmail" Display="Dynamic" ErrorMessage="(Email must be a in valid address format, e.g. me@me.com)" ForeColor="#983625" ValidationExpression="(?!.*\.\.)(^[^\.][^@\s]+@[^@\s]+\.[^@\s\.]+$)" ValidationGroup="CreateAccount"></asp:RegularExpressionValidator>
        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>

        <asp:Label ID="LblPhone" runat="server" Text="Phone Number ( (555)555-5555 )"></asp:Label>
        <asp:RegularExpressionValidator ID="RegexPhone" runat="server" ControlToValidate="TxtPhone" Display="Dynamic" ErrorMessage="(Phone Number must be in the format (555)555-5555)" ForeColor="#983625" ValidationExpression="^\(?\d\d\d\)?\d\d\d\-?\d\d\d\d$" ValidationGroup="CreateAccount"></asp:RegularExpressionValidator>
        <asp:TextBox ID="TxtPhone" runat="server"></asp:TextBox>

        <asp:Label ID="LblEducation" runat="server" Text=" * Education Level"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqEducation" runat="server" ControlToValidate="DDEducation" Display="Dynamic" ErrorMessage="(Education Level is required)" ForeColor="#983625" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
        <asp:DropDownList ID="DDEducation" runat="server"></asp:DropDownList>

        <asp:Label ID="LblBirthday" runat="server" Text=" * Birthday (yyyy-MM-dd)"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqBirthday" runat="server" ControlToValidate="TxtBirthday" Display="Dynamic" ErrorMessage="(Birthday is required)" ForeColor="#983625" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegexBirthday" runat="server" ControlToValidate="TxtBirthday" Display="Dynamic" ErrorMessage="(Birthday must be in the format yyyy-MM-dd)" ForeColor="#983625" ValidationExpression="^\d\d\d\d\-?\d\d\-?\d\d$" ValidationGroup="CreateAccount"></asp:RegularExpressionValidator>
        <asp:TextBox ID="TxtBirthday" runat="server"></asp:TextBox>
            
        <asp:Label ID="LblPassword" runat="server" Text=" * Password"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqPassword" runat="server" ControlToValidate="TxtPassword" Display="Dynamic" ErrorMessage="(Password is required)" ForeColor="#983625" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CmpPasswords" runat="server" ControlToCompare="TxtPasswordRepeat" ControlToValidate="TxtPassword" Display="Dynamic" ErrorMessage="(Passwords must match)" ForeColor="#983625" ValidationGroup="CreateAccount"></asp:CompareValidator>
        <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
            
        <asp:Label ID="LblConfirmPassword" runat="server" Text=" * Confirm Password"></asp:Label>
        <asp:RequiredFieldValidator ID="ReqConfirmPassword" runat="server" ControlToValidate="TxtPasswordRepeat" Display="Dynamic" ErrorMessage="(Confirm Password is required)" ForeColor="#983625" ValidationGroup="CreateAccount"></asp:RequiredFieldValidator>
        <asp:TextBox ID="TxtPasswordRepeat" runat="server" TextMode="Password"></asp:TextBox>
            
        <br /><asp:Button ID="BtnCreate" runat="server" Text="Create Account" OnClick="BtnCreate_Click" ValidationGroup="CreateAccount" />
    </div>
</asp:Content>

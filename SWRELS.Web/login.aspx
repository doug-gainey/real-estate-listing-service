<%@ Page Title="" Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<%@ Register TagPrefix="uc" TagName="TextField" Src="~/controls/textfield.ascx" %>
<asp:Content ID="cntLeftColumn" ContentPlaceHolderID="cphLeftColumn" runat="Server">
    <uc:TextField Id="tfUserName" Label="User Name" Required="true" runat="server" />
    <uc:TextField Id="tfPassword" Label="Password" Required="true" TextMode="Password" runat="server" />
    <div class="datafield">
        <asp:Button ID="btnSignIn" Text="Sign In" OnClick="btnSignIn_Click" runat="server" />
    </div>
</asp:Content>

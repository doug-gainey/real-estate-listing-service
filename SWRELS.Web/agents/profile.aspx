<%@ Page Title="Agent Profile" Language="C#" MasterPageFile="~/agents/agent.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="agents_profile" %>

<%@ Register TagPrefix="uc" TagName="TextField" Src="~/controls/textfield.ascx" %>
<%@ Register TagPrefix="uc" TagName="ListField" Src="~/controls/listfield.ascx" %>
<asp:Content ID="cntHead" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function validateCancelation() {
            if (!confirm('Are you sure you want to cancel your SWRELS.com agent account?'))
                return false;
            return true;
        }

        function changePassword() {
            var password = $('#password');
            if (!password.is(':visible'))
                password.slideDown('slow');
            else
                password.slideUp('slow');
        }
    </script>
</asp:Content>
<asp:Content ID="cntContentArea" ContentPlaceHolderID="cphContentArea" runat="Server">
    <div class="leftcolumn">
        <h1>Agent Information</h1>
        <div class="datafield">
            <strong>User Name:</strong>
            <asp:Label ID="lblUserName" runat="server" />
        </div>
        <uc:TextField ID="tfFirstName" Label="First Name" MaxLength="30" Required="true" runat="server" />
        <uc:TextField ID="tfLastName" Label="Last Name" MaxLength="30" Required="true" runat="server" />
        <uc:TextField ID="tfLicenseNumber" Label="Agent License Number" Required="true" runat="server" />
        <uc:TextField ID="tfAgencyName" Label="Agency Name" MaxLength="50" Required="true" runat="server" />
        <uc:TextField ID="tfAddress" Label="Address" MaxLength="50" Required="true" runat="server" />
        <uc:TextField ID="tfCity" Label="City" MaxLength="50" Required="true" runat="server" />
        <uc:ListField ID="lfState" Label="State" Required="true" runat="server">
            <asp:ListItem Value="">- Select State -</asp:ListItem>
        </uc:ListField>
        <uc:TextField ID="tfZipCode" Label="ZIP Code" MaxLength="5" ValidationExpression="^\d{5}$" Format="12345" Required="true" runat="server" />
        <uc:TextField ID="tfPhoneNumber" Label="Phone Number" MaxLength="12" ValidationExpression="^\d{3}-\d{3}-\d{4}$" Format="123-456-7890" Required="true" runat="server" />
        <uc:TextField ID="tfFaxNumber" Label="Fax Number" MaxLength="12" ValidationExpression="^\d{3}-\d{3}-\d{4}$" Format="123-456-7890" runat="server" />
        <uc:TextField ID="tfEmailAddress" Label="Email Address" MaxLength="50" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Format="name@domain.com" Required="true" runat="server" />
    </div>
    <div class="rightcolumn">
        <h1>Billing Information</h1>
        <uc:ListField ID="lfRenewal" Label="Billing Period" Required="true" runat="server">
            <asp:ListItem Value="">- Select Billing Period -</asp:ListItem>
            <asp:ListItem Value="1">Monthly</asp:ListItem>
            <asp:ListItem Value="12">Yearly</asp:ListItem>
        </uc:ListField>
        <!--
        <asp:ListItem Value="3">Quarterly</asp:ListItem>
        <asp:ListItem Value="6">Bi-Annually</asp:ListItem>
        -->
        <uc:TextField ID="tfCreditCardFirstName" Label="Credit Card First Name" MaxLength="30" Required="true" runat="server" />
        <uc:TextField ID="tfCreditCardLastName" Label="Credit Card Last Name" MaxLength="30" Required="true" runat="server" />
        <uc:ListField ID="lfCreditCardType" Label="Credit Card Type" Required="true" runat="server">
            <asp:ListItem Value="">- Select Credit Card Type -</asp:ListItem>
            <asp:ListItem>MasterCard</asp:ListItem>
            <asp:ListItem>Visa</asp:ListItem>
            <asp:ListItem>Discover</asp:ListItem>
        </uc:ListField>
        <uc:TextField ID="tfCreditCardNumber" Label="Credit Card Number" MaxLength="16" ValidationExpression="^(\d{16})|(\*{12}\d{4})$" Format="1234123412341234" Required="true" runat="server" />
        <div>
            <strong>Credit Card Expiration Date</strong> <span class="required">*</span></div>
        <uc:ListField ID="lfCreditCardExpirationMonth" Label="Credit Card Expiration Month" CssClass="inline hidelabel" Required="true" runat="server">
            <asp:ListItem Value="">- Month -</asp:ListItem>
        </uc:ListField>
        <uc:ListField ID="lfCreditCardExpirationYear" Label="Credit Card Expiration Year" CssClass="hidelabel" Required="true" runat="server">
            <asp:ListItem Value="">- Year -</asp:ListItem>
        </uc:ListField>
        <uc:TextField ID="tfCreditCardSecurityCode" Label="Credit Card Security Code" MaxLength="4" Required="true" runat="server" />
        <h1>Account Options</h1>
        <div class="datafield">
            <a href="javascript:changePassword()">Change Password</a>
        </div>
        <div id="password" class="hidden">
            <uc:TextField ID="tfNewPassword" Label="New Password" MaxLength="8" TextMode="Password" runat="server" />
            <uc:TextField ID="tfConfirmPassword" Label="Confirm New Password" MaxLength="8" TextMode="Password" runat="server" />
            <asp:CompareValidator ID="cpvPassword" ControlToValidate="tfConfirmPassword" ControlToCompare="tfNewPassword" Operator="Equal" ErrorMessage="Password and Confirm Password do not match." Display="None" runat="server" />
        </div>
        <div class="datafield">
            <asp:LinkButton ID="btnCancelAccount" OnClick="btnCancelAccount_Click" OnClientClick="return validateCancelation()" CausesValidation="false" runat="server">Cancel Account</asp:LinkButton>
        </div>
    </div>
    <div class="buttons">
        <asp:Button ID="btnSave" Text="Save" OnClick="btnSave_Click" runat="server" />
    </div>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeFile="textfield.ascx.cs" Inherits="TextField" %>
<div id="<%=ClientID %>" class="datafield <%=CssClass %>">
    <asp:Label ID="lblLabel" AssociatedControlID="tbxTextBox" runat="server" />
    <asp:Label ID="lblRequired" CssClass="required" Visible="false" runat="server">*</asp:Label>
    <asp:RequiredFieldValidator ID="reqRequired" ControlToValidate="tbxTextBox" SetFocusOnError="true" Display="None" Visible="false" runat="server" />
    <asp:RegularExpressionValidator ID="regRegEx" ControlToValidate="tbxTextBox" SetFocusOnError="true" Display="None" Visible="false" runat="server" />
    <asp:CompareValidator ID="cmpCompare" ControlToValidate="tbxTextBox" SetFocusOnError="true" Display="None" Visible="false" runat="server" /><br />
    <asp:TextBox ID="tbxTextBox" CssClass="textbox" runat="server" />
</div>
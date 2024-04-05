<%@ Control Language="C#" AutoEventWireup="true" CodeFile="listfield.ascx.cs" Inherits="ListField" %>
<div id="<%=ClientID %>" class="datafield <%=CssClass %>">
    <asp:Label ID="lblLabel" AssociatedControlID="ddlList" runat="server" />
    <asp:Label ID="lblRequired" CssClass="required" Visible="false" runat="server">*</asp:Label>
    <asp:RequiredFieldValidator ID="reqRequired" ControlToValidate="ddlList" SetFocusOnError="true" Display="None" Visible="false" runat="server" /><br />
    <asp:DropDownList ID="ddlList" CssClass="listbox" runat="server" />
</div>
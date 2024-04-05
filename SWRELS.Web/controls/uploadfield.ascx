<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uploadfield.ascx.cs" Inherits="UploadField" %>
<div id="<%=ClientID %>" class="datafield <%=CssClass %>">
    <asp:Label ID="lblLabel" AssociatedControlID="fileUpload" runat="server" />
    <asp:Label ID="lblRequired" CssClass="required" Visible="false" runat="server">*</asp:Label>
    <asp:RequiredFieldValidator ID="reqRequired" ControlToValidate="fileUpload" SetFocusOnError="true" Display="None" Visible="false" runat="server" /><br />
    <asp:FileUpload ID="fileUpload" size="12" runat="server" />
    <asp:Button ID="btnUpload" Text="Upload" disabled="disabled" Style="display: block" runat="server" />
    <asp:Image ID="imgPreview" Width="125px" Visible="false" runat="server" />
</div>

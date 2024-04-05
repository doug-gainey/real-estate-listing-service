﻿<%@ Page Title="Add Land/Farm Listing" Language="C#" MasterPageFile="~/agents/agent.master" AutoEventWireup="true" CodeFile="addland.aspx.cs" Inherits="agents_addland" %>

<%@ Register TagPrefix="uc" TagName="TextField" Src="~/controls/textfield.ascx" %>
<%@ Register TagPrefix="uc" TagName="ListField" Src="~/controls/listfield.ascx" %>
<%@ Register TagPrefix="uc" TagName="CheckBoxField" Src="~/controls/checkboxfield.ascx" %>
<%@ Register TagPrefix="uc" TagName="UploadField" Src="~/controls/uploadfield.ascx" %>
<asp:Content ID="cntHead" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="../styles/jquery.cluetip.css" />
    <link rel="stylesheet" type="text/css" href="../styles/thickbox.css" />
    <script type="text/javascript" src="../scripts/jquery.cluetip.js"></script>
    <script type="text/javascript" src="../scripts/thickbox.js"></script>
    <script type="text/javascript">
        $(document).ready(function() {
            $('#lnkRequired').cluetip({ local: true, cursor: 'pointer' });
        });

        function showFeatures(featureName) {
            var selectedFeature = $('#div' + featureName);
            if (!selectedFeature.is(':visible')) {
                $('.features').slideUp('slow');
                selectedFeature.slideDown('slow');
            }
        }

        function toggleField(fieldId) {
            var field = $('#' + fieldId);
            if (field.is(':visible'))
                field.slideUp('slow');
            else
                field.slideDown('slow');
        }
    </script>
</asp:Content>
<asp:Content ID="cntContentArea" ContentPlaceHolderID="cphContentArea" runat="Server">
    <asp:PlaceHolder ID="phGeneral" runat="server">
        <div class="message">
            Please note there are a number of fields that are required to add a listing. Please review the <a id="lnkRequired" title="Required Fields" href="#required" rel="#required">list of required fields</a> before attempting to add a listing. For you convenience, required fields are also denoted by an asterisk ( <span class="required">*</span> ) on each form.
        </div>
        <div id="required" class="hidden">
            Title<br />Start Date<br />Expiration Date<br />Address<br />City<br />State<br />County<br />Property Type
        </div>
        <h1>Step 1: Listing Information</h1>
        <div class="leftcolumn">
            <uc:TextField ID="tfTitle" Label="Title" MaxLength="50" Required="true" runat="server" />
            <uc:TextField ID="tfListDate" Label="Start Date" DataType="Date" Operator="DataTypeCheck" Required="true" runat="server" />
            <uc:TextField ID="tfExpirationDate" Label="Expiration Date" DataType="Date" Operator="DataTypeCheck" Required="true" runat="server" />
            <uc:TextField ID="tfListPrice" Label="Price" DataType="Currency" Operator="DataTypeCheck" runat="server" />
            <uc:TextField ID="tfDescription" Label="Description" TextMode="MultiLine" runat="server" />
        </div>
        <div class="rightcolumn">
            <uc:CheckBoxField ID="cbfForSale" Label="For Sale" runat="server" />
            <uc:TextField ID="tfPricePerAcre" Label="Price Per Acre" CssClass="hidden" DataType="Integer" Operator="DataTypeCheck" runat="server" />
            <uc:CheckBoxField ID="cbfForExchange" Label="For Exchange" runat="server" />
            <uc:CheckBoxField ID="cbfForLease" Label="For Lease" runat="server" />
            <uc:TextField ID="tfLeasePrice" Label="Lease Price" CssClass="hidden" DataType="Integer" Operator="DataTypeCheck" runat="server" />
            <uc:TextField ID="tfLeaseMode" Label="Lease Mode" CssClass="hidden" MaxLength="10" runat="server" />
            <uc:TextField ID="tfMortgageBalance" Label="Mortgage Balance" DataType="Integer" Operator="DataTypeCheck" runat="server" />
            <uc:TextField ID="tfTermDesired" Label="Term Desired" MaxLength="25" runat="server" />
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="phLocation" Visible="false" runat="server">
        <h1>Step 2: Location Information</h1>
        <div class="leftcolumn">
            <uc:TextField ID="tfAddress" Label="Address" MaxLength="50" Required="true" runat="server" />
            <uc:TextField ID="tfCity" Label="City" MaxLength="50" Required="true" runat="server" />
            <uc:ListField ID="lfState" Label="State" Required="true" runat="server">
                <asp:ListItem Value="">- Select State -</asp:ListItem>
            </uc:ListField>
            <uc:TextField ID="tfZipCode" Label="ZIP Code" MaxLength="5" ValidationExpression="^\d{5}$" Format="12345" runat="server" />
            <uc:TextField ID="tfCounty" Label="County" MaxLength="50" Required="true" runat="server" />
            <uc:TextField ID="tfArea" Label="Area" MaxLength="5" DataType="Integer" Operator="LessThanEqual" ValueToCompare="32767" runat="server" />
            <uc:TextField ID="tfSuiteNumber" Label="Suite/Unit Number" MaxLength="6" runat="server" />
        </div>
        <div class="rightcolumn">
            <uc:TextField ID="tfSubComplexComm" Label="Sub-Division/Complex/Community" MaxLength="50" runat="server" />
            <uc:TextField ID="tfParcelNumber" Label="Parcel/Lot Number" MaxLength="25" runat="server" />
            <uc:TextField ID="tfTaxMapNumber" Label="Tax Map Number" MaxLength="50" runat="server" />
            <uc:TextField ID="tfSchoolDistrict" Label="School District" MaxLength="50" runat="server" />
            <uc:TextField ID="tfDirections" Label="Directions" TextMode="MultiLine" runat="server" />
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="phDetails" Visible="false" runat="server">
        <h1>Step 3: Property Details</h1>
        <div class="leftcolumn">
            <uc:ListField ID="lfPropertyType" Label="Property Type" Required="true" runat="server">
                <asp:ListItem Value="">- Select Property Type -</asp:ListItem>
            </uc:ListField>
            <uc:TextField ID="tfLotSize" Label="Lot Size" MaxLength="9" runat="server" />
            <uc:TextField ID="tfAcreage" Label="Acreage" DataType="Double" Operator="DataTypeCheck" runat="server" />
            <uc:TextField ID="tfTillableAcres" Label="Tillable Acres" DataType="Double" Operator="DataTypeCheck" runat="server" />
            <uc:TextField ID="tfUsableAcres" Label="Usable Acres" DataType="Double" Operator="DataTypeCheck" runat="server" />
            <uc:TextField ID="tfNumBuildings" Label="Number of Buildings" MaxLength="3" DataType="Integer" Operator="LessThanEqual" ValueToCompare="127" runat="server" />
            <uc:TextField ID="tfBuildingSqFt" Label="Building Square Feet" DataType="Integer" Operator="DataTypeCheck" runat="server" />
        </div>
        <div class="rightcolumn">
            <uc:TextField ID="tfYearlyTaxes" Label="Yearly Taxes" DataType="Integer" Operator="DataTypeCheck" runat="server" />
            <uc:CheckBoxField ID="cbfWaterfront" Label="Waterfront" runat="server" />
            <uc:TextField ID="tfPreviousUse" Label="Previous Use" MaxLength="25" runat="server" />
            <uc:TextField ID="tfZoning" Label="Zoning" MaxLength="6" runat="server" />
            <uc:TextField ID="tfDistanceToInterchange" Label="Distance to Interchange" DataType="Double" Operator="DataTypeCheck" runat="server" />
            <uc:TextField ID="tfTrafficCount" Label="Traffic Count Per Day" DataType="Integer" Operator="DataTypeCheck" runat="server" />
            <uc:TextField ID="tfRoadFront" Label="Road Front Footage" DataType="Integer" Operator="DataTypeCheck" runat="server" />
        </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="phFeatures" Visible="false" runat="server">
        <h1>Step 4: Property Features</h1>
        <asp:PlaceHolder ID="phFeatureSections" runat="server" />
        <uc:TextField ID="tfExtraAmenities" Label="Extra Features/Amenities" TextMode="MultiLine" runat="server" />
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="phPhotos" Visible="false" runat="server">
        <h1>Step 5: Property Photos</h1>
        <div class="column1">
            <uc:UploadField ID="ufPhoto1" Label="Photo 1" runat="server" />
            <uc:UploadField ID="ufPhoto2" Label="Photo 2" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto3" Label="Photo 3" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto4" Label="Photo 4" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto5" Label="Photo 5" Visible="false" runat="server" />
        </div>
        <div class="column2">
            <uc:UploadField ID="ufPhoto6" Label="Photo 6" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto7" Label="Photo 7" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto8" Label="Photo 8" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto9" Label="Photo 9" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto10" Label="Photo 10" Visible="false" runat="server" />
        </div>
        <div class="column3">
            <uc:UploadField ID="ufPhoto11" Label="Photo 11" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto12" Label="Photo 12" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto13" Label="Photo 13" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto14" Label="Photo 14" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto15" Label="Photo 15" Visible="false" runat="server" />
        </div>
        <div class="column4">
            <uc:UploadField ID="ufPhoto16" Label="Photo 16" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto17" Label="Photo 17" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto18" Label="Photo 18" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto19" Label="Photo 19" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto20" Label="Photo 20" Visible="false" runat="server" />
        </div>
        <div class="column5">
            <uc:UploadField ID="ufPhoto21" Label="Photo 21" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto22" Label="Photo 22" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto23" Label="Photo 23" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto24" Label="Photo 24" Visible="false" runat="server" />
            <uc:UploadField ID="ufPhoto25" Label="Photo 25" Visible="false" runat="server" />
        </div>
    </asp:PlaceHolder>
    <div class="buttons">
        <asp:Button ID="btnContinue" Text="Continue" OnClick="btnContinue_Click" runat="server" />
        <asp:Button ID="btnSave" Text="Save" OnClick="btnSave_Click" Visible="false" runat="server" />
        <asp:LinkButton ID="btnGoBack" OnClick="btnGoBack_Click" CausesValidation="false" Visible="false" runat="server">Go Back</asp:LinkButton>
    </div>
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>
<%@ Import Namespace="SWRELS.Domain"%>

<asp:Content ID="cntHead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntLeftColumn" ContentPlaceHolderID="cphLeftColumn" runat="Server">
    <div id="browsebystate">
        <h2>BROWSE BY STATE</h2>
        <div id="states">
            <div><a href="search.aspx?state=AL">Alabama</a></div>
            <div><a href="search.aspx?state=AK">Alaska</a></div>
            <div><a href="search.aspx?state=AZ">Arizona</a></div>
            <div><a href="search.aspx?state=AR">Arkansas</a></div>
            <div><a href="search.aspx?state=CA">California</a></div>
            <div><a href="search.aspx?state=CO">Colorado</a></div>
            <div><a href="search.aspx?state=CT">Connecticut</a></div>
            <div><a href="search.aspx?state=DE">Delaware</a></div>
            <div><a href="search.aspx?state=FL">Florida</a></div>
            <div><a href="search.aspx?state=GA">Georgia</a></div>
            <div><a href="search.aspx?state=HI">Hawaii</a></div>
            <div><a href="search.aspx?state=ID">Idaho</a></div>
            <div><a href="search.aspx?state=IL">Illinois</a></div>
            <div><a href="search.aspx?state=IN">Indiana</a></div>
            <div><a href="search.aspx?state=IA">Iowa</a></div>
            <div><a href="search.aspx?state=KS">Kansas</a></div>
            <div><a href="search.aspx?state=KY">Kentucky</a></div>
            <div><a href="search.aspx?state=LA">Louisiana</a></div>
            <div><a href="search.aspx?state=ME">Maine</a></div>
            <div><a href="search.aspx?state=MD">Maryland</a></div>
            <div><a href="search.aspx?state=MA">Massachusetts</a></div>
            <div><a href="search.aspx?state=MI">Michigan</a></div>
            <div><a href="search.aspx?state=MN">Minnesota</a></div>
            <div><a href="search.aspx?state=MS">Mississippi</a></div>
            <div><a href="search.aspx?state=MO">Missouri</a></div>
            <div><a href="search.aspx?state=MT">Montana</a></div>
            <div><a href="search.aspx?state=NE">Nebraska</a></div>
            <div><a href="search.aspx?state=NV">Nevada</a></div>
            <div><a href="search.aspx?state=NH">New Hampshire</a></div>
            <div><a href="search.aspx?state=NJ">New Jersey</a></div>
            <div><a href="search.aspx?state=NM">New Mexico</a></div>
            <div><a href="search.aspx?state=NY">New York</a></div>
            <div><a href="search.aspx?state=NC">North Carolina</a></div>
            <div><a href="search.aspx?state=ND">North Dakota</a></div>
            <div><a href="search.aspx?state=OH">Ohio</a></div>
            <div><a href="search.aspx?state=OK">Oklahoma</a></div>
            <div><a href="search.aspx?state=OR">Oregon</a></div>
            <div><a href="search.aspx?state=PN">Pennsylvania</a></div>
            <div><a href="search.aspx?state=RI">Rhode Island</a></div>
            <div><a href="search.aspx?state=SC">South Carolina</a></div>
            <div><a href="search.aspx?state=SD">South Dakota</a></div>
            <div><a href="search.aspx?state=TN">Tennessee</a></div>
            <div><a href="search.aspx?state=TX">Texas</a></div>
            <div><a href="search.aspx?state=UT">Utah</a></div>
            <div><a href="search.aspx?state=VT">Vermont</a></div>
            <div><a href="search.aspx?state=VA">Virginia</a></div>
            <div><a href="search.aspx?state=WA">Washington</a></div>
            <div><a href="search.aspx?state=WV">West Virginia</a></div>
            <div><a href="search.aspx?state=WI">Wisconsin</a></div>
            <div><a href="search.aspx?state=WY">Wyoming</a></div>
        </div>
    </div>
    <div id="featuredproperties">
        <h1>SEARCH RESULTS</h1>
        <style type="text/css">
            .listing { background:#fff; border: 1px solid #fecc00; -moz-border-radius: 6px; margin:5px; }
            .listingheader { background: #fefeaa; -moz-border-radius-topleft: 6px; -moz-border-radius-topright: 6px; padding: 5px; color: #000; text-align: left; font-weight:bold; text-transform:capitalize; }
            .listingbody { margin:5px; }
            .listingbody img { float:left; width:150px; margin-right:5px; }
            .listingprice { color:Green; font-weight:bold; }
        </style>
        <asp:DataList ID="dlSearchResults" OnItemDataBound="SearchResultsItem_DataBound" Width="100%" runat="server">
        <ItemTemplate>
            <div class="listing">
            <div class="listingheader"><asp:Literal ID="litHeader" runat="server" /></div>
                <div class="listingbody">
                    <asp:Image ID="imgPhoto" AlternateText="" runat="server" />
                    <asp:Literal ID="litPrice" runat="server" />
                    <asp:Literal ID="litDescription" runat="server" />
                    <div style="clear:both; "></div>
                </div>
            </div>
        </ItemTemplate>
        </asp:DataList>
        <div style="clear:both;"></div>
    </div>
</asp:Content>
<asp:Content ID="cntRightColumn" ContentPlaceHolderID="cphRightColumn" runat="Server">
    Advertising coming soon...
</asp:Content>
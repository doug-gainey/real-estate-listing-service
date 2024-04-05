<%@ Page Language="C#" MasterPageFile="~/default.master" AutoEventWireup="true" CodeFile="listing.aspx.cs" Inherits="listing" %>

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
    <div id="content">
        <h1><%=Listing.Title %></h1>
        <%
            foreach (var photo in Listing.Photos)
            {
                %>
                <img src="photos/<%=photo.PhotoFileName %>" alt="" />
                <%
            } %>
        
    </div>
</asp:Content>
<asp:Content ID="cntRightColumn" ContentPlaceHolderID="cphRightColumn" runat="Server">
    Advertising coming soon...
</asp:Content>

using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SWRELS.Domain;
using SWRELS.Facade;
using System.Web.UI;

public partial class search : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && Request.QueryString["state"] != null)
        {
            using (SwrelsFacade facade = new SwrelsFacade())
            {
                IList<Listing> listings = facade.GetListingsByState(Request.QueryString["state"]);
                if (listings == null)
                    return;

                dlSearchResults.DataSource = listings;
                dlSearchResults.DataBind();
            }
        }
    }

    protected void SearchResultsItem_DataBound(object sender, DataListItemEventArgs e)
    {
        Listing listing = (Listing)e.Item.DataItem;
        if (listing == null)
            return;

        Literal header = (Literal)e.Item.FindControl("litHeader");
        header.Text = String.Format("{0}, {1}, {2}", listing.Address, listing.City, listing.State);

        Image photo = (Image)e.Item.FindControl("imgPhoto");
        if (listing.Photos.Count > 0)
            photo.ImageUrl = String.Format("photos/{0}", listing.Photos[0].PhotoFileName);
        else
            photo.Visible = false;

        Literal price = (Literal)e.Item.FindControl("litPrice");
        if (listing.ListingPrice > 0)
            price.Text = String.Format("<div class=\"listingprice\">{0:c0}</div>", listing.ListingPrice);
        else
            price.Visible = false;

        Literal description = (Literal)e.Item.FindControl("litDescription");
        description.Text = listing.Description;
    }
}

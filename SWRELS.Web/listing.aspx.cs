using System;
using System.Collections.Generic;
using SWRELS;
using SWRELS.Domain;
using SWRELS.Facade;

public partial class listing : System.Web.UI.Page
{
    public int ListingId
    {
        get { return Request.QueryString["id"].ToInt(); }
    }

    public Listing Listing;

    protected void Page_Load(object sender, EventArgs e)
    {
        using (SwrelsFacade facade = new SwrelsFacade())
        {
            Listing = facade.Get<Listing>(ListingId);
        }
    }
}

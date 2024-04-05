using System;
using System.Collections.Generic;
using System.Text;
using SWRELS.Domain;
using SWRELS.Facade;
using System.Web.UI;

public partial class _default : System.Web.UI.Page
{
    protected IList<Listing> FeaturedListings;

    protected void Page_Load(object sender, EventArgs e)
    {
        using (SwrelsFacade facade = new SwrelsFacade())
        {
            FeaturedListings = facade.GetFeaturedListings();
            StringBuilder html = new StringBuilder();

            int i = 0;
            foreach (var listing in FeaturedListings)
            {
                if (listing.Photos.Count == 0) continue;

                html.Append("<div");

                if (i == 0)
                    html.Append(" class=\"prev\"");
                else if(i == 1)
                    html.Append(" class=\"featured\"");
                else if (i == 2)
                    html.Append(" class=\"next\"");

                html.Append(">");

                html.Append("<div class=\"wrapper\">");
                html.AppendFormat("<a href=\"listing.aspx?id={0}\"><img src=\"photos/{1}\" alt=\"\" /></a>", listing.Id, listing.Photos[0].PhotoFileName);

                html.Append("<div class=\"description\">");
                html.AppendFormat("<a href=\"listing.aspx?id={0}\">{1}</a>", listing.Id, listing.Title);
                html.AppendFormat("<div>{0}, {1}</div>", listing.City, listing.State);
                html.AppendFormat("<div>{0:c0}</div>", listing.ListingPrice);
                html.Append("</div>");

                html.Append("</div>");

                html.Append("</div>");
                i++;
            }

            phFeaturedListings.Controls.Add(new LiteralControl(html.ToString()));
        }
    }
}

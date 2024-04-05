using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using SWRELS.Domain;

namespace SWRELS.Facade
{
    public partial class SwrelsFacade
    {
        public IList<PropertyType> GetPropertyTypes(ListingType listingType)
        {
            ICriteria criteria = Session.CreateCriteria(typeof(PropertyType));
            criteria.Add(Restrictions.Eq("ListingType", (int)listingType));
            return criteria.List<PropertyType>();
        }

        public IList<Listing> GetListingsByState(string state)
        {
            ICriteria criteria = Session.CreateCriteria(typeof(Listing));
            criteria.Add(Restrictions.Eq("State", state));
            return criteria.List<Listing>();
        }

        public IList<Listing> GetFeaturedListings()
        {
            ICriteria criteria = Session.CreateCriteria(typeof(Listing));
            criteria.Add(Restrictions.Eq("Featured", true));
            return criteria.List<Listing>();
        }
    }
}
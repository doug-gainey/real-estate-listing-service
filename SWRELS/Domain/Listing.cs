using System;
using System.Collections.Generic;

namespace SWRELS.Domain
{
    public class Listing
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }
        public virtual decimal? ListingPrice { get; set; }
        public virtual ListingType ListingType { get; set; }
        public virtual short? Area { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string County { get; set; }
        public virtual string TaxMpNum { get; set; }
        public virtual string LotSize { get; set; }
        public virtual decimal? Acreage { get; set; }
        public virtual string Description { get; set; }
        public virtual string Directions { get; set; }
        public virtual DateTime? ListDate { get; set; }
        public virtual DateTime? ExpireDate { get; set; }
        public virtual bool WaterFront { get; set; }
        public virtual string SuiteUnit { get; set; }
        public virtual string SubComplxComm { get; set; }
        public virtual string ParcelNumber { get; set; }
        public virtual string XtraAmment { get; set; }
        public virtual bool Featured { get; set; }
        public virtual bool Closed { get; set; }
        public virtual bool Pending { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual PropertyType PropertyType { get; set; }

        public virtual IList<ListingPhoto> Photos { get; set; }
        public virtual IList<Feature> Features { get; set; }

        public Listing()
        {
            Photos = new List<ListingPhoto>();
            Features = new List<Feature>();
        }
    }
}
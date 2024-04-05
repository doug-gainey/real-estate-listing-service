
namespace SWRELS.Domain
{
    public class LandFarmListing
    {
        public virtual int Id { get; set; }
        public virtual string SchoolDistrict { get; set; }
        public virtual bool ForSale { get; set; }
        public virtual bool ForExchange { get; set; }
        public virtual bool ForLease { get; set; }
        public virtual int? PricePerAcre { get; set; }
        public virtual int? MortBalance { get; set; }
        public virtual int? LeasePrice { get; set; }
        public virtual string LeaseMode { get; set; }
        public virtual int? YearlyTaxes { get; set; }
        public virtual decimal? TillableAcres { get; set; }
        public virtual decimal? UsableAcres { get; set; }
        public virtual string PreviousUse { get; set; }
        public virtual string Zoning { get; set; }
        public virtual decimal? DistToInterc { get; set; }
        public virtual int? TrafCntPDay { get; set; }
        public virtual int? RoadFront { get; set; }
        public virtual short? NumBldgs { get; set; }
        public virtual int? BldgSqFt { get; set; }

        public virtual Listing Listing { get; set; }
    }
}
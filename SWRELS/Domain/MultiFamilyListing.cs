
namespace SWRELS.Domain
{
    public class MultiFamilyListing
    {
        public virtual int Id { get; set; }
        public virtual string SchoolDistrict { get; set; }
        public virtual string TaxDistrict { get; set; }
        public virtual bool ForSale { get; set; }
        public virtual bool ForExchange { get; set; }
        public virtual bool ForLease { get; set; }
        public virtual short? TotParking { get; set; }
        public virtual short? NumOfElev { get; set; }
        public virtual int? MinSqFoot { get; set; }
        public virtual int? MaxSqFoot { get; set; }
        public virtual short? EffRent { get; set; }
        public virtual short? OneBRent { get; set; }
        public virtual short? TwoBRent { get; set; }
        public virtual short? ThrBRent { get; set; }
        public virtual short? FreBRent { get; set; }
        public virtual short? FveBRent { get; set; }
        public virtual string NearInterchange { get; set; }
        public virtual decimal? DistToInterc { get; set; }
        public virtual short? YearBuilt { get; set; }
        public virtual bool PriorTo { get; set; }
        public virtual short? YearRemod { get; set; }

        public virtual Listing Listing { get; set; }
    }
}
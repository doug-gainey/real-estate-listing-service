
namespace SWRELS.Domain
{
    public class CommercialListing
    {
        public virtual int Id { get; set; }
        public virtual bool ForSale { get; set; }
        public virtual bool ForExchange { get; set; }
        public virtual bool ForLease { get; set; }
        public virtual string PreviousUse { get; set; }
        public virtual string UseCode { get; set; }
        public virtual string Zoning { get; set; }
        public virtual int? TotBldgSqFt { get; set; }
        public virtual short? OccupRate { get; set; }
        public virtual int? MortBalance { get; set; }
        public virtual short? NumOfDocks { get; set; }
        public virtual string DockSize { get; set; }
        public virtual string BaySize { get; set; }
        public virtual short? NumDrvInDrs { get; set; }
        public virtual string DrvInDrSize { get; set; }
        public virtual short? NumOfUnits { get; set; }
        public virtual short? NumOfFlrAbvGrnd { get; set; }
        public virtual short? TotParking { get; set; }
        public virtual decimal? PrkRatPerK { get; set; }
        public virtual int? TrafCntPDay { get; set; }
        public virtual string CeilingHgt { get; set; }
        public virtual decimal? DistToInterc { get; set; }
        public virtual string NearInterchange { get; set; }
        public virtual decimal? LeasePrice { get; set; }
        public virtual bool WillllRemod { get; set; }
        public virtual decimal? FinAllowSqFt { get; set; }
        public virtual int? TotAvSqFt { get; set; }
        public virtual int? MxContAvSqFt { get; set; }
        public virtual int? MinAvSqFt { get; set; }
        public virtual short? PercentRent { get; set; }
        public virtual short? YearBuilt { get; set; }
        public virtual short? YearRemod { get; set; }

        public virtual Listing Listing { get; set; }
    }
}
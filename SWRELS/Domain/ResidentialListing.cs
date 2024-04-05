using System;

namespace SWRELS.Domain
{
    public class ResidentialListing
    {
        public virtual int Id { get; set; }
        public virtual string SchoolDistrict { get; set; }
        public virtual string TaxDistrict { get; set; }
        public virtual bool NewConst { get; set; }
        public virtual DateTime? CompleteDate { get; set; }
        public virtual short? Bedrooms { get; set; }
        public virtual short? Baths { get; set; }
        public virtual short? HalfBaths { get; set; }
        public virtual int? SqFoot { get; set; }
        public virtual int? FinLivingSpace { get; set; }
        public virtual bool LivingRoom { get; set; }
        public virtual bool FamilyRoom { get; set; }
        public virtual bool Utility { get; set; }
        public virtual bool DiningRoom { get; set; }
        public virtual bool GreatRoom { get; set; }
        public virtual bool Den { get; set; }
        public virtual bool EatingSpc { get; set; }
        public virtual bool RecRoom { get; set; }
        public virtual decimal? YearlyTaxes { get; set; }
        public virtual short? YearBuilt { get; set; }
        public virtual bool PriorTo { get; set; }

        public virtual Listing Listing { get; set; }
    }
}
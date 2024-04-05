
namespace SWRELS.Domain
{
    public class PropertyType
    {
        public virtual int Id { get; set; }

        public virtual ListingType ListingType { get; set; }
        public virtual string Description { get; set; }
        public virtual string PTypeName { get; set; }
    }
}
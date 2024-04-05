
namespace SWRELS.Domain
{
    public class ListingPhoto
    {
        public virtual int Id { get; set; }

        public virtual string PhotoFileName { get; set; }
        public virtual short ListOrder { get; set; }

        public virtual Listing Listing { get; set; }
    }
}

namespace SWRELS.Domain
{
    public class Feature
    {
        public virtual int Id { get; set; }
        public virtual short FeatureNum { get; set; }
        public virtual string FeatureName { get; set; }
        public virtual string FeatureOption { get; set; }

        public virtual Listing Listing { get; set; }
    }
}
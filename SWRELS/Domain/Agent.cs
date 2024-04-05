using System;

namespace SWRELS.Domain
{
    public class Agent
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string LoginName { get; set; }
        public virtual string LoginPass { get; set; }
        public virtual string AgencyName { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string FaxNumber { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual bool CharterMem { get; set; }
        public virtual DateTime SignUpDate { get; set; }
        public virtual int LicNumber { get; set; }
        public virtual bool Active { get; set; }
        public virtual string CcFirstName { get; set; }
        public virtual string CcLastName { get; set; }
        public virtual string CardType { get; set; }
        public virtual string CardNumber { get; set; }
        public virtual short? ExpireMonth { get; set; }
        public virtual short? ExpireYear { get; set; }
        public virtual string SecurityCode { get; set; }
        public virtual short? Renewal { get; set; }
    }
}
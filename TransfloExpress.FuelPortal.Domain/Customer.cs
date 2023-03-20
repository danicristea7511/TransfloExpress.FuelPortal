using TransfloExpress.FuelPortal.Domain.Common;

namespace TransfloExpress.FuelPortal.Domain
{
    public class Customer: BaseEntity
    {       
        public char Custcode { get; set; }
        public string? CompanyName { get; set; }
        public string? AddressLine { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? PrimaryContactName { get; set; }
        public string? PrimaryContactPhone { get; set; }
        public string? PrimaryContactEmail { get; set; }
        public bool IsIssuer { get; set; }
        public bool IsInviter { get; set; }
        public bool IsLocked { get; set; }
        public CustomerType Type { get; set; }
        public int TypeId { get; set; }
    }
}


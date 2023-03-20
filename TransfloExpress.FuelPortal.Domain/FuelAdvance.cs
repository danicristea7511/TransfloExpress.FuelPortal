using TransfloExpress.FuelPortal.Domain.Common;

namespace TransfloExpress.FuelPortal.Domain
{
    public class FuelAdvance: BaseEntity
    {
        public string ReceiverReferenceNumber { get; set; }
        public string? CardNumber { get; set; }
        public string? CardNumberMasked { get; set; }
        public string? CardNumberToken { get; set; }
        public string? CardToken { get; set; }
        public string? CardSecurityToken { get; set; }
        public string? CardFirstName { get; set; }

        public string? CardLastName { get; set; }
        public DateTime CardExpirationDate { get; set; }
        public bool CardStatus { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}


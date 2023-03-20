using System.ComponentModel.DataAnnotations;
using TransfloExpress.FuelPortal.Domain.Common;

namespace TransfloExpress.FuelPortal.Domain
{
    public class CustomerType: BaseEntity
    {
        public string Type { get; set; } = string.Empty;

        public string? Description { get; set; }

    }
}


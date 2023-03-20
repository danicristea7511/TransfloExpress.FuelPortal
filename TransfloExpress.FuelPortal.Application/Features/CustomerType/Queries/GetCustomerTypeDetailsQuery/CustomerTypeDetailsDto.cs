using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransfloExpress.FuelPortal.Application.Features.CustomerType.Queries.GetCustomerTypeDetailsQuery
{
    public class CustomerTypeDetailsDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}

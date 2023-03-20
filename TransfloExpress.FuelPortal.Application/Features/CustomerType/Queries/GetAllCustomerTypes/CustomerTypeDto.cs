using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransfloExpress.FuelPortal.Application.Features.CustomerType.Queries.GetAllCustomerTypes
{
    public class CustomerTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}

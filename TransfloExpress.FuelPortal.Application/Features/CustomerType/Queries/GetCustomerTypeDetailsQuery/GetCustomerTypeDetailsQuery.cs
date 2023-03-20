using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransfloExpress.FuelPortal.Application.Features.CustomerType.Queries.GetCustomerTypeDetailsQuery
{
    public record GetCustomerTypeDetailsQuery(int id): IRequest<CustomerTypeDetailsDto>;
  
}

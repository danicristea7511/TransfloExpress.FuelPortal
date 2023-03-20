using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransfloExpress.FuelPortal.Application.Features.CustomerType.Commands.CreateCustomerType
{
    public class DeleteCustomerTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}

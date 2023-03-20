using MediatR;

namespace TransfloExpress.FuelPortal.Application.Features.CustomerType.Commands.CreateCustomerType
{
    public class UpdateCustomerTypeCommand : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

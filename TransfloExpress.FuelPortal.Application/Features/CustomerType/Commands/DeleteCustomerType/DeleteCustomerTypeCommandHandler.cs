using MediatR;
using TransfloExpress.FuelPortal.Application.Contract.Persistence;
using TransfloExpress.FuelPortal.Application.Exceptions;

namespace TransfloExpress.FuelPortal.Application.Features.CustomerType.Commands.CreateCustomerType
{
    public class DeleteCustomerTypeCommandHandler : IRequestHandler<DeleteCustomerTypeCommand, Unit>
    {
        private readonly ICustomerTypeRepository _customerTypeRepository;

        public DeleteCustomerTypeCommandHandler(ICustomerTypeRepository customerTypeRepository) =>
            _customerTypeRepository = customerTypeRepository;

        public async Task<Unit> Handle(DeleteCustomerTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            // retrieve to domain entity type object
            var customerTypeToDelete = await _customerTypeRepository.GetByIdAsync(request.Id);

            //verify that the record exists
            if (customerTypeToDelete == null)
            {
                throw new NotFoundException(nameof(CustomerType), request.Id);
            }

            //remove from database
            await _customerTypeRepository.DeleteAsync(customerTypeToDelete);

            //retrun record id;
            return Unit.Value;
        }
    }
}

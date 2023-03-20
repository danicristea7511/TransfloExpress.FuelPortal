using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransfloExpress.FuelPortal.Application.Contract.Persistence;

namespace TransfloExpress.FuelPortal.Application.Features.CustomerType.Commands.CreateCustomerType
{
    public class UpdateCustomerTypeCommandHandler : IRequestHandler<UpdateCustomerTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerTypeRepository _customerTypeRepository;

        public UpdateCustomerTypeCommandHandler(IMapper mapper, ICustomerTypeRepository customerTypeRepository)
        {
            _mapper = mapper;
            _customerTypeRepository = customerTypeRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            // convert to domain entity type object
            var customerTypeToCreate = _mapper.Map<Domain.CustomerType>(request);

            //add to database
            await _customerTypeRepository.UpdateAsync(customerTypeToCreate);

            //retrun record id;
            return Unit.Value;
        }
    }
}

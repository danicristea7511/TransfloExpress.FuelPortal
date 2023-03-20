using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransfloExpress.FuelPortal.Application.Contract.Persistence;
using TransfloExpress.FuelPortal.Application.Exceptions;

namespace TransfloExpress.FuelPortal.Application.Features.CustomerType.Commands.CreateCustomerType
{
    public class CreateCustomerTypeCommandHandler : IRequestHandler<CreateCustomerTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerTypeRepository _customerTypeRepository;

        public CreateCustomerTypeCommandHandler(IMapper mapper, ICustomerTypeRepository customerTypeRepository)
        {
            _mapper = mapper;
            _customerTypeRepository = customerTypeRepository;
        }

        public async Task<int> Handle(CreateCustomerTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
            var validator = new CreateCustomerTypeCommandValidator(_customerTypeRepository);
            var valicationResult = await validator.ValidateAsync(request);

            if (valicationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid LeaveType", valicationResult);
            }                
            // convert to domain entity type object
            var customerTypeToCreate = _mapper.Map<Domain.CustomerType>(request);

            //add to database
            await _customerTypeRepository.CreateAsync(customerTypeToCreate);

            //retrun record id;
            return customerTypeToCreate.Id;
        }
    }
}

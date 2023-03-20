using AutoMapper;
using MediatR;
using TransfloExpress.FuelPortal.Application.Contract.Persistence;
using TransfloExpress.FuelPortal.Application.Exceptions;

namespace TransfloExpress.FuelPortal.Application.Features.CustomerType.Queries.GetCustomerTypeDetailsQuery
{
    public class GetCustomerTypeDetailsQueryHandler : IRequestHandler<GetCustomerTypeDetailsQuery, CustomerTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerTypeRepository _customerTypeRepository;

        public GetCustomerTypeDetailsQueryHandler(IMapper mapper, ICustomerTypeRepository customerTypeRepository)
        {
            _mapper = mapper;
            _customerTypeRepository = customerTypeRepository;
        }

        public async Task<CustomerTypeDetailsDto> Handle(GetCustomerTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var customerType = await _customerTypeRepository.GetByIdAsync(request.id);

            //verify that the record exist
            if (customerType == null)
            {
                throw new NotFoundException(nameof(CustomerType), request.id);
            }

            //convert data objects to DTO objects
            var data = _mapper.Map<CustomerTypeDetailsDto>(customerType);

            //return list of DTO object;
            return data;
        }
    }
}

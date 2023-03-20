using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransfloExpress.FuelPortal.Application.Contract.Persistence;

namespace TransfloExpress.FuelPortal.Application.Features.CustomerType.Queries.GetAllCustomerTypes
{
    public class GetCustomerTypeQueryHandler : IRequestHandler<GetCustomerTypesQuery, List<CustomerTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerTypeRepository _customerTypeRepository;

        public GetCustomerTypeQueryHandler(IMapper mapper, ICustomerTypeRepository customerTypeRepository)
        {
            _mapper = mapper;
            _customerTypeRepository = customerTypeRepository;
        }

        public async Task<List<CustomerTypeDto>> Handle(GetCustomerTypesQuery request, CancellationToken cancellationToken)
        {
            //Query the database
            var customerTypes = await _customerTypeRepository.GetAsync();

            //convert data objects to DTO objects
            var data = _mapper.Map<List<CustomerTypeDto>>(customerTypes);

            //return list of DTO object;
            return data;
        }
    }
}

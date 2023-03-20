using AutoMapper;
using TransfloExpress.FuelPortal.Application.Features.CustomerType.Queries.GetAllCustomerTypes;
using TransfloExpress.FuelPortal.Application.Features.CustomerType.Queries.GetCustomerTypeDetailsQuery;
using TransfloExpress.FuelPortal.Domain;

namespace TransfloExpress.FuelPortal.Application.MappingProfiles
{
    public class CustomerTypeProfile: Profile
    {
        public CustomerTypeProfile()
        {
            CreateMap<CustomerTypeDto, CustomerType>().ReverseMap();

            CreateMap<CustomerType, CustomerTypeDetailsDto>().ReverseMap();
        }
    }
}

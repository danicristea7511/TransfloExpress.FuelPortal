using TransfloExpress.FuelPortal.Domain;

namespace TransfloExpress.FuelPortal.Application.Contract.Persistence
{
    public interface ICustomerTypeRepository :IGenericRepository<CustomerType>
    {
        Task<bool> IsCustomerTypeUnique(string name);
    }
}
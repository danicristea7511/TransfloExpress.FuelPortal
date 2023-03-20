using TransfloExpress.FuelPortal.Domain;

namespace TransfloExpress.FuelPortal.Application.Contract.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetCustomerWithDetails(int id);
        Task<List<Customer>> GetCustomersWithDetails();
        Task<List<Customer>> GetCustomersWithDetails(int customerTypeId);
    }
}
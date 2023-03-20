using Microsoft.EntityFrameworkCore;
using TransfloExpress.FuelPortal.Application.Contract.Persistence;
using TransfloExpress.FuelPortal.Domain;
using TransfloExpress.FuelPortal.Persistence.DatabaseContext;

namespace TransfloExpress.FuelPortal.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(FuelDatabaseContext context) : base(context)
        {

        }

        public async Task<List<Customer>> GetCustomersWithDetails()
        {
            var customers = await _context.Customers
                .Include(q => q.Type)
                .ToListAsync();

            return customers;
        }

        public async Task<List<Customer>> GetCustomersWithDetails(int customerTypeId)
        {
            var customers = await _context.Customers
                .Where(q => q.TypeId == customerTypeId)
                .Include(q => q.Type)
                .ToListAsync();

            return customers;
        }

        public async Task<Customer> GetCustomerWithDetails(int id)
        {
            var customer = await _context.Customers               
                .Include(q => q.Type)
                .FirstOrDefaultAsync(q => q.Id == id);

            return customer;
        }
    }
}

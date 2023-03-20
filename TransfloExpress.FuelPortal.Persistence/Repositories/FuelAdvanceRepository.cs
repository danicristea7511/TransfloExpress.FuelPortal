using Microsoft.EntityFrameworkCore;
using TransfloExpress.FuelPortal.Application.Contract.Persistence;
using TransfloExpress.FuelPortal.Domain;
using TransfloExpress.FuelPortal.Persistence.DatabaseContext;

namespace TransfloExpress.FuelPortal.Persistence.Repositories
{
    public class FuelAdvanceRepository : GenericRepository<FuelAdvance>, IFuelAdvanceRepository
    {
        public FuelAdvanceRepository(FuelDatabaseContext context) : base(context)
        {

        }

        public async Task AddFuelAdvances(List<FuelAdvance> fuelAdvances)
        {
            await _context.AddRangeAsync(fuelAdvances);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> FuelAdvanceExists(string receiverReferenceNumber, int customerId)
        {
            return await _context.FuelAdvances.AnyAsync(q => q.ReceiverReferenceNumber == receiverReferenceNumber
                        && q.CustomerId == customerId);
        }

        public async Task<FuelAdvance> GetCustomerFuelAdvance(int customerId)
        {
            var fuelAdvance = await _context.FuelAdvances.FirstOrDefaultAsync(q => q.CustomerId == customerId);
            return fuelAdvance;
        }

        public async Task<List<FuelAdvance>> GetFuelAdvancesWithDetails()
        {
            var fuelAdavances = await _context.FuelAdvances
                .Include(q => q.Customer)
                .ToListAsync();
            return fuelAdavances;
        }

        public async Task<List<FuelAdvance>> GetFuelAdvancesWithDetails(int customerId)
        {
            var fuelAdavances = await _context.FuelAdvances.Where(q => q.CustomerId == customerId)
               .Include(q => q.Customer)
               .ToListAsync();
            return fuelAdavances;
        }

        public async Task<FuelAdvance> GetFuelAdvanceWithDetails(int id)
        {
            var fuelAdavance = await _context.FuelAdvances
               .Include(q => q.Customer)
               .FirstOrDefaultAsync(q => q.Id == id);
            return fuelAdavance;
        }
    }
}

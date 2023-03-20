using TransfloExpress.FuelPortal.Domain;

namespace TransfloExpress.FuelPortal.Application.Contract.Persistence
{
    public interface IFuelAdvanceRepository : IGenericRepository<FuelAdvance>
    {
        Task<FuelAdvance> GetFuelAdvanceWithDetails(int id);
        Task<List<FuelAdvance>> GetFuelAdvancesWithDetails();
        Task<List<FuelAdvance>> GetFuelAdvancesWithDetails(int customerId);
        Task<bool> FuelAdvanceExists(string receiverReferenceNumber, int customerId);
        Task AddFuelAdvances(List<FuelAdvance> fuelAdvances);
        Task<FuelAdvance> GetCustomerFuelAdvance(int customerId);
    }
}
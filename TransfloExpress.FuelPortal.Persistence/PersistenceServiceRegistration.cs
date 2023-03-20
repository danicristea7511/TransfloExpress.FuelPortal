using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransfloExpress.FuelPortal.Application.Contract.Persistence;
using TransfloExpress.FuelPortal.Persistence.DatabaseContext;
using TransfloExpress.FuelPortal.Persistence.Repositories;

namespace TransfloExpress.FuelPortal.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FuelDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FuelDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IFuelAdvanceRepository, FuelAdvanceRepository>();
            return services;
        }
    }
}

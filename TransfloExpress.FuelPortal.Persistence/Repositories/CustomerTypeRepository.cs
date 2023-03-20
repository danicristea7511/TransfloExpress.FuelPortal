using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransfloExpress.FuelPortal.Application.Contract.Persistence;
using TransfloExpress.FuelPortal.Domain;
using TransfloExpress.FuelPortal.Persistence.DatabaseContext;

namespace TransfloExpress.FuelPortal.Persistence.Repositories
{
    public class CustomerTypeRepository : GenericRepository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(FuelDatabaseContext context): base(context)
        {

        }

        public Task<bool> IsCustomerTypeUnique(string name)
        {
            return _context.CustomerTypes.AnyAsync(q => q.Type == name);
        }
    }
}

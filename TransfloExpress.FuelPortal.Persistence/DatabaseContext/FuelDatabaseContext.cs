using Microsoft.EntityFrameworkCore;
using TransfloExpress.FuelPortal.Domain;
using TransfloExpress.FuelPortal.Domain.Common;

namespace TransfloExpress.FuelPortal.Persistence.DatabaseContext
{
    public class FuelDatabaseContext : DbContext
    {
        public FuelDatabaseContext(DbContextOptions<FuelDatabaseContext> options): base(options)
        {

        }

        public DbSet<CustomerType> CustomerTypes { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<FuelAdvance> FuelAdvances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FuelDatabaseContext).Assembly);           

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.LastModifiedDate = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

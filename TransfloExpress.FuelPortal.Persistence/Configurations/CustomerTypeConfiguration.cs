using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TransfloExpress.FuelPortal.Domain;

namespace TransfloExpress.FuelPortal.Persistence.Configurations
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.HasData(
               new CustomerType
               {
                   Id = 1,
                   Type = "Broker",
                   Description = "Broker fleet",
                   DateCreated = DateTime.UtcNow,
                   LastModifiedDate = DateTime.UtcNow

               },
                new CustomerType
                {
                    Id = 2,
                    Type = "Carrier",
                    Description = "Carrier fleet",
                    DateCreated = DateTime.UtcNow,
                    LastModifiedDate = DateTime.UtcNow

                }
               );

            builder.Property(q => q.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(q => q.Description)
                .HasMaxLength(200);
        }
    }
}

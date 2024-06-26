﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransfloExpress.FuelPortal.Persistence.DatabaseContext;

#nullable disable

namespace TransfloExpress.FuelPortal.Persistence.Migrations
{
    [DbContext(typeof(FuelDatabaseContext))]
    partial class FuelDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TransfloExpress.FuelPortal.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Custcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsInviter")
                        .HasColumnType("bit");

                    b.Property<bool>("IsIssuer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryContactPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TransfloExpress.FuelPortal.Domain.CustomerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("CustomerTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2023, 3, 17, 13, 5, 16, 296, DateTimeKind.Utc).AddTicks(437),
                            Description = "Broker fleet",
                            LastModifiedDate = new DateTime(2023, 3, 17, 13, 5, 16, 296, DateTimeKind.Utc).AddTicks(442),
                            Type = "Broker"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2023, 3, 17, 13, 5, 16, 296, DateTimeKind.Utc).AddTicks(444),
                            Description = "Carrier fleet",
                            LastModifiedDate = new DateTime(2023, 3, 17, 13, 5, 16, 296, DateTimeKind.Utc).AddTicks(445),
                            Type = "Carrier"
                        });
                });

            modelBuilder.Entity("TransfloExpress.FuelPortal.Domain.FuelAdvance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CardExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CardFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumberMasked")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardNumberToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardSecurityToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CardStatus")
                        .HasColumnType("bit");

                    b.Property<string>("CardToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReceiverReferenceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("FuelAdvances");
                });

            modelBuilder.Entity("TransfloExpress.FuelPortal.Domain.Customer", b =>
                {
                    b.HasOne("TransfloExpress.FuelPortal.Domain.CustomerType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("TransfloExpress.FuelPortal.Domain.FuelAdvance", b =>
                {
                    b.HasOne("TransfloExpress.FuelPortal.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });
#pragma warning restore 612, 618
        }
    }
}

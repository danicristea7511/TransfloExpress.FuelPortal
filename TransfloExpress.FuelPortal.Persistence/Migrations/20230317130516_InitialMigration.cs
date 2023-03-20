using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransfloExpress.FuelPortal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Custcode = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsIssuer = table.Column<bool>(type: "bit", nullable: false),
                    IsInviter = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CustomerTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "CustomerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuelAdvances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumberMasked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumberToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardSecurityToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CardStatus = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelAdvances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelAdvances_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "DateCreated", "Description", "LastModifiedDate", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 17, 13, 5, 16, 296, DateTimeKind.Utc).AddTicks(437), "Broker fleet", new DateTime(2023, 3, 17, 13, 5, 16, 296, DateTimeKind.Utc).AddTicks(442), "Broker" },
                    { 2, new DateTime(2023, 3, 17, 13, 5, 16, 296, DateTimeKind.Utc).AddTicks(444), "Carrier fleet", new DateTime(2023, 3, 17, 13, 5, 16, 296, DateTimeKind.Utc).AddTicks(445), "Carrier" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TypeId",
                table: "Customers",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelAdvances_CustomerId",
                table: "FuelAdvances",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelAdvances");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerTypes");
        }
    }
}

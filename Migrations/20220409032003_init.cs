using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBCSporting_LAIR.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddProductViewModel",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearlyPrice = table.Column<double>(type: "float", nullable: true),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddProductViewModel", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "AddTechnicianViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddTechnicianViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearlyPrice = table.Column<double>(type: "float", nullable: false),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductViewModel",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearlyPrice = table.Column<double>(type: "float", nullable: true),
                    ReleasedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductViewModel", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicianViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cell = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AddCustomerViewModel",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_AddCustomerViewModel_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerViewModel",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_CustomerViewModel_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => new { x.CustomerId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Registrations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TechnicianViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_TechnicianViewModel_TechnicianViewModelId",
                        column: x => x.TechnicianViewModelId,
                        principalTable: "TechnicianViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Afghanistan" },
                    { 2, "Algeria" },
                    { 3, "Argentina" },
                    { 4, "Australia" },
                    { 5, "Austria" },
                    { 6, "Bahamas" },
                    { 7, "Bangladesh" },
                    { 8, "Belarus" },
                    { 9, "Belgium" },
                    { 10, "Bhutan" },
                    { 11, "Bolivia" },
                    { 12, "Botswana" },
                    { 13, "Brazil" },
                    { 14, "Brunei" },
                    { 15, "Bulgaria" },
                    { 16, "Cambodia" },
                    { 17, "Cameroon" },
                    { 18, "Canada" },
                    { 19, "Chile" },
                    { 20, "China" },
                    { 21, "Colombia" },
                    { 22, "Costa Rica" },
                    { 23, "Croatia" },
                    { 24, "Cuba" },
                    { 25, "Czechia (Czech Republic)" },
                    { 26, "Democratic Republic of the Congo" },
                    { 27, "Denmark" },
                    { 28, "Dominican Republic" },
                    { 29, "Ecuador" },
                    { 30, "Egypt" },
                    { 31, "El Salvador" },
                    { 32, "Equatorial Guinea" },
                    { 33, "Ethiopia" },
                    { 34, "Finland" },
                    { 35, "France" },
                    { 36, "Georgia" },
                    { 37, "Germany" },
                    { 38, "Greece" },
                    { 39, "Iceland" },
                    { 40, "India" },
                    { 41, "Indonesia" },
                    { 42, "Iran" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 43, "Iraq" },
                    { 44, "Ireland" },
                    { 45, "Israel" },
                    { 46, "Italy" },
                    { 47, "Liberia" },
                    { 48, "Macedonia" },
                    { 49, "Malaysia" },
                    { 50, "Mexico" },
                    { 51, "Netherlands" },
                    { 52, "New Zealand" },
                    { 53, "North Korea" },
                    { 54, "Philippines" },
                    { 55, "Poland" },
                    { 56, "Portugal" },
                    { 57, "Qatar" },
                    { 58, "Russia" },
                    { 59, "Saudi Arabia" },
                    { 60, "Serbia" },
                    { 61, "Singapore" },
                    { 62, "South Africa" },
                    { 63, "South Korea" },
                    { 64, "Sweden" },
                    { 65, "Switzerland" },
                    { 66, "Syria" },
                    { 67, "Tanzania" },
                    { 68, "Thailand" },
                    { 69, "Turkey" },
                    { 70, "Uganda" },
                    { 71, "Ukraine" },
                    { 72, "United Arab Emirates" },
                    { 73, "United Kingdom" },
                    { 74, "United States of America" },
                    { 75, "Uruguay" },
                    { 76, "Venezuela" },
                    { 77, "Vietnam" },
                    { 78, "Wakanda" },
                    { 79, "Wonderland (Your name must be Alice)" },
                    { 80, "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "Phone", "PostalCode", "Province" },
                values: new object[,]
                {
                    { 1, "", "San Francisco", 74, "kanthoni@pge.com", "Kaitlyn", "Anthoni", "", "", "" },
                    { 2, "", "Washington", 74, "ania@mma.nidc.com", "Ania", "Irvin", "", "", "" },
                    { 3, "", "Mission Veijo", 18, "", "Gonzalo", "Keeton", "", "", "" },
                    { 4, "", "Sacramento", 42, "amauro@yahoo.org", "Anton", "Mauro", "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "Phone", "PostalCode", "Province" },
                values: new object[,]
                {
                    { 5, "", "Fresno", 35, "kmayte@fresno.ca.gov", "Kendall", "Mayte", "", "", "" },
                    { 6, "", "Los Angeles", 79, "kenzie@mma.jobtrak.com", "Kenzie", "Quinn", "", "", "" },
                    { 7, "", "Fresno", 78, "marvin@expedata.com", "Marvin", "Quintin", "", "", "" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Code", "Name", "ReleasedDate", "YearlyPrice" },
                values: new object[,]
                {
                    { 1, "TRNY10", "Tournament Master 1.0", new DateTime(2015, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.9900000000000002 },
                    { 2, "LEAG10", "League Scheduler 1.0", new DateTime(2016, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.9900000000000002 },
                    { 3, "LEAGD10", "League Scheduler Deluxe 1.0", new DateTime(2016, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.9900000000000002 },
                    { 4, "DRAFT10", "Draft Manager 1.0", new DateTime(2017, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.9900000000000002 },
                    { 5, "TEAM10", "Team Manager 1.0", new DateTime(2017, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.9900000000000002 },
                    { 6, "TRNY20", "Tournament Master 2.0", new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.9900000000000002 },
                    { 7, "DRAFT20", "Draft Manager 2.0", new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "Id", "Cell", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "800-555-0443", "alison@sportsprosoftware.com", "Alison Diaz" },
                    { 2, "800-555-0449", "awilson@sportsprosoftware.com", "Andrew Wilson" },
                    { 3, "800-555-0459", "gfiori@sportsprosoftware.com", "Gina Fiori" },
                    { 4, "800-555-0400", "gunter@sportsprosoftware.com", "Gunter Wendt" },
                    { 5, "800-555-0444", "jason@sportsprosoftware.com", "Jason Lee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddCustomerViewModel_CountryId",
                table: "AddCustomerViewModel",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerViewModel_CountryId",
                table: "CustomerViewModel",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianId",
                table: "Incidents",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianViewModelId",
                table: "Incidents",
                column: "TechnicianViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ProductId",
                table: "Registrations",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddCustomerViewModel");

            migrationBuilder.DropTable(
                name: "AddProductViewModel");

            migrationBuilder.DropTable(
                name: "AddTechnicianViewModel");

            migrationBuilder.DropTable(
                name: "CustomerViewModel");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "ProductViewModel");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "TechnicianViewModel");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

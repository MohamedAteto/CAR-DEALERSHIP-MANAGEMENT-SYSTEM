using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DriverLicenseNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeFullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmployeePosition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeePhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmployeeHireDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Make = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VehiclePrice = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Transmission = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Cars_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomersProfiles",
                columns: table => new
                {
                    CustomerProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CustomerCity = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerNationality = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CustomerDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersProfiles", x => x.CustomerProfileId);
                    table.ForeignKey(
                        name: "FK_CustomersProfiles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sale_Cars_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Cars",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Comfortable Passenger Cars", "Sedan" },
                    { 2, "Sprt utility Vehicles", "SUV" },
                    { 3, "Compact Practical Cars", "HatchBack" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "DriverLicenseNumber", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "DL100001", "ahmed.hassan@example.com", "Ahmed Hassan", "01010000001" },
                    { 2, "DL100002", "mona.adel@example.com", "Mona Adel", "01010000002" },
                    { 3, "DL100003", "omar.khaled@example.com", "Omar Khaled", "01010000003" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "EmployeeEmail", "EmployeeFullName", "EmployeeHireDate", "EmployeePhoneNumber", "EmployeePosition" },
                values: new object[,]
                {
                    { 1, "mostafa.nabil@autodrive.com", "Mostafa Nabil", "2021-01-10", "01010000001", "Sales Manager" },
                    { 2, "aya.emad@autodrive.com", "Aya Emad", "2021-04-15", "01010000002", "Sales Consultant" },
                    { 3, "hassan.ali@autodrive.com", "Hassan Ali", "2021-02-20", "01010000003", "Sales Consultant" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "VehicleId", "CategoryId", "Color", "FuelType", "Make", "Mileage", "Model", "Status", "Transmission", "VIN", "VehiclePrice", "Year" },
                values: new object[,]
                {
                    { 1, 1, "White", "Petrol", "Toyota", 12000, "Corolla", "Available", "Automatic", "VIN00000000000001", 650000m, 2024 },
                    { 2, 2, "Black", "Petrol", "Hyundai", 18000, "Elantra", "Available", "Automatic", "VIN00000000000002", 590000m, 2023 },
                    { 3, 3, "Gray", "Petrol", "Kia", 9000, "Sportage", "Available", "Automatic", "VIN00000000000003", 980000m, 2024 }
                });

            migrationBuilder.InsertData(
                table: "CustomersProfiles",
                columns: new[] { "CustomerProfileId", "CustomerAddress", "CustomerCity", "CustomerDateOfBirth", "CustomerId", "CustomerNationality" },
                values: new object[,]
                {
                    { 1, "12 Nile St.", "Cairo", new DateTime(1992, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Egyptian" },
                    { 2, "25 Tahrir St.", "Giza", new DateTime(1995, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Egyptian" },
                    { 3, "18 El Nasr St.", "Cairo", new DateTime(1988, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Egyptian" }
                });

            migrationBuilder.InsertData(
                table: "Sale",
                columns: new[] { "SaleId", "CustomerId", "EmployeeId", "Notes", "PaymentMethod", "SaleDate", "SalePrice", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Complete Sale.", "Bank Transfer", new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1750000m, 1 },
                    { 2, 2, 2, "Complete Sale.", "Bank Transfer", new DateTime(2026, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1850000m, 2 },
                    { 3, 3, 3, "Complete Sale.", "Cash", new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 510000m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_VIN",
                table: "Cars",
                column: "VIN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_CategoryName",
                table: "Categorys",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DriverLicenseNumber",
                table: "Customers",
                column: "DriverLicenseNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomersProfiles_CustomerId",
                table: "CustomersProfiles",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeEmail",
                table: "Employee",
                column: "EmployeeEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CustomerId",
                table: "Sale",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_EmployeeId",
                table: "Sale",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_VehicleId",
                table: "Sale",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersProfiles");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}

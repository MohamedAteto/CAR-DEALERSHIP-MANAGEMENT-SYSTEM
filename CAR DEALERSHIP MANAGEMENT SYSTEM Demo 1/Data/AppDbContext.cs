using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Vehicle> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<CustomerProfile> CustomersProfiles { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.CategoryName)
                .IsUnique();

            modelBuilder.Entity<Vehicle>()
              .HasIndex(c => c.VIN)
              .IsUnique();

            modelBuilder.Entity<Customer>()
              .HasIndex(c => c.Email)
              .IsUnique();

            modelBuilder.Entity<Customer>()
              .HasIndex(c => c.DriverLicenseNumber)
              .IsUnique();

            modelBuilder.Entity<Employee>()
              .HasIndex(c => c.EmployeeEmail)
              .IsUnique();

            modelBuilder.Entity<Vehicle>()
             .Property(s => s.VehiclePrice)
             .HasPrecision(12, 2);

            modelBuilder.Entity<Sale>()
             .Property(s => s.SalePrice)
             .HasPrecision(12, 2);



            modelBuilder.Entity<Category>()
                .HasMany(c => c.Vehicles)
                .WithOne(v => v.Category)
                .HasForeignKey(v => v.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(v => v.Customer)
                .HasForeignKey(v => v.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Employee>()
                .HasMany(c => c.Sales)
                .WithOne(v => v.Employee)
                .HasForeignKey(v => v.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Vehicle>()
                .HasMany(c => c.Sales)
                .WithOne(v => v.Vehicle)
                .HasForeignKey(v => v.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.Status)
                .HasDefaultValue("Available");



            modelBuilder.Entity<CustomerProfile>()
                .HasOne(c => c.Customer)
                .WithOne(p => p.CustomerProfile)
                .HasForeignKey<CustomerProfile>(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { CategoryId = 1, CategoryName = "Sedan" ,CategoryDescription = "Comfortable Passenger Cars"  },
                    new Category { CategoryId = 2, CategoryName = "SUV" , CategoryDescription ="Sprt utility Vehicles"},
                    new Category { CategoryId = 3, CategoryName = "HatchBack" ,CategoryDescription ="Compact Practical Cars" }
                
                );


            modelBuilder.Entity<Vehicle>()
                .HasData(
                
                    new Vehicle { VehicleId = 1 , Make = "Toyota" ,Model = "Corolla", Year = 2024 ,Color ="White" , VehiclePrice = 650000 , Mileage = 12000 , VIN = "VIN00000000000001" , FuelType ="Petrol" , Transmission ="Automatic" , Status ="Available" , CategoryId = 1},
                    new Vehicle { VehicleId = 2 , Make = "Hyundai", Model = "Elantra", Year = 2023 ,Color ="Black" , VehiclePrice = 590000 , Mileage = 18000 , VIN = "VIN00000000000002" , FuelType ="Petrol" , Transmission ="Automatic" , Status ="Available", CategoryId = 2 },
                    new Vehicle { VehicleId = 3 , Make = "Kia", Model = "Sportage", Year = 2024 ,Color ="Gray" , VehiclePrice = 980000 , Mileage = 9000 , VIN = "VIN00000000000003" , FuelType ="Petrol" , Transmission ="Automatic" , Status ="Available" , CategoryId = 3 }
                );


            modelBuilder.Entity<Customer>()
                .HasData(
                
                    new Customer {  CustomerId = 1 , FullName = "Ahmed Hassan" , Email = "ahmed.hassan@example.com", PhoneNumber = "01010000001", DriverLicenseNumber = "DL100001" },
                    new Customer { CustomerId = 2 , FullName = "Mona Adel" , Email = "mona.adel@example.com", PhoneNumber = "01010000002", DriverLicenseNumber = "DL100002"},
                    new Customer { CustomerId = 3 , FullName = "Omar Khaled", Email = "omar.khaled@example.com", PhoneNumber = "01010000003", DriverLicenseNumber = "DL100003" }


                );

            modelBuilder.Entity<CustomerProfile>()
                .HasData(
                    new CustomerProfile { CustomerProfileId = 1, CustomerAddress = "12 Nile St.", CustomerCity = "Cairo", CustomerNationality = "Egyptian" ,CustomerDateOfBirth= new DateTime(1992, 03, 12), CustomerId = 1 },
                    new CustomerProfile { CustomerProfileId = 2, CustomerAddress = "25 Tahrir St.", CustomerCity = "Giza", CustomerNationality = "Egyptian", CustomerDateOfBirth = new DateTime(1995,07, 24), CustomerId =2 },
                    new CustomerProfile { CustomerProfileId = 3, CustomerAddress = "18 El Nasr St.", CustomerCity = "Cairo", CustomerNationality = "Egyptian", CustomerDateOfBirth = new DateTime(1988, 11, 05), CustomerId = 3 }

                );

            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee { EmployeeId = 1 , EmployeeFullName = "Mostafa Nabil" , EmployeePosition ="Sales Manager" , EmployeeEmail ="mostafa.nabil@autodrive.com", EmployeePhoneNumber = "01010000001" , EmployeeHireDate = "2021-01-10"},
                    new Employee { EmployeeId = 2 , EmployeeFullName = "Aya Emad", EmployeePosition ="Sales Consultant" , EmployeeEmail = "aya.emad@autodrive.com", EmployeePhoneNumber = "01010000002" , EmployeeHireDate = "2021-04-15"},
                    new Employee { EmployeeId = 3 , EmployeeFullName = "Hassan Ali", EmployeePosition = "Sales Consultant", EmployeeEmail = "hassan.ali@autodrive.com", EmployeePhoneNumber = "01010000003" , EmployeeHireDate = "2021-02-20"}
                );
                

            modelBuilder.Entity<Sale>()
                .HasData(
                
                    new Sale { SaleId = 1, SaleDate = new DateTime(2024, 08, 15), SalePrice = 1750000, PaymentMethod = "Bank Transfer" , Notes ="Complete Sale." ,VehicleId = 1, CustomerId = 1, EmployeeId = 1},
                    new Sale { SaleId = 2, SaleDate = new DateTime(2026, 08, 22), SalePrice = 1850000, PaymentMethod = "Bank Transfer" , Notes ="Complete Sale." ,VehicleId = 2, CustomerId = 2, EmployeeId = 2},
                    new Sale { SaleId = 3, SaleDate = new DateTime(2026, 09, 05), SalePrice = 510000, PaymentMethod = "Cash" , Notes ="Complete Sale." ,VehicleId = 3, CustomerId = 3, EmployeeId = 3}
                );


            base.OnModelCreating(modelBuilder);
        }


    }
}

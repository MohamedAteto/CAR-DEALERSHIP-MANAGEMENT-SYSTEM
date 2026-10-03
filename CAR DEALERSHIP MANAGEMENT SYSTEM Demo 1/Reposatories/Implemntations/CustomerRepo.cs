using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustomerDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntations
{
    public class CustomerRepo : GenericRepo<Customer>, ICustmorRepo
    {
        private readonly AppDbContext _context;
        public CustomerRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public bool EmailExists(string email)
        {
            return _context.Customers.Any(c => c.Email == email);
        }

        public Customer? GetCustomerWithDetails(int id)
        {
            return _context.Customers
                  .Include(c => c.CustomerProfile)
                  .Include(c => c.Sales)
                  .FirstOrDefault(c => c.CustomerId == id);
        }

        public bool HasSales(int customerId)
        {
            return _context.Sales.Any(s => s.CustomerId == customerId);
        }
    }
}

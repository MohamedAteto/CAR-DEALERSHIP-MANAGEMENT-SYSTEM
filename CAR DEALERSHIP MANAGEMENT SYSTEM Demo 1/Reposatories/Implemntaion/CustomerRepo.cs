using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustomerDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntaion
{
    public class CustomerRepo : GenericRepo<Customer>, ICustomerRepo
    {
        private readonly AppDbContext _context;
        public CustomerRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public void Create_customer_with_profile_unique_email(Customer customer)
        {
            if (customer is null)
                throw new ArgumentNullException(nameof(customer));

            var existingCustomer = _context.Customers.FirstOrDefault(c => c.Email == customer.Email);
            if(existingCustomer != null)
                throw new InvalidOperationException("A customer with the same email already exists.");

            _context.Customers.Add(customer);
        }

        public ICollection<Customer> Customer_profile_purchase_history_total_vehicles_and_money_spent()
        {
            var customers = _context.Customers
                .Include(c => c.CustomerProfile)
                .Include(c => c.Sales)
                .ThenInclude(s => s.Vehicle)
                .ToList();

            

            return customers;
        }
    }
}

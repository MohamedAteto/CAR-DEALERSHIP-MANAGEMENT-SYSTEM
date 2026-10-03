using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces
{
    public interface ICustmorRepo : IGenericRepo<Customer>
    {
        Customer? GetCustomerWithDetails(int id);
        bool EmailExists(string email);
        bool HasSales(int customerId);

    }
}

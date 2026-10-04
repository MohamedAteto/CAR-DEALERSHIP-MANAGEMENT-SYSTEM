using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustomerDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface
{
    public interface ICustomerRepo : IGenericRepo<Customer>
    {
        public void Create_customer_with_profile_unique_email(Customer customer);
        public ICollection<Customer> Customer_profile_purchase_history_total_vehicles_and_money_spent();

    }
}

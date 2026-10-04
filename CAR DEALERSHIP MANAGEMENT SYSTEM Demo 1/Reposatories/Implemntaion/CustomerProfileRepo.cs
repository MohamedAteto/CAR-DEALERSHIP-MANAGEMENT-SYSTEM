using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntaion
{
    public class CustomerProfileRepo : GenericRepo<CustomerProfile> , ICustomerProfileRepo
    {
        public CustomerProfileRepo(AppDbContext context) : base(context)
        {
        }


    }
}

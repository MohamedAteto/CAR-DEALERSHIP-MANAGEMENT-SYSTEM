using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntations
{
    public class CusomterProfileRepo : GenericRepo<CustomerProfile>,ICustmorProfileRepo
    {
        public CusomterProfileRepo(AppDbContext context) : base(context)
        {

        }
    }
}

using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {

        public ICollection<Category> GetCategoriesWithVehicleCount();
    }
}

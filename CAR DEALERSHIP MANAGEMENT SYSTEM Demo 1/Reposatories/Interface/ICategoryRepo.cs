using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        public ICollection<Category> Get_Categories_With_CountOf_Vehicles();
    }
}

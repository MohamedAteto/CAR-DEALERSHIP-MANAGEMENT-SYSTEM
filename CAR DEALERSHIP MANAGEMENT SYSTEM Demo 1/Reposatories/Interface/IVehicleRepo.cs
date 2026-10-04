using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface
{
    public interface IVehicleRepo : IGenericRepo<Vehicle>
    {
        public ICollection<Vehicle> GetVehiclesWithExsitCategory();

        public ICollection<Vehicle> Get_available_vehicles_with_category_newest_yearthenlowest_price();
    }
}

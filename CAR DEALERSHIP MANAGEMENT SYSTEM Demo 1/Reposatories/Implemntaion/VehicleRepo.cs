using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntaion
{
    public class VehicleRepo : GenericRepo<Vehicle>, IVehicleRepo
    {
        private readonly AppDbContext _context;
        public VehicleRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public ICollection<Vehicle> GetVehiclesWithExsitCategory()
        {
            var items = _context.Cars.Include(c => c.Category).Where(c => c.Category != null).ToList();
            return items;
        }

        public ICollection<Vehicle> Get_available_vehicles_with_category_newest_yearthenlowest_price()
        {
            var items = _context.Cars.Include(c => c.Category)
                .Where(c => c.Status == "Available" && c.Category != null)
                .OrderByDescending(c => c.Year)
                .ThenBy(c => c.VehiclePrice)
                .ToList();

            return items;
        }
    }
}

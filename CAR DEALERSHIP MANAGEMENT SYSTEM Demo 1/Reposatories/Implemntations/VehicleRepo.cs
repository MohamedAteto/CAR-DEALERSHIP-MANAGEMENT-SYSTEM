using System.Runtime.CompilerServices;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntations
{
    public class VehicleRepo : GenericRepo<Vehicle>, IvehicleRepo
    {

        private readonly AppDbContext _context;
        public VehicleRepo(AppDbContext context) : base(context) 
        {
            _context = context;
        }


        public ICollection<Vehicle> GetAvailableVehicles()
        {
            var items = _context.Vehicles
                .Include(c => c.Category)
                .Where(a => a.Status == "Available").ToList();

            if (items is null)
                throw new Exception("Not Found");

            return items;
        }

        public ICollection<Vehicle> GetSoldVehicles()
        {
            var items = _context.Vehicles.Where(s => s.Status == "Sold").ToList();

            if (items is null)
                throw new Exception("Not Found");

            return items;
        }


    }
}

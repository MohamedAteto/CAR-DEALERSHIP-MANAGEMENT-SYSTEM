using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntations
{
    public class CategoryRepo : GenericRepo<Category>  , ICategoryRepo
    {
        private readonly AppDbContext _context;
        public CategoryRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<Category> GetCategoriesWithVehicleCount()
        {
            var items = _context.Categorys
                .Include(v => v.Vehicles)
                .ToList();

            return items;
        }
    }
}

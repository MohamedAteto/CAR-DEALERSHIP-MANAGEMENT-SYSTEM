using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntaion
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {

        private readonly AppDbContext _context;

        public CategoryRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<Category> Get_Categories_With_CountOf_Vehicles()
        {
            var items = _context.Categorys.ToList();

            if (items == null || items.Count == 0)
                throw new ArgumentNullException(nameof(items));

            return items;
            
        }
    }
}

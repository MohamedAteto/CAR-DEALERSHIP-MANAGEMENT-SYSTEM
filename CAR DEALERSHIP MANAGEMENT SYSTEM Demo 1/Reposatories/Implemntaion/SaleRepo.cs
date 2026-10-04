using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntaion
{
    public class SaleRepo : GenericRepo<Sale>, ISaleRepo
    {
        private readonly AppDbContext _context;
        public SaleRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public ICollection<Sale> Get_sales_with_related_details_groupby_employee_calculate_revenue()
        {
            var items = _context.Sales
                .Include(c => c.Customer)
                .Include(v => v.Vehicle)
                .Include(e => e.Employee)
                //.ThenInclude(s => s.Sales)
                .ToList();

            return items;
        }
    }
}

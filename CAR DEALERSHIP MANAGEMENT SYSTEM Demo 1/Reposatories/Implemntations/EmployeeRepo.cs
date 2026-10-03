using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntations
{
    public class EmployeeRepo : GenericRepo<Employee>, IEmployeeRepo
    {
        private readonly AppDbContext _context;

        public EmployeeRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }


        public ICollection<Employee> GetAllOrderdBySalesNumbers()
        {
            var item = _context.Employees
                .OrderByDescending(e => e.Sales)
                .ToList();

            return item;
        }

     
    }
}

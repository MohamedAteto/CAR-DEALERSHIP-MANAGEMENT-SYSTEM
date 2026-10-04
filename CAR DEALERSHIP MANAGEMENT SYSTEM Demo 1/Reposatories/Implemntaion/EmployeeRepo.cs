using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntaion
{
    public class EmployeeRepo : GenericRepo<Employee> , IEmployeeRepo
    {
        private readonly AppDbContext _context;
        public EmployeeRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

      
        public ICollection<Employee> GetEployeeWith_Salescount_orderby_highest_sales()
        {
            return _context.Employees
                .Include(e => e.Sales)
                .OrderByDescending(e => e.Sales.Count)
                .ToList();  
        }

     

       
    }
}

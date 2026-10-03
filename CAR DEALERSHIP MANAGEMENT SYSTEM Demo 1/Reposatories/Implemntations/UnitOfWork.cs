using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntations
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;

        public ICategoryRepo CategoryRepo { get; private set; }
        public ICustmorRepo CustmorRepo { get; private set; }
        public IEmployeeRepo EmployeeRepo { get; private set; }
        public ISaleRepo SaleRepo { get; private set; }
        public IvehicleRepo VehiclRepo { get; private set; }

        // Accept ONLY AppDbContext
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CategoryRepo = new CategoryRepo(_context);
            CustmorRepo = new CustomerRepo(_context);
            EmployeeRepo = new EmployeeRepo(_context);
            SaleRepo = new SaleRepo(_context);
            VehiclRepo = new VehicleRepo(_context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

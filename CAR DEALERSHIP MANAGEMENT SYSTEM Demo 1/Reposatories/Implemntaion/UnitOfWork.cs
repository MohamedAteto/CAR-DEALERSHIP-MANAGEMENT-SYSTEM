using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntaion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IVehicleRepo VehicleRepo { get; }
        public ICategoryRepo CategoryRepo { get; }

        public ICustomerRepo CustomerRepo { get; }
        public ICustomerProfileRepo customerProfileRepo { get; }
        public ISaleRepo SaleRepo   { get; }
        public IEmployeeRepo EmployeeRepo { get; }
        public UnitOfWork(AppDbContext context , IVehicleRepo vehicleRepo, ICategoryRepo categoryRepo , ICustomerRepo customerRepo , ICustomerProfileRepo customerProfileRepo , IEmployeeRepo employeeRepo,ISaleRepo saleRepo)
        {
            _context = context;
            VehicleRepo = vehicleRepo;
            CategoryRepo = categoryRepo;
            CustomerRepo = customerRepo;
           this.customerProfileRepo = customerProfileRepo;
            EmployeeRepo = employeeRepo;
            SaleRepo = saleRepo;
        }
      

        public void Dispose()
        {   
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

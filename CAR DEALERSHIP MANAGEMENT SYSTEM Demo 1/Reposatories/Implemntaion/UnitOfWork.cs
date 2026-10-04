using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntaion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IVehicleRepo VehicleRepo => throw new NotImplementedException();
        public ICategoryRepo CategoryRepo => throw new NotImplementedException();

        public ICustomerRepo CustomerRepo => throw new NotImplementedException();
        public ICustomerProfileRepo customerProfileRepo => throw new NotImplementedException();

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

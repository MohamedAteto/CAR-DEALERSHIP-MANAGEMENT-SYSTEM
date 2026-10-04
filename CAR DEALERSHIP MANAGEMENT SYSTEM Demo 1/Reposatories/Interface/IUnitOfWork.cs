namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface
{
    public interface IUnitOfWork
    {
        IVehicleRepo VehicleRepo { get; }

        ICategoryRepo CategoryRepo { get; }
        ISaleRepo SaleRepo { get; }
        IEmployeeRepo EmployeeRepo { get; }
        ICustomerProfileRepo customerProfileRepo { get; }
        ICustomerRepo CustomerRepo { get; }
        void Save();
        void Dispose();
    }
}

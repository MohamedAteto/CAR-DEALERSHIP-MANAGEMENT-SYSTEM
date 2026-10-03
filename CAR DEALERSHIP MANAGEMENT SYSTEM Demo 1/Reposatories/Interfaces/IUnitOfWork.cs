namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces
{
    public interface IUnitOfWork
    {


        ICategoryRepo CategoryRepo { get; }
        ICustmorRepo CustmorRepo { get; }
        IEmployeeRepo EmployeeRepo { get; }
        ISaleRepo SaleRepo { get; }
        IvehicleRepo VehiclRepo { get; }

        void Save();

    }
}

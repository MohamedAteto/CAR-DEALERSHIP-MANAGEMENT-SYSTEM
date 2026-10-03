using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces
{
    public interface IEmployeeRepo : IGenericRepo<Employee>
    {
        public ICollection<Employee> GetAllOrderdBySalesNumbers();
    }
}

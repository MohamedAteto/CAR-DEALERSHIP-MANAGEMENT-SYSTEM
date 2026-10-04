using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface
{
    public interface IEmployeeRepo : IGenericRepo<Employee>
    {
        public ICollection<Employee> GetEployeeWith_Salescount_orderby_highest_sales();
    }
}

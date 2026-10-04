using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface
{
    public interface ISaleRepo : IGenericRepo<Sale>
    {
        public ICollection<Sale> Get_sales_with_related_details_groupby_employee_calculate_revenue();
    }
}

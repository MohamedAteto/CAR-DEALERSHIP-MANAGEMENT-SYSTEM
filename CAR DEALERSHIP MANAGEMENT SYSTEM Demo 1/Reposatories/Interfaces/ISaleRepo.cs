using System.Diagnostics.Contracts;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces
{
    public interface ISaleRepo : IGenericRepo<Sale>
    {

        public ICollection<Sale> GetSalesWithDetials();
        public Sale? GetSaleWithVehicle(int saleId);
      

    }
}

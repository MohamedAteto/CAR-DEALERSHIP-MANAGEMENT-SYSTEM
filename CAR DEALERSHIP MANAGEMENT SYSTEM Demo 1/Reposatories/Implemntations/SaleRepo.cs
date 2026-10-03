using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntations
{
    public class SaleRepo : GenericRepo<Sale>, ISaleRepo
    {
        private readonly AppDbContext _context;

        public SaleRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<Sale> GetSalesWithDetials()
        {
            var items =  _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Employee)
                .Include(s => s.Vehicle)
                .ToList();

            return items;
        }

        public Sale? GetSaleWithVehicle(int saleId)
        {
            return _context.Sales
                .Include(s => s.Vehicle)
                .FirstOrDefault(s => s.SaleId == saleId);
        }
    }
}

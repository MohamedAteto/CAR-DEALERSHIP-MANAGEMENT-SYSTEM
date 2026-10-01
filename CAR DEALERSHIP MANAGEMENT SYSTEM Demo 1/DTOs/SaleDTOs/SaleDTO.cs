using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.SaleDTOs
{
    public class SaleDTO
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
        public string? Notes { get; set; }

        public int CustomerId { get; set; }


        public int EmployeeId { get; set; }


        public int VehicleId { get; set; }
    }
}

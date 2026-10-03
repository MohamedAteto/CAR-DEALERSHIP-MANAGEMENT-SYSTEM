using System.ComponentModel.DataAnnotations;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustmorProfileDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.SaleDTOs;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustomerDTOs
{
    public class CustmorDTO
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DriverLicenseNumber { get; set; }
        public List<SaleHistoryDTO> PurchaseHistory { get; set; } = new();
        public int TotalVehiclesPurchased { get; set; }
        public decimal TotalMoneySpent { get; set; }

        public CreateCustmorProfileDTO? Profile { get; set; }
    }
}

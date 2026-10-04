using System.ComponentModel.DataAnnotations;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustmorProfileDTOs;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustomerDTOs
{
    public class CustmorDTO
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal TotalMoneySpent { get; set; }

        public int TotlaVehicles { get; set; }
        public CustmorProfileDTO CustomerProfile { get; set; }
    }
}

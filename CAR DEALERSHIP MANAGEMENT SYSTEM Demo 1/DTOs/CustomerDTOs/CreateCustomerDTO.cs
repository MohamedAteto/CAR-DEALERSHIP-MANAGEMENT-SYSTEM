using System.ComponentModel.DataAnnotations;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustmorProfileDTOs;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustomerDTOs
{
    public class CreateCustomerDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DriverLicenseNumber { get; set; }

        public CreateCustmorProfileDTO CustmorProfile { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustmorProfileDTOs
{
    public class CustmorProfileDTO
    {
        public int CustomerProfileId { get; set; }
        public string CustomerAddress { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerNationality { get; set; }
        public int CustomerId { get; set; }
    }
}

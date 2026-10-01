using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustmorProfileDTOs
{
    public class CreateCustmorDTO
    {
        public int CustomerProfileId { get; set; }
        public string CustomerAddress { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerNationality { get; set; }
        public DateTime? CustomerDateOfBirth { get; set; }
        public int CustomerId { get; set; }
    }
}

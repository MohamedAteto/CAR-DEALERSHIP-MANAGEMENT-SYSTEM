namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustmorProfileDTOs
{
    public class UpdateCustmorProfileDTO
    {
        public int CustomerProfileId { get; set; }
        public string CustomerAddress { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerNationality { get; set; }
        public DateTime? CustomerDateOfBirth { get; set; }
        public int CustomerId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.EmployeeDTOs
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeePosition { get; set; }
        public string EmployeeEmail { get; set; }
        public string? EmployeePhoneNumber { get; set; }
        public int? SalesCount { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models
{
    [Index(nameof(EmployeeEmail), IsUnique = true)]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required,MaxLength(150)]
        public string EmployeeFullName { get; set; }
        [Required, MaxLength(100)]
        public string EmployeePosition { get; set; }
        [Required, EmailAddress]
        public string EmployeeEmail { get; set; }
        [MaxLength(20)]
        public string? EmployeePhoneNumber { get; set; }
        [Required]
        public string EmployeeHireDate { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}

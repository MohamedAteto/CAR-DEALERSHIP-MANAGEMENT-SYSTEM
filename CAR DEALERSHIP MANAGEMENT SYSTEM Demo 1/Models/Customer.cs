using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(DriverLicenseNumber), IsUnique = true)]
    public class Customer
    {

        [Key]
        public int CustomerId { get; set; }
        [Required,MaxLength(150)]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(30)]
        public string DriverLicenseNumber { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();


        //public int CustomerProfileId { get; set; }
        //[ForeignKey("CustomerProfileId")]
        public CustomerProfile CustomerProfile { get; set; }



    }


}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models
{
    public class CustomerProfile
    {
        [Key]
        public int CustomerProfileId { get; set; }
        [Required,MaxLength(250)]
        public string CustomerAddress { get; set; }
        [ MaxLength(100)]
        public string? CustomerCity { get; set; }
        [MaxLength(500)]
        public string? CustomerNationality { get; set; }
        public DateTime? CustomerDateOfBirth { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }


    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models
{
    [Index(nameof(VIN), IsUnique = true)]

    public class Vehicle
    {
       


        [Key]
        public int VehicleId { get; set; }
        [Required,MaxLength(100)]
        public string Make { get; set; }
        [Required, MaxLength(100)]
        public string Model { get; set; }
        [Required]

        public int Year { get; set; }
        [MaxLength(50)]
        public string? Color { get; set; }
        [Required , Range(1 , int.MaxValue)]
        public decimal VehiclePrice { get; set; }
        [Required, Range(1, int.MaxValue)]

        public int Mileage { get; set; }
        [Required, MaxLength(17)]

        public string VIN { get; set; }
        [MaxLength(30)]
        public string? FuelType { get; set; }
        [MaxLength(30)]
        public string Transmission { get; set; }
        [Required,DefaultValue("Available")]
        public string Status { get; set; }



        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }


        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}

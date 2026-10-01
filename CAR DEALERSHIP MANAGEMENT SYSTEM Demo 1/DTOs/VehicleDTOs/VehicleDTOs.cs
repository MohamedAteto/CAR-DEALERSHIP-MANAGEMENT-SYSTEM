using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.VehicleDTOs
{
    public class VehicleDTOs
    {
        public int VehicleId { get; set; }
        
        public string Make { get; set; }
    
        public string Model { get; set; }
        
        public int Year { get; set; }
        public string? Color { get; set; }
        public decimal VehiclePrice { get; set; }

        public int Mileage { get; set; }

        public string? FuelType { get; set; }
        public string Transmission { get; set; }
        public string Status { get; set; }

        public int CategoryId { get; set; }
    }
}

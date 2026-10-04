using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.VehicleDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public VehicleController(IUnitOfWork unit )
        {
            _unit = unit;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();

        }

        [HttpPost]
        public IActionResult AddVehicle([FromBody] CreateVehicleDTO vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle object is null");
            }
            var EntityVehicle = _mapper.Map<Vehicle>(vehicle);

            _unit.VehicleRepo.Create(EntityVehicle);

            _unit.Save();


            return Ok("Vehicle added successfully");
        }

        [HttpGet]
        public IActionResult GetAllVehiclesInDetials()
        {
            var vehicles = _unit.VehicleRepo.Get_available_vehicles_with_category_newest_yearthenlowest_price();

            if(vehicles == null || !vehicles.Any())
                return NotFound("No vehicles found.");
            
            var vehicleDTOs = _mapper.Map<List<VehicleDTO>>(vehicles);
            return Ok(vehicleDTOs);
        }


        [HttpPut]
        public IActionResult UpdateVehicle(int id ,[FromBody] UPdateVehicleDTO vehicle)
        {
            if (vehicle == null)
                return BadRequest("Vehicle object is null");


            
            var existingVehicle = _unit.VehicleRepo.GetById(id);

            if (existingVehicle == null)
                return NotFound($"Vehicle with ID {id} not found.");
            
            _mapper.Map( source: vehicle,destination: existingVehicle);
            _unit.VehicleRepo.Update(id ,existingVehicle);

            _unit.Save();


            return Ok("Vehicle updated successfully");
        }

        [HttpDelete]
        public IActionResult DeleteVehicle(int id)
        {
            var existingVehicle = _unit.VehicleRepo.GetById(id);

            if (existingVehicle == null)
                return NotFound($"Vehicle with ID {id} not found.");

            if (existingVehicle.Status == "Sold")
                return BadRequest("Cannot delete a sold vehicle.");

            _unit.VehicleRepo.Delete(id);
            _unit.Save();

            return Ok("Vehicle deleted successfully");
        }
    }
}

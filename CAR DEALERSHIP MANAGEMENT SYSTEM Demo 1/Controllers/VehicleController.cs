using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.VehicleDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase 
    {

        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public VehicleController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(s =>  s.AddProfile<MappingProfiles>()).CreateMapper();
        }


        [HttpGet("Get Vehicles")]
        public IActionResult Get()
        {
            var items = _unit.VehiclRepo.GetAvailableVehicles()
                .OrderBy(s => s.Year)
                .ThenBy(s => s.VehiclePrice).ToList();

            if (items is null)
                return NotFound();

            var DTO = _mapper.Map<List<VehicleDTO>>(items);


            return Ok(DTO);
        }

        [HttpPost]
        public IActionResult Add(CreateVehicleDTO item)
        {
            if (item is null)
                return BadRequest("The entary data isn't good");

            var Entity = _mapper.Map<Vehicle>(item);

            return NoContent();

        }

        [HttpPut]
        public IActionResult Update(int id , UPdateVehicleDTO dTO)
        {
            if (dTO is null)
                return NotFound();

            var item = _unit.VehiclRepo.GetById(id);

            if (item is null)
                return NotFound();

            _mapper.Map( destination : item , source : dTO);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = _unit.VehiclRepo.GetById(id);

            if (item is null)
                return NotFound();

            if (item.Status == "Sold")
                return BadRequest("this Car Has Sold");

            _unit.VehiclRepo.Delete(id);

            return NoContent();
        }

    }
}

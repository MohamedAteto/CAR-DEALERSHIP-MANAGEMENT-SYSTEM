using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CategoryDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.EmployeeDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDTO DTO)
        {
            if (DTO is null)
                return BadRequest("this data isn't good");

            var Entity = _mapper.Map<Employee>(DTO);

            _unit.EmployeeRepo.Add(Entity);
            return NoContent();
        }


        public IActionResult Get()
        {
            var items = _unit.EmployeeRepo.GetAllOrderdBySalesNumbers();

            if (items is null)
                return BadRequest("Thier isn't data");

            var DTO = _mapper.Map<List<EmployeeDTO>>(items);
            return Ok(DTO);
        }


        [HttpPut]
        public IActionResult Update(int id, UpdateEmployeeDTO DTO)
        {

            if (DTO is null)
                return NotFound();

            var item = _unit.EmployeeRepo.GetById(id);
            if (item is null)
                return NotFound();

            var Entity = _mapper.Map(source: DTO, destination: item);
            _unit.EmployeeRepo.Update(id, Entity);

            return NoContent();


        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = _unit.EmployeeRepo.GetById(id);

            if (item is null)
                return NotFound();

            if (item.Sales.Count == 0)
            {
                _unit.EmployeeRepo.Delete(id);

                return NoContent();
            }

            return BadRequest("their is a cars in this category");


        }


    }
}

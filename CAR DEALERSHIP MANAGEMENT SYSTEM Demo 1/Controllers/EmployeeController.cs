using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.EmployeeDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            _mapper = new MapperConfiguration(s => s.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeDTO DTO)
        {
            if (DTO is null)
                return BadRequest("this is null bro");

            var Entity = _mapper.Map<Employee>(DTO);

            _unit.EmployeeRepo.Create(Entity);
            _unit.Save();

            return Ok("Added Succefully !!");
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _unit.EmployeeRepo.GetEployeeWith_Salescount_orderby_highest_sales();

            if (items is null)
                return BadRequest("Thier isn't Date");

            var DTO = _mapper.Map<List<EmployeeDTO>>(items);

            return Ok(DTO);
        }

        [HttpPut]
        public IActionResult Update(int id, UpdateEmployeeDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Thier isn't data");

            var Exist = _unit.EmployeeRepo.GetById(id);
            if (Exist is null)
                return NotFound();

            _mapper.Map(source: DTO, destination: Exist);
            _unit.EmployeeRepo.Update(id, Exist);
            _unit.Save();
            return Ok("Updated !");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var item = _unit.EmployeeRepo.GetById(id);

            if (item is null)
                return NotFound();

            if (!item.Sales.Any())
                return BadRequest("Can't Remove Object with assoitated Sales Recoards");

            _unit.EmployeeRepo.Delete(id);
            _unit.Save();

            return Ok("Deleted !!");

        }
    }
}
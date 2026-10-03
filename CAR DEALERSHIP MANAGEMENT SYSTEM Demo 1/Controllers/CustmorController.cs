using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustomerDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustmorController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public CustmorController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();
        }

   
        [HttpPost]
        public IActionResult Create([FromBody] CreateCustomerDTO dto)
        {
            if (dto is null)
                return BadRequest("Invalid customer data.");



            if (_unit.CustmorRepo.EmailExists(dto.Email))
                return BadRequest($"The email '{dto.Email}' is already in use.");



            var customer = _mapper.Map<Customer>(dto);

            _unit.CustmorRepo.Add(customer);
            _unit.Save();

            return StatusCode(StatusCodes.Status201Created, customer);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _unit.CustmorRepo.GetCustomerWithDetails(id);

            if (customer is null)
                return NotFound($"Customer with ID {id} not found.");

            var result = _mapper.Map<CustmorDTO>(customer);

            // Calculate business metrics
            result.TotalVehiclesPurchased = customer.Sales.Count;
            result.TotalMoneySpent = customer.Sales.Sum(s => s.SalePrice); 

            return Ok(result);
        }

  
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateCustmorDTO dto)
        {
            if (dto is null)
                return BadRequest("Invalid update payload.");

            var customer = _unit.CustmorRepo.GetCustomerWithDetails(id);

            if (customer is null)
                return NotFound($"Customer with ID {id} not found.");

            if (_unit.CustmorRepo.EmailExists(dto.Email))
                return BadRequest($"The email '{dto.Email}' is already in use by another customer.");

            _mapper.Map(dto, customer);

            _unit.CustmorRepo.Update(customer.CustomerId,customer);
            _unit.Save();

            return Ok(customer);
        }

    
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _unit.CustmorRepo.GetById(id);

            if (customer is null)
                return NotFound($"Customer with ID {id} not found.");

            // Check if customer has recorded sales
            if (_unit.CustmorRepo.HasSales(id))
                return BadRequest("Cannot delete customer because they have recorded sales history.");

            _unit.CustmorRepo.Delete(id);
            _unit.Save();

            return NoContent();
        }
    }
}

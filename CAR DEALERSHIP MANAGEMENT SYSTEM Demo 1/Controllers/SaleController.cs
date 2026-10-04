using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.EmployeeDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.SaleDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Implemntaion;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public SaleController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(s => s.AddProfile<MappingProfiles>()).CreateMapper();
        }

        public IActionResult CreateSale([FromBody] CreateSaleDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid payload.");

            var customer = _unit.CustomerRepo.GetById(dto.CustomerId);
            if (customer == null)
                return NotFound($"Customer with ID {dto.CustomerId} was not found.");

            var employee = _unit.EmployeeRepo.GetById(dto.EmployeeId);
            if (employee == null)
                return NotFound($"Employee with ID {dto.EmployeeId} was not found.");

            var vehicle = _unit.VehicleRepo.GetById(dto.VehicleId);
            if (vehicle == null)
                return NotFound($"Vehicle with ID {dto.VehicleId} was not found.");

            if (!string.Equals(vehicle.Status, "Available", StringComparison.OrdinalIgnoreCase))
                return BadRequest($"Vehicle '{vehicle.Make} {vehicle.Model}' (ID: {vehicle.VehicleId}) is not available for sale. Current status: '{vehicle.Status}'.");

            var sale = _mapper.Map<Sale>(dto);
            _unit.SaleRepo.Create(sale);

            vehicle.Status = "Sold";
            _unit.VehicleRepo.Update(vehicle.VehicleId, vehicle);

            _unit.Save();

            return Ok("Sale created successfully and vehicle status updated to 'Sold'.");
        }
            [HttpGet]
        public IActionResult GetSales()
        {
            var sales = _unit.SaleRepo.Get_sales_with_related_details_groupby_employee_calculate_revenue();

            if (sales == null)
                return BadRequest("NotFound");

            var employees = sales
                .GroupBy(s => s.EmployeeId)
                .Select(g => g.First().Employee)
                .ToList();

            var result = _mapper.Map<List<EmployeeDTO>>(employees);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, [FromBody] UpdateSaleDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid payload.");

            var existingSale = _unit.SaleRepo.GetById(id);
            if (existingSale == null)
                return NotFound($"Sale with ID {id} not found.");

            existingSale.PaymentMethod = dto.PaymentMethod;
            existingSale.Notes = dto.Notes;

            _unit.SaleRepo.Update(id, existingSale);
            _unit.Save();

            return Ok("Sale updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            var existingSale = _unit.SaleRepo.GetById(id);
            if (existingSale == null)
                return NotFound($"Sale with ID {id} not found.");

            var vehicle = _unit.VehicleRepo.GetById(existingSale.VehicleId);
            if (vehicle != null)
            {
                vehicle.Status = "Available";
                _unit.VehicleRepo.Update(vehicle.VehicleId, vehicle);
            }

            _unit.SaleRepo.Delete(id);
            _unit.Save();

            return Ok("Sale deleted and vehicle marked back as Available.");
        }
    }
}

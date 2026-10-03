using System.Reflection.Metadata.Ecma335;
using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.SaleDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;
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

        public SaleController(IUnitOfWork context)
        {
            _unit = context;
            _mapper = new MapperConfiguration(s => s.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost]
        public IActionResult Create(CreateSaleDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Data Isn't good");


            var Customer = _unit.CustmorRepo.GetById(DTO.CustomerId);
            if (Customer is null)
                return BadRequest($"Customer with ID {DTO.CustomerId} does not exist.");


            var employee = _unit.EmployeeRepo.GetById(DTO.EmployeeId);
            if (employee is null)
                return BadRequest($"Employee with ID {DTO.EmployeeId} does not exist.");


            var vehicle = _unit.VehiclRepo.GetById(DTO.VehicleId);
            if (vehicle is null)
                return BadRequest($"Vehicle with ID {DTO.VehicleId} does not exist.");

            if (vehicle.Status == "Sold")
                return BadRequest($"Vehicle with ID {DTO.VehicleId} is already marked as sold.");


            var Entity = _mapper.Map<Sale>(DTO);
            Entity.SaleDate = DateTime.Now;
            vehicle.Status = "Sold";

            _unit.VehiclRepo.Update(vehicle.VehicleId,vehicle);

            _unit.SaleRepo.Add(Entity);

            return NoContent();


        }


        [HttpGet]
        public IActionResult GetGroupedByEmployee()
        {
            var sales = _unit.SaleRepo.GetSalesWithDetials();

            var result = sales
                .GroupBy(s => new { s.EmployeeId, EmployeeName = s.Employee != null ? s.Employee.EmployeeFullName : "Unknown" })
                .Select(g => new EmployeeSalesGroupDto
                {
                    EmployeeId = g.Key.EmployeeId,
                    EmployeeName = g.Key.EmployeeName,
                    TotalRevenue = g.Sum(s => s.SalePrice),
                    TotalSalesCount = g.Count(),
                    Sales = g.Select(s => new SaleDTO
                    {
                        SaleId = s.SaleId,
                        SaleDate = s.SaleDate,
                        TotalAmount = s.SalePrice,
                        PaymentMethod = s.PaymentMethod,
                        Notes = s.Notes,
                        CustomerId = s.CustomerId,
                        VehicleId = s.VehicleId,
                        VehicleVIN = s.Vehicle != null ? s.Vehicle.VIN : "N/A"
                    }).ToList()
                })
                .ToList();

            return Ok(result);
        }

        // PUT: /api/sales/{id}
        // Requirement: Update payment method or notes.
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateSaleDTO dto)
        {
            if (dto is null)
                return BadRequest("Invalid update payload.");

            var sale = _unit.SaleRepo.GetById(id);

            if (sale is null)
                return NotFound($"Sale record with ID {id} not found.");

            // Update only allowed fields
            sale.PaymentMethod = dto.PaymentMethod;
            sale.Notes = dto.Nots;

            _unit.SaleRepo.Update(id,sale);
            _unit.Save();

            return Ok(sale);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sale = _unit.SaleRepo.GetSaleWithVehicle(id);

            if (sale is null)
                return NotFound($"Sale record with ID {id} not found.");

            if (sale.Vehicle != null)
            {
                sale.Vehicle.Status = "Available";
                _unit.VehiclRepo.Update(sale.VehicleId,sale.Vehicle);
            }

            _unit.SaleRepo.Delete(id);

            return NoContent();
        }

    }
}

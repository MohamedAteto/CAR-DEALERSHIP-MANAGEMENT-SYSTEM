using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CustomerDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public CustomerController(IUnitOfWork context)
        {
            _unit = context;
            _mapper = new MapperConfiguration(d => d.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost]
        public IActionResult CreateCustomerWithProfile([FromBody] CreateCustomerDTO customerWithProfileDTO)
        {
            if (customerWithProfileDTO == null)
                return BadRequest("Customer data is null.");
            
            var customer = _mapper.Map<Customer>(customerWithProfileDTO);

            var customerProfile = _mapper.Map<CustomerProfile>(customerWithProfileDTO);

            customer.CustomerProfile = customerProfile;
            _unit.CustomerRepo.Create(customer);

            _unit.customerProfileRepo.Create(customerProfile);

            _unit.Save();
            return Ok("Created Succesfully");
        }

        [HttpGet] 
        public IActionResult GetAllCustomersWithAnyRelatedDetails()
        {
            var items = _unit.CustomerRepo.Customer_profile_purchase_history_total_vehicles_and_money_spent();

            if(items is null)
                return BadRequest("No Customers Found");


            var customerDTOs = _mapper.Map<List<CustmorDTO>>(items);
            return Ok(customerDTOs);
        }

        [HttpPut]
        public IActionResult UPdateCustomerAndProfile(int id ,[FromBody] UpdateCustmorDTO updateCustmorDTO)
        {
            if (updateCustmorDTO == null)
                return BadRequest("Customer data is null.");


            var customer = _unit.CustomerRepo.GetById(id);
            if (customer == null)
                return NotFound("Customer not found.");


            var customerProfile = _unit.customerProfileRepo.GetById(customer.CustomerProfile.CustomerProfileId);
            if (customerProfile == null)
                return NotFound("Customer profile not found.");


            _mapper.Map(updateCustmorDTO, customer);
            _mapper.Map(updateCustmorDTO, customerProfile);

            _unit.CustomerRepo.Update(id,customer);
            _unit.customerProfileRepo.Update(customerProfile.CustomerProfileId , customerProfile);

            _unit.Save();

            return Ok("Updated Successfully");
        }

        [HttpDelete]
        public IActionResult DeleteCustomerAndProfile(int id)
        {

            var customer = _unit.CustomerRepo.GetById(id);
            if (customer == null)
                return NotFound("Customer not found.");


            var customerProfile = _unit.customerProfileRepo.GetById(customer.CustomerProfile.CustomerProfileId);
            if (customerProfile == null)
                return NotFound("Customer profile not found.");

            if(customer.Sales.Any())
                return BadRequest("Cannot delete customer with associated sales.");


            _unit.CustomerRepo.Delete(id);
            _unit.customerProfileRepo.Delete(customerProfile.CustomerProfileId);

            _unit.Save();

            return Ok("Deleted Successfully");
        }

    }
}

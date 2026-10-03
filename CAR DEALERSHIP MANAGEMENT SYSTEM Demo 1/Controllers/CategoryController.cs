using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CategoryDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        public CategoryController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(s => s.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost]
        public IActionResult Create(CategoryDTO category)
        {
            if (category is null)
                return BadRequest();

            var Entity = _mapper.Map<Category>(category);

            _unit.CategoryRepo.Add(Entity);
            return Ok(Entity);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _unit.CategoryRepo.GetCategoriesWithVehicleCount();
            if (items is null)
                return NotFound();

            var DTO = _mapper.Map<CategoryDTO>(items);

            return Ok(DTO);
        }

        [HttpPut]
        public IActionResult Update(int id , UpdateCategoryDTO DTO)
        {

            if (DTO is null)
                return NotFound();

            var item = _unit.CategoryRepo.GetById(id);
            if (item is null)
                return NotFound();

            var Entity = _mapper.Map(source: DTO, destination: item);
            _unit.CategoryRepo.Update(id, Entity);

            return NoContent();

            
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = _unit.CategoryRepo.GetById(id);

            if (item is null)
                return NotFound();

            if (item.Vehicles.Count == 0)
            {
                _unit.CategoryRepo.Delete(id);

                return NoContent();
            }

                return BadRequest("their is a cars in this category");

           
        }


    }
}

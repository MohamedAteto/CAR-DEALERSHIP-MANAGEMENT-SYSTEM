using AutoMapper;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.DTOs.CategoryDTOs;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Mapping;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Models;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo_1.Reposatories.Interface;
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
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfiles>()).CreateMapper();

        }



        [HttpPost]
        public IActionResult AddCategory([FromBody] CreateCategoryDTO category)
        {

            if (category == null)
                return BadRequest("Category object is null or name is empty");


            var EntityCategory = _mapper.Map<Category>(category);


            _unit.CategoryRepo.Create(EntityCategory);

            _unit.Save();

            return Ok("Category added successfully");
        }


        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _unit.CategoryRepo.Get_Categories_With_CountOf_Vehicles();

            if (categories == null || !categories.Any())
                return NotFound("No categories found.");

            
            var categoryDTOs = _mapper.Map<List<CategoryDTO>>(categories);
            return Ok(categoryDTOs);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryDTO category)
        {
            if (category == null)
                return BadRequest("Category object is null or name is empty");

            var existingCategory = _unit.CategoryRepo.GetById(id);
            if (existingCategory == null)
                return NotFound($"Category with ID {id} not found.");


            _mapper.Map(category, existingCategory);
            _unit.CategoryRepo.Update(id,existingCategory);

            _unit.Save();


            return Ok("Category updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            var existingCategory = _unit.CategoryRepo.GetById(id);
            if (existingCategory == null)
                return NotFound($"Category with ID {id} not found.");

            if(existingCategory.Vehicles.Any())
                return BadRequest("Cannot delete category with associated vehicles.");


            _unit.CategoryRepo.Delete(id);

            _unit.Save();

            return Ok("Category deleted successfully");
        }
    }
}
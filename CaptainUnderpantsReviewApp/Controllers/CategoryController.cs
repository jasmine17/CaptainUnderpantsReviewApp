using CaptainUnderpantsReviewApp.Interfaces;
using CaptainUnderpantsReviewApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CaptainUnderpantsReviewApp.Dto;

namespace CaptainUnderpantsReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories();

            if(!ModelState.IsValid)
                return BadRequest
                    (ModelState);
            return Ok(categories);
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200,Type=typeof(Category))]
        public IActionResult GetCategory(int id)
        {
            if (!_categoryRepository.CategoryExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var cat = _categoryRepository.GetCategory(id);

            return Ok(cat);
        }

        [HttpGet("captain/{id}")]
        [ProducesResponseType(200,Type=typeof(Category))]
        public IActionResult GetCaptainUnderpantByCategory(int id)
        {
            if (!_categoryRepository.CategoryExists(id))
                return NotFound();

            var cat = _categoryRepository.GetCaptainUnderpantByCategory(id);

            return Ok(cat);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest();

            var category = _categoryRepository.GetCategories()
                .Where(c=>c.Name.Trim().ToUpper()==categoryCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if(category!=null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryMap = _mapper.Map<Category>(categoryCreate);

            if(!_categoryRepository.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        
        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryDto updateCategory)
        {
            if (updateCategory == null)
                return BadRequest(ModelState);

            if(categoryId!=updateCategory.Id)
                return BadRequest(ModelState);

            //if (_categoryRepository.CategoryExists(categoryId))
            //    return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var categoryMap = _mapper.Map<Category>(updateCategory);

            if(!_categoryRepository.UpdateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong updateing category");
                return StatusCode(500,ModelState);
            }
            return NoContent();
        }
    }
}

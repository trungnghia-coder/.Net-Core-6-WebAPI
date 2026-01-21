using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Data.MyDBContext _context;
        public CategoriesController(Data.MyDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            try
            {
                var categories = _context.categories.ToList();
                return Ok(categories);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateCategory(Models.CategoryModel model)
        {
            try
            {
                var category = new Data.Category
                {
                    Name = model.Name
                };
                _context.categories.Add(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, category);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Models.CategoryModel model)
        {
            var category = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            try
            {
                category.Name = model.Name;
                _context.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            try
            {
                _context.categories.Remove(category);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

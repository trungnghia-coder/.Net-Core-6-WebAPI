using Microsoft.AspNetCore.Mvc;
using WebApiNet.Repository;

namespace WebApiNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IMerchandiseRepository _merchandiseRepository;

        public ProductsController(IMerchandiseRepository merchandiseRepository)
        {
            _merchandiseRepository = merchandiseRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            try
            {
                var result = _merchandiseRepository.getAll(search ?? "", from, to, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We can't get the product.");
            }
        }
    }
}

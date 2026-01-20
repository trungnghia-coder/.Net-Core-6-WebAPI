using Microsoft.AspNetCore.Mvc;
using WebApiNet.Models;

namespace WebApiNet.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]             
    public class MerchandiseController : ControllerBase 
    {
        public static List<Models.Merchandise> merchandises = new List<Models.Merchandise>
        {
            new Models.Merchandise { MerchandiseId = Guid.NewGuid(), MerchandiseName = "Áo thun", Price = 150000 },
            new Models.Merchandise { MerchandiseId = Guid.NewGuid(), MerchandiseName = "Quần jeans", Price = 300000 },
            new Models.Merchandise { MerchandiseId = Guid.NewGuid(), MerchandiseName = "Giày thể thao", Price = 500000 }
        };


        [HttpGet] 
        public IActionResult GetAll()
        {
            return Ok(merchandises); 
        }

        [HttpGet("{id}")]
        public IActionResult GetById(String id)
        {
            try
            {
                var hangHoa = merchandises.SingleOrDefault(hh => hh.MerchandiseId == Guid.Parse(id));
                if(hangHoa == null)
                {
                    return NotFound();
                }
                return Ok(hangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(MerchandiseVM newMerchandise)
        {
            var hangHoa = new Merchandise
            {
                MerchandiseId = Guid.NewGuid(),
                MerchandiseName = newMerchandise.MerchandiseName,
                Price = newMerchandise.Price
            };
            merchandises.Add(hangHoa);
            return Ok(new
            {
                Success = true,
                Message = "Đã thêm hàng hóa thành công!",
                Data = hangHoa
            });
        }


    }
}

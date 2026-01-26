using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAPINetCore.Models;
using MyAPINetCore.Repositories;

namespace MyAPINetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBookRepository _bookRepo;

        public ProductController(IBookRepository repo)
        {
            _bookRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _bookRepo.GetAllBooksAsync();
                return Ok(books);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            try
            {
                var book = await _bookRepo.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound($"Book with ID {id} not found");
                }
                return Ok(book);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddBook([FromBody] BookModel book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var bookId = await _bookRepo.AddBookAsync(book);
                return CreatedAtAction(nameof(GetBookById), new { id = bookId }, book);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookModel book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedBook = await _bookRepo.UpdateBookAsync(id, book);
                if (updatedBook == null)
                {
                    return NotFound($"Book with ID {id} not found");
                }

                return Ok(updatedBook);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var result = await _bookRepo.DeleteBookAsync(id);
                if (!result)
                {
                    return NotFound($"Book with ID {id} not found");
                }

                return NoContent();
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

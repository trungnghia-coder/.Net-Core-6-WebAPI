using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using MyAPINetCore.Data;
using MyAPINetCore.Models;

namespace MyAPINetCore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookStoreContext _context;
        private IMapper _mapper;

        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddBookAsync(BookModel book)
        {
            var newBook = _mapper.Map<Books>(book);
            _context.Books!.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books!.FindAsync(id);
            if (book == null)
            {
                return false;
            }

            _context.Books!.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var books = await _context.Books!.ToListAsync();
            return _mapper.Map<List<BookModel>>(books);
        }

        public async Task<BookModel?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books!.FindAsync(id);
            return _mapper.Map<BookModel>(book);
        }

        public async Task<BookModel?> UpdateBookAsync(int id, BookModel bookModel)
        {
            var book = await _context.Books!.FindAsync(id);
            if (book == null)
            {
                return null;
            }

            book.Title = bookModel.Title;
            book.Description = bookModel.Description;
            book.Price = bookModel.Price;
            book.Quantity = bookModel.Quantity;

            _context.Books!.Update(book);
            await _context.SaveChangesAsync();

            return _mapper.Map<BookModel>(book);
        }
    }
}

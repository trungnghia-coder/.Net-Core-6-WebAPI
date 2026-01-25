using MyAPINetCore.Models;

namespace MyAPINetCore.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBooksAsync();
        public Task<BookModel?> GetBookByIdAsync(int id);
        public Task<int> AddBookAsync(BookModel book);
        public Task<BookModel?> UpdateBookAsync(int id, BookModel book);
        public Task<bool> DeleteBookAsync(int id);
    }
}

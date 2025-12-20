using LibraryManagementApi.Data;
using LibraryManagementApi.Interfaces.IServices;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();

        }

        public void Add(Book book)
        {
            _context.AddAsync(book);
            _context.SaveChanges();


        }
    }
}

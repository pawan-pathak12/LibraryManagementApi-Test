using LibraryManagementApi.Interfaces;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Services
{
    public class BookService : IBookService
    {
        private static readonly List<Book> _books = new List<Book>();
        public IEnumerable<Book> GetAll()
        {
            return new List<Book>
            {
                new Book
                {
                    Id=1 , Title="CLean Code",Author ="Robert C. Martin" ,Price=500
                }
            };
        }

        public void Add(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);

        }
    }
}

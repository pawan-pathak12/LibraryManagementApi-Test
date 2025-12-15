using LibraryManagementApi.Interfaces;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Tests.Fakes
{
    public class EmptyBookService : IBookService
    {
        private static readonly List<Book> _books = new();
        public IEnumerable<Book> GetAll()
        {
            return new List<Book>();
        }

        public void Add(Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
        }
    }
}

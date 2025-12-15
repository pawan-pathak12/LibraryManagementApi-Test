using LibraryManagementApi.Interfaces;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Tests.Fakes
{
    public class EmptyBookService : IBookService
    {
        public IEnumerable<Book> GetAll()
        {
            return new List<Book>();
        }
    }
}

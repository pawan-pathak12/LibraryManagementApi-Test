using LibraryManagementApi.Interfaces;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Services
{
    public class BookService : IBookService
    {

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
    }
}

using LibraryManagementApi.Models;

namespace LibraryManagementApi.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();

    }
}

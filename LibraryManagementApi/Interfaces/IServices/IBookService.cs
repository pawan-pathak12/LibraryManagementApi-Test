using LibraryManagementApi.Models;

namespace LibraryManagementApi.Interfaces.IServices
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        void Add(Book book);

    }
}

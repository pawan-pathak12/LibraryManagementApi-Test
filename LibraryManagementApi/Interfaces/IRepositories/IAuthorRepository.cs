using LibraryManagementApi.Models;

namespace LibraryManagementApi.Interfaces.IRepositories
{
    public interface IAuthorRepository
    {
        void Add(Author author);
        List<Author> GetAll();
        Author GetById(int id);
        bool Update(Author author);
        bool Delete(int id);
    }
}

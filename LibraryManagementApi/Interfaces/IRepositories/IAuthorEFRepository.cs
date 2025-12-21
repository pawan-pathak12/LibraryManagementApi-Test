using LibraryManagementApi.Models;

namespace LibraryManagementApi.Interfaces.IRepositories
{
    public interface IAuthorEFRepository
    {
        void Add(Author author);
        Author? GetById(int id);
        IEnumerable<Author> GetAll();
        bool Update(Author author);
        bool Delete(int id);
        bool ExistsByName(string name);
    }
}

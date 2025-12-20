using LibraryManagementApi.Models;

namespace LibraryManagementApi.Interfaces.IServices
{
    public interface IAuthorService
    {
        bool CreateAuthor(Author author);
        List<Author> GetAllAuthor();

        Author GetById(int id);
        bool Update(Author author);
        bool Delete(int id);
    }
}

using LibraryManagementApi.Interfaces.IRepositories;
using LibraryManagementApi.Interfaces.IServices;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Services
{

    public class AuthorService : IAuthorService
    {
        private readonly List<Author> _authors;

        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _authors = new List<Author>();
        }

        public bool CreateAuthor(Author author)
        {
            _authorRepository.Add(author);
            return true;
        }

        public List<Author> GetAllAuthor()
        {
            return _authorRepository.GetAll();
        }
        public Author GetById(int id)
        {
            var author = _authorRepository.GetById(id);

            if (author == null)
            {
                return null;
            }
            return author;

        }

        public bool Update(Author author)
        {
            return _authorRepository.Update(author);
        }

        public bool Delete(int id)
        {
            return _authorRepository.Delete(id);
        }
    }
}

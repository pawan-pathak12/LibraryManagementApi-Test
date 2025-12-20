using LibraryManagementApi.Interfaces.IRepositories;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly List<Author> _authors = new();

        public void Add(Author author)
        {
            _authors.Add(author);
        }

        public List<Author> GetAll()
        {
            _authors.Add(new Author
            {
                Id = 1,
                Name = "Robert"
            });
            return _authors.ToList();
        }
        public Author GetById(int id)
        {
            _authors.Add(new Author { Id = 1, Name = "nom" });

            return _authors.Find(x => x.Id == id);



        }

        public bool Update(Author author)
        {
            var existingAuthor = _authors.FirstOrDefault(a => a.Id == author.Id);

            if (existingAuthor == null)
                return false;

            existingAuthor.Name = author.Name;

            return true;
        }

        public bool Delete(int id)
        {
            var exitingAuthor = _authors.Find(x => x.Id == id);
            if (exitingAuthor == null)
            {
                return false;
            }
            _authors.Remove(exitingAuthor);
            return true;
        }
    }
}

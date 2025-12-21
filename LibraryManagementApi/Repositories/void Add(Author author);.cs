using LibraryManagementApi.Data;
using LibraryManagementApi.Interfaces.IRepositories;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public class AuthorEfRepository : IAuthorEFRepository
    {
        private readonly LibraryDbContext _context;

        public AuthorEfRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public void Add(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public Author? GetById(int id)
        {
            return _context.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public bool Update(Author author)
        {
            var existing = _context.Authors.Find(author.Id);
            if (existing == null) return false;

            existing.Name = author.Name;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var author = _context.Authors.Find(id);
            if (author == null) return false;

            _context.Authors.Remove(author);
            _context.SaveChanges();
            return true;
        }

        public bool ExistsByName(string name)
        {
            return _context.Authors.Any(a => a.Name == name);
        }

    }

}

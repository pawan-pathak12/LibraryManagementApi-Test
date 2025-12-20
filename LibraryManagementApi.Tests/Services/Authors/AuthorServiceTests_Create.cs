using LibraryManagementApi.Interfaces.IRepositories;
using LibraryManagementApi.Interfaces.IServices;
using LibraryManagementApi.Models;
using LibraryManagementApi.Repositories;
using LibraryManagementApi.Services;

namespace LibraryManagementApi.Tests.Services.Authors
{
    [TestClass]
    public class AuthorServiceTests_Create
    {
        private IAuthorService _service;
        private IAuthorRepository _repository;


        [TestInitialize]
        public void Setup()
        {
            _repository = new AuthorRepository(); // in-memory
            _service = new AuthorService(_repository);
        }

        [TestMethod]
        public void CreateAuthor_ValidAuthor_ReturnsTrue()
        {
            var author = new Author { Id = 1, Name = "Ram" };

            // Act
            var result = _service.CreateAuthor(author);

            // Assert
            Assert.IsTrue(result);
        }




    }
}

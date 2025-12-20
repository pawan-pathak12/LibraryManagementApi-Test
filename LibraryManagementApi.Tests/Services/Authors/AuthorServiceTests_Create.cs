using LibraryManagementApi.Models;
using LibraryManagementApi.Repositories;
using LibraryManagementApi.Services;

namespace LibraryManagementApi.Tests.Services.Authors
{
    [TestClass]
    public class AuthorServiceTests_Create
    {
        [TestMethod]
        public void CreateAuthor_ValidAuthor_ReturnsTrue()
        {
            //Arrange 
            var repo = new AuthorRepository();
            var service = new AuthorService(repo);

            var author = new Author { Id = 1, Name = "Ram" };

            // Act
            var result = service.CreateAuthor(author);

            // Assert
            Assert.IsTrue(result);
        }
    }
}

using LibraryManagementApi.Models;
using LibraryManagementApi.Tests.Common;

namespace LibraryManagementApi.Tests.Services.Authors
{
    [TestClass]
    public class AuthorServiceTests_Delete : AuthorServiceTestBase
    {
        [TestMethod]
        public void Delete_WithExistingId_ReturnTrue()
        {
            var author = new Author
            {
                Id = 1,
                Name = "Harry"
            };
            _service.CreateAuthor(author);

            var isDeleted = _service.Delete(author.Id);

            Assert.IsTrue(isDeleted);
        }


        [TestMethod]
        public void Delete_WitNonExistingId_ReturnFalse()
        {
            int id = 12;

            var isDeleted = _service.Delete(id);

            Assert.IsFalse(isDeleted);
        }
    }
}

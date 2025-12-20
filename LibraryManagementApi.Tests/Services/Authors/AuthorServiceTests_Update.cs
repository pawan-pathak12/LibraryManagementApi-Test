using LibraryManagementApi.Models;
using LibraryManagementApi.Tests.Common;

namespace LibraryManagementApi.Tests.Services.Authors
{
    [TestClass]
    public class AuthorServiceTests_Update : AuthorServiceTestBase
    {
        [TestMethod]
        public void Update_WithExistingId_ReturnTrue()
        {
            var author = new Author
            {
                Id = 1,
                Name = "Robert"
            };
            _service.CreateAuthor(author);

            var author2 = new Author
            {
                Id = 1,
                Name = "Ram"
            };
            var isUpdated = _service.Update(author2);

            Assert.IsTrue(isUpdated);
        }

        [TestMethod]
        public void Update_WithNonExisingId_ReturnFalse()
        {
            var author = new Author
            {
                Id = 100,
                Name = "harry"
            };
            var isUpdated = _service.Update(author);

            Assert.IsFalse(isUpdated);
        }
    }
}

using LibraryManagementApi.Tests.Common;

namespace LibraryManagementApi.Tests.Services.Authors
{
    [TestClass]
    public class AuthorServiceTests_Get : AuthorServiceTestBase
    {
        [TestMethod]
        public void GetAllAuthor_ReturnList()
        {
            var authors = _service.GetAllAuthor();

            Assert.IsNotNull(authors);
            Assert.AreNotEqual(0, authors.Count);
        }

        [TestMethod]
        public void GetById_OneMember_WillReturned()
        {
            int id = 1;
            var author = _service.GetById(1);

            Assert.IsNotNull(id);
            Assert.AreEqual(id, author.Id);
        }
        [TestMethod]
        public void GetById_WithNonExistingId_ReturnNull()
        {
            int id = 999;
            var author = _service.GetById(id);

            Assert.IsNull(author);
        }
    }
}

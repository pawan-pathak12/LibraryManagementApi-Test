using System.Net;

namespace LibraryManagementApi.Tests.Controllers.Members
{
    [TestClass]
    public class MemberControllerTests_Delete
    {
        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            var factory = new MemberAPIFactory();
            _client = factory.CreateClient();
        }

        #region API

        [TestMethod]
        public async Task DeleteMember_ExistingId_ReturnsOk()
        {
            int id = 1;

            var isDeleted = await _client.DeleteAsync($"/api/member/{id}");

            Assert.AreEqual(HttpStatusCode.OK, isDeleted.StatusCode);
        }

        [TestMethod]
        public async Task DeleteMember_NonExistingId_ReturnsNotFound()
        {
            var id = 5;

            var isdeleted = await _client.DeleteAsync($"/api/member/{id}");

            Assert.AreEqual(HttpStatusCode.NotFound, isdeleted.StatusCode);
        }
        #endregion
    }
}

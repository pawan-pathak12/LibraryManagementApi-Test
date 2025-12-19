using System.Net;

namespace LibraryManagementApi.Tests.Controllers.Members
{
    [TestClass]
    public class MemberControllerTests_Get
    {
        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            var factory = new MemberAPIFactory();
            _client = factory.CreateClient();
        }

        #region  API test
        [TestMethod]
        public async Task GetMember_ReturnOk()
        {
            var response = await _client.GetAsync("/api/member");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetMemberById_1_ReturnsOk()
        {
            int id = 1;

            var response = await _client.GetAsync($"/api/member/{id}");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task GetMemberById_DontExists_ReturnNotFound()
        {
            int id = 2;
            var response = await _client.GetAsync($"/api/member/{id}");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        #endregion

    }
}

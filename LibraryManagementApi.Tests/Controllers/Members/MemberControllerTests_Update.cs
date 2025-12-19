using LibraryManagementApi.Models;
using System.Net;
using System.Net.Http.Json;

namespace LibraryManagementApi.Tests.Controllers.Members
{
    [TestClass]
    public class MemberControllerTests_Update
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
        public async Task UpdateMember_Return_Ok()
        {
            var member = new Member
            {
                Id = 1,
                Name = "name",
                Email = "email",
                Phone = 1234543211
            };
            var isUpdated = await _client.PutAsJsonAsync("/api/member", member);

            Assert.AreEqual(HttpStatusCode.OK, isUpdated.StatusCode);
        }
        [TestMethod]
        public async Task UpdateMember_WithNotexisitngId_Return_NotFound()
        {
            var member = new Member
            {
                Id = 2,
                Name = "name",
                Email = "email",
                Phone = 1234543211
            };
            var isUpdated = await _client.PutAsJsonAsync("/api/member", member);

            Assert.AreEqual(HttpStatusCode.NotFound, isUpdated.StatusCode);
        }

        #endregion
    }
}

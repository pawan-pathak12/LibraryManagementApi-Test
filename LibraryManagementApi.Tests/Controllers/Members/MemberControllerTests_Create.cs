using LibraryManagementApi.Models;
using System.Net;
using System.Net.Http.Json;

namespace LibraryManagementApi.Tests.Controllers.Members
{
    [TestClass]
    public class MemberControllerTests_Create
    {

        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            var factory = new MemberAPIFactory();
            _client = factory.CreateClient();
        }

        [TestMethod]
        public async Task CreateMember_ReturnOk()
        {
            //Arrange 
            var member = new Member
            {
                Name = "Ram",
                Email = "ram@gmail.com",
                Phone = 9812345678
            };

            //Act 
            var response = await _client.PostAsJsonAsync("/api/member", member);

            //Assert 
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async Task CreateMember_IfValidationFails_ReturnsBadRequest()
        {
            var member = new Member
            {
                Id = 1,
                Name = " ",
                Email = "ram@gmail.com",
                Phone = 981234567
            };

            var result = await _client.PostAsJsonAsync("/api/member", member);

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);

        }

        /*  [TestMethod]
          public async Task CreateMember_ReturnCOnflict_IfEmailIsDuplicate()
          {
              var member = new Member
              {
                  Id = 1,
                  Name = "ram",
                  Email = "ram@gmail.com",
                  Phone = 1234567890
              };
              await _client.PostAsJsonAsync("/api/member", member);


              var member2 = new Member
              {
                  Id = 2,
                  Name = "ram",
                  Email = "ram@gmail.com",
                  Phone = 1234567890
              };
              var created = await _client.PostAsJsonAsync("/api/member", member2);

              Assert.AreEqual(HttpStatusCode.Conflict, created.StatusCode);

          }
        */


    }
}

using LibraryManagementApi.Models;
using LibraryManagementApi.Services;
using System.Net;
using System.Net.Http.Json;

namespace LibraryManagementApi.Tests.ServiceTests
{
    [TestClass]
    public class MemberServiceTests
    {
        private readonly MemberService _memberService;
        public MemberServiceTests()
        {
            _memberService = new MemberService();
        }

        #region First Test step 1-3

        [TestMethod]
        public void CreateMember_ValidData_ReturnStudent()
        {
            //Arrange 
            var name = "Ram";
            var email = "ram@gmail.com";
            var phone = 9812345678;

            //Act 
            var member = _memberService.CreateMember(name, email, phone);

            //Assert 
            Assert.IsNotNull(member);
            Assert.AreEqual(name, member.Name);
            Assert.AreEqual(email, member.Email);
            Assert.AreEqual(phone, member.Phone);
        }

        #endregion

        #region Steo 4 and 5 (Validation-red -green) 

        [TestMethod]

        public void CreateMember_IfNullName_ReturnNull()
        {
            //Arrange 
            var name = "";
            var email = "ram@gmail.com";
            var phone = 9812345678;

            //Act 
            var member = _memberService.CreateMember(name, email, phone);

            //Assert 
            Assert.IsNull(member);

        }

        [TestMethod]
        public void CreateMember_IfNullEmail_ReturnNull()
        {
            //Arrange 
            var name = "ram";
            var email = "";
            var phone = 981234567;

            //Act 
            var member = _memberService.CreateMember(name, email, phone);

            //Assert    
            Assert.IsNull(member);
        }

        [TestMethod]
        public void CreateMember_IfNumberLessthen10_ReturnExeption()
        {
            //Arrange 
            var name = "ram";
            var email = "ram@gmail.com";
            long phone = 123;

            // Act + Assert
            Assert.ThrowsException<ArgumentException>(() =>
                _memberService.CreateMember(name, email, phone)
            );
        }

        #endregion

        #region Step 6 -API Layer (controller)
        //API Testing
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
        #endregion

    }
}

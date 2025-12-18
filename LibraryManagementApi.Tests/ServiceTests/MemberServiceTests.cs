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

        #region Create Member Member

        //Service Tests
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

        //API test 
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

        #endregion

        #region Get Member


        #region  Service test
        [TestMethod]
        public void GetAllMembers_ReturnList_OfMembers()
        {
            var result = _memberService.GetAllMembers();

            //Assert 
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod]
        public void GetMemberById_Return_OneMember()
        {
            //Arrange 
            var id = 1;
            var name = "Ram Nath";
            var email = "ramnath@gmail.com";
            var number = 9812345654;

            var member = _memberService.CreateMember(id, name, email, number);

            //Act 

            var memberById = _memberService.GetMemberById(id);

            //Assert 

            Assert.IsNotNull(memberById);
            Assert.AreEqual(id, memberById.Id);

        }
        #endregion

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

        #endregion

        #endregion

    }
}

using LibraryManagementApi.Services;

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
        [TestMethod]
        public async Task CreateMember_ValidData_ReturnsMember()
        {
            //Arrange 
            string name = "Ram";
            string email = "ram@gmail.com";
            long phone = 9812345678;
            //Act 
            var member = _memberService.CreateMember(name, email, phone);

            //Assert 
            Assert.IsNotNull(member);
            Assert.AreEqual(name, member.Name);
            Assert.AreEqual(email, member.Email);
            Assert.AreEqual(phone, member.Phone);

        }
    }
}

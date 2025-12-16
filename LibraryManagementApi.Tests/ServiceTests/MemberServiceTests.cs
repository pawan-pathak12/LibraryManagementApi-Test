namespace LibraryManagementApi.Tests.ServiceTests
{
    [TestClass]
    public class MemberServiceTests
    {
        private readonly MemberService _memberService;
        [TestMethod]
        public async Task CreateMember_ValidData_ReturnsMember()
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
    }
}

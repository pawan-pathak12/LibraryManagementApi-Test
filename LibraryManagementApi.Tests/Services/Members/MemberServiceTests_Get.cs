using LibraryManagementApi.Services;

namespace LibraryManagementApi.Tests.Services.Members
{
    [TestClass]
    public class MemberServiceTests_Get
    {
        private readonly MemberService _memberService;
        public MemberServiceTests_Get()
        {
            _memberService = new MemberService();
        }
        #region  Service test
        [TestMethod]
        public void GetAllMembers_OfMembers_ReturnList()
        {
            var result = _memberService.GetAllMembers();

            //Assert 
            Assert.IsNotNull(result);
            Assert.AreNotEqual(0, result.Count());
        }

        [TestMethod]
        public void GetMemberById_OneMember_WillReturned()
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
    }
}

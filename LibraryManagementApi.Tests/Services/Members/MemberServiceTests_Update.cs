using LibraryManagementApi.Models;
using LibraryManagementApi.Services;

namespace LibraryManagementApi.Tests.Services.Members
{
    [TestClass]
    public class MemberServiceTests_Update
    {
        private readonly MemberService _memberService;

        public MemberServiceTests_Update()
        {
            _memberService = new MemberService();
        }
        #region Serice test
        [TestMethod]
        public void UpdateMember_WithExisitingId_ReturnsTrue()
        {
            var member = new Member
            {
                Id = 1,
                Name = "nothing",
                Email = "nothing@gmail.com",
                Phone = 1234567890
            };

            var isUpdated = _memberService.UpdateMember(member);

            Assert.IsTrue(isUpdated);

        }

        #endregion

    }
}

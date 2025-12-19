using LibraryManagementApi.Services;

namespace LibraryManagementApi.Tests.Services.Members
{
    [TestClass]
    public class MemberServiceTests_Delete
    {
        private readonly MemberService _memberService;
        public MemberServiceTests_Delete()
        {
            _memberService = new MemberService();
        }
        #region Service Testing 
        [TestMethod]
        public void DeleteMember_WithExistingId_ReturnsTrue()
        {
            int id = 1;

            var isDeleted = _memberService.DeleteMember(id);

            Assert.IsTrue(isDeleted);

        }
        [TestMethod]
        public void DeleteMember_WithNonExistingId_ReturnsFalse()
        {
            int id = 5;

            var isDeleted = _memberService.DeleteMember(id);

            Assert.IsFalse(isDeleted);

        }

        #endregion

    }
}

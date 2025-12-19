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


        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            var factory = new MemberAPIFactory();
            _client = factory.CreateClient();
        }


        #region Update 




        #endregion

    }
}

using LibraryManagementApi.Models;
using LibraryManagementApi.Services;

namespace LibraryManagementApi.Tests.Services.Members
{
    [TestClass]
    public class MemberServiceTests_Create
    {
        private readonly MemberService _memberService;
        public MemberServiceTests_Create()
        {
            _memberService = new MemberService();
        }

        #region   Service Tests

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

        [TestMethod]
        public void CreateMember_ReturnFalse_IfEmailIsInvalid()
        {
            var member = new Member
            {
                Id = 1,
                Name = "Kiran",
                Email = "kirangmail.com",
                Phone = 9812345989
            };

            var createdMember = _memberService.CreateMember(member.Id, member.Name, member.Email, member.Phone);

            Assert.IsFalse(createdMember);
        }

        [TestMethod]
        public void CreateMember_ReturnFalse_IfEmailIsDuplicate()
        {
            int id = 1;
            string name = "Ram";
            string email = "ram@gmail.com";
            long phone = 9812321234;

            _memberService.CreateMember(id, name, email, phone);

            string email2 = "ram@gmail.com";
            var createdMember = _memberService.CreateMember(id, name, email2, phone);


            Assert.IsFalse(createdMember);
        }

        #endregion
    }
}

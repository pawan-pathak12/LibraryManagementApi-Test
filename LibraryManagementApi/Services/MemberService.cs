using LibraryManagementApi.Models;

namespace LibraryManagementApi.Services
{
    public class MemberService
    {
        public Member CreateMember(string name, string email, long phone)
        {
            return new Member
            {
                Name = name,
                Email = email,
                Phone = phone
            };
        }
    }
}

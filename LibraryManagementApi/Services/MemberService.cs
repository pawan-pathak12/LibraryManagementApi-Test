using LibraryManagementApi.Models;

namespace LibraryManagementApi.Services
{
    public class MemberService
    {
        public Member CreateMember(string name, string email, long phone)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                return null;
            }
            if (phone.ToString().Length < 10)
            {
                throw new ArgumentException("Number length should be equal to 10");
            }
            return new Member
            {
                Name = name,
                Email = email,
                Phone = phone
            };
        }
    }
}

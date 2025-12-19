using LibraryManagementApi.Models;

namespace LibraryManagementApi.Services
{
    public class MemberService
    {
        private readonly List<Member> members;
        public MemberService()
        {
            members = new List<Member>();
        }
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
            if (!(email.Contains("@") && email.Contains(".")))
            {
                return null;
            }
            return new Member
            {
                Name = name,
                Email = email,
                Phone = phone
            };

        }
        public bool CreateMember(int id, string name, string email, long phone)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }
            if (phone.ToString().Length < 10)
            {
                throw new ArgumentException("Number length should be equal to 10");
            }
            if (!(email.Contains("@") && email.Contains(".")))
            {
                return false;
            }
            if (members.Any(x => x.Email == email.ToLower()))
            {
                return false;
            }
            members.Add(new Member { Id = 1, Name = name, Email = email, Phone = phone });
            return true;

        }
        public List<Member> GetAllMembers()
        {
            // return members.ToList();
            return new List<Member>
               {
                   new Member { Id=1 , Name="Ram" , Email ="ram@gmail.com" , Phone=9812345678},
                   new Member { Id=1 , Name="Kiran" , Email ="kiran@gmail.com" , Phone=98763212}
               };
        }

        public Member GetMemberById(int id)
        {
            foreach (var member in members)
            {
                if (member.Id == id)
                {
                    return member;
                }
            }
            return null;
        }

        public bool UpdateMember(Member member)
        {
            members.Add(new Member { Id = 1, Name = "ram", Email = "ramemail", Phone = 9862344 });
            var existingMember = GetMemberById(member.Id);
            if (existingMember == null)
            {
                return false;
            }
            existingMember.Name = member.Name;
            existingMember.Email = member.Email;

            return true;
        }

        public bool DeleteMember(int id)
        {
            members.Add(new Member { Id = 1, Name = "ram", Email = "ramemail", Phone = 9862344 });
            members.Add(new Member { Id = 2, Name = "null", Email = "null@gmail.com", Phone = 2262344 });

            var existingMember = GetMemberById(id);
            if (existingMember == null)
            {
                return false;
            }

            members.Remove(existingMember);
            return true;
        }
    }
}

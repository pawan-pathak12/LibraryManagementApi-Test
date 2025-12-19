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
            return new Member
            {
                Name = name,
                Email = email,
                Phone = phone
            };

        }
        public Member CreateMember(int id, string name, string email, long phone)
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
            members.Add(new Member { Id = id, Name = name, Email = email, Phone = phone });

            return new Member
            {
                Id = id,
                Name = name,
                Email = email,
                Phone = phone
            };

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
    }
}

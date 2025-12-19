using LibraryManagementApi.Models;
using LibraryManagementApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MemberService _memberService;

        public MemberController()
        {
            this._memberService = new MemberService();
        }

        [HttpPost]
        public IActionResult Create(Member member)
        {
            var created = _memberService.CreateMember(member.Name, member.Email, member.Phone);
            if (created == null)
            {
                return BadRequest();
            }
            return Ok(created);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _memberService.GetAllMembers();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            int ids = 1;
            string name = "ram";
            string email = "ram";
            long phone = 9812346588;

            var member = _memberService.CreateMember(ids, name, email, phone);

            var result = _memberService.GetMemberById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(Member member)
        {
            var isUpdated = _memberService.UpdateMember(member);
            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok(isUpdated);
        }
    }
}

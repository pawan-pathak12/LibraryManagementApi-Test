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
            return Ok(created);
        }

    }
}

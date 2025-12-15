using LibraryManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var books = new List<Book>
            {
                new Book{Id=1 , Title ="Clean Code" , Author="Nothing " , Price =500}
            };
            return Ok(books);
        }
    }
}

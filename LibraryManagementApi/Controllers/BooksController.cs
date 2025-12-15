using LibraryManagementApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var books = _bookService.GetAll();

            if (!books.Any())
                return NoContent();

            return Ok(books);
        }
    }
}

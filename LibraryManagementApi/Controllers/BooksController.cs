using LibraryManagementApi.Interfaces;
using LibraryManagementApi.Models;
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
        [HttpPost]
        public IActionResult Post(Book book)
        {
            _bookService.Add(book);
            return Created("/api/books", book);
        }
    }
}

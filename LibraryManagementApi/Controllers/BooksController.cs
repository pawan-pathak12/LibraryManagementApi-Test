using LibraryManagementApi.Interfaces.IServices;
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
            if (string.IsNullOrWhiteSpace(book.Title) ||
                string.IsNullOrWhiteSpace(book.Author) ||
                book.Price <= 0)
            {
                return BadRequest();
            }
            _bookService.Add(book);
            return Created("/api/books", book);
        }
    }
}

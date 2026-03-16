using Microsoft.AspNetCore.Mvc;
using LibraryPortalAPI.Data;
using LibraryPortalAPI.Models;

namespace LibraryPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // Get book by ID
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
                return NotFound("Book not found");

            return Ok(book);
        }

        // Add new book
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return Ok("Book added successfully");
        }

        // Update book
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = _context.Books.Find(id);

            if (book == null)
                return NotFound("Book not found");

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Category = updatedBook.Category;
            book.Quantity = updatedBook.Quantity;

            _context.SaveChanges();

            return Ok("Book updated successfully");
        }

        // Delete book
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
                return NotFound("Book not found");

            _context.Books.Remove(book);
            _context.SaveChanges();

            return Ok("Book deleted successfully");
        }
    }
}
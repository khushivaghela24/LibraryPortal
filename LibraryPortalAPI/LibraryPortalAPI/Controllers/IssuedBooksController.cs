using Microsoft.AspNetCore.Mvc;
using LibraryPortalAPI.Data;
using LibraryPortalAPI.Models;

namespace LibraryPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssuedBooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public IssuedBooksController(LibraryContext context)
        {
            _context = context;
        }

        // Issue Book
        [HttpPost("issue")]
        public IActionResult IssueBook(IssuedBook issue)
        {
            var book = _context.Books.Find(issue.BookId);

            if (book == null)
                return NotFound("Book not found");

            if (book.Quantity <= 0)
                return BadRequest("Book not available");

            issue.IssueDate = DateTime.Now;
            issue.Status = "Issued";

            _context.IssuedBooks.Add(issue);

            book.Quantity--;

            _context.SaveChanges();

            return Ok("Book issued successfully");
        }

        // Return Book
        [HttpPost("return/{issueId}")]
        public IActionResult ReturnBook(int issueId)
        {
            var issue = _context.IssuedBooks.Find(issueId);

            if (issue == null)
                return NotFound("Issue record not found");

            if (issue.Status == "Returned")
                return BadRequest("Book already returned");

            issue.ReturnDate = DateTime.Now;
            issue.Status = "Returned";

            var book = _context.Books.Find(issue.BookId);

            if (book != null)
                book.Quantity++;

            _context.SaveChanges();

            return Ok("Book returned successfully");
        }

        // View all issued books
        [HttpGet]
        public IActionResult GetIssuedBooks()
        {
            var issuedBooks = _context.IssuedBooks.ToList();
            return Ok(issuedBooks);
        }
    }
}
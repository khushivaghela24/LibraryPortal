namespace LibraryPortalAPI.Models
{
    public class IssuedBook
    {
        public int IssueId { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string Status { get; set; }
    }
}
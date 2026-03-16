using LibraryPortalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibraryPortalAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<IssuedBook> IssuedBooks { get; set; }
    }
}
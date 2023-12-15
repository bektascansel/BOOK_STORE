using Book_Store.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Book_Store.DBContext
{
    public class BookStoreDBContext : DbContext
    {

        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }



       

    }
    
}

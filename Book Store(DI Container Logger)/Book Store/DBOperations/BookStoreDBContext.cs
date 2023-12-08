using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Book_Store.DBContext
{
    public class BookStoreDBContext:DbContext
    {

       public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options) {}

       public DbSet<Book> Books { get; set; }


    }
}

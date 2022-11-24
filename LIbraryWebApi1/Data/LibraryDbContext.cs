using Microsoft.EntityFrameworkCore;
namespace LibraryWebApi1.Models
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options):base(options){}
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
    }
}
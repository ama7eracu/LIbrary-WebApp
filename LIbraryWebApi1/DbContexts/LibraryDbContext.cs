using LibraryWebApi1.Models;
using Microsoft.EntityFrameworkCore;

namespace LIbraryWebApi1.DbContexts
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options):base(options){}
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Magazine> Magazines { get; set; } = null!;
    }
}
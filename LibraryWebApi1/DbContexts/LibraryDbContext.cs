using System.Numerics;
using LibraryWebApi1.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi1.DbContexts
{
    public class LibraryDbContext:DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Magazine> Magazines { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Author = "Александр Сергеевич Пушкин",
                    Count = 1950,
                    Genre = "Роман",
                    Name = "Капитанская Дочка",
                    PublicationYear = 1836,
                    Publishing = "Нет"
                },
                new Book
                    {
                        Id = 2,
                        Author = "Александр Сергеевич Пушкин",
                        Count = 250,
                        Genre = "Роман",
                        Name = "Евгений Онегин",
                        PublicationYear = 1833,
                        Publishing = "Нет"
                    },
                new Book{
                Id = 3,
                Author = "Лев Толстой",
                Count = 39,
                Genre = "Любовный Роман",
                Name = "Война и Мир",
                PublicationYear = 1867,
                Publishing = "Нет"
                    }
            );
            modelBuilder.Entity<Magazine>().HasData(
                new Magazine
                {
                    Count = 78,
                    Id = 1,
                    Name = "Аргументы и Правда",
                    Number = 4,
                    Periodicity = 4,
                    PublicationYear = 2010,
                    Publishing = "Добрые Газеты"
                },
                new Magazine
                {
                    Count = 10,
                    Id = 2,
                    Name = "Желтая Пресса",
                    Number = 38,
                    Periodicity = 2,
                    PublicationYear = 2017,
                    Publishing = "Правда и Только Правда"
                },
                new Magazine
                {
                    Count = 256,
                    Id = 3,
                    Name = "Правильное Православие",
                    Number = 192,
                    Periodicity = 4,
                    PublicationYear = 2022,
                    Publishing = "Российская Православная Церковь"
                }
            );
        }
    }
}
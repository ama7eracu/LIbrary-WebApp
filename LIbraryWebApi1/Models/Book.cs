using System.Linq;
namespace LibraryWebApi1.Models
{
    public class Book:BaseClass
    {
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public override void Assigning(BaseClass baseClass)
        {
            base.Assigning(baseClass);
            if (baseClass is Book book)
            {
                this.Author =book.Author;
                this.Genre = book.Genre;
            }
        }
        public static IQueryable<Book> SearchByName(string name, IQueryable<Book> books)
            => books.Where(x => x.Name.ToLower().Contains(name.ToLower()));
    }
}
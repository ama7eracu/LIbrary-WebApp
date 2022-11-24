using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi1.Models
{
    public class Book:BaseClass
    {
        [Required]
        [MinLength(4)]
        public string Author { get; set; } = null!;
        [Required]
        [MinLength(4)]
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
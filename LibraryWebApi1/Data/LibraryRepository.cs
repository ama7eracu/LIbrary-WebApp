using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi1.Data
{
    public class LibraryRepository:ILibraryRepository
    {
        private readonly LibraryDbContext _context;

        public LibraryRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Book>> GetAllBook()
        {
            return await _context.Books.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<ICollection<Magazine>> GetAllMagazine()
        {
            return await _context.Magazines.OrderBy(x=>x.Id).ToListAsync();
        }
        
    }
}
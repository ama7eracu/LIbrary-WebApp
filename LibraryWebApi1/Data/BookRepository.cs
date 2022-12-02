using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi1.Data
{
    public class BookRepository:IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> BookExists(long bookId)
        {
            return await _context.Books.AnyAsync(book => book.Id == bookId);
        }

        public async Task<ICollection<Book>> GetAllBook()
        {
            return await _context.Books.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Book?> GetBook(long id)
        {
            return await _context.Books.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<bool> AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            return await Save();

        }
        
        public async Task<bool> DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            return await Save();
        }

        public async Task<bool> EditBook(long id,Book book)
        {
            var updateBook = _context.Books.FirstOrDefault(x => x.Id == id);
            updateBook?.Assigning(book);
            _context.Books.Update(updateBook!);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var save= await _context.SaveChangesAsync();
            return save > 0;
        }
    }
}
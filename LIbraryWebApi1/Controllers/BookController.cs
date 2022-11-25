using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace LibraryWebApi1.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class BookController : Controller
    {
        private readonly LibraryDbContext _context;
        public BookController(LibraryDbContext ctx)
        {
            _context = ctx;
        }
        // GET:api/Book/
        [HttpGet]
        public async Task<ActionResult<IQueryable<BookDto>>> Get()
        {
            if (!_context.Books.Any())
            {
                return NotFound();
            }
            var books = await _context.Books.Select(x =>
                new BookDto()
                {
                    Id = x.Id,
                    Author = x.Author,
                    Count = x.Count,
                    Genre = x.Genre,
                    Publishing = x.Publishing,
                    Name = x.Name,
                    PublicationYear = x.PublicationYear
                }).ToListAsync();
            return Ok(books);
        }
        
        //GET:api/Book/id
        [HttpGet("{id}")] 
        public async Task<ActionResult<BookDto>> Get(long id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var book = await _context.Books.FindAsync(id);
            if (book==null)
            {
                return NotFound();
            }
            BookDto bookDto = new BookDto()
            {
                Id=book.Id,
                Name = book.Name,
                Author = book.Author,
                Count = book.Count,
                Genre = book.Genre,
                PublicationYear = book.PublicationYear,
                Publishing = book.Publishing
            };
            return Ok(bookDto);
        }
        
        //POST:api/Book
        [HttpPost]
        public async Task<ActionResult<Book>> Post(BookDto bookDto)
        {
            Book book = new Book()
            {
                Id = bookDto.Id,
                Author = bookDto.Author,
                Count = bookDto.Count,
                Genre = bookDto.Genre,
                Name = bookDto.Name,
                Publishing = bookDto.Publishing,
                PublicationYear = bookDto.PublicationYear
            };
           _context.Books.Add(book);
           await _context.SaveChangesAsync();
           return Ok();
       }
        
        //PUT:api/Book/id
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id,Book book)
       {
           if (id != book.Id)
           {
               return BadRequest();
           }
           var changedBook =await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
           if (changedBook == null)
           {
               return NotFound();
           }
           changedBook.Assigning(book);
           await _context.SaveChangesAsync();
           return Ok();
       }
        
        //DELETE:api/Book/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Entry(book).State=EntityState.Deleted;
            await _context.SaveChangesAsync();
            return Ok();

        }
        
        //GET:api/Book/Search/nameBook
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest();
            }
            var foundBooks = Book.SearchByName(name, _context.Books);
            if (!foundBooks.Any())
            {
                return NotFound();
            }
            var booksDto =await foundBooks.Select(x => new BookDto()
            {
                Author = x.Author,
                Count = x.Count,
                Genre = x.Genre,
                Id = x.Id,
                Name = x.Name,
                Publishing = x.Publishing,
                PublicationYear = x.PublicationYear
            }).ToListAsync();
            return Ok(booksDto);
        }
    }
}
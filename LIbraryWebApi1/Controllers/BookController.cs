using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace LibraryWebApi.Controllers
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
        public  ActionResult<IQueryable<BookDTO>> Get()
        {
            if (!_context.Books.Any())
            {
                return NotFound();
            }
            var books = _context.Books.Select(x =>
                new BookDTO()
                {
                    Id = x.Id,
                    Author = x.Author,
                    Count = x.Count,
                    Genre = x.Genre,
                    Publishing = x.Publishing,
                    Name = x.Name,
                    PublicationYear = x.PublicationYear
                });
            return Ok(books);
        }
        //GET:api/Book/id
        [HttpGet("{id}")] 
        public async Task<ActionResult<BookDTO>> Get(long id)
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
            BookDTO bookDto = new BookDTO()
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
        public async Task<ActionResult<Book>> Post(BookDTO bookDto)
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
        public  ActionResult<IEnumerable<Book>> SearchByName(string name)
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
            return Ok(foundBooks);
        }
    }
}
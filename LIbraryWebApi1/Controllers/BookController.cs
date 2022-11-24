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
        public async Task<ActionResult<IQueryable<Book>>> Get()
        {
            if (!_context.Books.Any())
            {
                return NotFound();
            }
            return Ok(await _context.Books.ToListAsync());
        }
        //GET:api/Book/id
        [HttpGet("{id}")] 
        public async Task<ActionResult<Book>> Get(long id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        //POST:api/Book
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
       {
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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LIbraryWebApi1.DbContexts;
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
        private readonly IMapper _mapper;
        public BookController(LibraryDbContext ctx,IMapper mapper)
        {
            _context = ctx;
            _mapper = mapper;
        }
        // GET:api/Book/
        [HttpGet]
        public async Task<ActionResult<IQueryable<BookDto>>> GetAllBooks()
        {
            if (!_context.Books.Any())
            {
                return NotFound();
            }
            var bookDto =await ( _context.Books.Select(book => _mapper.Map<BookDto>(book))).ToListAsync();
            return Ok(bookDto);
        }
        
        //GET:api/Book/id
        [HttpGet("{id}")] 
        public async Task<ActionResult<BookDto>> GetBook(long id)
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
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }
        
        
        //POST:api/Book
        [HttpPost]
        public async Task<ActionResult> AddBook(BookDto bookDto)
        { 
            var book = _mapper.Map<Book>(bookDto); 
            _context.Books.Add(book);
           await _context.SaveChangesAsync();
           return Ok();
       }
        
        //PUT:api/Book/id
        [HttpPut("{id}")]
        public async Task<ActionResult> EditBook(long id,BookDto bookDto)
       {
           if (id<0)
           {
               return BadRequest();
           }
           var changedBook =await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
           if (changedBook == null)
           {
               return NotFound();
           }
           changedBook.Assigning(_mapper.Map<Book>(bookDto));
           await _context.SaveChangesAsync();
           return Ok();
       }
        //DELETE:api/Book/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(long id)
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
        public  ActionResult<IEnumerable<BookDto>> SearchByName(string name)
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
            return Ok(foundBooks.Select(book=>_mapper.Map<BookDto>(book)));
        }
    }
}
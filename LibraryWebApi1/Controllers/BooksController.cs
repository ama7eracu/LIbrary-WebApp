using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Interfaces.Models;
using LibraryWebApi1.Interfaces.Models.DTO;
using LibraryWebApi1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LibraryWebApi1.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;
        private readonly ISearchByName<BookDto,IBookRepository> _search;
        private readonly ISearchByGenre _searchByGenre;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository repository, IMapper mapper, ISearchByName<BookDto,IBookRepository> search,
            ISearchByGenre searchByGenre)
        {
            _repository = repository;
            _mapper = mapper;
            _search = search;
            _searchByGenre = searchByGenre;
        }

        // GET:api/Book/
        [HttpGet]
        public async Task<ActionResult<IQueryable<BookDto>>> GetAllBooks()
        {
            var books = await _repository.GetAllBook();
            if (!books.Any())
            {
                return NotFound();
            }
            var bookDto = books.Select(book => _mapper.Map<BookDto>(book));
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
            if (! await _repository.BookExists(id))
            {
                return NotFound();
            }
            var book = await _repository.GetBook(id);
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        //POST:api/Book
        [HttpPost]
        public async Task<ActionResult> AddBook(BookDto bookDto)
        { 
            var book = _mapper.Map<Book>(bookDto);
            if (!await _repository.AddBook(book))
            {
                return BadRequest();
            }
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
            var book = _mapper.Map<Book>(bookDto);
            if (!await _repository.BookExists(id))
            {
                return NotFound();
            }

            if (!await _repository.EditBook(id,book))
            {
                return BadRequest();
            }
            return NoContent();
        }
        //DELETE:api/Book/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(long id)
        {
            if (!await _repository.BookExists(id))
            {
                return NotFound();
            }
            var book = await _repository.GetBook(id);
            if (!await _repository.DeleteBook(book!))
            {
                return BadRequest();
            }

            return Ok();
        }

         //GET:api/Book/Search/name/nameBook
        [HttpGet("search/name/{searchName}")]
        public async Task< ActionResult<IEnumerable<BookDto>>> SearchBookByName(string searchName)
        {
            if (string.IsNullOrWhiteSpace(searchName))
            {
                return BadRequest();
            }
            var foundBooks =await _search.SearchByName(searchName, _repository);
            if (!foundBooks.Any())
            {
                return NotFound();
            }
            return Ok(foundBooks);
        }
         //GET:api/Book/search/genre/{roman}
        [HttpGet("search/genre/{searchGenre}")]
        public async Task<ActionResult<List<BookDto>>> SearchByGenre(string searchGenre)
        {
            if (string.IsNullOrEmpty(searchGenre))
            {
                return BadRequest();
            }
            var foundBooks = await _searchByGenre.SearchByGenre(searchGenre, _repository);
            if (!foundBooks.Any())
            {
                return NotFound();
            }
            return Ok(foundBooks);
        }
    }
}
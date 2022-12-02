using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Models.DTO;
using LibraryWebApi1.Services.Interfaces;

namespace LibraryWebApi1.Services
{
    public class BookSearch:ISearchByName<BookDto,IBookRepository>,ISearchByGenre
    {
        private readonly IMapper _mapper;
        public BookSearch(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<List<BookDto>> SearchByName(string searchName, IBookRepository repository)
        {
            var books = await (repository.GetAllBook());
            var foundBooks=books.ToList().Where(s => s.Name.ToLower().Contains(searchName.ToLower())).ToList();
            var foundBooksDto = foundBooks.Select(book => _mapper.Map<BookDto>(book));
            return foundBooksDto.ToList();
        }
        public async Task<List<BookDto>> SearchByGenre(string searchGenre,IBookRepository repository)
        {
            var books = await (repository.GetAllBook());
            var booksDto = books.ToList().Select(book => _mapper.Map<BookDto>(book));
            var foundBooks = booksDto.Where(book => book.Genre.ToLower().Equals(searchGenre.ToLower())).ToList();
            return foundBooks;
        }
    }
}
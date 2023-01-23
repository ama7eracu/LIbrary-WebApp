using AutoMapper;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Models.DTO;
using LibraryWebApi1.Services.Interfaces;

namespace LibraryWebApi1.Services
{
    public class BookSearch:ISearchByName<BookDTO,IBookRepository>,ISearchByGenre
    {
        private readonly IMapper _mapper;
        public BookSearch(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<List<BookDTO>> SearchByName(string searchName, IBookRepository repository)
        {
            var books = await (repository.GetAllBook());
            var foundBooks=books.ToList().Where(s => s.Name.ToLower().Contains(searchName.ToLower())).ToList();
            var foundBooksDto = foundBooks.Select(book => _mapper.Map<BookDTO>(book));
            return foundBooksDto.ToList();
        }
        public async Task<List<BookDTO>> SearchByGenre(string searchGenre,IBookRepository repository)
        {
            var books = await (repository.GetAllBook());
            var booksDto = books.ToList().Select(book => _mapper.Map<BookDTO>(book));
            var foundBooks = booksDto.Where(book => book.Genre.ToLower().Equals(searchGenre.ToLower())).ToList();
            return foundBooks;
        }
    }
}
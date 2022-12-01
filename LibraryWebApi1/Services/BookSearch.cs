using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryWebApi1.DbContexts;
using LibraryWebApi1.Models.DTO;
using LibraryWebApi1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi1.Services
{
    public class BookSearch:ISearchByName<BookDto>,ISearchByGenre
    {
        private readonly IMapper _mapper;
        public BookSearch(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<List<BookDto>> SearchByName(string searchName, LibraryDbContext context)
        {
            var foundBooks =await (context.Books
                .Where(s => s.Name.ToLower().Contains(searchName.ToLower()))).ToListAsync();
            var foundBooksDto = foundBooks
                .Select(book => _mapper.Map<BookDto>(book));
            return foundBooksDto.ToList();
        }
        public async Task<List<BookDto>> SearchByGenre(string searchGenre, LibraryDbContext context)
        {
            var books = await (context.Books.Select(book => _mapper.Map<BookDto>(book))).ToListAsync();
            var foundBooks = books.Where(book => book.Genre.ToLower().Equals(searchGenre.ToLower())).ToList();
            return foundBooks;
        }
    }
}
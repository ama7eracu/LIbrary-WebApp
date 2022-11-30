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
    public class SearchByNameBook:ISearchByName<BookDto>
    {
        private readonly IMapper _mapper;
        public SearchByNameBook(IMapper mapper)
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
        
    }
}
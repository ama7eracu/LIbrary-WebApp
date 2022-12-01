using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryWebApi1.DbContexts;
using LibraryWebApi1.Models;
using LibraryWebApi1.Models.DTO;
using LibraryWebApi1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi1.Services
{
    
    public class LibrarySearch:ISearchByName<LibraryDTO>
    {
        private readonly IMapper _mapper;

        public LibrarySearch(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<List<LibraryDTO>> SearchByName(string searchName, LibraryDbContext context)
        {
            var books = await context.Books.Select(book => _mapper.Map<LibraryDTO>(book)).ToListAsync();
            var magazines = await context.Magazines.Select(magazine => _mapper.Map<LibraryDTO>(magazine)).ToListAsync();
            var library = books.Concat(magazines);
            var foundLibrary = library.Where(s => s.Name.ToLower().Contains(searchName.ToLower())).ToList();
            return foundLibrary;
        }
    }
}
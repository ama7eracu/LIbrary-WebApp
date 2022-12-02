using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Models.DTO;
using LibraryWebApi1.Services.Interfaces;

namespace LibraryWebApi1.Services
{
    
    public class LibrarySearch:ISearchByName<LibraryDTO,ILibraryRepository>
    {
        private readonly IMapper _mapper;

        public LibrarySearch(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<List<LibraryDTO>> SearchByName(string searchName, ILibraryRepository repository)
        {
            var books = await repository.GetAllBook();
            var booksDto = books
                .ToList().Select(book => _mapper.Map<LibraryDTO>(book));
            var magazines = await repository.GetAllMagazine();
            var magazinesDto = magazines
                .ToList().Select(magazine => _mapper.Map<LibraryDTO>(magazine));
            var library = booksDto.Concat(magazinesDto);
            var foundLibrary = library
                .Where(s => s.Name.ToLower().Contains(searchName.ToLower())).ToList();
            return foundLibrary;

        }
    }
}
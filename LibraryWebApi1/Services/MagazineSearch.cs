using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AutoMapper;
using LibraryWebApi1.DbContexts;
using LibraryWebApi1.Models.DTO;
using LibraryWebApi1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi1.Services
{
    public class MagazineSearch:ISearchByName<MagazineDto>
    {
        
        private readonly IMapper _mapper;

        public MagazineSearch(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<MagazineDto> SearchByName(string searchName, IEnumerable<MagazineDto> magazines)
        {
            var foundMagazines = magazines
                .Where(s => s.Name.ToLower().Contains(searchName.ToLower()));
            return foundMagazines.ToList();
        }

        public async Task<List<MagazineDto>> SearchByName(string searchName, LibraryDbContext context)
        {
            var foundMagazines =await (context.Magazines
                .Where(s => s.Name.ToLower().Contains(searchName.ToLower()))).ToListAsync();
            var foundMagazinesDto = foundMagazines
                .Select(x => _mapper.Map<MagazineDto>(x)).ToList();
            return foundMagazinesDto;
        }
    }
}
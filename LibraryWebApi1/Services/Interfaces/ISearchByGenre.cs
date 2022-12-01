using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryWebApi1.DbContexts;
using LibraryWebApi1.Models.DTO;

namespace LibraryWebApi1.Services.Interfaces
{
    public interface ISearchByGenre
    {
        public Task<List<BookDto>> SearchByGenre(string searchGenre, LibraryDbContext context);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Interfaces.Models.DTO;

namespace LibraryWebApi1.Services.Interfaces
{
    public interface ISearchByGenre
    {
        public Task<List<BookDto>> SearchByGenre(string searchGenre, IBookRepository context);
    }
}
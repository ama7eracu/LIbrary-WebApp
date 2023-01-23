using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Models.DTO;


namespace LibraryWebApi1.Services.Interfaces
{
    public interface ISearchByGenre
    {
        public Task<List<BookDTO>> SearchByGenre(string searchGenre, IBookRepository context);
    }
}
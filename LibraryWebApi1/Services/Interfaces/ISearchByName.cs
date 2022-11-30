using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApi1.DbContexts;
using LibraryWebApi1.Models;

namespace LibraryWebApi1.Services.Interfaces
{
    public interface ISearchByName<T>
    {
        //List<T> SearchByName(string searchName, IEnumerable<T> collection);
         Task<List<T>>  SearchByName(string searchName, LibraryDbContext context);
    }
}
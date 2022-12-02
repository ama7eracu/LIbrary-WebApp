using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryWebApi1.Services.Interfaces
{
    public interface ISearchByName<T, repository>
    {
        Task<List<T>>  SearchByName(string searchName, repository _repository);
    }
}
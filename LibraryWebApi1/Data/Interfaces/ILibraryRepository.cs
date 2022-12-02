using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryWebApi1.Models;

namespace LibraryWebApi1.Data.Interfaces
{
    public interface ILibraryRepository
    {
       Task<ICollection<Book>> GetAllBook();
       Task<ICollection<Magazine>> GetAllMagazine();
    }
}
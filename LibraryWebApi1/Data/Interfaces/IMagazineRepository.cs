using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryWebApi1.Interfaces.Models;

namespace LibraryWebApi1.Data.Interfaces
{
    public interface IMagazineRepository
    {
        Task<bool> MagazineExists(long magazineId);
        Task<ICollection<Magazine>> GetAllMagazine(); 
        Task<Magazine?> GetMagazine(long id);
        Task<bool> AddMagazine(Magazine magazine);
        Task<bool> DeleteMagazine(Magazine magazine);
        Task<bool> EditMagazine(long id,Magazine magazine);
        Task<bool> Save();
    }
}
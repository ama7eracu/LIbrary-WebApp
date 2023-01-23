
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi1.Data
{
    public class MagazineRepository:IMagazineRepository
    {
        private readonly LibraryDbContext _context;

        public MagazineRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> MagazineExists(long magazineId)
        {
            return await _context.Magazines.AnyAsync(magazine => magazine.Id == magazineId);
        }

        public async Task<ICollection<Magazine>> GetAllMagazine()
        {
            return await _context.Magazines.OrderBy(x=>x.Id).ToListAsync();
        }

        public async Task<Magazine?> GetMagazine(long id)
        {
            return await _context.Magazines.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> AddMagazine(Magazine magazine)
        {
            await _context.Magazines.AddAsync(magazine);
            return await Save();
        }

        public async Task<bool> DeleteMagazine(Magazine magazine)
        {
            _context.Magazines.Remove(magazine);
            return await Save();
        }
        
        public async Task<bool> EditMagazine(long id ,Magazine magazine)
        {
            var updateMagazine = _context.Magazines.FirstOrDefault(x => x.Id == id);
            updateMagazine?.Assigning(magazine);
            _context.Magazines.Update(updateMagazine!);
            return await Save();
        }
        
        public async Task<bool> Save()
        {
           var save= await _context.SaveChangesAsync();
           return save > 0;
        }
    }
}
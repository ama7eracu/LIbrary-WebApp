using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using LibraryWebApi1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazineController : Controller
    {
        private readonly LibraryDbContext _context;
        public MagazineController(LibraryDbContext ctx)
        {
            _context = ctx;
        }
        // GET:api/Magazine/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazineDto>>> Get()
        {
            if (!_context.Magazines.Any())
            {
                return NotFound();
            }
            var magazineDto = await _context.Magazines.Select(x => new MagazineDto()
            {
                Name = x.Name,
                Count = x.Count,
                Id = x.Id,
                Number = x.Number,
                Periodicity = x.Periodicity,
                PublicationYear = x.PublicationYear,
                Publishing = x.Publishing
            }).ToListAsync();
            return Ok(magazineDto);
        }
        
        //GET:api/Magazine/id
        [HttpGet("{id}")]
        public async Task<ActionResult<MagazineDto>> Get(long id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var magazine = await _context.Magazines.FindAsync(id);
            if (magazine == null)
            {
                return NotFound();
            }
            var magazineDto = new MagazineDto()
            {
                Count = magazine.Count,
                Name = magazine.Name,
                Id = magazine.Id,
                Number = magazine.Number,
                Periodicity = magazine.Periodicity,
                PublicationYear = magazine.PublicationYear,
                Publishing = magazine.Publishing
            };
            
            return Ok(magazineDto);
        }
        
        //POST:api/Magazine/
        [HttpPost]
        public async Task<ActionResult> Post(MagazineDto magazineDto)
        {
            if (await _context.Magazines.FindAsync(magazineDto.Id) != null)
            {
                return BadRequest();
            }
            var magazine = new Magazine()
            {
                Count = magazineDto.Count,
                Id = magazineDto.Id,
                Name = magazineDto.Name,
                Number = magazineDto.Number,
                Periodicity = magazineDto.Periodicity,
                PublicationYear = magazineDto.PublicationYear,
                Publishing = magazineDto.Publishing
            };
            await _context.Magazines.AddAsync(magazine);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        //PUT:api/Magazine/id
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, Magazine magazine)
        {
            if (id != magazine.Id)
            {
                return BadRequest();
            }
            var changeMagazine =await _context.Magazines.FirstOrDefaultAsync(x => x.Id == id);
            if (changeMagazine == null)
            {
                return NotFound();
            }
            changeMagazine.Assigning(magazine);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        //DELETE:api/Magazine/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var magazine = await _context.Magazines.FindAsync(id);
            if (magazine == null)
            {
                return NotFound();
            }
            _context.Magazines.Entry(magazine).State=EntityState.Deleted;
            await _context.SaveChangesAsync();
            return Ok();

        }
        
        //GET:api/Magazine/Search/nameMagazine
        [HttpGet("Search/{name}")]
        public  async Task<ActionResult<IQueryable<MagazineDto>>> SearchByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest();
            }
            var foundMagazines = Magazine.SearchByName(name, _context.Magazines);
            if (!foundMagazines.Any())
            {
                return NotFound();
            }
            var magazinesDto = await foundMagazines.Select(x => new MagazineDto()
            {
                Count = x.Count,
                Id = x.Id,
                Name = x.Name,
                Number = x.Number,
                Periodicity = x.Periodicity,
                PublicationYear = x.PublicationYear,
                Publishing = x.Publishing
            }).ToListAsync();
            
            return Ok(magazinesDto);
        }
        
    }
}
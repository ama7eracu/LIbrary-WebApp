using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryWebApi1.DbContexts;
using LibraryWebApi1.Models;
using LibraryWebApi1.Models.DTO;
using LibraryWebApi1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace LibraryWebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazineController : Controller
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISearchByName<MagazineDto> _search;
        public MagazineController(LibraryDbContext context,IMapper mapper, ISearchByName<MagazineDto> search)
        {
            _context = context;
            _mapper = mapper;
            _search = search;
        }
        // GET:api/Magazine/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazineDto>>> GetAllMagazines()
        {
            if (!_context.Magazines.Any())
            {
                return NotFound();
            }
            var magazinesDto =await _context.Magazines.
                Select(magazine => _mapper.Map<MagazineDto>(magazine)).ToListAsync();
            return Ok(magazinesDto);
        }
        
        //GET:api/Magazine/id
        [HttpGet("{id}")]
        public async Task<ActionResult<MagazineDto>> GetMagazine(long id)
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
            return Ok(_mapper.Map<MagazineDto>(magazine));
        }
        
        //POST:api/Magazine/
        [HttpPost]
        public async Task<ActionResult> AddMagazine(MagazineDto magazineDto)
        {
            var magazine = _mapper.Map<Magazine>(magazineDto);
            await _context.Magazines.AddAsync(magazine);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        //PUT:api/Magazine/id
        [HttpPut("{id}")]
        public async Task<ActionResult> EditMagazine(long id, MagazineDto magazineDto)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var changeMagazine =await _context.Magazines.FirstOrDefaultAsync(x => x.Id == id);
            if (changeMagazine == null)
            {
                return NotFound();
            }
            changeMagazine.Assigning(_mapper.Map<Magazine>(magazineDto));
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        //DELETE:api/Magazine/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMagazine(long id)
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
        [HttpGet("Search/{searchName}")]
        public async Task<ActionResult<IQueryable<MagazineDto>>>SearchMagazineByName(string searchName)
        {
            if (string.IsNullOrWhiteSpace(searchName))
            {
                return BadRequest();
            }
            var foundMagazine =await _search.SearchByName(searchName, _context);
            if (!foundMagazine.Any())
            {
                return NotFound();
            }
            return Ok(foundMagazine);
        }
        
    }
}
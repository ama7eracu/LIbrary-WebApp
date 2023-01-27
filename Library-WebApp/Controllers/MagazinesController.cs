using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Models;
using LibraryWebApi1.Models.DTO;
using LibraryWebApi1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibraryWebApi1.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazinesController : Controller
    {
        private readonly IMagazineRepository _repository;
        private readonly IMapper _mapper;
        private readonly ISearchByName<MagazineDTO,IMagazineRepository> _search;
        public MagazinesController(IMagazineRepository repository,IMapper mapper,
            ISearchByName<MagazineDTO,IMagazineRepository> search)
        {
            _repository = repository;
            _mapper = mapper;
            _search = search;
        }
        // GET:api/Magazine/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazineDTO>>> GetAllMagazines()
        {
            var magazines =await _repository.GetAllMagazine();
            if (!magazines.Any())
            {
                return NotFound();
            }

            var magazinesDto = magazines.Select(magazine => _mapper.Map<MagazineDTO>(magazine));
            return Ok(magazinesDto);
        }
        
        //GET:api/Magazine/id
        [HttpGet("{id}")]
        public async Task<ActionResult<MagazineDTO>> GetMagazine(long id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            
            if (! await _repository.MagazineExists(id))
            {
                return NotFound();
            }

            var magazine = await _repository.GetMagazine(id);
            return Ok(_mapper.Map<MagazineDTO>(magazine));
        }
        
        //POST:api/Magazine/
        [HttpPost]
        public async Task<ActionResult> AddMagazine(MagazineDTO magazineDto)
        {
            var magazine = _mapper.Map<Magazine>(magazineDto);
            if (!await _repository.AddMagazine(magazine))
            {
                return BadRequest();
            }
            return Ok();
        }
        
        //PUT:api/Magazine/id
        [HttpPut("{id}")]
        public async Task<ActionResult> EditMagazine(long id, MagazineDTO magazineDto)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            var magazine = _mapper.Map<Magazine>(magazineDto);
            if (!await _repository.MagazineExists(id))
            {
                return NotFound();
            }

            if (!await _repository.EditMagazine(id,magazine))
            {
                return BadRequest();
            }
            return NoContent();
        }
        
        //DELETE:api/Magazine/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMagazine(long id)
        {
            if (!await _repository.MagazineExists(id))
            {
                return NotFound();
            }
            var magazine = await _repository.GetMagazine(id);
            if (!await _repository.DeleteMagazine(magazine!))
            {
                return BadRequest();
            }
            return Ok();
        }
        
         //GET:api/Magazine/Search/name/searchName
        [HttpGet("search/name/{searchName}")]
        public async Task<ActionResult<IQueryable<MagazineDTO>>>SearchMagazineByName(string searchName)
        {
            if (string.IsNullOrWhiteSpace(searchName))
            {
                return BadRequest();
            }
            var foundMagazine =await _search.SearchByName(searchName, _repository);
            if (!foundMagazine.Any())
            {
                return NotFound();
            }
            return Ok(foundMagazine);
        }
        
    }
}
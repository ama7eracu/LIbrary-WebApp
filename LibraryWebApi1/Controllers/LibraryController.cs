using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryWebApi1.Data.Interfaces;
using LibraryWebApi1.Interfaces.Models.DTO;
using LibraryWebApi1.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : Controller
    {
        private readonly ILibraryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ISearchByName<LibraryDTO,ILibraryRepository> _search;

        public LibraryController(ILibraryRepository repository, IMapper mapper,
            ISearchByName<LibraryDTO,ILibraryRepository> search)
        {
            _repository = repository;
            _mapper = mapper;
            _search = search;
        }
        //GET:api/Library/
        [HttpGet("search/name/{searchName}")]
        public async Task<ActionResult<List<LibraryDTO>>> SearchByNameAll(string searchName)
        {
            if (string.IsNullOrWhiteSpace(searchName))
            {
                return BadRequest();
            }
            var foundLibraryDto =await _search.SearchByName(searchName, _repository);
            if (!foundLibraryDto.Any())
            {
                return NotFound();
            }
            return Ok(foundLibraryDto);
        }
    }
}
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
    public class LibraryController : Controller
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISearchByName<LibraryDTO> _search;

        public LibraryController(LibraryDbContext context, IMapper mapper, ISearchByName<LibraryDTO> search)
        {
            _context = context;
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
            var foundLibraryDto =await _search.SearchByName(searchName, _context);
            if (!foundLibraryDto.Any())
            {
                return NotFound();
            }
            return Ok(foundLibraryDto);
        }
    }
}
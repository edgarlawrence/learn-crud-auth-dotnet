using API_practice.DTO;
using API_practice.Interface;
using API_practice.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_practice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GenreList()
        {
            var results = _genreService.ListGenre();
            if (results.Any())
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<IEnumerable<GenreDTO>>(results));
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPost]
        public async Task<IActionResult> PostGenre(GenreDTO genreDTO)
        {
            var results = await _genreService.AddGenre(_mapper.Map<Genre>(genreDTO));
            
            if(results != null)
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<GenreDTO>(results));
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpPut]
        public async Task<IActionResult> PutGenre(GenreDTO genreDTO)
        {
            var results = _genreService.EditGenre(_mapper.Map<Genre>(genreDTO));

            if(results != null)
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<GenreDTO>(results));
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpDelete]
        public IActionResult DeleteGenre(string id)
        {
            var results = _genreService.DeleteGenre(id);
            if (results == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        [HttpGet("Details")]
        public IActionResult Details(string id)
        {
            var results = _genreService.DetailGenre(id);
            if (results != null)
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<GenreDTO>(results));
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}

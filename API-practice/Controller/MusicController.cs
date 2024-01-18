using API_practice.DTO;
using API_practice.Interface;
using API_practice.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_practice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicServices _musicServices;
        private readonly IMapper _mapper;
        public MusicController(IMusicServices musicServices, IMapper mapper)
        {
            _musicServices = musicServices;
            _mapper = mapper;
        }

        // add music
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(MusicDTO musicDTO)
        {
            // map musicDTO to music and send it to the AddMusic function 
            // that comes through the repository

            var result = await _musicServices.AddMusic(_mapper.Map<Music>(musicDTO));
            if(result is not null)
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<MusicDTO>(result));
            }
            return StatusCode(StatusCodes.Status400BadRequest);

        }

        // update music
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(MusicDTO musicDTO)
        {
            // map musicDTO to music and send it to the AddMusic function 
            // that comes through the repository
            var result = await _musicServices.EditMusic(_mapper.Map<Music>(musicDTO)); 
            if(result != null) 
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<MusicDTO>(result));
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // delete music
        [HttpDelete]
        [Authorize]
        public IActionResult Delete(string id)
        {
            var result = _musicServices.DeleteMusic(id);
            if(result == true)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // detail music
        [HttpGet("Details")]
        public IActionResult Details(string id)
        {
            var result = _musicServices.DetailsMusic(id);
            if(result != null)
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<MusicDTO>(result));
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // list of music
        [HttpGet]
        public IActionResult List()
        {
            var result = _musicServices.ListMusic();
            if(result.Any())
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<IEnumerable<MusicDTO>>(result));
            }

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("Genre")]
        public IActionResult GetMusicByGenre(string genreId)
        {
            var result = _musicServices.GetAllMusicBasedOnGenre(genreId);

            if (result.Any())
            {
                return StatusCode(StatusCodes.Status200OK, _mapper.Map<IEnumerable<MusicDTO>>(result));
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}

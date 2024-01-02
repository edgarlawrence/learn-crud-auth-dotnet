using API_practice.DTO;
using API_practice.Model;
using AutoMapper;

namespace API_practice.Mapping
{
    public class MusicMapping : Profile
    {
        public MusicMapping() 
        {
            // CreateMap<Source, Target>
            // This mapping will be used when return the result of a request
            CreateMap<Music, MusicDTO>();

            // This mapping will be used when send a request
            CreateMap<MusicDTO, Music>();
        }
    }
}

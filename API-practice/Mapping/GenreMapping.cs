using API_practice.DTO;
using API_practice.Model;
using AutoMapper;

namespace API_practice.Mapping
{
    public class GenreMapping : Profile
    {
        public GenreMapping() 
        { 
            CreateMap<GenreDTO, Genre>();

            CreateMap<Genre, GenreDTO>();
        }
    }
}

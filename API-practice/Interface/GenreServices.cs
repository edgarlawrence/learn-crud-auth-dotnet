using API_practice.Context;
using API_practice.Model;
using Microsoft.EntityFrameworkCore;

namespace API_practice.Interface
{
    public class GenreServices : IGenreService
    {
        private readonly AppDbContext _appDbContext;
        public GenreServices(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Genre> AddGenre(Genre genre)
        {
            if (genre != null)
            {
                genre.Id = Guid.NewGuid().ToString();
                await _appDbContext.Genre.AddAsync(genre);
                await _appDbContext.SaveChangesAsync();
            }
            return genre;
        }

        public bool DeleteGenre(string id)
        {
            var genres = DetailGenre(id);
            if (genres != null)
            {
                _appDbContext.Genre.Remove(genres);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Genre DetailGenre(string id)
        {
            return _appDbContext.Genre.FirstOrDefault(m => m.Id == id);
        }

        public async Task<Genre> EditGenre(Genre genre)
        {
            var genreDetails = DetailGenre(genre.Id);

            if (genreDetails != null)
            {
                // AutoMapper or Mapster or any kind of function that 
                // could map these properties must be used
                genreDetails.Name = genre.Name;
                await _appDbContext.SaveChangesAsync();
            }
            return genreDetails;
        }

        public IEnumerable<Genre> ListGenre()
        {
            return _appDbContext.Genre.OrderByDescending(m => m.Name).ToList();
        }
    }
}

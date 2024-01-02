using API_practice.Context;
using API_practice.Model;
using Microsoft.AspNetCore.Mvc;

namespace API_practice.Interface
{
    public class MusicServices : IMusicServices
    {
        private readonly AppDbContext _appDbContext;
        public MusicServices(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        /// add new customer
        public async Task<Music> AddMusic(Music music)
        {
            if (music != null)
            {
                music.Id = Guid.NewGuid().ToString();
                await _appDbContext.Music.AddAsync(music);
                await _appDbContext.SaveChangesAsync();
            }
            return music;
        }

        // delete customer based on
        public bool DeleteMusic(string id)
        {
            var music = DetailsMusic(id);
            if(music != null)
            {
                _appDbContext.Music.Remove(music);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Music DetailsMusic(string id)
        {
            return _appDbContext.Music.FirstOrDefault(m => m.Id == id);

        }

        public async Task<Music> EditMusic(Music music)
        {
            var musicDetail = DetailsMusic(music.Id);

            if (musicDetail != null)
            {
                // AutoMapper or Mapster or any kind of function that 
                // could map these properties must be used
                musicDetail.Title = music.Title;
                musicDetail.ReleaseDate = music.ReleaseDate;
                musicDetail.Artist = music.Artist;
                musicDetail.Rate = music.Rate;
                await _appDbContext.SaveChangesAsync();
            }
            return musicDetail;
        }

        public IEnumerable<Music> GetAllMusicBasedOnGenre(string genreId)
        {
            return _appDbContext.Music.Where(m => m.GenreId == genreId).ToList();
        }

        public IEnumerable<Music> ListMusic()
        {
               return _appDbContext.Music.OrderByDescending(m => m.ReleaseDate).ToList();
        }

    }
}

using API_practice.Model;

namespace API_practice.Interface
{
    public interface IMusicServices
    {
        // show all music Music
        IEnumerable<Music> ListMusic();

        // show all music based on genre
        IEnumerable<Music> GetAllMusicBasedOnGenre(string genreId);

        // create music
        Task<Music> AddMusic(Music music);

        // read music
        Music DetailsMusic(string id);

        // update music
        Task<Music> EditMusic(Music music);
        
        //delete
        bool DeleteMusic(string id);
    }
}

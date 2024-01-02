using API_practice.Model;

namespace API_practice.Interface
{
    public interface IGenreService
    {
        // show all genre Genre
        IEnumerable<Genre> ListGenre();

        // create genre
        Task<Genre> AddGenre(Genre genre);

        // read genre
        Genre DetailGenre(string id);

        // update genre
        Task<Genre> EditGenre(Genre genre);

        //delete
        bool DeleteGenre(string id);
    }
}

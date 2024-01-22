using MovieSearch.Model;

namespace MovieSearch.Interface
{
    public interface IMovieService
    {
        Task<Movie> SerachMovie(string moiveTitle);
    }
}

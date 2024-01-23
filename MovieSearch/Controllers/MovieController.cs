using Microsoft.AspNetCore.Mvc;
using MovieSearch.Interface;
using MovieSearch.Model;

namespace MovieSearch.Controllers
{
    [ApiController]
    [Route("movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("search")]
        public async Task<Movie> Search([FromQuery] string title )
        {
            var movieResponse = await _movieService.SerachMovie(title);
            if (movieResponse == null)
            {
                var movie = new Movie();
                return movie;
            }
            return movieResponse;
        }

        [HttpGet("get")]
        public async Task<Movie> GetMovie([FromQuery] string id)
        {
            var movieResponse = await _movieService.GetMovie(id);
            if (movieResponse == null)
            {
                var movie = new Movie();
                return movie;
            }
            return movieResponse;
        }
    }
}
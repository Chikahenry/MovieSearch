using Microsoft.AspNetCore.Mvc;
using MovieSearch.Interface;
using MovieSearch.Model;

namespace MovieSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<Movie> Get([FromQuery] string title = "only")
        {
            var movieResponse = await _movieService.SerachMovie(title);
            if (movieResponse == null)
                return null;
            return movieResponse;
        }
    }
}
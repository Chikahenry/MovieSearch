using Microsoft.Extensions.Options;
using MovieSearch.Common;
using MovieSearch.Config;
using MovieSearch.Interface;
using MovieSearch.Model;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace MovieSearch.Service
{
    public class MovieService : IMovieService
    {
        private readonly OMDBOptions _omdbOptions;
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly IHostEnvironment _hostEvironment;
        public MovieService(ILogger logger, IHostEnvironment hostEvironment, HttpClient httpClient, IOptions<OMDBOptions> omdbOptions)
        {
            _logger = logger;
            _omdbOptions = omdbOptions.Value;
            _httpClient = httpClient;
            _hostEvironment = hostEvironment;
        }


        public async Task<Movie> SerachMovie(string moiveTitle)
        {

            string baseUrl = $"{_omdbOptions.BaseUrl}/?t={moiveTitle}&apikey={_omdbOptions.ApiKey}";
            var response = await _httpClient.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            var movie = responseBody.FromJson<Movie>();
            ArgumentNullException.ThrowIfNull(movie, nameof(movie));

            return movie;

        }
    }
}

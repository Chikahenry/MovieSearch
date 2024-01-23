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
        private readonly HttpClient _httpClient;
        public MovieService( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<Movie> SerachMovie(string moiveTitle)
        {

            string baseUrl = $"{OMDBOptions.BaseUrl}/?t={moiveTitle}&apikey={OMDBOptions.ApiKey}";
            var response = await _httpClient.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            var movie = responseBody.FromJson<Movie>();
            ArgumentNullException.ThrowIfNull(movie, nameof(movie));

            return movie;

        }

        public async Task<Movie> GetMovie(string id)
        {

            string baseUrl = $"{OMDBOptions.BaseUrl}/?i={id}&apikey={OMDBOptions.ApiKey}";
            var response = await _httpClient.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            var movie = responseBody.FromJson<Movie>();
            ArgumentNullException.ThrowIfNull(movie, nameof(movie));

            return movie;

        }
    }
}

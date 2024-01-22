using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieSearch.Config
{
    public class OMDBOptions
    {
        [JsonIgnore]
        public const string SectionName = "OMDB";

        [Required]
        public string BaseUrl { get; set; }

        [Required]
        public string ApiKey { get; set; }
    }
}

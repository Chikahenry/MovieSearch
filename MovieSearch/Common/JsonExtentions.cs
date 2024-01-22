using System.Text.Json;

namespace MovieSearch.Common
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static T? FromJson<T>(this string json)
            => JsonSerializer.Deserialize<T>(json, _jsonOptions);

        public static object? FromJson(this string json, Type type)
            => JsonSerializer.Deserialize(json, type, _jsonOptions);

        public static string ToJson<T>(this T obj) =>
            JsonSerializer.Serialize(obj, _jsonOptions);

        public static T? FromJsonAnonymously<T>(this string json, T anonymousTypeObject)
            => JsonSerializer.Deserialize<T>(json, _jsonOptions);

        public static ValueTask<TValue?> FromJsonAnonymouslyAsync<TValue>(this Stream stream, TValue anonymousTypeObject, CancellationToken cancellationToken = default)
            => JsonSerializer.DeserializeAsync<TValue>(stream, _jsonOptions, cancellationToken);
    }

}

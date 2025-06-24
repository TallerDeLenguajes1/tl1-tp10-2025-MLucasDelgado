using System.Text.Json.Serialization;

namespace anime
{
    public class AnimeCaracteristicas
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("episodes")]
        public int? Episodes { get; set; }

        [JsonPropertyName("rating")]
        public string Rating { get; set; }

        [JsonPropertyName("score")]
        public double? Score { get; set; }

        [JsonPropertyName("year")]
        public int? Year { get; set; }

        [JsonPropertyName("synopsis")]
        public string Synopsis { get; set; }
    }

    public class AnimeResponse
    {
        [JsonPropertyName("data")]
        public List<AnimeCaracteristicas> Data { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace JAppInfos.Models.champion
{
    public class ChampionList
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("blurb")]
        public string Blurb { get; set; }

        [JsonPropertyName("info")]
        public ChampionInfo Info { get; set; }

        [JsonPropertyName("image")]
        public ChampionImage Image { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("partype")]
        public string Partype { get; set; }

        [JsonPropertyName("stats")]
        public ChampionStats Stats { get; set; }
    }
}


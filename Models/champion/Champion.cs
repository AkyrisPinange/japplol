using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace JAppInfos.Models.champion
{
    public class Champion
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("skins")]
        public List<Skin> Skins { get; set; }
        [JsonPropertyName("lore")]
        public string Lore { get; set; }
        [JsonPropertyName("blurb")]
        public string Blurb { get; set; }
        [JsonPropertyName("allytips")]
        public List<string> Allytips { get; set; }
        [JsonPropertyName("enemytips")]
        public List<string> Enemytips { get; set; }
        [JsonPropertyName("Tags")]
        public List<string> Tags { get; set; }
        [JsonPropertyName("partype")]
        public string Partype { get; set; }
        [JsonPropertyName("recommended")]
        public List<object> Recommended { get; set; }
    }
}

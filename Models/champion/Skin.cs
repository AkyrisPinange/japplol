﻿using System.Text.Json.Serialization;

namespace JAppInfos.Models.champion
{
    public class Skin
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("num")]
        public int Num { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("chromas")]
        public bool Chromas { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace JAppInfos.Models.champion
{
    public class ChampionStats
    {
        [JsonPropertyName("hp")]
        public int Hp { get; set; }

        [JsonPropertyName("hpperlevel")]
        public int Hpperlevel { get; set; }
 
        [JsonPropertyName("mp")]
        public int Mp { get; set; }

        [JsonPropertyName("mpperlevel")]
        public double Mpperlevel { get; set; }

        [JsonPropertyName("movespeed")]
        public int Movespeed { get; set; }

        [JsonPropertyName("armor")]
        public int Armor { get; set; }

        [JsonPropertyName("armorperlevel")]
        public double Armorperlevel { get; set; }

        [JsonPropertyName("spellblock")]
        public int Spellblock { get; set; }

        [JsonPropertyName("spellblockperlevel")]
        public double Spellblockperlevel { get; set; }

        [JsonPropertyName("attackrange")]
        public int Attackrange { get; set; }

        [JsonPropertyName("hpregen")]
        public double Hpregen { get; set; }

        [JsonPropertyName("hpregenperlevel")]
        public double Hpregenperlevel { get; set; }

        [JsonPropertyName("mpregen")]
        public double Mpregen { get; set; }

        [JsonPropertyName("mpregenperlevel")]
        public double Mpregenperlevel { get; set; }

        [JsonPropertyName("crit")]
        public double Crit { get; set; }

        [JsonPropertyName("critperlevel")]
        public double Critperlevel { get; set; }

        [JsonPropertyName("attackdamage")]
        public int Attackdamage { get; set; }

        [JsonPropertyName("attackdamageperlevel")]
        public double Attackdamageperlevel { get; set; }

        [JsonPropertyName("attackspeedperlevel")]
        public double Attackspeedperlevel { get; set; }

        [JsonPropertyName("attackspeed")]
        public double Attackspeed { get; set; }
    }
}

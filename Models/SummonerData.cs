namespace JAppInfos.Models
{
    public class SummonerData
    {
        public required string id { get; set; }
        public required string accountId { get; set; }
        public required string puuid { get; set; }
        public required string name { get; set; }
        public required int profileIconId { get; set; }
        public required long revisionDate { get; set; } 
        public required int summonerLevel { get; set; }
    }
}

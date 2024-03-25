using Microsoft.AspNetCore.Identity;

namespace JAppInfos.Models
{
    public class User : IdentityUser<string> 
    {
        public required string Id { get; set; }
        public required string UserName { get; set; }
        public required string PassWord { get; set; }
        public required string SummonerName { get; set; }
        public required int ProfileIconId { get; set; }
        public required string BaseImg { get; set; }
        public required long RevisionDate { get; set; }
        public required int SummonerLevel { get; set; }
        public required string Puuid { get; set; }
        public required string AccountId { get; set; }
        public required long CreatedTimestamp { get; set; }
    }
}

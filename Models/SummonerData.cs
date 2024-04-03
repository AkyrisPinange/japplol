using System.ComponentModel.DataAnnotations;

namespace JAppInfos.Models
{
    public class SummonerData
    {
        [Key]
        public string Id { get; set; } 

        [Required] 
        public string AccountId { get; set; }

        [Required] 
        public string Puuid { get; set; }

        [Required] 
        public string Name { get; set; }

        [Required] 
        public int ProfileIconId { get; set; }

        [Required] 
        public long RevisionDate { get; set; }

        [Required] 
        public int SummonerLevel { get; set; }

        public string UserId { get; set; } 
        public User User { get; set; } 

    }
}

using Microsoft.AspNetCore.Identity;

namespace JAppInfos.Models
{
    public class User : IdentityUser 
    {
        public SummonerData SummonerData { get; set; }

    }
}

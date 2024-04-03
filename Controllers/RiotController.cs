using JAppInfos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JAppInfos.Controllers
{
    public class RiotController : Controller
    {


        private readonly RegisterService _registerService;
        private readonly RiotService _riotService;
        public RiotController(  RiotService riotService, RegisterService registerService)
        {
           
            _riotService = riotService;
            _registerService = registerService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("consultSummoner")]
        public async Task<IActionResult> ConsultSummonerAsync(string summonerName)
        {
            var summonerData = await _registerService.GetSummonerData(summonerName);
            if (summonerData != null)
            {
                return Ok(summonerData);
            }
            else
            {
                return BadRequest("Deu errado");
            }

        }   
        [AllowAnonymous]
        [HttpGet]
        [Route("ChampionsSkins")]
        public async Task<IActionResult> ChamptionAsync()
        {
            var champion = await _riotService.GetChamptionSkins();
            if (champion != null)
            {
                return Ok(champion);
            }
            else
            {
                return BadRequest("Deu errado");
            }

        }

        [HttpGet]
        [Route("test")]
        [Authorize]
        public async Task<IActionResult> test()
        {
            return Ok("teste token ok");

        }
    }
}

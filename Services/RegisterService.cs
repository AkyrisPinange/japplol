using JAppInfos.Models.AppDbContext;
using JAppInfos.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using JAppInfos.Models.handler;
using JAppInfos.utils;




namespace JAppInfos.Services
{

    public class RegisterService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Utils _utils;



        public RegisterService(ApplicationDbContext context, UserManager<User> userManager, IHttpClientFactory httpClientFactory, Utils utils)
        {
            _context = context;
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
            _utils = utils;
        }


        public async Task Register(User user)
        {              
            var passwordHasher =  new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(null, user.PassWord);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

        }

            public async Task<object> GetSummonerData(string summonerName)
            {
                var client = _httpClientFactory.CreateClient("riotClient");
                client.DefaultRequestHeaders.Add("X-Riot-Token", _utils.getConfig("baseUrl:Key"));

                try
                {
                    var response = await client.GetAsync($"summoner/v4/summoners/by-name/{summonerName}");
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<SummonerData>(content);
                    }
                    else
                    {
                        var errorContent = await response.Content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<ErrorResponse>(errorContent);

                }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error retrieving summoner data", ex); 
                }
            }
        
    }
}

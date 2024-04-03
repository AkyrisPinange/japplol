using JAppInfos.Models;
using JAppInfos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JAppInfos.Controllers
{

    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly RegisterService _registerService;
        private readonly UserManager<User> _userManager;

        public LoginController( RegisterService  registerService, UserManager<User> userManager) 
        {
            _registerService = registerService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            _registerService.Register(user);

            return Ok("Usuario Registrado com sucesso");

        }

    }
}

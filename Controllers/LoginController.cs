using JAppInfos.Models;
using JAppInfos.Models.login;
using JAppInfos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JAppInfos.Controllers
{
    
    [ApiController]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService;
        private readonly RegisterService _registerService;
       public LoginController(LoginService loginService, RegisterService  registerService) 
        {
            _registerService = registerService;
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var token = _loginService.LoginUser(userLogin);

            if (token != null)
            {
                return Ok(token);
            }

            return NotFound("User not found");
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        [Authorize]
        public IActionResult Register([FromBody] User user)
        {
                 _registerService.Register(user);

                return Ok("Usuario Registrado com sucesso");

        }

     
    }
}

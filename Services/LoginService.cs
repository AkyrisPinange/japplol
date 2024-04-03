using JAppInfos.handler.exceptions;
using JAppInfos.Models;
using JAppInfos.Models.AppDbContext;
using JAppInfos.Models.login;
using JAppInfos.utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JAppInfos.Services
{



    public class LoginService { 

        private readonly ApplicationDbContext _context;
        private readonly Utils _utils;

        public LoginService(ApplicationDbContext context,Utils utils)
        {
            _utils = utils;
            _context = context;
        }

        public string LoginUser(UserLogin userLogin)
        {
            return Authenticate(userLogin);
        }

        private string Authenticate(UserLogin userLogin)
        {

            User? user = _context.Users.Single(u => u.UserName == userLogin.UserName);

            if (user == null || user.PassWord == null)
            {
                throw new NotFoundException("User not Found", 404);
            }

            if (VerifyPassword(user.PasswordHash, userLogin.PassWord, user)) 
            { 
                return Generate(user);
            } else
            {
                return "User or Password it is incorrect";
            }

           
        }

        private string Generate(User user)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_utils.getConfig("Jwt:key")));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
            };
            JwtSecurityToken token = new JwtSecurityToken(_utils.getConfig("Jwt:Issuer"),
                _utils.getConfig("Jwt:Audience"),
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPassword(string hashedPassword, string plainTextPassword, User user)
        {
            var passwordHasher = new PasswordHasher<User>();
            return passwordHasher.VerifyHashedPassword(user, hashedPassword, plainTextPassword) == PasswordVerificationResult.Success;

        }

    }
}

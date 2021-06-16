using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Yum_PractiseCheck.Context;
using Yum_PractiseCheck.Repository.IRepository;

namespace Yum_PractiseCheck.Repository
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly ApplicationDbContext _context;

        private readonly AppSettings _appSettings;
    
        public AuthenticationManager(IOptions<AppSettings> options ,ApplicationDbContext context)
        {
          
            _context = context;
            _appSettings = options.Value;

        }

      
        public string Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(X => X.UserName == username && X.Password == password);

            if(user == null)
            {
                return null;
            }

            var tokenKey = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,user.Role)
                }),

                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
            
            
        }
    }
}

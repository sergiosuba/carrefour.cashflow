using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace cashflow.infrastructure.security
{
    public class JwtAuthManagerService : IJwtAuthManagerService
    {
        public async Task<string> GetTokenAsync(string email, string role)
        {
            await Task.Yield();

            var symmetric_Key = Encoding.ASCII.GetBytes(Settings.Secret);
            var token_Handler = new JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;
            var securitytokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Email, email),
                            new Claim(ClaimTypes.Role, role)
                        }),
                Expires = now.AddMinutes(Convert.ToInt32(Settings.TokenExpirationTime)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetric_Key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = token_Handler.CreateToken(securitytokenDescriptor);

            return token_Handler.WriteToken(token);
        }
    }
}
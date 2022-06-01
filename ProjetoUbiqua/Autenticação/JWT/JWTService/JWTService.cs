using Microsoft.IdentityModel.Tokens;
using ProjetoUbiqua.Autenticação.JWT.JWTLogic.Interface;
using ProjetoUbiqua.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoUbiqua.Autenticação.JWT.JWTLogic
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtSecurityToken GetToken(Utilizador utilizador)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: GetListaClaims(utilizador),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private List<Claim> GetListaClaims(Utilizador utilizador) => 
            new List<Claim> { 
                new Claim("Role","teste"), 
                new Claim("Username",utilizador.NomeUtilizador), 
                new Claim("Id", utilizador.ID_Utilizador.ToString()) 
            };
        
    }
}

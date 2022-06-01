using Microsoft.IdentityModel.Tokens;
using ProjetoUbiqua.Autenticação.JWT.JWTLogic.Interface;
using ProjetoUbiqua.Entities;
using ProjetoUbiqua.RBAC;
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
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWToken:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWToken:ValidIssuer"],
                audience: _configuration["JWToken:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: GetListaClaims(utilizador),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        private List<Claim> GetListaClaims(Utilizador utilizador) => 
            new List<Claim> { 
                new Claim("Role",utilizador.Is_admin ? Roles.Administrador : Roles.Utilizador), 
                new Claim("Username",utilizador.NomeUtilizador), 
                new Claim("Id", utilizador.ID_Utilizador.ToString()) 
            };
        
    }
}

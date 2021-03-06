using ProjetoUbiqua.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace ProjetoUbiqua.Autenticacao.JWT.JWTLogic.Interface
{
    public interface IJWTService
    {
        JwtSecurityToken GetToken(Utilizador utilizador);
    }
}

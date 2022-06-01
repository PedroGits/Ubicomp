using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjetoUbiqua.Autenticação.JWT.JWTLogic.Interface
{
    public interface IJWTService
    {
        JwtSecurityToken GetToken(List<Claim> authClaims);
    }
}

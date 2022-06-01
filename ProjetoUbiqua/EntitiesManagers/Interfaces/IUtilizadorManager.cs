using ProjetoUbiqua.Entities;
using ProjetoUbiqua.JWT.Model;
using System.IdentityModel.Tokens.Jwt;

namespace ProjetoUbiqua.EntitiesManagers.Interfaces
{
    public interface IUtilizadorManager
    {
        Task<IEnumerable<Utilizador>> GetAll();
        Task<JwtSecurityToken?> Login(LoginModel login);
    }
}

using Microsoft.EntityFrameworkCore;
using ProjetoUbiqua.Autenticação.JWT.JWTLogic.Interface;
using ProjetoUbiqua.Context;
using ProjetoUbiqua.Entities;
using ProjetoUbiqua.EntitiesManagers.Interfaces;
using ProjetoUbiqua.JWT.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjetoUbiqua.EntitiesManagers
{
    public class UtilizadorManager:IUtilizadorManager
    {
        private readonly DbSet<Utilizador> _dbSet;
        private readonly IJWTService _JWTService;

        public UtilizadorManager(DataContext dataContext, IJWTService jWTService)
        {
            _dbSet = dataContext.Utilizador;
            _JWTService = jWTService;
        }

        public async Task<IEnumerable<Utilizador>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<JwtSecurityToken?> Login(LoginModel login)
        {
            var utilizador = await _dbSet.Where(user => user.Email == login.Email && user.Password == login.Password).FirstOrDefaultAsync();
            
            if(utilizador == default)
                            return default;

            return _JWTService.GetToken(new List<Claim> { new Claim("teste","teste")});
        }
    }
}

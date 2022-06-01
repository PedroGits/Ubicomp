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

        public async Task<string?> Login(LoginModel login)
        {
            var utilizador = await _dbSet.Where(user => user.Email == login.Email && user.Password == login.Password && !user.Banido).FirstOrDefaultAsync();
            
            if(utilizador == default)
                            return default;

            return new JwtSecurityTokenHandler().WriteToken(_JWTService.GetToken(utilizador));
        }
    }
}

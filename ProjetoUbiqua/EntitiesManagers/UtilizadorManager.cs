using Microsoft.EntityFrameworkCore;
using ProjetoUbiqua.Context;
using ProjetoUbiqua.Entities;
using ProjetoUbiqua.EntitiesManagers.Interfaces;

namespace ProjetoUbiqua.EntitiesManagers
{
    public class UtilizadorManager:IUtilizadorManager
    {
        private readonly DbSet<Utilizador> _dbSet;

        public UtilizadorManager(DataContext dataContext)
        {
            _dbSet = dataContext.Utilizador;
        }

        public async Task<IEnumerable<Utilizador>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
    }
}

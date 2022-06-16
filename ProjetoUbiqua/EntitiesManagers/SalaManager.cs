using Microsoft.EntityFrameworkCore;
using ProjetoUbiqua.Context;
using ProjetoUbiqua.Entities;
using ProjetoUbiqua.EntitiesManagers.Interfaces;

namespace ProjetoUbiqua.EntitiesManagers
{
    public class SalaManager:ISalaManager
    {
        private readonly DataContext _dataContext;

        public SalaManager(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Sala> Adicionar(Sala sala)
        {
            sala.ID_Sala = 0;
            await _dataContext.AddAsync(sala);
            await _dataContext.SaveChangesAsync();

            return sala;
        }

        public async Task Editar(Sala sala)
        {
            if (sala == default)
                throw new NullReferenceException();

            _dataContext.Update(sala);
            await _dataContext.SaveChangesAsync();
        }
    }
}

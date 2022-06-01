using ProjetoUbiqua.Entities;

namespace ProjetoUbiqua.EntitiesManagers.Interfaces
{
    public interface IUtilizadorManager
    {
        Task<IEnumerable<Utilizador>> GetAll();
    }
}

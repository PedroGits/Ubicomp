using ProjetoUbiqua.Entities;

namespace ProjetoUbiqua.EntitiesManagers.Interfaces
{
    public interface ISalaManager
    {
        Task<Sala> AdicionarSala(Sala sala);
        Task EditarSala(Sala sala);
        Task<Sala> VisualizarSala(int IdSala);
        Task ApagarSala(int IdSala);
        Task AssociarSensorSala(int IdSensor, int IdSala);
        Task DesassociarSensorSala(int IdSensor, int IdSala);
        Task LigarDesligarLuzes(int IdSala, bool Estado);
        Task<IEnumerable<Sala>> GetAll();
        Task DefinirEstadoDasLuzes(int salaId, bool clicked = false);
    }
}

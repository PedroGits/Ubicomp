using ProjetoUbiqua.Entities;

namespace ProjetoUbiqua.EntitiesManagers.Interfaces
{
    public interface ISensorManager
    {
        Task<Sensor> AdicionarSensor(Sensor sensor);
        Task EditarSensor(Sensor sensor);
        Task<Sensor> VisualizarSensor(int IdSensor);
        Task ApagarSensor(int IdSensor);
        Task AlterarEstadoSensor(int IdSensor, bool Estado);
    }
}

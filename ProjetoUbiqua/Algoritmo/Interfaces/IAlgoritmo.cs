using ProjetoUbiqua.Entities;

namespace ProjetoUbiqua.Algoritmo.Interfaces
{
    public interface IAlgoritmo
    {
        bool BotaoClicado(Sala sala);
        bool CalcularEstadoDasLuzesSesnoresMovimento(Sala sala);

    }
}

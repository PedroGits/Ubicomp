using ProjetoUbiqua.Algoritmo.Interfaces;
using ProjetoUbiqua.Constantes;
using ProjetoUbiqua.Entities;

namespace ProjetoUbiqua.Algoritmo
{
    public class Algoritmo:IAlgoritmo
    {
        public bool BotaoClicado(Sala sala)
        {
            if(CalcularEstadoDasLuzesSesnoresMovimento(sala) == false)
            {
                return false;
            }

            return true;
        }
        public bool CalcularEstadoDasLuzesSesnoresMovimento(Sala sala)
        {
            var sensores = sala.Sensores;

            if(sensores.Any(x => x.Tipo == TipoSensor.MOVIMENTO && x.Ligado))
            {
                return true;
            }

            return false;
        }
    }
}

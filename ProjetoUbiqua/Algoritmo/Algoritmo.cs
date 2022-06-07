using ProjetoUbiqua.Algoritmo.Interfaces;
using ProjetoUbiqua.Constantes;
using ProjetoUbiqua.Entities;

namespace ProjetoUbiqua.Algoritmo
{
    public class Algoritmo:IAlgoritmo
    {
        public bool CalcularEstadoDasLuzes(Sala sala)
        {
            var sensores = sala.Sensores;

            //if(sensores.Any(x => x.Tipo == TipoSensor.MOVIMENTO && x.))

            return true;
        }
    }
}

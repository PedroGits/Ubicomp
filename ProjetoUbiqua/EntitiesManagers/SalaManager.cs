using Microsoft.EntityFrameworkCore;
using ProjetoUbiqua.Algoritmo.Interfaces;
using ProjetoUbiqua.Context;
using ProjetoUbiqua.Entities;
using ProjetoUbiqua.EntitiesManagers.Interfaces;

namespace ProjetoUbiqua.EntitiesManagers
{
    public class SalaManager:ISalaManager
    {
        private readonly DataContext _dataContext;
        private readonly IAlgoritmo _algoritmo;
        private readonly IClienteMqtt _clienteMqtt;

        public SalaManager(DataContext dataContext,
            IAlgoritmo algoritmo, IClienteMqtt clienteMqtt)
        {
            _dataContext = dataContext;
            _algoritmo = algoritmo;
            _clienteMqtt = clienteMqtt;
        }



        public async Task<Sala> AdicionarSala(Sala sala)
        {
            sala.ID_Sala = 0;
            await _dataContext.AddAsync(sala);
            await _dataContext.SaveChangesAsync();

            return sala;
        }

        public async Task<IEnumerable<Sala>> GetAll()
        {
           return await _dataContext.Sala.ToListAsync();
        }

    public async Task EditarSala(Sala sala)
        {
            if (sala == default)
                throw new NullReferenceException();

            _dataContext.Update(sala);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Sala> VisualizarSala(int IdSala)
        {
            var sala = await _dataContext.Sala.Where(sala => sala.ID_Sala == IdSala).Include(x => x.Sensores).FirstOrDefaultAsync();

            if (sala == default)
                throw new NullReferenceException();

            return sala;
        }

        public async Task ApagarSala(int IdSala)
        {
            var sala = await _dataContext.Sala.Where(sala => sala.ID_Sala == IdSala).FirstOrDefaultAsync();

            if (sala == default)
                throw new NullReferenceException();

            _dataContext.Sala.Remove(sala);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AssociarSensorSala(int IdSala, int IdSensor)
        {
            var sala = await _dataContext.Sala.Where(sala => sala.ID_Sala == IdSala).Include(x => x.Sensores).FirstOrDefaultAsync();
            var sensor = await _dataContext.Sensor.Where(sensor => sensor.ID_Sensor == IdSensor).FirstOrDefaultAsync();

            if (sala == default || sensor == default)
                throw new NullReferenceException();

            if (sala.Sensores != default && sala.Sensores.Any(sensor => sensor.ID_Sensor == IdSensor))
                return;

            sala.Sensores.Add(sensor);

            _dataContext.Update(sala);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DesassociarSensorSala(int IdSala, int IdSensor)
        {
            var sala = await _dataContext.Sala.Where(sala => sala.ID_Sala == IdSala).Include(x => x.Sensores).FirstOrDefaultAsync();

            if (sala == default)
                throw new NullReferenceException();

            sala.Sensores = sala.Sensores.Where(sensor => sensor.ID_Sensor != IdSensor).ToList();

            _dataContext.Update(sala);
            await _dataContext.SaveChangesAsync();
        }

        public async Task LigarDesligarLuzes(int IdSala,bool Estado)
        {
            var sala = await _dataContext.Sala.Where(sala => sala.ID_Sala == IdSala).Include(x => x.Sensores).FirstOrDefaultAsync();

            if (sala == default)
                throw new NullReferenceException();

            sala.EstadoLuzes = Estado;

            _dataContext.Update(sala);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Sensor>> GetListSensores(int IdSala)
        {
            var sala = await _dataContext.Sala.Where(sala => sala.ID_Sala == IdSala).Include(x => x.Sensores).FirstOrDefaultAsync();

            if (sala == default)
                throw new NullReferenceException();

            var sensores = sala.Sensores;

            return sensores;
        }

        public async Task DefinirEstadoDasLuzes(int salaId, bool clicked=false)
        {
            var sala = await _dataContext.Sala.Where(sala => sala.ID_Sala == salaId).Include(x => x.Sensores).FirstAsync();

            if (sala == default)
                return;

            var estadoLuzes = clicked ? _algoritmo.BotaoClicado(sala) : _algoritmo.CalcularEstadoDasLuzesSesnoresMovimento(sala);

           

            if (estadoLuzes != sala.EstadoLuzes)
            {
                sala.EstadoLuzes = estadoLuzes;
                _dataContext.Sala.Update(sala);
                await _dataContext.SaveChangesAsync();
                _clienteMqtt.MandarMensagemAsync(estadoLuzes.ToString(), sala.ID_Sala.ToString());
            }
                
        }
    }
}

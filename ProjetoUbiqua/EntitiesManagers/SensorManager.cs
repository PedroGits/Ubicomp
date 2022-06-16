using ProjetoUbiqua.Entities;
using ProjetoUbiqua.EntitiesManagers.Interfaces;

namespace ProjetoUbiqua.EntitiesManagers
{
    public class SensorManager:ISensorManager
    {
        private readonly DataContext _dataContext;

        public SensorManager(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Sensor> AdicionarSensor(Sensor sensor)
        {
            sensor.ID_Sensor = 0;
            await _dataContext.AddAsync(sensor);
            await _dataContext.SaveChangesAsync();

            return sensor;
        }

        public async Task EditarSensor(Sensor sensor)
        {
            if (sensor == default)
                throw new NullReferenceException();

            _dataContext.Update(sensor);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Sensor> VisualizarSensor(int IdSensor)
        {
            var sensor = await _dataContext.Sensor.Where(sensor => sensor.ID_Sensor == IdSensor).FirstOrDefaultAsync();

            if (sensor == default)
                throw new NullReferenceException();

            return sensor;
        }

        public async Task ApagarSensor(int IdSensor)
        {
            var sensor = await _dataContext.Sensor.Where(sensor => sensor.ID_Sensor == IdSensor).FirstOrDefaultAsync();
            if (sensor == default)
                throw new NullReferenceException();
            _dataContext.Sensor.Remove(sensor);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AlterarEstadoSensor(int IdSensor,bool Estado)
        {
            var sensor = await _dataContext.Sensor.Where(sensor => sensor.ID_Sensor == IdSensor).FirstOrDefaultAsync();

            if (sensor == default)
                throw new NullReferenceException();

            sensor.Ligado = Estado;

            _dataContext.Update(sensor);
            await _dataContext.SaveChangesAsync();
        }
    }
}

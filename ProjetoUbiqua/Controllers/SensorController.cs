using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUbiqua.EntitiesManagers.Interfaces;

namespace ProjetoUbiqua.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ISensorManager _sensorManager;

        public SensorController(ISensorManager sensorManager)
        {
            _sensorManager = sensorManager;
        }
    }
}

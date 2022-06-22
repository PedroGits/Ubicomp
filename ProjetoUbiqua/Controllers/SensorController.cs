using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUbiqua.Entities;
using ProjetoUbiqua.EntitiesManagers.Interfaces;
using ProjetoUbiqua.RBAC;

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

        [HttpPost("AdicionarSensor"), Authorize(Roles = Roles.Administrador)]
        public async Task<ActionResult<Sensor>> AdicionarSensor(Sensor sensor)
        {
            try
            {
                var novaSala = await _sensorManager.AdicionarSensor(sensor);
                return Ok(novaSala);
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPut("EditarSensor"), Authorize(Roles = Roles.Administrador)]
        public async Task<ActionResult> EditarSensor(Sensor sensor)
        {
            try
            {
                await _sensorManager.EditarSensor(sensor);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpGet("VisualizarSensor")]
        public async Task<ActionResult<Sensor>> VisualizarSensor(int IdSensor)
        {
            try
            {
                Sensor sensor = await _sensorManager.VisualizarSensor(IdSensor);
                return Ok(sensor);
            }
            catch
            {
                return Problem();
            }

        }

        [HttpDelete, Authorize(Roles = Roles.Administrador)]
        public async Task<ActionResult> ApagarSensor(int IdSensor)
        {
            try
            {
                await _sensorManager.ApagarSensor(IdSensor);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPatch("AlterarEstadoSensorMovimento/{IdSensor}")]
        public async Task<ActionResult> AlterarEstadoSensor(int IdSensor, [FromBody] bool Estado)
        {
            try
            {
                await _sensorManager.AlterarEstadoSensor(IdSensor, Estado);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpGet("Cliked/{IdSensor}")]
        public async Task<ActionResult> Clicked (int IdSensor)
        {
            try
            {
                await _sensorManager.BotaoClicked(IdSensor);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }
    }
}

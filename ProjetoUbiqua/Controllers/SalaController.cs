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
    public class SalaController : ControllerBase
    {
        private readonly ISalaManager _salaManager;

        public SalaController(ISalaManager salaManager)
        {
            _salaManager = salaManager;
        }

       
        [HttpPost("AdicionarSala"), Authorize(Roles = Roles.Administrador)]
        public async Task<ActionResult<Sala>> AdicionarSala(Sala sala)
        {
            try
            {
                var novaSala = await _salaManager.AdicionarSala(sala);
                return Ok(novaSala);
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPut("EditarSala"), Authorize(Roles = Roles.Administrador)]
        public async Task<ActionResult> EditarSala(Sala sala)
        {
            try
            {
                await _salaManager.EditarSala(sala);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpGet("VisualizarSala"), ]
        public async Task<ActionResult<Sala>> VisualizarSala(int IdSala)
        {
            try
            {
                Sala sala = await _salaManager.VisualizarSala(IdSala);
                return Ok(sala);
            }
            catch
            {
                return Problem();
            }

        }

        [HttpGet, Authorize(Roles = Roles.Administrador)]
        public async Task<ActionResult<Sala>> VisualizarSalas(int IdSala)
        {
            try
            {
                Sala sala = await _salaManager.VisualizarSala(IdSala);
                return Ok(sala);
            }
            catch
            {
                return Problem();
            }

        }

        [HttpDelete, Authorize(Roles = Roles.Administrador)]
        public async Task<ActionResult> ApagarSala(int IdSala)
        {
            try
            {
                await _salaManager.ApagarSala(IdSala);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPatch("AssociarSensorSala/{IdSala}"), Authorize(Roles = Roles.Administrador)]
        public async Task<ActionResult> AssociarSensorSala(int IdSala, [FromBody] int IdSensor)
        {
            try
            {
                await _salaManager.AssociarSensorSala(IdSala,IdSensor);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPatch("DesassociarSensorSala/{IdSala}"), Authorize(Roles = Roles.Administrador)]
        public async Task<ActionResult> DesassociarSensorSala(int IdSala, [FromBody] int IdSensor)
        {
            try
            {
                await _salaManager.DesassociarSensorSala(IdSala, IdSensor);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPatch("ControlarLuzes/{IdSala}")]
        public async Task<ActionResult> LigarDesligarLuzes(int IdSala, [FromBody] bool Estado)
        {
            try
            {
                await _salaManager.LigarDesligarLuzes(IdSala,Estado);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }


    }
}

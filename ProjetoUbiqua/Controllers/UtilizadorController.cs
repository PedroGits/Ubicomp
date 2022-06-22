using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoUbiqua.DTO;
using ProjetoUbiqua.Entities;
using ProjetoUbiqua.RBAC;

namespace ProjetoUbiqua.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadorController : ControllerBase
    {
        private readonly IUtilizadorManager _utilizadorManager;

        public UtilizadorController(IUtilizadorManager utilizadorManager)
        {
            _utilizadorManager = utilizadorManager;
        }
       
        
        [HttpGet, Authorize(Roles = Roles.Administrador)]
        public async Task<ActionResult<IEnumerable<Utilizador>>> GetAll()
        {
            return Ok(await _utilizadorManager.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<Utilizador>> Adicionar(RegistoDTO utilizador)
        {
            try
            {
                var novoUtilizador = await _utilizadorManager.Adicionar(utilizador);
                if (novoUtilizador == null)
                    return Problem("Nome ou Email já existem!");

                return Ok(novoUtilizador);
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPost("Login")]
        public async Task<ActionResult<RespostaTokenDTO>> Login(LoginDTO login)
        {
            var response = await _utilizadorManager.Login(login);

            if (response != default)
                return Ok(response);

            return Unauthorized();
        }

        [HttpPut]
        public async Task<ActionResult> Editar(Utilizador utilizador)
        {
            try
            {
                await _utilizadorManager.Editar(utilizador);
                return Ok();
            }
            catch
            {
                return Problem();
            }
            
        }

        [HttpPatch("Banir/{IdUtilizador}")]
        public async Task<ActionResult> AlterarEstado(int IdUtilizador, bool estado)
        {
            try
            {
                await _utilizadorManager.Banir(IdUtilizador, estado);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPatch("AssociarSala/{IdUtilizador}")]
        public async Task<ActionResult> AssociarSala(int IdUtilizador, [FromBody] int IdSala)
        {
            try
            {
                await _utilizadorManager.AssociarSala(IdUtilizador, IdSala);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPatch("DesassociarSala/{IdUtilizador}")]
        public async Task<ActionResult> DesassociarSala(int IdUtilizador, [FromBody] int IdSala)
        {
            try
            {
                await _utilizadorManager.DesassociarSala(IdUtilizador, IdSala);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

        [HttpPatch("Apagar/{IdUtilizador}")]
        public async Task<ActionResult> Apagar(int IdUtilizador)
        {
            try
            {
                await _utilizadorManager.Apagar(IdUtilizador);
                return Ok();
            }
            catch
            {
                return Problem();
            }

        }

    }
}

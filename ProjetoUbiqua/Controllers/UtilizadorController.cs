using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUbiqua.Entities;
using ProjetoUbiqua.EntitiesManagers.Interfaces;
using ProjetoUbiqua.JWT.Model;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utilizador>>> GetAll()
        {
            return Ok(await _utilizadorManager.GetAll());
        }

        [HttpPost("Login")]
        public async Task<ActionResult<IEnumerable<Utilizador>>> Login(LoginModel login)
        {
            return Ok(await _utilizadorManager.GetAll());
        }
    }
}

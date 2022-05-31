using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUbiqua.EntitiesManagers.Interfaces;

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
    }
}

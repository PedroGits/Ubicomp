using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoUbiqua.EntitiesManagers.Interfaces;

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

    }
}

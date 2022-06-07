using ProjetoUbiqua.Entities;
using ProjetoUbiqua.JWT.Model;
using System.IdentityModel.Tokens.Jwt;

namespace ProjetoUbiqua.EntitiesManagers.Interfaces
{
    public interface IUtilizadorManager
    {
        Task<IEnumerable<Utilizador>> GetAll();
        Task<RespostaTokenDTO?> Login(LoginDTO login);
        Task Editar(Utilizador utilizador);
        Task<Utilizador> Adicionar(Utilizador utilizador);
        Task Apagar(int IdUtilizador);
        Task Banir(int IdUtilizador);
        Task AssociarSala(int IdUtilizador, int SalaId);
        Task DesassociarSala(int IdUtilizador, int SalaId);
    }
}

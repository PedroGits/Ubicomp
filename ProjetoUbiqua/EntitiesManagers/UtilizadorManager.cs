using Microsoft.EntityFrameworkCore;
using ProjetoUbiqua.Autenticacao.JWT.JWTLogic.Interface;
using ProjetoUbiqua.Context;
using ProjetoUbiqua.Entities;
using ProjetoUbiqua.EntitiesManagers.Interfaces;
using ProjetoUbiqua.JWT.Model;
using ProjetoUbiqua.Mqtt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProjetoUbiqua.EntitiesManagers
{
    public class UtilizadorManager:IUtilizadorManager
    {
        private readonly DataContext _dataContext;
        private readonly IJWTService _JWTService;
        private readonly IClienteMqtt _mqttService;

        public UtilizadorManager(DataContext dataContext, IJWTService jWTService, IClienteMqtt mqttService)
        {
            _dataContext = dataContext;
            _JWTService = jWTService;
            _mqttService = mqttService;
        }

        public async Task DesassociarSala(int IdUtilizador, int SalaId)
        {
            var utilizador = await _dataContext.Utilizador.Where(user => user.ID_Utilizador == IdUtilizador).Include(x => x.Salas).FirstOrDefaultAsync();
            
            if (utilizador == default)
                throw new NullReferenceException();

            utilizador.Salas = utilizador.Salas.Where(sala => sala.ID_Sala != SalaId).ToList();

            _dataContext.Update(utilizador);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AssociarSala(int IdUtilizador, int SalaId)
        {
            var utilizador = await _dataContext.Utilizador.Where(user => user.ID_Utilizador == IdUtilizador).Include(x => x.Salas).FirstOrDefaultAsync();
            var sala = await _dataContext.Sala.Where(sala => sala.ID_Sala == SalaId).FirstOrDefaultAsync();

            if (utilizador == default || sala == default)
                throw new NullReferenceException();

            if (utilizador.Salas != default && utilizador.Salas.Any(sala => sala.ID_Sala == SalaId))
                return;

            utilizador.Salas.Add(sala);

            _dataContext.Update(utilizador);
            await _dataContext.SaveChangesAsync();
        }


        public async Task Banir(int IdUtilizador)
        {
            var utilizador = await _dataContext.Utilizador.Where(user => user.ID_Utilizador == IdUtilizador).FirstOrDefaultAsync();

            if (utilizador == default)
                throw new NullReferenceException();

            utilizador.Banido = true;

            _dataContext.Update(utilizador);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Apagar(int IdUtilizador)
        {
            var utilizador = await _dataContext.Utilizador.Where(user => user.ID_Utilizador == IdUtilizador).FirstOrDefaultAsync();

            if (utilizador == default)
                throw new NullReferenceException();

            _dataContext.Utilizador.Remove(utilizador);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Editar(Utilizador utilizador)
        {
            if (utilizador == default)
                throw new NullReferenceException();

            _dataContext.Update(utilizador);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Utilizador>> GetAll()
        {
            _mqttService.MandarMensagemAsync("teste", "teste");

            return await _dataContext.Utilizador.ToListAsync();
        }

        public async Task<RespostaTokenDTO?> Login(LoginDTO login)
        {
            var utilizador = await _dataContext.Utilizador.Where(user => user.Email == login.Email && user.Password == login.Password && !user.Banido).FirstOrDefaultAsync();
            
            if(utilizador == default)
                            return default;

            var token = _JWTService.GetToken(utilizador);

            return new RespostaTokenDTO { 
                Token = new JwtSecurityTokenHandler().WriteToken(token), 
                ValidoUntil = token.ValidTo 
            };
        }

        public async Task<Utilizador> Adicionar(Utilizador utilizador)
        {
            utilizador.ID_Utilizador = 0;
            
            await _dataContext.AddAsync(utilizador);
            await _dataContext.SaveChangesAsync();

            return utilizador;
        }
    }
}

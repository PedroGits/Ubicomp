using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using ProjectoUbiquaNUnitTest.ServiceMock;
using ProjetoUbiqua.Context;
using ProjetoUbiqua.Entities;
using ProjetoUbiqua.EntitiesManagers;
using ProjetoUbiqua.JWT.Model;
using ProjetoUbiqua.Mqtt;
using ProjetoUbiqua.Mqtt.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectoUbiquaNUnitTest
{
    public class UtilizadorManagerTestClass
    {
        private static DbContextOptions<DataContext> dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "testeDb")
            .Options;

        DataContext _dataContext;

        [OneTimeSetUp]
        public void Setup()
        {
            _dataContext = new DataContext(dbContextOptions);
            _dataContext.Database.EnsureCreated();
            SeedDatabase();



        }

        [OneTimeTearDown]
        public void CleanContext()
        {
            _dataContext.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
            _dataContext.Utilizador.AddRange(new List<Utilizador> {
            new Utilizador
            {
                NomeUtilizador = "teste",
                Password = "teste",
                Email = "teste@teste.com",
                Banido = false,
                ID_Utilizador = 0,
                Is_admin = true,
                Salas = new List<Sala>{new Sala{Area = 10, EstadoLuzes = true, Lotacao = 2, NomeSala = "teste"}}
            },
            new Utilizador
            {
                NomeUtilizador = "teste",
                Password = "teste",
                Email = "testeUserBanido@teste.com",
                Banido = true,
                ID_Utilizador = 0,
                Is_admin = true,
                Salas = default
            }
            });

            _dataContext.Sala.Add(new Sala { Area = 10, EstadoLuzes = true, Lotacao = 2, NomeSala = "teste" });

            _dataContext.SaveChanges();
        }


        [Test]
        public async Task Login_Should_Return_Not_Null()
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

            var credenciais = new LoginDTO { Email = "teste@teste.com", Password = "teste" };

            var result = await utilizadorManagerTest.Login(credenciais);

            Assert.That(result, Is.Not.Null);
            
        }

        [Test]
        public async Task Login_Should_Return_Null()
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

          
            await _dataContext.SaveChangesAsync();

            var credenciais = new LoginDTO { Email = "testeUserBanido@teste.com", Password = "test" };

            var result = await utilizadorManagerTest.Login(credenciais);

            Assert.That(result, Is.Null);

        }

        [TestCase(1,1)]
        [TestCase(1, 2)]
        public async Task AssociarSala_Should_Not_Throw_Exception(int idUtilizador, int idSala)
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);


            Assert.DoesNotThrowAsync(() =>  utilizadorManagerTest.AssociarSala(idUtilizador, idSala));

        }

        [TestCase(10, 10)]
        [TestCase(10, 1)]
        [TestCase(1, 10)]
        public async Task AssociarSala_Should_Throw_Exception(int idUtilizador, int idSala)
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);


            Assert.ThrowsAsync<NullReferenceException>(() => utilizadorManagerTest.AssociarSala(idUtilizador, idSala));

        }

        [TestCase(10, 10)]
        public async Task DesassociarSala_Should_Throw_Exception(int idUtilizador, int idSala)
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

            Assert.ThrowsAsync<NullReferenceException>(() => utilizadorManagerTest.DesassociarSala(idUtilizador, idSala));

        }

        [TestCase(1, 1)]
        public async Task DesassociarSala_Should_Not_Throw_Exception(int idUtilizador, int idSala)
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

            Assert.DoesNotThrowAsync(() => utilizadorManagerTest.DesassociarSala(idUtilizador, idSala));

        }

        [TestCase(2)]
        public async Task Banir_Should_Not_Throw_Exception(int idUtilizador)
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

            Assert.DoesNotThrowAsync(() => utilizadorManagerTest.Banir(idUtilizador));

        }

        [TestCase(10)]
        public async Task Banir_Should_Throw_Exception(int idUtilizador)
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

            Assert.ThrowsAsync<NullReferenceException>(() => utilizadorManagerTest.Banir(idUtilizador));

        }

        [Test]
        public async Task Adicionar_Should_Not_Throw()
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

            var novoUtilizador = new Utilizador
            {
                NomeUtilizador = "testeAdd",
                Password = "testeAdd",
                Email = "testeAdd@teste.com",
                Banido = true,
                ID_Utilizador = 0,
                Is_admin = true,
                Salas = default
            };

            Assert.DoesNotThrowAsync(() => utilizadorManagerTest.Adicionar(novoUtilizador));
        }

        [Test]
        public async Task Editar_Should_Not_Throw()
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

            var utilizador = await _dataContext.Utilizador.AsNoTracking().LastAsync();
            utilizador.Banido = false;
            _dataContext.ChangeTracker.Clear();

            Assert.DoesNotThrowAsync(() => utilizadorManagerTest.Editar(utilizador));
        }

        [Test]
        public async Task Editar_Should_Throw()
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

            Assert.ThrowsAsync<NullReferenceException>(() => utilizadorManagerTest.Editar(default));
        }

        [Test]
        public async Task Get_All_Should_Be_Equal()
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

            var result = await utilizadorManagerTest.GetAll();
            var utilizadores = await _dataContext.Utilizador.ToListAsync();

            Assert.AreEqual(result, utilizadores);
        }

        [Test]
        public async Task Apagar_Should_Not_Throw()
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

            var idUtilizador = await _dataContext.Utilizador.MaxAsync(x => x.ID_Utilizador);

            Assert.DoesNotThrowAsync(() => utilizadorManagerTest.Apagar(idUtilizador));
        }

        [Test]
        public async Task Apagar_Should_Throw()
        {
            var jwtServiceMock = new JWTServiceMock();
            var clienteMqtt = new MqttServiceMock();

            UtilizadorManager utilizadorManagerTest = new UtilizadorManager(_dataContext, jwtServiceMock, clienteMqtt);

            var idUtilizador = await _dataContext.Utilizador.MaxAsync(x => x.ID_Utilizador);

            //Assert.ThrowsAsync<NullReferenceException>(() => utilizadorManagerTest.Apagar(idUtilizador + 1));
            Assert.Fail();
        }
    }
}

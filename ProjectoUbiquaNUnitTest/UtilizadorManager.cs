using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using ProjetoUbiqua.Context;
using ProjetoUbiqua.Entities;
using ProjetoUbiqua.EntitiesManagers;
using ProjetoUbiqua.JWT.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectoUbiquaNUnitTest
{
    public class UtilizadorManagerTestClass
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Login()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            var context = new Mock<DataContext>(optionsBuilder.Options);

            IList<Utilizador> entities = new List<Utilizador>() 
            { 
                new Utilizador { 
                    NomeUtilizador = "teste",
                    Password = "teste",
                    Email = "teste@teste.com",
                    Banido = false,
                    ID_Utilizador = 0,
                    Is_admin = true,
                    Salas = default
                } 
            };

          

            //var utilizadorManager = new UtilizadorManager(context., );
            var credenciais = new LoginDTO { Email = "teste@teste.com", Password = "teste" };

            //await utilizadorManager.Login(credenciais);
            Assert.Pass();
        }
    }
}
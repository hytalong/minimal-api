using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
             var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
             var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "","..","..",".."));

            //Configurar o ConfigurarionBuilder
            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);

        }

        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            //arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE administradores");

            var adm = new Administrador();
            adm.Id = 1;
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil  = "Adm";
            var administradorServico = new AdministradorServico(context);

            //Act
            administradorServico.Incluir(adm);

            //Assert
            Assert.AreEqual(1, administradorServico.Todos(1).Count());
        }
        
        [TestMethod]
        public void TestandoBuscaPorId()
        {
            //arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE administradores");

            var adm = new Administrador();
            adm.Id = 1;
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil  = "Adm";
            var administradorServico = new AdministradorServico(context);

            //Act
            administradorServico.Incluir(adm);
            var admDobanco = administradorServico.BuscaPorId(adm.Id);

            //Assert
            Assert.AreEqual(1, admDobanco?.Id);
        }
    }
}
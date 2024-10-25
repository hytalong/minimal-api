using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using minimal_api;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using minimal_api.Infraestrutura.Db;
using Test.Helpers.Mocks;

namespace Test.Helpers
{
    public class Setup
    {
        public const string PORT = "5000";
        public static TestContext testContext = default!;
        public static WebApplicationFactory<Startup> http = default!;
        public static HttpClient client = default!;

        public static void ClassInit(TestContext testContext)
        {
            Setup.testContext = testContext;
            Setup.http = new WebApplicationFactory<Startup>();

            Setup.http = Setup.http.WithWebHostBuilder(builder =>
            {
                builder.UseSetting("https_port", Setup.PORT).UseEnvironment("Testing");

                builder.ConfigureServices(services => 
                {
                    services.AddScoped<IAdministradorServico, AdministradorServicoMock>();

                    
                    /*var conexao = "Server=localhost;Database=desafio21dias_dotnet7_test;User=root;Password=lalaland";
                    services.AddDbContext<DbContexto>(options =>
                    {
                        options.UseMySql(conexao, SeverVersion.AutoDetect(conexao));
                    });
                    */
                    
                });

            });

            Setup.client = Setup.http.CreateClient();
        }
        public static void ClassCleanup()
        {
            Setup.http.Dispose();
        }

    }
}
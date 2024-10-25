using System;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using minimal_api.dominio.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Helpers;

namespace Test.Requests
{
    [TestClass]
    public class VeiculoRequestTest
    {
        private static string token = "minimal-api-alunos-vamlos_lá"; // Substitua com o token válido

        [ClassInitialize]
        public static void ClassInit(TestContext testContext)
        {
            Setup.ClassInit(testContext);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Setup.ClassCleanup();
        }

        [TestMethod]
        public async Task TestarPostVeiculo()
        {
            // Arrange
            var veiculo = new VeiculoDto
            {
                Nome = "Aquele La",
                Marca = "Alguma",
                Ano = 1995
            };

            var content = new StringContent(JsonSerializer.Serialize(veiculo), Encoding.UTF8, "application/json");
            
            // Configura o cabeçalho de autorização
            Setup.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Act
            var response = await Setup.client.PostAsync("/veiculos", content);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

            var result = await response.Content.ReadAsStringAsync();
            var veiculoCriado = JsonSerializer.Deserialize<VeiculoDto>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.IsNotNull(veiculoCriado?.Nome);
            Assert.IsNotNull(veiculoCriado?.Marca);
            Assert.AreEqual(1995, veiculoCriado?.Ano);
        }
    }
}

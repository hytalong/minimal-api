using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.Entidades;

namespace Test.Domain
{
    [TestClass]
    public class VeiculoTest
    {
    [TestMethod]
    public void TestarGetSetPropriedades()
        {
            //arrange
            var veiculo = new Veiculo();

            //Act
            veiculo.Id = 1;
            veiculo.Nome = "Fox";
            veiculo.Marca = "Volkswagen";
            veiculo.Ano  = 2004;

            //Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("Fox", veiculo.Nome);
            Assert.AreEqual("Volkswagen", veiculo.Marca);
            Assert.AreEqual(2004, veiculo.Ano);
        }
    }
    
}
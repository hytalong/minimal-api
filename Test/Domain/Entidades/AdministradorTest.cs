using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.Entidades;

namespace Test.Domain
{
     [TestClass]
    public class AdministradorTest
    {
    [TestMethod]
    public void TestarGetSetPropriedades()
        {
            //arrange
            var adm = new Administrador();

            //Act
            adm.Id = 1;
            adm.Email = "teste@teste.com";
            adm.Senha = "teste";
            adm.Perfil  = "Adm";

            //Assert
            Assert.AreEqual(1, adm.Id);
            Assert.AreEqual("teste@teste.com", adm.Email);
            Assert.AreEqual("teste", adm.Senha);
            Assert.AreEqual("Adm", adm.Perfil);
        }
    }
    
}
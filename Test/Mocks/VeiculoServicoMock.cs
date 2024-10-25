using System;
using System.Collections.Generic;
using System.Linq;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;

namespace Test.Helpers.Mocks
{
    public class VeiculoServicoMock : IVeiculoServico
    {
        private static List<Veiculo> veiculos = new List<Veiculo>()
        {
            new Veiculo
            {
                Id = 1,
                Nome = "FOX",
                Marca = "Volkswagen",
                Ano = 2004
            }
        };

        public void Apagar(Veiculo veiculo)
        {
            veiculos.Remove(veiculo);
        }

        public void Atualizar(Veiculo veiculo)
        {
            var veiculoExistente = BuscarPorId(veiculo.Id);
            if (veiculoExistente != null)
            {
                veiculoExistente.Nome = veiculo.Nome;
                veiculoExistente.Marca = veiculo.Marca;
                veiculoExistente.Ano = veiculo.Ano;
            }
        }

        public Veiculo? BuscarPorId(int id)
        {
            return veiculos.Find(a => a.Id == id);
        }

        public void Incluir(Veiculo veiculo)
        {
            veiculo.Id = veiculos.Count + 1;
            veiculos.Add(veiculo);
        }

        public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
        {
            return veiculos;
        }
    }
}

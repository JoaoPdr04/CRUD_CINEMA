using CinemaDomain;
using System.Diagnostics;
using System.Text.Json;

namespace CinemaTeste
{
    [TestClass]
    public sealed class TestCinemaDomain
    {
        private JsonSerializerOptions OptionsJson()
        {
            return new JsonSerializerOptions { WriteIndented = true };
        }
        [TestMethod]
        public void TesteGenero()
        {
            var genero = new Genero
            {
                Id = 1,
                Nome = "Ação"
            };
            var generoJson = JsonSerializer.Serialize(genero, OptionsJson());
            Debug.WriteLine(generoJson);
            Assert.IsNotNull(generoJson);
        }

        [TestMethod]
        public void TesteFilme()
        {
            var genero1 = new Genero { Id = 1, Nome = "Suspense" };
            var genero2 = new Genero { Id = 2, Nome = "Drama" };
            var filme = new Filme { Id = 1, Nome = "Obssessão", Genero = genero1, Classificacao = "16", Duracao = 90 };

            var filmeJson = JsonSerializer.Serialize(filme, OptionsJson());
            Debug.WriteLine(filmeJson);
            Assert.IsNotNull(filmeJson);
        }
        [TestMethod]
        public void TesteSala()
        {
            var sala = new Sala { Id = 1, Numero = 1, Capacidade = 40 };
            var salaJson = JsonSerializer.Serialize(sala, OptionsJson());
            Debug.WriteLine(salaJson);
            Assert.IsNotNull(salaJson);
        }

        [TestMethod]
        public void TesteSessao()
        {
            var genero = new Genero { Id = 1, Nome = "Ação" };
            var filme = new Filme { Id = 1, Nome = "Missão Impossível", Genero = genero, Classificacao = "14", Duracao = 120 };
            var sala = new Sala { Id = 1, Numero = 1, Capacidade = 40 };
            var sessao = new Sessao { Id = 1, Data = DateTime.Now, Sala = sala, Preco = 25.00m, Filme = filme };
            var sessaoJson = JsonSerializer.Serialize(sessao, OptionsJson());
            Debug.WriteLine(sessaoJson);
            Assert.IsNotNull(sessaoJson);
        }
        [TestMethod]
        public void IngressoTeste()
        {
            var genero = new Genero { Id = 1, Nome = "Drama" };
            var filme = new Filme { Id = 1, Nome = "Her", Genero = genero, Classificacao = "16", Duracao = 100 };
            var sala = new Sala { Id = 1, Numero = 1, Capacidade = 60 };
            var sessao = new Sessao { Id = 1, Data = DateTime.Now, Sala = sala, Preco = 40, Filme = filme };
            var ingresso = new Ingresso { Id = 1, Sessao = sessao, DataCompra = DateTime.Now, Documento = "123456789", FormaPagamento = "Pix", ValorTotal = 100, IngressoItens = new List<IngressoItem>()  };
            var ingressoJson = JsonSerializer.Serialize(ingresso, OptionsJson());
            Debug.WriteLine(ingressoJson);
            Assert.IsNotNull(ingressoJson);
        }
        [TestMethod]
        public void IngressoItemTeste()
        {
            var genero = new Genero { Id = 1, Nome = "Animação" };
            var filme = new Filme { Id = 1, Nome = "Only Yesterday", Genero = genero, Classificacao = "Livre", Duracao = 120 };
            var sala = new Sala { Id = 1, Numero = 1, Capacidade = 50 };
            var sessao = new Sessao { Id = 1, Data = DateTime.Now, Sala = sala, Preco = 50, Filme = filme };
            var ingresso = new Ingresso { Id = 1, Sessao = sessao, DataCompra = DateTime.Now, Documento = "123456789", FormaPagamento = "Pix", ValorTotal = 100, IngressoItens = new List<IngressoItem>() };
            var IngressoItem = new IngressoItem { Ingresso = ingresso, Assento = 14,Fileira = 5, MeiaEntrada = false };
            var ingressoItemJson = JsonSerializer.Serialize(IngressoItem, OptionsJson());
            Debug.WriteLine(ingressoItemJson);
            Assert.IsNotNull(ingressoItemJson);
        }
    }
}

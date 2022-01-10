using Bigai.Torneio.Luta.Api.Models;
using Xunit;

namespace Bigai.Torneio.Luta.Api.UnitTests.Models
{
    public class LutadorTests
    {
        [Fact]
        public void CalcularPercentualVitorias_ConsideraValorInteiro_AtribuiPercentual()
        {
            // Arrange
            var percentualEsperado = 91;
            var lutador = new Lutador()
            {
                Id = 37,
                Nome = "Muhammad Ali",
                Idade = 74,
                ArtesMarciais = new string[] { "Boxe" },
                Lutas = 61,
                Derrotas = 5,
                Vitorias = 56
            };

            // Act
            lutador.CalcularPercentualVitorias();

            // Assert
            Assert.Equal(percentualEsperado, lutador.PercentualVitorias);
        }
    }
}
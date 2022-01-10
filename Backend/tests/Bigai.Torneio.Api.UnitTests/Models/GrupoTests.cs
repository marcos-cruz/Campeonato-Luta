using Bigai.Torneio.Luta.Api.Models;
using Xunit;

namespace Bigai.Torneio.Luta.Api.UnitTests.Models
{
    public class GrupoTests
    {
        [Fact]
        public void CriarGrupos_DeveRetornar4Grupos()
        {
            // Arrange
            var lutadores = HelperTests.Lutadores();
            var gruposEsperados = 4;
            var lutadoresPorGrupo = 5;

            // Act
            var grupos = Grupo.CriarGrupos(lutadores);

            // Assert
            Assert.Equal(gruposEsperados, grupos.Grupos.Count);
            int index = 0;
            foreach (var grupo in grupos.Grupos)
            {
                Assert.Equal(lutadoresPorGrupo, grupos.Grupos[index].Count);
                index++;
            }
        }

        [Fact]
        public void CriarGrupos_LutadoresNosGruposDevemEstarOrdenadosPorIdadeDoMenorParaMaior()
        {
            // Arrange
            var lutadores = HelperTests.Lutadores();

            // Act
            var grupos = Grupo.CriarGrupos(lutadores);

            // Assert
            for (int i = 0, j = grupos.Grupos.Count; i < j; i++)
            {
                var grupoPorIdade = grupos.Grupos[i];

                for (int x = 0, y = 1; y < grupoPorIdade.Count; y++)
                {
                    Assert.True(grupoPorIdade[x].Idade <= grupoPorIdade[y].Idade);
                }

            }
        }
    }
}
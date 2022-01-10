using System.Collections.Generic;
using System.Linq;

namespace Bigai.Torneio.Luta.Api.Models
{
    public class Grupo
    {
        public List<List<Lutador>> Grupos { get; set; }

        private Grupo(List<Lutador> lutadores)
        {
            Grupos = DividirEmGrupos(lutadores);
        }

        public static Grupo CriarGrupos(List<Lutador> lutadores)
        {
            return new Grupo(lutadores);
        }

        public List<List<Lutador>> FaseDeGrupos(List<List<Lutador>> grupos)
        {
            var resultadoCombate = new List<List<Lutador>>();

            foreach (var grupo in grupos)
            {
                var resultado = DisputarNoMesmoGrupo(grupo);

                resultadoCombate.Add(resultado);
            }

            return resultadoCombate;
        }

        private List<List<Lutador>> DividirEmGrupos(List<Lutador> lutadores, int lutadoresPorGrupo = 5)
        {
            if (lutadores == null || lutadores.Count < lutadoresPorGrupo) { return null; }
            
            lutadores = CalcularPercentualVitoriasPorJogador(lutadores);
            
            lutadores = OrdenarPorIdade(lutadores);

            var grupos = lutadores.Select((x, i) => new { Index = i, Value = x })
                                  .GroupBy(x => x.Index / lutadoresPorGrupo)
                                  .Select(x => x.Select(v => v.Value).ToList())
                                  .ToList();
            return grupos;
        }

        private static List<Lutador> CalcularPercentualVitoriasPorJogador(List<Lutador> lutadores)
        {
            foreach (var lutador in lutadores)
            {
                lutador.CalcularPercentualVitorias();
            }

            return lutadores;
        }

        private List<Lutador> OrdenarPorIdade(List<Lutador> lutadores)
        {
            return lutadores.OrderBy(lutador => lutador.Idade)
                            .ToList();
        }
        
        private List<Lutador> DisputarNoMesmoGrupo(List<Lutador> grupoLutadores)
        {
            var resultadoGrupo = grupoLutadores.OrderByDescending(lutador => lutador.PercentualVitorias)
                                               .ToList();

            for (int i = 0, j = resultadoGrupo.Count; i < j; i++)
            {
                var ganhador1 = resultadoGrupo[i];

                for (int x = i + 1, y = resultadoGrupo.Count; x < y; x++)
                {
                    var ganhador2 = resultadoGrupo[x];

                    if (ganhador1.PercentualVitorias == ganhador2.PercentualVitorias && ganhador1.ArtesMarciais.Length == ganhador2.ArtesMarciais.Length)
                    {
                        if (ganhador1.Lutas < ganhador2.Lutas)
                        {
                            resultadoGrupo[x] = ganhador1;
                            resultadoGrupo[i] = ganhador2;
                            x = y;
                        }
                    }
                    else if (ganhador1.PercentualVitorias == ganhador2.PercentualVitorias && ganhador1.ArtesMarciais.Length < ganhador2.ArtesMarciais.Length)
                    {
                        resultadoGrupo[x] = ganhador1;
                        resultadoGrupo[i] = ganhador2;
                        x = y;
                    }
                }
            }

            return resultadoGrupo;
        }
    
    }
}
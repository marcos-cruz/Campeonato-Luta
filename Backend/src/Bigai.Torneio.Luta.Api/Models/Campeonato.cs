using System.Collections.Generic;
using System.Linq;

namespace Bigai.Torneio.Luta.Api.Models
{
    public static class Campeonato
    {
        public static List<Lutador> Disputar(this List<Lutador> lutadores)
        {
            var grupos = Grupo.CriarGrupos(lutadores).Grupos;

            var resultadoFaseDeGrupos = DisputarFaseDeGrupos(grupos);

            var resultadoDasQuartas = DisputarQuartasDeFinal(resultadoFaseDeGrupos);

            var resultadoSemifinal = DisputarSemifinal(resultadoDasQuartas);

            var finalTerceiro = DisputarFinalTerceiro(resultadoSemifinal);

            return finalTerceiro;
        }

        private static List<List<Lutador>> DisputarFaseDeGrupos(List<List<Lutador>> grupos)
        {
            var resultadoCombate = new List<List<Lutador>>();

            foreach (var grupo in grupos)
            {
                var resultado = grupo.DisputarNoMesmoGrupo();

                resultadoCombate.Add(resultado);
            }

            return resultadoCombate;
        }

        private static List<Lutador> DisputarNoMesmoGrupo(this List<Lutador> grupoLutadores)
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

        private static List<Lutador> DisputarQuartasDeFinal(List<List<Lutador>> resultadoFaseDeGrupos)
        {
            var resultadoCombate = new List<Lutador>();

            var primeiroGrupoA = resultadoFaseDeGrupos[0][0];
            var segundoGrupoB = resultadoFaseDeGrupos[1][1];
            resultadoCombate.Add(DisputarPartida(primeiroGrupoA, segundoGrupoB));

            var primeiroGrupoB = resultadoFaseDeGrupos[1][0];
            var segundoGrupoA = resultadoFaseDeGrupos[0][1];
            resultadoCombate.Add(DisputarPartida(primeiroGrupoB, segundoGrupoA));

            var primeiroGrupoC = resultadoFaseDeGrupos[2][0];
            var segundoGrupoD = resultadoFaseDeGrupos[3][1];
            resultadoCombate.Add(DisputarPartida(primeiroGrupoC, segundoGrupoD));

            var primeiroGrupoD = resultadoFaseDeGrupos[3][0];
            var segundoGrupoC = resultadoFaseDeGrupos[2][1];
            resultadoCombate.Add(DisputarPartida(primeiroGrupoD, segundoGrupoC));

            return resultadoCombate;
        }

        private static Lutador DisputarPartida(Lutador primeiroJogador, Lutador segundoJogador)
        {
            var vencedor = (primeiroJogador.PercentualVitorias >= segundoJogador.PercentualVitorias) ? primeiroJogador : segundoJogador;

            if (primeiroJogador.PercentualVitorias == segundoJogador.PercentualVitorias && primeiroJogador.ArtesMarciais.Length == segundoJogador.ArtesMarciais.Length)
            {
                if (primeiroJogador.Lutas < segundoJogador.Lutas)
                {
                    vencedor = segundoJogador;
                }
            }
            else if (primeiroJogador.PercentualVitorias == segundoJogador.PercentualVitorias && primeiroJogador.ArtesMarciais.Length < segundoJogador.ArtesMarciais.Length)
            {
                vencedor = segundoJogador;
            }


            return vencedor;
        }

        private static List<Lutador> DisputarSemifinal(List<Lutador> resultadoQuartasDeFinal)
        {
            var resultadoCombate = new List<Lutador>();

            var vencedor1 = DisputarPartida(resultadoQuartasDeFinal[0], resultadoQuartasDeFinal[1]);
            var perdedor1 = (vencedor1 == resultadoQuartasDeFinal[0]) ? resultadoQuartasDeFinal[1] : resultadoQuartasDeFinal[0];

            var vencedor2 = DisputarPartida(resultadoQuartasDeFinal[2], resultadoQuartasDeFinal[3]);
            var perdedor2 = (vencedor2 == resultadoQuartasDeFinal[2]) ? resultadoQuartasDeFinal[3] : resultadoQuartasDeFinal[2];

            resultadoCombate.Add(vencedor1);
            resultadoCombate.Add(vencedor2);
            resultadoCombate.Add(perdedor1);
            resultadoCombate.Add(perdedor2);

            return resultadoCombate;
        }

        private static List<Lutador> DisputarFinalTerceiro(List<Lutador> resultadoSemifinal)
        {
            var resultadoCombate = new List<Lutador>();

            var campeao = DisputarPartida(resultadoSemifinal[0], resultadoSemifinal[1]);
            var vice = (campeao == resultadoSemifinal[0]) ? resultadoSemifinal[1] : resultadoSemifinal[0];

            var terceiroLugar = DisputarPartida(resultadoSemifinal[2], resultadoSemifinal[3]);

            resultadoCombate.Add(campeao);
            resultadoCombate.Add(vice);
            resultadoCombate.Add(terceiroLugar);

            return resultadoCombate;
        }
    }
}
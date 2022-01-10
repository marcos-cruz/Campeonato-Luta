namespace Bigai.Torneio.Luta.Api.Models
{
    public class Lutador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string[] ArtesMarciais { get; set; }
        public int Lutas { get; set; }
        public int Derrotas { get; set; }
        public int Vitorias { get; set; }
        public int PercentualVitorias { get; set; }

        public void CalcularPercentualVitorias()
        {
            PercentualVitorias = (int)(((double)Vitorias / Lutas) * 100);
        }
    }
}
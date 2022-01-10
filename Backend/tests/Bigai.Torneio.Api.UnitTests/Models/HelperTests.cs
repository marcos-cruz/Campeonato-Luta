using System.Collections.Generic;
using Bigai.Torneio.Luta.Api.Models;

namespace Bigai.Torneio.Luta.Api.UnitTests
{
    public static class HelperTests
    {
        public static List<Lutador> Lutadores()
        {
            return new List<Lutador>()
            {
                new Lutador() { Id =  20, Nome = "Demetrious Johnson", Idade =  32, ArtesMarciais =  new string[] { "Olímpica estilo livre" }, Lutas =  31, Derrotas =  3, Vitorias = 27 },
                new Lutador() { Id =  19, Nome = "Evander Holyfield", Idade =  56, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  57, Derrotas =  10, Vitorias = 44 },
                new Lutador() { Id =  18, Nome = "Mike Tyson", Idade =  52, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  58, Derrotas =  6, Vitorias = 50 },
                new Lutador() { Id =  17, Nome = "Manny Pacquiao", Idade =  40, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  70, Derrotas =  7, Vitorias = 61 },
                new Lutador() { Id =  16, Nome = "Eder Jofre", Idade =  82, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  81, Derrotas =  2, Vitorias = 77 },
                new Lutador() { Id =  15, Nome = "Acelino Popó Freitas", Idade =  43, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  43, Derrotas =  2, Vitorias = 41 },
                new Lutador() { Id =  14, Nome = "Micky Ward", Idade =  53, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  51, Derrotas =  13, Vitorias = 38 },
                new Lutador() { Id =  13, Nome = "Joe Louis", Idade =  66, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  69, Derrotas =  3, Vitorias = 66 },
                new Lutador() { Id =  12, Nome = "Roberto Duran", Idade =  67, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  119, Derrotas =  16, Vitorias = 103 },
                new Lutador() { Id =  11, Nome = "Julio Cesar Chavez", Idade =  56, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  115, Derrotas =  6, Vitorias = 107 },
                new Lutador() { Id =  10, Nome = "Wanderlei Silva", Idade =  42, ArtesMarciais =  new string[] { "Muay Thay", "Jiu-Jitsu" }, Lutas =  50, Derrotas =  13, Vitorias = 35 },
                new Lutador() { Id =  9, Nome = "José Aldo", Idade =  32, ArtesMarciais =  new string[] { "Muay Thai", "Jiu-Jitsu" }, Lutas =  32, Derrotas =  4, Vitorias = 28 },
                new Lutador() { Id =  8, Nome = "Conor McGregor", Idade =  30, ArtesMarciais =  new string[] { "Boxe", "Jiu-jítsu", "Kickboxing", "Capoeira", "Karatê", "Taekwondo" }, Lutas =  25, Derrotas =  4, Vitorias = 21 },
                new Lutador() { Id =  7, Nome = "Rafael dos Anjos", Idade =  34, ArtesMarciais =  new string[] { "Boxe", "Jiu-jítsu", "Muay thai" }, Lutas =  39, Derrotas =  11, Vitorias = 28 },
                new Lutador() { Id =  6, Nome = "Thiago Marreta", Idade =  35, ArtesMarciais =  new string[] { "Muay thai", "Capoeira" }, Lutas =  26, Derrotas =  5, Vitorias = 21 },
                new Lutador() { Id =  5, Nome = "Henry Cejudo", Idade =  32, ArtesMarciais =  new string[] { "Olímpica estilo livre" }, Lutas =  16, Derrotas =  2, Vitorias = 14 },
                new Lutador() { Id =  4, Nome = "Tyron Woodley", Idade =  36, ArtesMarciais =  new string[] { "Wrestling", "KickBoxing", "Boxe" }, Lutas =  23, Derrotas =  3, Vitorias = 19 },
                new Lutador() { Id =  3, Nome = "Rocky Balboa", Idade =  42, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  81, Derrotas =  23, Vitorias = 57 },
                new Lutador() { Id =  2, Nome = "Apollo Creed", Idade =  43, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  47, Derrotas =  1, Vitorias = 46 },
                new Lutador() { Id =  1, Nome = "Adonis Creed", Idade =  32, ArtesMarciais =  new string[] { "Boxe" }, Lutas =  26, Derrotas =  1, Vitorias = 25 }
            };
        }
    }
}
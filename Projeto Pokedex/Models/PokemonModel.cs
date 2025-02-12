using System.Reflection;

namespace Projeto_Pokedex.Models
{
    public class PokemonModel
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }
        //public Imagem imagem
        public float Altura { get; set; }
        public float Peso { get; set; }
        public int Evolucao { get; set; }
    }
}

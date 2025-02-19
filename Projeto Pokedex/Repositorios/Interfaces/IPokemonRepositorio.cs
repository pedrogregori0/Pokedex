using Projeto_Pokedex.Models;

namespace Projeto_Pokedex.Repositorios.Interfaces
{
    public interface IPokemonRepositorio
    {
        Task<List<PokemonModel>> BuscarTodosPokemons(); // puxa tudo que tem na tabela "pokemon" do banco.
        Task<PokemonModel> BuscarPokemonPorID(int id); // recebe o id e usa pra procurar dentro do banco.
        Task<PokemonModel> AdicionarPokemon(PokemonModel pokemon); // adiciona o "pokemon" no banco de dados.   
        Task<PokemonModel> Atualizar(PokemonModel pokemon, int id); // da um refresh na tabela "pokemon" no banco de dados.   
        Task<bool> Apagar(int id);
    }
}

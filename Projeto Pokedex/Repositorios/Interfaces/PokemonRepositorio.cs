using Microsoft.EntityFrameworkCore;
using Projeto_Pokedex.Data;
using Projeto_Pokedex.Models;

namespace Projeto_Pokedex.Repositorios.Interfaces
{
    public class PokemonRepositorio : IPokemonRepositorio
    {
        private readonly PokedexDBContext _dbContext;
        public PokemonRepositorio(PokedexDBContext pokedexDBContext) // construtor
        {
            _dbContext = pokedexDBContext;
        }
        public async Task<PokemonModel> BuscarPokemonPorID(int id)
        {
            return await _dbContext.Pokemons.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PokemonModel>> BuscarTodosPokemons()
        {
            return await _dbContext.Pokemons.ToListAsync();
        }
        public async Task<PokemonModel> AdicionarPokemon(PokemonModel pokemon)
        {
            await _dbContext.Pokemons.AddAsync(pokemon);
            await _dbContext.SaveChangesAsync(); // metodo que confirma e *ADICIONA* o "pokemon" no banco de dados.
            return pokemon; // retorna o pokemon como "salvo".
        }
        public async Task<PokemonModel> Atualizar(PokemonModel pokemon, int id)
        {
            PokemonModel pokemonPorId = await BuscarPokemonPorID(id);

            if(pokemonPorId == null)
            {
                throw new Exception($"Pokemon para o ID:{id} Não foi encontrado no banco de dados.");
            }

            pokemonPorId.Nome = pokemon.Nome;
            pokemonPorId.Descricao = pokemon.Descricao;
            //pokemonPorId.imagem = pokemon.imagem; implementar pra puxar imagem (verificar se é por aqui tambem).
            pokemonPorId.Altura = pokemon.Altura;
            pokemonPorId.Peso = pokemon.Peso;
            pokemonPorId.Evolucao = pokemon.Evolucao;

            _dbContext.Pokemons.Update(pokemonPorId); // manda o comando de atualizar as informações.
            await _dbContext.SaveChangesAsync(); // usa o metodo pra salvar e confirmar a alteração das informações.
            return pokemonPorId; // retorna o "pokemon" encontrado.
        }
        public async Task<bool> Apagar(int id)
        {
            PokemonModel pokemonPorId = await BuscarPokemonPorID(id);

            if (pokemonPorId == null)
            {
                throw new Exception($"Pokemon para o ID:{id} Não foi encontrado no banco de dados.");
            }

            _dbContext.Pokemons.Remove(pokemonPorId);
            await _dbContext.SaveChangesAsync(); // metodo que confirma e *APAGA* o "pokemon" no banco de dados.
            return true;
        }


    }
}

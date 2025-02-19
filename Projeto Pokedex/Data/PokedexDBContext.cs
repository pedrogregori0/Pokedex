using Microsoft.EntityFrameworkCore;
using Projeto_Pokedex.Models;

namespace Projeto_Pokedex.Data
{
    public class PokedexDBContext : DbContext
    {
        public PokedexDBContext(DbContextOptions<PokedexDBContext> options) : base(options) 
        { 
            
        }

        public DbSet<PokemonModel> Pokemons { get; set; }   // cria a tabela "Pokemons" do banco
        public DbSet<TipoModel> Tipos{ get; set; } // cria a tabela "Tipos" do banco 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

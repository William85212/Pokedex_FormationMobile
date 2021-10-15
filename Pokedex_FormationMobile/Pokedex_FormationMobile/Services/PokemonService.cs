using Pokedex_FormationMobile.Models;
using Pokedex_FormationMobile.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex_FormationMobile.Services
{
    public class PokemonService : ApiRequester
    {
        public PokemonService() : base("https://pokeapi.co/api/v2/pokemon")
        {

        }

        public async Task<PokemonPage> GetAll(string url = null)
        {
            PokemonPage pp = await Get<PokemonPage>(url);
            return pp;
        }

        public async Task<PokemonDetails> Details(string url)
        {
            //Client.BaseAddress = null;
            PokemonDetails pp = await Get<PokemonDetails>(url);
            return pp;
        }
    }
}

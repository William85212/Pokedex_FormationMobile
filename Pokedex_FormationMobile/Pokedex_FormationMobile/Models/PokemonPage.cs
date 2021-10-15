using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Pokedex_FormationMobile.Models
{
    public class PokemonPage
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public ObservableCollection<Pokemon> Results { get; set; }
    }
}

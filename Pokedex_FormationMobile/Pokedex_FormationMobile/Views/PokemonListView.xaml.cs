using Pokedex_FormationMobile.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex_FormationMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonListView : ContentPage
    {
        public PokemonListView()
        {
            BindingContext = new PokemonListViewModel();
            InitializeComponent();
        }
    }
}
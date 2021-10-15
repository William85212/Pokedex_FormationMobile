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
    public partial class Page1 : ContentPage
    {
        public Page1(string url)
        {
            
            BindingContext = new PokemonDetailViewModel( url);
            InitializeComponent();
        }
    }
}
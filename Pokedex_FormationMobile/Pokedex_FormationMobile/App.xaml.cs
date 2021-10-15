using Pokedex_FormationMobile.Services;
using Pokedex_FormationMobile.Tools;
using Pokedex_FormationMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex_FormationMobile
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<PokemonService>();
            InitializeComponent();

            MainPage = new PokemonListView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

using Pokedex_FormationMobile.Models;
using Pokedex_FormationMobile.Services;
using Pokedex_FormationMobile.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Pokedex_FormationMobile.ViewsModels
{
    public class PokemonDetailViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }

        private Sprites _sprites;

        public Sprites Sprites
        {
            get { return _sprites; }
            set { SetValue(ref _sprites, value); }
        }

        private string _text;

        public string Weight
        {
            get { return _text; }
            set { _text = value; }
        }


        private Command _closeCommand;

        public Command CloseCommand
        {
            get { return _closeCommand = _closeCommand ?? new Command(Close); }
        }

        private void Close()
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        public PokemonDetailViewModel(string url)
        {
            LoadItem(url);
        }

        private async void LoadItem(string url)
        {
            PokemonDetails pkn = await DependencyService.Get<PokemonService>().Details(url);
            Name = pkn.Name;
            Sprites = pkn.Sprites;
            Weight = pkn.Weight;
        }
    }
}

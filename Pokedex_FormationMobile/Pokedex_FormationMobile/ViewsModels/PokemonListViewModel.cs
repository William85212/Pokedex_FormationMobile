using Pokedex_FormationMobile.Models;
using Pokedex_FormationMobile.Services;
using Pokedex_FormationMobile.Tools;
using Pokedex_FormationMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Pokedex_FormationMobile.ViewsModels
{
    public class PokemonListViewModel : ViewModelBase
    {
        public ObservableCollection<Pokemon> Liste { get; set; }

        private int _count;

        public int Count
        {
            get { return _count; }
            set { SetValue(ref _count, value); }
        }

        private string _next;

        public string Next
        {
            get { return _next; }
            set { SetValue(ref _next, value); }
        }

        private string _previous;

        public string Previous
        {
            get { return _previous; }
            set { SetValue(ref _previous, value); }
        }

        private Command _nextCommand;

        public Command NextCommand
        {
            get { return _nextCommand = _nextCommand ?? new Command(Suivant); }
        }

        private Command _previousCommand;

        public Command PreviousCommand
        {
            get { return _previousCommand = _previousCommand ?? new Command(Precedent); }
        }

        private void Suivant()
        {
            LoadItems(Next);
        }
        private void Precedent()
        {
            LoadItems(Previous);
        }

        public PokemonListViewModel()
        {
            Liste = new ObservableCollection<Pokemon>();
            LoadItems();
        }

        private async void LoadItems(string url = null)
        {
            Liste.Clear();
            PokemonPage listes =await DependencyService.Get<PokemonService>().GetAll(url);
            foreach (Pokemon item in listes.Results)
            {
                 Liste.Add(item);
            }

            Previous = listes.Previous;
            Next = listes.Next;
        }

        private Pokemon _pokemonSelected;

        public Pokemon SelectedPokemon
        {
            get { return _pokemonSelected; }
            set
            {
                SetValue(ref _pokemonSelected, value);
                if (!(_pokemonSelected is null))
                {
                    App.Current.MainPage.Navigation.PushModalAsync(new Page1(SelectedPokemon.Url));
                 
                }

            }
        }

       
    }
}

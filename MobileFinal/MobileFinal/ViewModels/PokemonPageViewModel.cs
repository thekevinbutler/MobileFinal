using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MobileFinal.Models.PokemonItem;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ModernHttpClient;
using System.Net.Http;

namespace MobileFinal.ViewModels
{
    public class PokemonPageViewModel : BindableBase, INavigationAware
    {
		public DelegateCommand RefreshCommand { get; set; }
        public INavigationService _navigationService;
        public DelegateCommand BackToMainCommand { get; set; }

        private Pokemon _pokeDisplay;
        public Pokemon PokeDisplay
        {
            get { return _pokeDisplay; }
            set { SetProperty(ref _pokeDisplay, value); }
        }

		private bool _refreshing;
		public bool Refreshing
		{
			get { return _refreshing; }
			set { SetProperty(ref _refreshing, value); }
		}

		private string _hap;
        public string Hap
        {
            get { return _hap; }
            set { SetProperty(ref _hap, value); }
        }


        public PokemonPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            BackToMainCommand = new DelegateCommand(NavToMain);
			RefreshCommand = new DelegateCommand(RefreshPokemon);
			//Refreshing = true;
        }

		private void RefreshPokemon()
		{
			PokeDisplay = new Pokemon();
			Refreshing = false;
			RandomPokemon();
			
		}

        private async void NavToMain()
        {
            await _navigationService.GoBackAsync();
        }


        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
           
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }
		private async void RandomPokemon()
		{
			Random rnd = new Random();
			int pokenum = rnd.Next(1, 150);
			HttpClient client = new HttpClient(new NativeMessageHandler());
			var uri = new Uri(
				string.Format(
					$"https://pokeapi.co/api/v2/pokemon/{pokenum}/"));
			try
			{
				var response = await client.GetAsync(uri);
			
			Pokemon pokeData = null;
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				pokeData = Pokemon.FromJson(content);
				PokeDisplay = pokeData;
			}
			}
			catch (Exception e)
			{
				Debug.Print(e.StackTrace);
			}
		}
        public void OnNavigatedTo(NavigationParameters parameters)
        {
			RandomPokemon();
        }





    }
}

using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MobileFinal.Models.PokemonItem;
using System.Collections.ObjectModel;
using System.Net.Http;
namespace MobileFinal.ViewModels
{
    public class PokemonPageViewModel : BindableBase, INavigationAware
    {

        public INavigationService _navigationService;
        public DelegateCommand BackToMainCommand { get; set; }

        private Pokemon _pokeDisplay;
        public Pokemon PokeDisplay
        {
            get { return _pokeDisplay; }
            set { SetProperty(ref _pokeDisplay, value); }
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

        public async void OnNavigatedTo(NavigationParameters parameters)
        {

            Random rnd = new Random();
            int pokenum = rnd.Next(1, 150);
            HttpClient client = new HttpClient();
            var uri = new Uri(
                string.Format(
                    $"http://pokeapi.co/api/v2/pokemon/{pokenum}/"));
            var response = await client.GetAsync(uri);
           
            Pokemon pokeData = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                pokeData = Pokemon.FromJson(content);

                // Hap = content.ToString();

                //for (int i = 0; i < pokeData.Articles.Count; i++)
                //{
                //    ArticleCollection.Add(pokeData.Articles[i]);
                //}
                PokeDisplay = pokeData;
            }


        }





    }
}

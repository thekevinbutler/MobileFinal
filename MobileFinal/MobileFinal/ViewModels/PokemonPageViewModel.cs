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

        private Pokemon _pokeDisplay;
        public Pokemon PokeDisplay
        {
            get { return _pokeDisplay; }
            set { SetProperty(ref _pokeDisplay, value); }
        }


        public async void OnNavigatingTo(NavigationParameters parameters)
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



                //for (int i = 0; i < pokeData.Articles.Count; i++)
                //{
                //    ArticleCollection.Add(pokeData.Articles[i]);
                //}
                PokeDisplay = pokeData;
            }
           
        }
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {




        }





    }
}

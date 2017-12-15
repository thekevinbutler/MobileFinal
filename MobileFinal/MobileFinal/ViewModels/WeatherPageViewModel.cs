using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using static MobileFinal.Models.ForecastItem;
using Prism.Navigation;
using System.Net.Http;
using static MobileFinal.Models.CharacterItem;

namespace MobileFinal.ViewModels
{
    public class WeatherPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand GetForecastForCityCommand { get; set; }
        public DelegateCommand BackToMainCommand { get; set; }



        private ObservableCollection<ForecastInfo> _forecastCollection = new ObservableCollection<ForecastInfo>();
        public ObservableCollection<ForecastInfo> ForecastCollection
        {
            get { return _forecastCollection; }
            set { SetProperty(ref _forecastCollection, value); }
        }

        private ForecastInfo _fiveday;
        public  ForecastInfo FiveDay
        {
            get { return _fiveday; }
            set { SetProperty(ref _fiveday, value); }
        }

        private string _search;
        public string Search
        {
            get { return _search; }
            set { SetProperty(ref _search, value); }
        }

        private ForecastInfo _currentForecast;
        public ForecastInfo CurrentForecast
        {
            get { return _currentForecast; }
            set { SetProperty(ref _currentForecast, value); }
        }

        INavigationService _navigationService;

        public WeatherPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
            // DeleteNewsCommand = new DelegateCommand<Articles>(DeleteApod);
            GetForecastForCityCommand = new DelegateCommand(GetForecastForCity);
            BackToMainCommand = new DelegateCommand(NavToMain);

           // NavToMoreInfoPageCommand = new DelegateCommand<Article>(NavToMoreInfoPage);
           // DeleteArtCommand = new DelegateCommand(DeleteArticles);
        }

		private async void GetForecastForCity()
        {
			HttpClient client = new HttpClient();

            Uri uri = new Uri("http://api.openweathermap.org/data/2.5/forecast?q=San+Marcos,us&units=imperial&APPID=d0d471a1a152669ddd200968f56c54a3");

            var response = await client.GetAsync(uri);
            ForecastInfo forecastData = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                forecastData = ForecastInfo.FromJson(content);
                FiveDay = forecastData;

            }
            for (int i = 7; i <= 39;)
            {
                FiveDay.list[i].dt_txt = FiveDay.list[i].dt_txt.Substring(5, 5);

                i += 8;
            }
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

        public void OnNavigatedTo(NavigationParameters parameters)
        {




        }


    }
}

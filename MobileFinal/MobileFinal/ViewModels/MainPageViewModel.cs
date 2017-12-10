using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MobileFinal.Models.NewsItem;
using System.Collections.ObjectModel;
using System.Net.Http;

namespace MobileFinal.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand<NewsArticle> DeleteNewsCommand { get; set; }

        public DelegateCommand NavToNewsCommand { get; set; }
        public DelegateCommand NavToWeatherCommand { get; set; }
		public DelegateCommand NavToTimeCommand { get; set; }


        private string _newsOrgEnteredByUser;
        public string NewsOrgEnteredByUser
        {
            get { return _newsOrgEnteredByUser; }
            set { SetProperty(ref _newsOrgEnteredByUser, value); }
        }

        private ObservableCollection<NewsArticle> _newsCollection = new ObservableCollection<NewsArticle>();
        public ObservableCollection<NewsArticle> NewsCollection
        {
            get { return _newsCollection; }
            set { SetProperty(ref _newsCollection, value); }
        }

        private ObservableCollection<Article> _articleCollection = new ObservableCollection<Article>();
        public ObservableCollection<Article> ArticleCollection
        {
            get { return _articleCollection; }
            set { SetProperty(ref _articleCollection, value); }
        }


        INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
           // DeleteNewsCommand = new DelegateCommand<Articles>(DeleteApod);
            NavToNewsCommand = new DelegateCommand(NavToNewsPage);
			NavToTimeCommand = new DelegateCommand(NavToTimePage);
        }
		private async void NavToTimePage()
		{
			var navParams = new NavigationParameters();
			await _navigationService.NavigateAsync("TimePage", navParams);
		}
            NavToWeatherCommand = new DelegateCommand(NavToWeatherPage);
        }


        private async void NavToNewsPage()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("NewsPage", navParams);
        }

        private async void NavToWeatherPage()
        {
            var navParams = new NavigationParameters();

            await _navigationService.NavigateAsync("WeatherPage", navParams);
        }


        private async void GetNewsForOrg()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri(
                string.Format(
                    $"https://newsapi.org/v2/top-headlines?sources={NewsOrgEnteredByUser}&apiKey=b49235adad6d4e0392cfa2970d4de6f4"));
            var response = await client.GetAsync(uri);
            NewsArticle newsData = null;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                newsData = NewsArticle.FromJson(content);

                for (int i = 0; i < newsData.Articles.Count;i++ )
                {
                    ArticleCollection.Add(newsData.Articles[i]);
                }

            }
            NewsCollection.Add(newsData);
            


        }
        public void DeleteApod(NewsArticle newsItem)
        {
            NewsCollection.Remove(newsItem);
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

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
        public DelegateCommand GetNewsForOrgCommand { get; set; }
        public DelegateCommand<NewsArticle> NavToMoreInfoPageCommand { get; set; }

        private string _hap;
        public string Hap
        {
            get { return _hap; }
            set { SetProperty(ref _hap, value); }
        }

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
            GetNewsForOrgCommand = new DelegateCommand(GetNewsForOrg);
            NavToMoreInfoPageCommand = new DelegateCommand<NewsArticle>(NavToMoreInfoPage);
        }



        private async void NavToMoreInfoPage(NewsArticle newsItem)
        {
            var navParams = new NavigationParameters();
            navParams.Add("NewsItemInfo", newsItem);
            await _navigationService.NavigateAsync("MoreInfoPage", navParams);
        }



        private

        async void GetNewsForOrg()
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


                ArticleCollection.Add(newsData.Articles.First());
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

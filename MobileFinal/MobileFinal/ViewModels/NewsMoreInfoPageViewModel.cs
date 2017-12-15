using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Xamarin.Forms.Xaml;
using static MobileFinal.Models.NewsItem;
using Xamarin.Forms;

namespace MobileFinal.ViewModels
{
    public class NewsMoreInfoPageViewModel : BindableBase, INavigatedAware
    {
        
            INavigationService _navigationService;

            public DelegateCommand GoWebCommand{ get; set; }
            public DelegateCommand GoBackCommand { get; set; }

            private Article _article;
            public Article Article
            {
                get { return _article; }
                set { SetProperty(ref _article, value); }
            }


        public NewsMoreInfoPageViewModel(INavigationService navigationService)
        {
                _navigationService = navigationService;

            GoWebCommand = new DelegateCommand(GoWeb);
            GoBackCommand = new DelegateCommand(GoBack);
        }

        private void GoWeb()
        {
            var url = Article.Url.ToString();
            Device.OpenUri(new Uri(url));
        }
        private void GoBack()
        {
            await _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
                if (parameters.ContainsKey("ArticleItemInfo"))
                {
                    Article = (Article)parameters["ArticleItemInfo"];
                }

           
        }



     }
    
}


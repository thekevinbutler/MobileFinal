using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MobileFinal.ViewModels
{
	public class MapPageViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand BackToMainCommand { get; set; }

        INavigationService _navigationService;

        public MapPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            BackToMainCommand = new DelegateCommand(NavToMain);

        }

        private async void NavToMain()
        {
            await _navigationService.GoBackAsync();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}

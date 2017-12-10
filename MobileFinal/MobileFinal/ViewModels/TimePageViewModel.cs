using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileFinal.ViewModels
{
	public class TimePageViewModel : BindableBase, INavigationAware
	{
		private string _digitalDateText;
		public string DigitalDateText
		{
			get { return _digitalDateText; }
			set { SetProperty(ref _digitalDateText, value); }
		}
		public INavigationService _navigationService;
		public DelegateCommand BackToMainCommand { get; set; }

        public TimePageViewModel(INavigationService navigationService)
        {
			_navigationService = navigationService;
			BackToMainCommand = new DelegateCommand(NavToMain);
			DigitalDateText = DateTime.Now.ToShortDateString();
        }

		private async void NavToMain()
		{
			await _navigationService.GoBackAsync();
		}
		public void OnNavigatingTo(NavigationParameters parameters)
		{
		}
		public void OnNavigatedFrom(NavigationParameters parameters)
		{ }
		public void OnNavigatedTo(NavigationParameters parameters)
		{
		}
	}
}

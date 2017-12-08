using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Prism.Navigation;

namespace MobileFinal.ViewModels
{
	public class ClockPageViewModel : BindableBase, INavigatedAware
	{
		INavigationService _navigationService;

		//public ICommand<object, SKPaintSurfaceEventArgs> CanvasCommand { get; set; }
		//public void On_Paint(object sender, SKPaintSurfaceEventArgs e)
		//{
		//	SKSurface surface = e.Surface;
		//	SKCanvas canvas = surface.Canvas;
		//	canvas.Clear(SKColors.Magenta);
			
		//}
		public ClockPageViewModel(INavigationService navigation)
        {
			_navigationService = navigation;
			//CanvasCommand = new DelegateCommand<SKPaintSurfaceEventArgs>(On_Paint);
        }
		
		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
			
		}

	}
}

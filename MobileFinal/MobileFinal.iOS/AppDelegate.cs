﻿using Foundation;
using UIKit;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Refractored.XamForms.PullToRefresh.iOS;

namespace MobileFinal.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            PullToRefreshLayoutRenderer.Init();
            global::Xamarin.Forms.Forms.Init();

			PullToRefreshLayoutRenderer.Init();
			

            Xamarin.FormsMaps.Init();
            LoadApplication(new App(new iOSInitializer()));


            return base.FinishedLaunching(app, options);

        }
    }

    public class iOSInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
        }
    }
}

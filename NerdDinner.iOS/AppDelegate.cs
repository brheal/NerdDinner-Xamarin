using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp;
using MonoTouch.ObjCRuntime;

namespace NerdDinner
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		private TabBarController _tabController;
		private UIWindow _window;
		private Appirater _appirater;
			
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			_window = new UIWindow (UIScreen.MainScreen.Bounds);

			_tabController = new TabBarController();

			_window.RootViewController = _tabController;

			// make the window visible
			_window.MakeKeyAndVisible ();

//			var raterSettings = new AppiraterSettings (493888026, "Nerd Dinner Mobile", false);
//			raterSettings.DaysUntilPrompt = 1;
//
//			_appirater = new Appirater (raterSettings);
//			_appirater.AppLaunched (true);

			return true;
		}

		public override void WillEnterForeground (UIApplication application)
		{
//			_appirater.AppEnteredForeground (true);
		}

		public static bool IsPhone 
		{
			get 
			{
				return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone;
			}
		}

		public static bool IsPad 
		{
			get 
			{
				return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad;
			}
		}

		public static bool HasRetina 
		{
			get 
			{
				if (MonoTouch.UIKit.UIScreen.MainScreen.RespondsToSelector(new Selector("scale")))
					return (MonoTouch.UIKit.UIScreen.MainScreen.Scale == 2.0);
				else
					return false;
			}
		}
	}
}


using System;
using MonoTouch.UIKit;

namespace NerdDinner
{
	public class TabBarController : UITabBarController
	{
		private UINavigationController _listNav;
		private DinnerListViewController _dinnerListView;
		private UINavigationController _mapNav;
		private DinnerMapViewController _dinnerMapView;
		private UINavigationController _aboutNav;
		private AboutViewController _aboutView;

		private IDinnerRepository _dinnerRepository;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			_dinnerRepository = new DinnerRepositoryOdata ();

			_dinnerListView = new DinnerListViewController(_dinnerRepository);
			_dinnerMapView = new DinnerMapViewController(_dinnerRepository);
			_aboutView = new AboutViewController();

			_listNav = new UINavigationController
			{
				TabBarItem = new UITabBarItem("List", UIImage.FromFile("Tabs/sessions.png"), 1)
			};
			_listNav.PushViewController(_dinnerListView, false);
			_dinnerListView.NavigationItem.Title = "List";

			_mapNav = new UINavigationController
			{
				TabBarItem = new UITabBarItem("Map", UIImage.FromFile("Tabs/maps.png"), 1)
			};
			_mapNav.PushViewController(_dinnerMapView, false);
			_dinnerMapView.NavigationItem.Title = "Map";

			_aboutNav = new UINavigationController
			{
				TabBarItem = new UITabBarItem("About", UIImage.FromFile("Tabs/sessions.png"), 1)
			};
			_aboutNav.PushViewController(_aboutView, false);
			_aboutView.Title = "About";

			ViewControllers = new UIViewController[]
			{
				_listNav,
				_mapNav,
				_aboutView
			};
		}
	}}


using System;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace NerdDinner
{
	public class DinnerListViewController : UITableViewController
	{
		IDinnerRepository dinnerRepository;

		public DinnerListViewController(IDinnerRepository _dinnerRepository) : base()
		{
			dinnerRepository = _dinnerRepository;

			var dinnersDelegate = new DinnerDelegate ();
			dinnersDelegate.DinnerSelected += HandleDinnerSelected;

			TableView.DataSource = new DinnerDataSource (_dinnerRepository);
			TableView.Delegate = dinnersDelegate;
			TableView.SectionIndexMinimumDisplayRowCount = 10;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			//
			// Deselect all cells when appearing
			//
			var sel = TableView.IndexPathForSelectedRow;
			if (sel != null) {
				TableView.DeselectRow (sel, true);
			}
		}

		void HandleDinnerSelected (object sender, DinnerSelectedEventArgs e)
		{
			var dinnerDetailViewController = new DinnerDetailViewController (e.Dinner);

			NavigationController.PushViewController (dinnerDetailViewController, true);
		}
	}
}


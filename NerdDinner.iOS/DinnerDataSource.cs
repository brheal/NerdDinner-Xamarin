using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.Foundation;
using System.Collections.ObjectModel;

namespace NerdDinner
{
	public class DinnerDataSource : UITableViewDataSource 
	{
		public List<Dinner> Dinners { get; set; }

		string cellIdentifier = "TableCell";

		public DinnerDataSource (IDinnerRepository dinnerRepository)
		{
			Dinners = new List<Dinner> ();

			if (Reachability.InternetConnectionStatus () != NetworkStatus.NotReachable) {
				Dinners = dinnerRepository.FindUpcomingDinners ();
			}
		}

		public Dinner GetDinner (NSIndexPath indexPath)
		{
			return Dinners [indexPath.Row];
		}

		public override int RowsInSection (UITableView tableview, int section)
		{
			return Dinners.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellIdentifier) as DinnerCell;
			if (cell == null) {
				cell = new DinnerCell (cellIdentifier);
			}

			var dinner = GetDinner (indexPath);
			if (dinner != null) {
				cell.Dinner = dinner;
			}

			return cell;
		}
	}
}


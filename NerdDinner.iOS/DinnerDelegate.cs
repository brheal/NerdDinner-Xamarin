using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace NerdDinner
{
	public class DinnerDelegate : UITableViewDelegate
	{
		public event EventHandler<DinnerSelectedEventArgs> DinnerSelected;

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			var dinner = ((DinnerDataSource)tableView.DataSource).GetDinner (indexPath);
			if (dinner != null) {
				var ev = DinnerSelected;
				if (ev != null) {
					ev (this, new DinnerSelectedEventArgs { Dinner = dinner });
				}
			}

			//Deselect, we use BeginInvoke, otherwise it doesn't deselect properly
			BeginInvokeOnMainThread(() => {
				var cell = tableView.CellAt(indexPath);
				cell.SetSelected(false, true);
			});
		}
	}

	public class DinnerSelectedEventArgs : EventArgs
	{
		public Dinner Dinner { get; set; }
	}
}


using System;

using MonoTouch.Foundation;
using MonoTouch.MessageUI;
using MonoTouch.UIKit;

namespace NerdDinner
{
	public partial class DinnerDetailViewController : UITableViewController
	{
		public DinnerViewModel dinnerViewModel;

		public DinnerDetailViewController (Dinner _dinner) : base (UITableViewStyle.Grouped)
		{
			dinnerViewModel = new DinnerViewModel(_dinner);

			Title = _dinner.Title;

			TableView.DataSource = new DinnerDetailDataSource (this);
			TableView.Delegate = new DinnerDetailDelegate (this);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			DeselectAll ();
		}

		void DeselectAll ()
		{
			var sel = TableView.IndexPathForSelectedRow;
			if (sel != null) {
				TableView.DeselectRow (sel, true);
			}
		}

		void OnPhoneSelected (string phoneNumber)
		{
			var url = NSUrl.FromString("tel:" + Uri.EscapeDataString(phoneNumber));

			if (UIApplication.SharedApplication.CanOpenUrl(url))
				UIApplication.SharedApplication.OpenUrl(url);
			else
				new UIAlertView("Oops", "Phone is not available", null, "Ok").Show();
		}

		void OnEmailSelected (string emailAddress)
		{
			if (MFMailComposeViewController.CanSendMail) {
				var composer = new MFMailComposeViewController ();
				composer.SetToRecipients(new string[] { emailAddress });
				composer.Finished += (sender, e) => DismissViewController (true, null);
				PresentViewController (composer, true, null);
			} else {
				new UIAlertView("Oops", "Email is not available", null, "Ok").Show();
			}
		}

		void OnTwitterSelected (string twitterName)
		{
			var name = twitterName;
			if (name.StartsWith ("@")) {
				name = name.Substring (1);
			}
			UIApplication.SharedApplication.OpenUrl (
				NSUrl.FromString ("http://twitter.com/" + Uri.EscapeDataString (name)));
		}

		void OnUrlSelected (string url)
		{
			UIApplication.SharedApplication.OpenUrl (
				NSUrl.FromString (url));
		}

		void OnAddressSelected (string address)
		{
			UIApplication.SharedApplication.OpenUrl (
				NSUrl.FromString ("http://maps.google.com/maps?q=" + Uri.EscapeDataString (address)));
		}

		void OnPropertySelected (Property property)
		{
			switch (property.Type) {
				case PropertyType.Phone:
				OnPhoneSelected (property.Value);
				break;
				case PropertyType.Email:
				OnEmailSelected (property.Value);
				break;
				case PropertyType.Twitter:
				OnTwitterSelected (property.Value);
				break;
				case PropertyType.Url:
				OnUrlSelected (property.Value);
				break;
				case PropertyType.Address:
				OnAddressSelected (property.Value);
				break;
			}
			DeselectAll ();
		}

		class DinnerDetailDelegate : UITableViewDelegate
		{
			DinnerDetailViewController controller;

			public DinnerDetailDelegate (DinnerDetailViewController controller)
			{
				this.controller = controller;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				var section = indexPath.Section;
				var prop = controller.dinnerViewModel.PropertyGroups [section].Properties [indexPath.Row];
				controller.OnPropertySelected (prop);
			}

			public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
			{
				if (indexPath.Section == 2) {
					return 100;
				} else {
					return 44;
				}
			}
		}

		class DinnerDetailDataSource : UITableViewDataSource
		{
			DinnerDetailViewController controller;

			public DinnerDetailDataSource (DinnerDetailViewController controller)
			{
				this.controller = controller;
			}

			public override int NumberOfSections (UITableView tableView)
			{
				return controller.dinnerViewModel.PropertyGroups.Count;
			}

			public override int RowsInSection (UITableView tableView, int section)
			{
				return controller.dinnerViewModel.PropertyGroups[section].Properties.Count;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var section = indexPath.Section;
				var cell = tableView.DequeueReusableCell ("C");
				if (cell == null) {
					cell = new UITableViewCell (UITableViewCellStyle.Value2, "C");
				}

				var prop = controller.dinnerViewModel.PropertyGroups [section].Properties [indexPath.Row];

				cell.TextLabel.Text = prop.Name.ToLowerInvariant ();
				cell.DetailTextLabel.Text = prop.Value;
				cell.DetailTextLabel.Lines = 0;

				cell.SelectionStyle = prop.Type == PropertyType.Generic ?
					UITableViewCellSelectionStyle.None :
						UITableViewCellSelectionStyle.Blue;

				return cell;
			}
		}
	}
}


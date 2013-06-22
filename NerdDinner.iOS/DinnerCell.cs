using System;
using MonoTouch.UIKit;
using System.Drawing;
using RestSharp.Extensions;
using System.Globalization;

namespace NerdDinner
{
	public class DinnerCell: UITableViewCell
	{
		static readonly UIFont NormalFont = UIFont.SystemFontOfSize (16);
		static readonly UIFont BoldFont = UIFont.BoldSystemFontOfSize (16);
		static readonly UIFont DetailsFont = UIFont.SystemFontOfSize (12);

		UILabel firstNameLabel;
		UILabel lastNameLabel;
		UILabel detailsLabel;

		Dinner dinner = null;
		public Dinner Dinner {
			get { return dinner; }
			set {
				if (dinner != value) {
					dinner = value;
					UpdateUI ();
				}
			}
		}

		public DinnerCell (string id)
			: base (UITableViewCellStyle.Default, id)
		{
			firstNameLabel = new UILabel {
				Font = BoldFont,
				TextColor = UIColor.Black,
				HighlightedTextColor = UIColor.White,
			};
			ContentView.Add (firstNameLabel);

			lastNameLabel = new UILabel {
				Font = NormalFont,
				TextColor = UIColor.Black,
				HighlightedTextColor = UIColor.White,
			};
			ContentView.Add (lastNameLabel);

			detailsLabel = new UILabel {
				Font = DetailsFont,
				TextColor = UIColor.Gray,
				HighlightedTextColor = UIColor.White,
			};
			ContentView.Add (detailsLabel);
		}

		void UpdateUI ()
		{
			var x = 6;

			var fn = dinner.Title;
			firstNameLabel.Text = fn;
			var fnw = string.IsNullOrEmpty (fn) ? 
				0.0f : 
					firstNameLabel.StringSize (fn, BoldFont).Width;
			var f = new RectangleF (x, 4, fnw + 4, 20);
			firstNameLabel.Frame = f;

			var ln = dinner.Description;
			lastNameLabel.Text = ln;
			var lnw = string.IsNullOrEmpty (ln) ?
				0.0f :
					lastNameLabel.StringSize (ln, NormalFont).Width;
			f.X = f.Right;
			f.Width = lnw;
			lastNameLabel.Frame = f;

			var date = Dinner.EventDate.ParseJsonDate (CultureInfo.CurrentUICulture);

			// var date = DateTime.Parse(dinner.EventDate ?? "");
			detailsLabel.Text = date.ToString ();
			detailsLabel.Frame = new RectangleF (x, 25, 258, 14);
		}
	}
}


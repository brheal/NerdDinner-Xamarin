using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace NerdDinner
{
	public partial class AboutViewController : UIViewController
	{
		UIScrollView _scrollView;

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			float xOffset = 10;
			float yOffset = 10;

			View.BackgroundColor = UIColor.White;

			_scrollView = new UIScrollView () {
				Frame = new RectangleF(0, 0, View.Frame.Width, View.Frame.Height),
				AutoresizingMask = UIViewAutoresizing.FlexibleHeight
			};
			View.AddSubview (_scrollView);

			var imageView = new UIImageView (UIImage.FromFile ("nerd.jpg"));
			imageView.Frame = new RectangleF ((View.Frame.Width - imageView.Frame.Width) / 2, yOffset, imageView.Frame.Width, imageView.Frame.Height);
			_scrollView.AddSubview (imageView);

			var label1 = new UILabel (
				new RectangleF(xOffset, imageView.Frame.Top + imageView.Frame.Height + yOffset, View.Frame.Width - (xOffset * 2), 0));
			label1.Text = "Are you a huge nerd? Perhaps a geek? No? Maybe a dork, dweeb or wonk. Quite possibly you're just a normal person. Either way, you're a social being. You need to get out for a bite to eat occasionally, preferably with folks that are like you.";
			label1.Lines = 0;
			label1.SizeToFit ();
			_scrollView.AddSubview(label1);

			var label2 = new UILabel (
				new RectangleF(xOffset, label1.Frame.Top + label1.Frame.Height + yOffset, View.Frame.Width - (xOffset * 2), 0));
			label2.Text = "Code by Hanselman, Guthrie, Galloway, Mourfield, Petersen and Arnott. JavaScript by Dave Ward. ASP.NET MVC by Haack and friends. Style by Michael Dorian Bach.";
			label2.Lines = 0;
			label2.SizeToFit ();
			_scrollView.AddSubview(label2);

			_scrollView.ContentSize = new SizeF (View.Frame.Width, label2.Frame.Top + label2.Frame.Height);
		}
	}
}
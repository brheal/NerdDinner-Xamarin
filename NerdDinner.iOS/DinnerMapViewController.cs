using System;
using MonoTouch.UIKit;
using MonoTouch.MapKit;
using System.Collections.Generic;
using MonoTouch.CoreLocation;

namespace NerdDinner
{
	public class DinnerMapViewController : UIViewController
	{
		MKMapView mapView;
		IEnumerable<Dinner> dinners;

		public DinnerMapViewController(IDinnerRepository dinnerRepository) : base()
		{
			dinners = new List<Dinner> (dinnerRepository.FindUpcomingDinners());
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			mapView = new MKMapView (View.Bounds);
			mapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

			foreach (Dinner dinner in dinners) {
				var annotation = new BasicMapAnnotation (new CLLocationCoordinate2D (dinner.Latitude, dinner.Longitude), dinner.Title, dinner.Description);
				mapView.AddAnnotation (annotation);
			}

			View.AddSubview(mapView);
		}
	}
}


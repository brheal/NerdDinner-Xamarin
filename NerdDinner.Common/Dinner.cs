using System;

namespace NerdDinner
{
	public class Dinner
	{
		public int DinnerID { get; set; }

		public string Title { get; set; }

		public string EventDate { get; set; } // was DateTime

		public string Description { get; set; }

		public string HostedBy { get; set; }

		public string ContactPhone { get; set; }

		public string Address { get; set; }

		public string Country { get; set; }

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public string HostedById { get; set; }
	}
}


using System;
using System.Collections.Generic;
using RestSharp;

namespace NerdDinner
{
	public class DinnerRepositoryOdata : IDinnerRepository
	{
		List<Dinner> dinners;

		public List<Dinner> FindUpcomingDinners()
		{
			if (dinners == null) {
				var request = new RestRequest ();
				request.RootElement = "d";
				request.Resource = "/Dinners";
				request.AddParameter ("$format", "json");
				request.AddParameter ("$top", 10);
				request.AddParameter ("$orderby", "EventDate");
				request.AddParameter ("$filter", string.Format ("year(EventDate) ge {0} and month(EventDate) ge {1} and day(EventDate) ge {2}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));

				var client = new RestClient("http://www.nerddinner.com/Services/OData.svc");
				IRestResponse<List<Dinner>> response = client.Execute<List<Dinner>>(request);
				dinners = response.Data;
			}
			return dinners;
		}
	}
}

using System;
using System.Collections.ObjectModel;
using RestSharp.Extensions;
using System.Globalization;

namespace NerdDinner
{
	public class DinnerViewModel
	{
		public Dinner Dinner { get; private set; }

		public ObservableCollection<PropertyGroup> PropertyGroups { get; private set; }

		public DinnerViewModel (Dinner dinner)
		{
			this.Dinner = dinner;

			PropertyGroups = new ObservableCollection<PropertyGroup> ();

			var general = new PropertyGroup ("General");
			general.Add ("Title", dinner.Title, PropertyType.Generic);
			general.Add ("EventDate", dinner.EventDate.ParseJsonDate (CultureInfo.CurrentUICulture).ToString(), PropertyType.Generic);
			general.Add ("Address", dinner.Address, PropertyType.Address);
			if (general.Properties.Count > 0) {
				PropertyGroups.Add (general);
			}

			var phone = new PropertyGroup ("Phone");
			phone.Add ("Phone", dinner.ContactPhone, PropertyType.Phone);
			if (phone.Properties.Count > 0) {
				PropertyGroups.Add (phone);
			}

			var description = new PropertyGroup ("Description");
			description.Add ("Description", dinner.Description, PropertyType.Generic);
			if (description.Properties.Count > 0) {
				PropertyGroups.Add (description);
			}
		}
	}
}


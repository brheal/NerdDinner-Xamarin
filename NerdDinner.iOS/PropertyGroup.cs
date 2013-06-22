using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NerdDinner
{
	public class PropertyGroup : IEnumerable<Property>
	{
		public string Title { get; private set; }
		public ObservableCollection<Property> Properties { get; private set; }

		public PropertyGroup (string title)
		{
			Title = title;
			Properties = new ObservableCollection<Property> ();
		}

		public void Add (string name, string value, PropertyType type)
		{
			if (!string.IsNullOrWhiteSpace (value)) {
				Properties.Add (new Property (name, value, type));
			}
		}

		IEnumerator<Property> IEnumerable<Property>.GetEnumerator ()
		{
			return Properties.GetEnumerator ();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return Properties.GetEnumerator ();
		}
	}
}


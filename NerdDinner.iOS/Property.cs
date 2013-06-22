using System;

namespace NerdDinner
{
	public enum PropertyType
	{
		Generic,
		Phone,
		Email,
		Url,
		Twitter,
		Address,
	}

	public class Property
	{
		public string Name { get; private set; }
		public string Value { get; private set; }
		public PropertyType Type { get; private set; }

		public Property (string name, string value, PropertyType type)
		{
			Name = name;
			Value = value.Trim ();
			Type = type;
		}

		public override string ToString ()
		{
			return string.Format ("{0} = {1}", Name, Value);
		}
	}
}


using System;

namespace ExpressiveAttributes
{
	[AttributeUsage(AttributeTargets.All, Inherited = false)]
	public class IAmAwesomeAttribute : Attribute
	{
		public string Comment { get; set; }

		public IAmAwesomeAttribute(string comment = "")
		{
			Comment = comment;
		}
	}
}
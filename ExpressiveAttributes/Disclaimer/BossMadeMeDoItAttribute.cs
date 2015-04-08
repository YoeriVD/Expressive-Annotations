using System;

namespace ExpressiveAttributes.Disclaimer
{
	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
	public class BossMadeMeDoItAttribute : Attribute
	{
		public string Comment { get; set; }
		
		public BossMadeMeDoItAttribute(string comment = "")
		{
			Comment = comment;
		}
	}
}

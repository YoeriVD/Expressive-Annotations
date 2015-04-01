using System;

namespace ExpressiveAttributes
{
	[AttributeUsage(AttributeTargets.All, Inherited = false)]
	public class AhaMomentAttribute : Attribute
	{
		public Where Where { get; set; }

		public AhaMomentAttribute(Where where)
		{
			Where = @where;
		}
	}
}
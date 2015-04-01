using System;

namespace ExpressiveAttributes
{
	[AttributeUsage(AttributeTargets.All, Inherited = false)]
	public class AhaMomentAttribute : Attribute
	{
		public enum Where
		{
			TrafficJam,
			Toilet,
			Shower
		}

		private readonly Where _where;

		public AhaMomentAttribute(Where where)
		{
			_where = @where;
		}
	}
}
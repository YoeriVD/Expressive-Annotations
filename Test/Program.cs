using ExpressiveAttributes;
using ExpressiveAttributes.Disclaimer;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}
	[BossMadeMeDoIt("random comment")]
	[AhaMoment(Where.Shower)]
	[HandsOff(ByOrderOf = "the cheff", OnPainOf = Consequence.PaperCut)]
	class Dummy {}
}

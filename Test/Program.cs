using ExpressiveAttributes;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}
	[IAmAwesome()]
	[LegacySucks()]
	[BossMadeMeDoIt]
	[BossMadeMeDoIt("random comment")]
	[AhaMoment(Where.Shower)]
	[HandsOff(ByOrderOf = "the cheff", OnPainOf = Consequence.PaperCut)]
	class Dummy {}
}

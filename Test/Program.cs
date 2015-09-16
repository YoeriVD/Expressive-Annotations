using System;
using Autofac;
using ExpressiveAttributes;
using ExpressiveAttributes.Autofac;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
		    var cb = new ContainerBuilder();
		    cb.EnableAttributeInterceptors();
		    cb.Register(c => new InterceptorTests());
		    var container = cb.Build();
		    using (var scope = container.BeginLifetimeScope())
		    {
		        var interceptorTest = scope.Resolve<InterceptorTests>();
                interceptorTest.CantTouchThisTest();
		    }

		    Console.ReadKey();
		}
	}
	[IAmAwesome()]
	[LegacySucks()]
	[BossMadeMeDoIt]
	[BossMadeMeDoIt("random comment")]
	[AhaMoment(Where.Shower)]
	[HandsOff(ByOrderOf = "the cheff", OnPainOf = Consequence.PaperCut)]
    [CantTouchThis(Stop.Hammertime)]
    class Dummy {}

    [EnableAttributeInterceptors]
    class InterceptorTests
    {
        [CantTouchThis(Stop.Hammertime)]
        public void CantTouchThisTest()
        {
            Console.WriteLine("FAIL");
        }
    }
}

using System;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using ExpressiveAttributes;
using ExpressiveAttributes.Autofac;
using ExpressiveAttributes.Autofac.Interceptors;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<InterceptorTests>()
                .AsSelf()
                .EnableClassInterceptors()
                .InterceptedBy(typeof (AutofacInterceptor));

            cb.EnableAttributeInterceptors();
            //cb.Register(c => new InterceptorTests());
            var container = cb.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var interceptorTest = scope.Resolve<InterceptorTests>();
                interceptorTest.CantTouchThisTest();
            }

            Console.ReadKey();
        }
    }

    [IAmAwesome]
    [LegacySucks]
    [BossMadeMeDoIt]
    [BossMadeMeDoIt("random comment")]
    [AhaMoment(Where.Shower)]
    [HandsOff(ByOrderOf = "the cheff", OnPainOf = Consequence.PaperCut)]
    [CantTouchThis(Stop.Hammertime)]
    internal class Dummy
    {
    }

    [EnableAttributeInterceptors]
    internal class InterceptorTests
    {
        [CantTouchThis(Stop.Hammertime)]
        public virtual void CantTouchThisTest()
        {
            Console.WriteLine("CantTouchThisTest FAILED");
        }
    }
}
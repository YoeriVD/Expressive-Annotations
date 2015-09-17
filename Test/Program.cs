﻿using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using ExpressiveAttributes;
using ExpressiveAttributes.Autofac;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cb = new ContainerBuilder();
            cb.EnableAttributeInterceptors();
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
    
    internal class InterceptorTests
    {
        [CantTouchThis(Stop.Hammertime)]
        public virtual void CantTouchThisTest()
        {
            Console.WriteLine("CantTouchThisTest FAILED");
        }
    }
}
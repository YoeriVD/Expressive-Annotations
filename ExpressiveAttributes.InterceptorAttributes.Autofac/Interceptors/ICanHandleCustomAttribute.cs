using System;
using Castle.DynamicProxy;

namespace ExpressiveAttributes.Autofac.Interceptors
{
    internal interface ICanHandleACustomAttribute
    {
        bool IsSuitedFor(Attribute attribute);
        void DoMagic(IInvocation invocation);
    }
}
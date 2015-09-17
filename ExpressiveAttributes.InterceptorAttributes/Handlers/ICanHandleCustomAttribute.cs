using System;
using System.Reflection;

namespace ExpressiveAttributes.Interceptors
{
    public interface ICanHandleACustomAttribute
    {
        bool IsSuitedFor(Attribute attribute);
        ICanHandleACustomAttribute DoMagic(MethodInfo invocation);
        bool CanIContinue();
    }
}
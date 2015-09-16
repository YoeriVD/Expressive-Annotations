using System;
using System.Diagnostics;
using System.IO;
using Castle.DynamicProxy;

namespace ExpressiveAttributes.Autofac.Interceptors
{
    internal class CantTouchThisHandler : ICanHandleACustomAttribute
    {
        private CantTouchThisAttribute _attribute;

        public bool IsSuitedFor(Attribute attribute)
        {
            _attribute = attribute as CantTouchThisAttribute;
            return _attribute != null;
        }

        public ICanHandleACustomAttribute DoMagic(IInvocation invocation)
        {
            var stop = _attribute.Stop;
            var message = $"Stop, {stop}!";
            try
            {
                Console.WriteLine(message);
            }
            catch (IOException)
            {
                Debug.WriteLine(message);
            }
            return this;
        }

        public bool CanIContinue()
        {
            return !IsSuitedFor(_attribute);
        }
    }
}
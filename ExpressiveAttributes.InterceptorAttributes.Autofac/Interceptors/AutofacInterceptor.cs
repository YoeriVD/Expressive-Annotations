using System;
using System.Linq;
using Castle.Core.Internal;
using Castle.DynamicProxy;

namespace ExpressiveAttributes.Autofac.Interceptors
{
    public class AutofacInterceptor : IInterceptor
    {
        private readonly ICanHandleACustomAttribute[] handlers = {new CantTouchThisHandler()};

        /// <exception cref="TypeLoadException">A custom attribute type could not be loaded. </exception>
        public void Intercept(IInvocation invocation)
        {
            var customAttributes = invocation.Method.GetCustomAttributes(true).OfType<Attribute>();

            customAttributes
                .ForEach(
                    attribute =>
                        handlers
                            .Where(handler => handler.IsSuitedFor(attribute))
                            .ForEach(handler => handler.DoMagic(invocation)));
        }
    }
}
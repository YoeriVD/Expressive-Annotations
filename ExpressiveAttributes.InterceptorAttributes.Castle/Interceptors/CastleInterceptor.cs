using System;
using System.Linq;
using Castle.DynamicProxy;

namespace ExpressiveAttributes.Interceptors
{
    public class CastleInterceptor : IInterceptor
    {
        private readonly ICanHandleACustomAttribute[] handlers = {new CantTouchThisHandler()};

        /// <exception cref="TypeLoadException">A custom attribute type could not be loaded. </exception>
        public void Intercept(IInvocation invocation)
        {
            var customAttributes = invocation.Method.GetCustomAttributes(true).OfType<Attribute>();

            var reports = customAttributes
                .Select(
                    attribute =>
                        handlers
                            .Where(handler => handler.IsSuitedFor(attribute))
                            .Select(handler => handler.DoMagic(invocation.Method).CanIContinue()));

            if (reports
                .SelectMany(report => report.Select(canProceed => canProceed))
                .All(canProceed => canProceed))
                invocation.Proceed();
        }
    }
}
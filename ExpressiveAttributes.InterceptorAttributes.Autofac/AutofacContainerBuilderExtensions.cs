using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using ExpressiveAttributes.Interceptors;

namespace ExpressiveAttributes.Autofac
{
    public static class AutofacContainerBuilderExtensions
    {
        public static ContainerBuilder EnableAttributeInterceptors(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(Assembly.GetCallingAssembly())
                .AsSelf()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(CastleInterceptor));


            builder.Register(c => new CastleInterceptor());
            return builder;
        }
    }
}
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using ExpressiveAttributes.Autofac.Interceptors;

namespace ExpressiveAttributes.Autofac
{
    public static class AutofacContainerBuilderExtensions
    {
        public static ContainerBuilder EnableAttributeInterceptors(this ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(Assembly.GetCallingAssembly())
                .AsSelf()
                .Where(t => t.GetCustomAttributes().OfType<EnableAttributeInterceptorsAttribute>().Any())
                .EnableClassInterceptors()
                .InterceptedBy(typeof(AutofacInterceptor));


            builder.Register(c => new AutofacInterceptor());
            return builder;
        }
    }
}
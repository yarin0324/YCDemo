using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;

namespace Api.Interceptor
{
    public class AopServiceExtension
    {
        public static void AopServiceBootstrap(ContainerBuilder builder, string serviceAssemblyName)
        {
            #region 註冊攔截器

            //異常攔截
            builder.RegisterType<ExceptionInterceptor>().AsSelf();

            #endregion

            //註冊服務
            builder.RegisterAssemblyTypes(Assembly.Load(serviceAssemblyName))
                .AsImplementedInterfaces().InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()
                .InterceptedBy(new Type[] { typeof(ExceptionInterceptor) });
        }
    }
}

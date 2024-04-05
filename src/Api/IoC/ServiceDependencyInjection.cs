using Service;

namespace Api.IoC
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
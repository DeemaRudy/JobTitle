using JobTitle.BLL.DI;

namespace JobTitle.Api.DI
{
    public static class ApiDependencies
    {
        public static IServiceCollection AddApiDependencyGroup(
                this IServiceCollection services)
        {
            services.AddBlDependencyGroup();

            return services;
        }
    }
}

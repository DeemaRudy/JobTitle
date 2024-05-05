using JobTitle.BLL.Interfaces;
using JobTitle.BLL.Services;
using JobTitle.DAL.DI;
using Microsoft.Extensions.DependencyInjection;

namespace JobTitle.BLL.DI
{
    public static class BlDependencies
    {
        public static IServiceCollection AddBlDependencyGroup(
             this IServiceCollection services)
        {
            services.AddDalDependencyGroup();
            services.AddScoped<IJobTitleService, JobTitleService>();

            return services;
        }
    }
}

using JobTitle.DAL.EF;
using JobTitle.DAL.Interfaces;
using JobTitle.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using JobTitleEntity = JobTitle.DAL.Entities.JobTitle;

namespace JobTitle.DAL.DI
{
    public static class DalDependencies
    {
        public static IServiceCollection AddDalDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<JobTitleEntity>), typeof(JobTitleRepository));
            services.AddScoped(typeof(JobTitleContext));

            return services;
        }
    }
}

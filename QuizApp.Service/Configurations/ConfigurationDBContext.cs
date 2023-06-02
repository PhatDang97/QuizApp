using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Core.Data;

namespace QuizApp.Service.Configurations
{
    public static class ConfigurationDBContext
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuizAppDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("QuizAppDB"));
                //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }
    }
}

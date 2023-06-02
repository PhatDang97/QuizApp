using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizApp.Core.Repositories;
using QuizApp.Service.Services;

namespace QuizApp.Service.Configurations
{
    public static class ConfigurationCoreService
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Auto Mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

            #region DI
            services.AddTransient<ITopicService, TopicService>();
            services.AddTransient<IQuestionGroupService, QuestionGroupService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IParticipantService, ParticipantService>();
            services.AddTransient<IParticipantResultService, ParticipantResultService>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            return services;
        }
    }
}

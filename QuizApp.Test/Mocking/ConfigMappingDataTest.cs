using AutoMapper;
using QuizApp.Service.Mappings;

namespace QuizApp.Test.Mocking
{
    public static class ConfigMappingDataTest
    {
        public static IMapper MappingData()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            var mapper = mappingConfig.CreateMapper();

            return mapper;
        }
    }
}

using AutoMapper;
using QuizApp.Common.Paging;
using QuizApp.Core.Entities;
using QuizApp.Service.Services.DTOs;

namespace QuizApp.Service.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TopicDto, Topic>().ReverseMap();
            CreateMap<TopicCreateDto, Topic>().ReverseMap();

            CreateMap<QuestionGroupDto, QuestionGroup>().ReverseMap();
            CreateMap<QuestionGroupCreateDto, QuestionGroup>().ReverseMap();
            CreateMap<PagedResult<QuestionGroupDto>, PagedResult<QuestionGroup>>().ReverseMap();

            CreateMap<QuestionDto, Question>().ReverseMap();
            CreateMap<QuestionCreateDto, Question>().ReverseMap();

            CreateMap<ParticipantDto, Participant>().ReverseMap();
            CreateMap<ParticipantCreateDto, Participant>().ReverseMap();
            CreateMap<ParticipantResultDto, ParticipantResult>().ReverseMap();
            CreateMap<ParticipantResultCreateDto, ParticipantResult>().ReverseMap();
            CreateMap<QuizResultsDto, QuizResults>().ReverseMap();
            CreateMap<QuizResultsCreateDto, QuizResults>().ReverseMap();

        }
    }
}

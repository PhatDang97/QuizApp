using QuizApp.Common.Paging;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public interface IQuestionGroupRepository : IBaseRepository<QuestionGroup>
    {
        Task<PagedResult<QuestionGroup>> GetQuestionGroupsPaging(GetQuestionGroupPagingRequest request);

    }
}

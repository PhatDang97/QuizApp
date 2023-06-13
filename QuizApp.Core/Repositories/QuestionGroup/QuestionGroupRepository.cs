using Microsoft.EntityFrameworkCore;
using QuizApp.Common.Paging;
using QuizApp.Core.Data;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public class QuestionGroupRepository : BaseRepository<QuestionGroup>, IQuestionGroupRepository
    {
        public QuestionGroupRepository(QuizAppDBContext context) : base(context)
        {
        }

        public async Task<PagedResult<QuestionGroup>> GetQuestionGroupsPaging(GetQuestionGroupPagingRequest request)
        {
            var questionGroups = _entities.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Keyword))
            {
                questionGroups = questionGroups.Where(x => x.Name.Contains(request.Keyword));
            }

            int totalRows = await questionGroups.CountAsync();

            var data = await questionGroups.Skip((request.PageIndex - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

            var result = new PagedResult<QuestionGroup>()
            {
                TotalRecords = totalRows,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return result;
        }

        public async Task<QuestionGroup> GetByName(string name)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task UpdateTotalQuestion(Guid questionGroupId)
        {
            var questionGroup = await _entities.Include(x => x.Questions).FirstOrDefaultAsync(x => x.Id == questionGroupId);
            if(questionGroup != null)
            {
                questionGroup.TotalQuestion = questionGroup.Questions.Count();
                _entities.Update(questionGroup);
            }
        }
    }
}

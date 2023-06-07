using QuizApp.Core.Data;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuizAppDBContext context) : base(context)
        {
        }

        //public Task<List<int>> GetAnswers(int[] ids)
        //{
        //    var result = _entities.AsEnumerable()
        //        .Where(x => ids.Contains(x.Id))
        //        .OrderBy(x => { return Array.IndexOf(ids, x.Id); })
        //        .Select(x => x.Answer)
        //        .ToList();

        //}
    }
}

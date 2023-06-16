using QuizApp.Core.Data;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public class QuizResultsRepository : BaseRepository<QuizResults>, IQuizResultsRepository
    {
        public QuizResultsRepository(QuizAppDBContext context) : base(context)
        {
        }
    }
}
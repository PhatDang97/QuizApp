using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        //Task<Question> GetAnswers(int[] ids);
    }
}

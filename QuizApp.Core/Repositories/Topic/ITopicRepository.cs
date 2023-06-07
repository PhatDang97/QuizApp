using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public interface ITopicRepository : IBaseRepository<Topic>
    {
        Task<IList<Topic>> GetAllIncludeGroup();
        Task<Topic> GetByName(string name);
    }
}

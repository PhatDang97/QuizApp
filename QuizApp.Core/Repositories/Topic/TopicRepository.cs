using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Data;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        public TopicRepository(QuizAppDBContext context) : base(context)
        {
        }

        public async Task<IList<Topic>> GetAllIncludeGroup()
        {
            return await _entities.Include(x => x.QuestionGroups).OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<Topic> GetByName(string name)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}

using QuizApp.Core.Data;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public class ParticipantResultRepository : BaseRepository<ParticipantResult>, IParticipantResultRepository
    {
        public ParticipantResultRepository(QuizAppDBContext context) : base(context)
        {
        }
    }
}

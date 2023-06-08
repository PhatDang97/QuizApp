using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Data;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Repositories
{
    public class ParticipantRepository : BaseRepository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(QuizAppDBContext context) : base(context)
        {
        }

        public async Task<Participant> GetByEmail(string email)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}

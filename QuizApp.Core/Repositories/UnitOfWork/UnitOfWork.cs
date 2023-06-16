using QuizApp.Core.Data;

namespace QuizApp.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizAppDBContext _context;
        private readonly ITopicRepository _topicRepository;
        private readonly IQuestionGroupRepository _questionGroupRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly IParticipantResultRepository _participantResultRepository;
        private readonly IQuizResultsRepository _resultRepository;

        public UnitOfWork(QuizAppDBContext context)
        {
            _context = context;
        }

        public ITopicRepository TopicRepository => _topicRepository ?? new TopicRepository(_context);
        public IQuestionGroupRepository QuestionGroupRepository => _questionGroupRepository ?? new QuestionGroupRepository(_context);
        public IQuestionRepository QuestionRepository => _questionRepository ?? new QuestionRepository(_context);
        public IParticipantRepository ParticipantRepository => _participantRepository ?? new ParticipantRepository(_context);
        public IParticipantResultRepository ParticipantResultRepository => _participantResultRepository ?? new ParticipantResultRepository(_context);
        public IQuizResultsRepository ResultRepository => _resultRepository ?? new QuizResultsRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public async Task DisposeAsync()
        {
            if (_context != null)
            {
                await _context.DisposeAsync();
            }
        }

        public bool SaveChanges()
        {
            var result = _context.SaveChanges();
            return result > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}

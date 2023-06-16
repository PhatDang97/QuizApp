namespace QuizApp.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITopicRepository TopicRepository { get; }
        IQuestionGroupRepository QuestionGroupRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IParticipantRepository ParticipantRepository { get; }
        IParticipantResultRepository ParticipantResultRepository { get; }
        IQuizResultsRepository ResultRepository { get; }
        Task DisposeAsync();
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}

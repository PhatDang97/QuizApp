namespace QuizApp.Core.Entities
{
    public class QuizResults : BaseEntity
    {
        public Guid ParticipantResultId { get; set; }
        public virtual ParticipantResult ParticipantResult { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid QuestionGroupId { get; set; }
    }
}

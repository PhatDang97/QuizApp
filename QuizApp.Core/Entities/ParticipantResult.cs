namespace QuizApp.Core.Entities
{
    public class ParticipantResult : BaseEntity
    {
        public int? Score { get; set; }
        public int? TimeTaken { get; set; }
        public bool IsFinish { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid QuestionGroupId { get; set; }
        public virtual QuestionGroup QuestionGroup { get; set; }
        public virtual Participant Participant { get; set; }        
    }
}

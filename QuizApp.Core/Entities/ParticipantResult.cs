namespace QuizApp.Core.Entities
{
    public class ParticipantResult : BaseEntity
    {
        public int? Score { get; set; }
        public int? TimeTaken { get; set; }
        public bool IsFinish { get; set; }
        public virtual QuizResults Result { get; set; }
    }
}

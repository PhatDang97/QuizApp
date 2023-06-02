namespace QuizApp.Service.Services.DTOs
{
    public class ParticipantResultDto
    {
        public Guid Id { get; set; }
        public int? Score { get; set; }
        public int? TimeTaken { get; set; }
        public bool IsFinish { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid QuestionGroupId { get; set; }
        public virtual QuestionGroupDto QuestionGroup { get; set; }
        public virtual ParticipantDto Participant { get; set; }
    }
}

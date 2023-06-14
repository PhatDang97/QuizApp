namespace QuizApp.Service.Services.DTOs
{
    public class ParticipantResultCreateDto
    {
        public int? Score { get; set; }
        public int? TimeTaken { get; set; }
        public bool IsFinish { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid QuestionGroupId { get; set; }
    }
}

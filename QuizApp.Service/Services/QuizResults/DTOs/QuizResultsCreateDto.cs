namespace QuizApp.Service.Services.DTOs
{
    public class QuizResultsCreateDto
    {
        public Guid ParticipantResultId { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid QuestionGroupId { get; set; }
    }
}
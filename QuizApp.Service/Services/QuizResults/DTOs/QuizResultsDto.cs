namespace QuizApp.Service.Services.DTOs
{
    internal class QuizResultsDto
    {
        public Guid Id { get; set; }
        public Guid ParticipantResultId { get; set; }
        public virtual ParticipantResultDto ParticipantResult { get; set; }
        public Guid ParticipantId { get; set; }
        public Guid QuestionGroupId { get; set; }
    }
}
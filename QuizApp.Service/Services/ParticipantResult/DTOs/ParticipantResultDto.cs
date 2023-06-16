namespace QuizApp.Service.Services.DTOs
{
    public class ParticipantResultDto
    {
        public Guid Id { get; set; }
        public int? Score { get; set; }
        public int? TimeTaken { get; set; }
        public bool IsFinish { get; set; }
    }
}

namespace QuizApp.Service.Services.DTOs
{
    public class ParticipantCreateDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public int? Score { get; set; }
        public int? TimeTaken { get; set; }

    }
}

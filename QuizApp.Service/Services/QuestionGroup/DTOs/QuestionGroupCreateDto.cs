namespace QuizApp.Service.Services.DTOs
{
    public class QuestionGroupCreateDto
    {
        public string Name { get; set; }
        public Guid TopicId { get; set; }
    }
}

namespace QuizApp.Service.Services.DTOs
{
    public class QuestionGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TopicId { get; set; }
        public virtual TopicDto Topic { get; set; }
    }
}

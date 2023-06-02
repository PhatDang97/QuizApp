namespace QuizApp.Service.Services.DTOs
{
    public class TopicDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual IList<QuestionGroupDto> QuestionGroups { get; set; }
    }
}

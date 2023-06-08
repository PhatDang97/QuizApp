namespace QuizApp.Service.Services.DTOs
{
    public class QuestionGroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TopicId { get; set; }
        public int Total { get { return Questions.Count(); } }
        public int TimeExpired { get { return Total * 60; } }
        Random random = new Random();
        public int Rate { get { return random.Next(1, 5); } }
        public virtual TopicDto Topic { get; set; }
        public virtual IList<QuestionDto> Questions { get; set; }
    }
}

namespace QuizApp.Service.Services.DTOs
{
    public class QuestionCreateDto
    {
        public string Name { get; set; }
        public String Image { get; set; }
        public String Option1 { get; set; }
        public String Option2 { get; set; }
        public String Option3 { get; set; }
        public String Option4 { get; set; }
        public String Option5 { get; set; }
        public String Option6 { get; set; }
        public int? Answer { get; set; }

        public Guid QuestionGroupId { get; set; }
    }
}

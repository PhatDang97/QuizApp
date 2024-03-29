﻿namespace QuizApp.Service.Services.DTOs
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
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
        public virtual QuestionGroupDto QuestionGroup { get; set; }

        public List<string> AnswerList
        {
            get { return new List<string>() { Option1, Option2, Option3, Option4, Option5, Option6 }; ; }
        }
    }
}

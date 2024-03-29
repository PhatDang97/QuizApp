﻿namespace QuizApp.Core.Entities
{
    public class QuestionGroup : BaseEntity
    {
        public string Name { get; set; }
        public Guid TopicId { get; set; }
        public virtual Topic Topic { get; set; }
        public int TotalQuestion { get; set; }
        public virtual IList<Question> Questions { get; set; }
    }
}
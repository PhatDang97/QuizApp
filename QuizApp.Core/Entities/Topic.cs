namespace QuizApp.Core.Entities
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; }

        public virtual IList<QuestionGroup> QuestionGroups { get; set; }
    }
}

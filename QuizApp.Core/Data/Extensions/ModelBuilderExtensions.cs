using Microsoft.EntityFrameworkCore;
using QuizApp.Core.Entities;

namespace QuizApp.Core.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            IList<Topic> topics = new List<Topic>();
            Topic topic1 = new Topic()
            {
                Id = Guid.NewGuid(),
                Name = "Popular"
            };

            topics.Add(topic1);
            builder.Entity<Topic>().HasData(topics);

            IList<QuestionGroup> questionGroups = new List<QuestionGroup>();
            QuestionGroup questionGroup1 = new QuestionGroup()
            {
                Id = Guid.NewGuid(),
                Name = "Graphic Design",
                TopicId = topic1.Id,
            };

            questionGroups.Add(questionGroup1);

            builder.Entity<QuestionGroup>().HasData(questionGroups);
        }
    }
}

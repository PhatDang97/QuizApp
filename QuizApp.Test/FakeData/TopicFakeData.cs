using Bogus;
using QuizApp.Core.Entities;

namespace QuizApp.Test.FakeData
{
    public static class TopicFakeData
    {
        public static IList<Topic> GenerateData(int count)
        {
            var faker = new Faker<Topic>()
                        .RuleFor(x => x.Name, f => f.Random.ToString())
                         .RuleFor(x => x.Id, Guid.NewGuid());

            return faker.Generate(count);
        }
    }
}

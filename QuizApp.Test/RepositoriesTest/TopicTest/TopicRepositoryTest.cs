using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuizApp.Core.Data;
using QuizApp.Core.Entities;
using QuizApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Test.RepositoriesTest.TopicTest
{
    public class TopicRepositoryTest
    {
        List<Topic> topicList;
        ITopicRepository repository;

        
        [SetUp]
        public async Task Init()
        {
            topicList = GenerateData(10);
            var data = topicList.AsQueryable();
            var mockdbContext = new Mock<QuizAppDBContext>();
            var mockSet = new Mock<DbSet<Topic>>();
            mockSet.As<IQueryable<Topic>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Topic>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Topic>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Topic>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
            //mockdbContext.Setup(x => x.Model).Returns(mockdbContext.Object);

            mockdbContext.Setup(x => x.SaveChanges()).Returns(10);

            //var repository = new Mock<ITopicRepository<Topic>>();

        }

        [Test]
        public async Task Test()
        {
            await repository.GetAll();
        }

        private List<Topic> GenerateData(int count)
        {
            var faker = new Faker<Topic>()
                        .RuleFor(x => x.Name, f => f.Name.Locale)
                         .RuleFor(x => x.Id, Guid.NewGuid());

            return faker.Generate(count);

        }

        //[SetUp]
        //public void Setup()
        //{
        //}

        //[Test]
        //public void Test1()
        //{
        //    Assert.Pass();
        //}
    }
}

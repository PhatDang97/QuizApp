using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using QuizApp.Core.Data;
using QuizApp.Core.Entities;
using QuizApp.Core.Repositories;
using QuizApp.Test.FakeData;
using QuizApp.Test.Mocking;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace QuizApp.Test.RepositoriesTest.TopicTest
{
    public class TopicRepositoryTest
    {
        BaseRepository<Topic> topicRepository;
        List<Topic> topicList;
        Mock<QuizAppDBContext> mockDbContext;

        [SetUp]
        public void Initialize()
        {
            topicList = TopicFakeData.GenerateData(10).ToList();

            var mockSet = topicList.ToAsyncDbSetMock();

            mockDbContext = new Mock<QuizAppDBContext>();
            mockDbContext.Setup(x => x.Set<Topic>()).Returns(mockSet.Object);
            mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            topicRepository = new BaseRepository<Topic>(mockDbContext.Object);
        }

        [Test]
        public async Task GetAll_HaveData_ReturnsCorrectResults()
        {
            // Range => function Initialzie above hanlde

            // Act
            var result = await topicRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);

            Assert.AreEqual(result.Count(), topicList.Count());
        }

        //[Theory]
        //[InlineData()]
        //public void Add_NewTopic_ReturnsCorrectResult(Topic topic)
        //{
        //    // Arrange
        //    //var topic = new Topic();
        //    //topic = new Topic() { Name = " 123" };

        //    var context = new Mock<QuizAppDBContext>();
        //    var dbSetMock = new Mock<DbSet<Topic>>();
        //    context.Setup(x => x.Set<Topic>()).Returns(dbSetMock.Object);
        //    dbSetMock.Setup(x => x.Add(It.IsAny<Topic>())).Returns(topic);

        //    // Act
        //    var repository = new BaseRepository<Topic>(context.Object);
        //    repository.Add(topic);

        //    //Assert
        //    context.Verify(x => x.Set<Topic>());
        //    dbSetMock.Verify(x => x.Add(It.Is<Topic>(y => y == topic)));
        //}
    }

    public class TopicData : IEnumerable<Topic>
    {
        public IEnumerator<Topic> GetEnumerator()
        {
            yield return new Topic() { Name ="123" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

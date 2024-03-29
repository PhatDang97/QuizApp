﻿using Moq;
using QuizApp.Core.Data;
using QuizApp.Core.Entities;
using QuizApp.Core.Repositories;
using QuizApp.Test.FakeData;
using QuizApp.Test.Mocking;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace QuizApp.Test.RepositoriesTest.TopicTest
{
    public class TopicRepositoryTest
    {
        //TopicRepository topicRepository;
        BaseRepository<Topic> topicRepository;
        List<Topic> topicList;
        Mock<QuizAppDBContext> mockDbContext;
        UnitOfWork unitOfWork;

        [SetUp]
        public void Initialize()
        {
            topicList = TopicFakeData.GenerateData(10).ToList();

            var mockSet = topicList.ToAsyncDbSetMock();

            mockDbContext = new Mock<QuizAppDBContext>();
            mockDbContext.Setup(x => x.Set<Topic>()).Returns(mockSet.Object);
            mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            topicRepository = new BaseRepository<Topic>(mockDbContext.Object);

            //topicRepository = new TopicRepository(mockDbContext.Object);
            unitOfWork = new UnitOfWork(mockDbContext.Object);
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

        [Test]
        public async Task Add_NewTopic_ReturnsCorrectResult()
        {
            // Arrange
            var topic = topicList.First();

            // Act
            await topicRepository.Add(topic);
            var result = await unitOfWork.SaveChangesAsync();

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task Update_Topic_ReturnsCorrectResult()
        {
            // Arrane
            var topic = topicList.First();

            // Act
            topicRepository.Update(topic);
            var result = await unitOfWork.SaveChangesAsync();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task Delete_Topic_ReturnsCorrectResult()
        {
            // Arrange
            var topic = topicList.First();

            // Act
            topicRepository.Delete(topic);
            var result = await unitOfWork.SaveChangesAsync();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task GetById_Topic_ReturnsCorrectResult()
        {
            var result = await topicRepository.GetById(topicList.First().Id);

            Assert.IsNotNull(result);
        }
    }
}
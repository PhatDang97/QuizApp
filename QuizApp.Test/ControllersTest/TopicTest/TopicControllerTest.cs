using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuizApp.Controllers;
using QuizApp.Core.Data;
using QuizApp.Core.Entities;
using QuizApp.Core.Repositories;
using QuizApp.Service.Services;
using QuizApp.Service.Services.DTOs;
using QuizApp.Test.FakeData;
using QuizApp.Test.Mocking;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace QuizApp.Test.ControllersTest.TopicTest
{
    public class TopicControllerTest
    {
        List<Topic> topicList;
        Mock<QuizAppDBContext> mockDbContext;
        private IMapper _mapper;
        Mock<UnitOfWork> mockUnitOfWork;
        Mock<TopicService> mockTopicService;
        Mock<DbSet<Topic>> mockSet;
        TopicController topicController;

        [SetUp]
        public void Initialize()
        {
            topicList = TopicFakeData.GenerateData(10).ToList();
            mockSet = topicList.ToAsyncDbSetMock();

            mockDbContext = new Mock<QuizAppDBContext>();
            mockDbContext.Setup(x => x.Set<Topic>()).Returns(mockSet.Object);
            mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            _mapper = ConfigMappingDataTest.MappingData();

            mockUnitOfWork = new Mock<UnitOfWork>(mockDbContext.Object);

            mockTopicService = new Mock<TopicService>(mockUnitOfWork.Object, _mapper);
            topicController = new TopicController(mockTopicService.Object);
        }

        [Test]
        public async Task GetAll_Topic_ReturnCorrectResults()
        {
            var result = await topicController.GetAll();

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Create_Topic_ReturnCorrectResults()
        {
            // Arrange
            var topic = new TopicCreateDto()
            {
                Name = "new Topic"
            };

            // Act
            var result = await topicController.Create(topic);


            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Delete_Topic_ReturnCorrectResults()
        {
            // Arrange
            var topicId = topicList.First().Id;

            // Act
            var result = await topicController.Delete(topicId);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

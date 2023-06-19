using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuizApp.Core.Data;
using QuizApp.Core.Entities;
using QuizApp.Core.Repositories;
using QuizApp.Service.Services;
using QuizApp.Service.Services.DTOs;
using QuizApp.Test.FakeData;
using QuizApp.Test.Mocking;

namespace QuizApp.Test.ServicesTest.TopicTest
{
    public class TopicServiceTest
    {
        TopicService topicService;
        List<Topic> topicList;
        Mock<UnitOfWork> mockUnitOfWork;
        private IMapper _mapper;
        Mock<QuizAppDBContext> mockDbContext;
        Mock<DbSet<Topic>> mockSet;


        [SetUp]
        public void Initialize()
        {
            topicList = TopicFakeData.GenerateData(10).ToList();
            mockSet = topicList.ToAsyncDbSetMock();
            mockDbContext = new Mock<QuizAppDBContext>();
            
            mockDbContext.Setup(x => x.Set<Topic>()).Returns(mockSet.Object);

            //mockSet.Setup(x => x.FindAsync(It.IsAny<List<Topic>>())).Returns((List<Topic> list) => { return new ValueTask<Topic?>(topicList.FirstOrDefault(x => x.Id == list.First().Id)); });
            //mockSet.Setup(x => x.Remove(It.IsAny<Topic>())).Callback<Topic>((entity) => topicList.Remove(entity));
            
            mockDbContext.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            _mapper = ConfigMappingDataTest.MappingData();

            mockUnitOfWork = new Mock<UnitOfWork>(mockDbContext.Object);

            topicService = new TopicService(mockUnitOfWork.Object, _mapper);
        }

        [Test]
        public async Task GetAll_HaveData_ReturnsCorrectResults()
        {
            // Act
            var result = await topicService.GetAll();
            
            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Create_NewTopic_ReturnsCorrectResults()
        {
            // Arrange
            var topic = new TopicCreateDto() { Name = "new topics"};

            // Act
            var result = await topicService.Create(topic);

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Delete_NewTopic_ReturnsCorrectResults()
        {
            // Arrange
            var topic = topicList.First();

            // Act
            var result = await topicService.DeleteById(topic.Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccessed);
        }
    }
}

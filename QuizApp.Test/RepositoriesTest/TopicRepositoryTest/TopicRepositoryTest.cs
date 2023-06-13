using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using QuizApp.Core.Data;
using QuizApp.Core.Entities;
using QuizApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Test.RepositoriesTest.TopicRepositoryTest
{
    public class TopicRepositoryTest
    {
        [Fact]
        public async Task GetByIdAsync_Returns_Product()
        {
            //Setup DbContext and DbSet mock  
            var dbContextMock = new Mock<QuizAppDBContext>();
            var dbSetMock = new Mock<DbSet<Topic>>();
            dbSetMock.Setup(s => s.Find(It.IsAny<Guid>())).Returns(new ValueTask<Topic>().Result);
            dbContextMock.Setup(s => s.Set<Topic>()).Returns(dbSetMock.Object);

            //Execute method of SUT (ProductsRepository)  
            var productRepository = new TopicRepository(dbContextMock.Object);
            var product = await productRepository.GetById(Guid.NewGuid());

            //Assert  
            Assert.Null(product);
        }

    }
}

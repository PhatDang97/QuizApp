using Microsoft.EntityFrameworkCore;
using Moq;

namespace QuizApp.Test.Mocking
{
    public static class MockExtensions
    {
        public static Mock<DbSet<T>> ToAsyncDbSetMock<T>(this IEnumerable<T> source) where T : class 
        {
            var data = source.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IAsyncEnumerable<T>>()
                .Setup(x => x.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                .Returns(new MockAsyncEnumerator<T>(data.GetEnumerator()));

            mockSet.As<IQueryable<T>>()
                .Setup(x => x.Provider)
                .Returns(new MockAsyncQueryProvider<T>(data.Provider));

            mockSet.As<IQueryable<T>>()
                .Setup(x => x.Expression)
                .Returns(data.Expression);

            mockSet.As<IQueryable<T>>()
                .Setup(x => x.GetEnumerator())
                .Returns(() => data.GetEnumerator());

            return mockSet;
        }
    }
}
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace QuizApp.Test.Mocking
{
    public class MockAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _provider;

        internal MockAsyncQueryProvider(IQueryProvider provider)
        {
            _provider = provider;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new MockAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new MockAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _provider.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _provider.Execute<TResult>(expression);
        }

        public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
        {
            return new MockAsyncEnumerable<TResult>(expression);
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute<TResult>(expression));
        }

        //IAsyncEnumerable<TResult> IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression)
        //{
        //    return new MockAsyncEnumerable<TResult>(expression);
        //}

        TResult IAsyncQueryProvider.ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
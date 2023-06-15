namespace QuizApp.Test.Mocking
{
    public class MockAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;

        public MockAsyncEnumerator(IEnumerator<T> enumerator)
        {
            _enumerator = enumerator;
        }

        public T Current => _enumerator.Current;

        public void Dispose()
        {
            _enumerator.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await Task.Run(() => { _enumerator.Dispose(); });
        }

        public Task<bool> MoveNext(CancellationToken cancellationToken)
        {
            return Task.FromResult(_enumerator.MoveNext());
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            return await Task.Run(() => { return Task.FromResult(_enumerator.MoveNext()); });
        }
    }
}